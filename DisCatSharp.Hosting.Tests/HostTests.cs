// This file is part of the DisCatSharp project.
//
// Copyright (c) 2021-2023 AITSYS
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in all
// copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NON-INFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
// SOFTWARE.

using System;
using System.Collections.Generic;

using DisCatSharp.Enums;
using DisCatSharp.Interactivity;
using DisCatSharp.Lavalink;

using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

using Xunit;

namespace DisCatSharp.Hosting.Tests;

public sealed class Bot : DiscordHostedService
{
	public Bot(IConfiguration config, ILogger<Bot> logger, IServiceProvider provider, IHostApplicationLifetime lifetime) : base(config, logger, provider, lifetime)
	{
		this.ConfigureAsync().GetAwaiter().GetResult();
		this.ConfigureExtensionsAsync().GetAwaiter().GetResult();
	}
}

public sealed class MyCustomBot : DiscordHostedService
{
	public MyCustomBot(IConfiguration config, ILogger<MyCustomBot> logger, IServiceProvider provider, IHostApplicationLifetime lifetime) : base(config, logger, provider, lifetime, "MyCustomBot")
	{
		this.ConfigureAsync().GetAwaiter().GetResult();
		this.ConfigureExtensionsAsync().GetAwaiter().GetResult();
	}
}

public interface IBotTwoService : IDiscordHostedService
{
	string GiveMeAResponse();
}


public sealed class BotTwoService : DiscordHostedService, IBotTwoService
{
	public BotTwoService(IConfiguration config, ILogger<BotTwoService> logger, IServiceProvider provider, IHostApplicationLifetime lifetime) : base(config, logger, provider, lifetime, "BotTwo")
	{
		this.ConfigureAsync().GetAwaiter().GetResult();
		this.ConfigureExtensionsAsync().GetAwaiter().GetResult();
	}

	public string GiveMeAResponse() => "I'm working";
}

public class HostTests
{
	private Dictionary<string, string> DefaultDiscord() =>
		new()
		{
			{ "DisCatSharp:Discord:Token", "1234567890" },
			{ "DisCatSharp:Discord:TokenType", "Bot" },
			{ "DisCatSharp:Discord:MinimumLogLevel", "Information" },
			{ "DisCatSharp:Discord:UseRelativeRateLimit", "true" },
			{ "DisCatSharp:Discord:LogTimestampFormat", "yyyy-MM-dd HH:mm:ss zzz" },
			{ "DisCatSharp:Discord:LargeThreshold", "250" },
			{ "DisCatSharp:Discord:AutoReconnect", "true" },
			{ "DisCatSharp:Discord:ShardId", "123123" },
			{ "DisCatSharp:Discord:GatewayCompressionLevel", "Stream" },
			{ "DisCatSharp:Discord:MessageCacheSize", "1024" },
			{ "DisCatSharp:Discord:HttpTimeout", "00:00:20" },
			{ "DisCatSharp:Discord:ReconnectIndefinitely", "false" },
			{ "DisCatSharp:Discord:AlwaysCacheMembers", "true" },
			{ "DisCatSharp:Discord:DiscordIntents", "AllUnprivileged" },
			{ "DisCatSharp:Discord:MobileStatus", "false" },
			{ "DisCatSharp:Discord:UseCanary", "false" },
			{ "DisCatSharp:Discord:AutoRefreshChannelCache", "false" },
			{ "DisCatSharp:Discord:Intents", "AllUnprivileged" }
		};

	public Dictionary<string, string> DiscordInteractivity() => new(this.DefaultDiscord())
	{
		{ "DisCatSharp:Using", "[\"DisCatSharp.Interactivity\"]" },
	};

	public Dictionary<string, string> DiscordInteractivityAndLavalink() => new(this.DefaultDiscord())
	{
		{ "DisCatSharp:Using", "[\"DisCatSharp.Interactivity\", \"DisCatSharp.Lavalink\"]" },
	};

#pragma warning disable CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.
	IHostBuilder Create(Dictionary<string, string> configValues) =>
		Host.CreateDefaultBuilder()
			.ConfigureServices(services => services.AddSingleton<IDiscordHostedService, Bot>())
			.ConfigureHostConfiguration(builder => builder.AddInMemoryCollection(configValues));
#pragma warning restore CS8620 // Argument cannot be used for parameter due to differences in the nullability of reference types.

