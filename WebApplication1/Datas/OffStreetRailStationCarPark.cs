using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class OffStreetRailStationCarPark
    {
        public string PkOffStreetRailStationCarPark { get; set; }
        public string FkBaseAuthority { get; set; }
        public int Version { get; set; }
        public string FkOffStreetCarPark { get; set; }
        public string StationId { get; set; }
        public string StationNameZhTw { get; set; }
        public string StationNameEnUs { get; set; }
    }
}
