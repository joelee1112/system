using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class OffStreetActivityCarPark
    {
        public string PkOffStreetActivityCarPark { get; set; }
        public string FkBaseAuthority { get; set; }
        public int Version { get; set; }
        public string FkOffStreetCarPark { get; set; }
        public string ActivityId { get; set; }
        public string ActivityNameZhTw { get; set; }
        public string ActivityNameEnUs { get; set; }
    }
}
