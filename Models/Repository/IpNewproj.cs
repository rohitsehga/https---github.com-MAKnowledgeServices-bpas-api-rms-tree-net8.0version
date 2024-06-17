using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class IpNewproj
    {
        public string PeLogn { get; set; }
        public short PrIden { get; set; }
        public int? NpNote { get; set; }
        public short? NpDura { get; set; }
        public string NpResp { get; set; }
        public DateTime? NpStdt { get; set; }
        public DateTime? NpFidt { get; set; }
        public int? NpEffo { get; set; }
        public string NpBill { get; set; }
        public string NpTag1 { get; set; }
        public string NpTag2 { get; set; }
        public short? NpPosn { get; set; }
        public string NpReto { get; set; }
        public short? IpLocn { get; set; }
        public DateTime? NpSbdt { get; set; }
        public DateTime? NpApdt { get; set; }
        public DateTime? NpRjdt { get; set; }
        public string NpPrim { get; set; }
        public string NpRole { get; set; }
        public string NpStat { get; set; }
        public string NpCost { get; set; }
    }
}
