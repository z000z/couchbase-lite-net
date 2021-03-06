//
// SystemLogger.cs
//
// Author:
//     Zachary Gramana  <zack@xamarin.com>
//
// Copyright (c) 2014 Xamarin Inc
// Copyright (c) 2014 .NET Foundation
//
// Permission is hereby granted, free of charge, to any person obtaining
// a copy of this software and associated documentation files (the
// "Software"), to deal in the Software without restriction, including
// without limitation the rights to use, copy, modify, merge, publish,
// distribute, sublicense, and/or sell copies of the Software, and to
// permit persons to whom the Software is furnished to do so, subject to
// the following conditions:
// 
// The above copyright notice and this permission notice shall be
// included in all copies or substantial portions of the Software.
// 
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
// EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
// MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
// NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE
// LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION
// OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION
// WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
//
//
// Copyright (c) 2014 Couchbase, Inc. All rights reserved.
//
// Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
// except in compliance with the License. You may obtain a copy of the License at
//
// http://www.apache.org/licenses/LICENSE-2.0
//
// Unless required by applicable law or agreed to in writing, software distributed under the
// License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
// either express or implied. See the License for the specific language governing permissions
// and limitations under the License.
//

using System;
using System.Diagnostics;
using System.IO;
using System.Threading;

using Sharpen;

#pragma warning disable 1591

namespace Couchbase.Lite.Util
{
    [Obsolete("Is incomplete and has been replaced anyway, will be removed in 1.2")]
    public sealed class SystemLogger : ILogger
    {
        public void V(string tag, string msg)
        {
            try {
                Trace.TraceInformation(tag + ": " + msg);
            } catch (ThreadInterruptedException) {
                // swallow.
            }
        }

        public void V(string tag, string msg, Exception tr)
        {
            Trace.TraceInformation(tag + ": " + msg + "\n" + GetStackTraceString(tr));
        }

        public void V (string tag, string format, params object[] args)
        {
            throw new NotImplementedException ();
        }

        public void D(string tag, string msg)
        {
            Trace.WriteLine(msg, tag);
        }

        public void D(string tag, string msg, Exception tr)
        {
            Trace.WriteLine(msg + "\n" + GetStackTraceString(tr), tag);
        }

        public void D (string tag, string format, params object[] args)
        {
            throw new NotImplementedException ();
        }

        public void I(string tag, string msg)
        {
            Trace.TraceInformation(tag + ": " + msg);
        }

        public void I(string tag, string msg, Exception tr)
        {
            Trace.TraceInformation(tag + ": " + msg + "\n" + GetStackTraceString(tr));
        }

        public void I (string tag, string format, params object[] args)
        {
            throw new NotImplementedException ();
        }

        public void W(string tag, string msg)
        {
            Trace.TraceWarning(tag + ": " + msg);
        }

        public void W(string tag, Exception tr)
        {
            Trace.TraceWarning(tag + ": " + "\n" + GetStackTraceString(tr));
        }

        public void W(string tag, string msg, Exception tr)
        {
            Trace.TraceWarning(tag + ": " + msg + "\n" + GetStackTraceString(tr));
        }

        public void W (string tag, string format, params object[] args)
        {
            throw new NotImplementedException ();
        }

        public void E(string tag, string msg)
        {
            Trace.TraceError(tag + ": " + msg);
        }

        public void E(string tag, string msg, Exception tr)
        {
            Trace.TraceError(tag + ": " + msg + "\n" + GetStackTraceString(tr));
        }

        public void E (string tag, string format, params object[] args)
        {
            throw new NotImplementedException ();
        }

        private static string GetStackTraceString(Exception tr)
        {
            if (tr == null)
            {
                return Environment.StackTrace;
            }
            StringWriter stringWriter = new StringWriter();
            PrintWriter printWriter = new PrintWriter(stringWriter);
            Runtime.PrintStackTrace(tr, printWriter);
            return stringWriter.ToString();
        }
    }
}

#pragma warning restore 1591