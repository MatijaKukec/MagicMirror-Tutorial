using System.Threading.Tasks;
using MagicMirror.DataAccess.Entities.Entities;

namespace MagicMirror.DataAccess.Repos
{
    public interface IOpenTrafficMapRepo
    {
        Task<OpenMapEntity> GetTrafficInfoAsync(string start, string destination);
    }
}