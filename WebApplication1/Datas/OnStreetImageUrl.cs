using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class OnStreetImageUrl
    {
        public string PkOnStreetImageUrl { get; set; }
        public string FkBaseAuthority { get; set; }
        public int Version { get; set; }
        public string FkOnStreetParkingSegment { get; set; }
        public string ImageUrl { get; set; }
    }
}