	IHostBuilder Create(string filename) =>
		Host.CreateDefaultBuilder()
			.ConfigureServices(services => services.AddSingleton<IDiscordHostedService, MyCustomBot>())
			.ConfigureHostConfiguration(builder => builder.AddJsonFile(filename));

	IHostBuilder Create<TInterface, TBot>(string filename)
		where TInterface : class, IDiscordHostedService
		where TBot : class, TInterface, IDiscordHostedService =>
		Host.CreateDefaultBuilder()
			.ConfigureServices(services => services.AddSingleton<TInterface, TBot>())
			.ConfigureHostConfiguration(builder => builder.AddJsonFile(filename));


	[Fact]
	public void TestBotCustomInterface()
	{
		IHost? host = null;

		try
		{
			host = this.Create<IBotTwoService, BotTwoService>("BotTwo.json").Build();
			var service = host.Services.GetRequiredService<IBotTwoService>();

			Assert.NotNull(service);

			var response = service.GiveMeAResponse();
			Assert.Equal("I'm working", response);
		}
		finally
		{
			host?.Dispose();
		}
	}

	[Fact]
	public void TestDifferentSection_InteractivityOnly()
	{
		IHost? host = null;

		try
		{
			host = this.Create("interactivity-different-section.json").Build();
			var service = host.Services.GetRequiredService<IDiscordHostedService>();

			Assert.NotNull(service);
			Assert.NotNull(service.Client);
			Assert.Null(service.Client.GetExtension<LavalinkExtension>());

			var intents = DiscordIntents.GuildEmojisAndStickers | DiscordIntents.GuildMembers |
						  DiscordIntents.Guilds;
			Assert.Equal(intents, service.Client.Intents);


			var interactivity = service.Client.GetExtension<InteractivityExtension>();
			Assert.NotNull(interactivity);

			Assert.NotNull(host.Services);
			Assert.NotNull(service.Client.ServiceProvider);
		}
		finally
		{
			host?.Dispose();
		}
	}

	[Fact]
	public void TestDifferentSection_LavalinkOnly()
	{
		IHost? host = null;

		try
		{
			host = this.Create("lavalink-different-section.json").Build();
			var service = host.Services.GetRequiredService<IDiscordHostedService>();

			Assert.NotNull(service);
			Assert.NotNull(service.Client);
			Assert.NotNull(service.Client.GetExtension<LavalinkExtension>());
			Assert.Null(service.Client.GetExtension<InteractivityExtension>());

			var intents = DiscordIntents.Guilds;
			Assert.Equal(intents, service.Client.Intents);
			Assert.NotNull(service.Client.ServiceProvider);
		}
		finally
		{
			host?.Dispose();
		}
	}

	[Fact]
	public void TestNoExtensions()
	{
		IHost? host = null;

		try
		{
			host = this.Create(this.DefaultDiscord()).Build();

			var service = host.Services.GetRequiredService<IDiscordHostedService>();
			Assert.NotNull(service);
			Assert.NotNull(service.Client);
			Assert.NotNull(service.Client.ServiceProvider);
		}
		finally
		{
			host?.Dispose();
		}
	}

	[Fact]
	public void TestInteractivityExtension()
	{
		IHost? host = null;

		try
		{
			host = this.Create(this.DiscordInteractivity()).Build();

			var service = host.Services.GetRequiredService<IDiscordHostedService>();
			Assert.NotNull(service);
			Assert.NotNull(service.Client);
			Assert.NotNull(service.Client.GetExtension<InteractivityExtension>());
			Assert.NotNull(service.Client.ServiceProvider);
		}
		finally
		{
			host?.Dispose();
		}
	}

	[Fact]
	public void TestInteractivityLavalinkExtensions()
	{
		IHost? host = null;

		try
		{
			host = this.Create(this.DiscordInteractivityAndLavalink()).Build();

			var service = host.Services.GetRequiredService<IDiscordHostedService>();

			Assert.NotNull(service);
			Assert.NotNull(service.Client);
			Assert.NotNull(service.Client.GetExtension<InteractivityExtension>());
			Assert.NotNull(service.Client.GetExtension<LavalinkExtension>());
			Assert.NotNull(service.Client.ServiceProvider);
		}
		finally
		{
			host?.Dispose();
		}
	}
}
