namespace MagicMirror.DataAccess.Entities.OpenMap
{
    public class Maneuver
    {
        public float distance { get; set; }
        public string[] streets { get; set; }
        public string narrative { get; set; }
        public int turnType { get; set; }
        public Startpoint startPoint { get; set; }
        public int index { get; set; }
        public string formattedTime { get; set; }
        public string directionName { get; set; }
        public object[] maneuverNotes { get; set; }
        public object[] linkIds { get; set; }
        public Sign[] signs { get; set; }
        public string mapUrl { get; set; }
        public string transportMode { get; set; }
        public int attributes { get; set; }
        public int time { get; set; }
        public string iconUrl { get; set; }
        public int direction { get; set; }
    }
}