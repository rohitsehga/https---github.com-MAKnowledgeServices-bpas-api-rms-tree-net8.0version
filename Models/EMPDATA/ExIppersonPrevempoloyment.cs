using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.EMPDATA
{
    public partial class ExIppersonPrevempoloyment
    {
        public string PeLogn { get; set; }
        public int Sl { get; set; }
        public string CompanyName { get; set; }
        public int? CityId { get; set; }
        public DateTime? EffectiveFromDate { get; set; }
        public DateTime? EffectiveToDate { get; set; }
        public string Userlognid { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Status { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? AprroveOn { get; set; }
        public string DesignationId { get; set; }
        public int? WorktypeId { get; set; }
    }
}
