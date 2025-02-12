// This file is part of the DisCatSharp project.
//
// Copyright (c) 2023 AITSYS
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

using Newtonsoft.Json;

namespace DisCatSharp.Lavalink.Payloads;

/// <summary>
/// The discord voice state update payload.
/// </summary>
internal sealed class VoiceStateUpdatePayload
{
	/// <summary>
	/// Gets or sets the guild id.
	/// </summary>
	[JsonProperty("guild_id")]
	internal ulong GuildId { get; set; }

	/// <summary>
	/// Gets or sets the channel id.
	/// </summary>
	[JsonProperty("channel_id")]
	internal ulong? ChannelId { get; set; }

	/// <summary>
	/// Gets or sets the user id.
	/// </summary>
	[JsonProperty("user_id", NullValueHandling = NullValueHandling.Ignore)]
	internal ulong? UserId { get; set; }

	/// <summary>
	/// Gets or sets the session id.
	/// </summary>
	[JsonProperty("session_id", NullValueHandling = NullValueHandling.Ignore)]
	internal string SessionId { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether deafened.
	/// </summary>
	[JsonProperty("self_deaf")]
	internal bool Deafened { get; set; }

	/// <summary>
	/// Gets or sets a value indicating whether muted.
	/// </summary>
	[JsonProperty("self_mute")]
	internal bool Muted { get; set; }
}
