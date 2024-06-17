using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourcerequestRole
    {
        public int? ReqId { get; set; }
        public long? Rolesl { get; set; }
        public string Title { get; set; }
        public int? Noofresource { get; set; }
        public DateTime? RequiredDate { get; set; }
        public string Priority { get; set; }
        public string Remarks { get; set; }
        public string Userlognid { get; set; }
        public DateTime? Entrystamp { get; set; }
        public int? IpLocn { get; set; }
        public decimal? ResourceAllocn { get; set; }
        public decimal? OtherAllocn { get; set; }
        public decimal? Billpercent { get; set; }
        public decimal Id { get; set; }
    }
}
