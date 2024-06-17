using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIppersonWorkPermitDetail
    {
        public int? Sl { get; set; }
        public string PeLogn { get; set; }
        public int? CountryId { get; set; }
        public string DocumentType { get; set; }
        public string DocTitle { get; set; }
        public DateTime? IssueDate { get; set; }
        public string IssuingPlace { get; set; }
        public string IssuingAuthority { get; set; }
        public int? SponsorShipType { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public int? Status { get; set; }
        public string UserLognId { get; set; }
        public DateTime? EntryStmap { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime? LastUpdatedOn { get; set; }
    }
}
