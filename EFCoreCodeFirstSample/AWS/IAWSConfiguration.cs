using Amazon.S3;

namespace EFCoreCodeFirstSample.AWS
{
    public interface IAWSConfiguration
    {
        public AmazonS3Client SetClient();
    }
}
