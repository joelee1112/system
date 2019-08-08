using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class OffStreetParkingEntranceExit
    {
        public string PkOffStreetParkingEntranceExit { get; set; }
        public short EntranceExitType { get; set; }
        public string FkBaseAuthority { get; set; }
        public int Version { get; set; }
        public string FkOffStreetCarPark { get; set; }
        public string FkBaseEntranceType { get; set; }
        public string NameZhTw { get; set; }
        public string NameEnUs { get; set; }
        public float Longitude { get; set; }
        public float Latitude { get; set; }
        public double MaxAllowedWidth { get; set; }
        public double MaxAllowedHeight { get; set; }
        public double? MaxAllowedWeight { get; set; }
        public string RoadId { get; set; }
        public string RoadName { get; set; }
        public string CrossRoadName { get; set; }
        public string LinkId { get; set; }
        public string Bearing { get; set; }
    }
}
