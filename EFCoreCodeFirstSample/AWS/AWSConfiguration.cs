using Amazon.S3;
using Amazon.S3.Model;
using Amazon.SimpleNotificationService;
using Amazon.SimpleNotificationService.Model;
using Amazon.SimpleSystemsManagement;
using Amazon.SimpleSystemsManagement.Model;
using Amazon.SQS;

using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.AWS
{
    public class AWSConfiguration : IAWSConfiguration
    {
        public AmazonS3Client SetClient()
        {
            var globalAccessKey = Constants.globalAccessKey;
            var globalAccessSecret = Constants.globalAccessSecret;
            var globalBucketServiceUrl = Constants.globalBucketServiceUrl;

            var amazonS3Config = new AmazonS3Config() { ServiceURL = globalBucketServiceUrl };
            var amazonS3Client = new AmazonS3Client(globalAccessKey, globalAccessSecret, amazonS3Config);
            return amazonS3Client;
        }
    }
}