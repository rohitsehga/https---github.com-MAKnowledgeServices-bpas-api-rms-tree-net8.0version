using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class IpPersonAsOn24Nov2021
    {
        public string PeLogn { get; set; }
        public short? PeIden { get; set; }
        public string PeEmid { get; set; }
        public string PeName { get; set; }
        public byte[] PeLopw { get; set; }
        public string PeDept { get; set; }
        public string PeDesg { get; set; }
        public DateTime? PeJoin { get; set; }
        public DateTime? PeQuit { get; set; }
        public DateTime? PeCrdt { get; set; }
        public DateTime? PeModt { get; set; }
        public string PeCrby { get; set; }
        public string PeMoby { get; set; }
        public byte[] PePswd { get; set; }
        public string PePtyp { get; set; }
        public string PeMail { get; set; }
        public int? PeMctc { get; set; }
        public short? CuIden { get; set; }
        public string PeLocn { get; set; }
        public string PeArch { get; set; }
        public string PeProx { get; set; }
        public string PeLmgr { get; set; }
    }
}
