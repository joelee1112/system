using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class OffStreetAirportCarPark
    {
        public string PkOffStreetAirportCarPark { get; set; }
        public string FkBaseAuthority { get; set; }
        public int Version { get; set; }
        public string FkOffStreetCarPark { get; set; }
        public string AirportId { get; set; }
        public string AirportNameZhTw { get; set; }
        public string AirportNameEnUs { get; set; }
        public string Terminal { get; set; }
    }
}
