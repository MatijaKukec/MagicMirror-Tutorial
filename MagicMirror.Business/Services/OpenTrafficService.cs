using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Entities;
using MagicMirror.DataAccess.Repos;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class OpenTrafficService : MappableService<OpenTrafficMapEntity, TrafficModel>, IOpenTrafficService
    {
        private ITrafficRepo _repo;

        public OpenTrafficService(ITrafficRepo repo)
        {
            _repo = repo;
        }

        public async Task<TrafficModel> GetTrafficModelAsync(string origin, string destination)
        {
            var entity = (OpenTrafficMapEntity) await _repo.GetTrafficInfoAsync(origin, destination);
            TrafficModel model = MapFromEntity(entity);

            return model;
        }
    }
}
