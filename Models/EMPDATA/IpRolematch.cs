using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class IpRolematch
    {
        public int PrIden { get; set; }
        public string PeLogn { get; set; }
        public DateTime? RmPlst { get; set; }
        public DateTime? RmPlfi { get; set; }
        public short? RmLoad { get; set; }
        public int? RqIden { get; set; }
        public string RmRole { get; set; }
        public short? RmPrim { get; set; }
        public short? RmBill { get; set; }
        public string RmSkil { get; set; }
        public short? IpLocn { get; set; }
        public double? RmBilv { get; set; }
        public double? RmAltv { get; set; }
        public short? RmStat { get; set; }
        public string RmUsr1 { get; set; }
        public string RmUsr2 { get; set; }
        public short? RmCaid { get; set; }
        public int? RmLink { get; set; }
        public string RmAcby { get; set; }
        public DateTime? RmAcdt { get; set; }
        public int RmRoid { get; set; }
    }
}
