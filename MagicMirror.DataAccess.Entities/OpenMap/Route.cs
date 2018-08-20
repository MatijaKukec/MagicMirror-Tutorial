namespace MagicMirror.DataAccess.Entities.OpenMap
{
    public class Route
    {
        public bool hasTollRoad { get; set; }
        public bool hasBridge { get; set; }
        public Boundingbox boundingBox { get; set; }
        public float distance { get; set; }
        public bool hasTunnel { get; set; }
        public bool hasHighway { get; set; }
        public object[] computedWaypoints { get; set; }
        public Routeerror routeError { get; set; }
        public string formattedTime { get; set; }
        public string sessionId { get; set; }
        public int realTime { get; set; }
        public bool hasSeasonalClosure { get; set; }
        public bool hasCountryCross { get; set; }
        public float fuelUsed { get; set; }
        public Leg[] legs { get; set; }
        public Options options { get; set; }
        public Location[] locations { get; set; }
        public int time { get; set; }
        public bool hasUnpaved { get; set; }
        public int[] locationSequence { get; set; }
        public bool hasFerry { get; set; }
    }
}