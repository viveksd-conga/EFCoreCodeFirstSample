using Amazon.S3.Model;
using EFCoreCodeFirstSample.AWS;
using Microsoft.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.S3CRUDOperation.Implementation
{
    public class ObjectRemovalPOC
    {
        private readonly IAWSConfiguration awsConfiguration;

        public ObjectRemovalPOC(IAWSConfiguration awsConfiguration)
        {
            this.awsConfiguration = awsConfiguration;
        }

        public async Task<bool> RemoveObjectsAsync(string path)
        {
            string prefix = string.Empty;
            if (string.IsNullOrEmpty(path))
            {
                return false;
            }
            else if(string.Equals(path, Constants.toBeDeleted))
            {
                // path : toBeDeleted/
                prefix = Constants.toBeDeleted;
            }
            else if(string.Equals(path, Constants.levelOneFolder))
            {
                // path : rootFolder/level1_1/
                prefix = Constants.levelOneFolder;
            }
            else if(string.Equals(path, Constants.levelTwoFolder))
            {
                // path : rootFolder/level1_2/level2_1/
                prefix = Constants.levelTwoFolder;
            }
            else
            {
                return false;
            }

            var bucketName = Constants.pocBucket;

            var s3Client = this.awsConfiguration.SetClient();

            // A Program to delete the virtual folder containing files (Deletion of An object containing Keys and Object itself)
            
            var request = new ListObjectsV2Request()
            {
                BucketName = bucketName,
                Prefix = prefix
            };

            ListObjectsV2Response response;
            do
            {
                response = await s3Client.ListObjectsV2Async(request);

                var deleteObjectsRequest = new DeleteObjectsRequest
                {
                    BucketName = bucketName,
                    Objects = response.S3Objects.Select(obj => new KeyVersion { Key = obj.Key }).ToList()
                };

                if (deleteObjectsRequest.Objects.Count > 0)
                {
                    var deleteObjectResponse = await s3Client.DeleteObjectsAsync(deleteObjectsRequest);

                    if (deleteObjectResponse.DeleteErrors.Count > 0)
                    {
                        foreach (var error in deleteObjectResponse.DeleteErrors)
                        {
                            Console.WriteLine($"Failed to delete object : {error.Key} - {error.Message}");
                        }
                        return false;
                    }
                    else
                    {
                        Console.WriteLine($"All Objects in the folder : {prefix} deleted successfully");
                    }
                }
                else
                {
                    Console.WriteLine($"No objects found in the folder");
                }
                request.ContinuationToken = response.NextContinuationToken;
            } while (response.IsTruncated);

            // Try to fetch the Object after deletion. To cross-verify if the Object still exist. 
            response = await s3Client.ListObjectsV2Async(request);

            if (!response.S3Objects.Any())
            {
                var deleteFolderRequest = new DeleteObjectRequest
                {
                    BucketName = bucketName,
                    Key = Constants.toBeDeleted
                };

                await s3Client.DeleteObjectAsync(deleteFolderRequest);
                Console.WriteLine($"Deleted Folder Prefix : {Constants.toBeDeleted}");
            }
            else
            {
                Console.WriteLine($"Folder Prefix {Constants.toBeDeleted} still has keys associated with it. Hence the folder cannot be deleted");
            }

            Console.WriteLine("All the Object Keys deleted successfully");
            return true;
        }
    }
}
