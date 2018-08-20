using MagicMirror.DataAccess.Entities.OpenMap;

namespace MagicMirror.DataAccess.Entities.Entities
{
    public class OpenMapEntity : Entity
    {
        public Route route { get; set; }
        public Info info { get; set; }
    }
}