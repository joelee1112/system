using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class BaseAuthority
    {
        public string PkBaseAuthority { get; set; }
        public string AuthorityCode { get; set; }
        public string NameZhTw { get; set; }
        public string NameEnUs { get; set; }
        public string Oid { get; set; }
        public string Phone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string WeUrl { get; set; }
        public string LogoUrl { get; set; }
        public DateTime UpdateTime { get; set; }
    }
}
