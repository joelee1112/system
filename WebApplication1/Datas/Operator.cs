using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class Operator
    {
        public string PkOperator { get; set; }
        public string FkBaseAuthority { get; set; }
        public int Version { get; set; }
        public string OperatorId { get; set; }
        public string NameZhTw { get; set; }
        public string NameEnUs { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string WebUrl { get; set; }
        public string LogoUrl { get; set; }
        public string TsAndCsUrl { get; set; }
        public string Ban { get; set; }
    }
}
