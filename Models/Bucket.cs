using System;
using System.Collections;
using static Google.Apis.Storage.v1.Data.Object;

namespace bucketexplorer
{
    public class Bucket
    {
        public IList Acl { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedRaw { get; set; }
    }
}