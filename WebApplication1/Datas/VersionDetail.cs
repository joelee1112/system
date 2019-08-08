using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class VersionDetail
    {
        public string PkVersionDetail { get; set; }
        public string FkBaseAuthority { get; set; }
        public int Version { get; set; }
        public string SrcDataTypeName { get; set; }
        public DateTime SrcUpdateTime { get; set; }
        public int SrcUpdateInterval { get; set; }
    }
}
