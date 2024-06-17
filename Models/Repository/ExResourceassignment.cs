using System;
using System.Collections.Generic;

namespace ResourceRequestService.Models.Repository
{
    public partial class ExResourceassignment
    {
        public int Id { get; set; }
        public int? Sl { get; set; }
        public string PeLmgr { get; set; }
        public string PeLogn { get; set; }
        public string RepValognid { get; set; }
        public int? CuIden { get; set; }
        public int? ProjId { get; set; }
        public string CuType { get; set; }
        public string IpLocn { get; set; }
        public string Groups { get; set; }
        public string WorkType { get; set; }
        public string AssignType { get; set; }
        public string Reason { get; set; }
        public string ReasonDetail { get; set; }
        public string Jobrefno { get; set; }
        public int? ReqId { get; set; }
        public string ResgclntComment { get; set; }
        public string ItComment { get; set; }
        public string AdminComment { get; set; }
        public DateTime? DateOfSelectionOrMove { get; set; }
        public DateTime? KickOffDate { get; set; }
        public DateTime? BillDate { get; set; }
        public string BillingStatus { get; set; }
        public string BillingDetails { get; set; }
        public string ComplComment { get; set; }
        public string HrRdAccFinComment { get; set; }
        public int? OnOff { get; set; }
        public DateTime? Entrystamp { get; set; }
        public string Userlognid { get; set; }
        public string Status { get; set; }
        /// <summary>
        /// To Save the Approve Status P=Pending,A=Approved,R=Rejected
        /// </summary>
        public string ApproveStatus { get; set; }
        public int? BcatId { get; set; }
        public decimal? BillingRate { get; set; }
        public string Userapprovestatus { get; set; }
        public string FinanceStatus { get; set; }
        public string FinanceComments { get; set; }
        public DateTime? FinanceEntrystamp { get; set; }
        public string FinanceLognid { get; set; }
        public string ManagerComments { get; set; }
        public DateTime? ManagerEntrystamp { get; set; }
        public string ManagerLognid { get; set; }
        public string ComplianceComments { get; set; }
        public string ComplianceStatus { get; set; }
        public DateTime? ComplianceEntrystamp { get; set; }
        public string ComplianceLognid { get; set; }
        public string ItCommentsOnapprove { get; set; }
        public string ItStatusOnapprove { get; set; }
        public DateTime? ItStatusEntrystamp { get; set; }
        public string ItStatusLognid { get; set; }
        public string AdminCommentsOnapprove { get; set; }
        public string AdminStatusOnapprove { get; set; }
        public DateTime? AdminStatusEntrystamp { get; set; }
        public string AdminStatusLognid { get; set; }
        public string Supr { get; set; }
        public DateTime? Ndasigneddate { get; set; }
        public string Documentation { get; set; }
        public string ManagerUpdate { get; set; }
        public string OrgnRole { get; set; }
        public string TdaComments { get; set; }
        public string CheadTypeoflead { get; set; }
        public string ServiceLed { get; set; }
        public string DeliveryLed { get; set; }
        public string CheadUpdatedbychead { get; set; }
        public DateTime? CheadEntrystamp { get; set; }
        public string InvoiceNo { get; set; }
        public string BillingRole { get; set; }
        public decimal? Allocation { get; set; }
        public string ConversionUserlognid { get; set; }
        public DateTime? ConversionEntrystamp { get; set; }
        public string ConversionComment { get; set; }
        public decimal? ProjDuration { get; set; }
        public string ProjFrequency { get; set; }
        public string BillFrequency { get; set; }
        public string ConversionComplStatus { get; set; }
        public string ConversionComplComments { get; set; }
        public string ConversionComplLognid { get; set; }
        public DateTime? ConversionComplEntrystamp { get; set; }
        public string NewDmSupr { get; set; }
        public string NewDmSuprConfirm { get; set; }
        public string Ndaconfirm { get; set; }
        public string OffboardConfirm { get; set; }
        public string OffboardConfirmedby { get; set; }
        public string OffboardComfirmcomments { get; set; }
        public DateTime? OffboardConfirmedon { get; set; }
        public string OffboardComfirmcommentsIt { get; set; }
        public string OffboardComfirmcommentsAdmn { get; set; }
        public decimal? Billpercent { get; set; }
        public string ConversionCheadApprovalStatus { get; set; }
        public DateTime? ConversionCheadEntrystamp { get; set; }
        public string ConversionCheadLoginid { get; set; }
        public string ConversionCheadComment { get; set; }
        public string BillEntity { get; set; }
        public string Sow { get; set; }
        public int? Usageclauseid { get; set; }
        public int? Blackout { get; set; }
        public string OnboardComments { get; set; }
        public int? LockId { get; set; }
        public DateTime? LockPeriod { get; set; }
        public string LockedBy { get; set; }
        public DateTime? LockedOn { get; set; }
        public string LockStatus { get; set; }
        public DateTime? DmKickOffDate { get; set; }
    }
}
