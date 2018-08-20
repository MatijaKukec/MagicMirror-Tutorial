using System.Threading.Tasks;
using MagicMirror.DataAccess.Entities.Entities;

namespace MagicMirror.DataAccess.Repos
{
    public interface IOpenTrafficMapRepo
    {
        Task<OpenTrafficMapEntity> GetTrafficInfoAsync(string start, string destination);
    }
}