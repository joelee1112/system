using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class OffStreetParkingAreaBaseParkingType
    {
        public string PkOffStreetParkingAreaBaseParkingType { get; set; }
        public string FkBaseAuthority { get; set; }
        public int Version { get; set; }
        public string FkOffStreetParkingArea { get; set; }
        public string FkBaseParkingType { get; set; }
    }
}
