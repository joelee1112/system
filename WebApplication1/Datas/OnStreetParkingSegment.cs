using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class OnStreetParkingSegment
    {
        public string PkOnStreetParkingSegment { get; set; }
        public string FkBaseAuthority { get; set; }
        public int Version { get; set; }
        public string FkBaseCity { get; set; }
        public string FkBaseTown { get; set; }
        public string ParkingSegmentId { get; set; }
        public string NameZhTw { get; set; }
        public string NameEnUs { get; set; }
        public string StartRoadSection { get; set; }
        public string EndRoadSection { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public string Geometry { get; set; }
        public string Description { get; set; }
        public string FareDescription { get; set; }
        public string SpecialOfferDescription { get; set; }
        public string LandMark { get; set; }
    }
}
