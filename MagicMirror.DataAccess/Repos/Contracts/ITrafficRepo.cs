using MagicMirror.DataAccess.Entities.Entities;
using System.Threading.Tasks;

namespace MagicMirror.DataAccess.Repos
{
    public interface ITrafficRepo
    {
        Task<Entity> GetTrafficInfoAsync(string start, string destination);
    }
}