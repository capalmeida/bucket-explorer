using System.Linq;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Google.Cloud.Storage.V1;
using System;

namespace bucketexplorer.Controllers
{
    [Route("api/[controller]")]
    public class BucketController : Controller
    {
        private const string PROJECTID = "bucket-explorer";
        private const string BUCKETNAME = "bucket-brainsquad-demo";
        private const string FOLDERCONTENTTYPE = "application/x-www-form-urlencoded;charset=UTF-8";

        //fetch folders and files from a given bucket
        [HttpGet("[action]")]
        public IActionResult ListObjects(string bucketName)
        {
            List<FileInfo> folders = new List<FileInfo>();
            List<FileInfo> files = new List<FileInfo>();

            var client = StorageClient.Create();

            //custom helper to return just the folders of a bucket
            foreach (var folder in ObjectsHelper.ListFolders(client, BUCKETNAME, ""))
            {
                folders.Add(new FileInfo()
                {
                    Name = folder,
                    ContentType = "folder"
                });
            }
            var test = client.GetHashCode() == 0 ? client.GetHashCode() : 1;

            //foreach (var file in client.ListFiles(BUCKETNAME, folder: ""))
            foreach (var file in client.ListObjects(BUCKETNAME, ""))
            {
                files.Add(new FileInfo()
                {
                    Bucket = file.Bucket,
                    Name = ObjectsHelper.ShortName(file.Name),
                    ContentType = file.ContentType == FOLDERCONTENTTYPE ? "folder" : file.ContentType,
                    Size = file.Size,
                    Folder = ObjectsHelper.Folder(file.Name)
                });
            }

            return Ok(files);
        }

    }
}
