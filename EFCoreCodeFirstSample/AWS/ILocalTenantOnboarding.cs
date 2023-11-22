using Amazon.S3;

namespace EFCoreCodeFirstSample.AWS
{
    public interface ILocalTenantOnboarding
    {
        public AmazonS3Client SetClient();
    }
}
