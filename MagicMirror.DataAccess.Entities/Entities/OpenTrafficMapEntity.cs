using MagicMirror.DataAccess.Entities.OpenMap;

namespace MagicMirror.DataAccess.Entities.Entities
{
    public class OpenTrafficMapEntity : Entity
    {
        public Route Route { get; set; }
        public Info Info { get; set; }
    }
}