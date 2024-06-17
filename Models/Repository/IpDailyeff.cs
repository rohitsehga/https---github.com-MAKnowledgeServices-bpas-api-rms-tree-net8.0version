using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class IpDailyeff
    {
        public short PrIden { get; set; }
        public short AcIden { get; set; }
        public string PeLogn { get; set; }
        public DateTime DeDate { get; set; }
        public short? DeEffo { get; set; }
        public short? IpLocn { get; set; }
        public string AmbBillable { get; set; }
        public DateTime? EntryStamp { get; set; }
    }
}
