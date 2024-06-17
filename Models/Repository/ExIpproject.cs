using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExIpproject
    {
        public int? PrIden { get; set; }
        public string ProjectName { get; set; }
        public string Description { get; set; }
        public string BusinessJustification { get; set; }
        public string ProblemStatement { get; set; }
        public string Department { get; set; }
        public string Priority { get; set; }
        public string Pmopriority { get; set; }
        public string ProjectScope { get; set; }
        public string ProjectSponsor { get; set; }
        public string ProjectManager { get; set; }
        public DateTime? PlanStartDate { get; set; }
        public DateTime? PlanFinishDate { get; set; }
        public DateTime? PmoplanStartDate { get; set; }
        public DateTime? PmoplanFinishDate { get; set; }
        public string IsBudgeted { get; set; }
        public string ResourceCost { get; set; }
        public string SuccessCriteria { get; set; }
        public int? CategoryId { get; set; }
        public int? ThemeId { get; set; }
        public string Capex { get; set; }
        public string Opex { get; set; }
        public int? PartnerId { get; set; }
        public string ApprovalStatus { get; set; }
        public string ApprovalComments { get; set; }
        public string ApprovedBy { get; set; }
        public DateTime? ApprovedOn { get; set; }
        public string Status { get; set; }
        public string Createdby { get; set; }
        public DateTime? Createdon { get; set; }
        public string Updatedby { get; set; }
        public DateTime? Updatedon { get; set; }
        public int? CuIden { get; set; }
    }
}
