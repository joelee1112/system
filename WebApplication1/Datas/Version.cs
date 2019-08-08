using System;
using System.Collections.Generic;

namespace WebApplication1.Datas
{
    public partial class Version
    {
        public string PkVersion { get; set; }
        public string FkBaseAuthority { get; set; }
        public int Version1 { get; set; }
        public short IsFinish { get; set; }
        public DateTime VersionTime { get; set; }
        public DateTime LatestCheckTime { get; set; }
        public string SourceDataHash { get; set; }
        public int? ReleasedVersion { get; set; }
    }
}
