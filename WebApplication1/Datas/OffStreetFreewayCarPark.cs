using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class OffStreetFreewayCarPark
    {
        public string PkOffStreetFreewayCarPark { get; set; }
        public string FkBaseAuthority { get; set; }
        public int Version { get; set; }
        public string FkOffStreetCarPark { get; set; }
        public string ServiceAreaId { get; set; }
        public string ServiceAreaNameZhTw { get; set; }
        public string ServicAreaNameEnUs { get; set; }
    }
}
