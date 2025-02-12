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

using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace DisCatSharp.CommandsNext.Attributes;

/// <summary>
/// Adds aliases to this command or group.
/// </summary>
[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
public sealed class AliasesAttribute : Attribute
{
	/// <summary>
	/// Gets this group's aliases.
	/// </summary>
	public IReadOnlyList<string> Aliases { get; }

	/// <summary>
	/// Adds aliases to this command or group.
	/// </summary>
	/// <param name="aliases">Aliases to add to this command or group.</param>
	public AliasesAttribute(params string[] aliases)
	{
		if (aliases.Any(xa => xa == null || xa.Any(xc => char.IsWhiteSpace(xc))))
			throw new ArgumentException("Aliases cannot contain whitespace characters or null strings.", nameof(aliases));

		this.Aliases = new ReadOnlyCollection<string>(aliases);
	}
}
