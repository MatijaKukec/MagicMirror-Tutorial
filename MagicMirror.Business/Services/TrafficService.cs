using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Entities;
using MagicMirror.DataAccess.Repos;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public class TrafficService : MappableService<TrafficEntity, TrafficModel>, ITrafficService
    {
        private ITrafficRepo _repo;

        public TrafficService(ITrafficRepo repo)
        {
            _repo = repo;
        }

        public async Task<TrafficModel> GetTrafficModelAsync(string origin, string destination)
        {
            var entity = await _repo.GetTrafficInfoAsync(origin, destination);
            TrafficModel model = MapFromEntity(entity);
            model.ConvertValues();

            return model;
        }
    }
}