using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class OffStreetCarParkBaseParkingSiteType
    {
        public string PkOffStreetCarParkBaseParkingSiteType { get; set; }
        public string FkBaseAuthority { get; set; }
        public int Version { get; set; }
        public string FkOffStreetCarPark { get; set; }
        public string FkBaseParkingSiteType { get; set; }
    }
}
