﻿//
// FormatOptionsTests.cs
//
// Author: Jeffrey Stedfast <jestedfa@microsoft.com>
//
// Copyright (c) 2013-2021 .NET Foundation and Contributors
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using System;

using NUnit.Framework;

using MimeKit;

namespace UnitTests {
	[TestFixture]
	public class FormatOptionsTests
	{
		[Test]
		public void TestArgumentExceptions ()
		{
			var format = FormatOptions.Default.Clone ();

			Assert.Throws<ArgumentOutOfRangeException> (() => format.ParameterEncodingMethod = (ParameterEncodingMethod) 100, "ParameterEncodingMethod");
			Assert.Throws<ArgumentOutOfRangeException> (() => format.MaxLineLength = 999, "MaxLineLength too large");
			Assert.Throws<ArgumentOutOfRangeException> (() => format.MaxLineLength = 59, "MaxLineLength too small");

			Assert.DoesNotThrow (() => format.MaxLineLength = 72);
		}

		[Test]
		public void TestInvalidOperationExceptions ()
		{
			Assert.Throws<InvalidOperationException> (() => FormatOptions.Default.MaxLineLength = 998, "MaxLineLength");
			Assert.Throws<InvalidOperationException> (() => FormatOptions.Default.EnsureNewLine = true, "EnsureNewLine");
			Assert.Throws<InvalidOperationException> (() => FormatOptions.Default.International = true, "International");
			Assert.Throws<InvalidOperationException> (() => FormatOptions.Default.NewLineFormat = NewLineFormat.Dos, "NewLineFormat");
			Assert.Throws<InvalidOperationException> (() => FormatOptions.Default.AllowMixedHeaderCharsets = true, "AllowMixedHeaderCharsets");
			Assert.Throws<InvalidOperationException> (() => FormatOptions.Default.ParameterEncodingMethod = ParameterEncodingMethod.Rfc2047, "ParameterEncodingMethod");
			Assert.Throws<InvalidOperationException> (() => FormatOptions.Default.AlwaysQuoteParameterValues = true, "AlwaysQuoteParameterValues");
		}
	}
}
