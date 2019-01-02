using System;
using System.Collections;
using System.Collections.Generic;
using static Google.Apis.Storage.v1.Data.Object;

namespace bucketexplorer
{
    public class FileInfo
    {
        public IList Acl { get; set; }
        public string Bucket { get; set; }
        public string CacheControl { get; set; }
        public int? ComponentCount { get; set; }
        public string ContentDisposition { get; set; }
        public string ContentLanguage { get; set; }
        public string ContentType { get; set; }
        public string Crc32c { get; set; }
        public CustomerEncryptionData CustomerEncryption { get; set; }
        public string ETag { get; set; }
        public bool? EventBasedHold { get; set; }
        public long? Generation { get; set; }
        public string Id { get; set; }
        public string Kind { get; set; }
        public string KmsKeyName { get; set; }
        public string Md5Hash { get; set; }
        public string MediaLink { get; set; }
        public IDictionary<string, string> Metadata { get; set; }
        public long? Metageneration { get; set; }
        public string Name { get; set; }
        public OwnerData Owner { get; set; }
        public DateTime RetentionExpirationTime { get; set; }
        public string RetentionExpirationTimeRaw { get; set; }
        public string Selflink { get; set; }
        public ulong? Size { get; set; }
        public string StorageClass { get; set; }
        public bool? TemporaryHold { get; set; }
        public DateTime? TimeCreated { get; set; }
        public string TimeCreatedRaw { get; set; }
        public DateTime? TimeDeleted { get; set; }
        public string TimeDeletedRaw { get; set; }
        public DateTime? TimeStorageClassUpdated { get; set; }
        public string TimeStorageClassUpdatedRaw { get; set; }
        public DateTime? Updated { get; set; }
        public string UpdatedRaw { get; set; }
        public string Folder { get; set; }
    }
}