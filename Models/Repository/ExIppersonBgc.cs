using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIppersonBgc
    {
        public string PeLogn { get; set; }
        public DateTime? BgvIniDt { get; set; }
        public string BgvStatus { get; set; }
        public string BgvComments { get; set; }
        public DateTime? IdbcompletionDate { get; set; }
        public DateTime? IdentityCheckCompletionDate { get; set; }
        public DateTime? BgvclosureDate { get; set; }
        public int? BgvVendorId { get; set; }
        public DateTime? DrugTestCompletionDate { get; set; }
        public string Status { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStamp { get; set; }
        public string EndUserLognId { get; set; }
        public DateTime? EndEntrystamp { get; set; }
    }
}
