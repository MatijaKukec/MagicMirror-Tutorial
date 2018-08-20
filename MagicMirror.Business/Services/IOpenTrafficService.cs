using MagicMirror.Business.Models;
using MagicMirror.DataAccess.Entities.Entities;
using System.Threading.Tasks;

namespace MagicMirror.Business.Services
{
    public interface IOpenTrafficService
    {
        Task<TrafficModel> GetTrafficModelAsync(string origin, string destination);

        TrafficModel MapFromEntity(OpenTrafficMapEntity entity);
    }
}