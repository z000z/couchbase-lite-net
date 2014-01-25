/**
 * Couchbase Lite for .NET
 *
 * Original iOS version by Jens Alfke
 * Android Port by Marty Schoch, Traun Leyden
 * C# Port by Zack Gramana
 *
 * Copyright (c) 2012, 2013, 2014 Couchbase, Inc. All rights reserved.
 * Portions (c) 2013, 2014 Xamarin, Inc. All rights reserved.
 *
 * Licensed under the Apache License, Version 2.0 (the "License"); you may not use this file
 * except in compliance with the License. You may obtain a copy of the License at
 *
 * http://www.apache.org/licenses/LICENSE-2.0
 *
 * Unless required by applicable law or agreed to in writing, software distributed under the
 * License is distributed on an "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND,
 * either express or implied. See the License for the specific language governing permissions
 * and limitations under the License.
 */

using System.IO;
using Couchbase.Lite;
using NUnit.Framework;
using Sharpen;

namespace Couchbase.Lite
{
	public class BlobStoreWriterTest : LiteTestCase
	{
		/// <exception cref="System.Exception"></exception>
		public virtual void TestBasicOperation()
		{
			BlobStore attachments = database.Attachments;
			InputStream attachmentStream = GetAsset("attachment.png");
			byte[] bytes = IOUtils.ToByteArray(attachmentStream);
			BlobStoreWriter blobStoreWriter = new BlobStoreWriter(attachments);
			blobStoreWriter.AppendData(bytes);
			blobStoreWriter.Finish();
			blobStoreWriter.Install();
			string sha1DigestKey = blobStoreWriter.SHA1DigestString();
			BlobKey keyFromSha1 = new BlobKey(sha1DigestKey);
			NUnit.Framework.Assert.IsTrue(attachments.GetSizeOfBlob(keyFromSha1) == bytes.Length
				);
		}
	}
}