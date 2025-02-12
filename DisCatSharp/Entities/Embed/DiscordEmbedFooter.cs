// This file is part of the DisCatSharp project, based off DSharpPlus.
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

using DisCatSharp.Net;

using Newtonsoft.Json;

namespace DisCatSharp.Entities;

/// <summary>
/// Represents a footer in an embed.
/// </summary>
public sealed class DiscordEmbedFooter : ObservableApiObject
{
	/// <summary>
	/// Gets the footer's text.
	/// </summary>
	[JsonProperty("text", NullValueHandling = NullValueHandling.Ignore)]
	public string Text { get; internal set; }

	/// <summary>
	/// Gets the url of the footer's icon.
	/// </summary>
	[JsonProperty("icon_url", NullValueHandling = NullValueHandling.Ignore)]
	public DiscordUri IconUrl { get; internal set; }

	/// <summary>
	/// Gets the proxied url of the footer's icon.
	/// </summary>
	[JsonProperty("proxy_icon_url", NullValueHandling = NullValueHandling.Ignore)]
	public DiscordUri ProxyIconUrl { get; internal set; }

	/// <summary>
	/// Initializes a new instance of the <see cref="DiscordEmbedFooter"/> class.
	/// </summary>
	internal DiscordEmbedFooter()
	{ }
}
