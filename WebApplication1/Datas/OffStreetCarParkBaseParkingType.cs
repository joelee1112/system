using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class OffStreetCarParkBaseParkingType
    {
        public string PkOffStreetCarParkBaseParkingType { get; set; }
        public string FkBaseAuthority { get; set; }
        public int Version { get; set; }
        public string FkOffStreetCarPark { get; set; }
        public string FkBaseParkingType { get; set; }
    }
}
