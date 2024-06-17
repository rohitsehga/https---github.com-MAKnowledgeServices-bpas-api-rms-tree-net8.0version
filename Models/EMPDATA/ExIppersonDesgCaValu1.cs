using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIppersonDesgCaValu1
    {
        public string PeLogn { get; set; }
        public string PeDesg { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string Status { get; set; }
        public string CaCode { get; set; }
        public string CaValu { get; set; }
        public string CaName { get; set; }
        public short? CaOrdr { get; set; }
        public string CaArch { get; set; }
    }
}
