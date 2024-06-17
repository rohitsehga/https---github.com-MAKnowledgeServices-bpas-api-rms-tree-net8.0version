using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIppersonCompensationLog
    {
        public string CompType { get; set; }
        public string PeLogn { get; set; }
        public string CompCategory { get; set; }
        public byte[] OldValue { get; set; }
        public byte[] NewValue { get; set; }
        public string Modifiedby { get; set; }
        public DateTime? Modifiedon { get; set; }
    }
}
