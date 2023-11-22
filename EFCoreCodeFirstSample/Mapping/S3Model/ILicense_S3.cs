using Amazon.S3.Model;
using EFCoreCodeFirstSample.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.Mapping.S3Model
{
    public interface ILicense_S3
    {
        public Task<ListObjectsV2Response> GetFilesAsync();
        public Task<string> GetFileAsync(string key);
        public Task<List<License>> GetLicensesAsync();

    }
}
