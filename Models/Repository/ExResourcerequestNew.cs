using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourcerequestNew
    {
        public decimal Id { get; set; }
        public long? ReqId { get; set; }
        public int? CuIden { get; set; }
        public int? ProjId { get; set; }
        public DateTime? RequestDate { get; set; }
        public DateTime? CompletionDate { get; set; }
        public int? RequestSl { get; set; }
        public string GroupCode { get; set; }
        public string ResourceType { get; set; }
        public string AssignmentType { get; set; }
        public decimal? ResourceCount { get; set; }
        public int? ActualCount { get; set; }
        public string ResourceDuration { get; set; }
        public string ResourceReason { get; set; }
        public DateTime? RequestClosingdate { get; set; }
        public string ResourceSkillset { get; set; }
        public string ResourceComments { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        /// <summary>
        /// P:Pending
        /// C:Closed
        /// </summary>
        public string Status { get; set; }
        public string Mngrcomments { get; set; }
        public string Mngrstatus { get; set; }
        public string ClientStratImp { get; set; }
        public string Clientanalystsectorname { get; set; }
        public string Amvp { get; set; }
        public int? IpLocn { get; set; }
        public string Supr { get; set; }
        public string Tdacomments { get; set; }
        public string ReplacementLogn { get; set; }
        public string Sow { get; set; }
    }
}
