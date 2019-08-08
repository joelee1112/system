using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class OffStreetImageUrl
    {
        public string PkOffStreetImageUrl { get; set; }
        public string FkBaseAuthority { get; set; }
        public int Version { get; set; }
        public string FkOffStreetCarPark { get; set; }
        public string ImageUrl { get; set; }
    }
}
