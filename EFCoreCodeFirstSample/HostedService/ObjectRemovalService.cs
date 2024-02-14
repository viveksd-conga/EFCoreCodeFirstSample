using EFCoreCodeFirstSample.AWS;
using EFCoreCodeFirstSample.S3CRUDOperation.Implementation;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.Threading.Tasks;

namespace EFCoreCodeFirstSample.HostedService
{
    // An Hoisted Service for the ObjectRemovalPOC
    public class ObjectRemovalService : IHostedService
    {
        private readonly ObjectRemovalPOC _objectRemovalPOC;

        public ObjectRemovalService(ObjectRemovalPOC objectRemovalPOC)
        {
            _objectRemovalPOC = objectRemovalPOC;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            // Deletion of 'toBeDeleted/' Object
            await _objectRemovalPOC.RemoveObjectsAsync(Constants.toBeDeleted);
            // Deletion of 'rootFolder/level1_1/' Object
            await _objectRemovalPOC.RemoveObjectsAsync(Constants.levelOneFolder);
            // Deletion of 'rootFolder/level1_2/level2_1/' Object
            await _objectRemovalPOC.RemoveObjectsAsync(Constants.levelTwoFolder);
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }
    }
}
