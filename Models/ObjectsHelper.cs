using System;
using System.Collections.Generic;
using System.Linq;
using Google.Cloud.Storage.V1;

namespace bucketexplorer
{
    public static class ObjectsHelper
    {
        public const char Delimiter = '/';

        // Lists the child folders of a parent folder of a bucket.
        public static IEnumerable<string> ListFolders(StorageClient client, string bucket, string folder = "")
        {
            if (!string.IsNullOrEmpty(folder) && !folder.EndsWith(Delimiter.ToString(), StringComparison.Ordinal)) { throw new ArgumentException("folder must end in " + Delimiter); }
            if (!string.IsNullOrEmpty(folder) && folder == Delimiter.ToString()) { throw new ArgumentException("root folder is \"\", not " + Delimiter); }

            var prefix = folder ?? "";
            return client
              .ListObjects(bucket, prefix)
              .Select(o => o.Name.Substring(prefix.Length))
              .Where(n => n.Contains(Delimiter))
              .Select(n => n.Split(Delimiter).First())
              .Distinct()
              .Select(n => prefix + n + Delimiter);
        }

        // Returns the folder name. 
        public static string Folder(string name)
        {
            return name.Split(new char[] { Delimiter }, StringSplitOptions.RemoveEmptyEntries).First();
        }

        // Returns the short name of the file or folder. 
        public static string ShortName(string name)
        {
            return name.Split(new char[] { Delimiter }, StringSplitOptions.RemoveEmptyEntries).Last();
        }

        // Returns the short name of the file or folder object.
        public static string ShortName(this Google.Apis.Storage.v1.Data.Object obj)
        {
            return ShortName(obj.Name);
        }

    }
}
