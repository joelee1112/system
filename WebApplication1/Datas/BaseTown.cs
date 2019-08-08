using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class BaseTown
    {
        public string PkBaseTown { get; set; }
        public string FkBaseCity { get; set; }
        public string TownId { get; set; }
        public string NameZhTw { get; set; }
        public string NameEnUs { get; set; }
    }
}
