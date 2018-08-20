namespace MagicMirror.DataAccess.Entities.OpenMap
{
    public class Location
    {
        public bool dragPoint { get; set; }
        public Displaylatlng displayLatLng { get; set; }
        public string adminArea4 { get; set; }
        public string adminArea5 { get; set; }
        public string postalCode { get; set; }
        public string adminArea1 { get; set; }
        public string adminArea3 { get; set; }
        public string type { get; set; }
        public string sideOfStreet { get; set; }
        public string geocodeQualityCode { get; set; }
        public string adminArea4Type { get; set; }
        public int linkId { get; set; }
        public string street { get; set; }
        public string adminArea5Type { get; set; }
        public string geocodeQuality { get; set; }
        public string adminArea1Type { get; set; }
        public string adminArea3Type { get; set; }
        public Latlng latLng { get; set; }
    }
}