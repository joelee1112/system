using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class OffStreetScenicSpotCarPark
    {
        public string PkOffStreetScenicSpotCarPark { get; set; }
        public string FkBaseAuthority { get; set; }
        public int Version { get; set; }
        public string FkOffStreetCarPark { get; set; }
        public string ScenicSpotId { get; set; }
        public string ScenicSpotNameZhTw { get; set; }
        public string ScenicSpotNameEnUs { get; set; }
    }
}
