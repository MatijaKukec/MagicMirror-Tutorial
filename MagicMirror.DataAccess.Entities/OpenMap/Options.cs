namespace MagicMirror.DataAccess.Entities.OpenMap
{
    public class Options
    {
        public object[] arteryWeights { get; set; }
        public int cyclingRoadFactor { get; set; }
        public int timeType { get; set; }
        public bool useTraffic { get; set; }
        public bool returnLinkDirections { get; set; }
        public bool countryBoundaryDisplay { get; set; }
        public bool enhancedNarrative { get; set; }
        public string locale { get; set; }
        public object[] tryAvoidLinkIds { get; set; }
        public int drivingStyle { get; set; }
        public bool doReverseGeocode { get; set; }
        public int generalize { get; set; }
        public object[] mustAvoidLinkIds { get; set; }
        public bool sideOfStreetDisplay { get; set; }
        public string routeType { get; set; }
        public bool avoidTimedConditions { get; set; }
        public int routeNumber { get; set; }
        public string shapeFormat { get; set; }
        public int maxWalkingDistance { get; set; }
        public bool destinationManeuverDisplay { get; set; }
        public int transferPenalty { get; set; }
        public string narrativeType { get; set; }
        public int walkingSpeed { get; set; }
        public int urbanAvoidFactor { get; set; }
        public bool stateBoundaryDisplay { get; set; }
        public string unit { get; set; }
        public int highwayEfficiency { get; set; }
        public int maxLinkId { get; set; }
        public int maneuverPenalty { get; set; }
        public object[] avoidTripIds { get; set; }
        public int filterZoneFactor { get; set; }
        public string manmaps { get; set; }
    }
}
