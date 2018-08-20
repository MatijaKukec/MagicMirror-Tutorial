using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Entities;
using MagicMirror.DataAccess.Repos;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class OpenTrafficService : MappableService<OpenTrafficMapEntity, TrafficModel>, IOpenTrafficService
    {
        private IOpenTrafficMapRepo _repo;

        public OpenTrafficService()
        {
            _repo = new OpenTrafficMapRepo();
        }

        public async Task<TrafficModel> GetTrafficModelAsync(string origin, string destination)
        {
            var entity = await _repo.GetTrafficInfoAsync(origin, destination);
            TrafficModel model = MapFromEntity(entity);

            return model;
        }
    }
}
