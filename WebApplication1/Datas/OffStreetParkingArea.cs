using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class OffStreetParkingArea
    {
        public string PkOffStreetParkingArea { get; set; }
        public string FkBaseAuthority { get; set; }
        public int Version { get; set; }
        public string FkOffStreetCarPark { get; set; }
        public string ParkingAreaId { get; set; }
        public string NameZhTw { get; set; }
        public string NameEnUs { get; set; }
        public string Geometry { get; set; }
    }
}
