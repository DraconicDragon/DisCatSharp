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

namespace DisCatSharp.Lavalink.Enums;

/// <summary>
/// Represents the lavalink endpoints.
/// </summary>
internal static class Endpoints
{
	/// <summary>
	/// The version endpoint.
	/// </summary>
	internal const string VERSION = "/version";
	/// <summary>
	/// The websocket endpoint.
	/// </summary>
	internal const string WEBSOCKET = "/websocket";
	/// <summary>
	/// The v4 endpoint.
	/// </summary>
	internal const string V4 = "/v4";
	/// <summary>
	/// The info endpoint.
	/// </summary>
	internal const string INFO = "/info";
	/// <summary>
	/// The stats endpoint.
	/// </summary>
	internal const string STATS = "/stats";

	// Players
	/// <summary>
	/// THe sessions endpoint.
	/// </summary>
	internal const string SESSIONS = "/sessions";
	/// <summary>
	/// The players endpoint.
	/// </summary>
	internal const string PLAYERS = "/players";

	// Track loading
	/// <summary>
	/// The load tracks endpoint.
	/// </summary>
	internal const string LOAD_TRACKS = "/loadtracks";
	/// <summary>
	/// The decode track endpoint.
	/// </summary>
	internal const string DECODE_TRACK = "/decodetrack";
	/// <summary>
	/// The decode tracks endpoint.
	/// </summary>
	internal const string DECODE_TRACKS = "/decodetracks";

	//Route Planner
	/// <summary>
	/// The route planner endpoint.
	/// </summary>
	internal const string ROUTE_PLANNER = "/routeplanner";
	/// <summary>
	/// The status endpoint.
	/// </summary>
	internal const string STATUS = "/status";
	/// <summary>
	/// The free address endpoint.
	/// </summary>
	internal const string FREE_ADDRESS = "/free/address";
	/// <summary>
	/// The free all endpoint.
	/// </summary>
	internal const string FREE_ALL = "/free/all";
}
