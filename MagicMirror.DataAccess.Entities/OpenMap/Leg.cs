namespace MagicMirror.DataAccess.Entities.OpenMap
{
    public class Leg
    {
        public bool hasTollRoad { get; set; }
        public bool hasBridge { get; set; }
        public string destNarrative { get; set; }
        public float distance { get; set; }
        public bool hasTunnel { get; set; }
        public bool hasHighway { get; set; }
        public int index { get; set; }
        public string formattedTime { get; set; }
        public int origIndex { get; set; }
        public bool hasSeasonalClosure { get; set; }
        public bool hasCountryCross { get; set; }
        public object[][] roadGradeStrategy { get; set; }
        public int destIndex { get; set; }
        public int time { get; set; }
        public bool hasUnpaved { get; set; }
        public string origNarrative { get; set; }
        public Maneuver[] maneuvers { get; set; }
        public bool hasFerry { get; set; }
    }
}