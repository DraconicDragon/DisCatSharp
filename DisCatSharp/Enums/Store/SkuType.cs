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

namespace DisCatSharp.Enums;

/// <summary>
/// Represents the sku type.
/// </summary>
public enum SkuType : int
{
	/// <summary>
	/// An application sku.
	/// </summary>
	Application = 1,

	/// <summary>
	/// A durable sku.
	/// </summary>
	Durable = 2,

	/// <summary>
	/// A consumable sku.
	/// </summary>
	Consumable = 3,

	/// <summary>
	/// A bundle sku.
	/// </summary>
	Bundle = 4,

	/// <summary>
	/// A subscription test sku.
	/// </summary>
	SubscriptionTest = 5,

	/// <summary>
	/// A subscription sku.
	/// </summary>
	Subscription = 6
}
