using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpcustomerSopDoc
    {
        public string ClientCode { get; set; }
        public string ClientGroup { get; set; }
        public int Sl { get; set; }
        public string DocumentName { get; set; }
        public string Uploadedby { get; set; }
        public DateTime UploadedEntryStamp { get; set; }
        public string Status { get; set; }
        public string DocumentTitle { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedEntryStamp { get; set; }
        public string ApprovedStatus { get; set; }
        public string Comments { get; set; }
        public string Keywords { get; set; }
        public string Type { get; set; }
        public string Dm { get; set; }
        public string PeLogn { get; set; }
        public int? Team { get; set; }
    }
}
