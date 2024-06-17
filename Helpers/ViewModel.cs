using System;
using System.Collections.Generic;

namespace ResourceRequestService.Helpers
{
    public class ViewModel
    {
    }
    public class ClientModel
    {
        public int CU_IDEN { get; set; }
        public string? CU_COMP { get; set; }

        public short? ExCuHmth { get; set; }

        public string? CuCode { get; set; }//cucode and cu_comp are same
        public string? CuName { get; set; }

        public string[]? Clienttype { get; set; }

        public string? ServiceLine { get; set; }
        public string[]? Clientgeo { get; set; }

        //public string[]? Clientgroup { get; set; }

        public int[] MainService { get; set; }
        public bool Issowmandate { get; set; }

        public string? Role { get; set; }

        public string? PE_LOGN { get; set; }

        public string AcMgrPLOGN { get; set; }
        public string EmgrPLOGN { get; set; }

        public string? USERLOGNID { get; set; }

        public string StartDate { get; set; }

        public string Type { get; set; }

        public int[] Engagement { get; set; }


    }

    public class LOBHC
    {
        public string LOBHC1 { get; set; }
        public int count { get; set; } 

        public LOBHC(string LOBHC2, int count1)
        {
            LOBHC1 = LOBHC2;
            count = count1; 
        }

    }
    public class RoleListDM
    {
        public string Name { get; set; }
        public string Logn { get; set; }
        public string Desg { get; set; }
    }
    public class ResourceRequest
    {
        public int Cu_Iden { get; set; }
        public string Request_Date { get; set; }
        public string Completion_Date { get; set; }
        public string UserLognID { get; set; }

        public string AMVP { get; set; }
        public int IP_Locn { get; set; }
        public string Group_Code { get; set; }
        public string Resource_Reason { get; set; }

        public string Supr { get; set; }

        public int Proj_Id { get; set; }

        public string REPLACEMENT_LOGN { get; set; }
        public string SowNo { get; set; }
        public string Title { get; set; }
        public int NoOfResource { get; set; }

        public string Required_Date { get; set; }

        public string Priority { get; set; }
        public string Remarks { get; set; }
        public float Resource_Allocn { get; set; }

        public float BillPercent { get; set; }

        public string LognType { get; set; }
    }

    public class skillset
    {
        public long Req_ID { get; set; }
        public long MaxRoleSL { get; set; }
        public int SL { get; set; }
        public string CaCode { get; set; }
        public string ElCode { get; set; }
        public string Skill_Level { get; set; }

        public string UserLognID { get; set; }

        public DateTime ENTRYSTAMP { get; set; }

    }


    public class Connection
    {
        public string Employee { get; set; }
        public string Resource { get; set; }
        public string Amba { get; set; }
        public string Candidate { get; set; }
        public string Repository { get; set; }
    }



    public class StoredProcdure
    {
        public string ProviderName { get; set; }
        public string ProcedureName { get; set; }
        public Dictionary<string, dynamic> Params { get; set; }
    }

    public class ResourceOffboard
    {
        public string Logn { get; set; }
        public string CuIden { get; set; }
        public string Reason { get; set; }

        public string KickOffDate { get; set; }
        public string OffboardReason { get; set; }

        public string ReplacementReason { get; set; }
        public string ReplaceWith { get; set; }
        public string OffboardDate { get; set; }
        public string WhoUpdate { get; set; }

        public string CmplComments { get; set; }
        public string OffboardComments { get; set; }

        public string itFolderAccess { get; set; }

        public string itFOlderAccessComments { get; set; }

        public string itEmailAccess { get; set; }

        public string itEmailAccessComments { get; set; }

        public string adminAccessComments { get; set; }

    }
    public class Resource
    {
        public string Logn { get; set; }
        public string CuIden { get; set; }
        public string ClientType { get; set; }

        public string Group { get; set; }
        public string ProjID { get; set; }

        public string ReqID { get; set; }
        public string PeLogn { get; set; }
        public string DOS { get; set; }
        public string KickOff { get; set; }

        public string newstartdate { get; set; }



        public string AssignRole { get; set; }
        public string Allocation { get; set; }

        public string Reason { get; set; }

        public string Replacing { get; set; }

        public string BillStart { get; set; }

        public string BillPercentage { get; set; }

        public string ReportTo { get; set; }

        public string Supervisor { get; set; }

        public string Compliance { get; set; }

        public string OnboardComments { get; set; }
        public string IsFolderAccessRequired { get; set; }
        public string FolderAccessDetails { get; set; }

        public string IsEmailAccessRequired { get; set; }
        public string EmailAccessDetails { get; set; }
        public string ClientRoomDetails { get; set; }
        public string WorkStationDetails { get; set; }
        public string SOWno { get; set; }
        public string LognType { get; set; }
        public string UserLognID { get; set; }
        public string ChangeType { get; set; }

        public string RoleReasonGroup { get; set; }

        public string comments { get; set; }
        public string replaceWith { get; set; } 
        public int PersonType { get; set; }

    }

    public class BillPercenateUpdate
    {
        public string PeLogn { get; set; }
        public int CuIden { get; set; }
        public DateTime NewStart { get; set; }

        public decimal NewBillPercent { get; set; }
        public string UserLognID { get; set; } 
    }

    public class ComplianceOnbaordAction
    {
        public int ID { get; set; }
        public string ComplianceAction { get; set; }
        public string ComplianceComments { get; set; }
        public string ComplianceLoginID { get; set; }
        public int UsageClauseID { get; set; }
        public int BlackOut { get; set; }
        public DateTime NDASignedDate { get; set; } 
        public string SOWNo { get; set; }
    }

    public class FinanceOnbaordAction
    {
        public int ID { get; set; }
        public string FinanceAction { get; set; }
        public string FinanceComments { get; set; }
        public string FinanceLoginID { get; set; }
        public DateTime billstartdate { get; set; } 
        public string SOWNo { get; set; }
        public string BillEntity { get; set; }
    }

    public class AdminAction
    {
        public int ID { get; set; }
        public string Action { get; set; } 
        public string Comments { get; set; }
        public string LoginID { get; set; }  
    }
    public class FinanceOffBoardAction
    {
        public int ID { get; set; }
        public string FinanceAction { get; set; }
        public string FinanceComments { get; set; }
        public string FinanceLoginID { get; set; }
        public DateTime billenddate { get; set; } 
    }

    public class SaveRisk
    {
        public DateTime Riskdate { get; set; }

        public int cuiden { get; set; }

        public string pelogniden { get; set; }

        public int RCatID { get; set; }

        public int PID { get; set; }

        public int RiskSymptom { get; set; }

        public string ROC { get; set; }

        public DateTime IdentifiedDate { get; set; }

        public DateTime ClosingDate { get; set; }

        public string RiskDesc { get; set; }
        public string mngrcomments { get; set; }

        public string createdby { get; set; } 

        public MitigationPlans[] mitigationPlans { get; set; }
    }

    public class MitigationPlans
    {  
        public string mitidationplantext { get; set; }

        public string assignedto { get; set; }

        public DateTime closingdate { get; set; } 
    }

    public class SaveFeedbackSurvey
    {
        public string AssessmentName { get; set; }

        public int cuiden { get; set; }

        public string ProjectName { get; set; }

        public int AssessmentQBID { get; set; }

        public string AssessmentOwner { get; set; }

        public string AssessmentPurpose { get; set; }

        public string AssessmentType { get; set; }

        public DateTime AssessmentStartDate { get; set; }

        public DateTime AssessmentEndDate { get; set; }

        public string Assessmentcomments { get; set; }

        public string createdby { get; set; }

        public string AssessmentFrequency { get; set; } 

        public savecontributor[] contributor { get; set; }
    }

    public class savecontributor
    { 
        public string contributorname { get; set; }
        public string contributoremailid { get; set; }

        public string contributorcategory { get; set; }
    }

    public class SavetmpContributor
    {  
        public int cuiden { get; set; }

        public string personname { get; set; } 

        public string role { get; set; }

        public string mailid { get; set; }

        public string enteredby { get; set; }  
    }

    public class SaveUserResponse
    {
        public string usermailid { get; set; }

        public int assessmentid { get; set; }

        public int questionid { get; set; }

        public string ans1 { get; set; }
        public string ans2 { get; set; }
        public string ans3 { get; set; }
        public string ans4 { get; set; }
        public string ans5 { get; set; }
        public string ans6 { get; set; }
        //public string ans7 { get; set; }
        //public string ans8 { get; set; }
        //public string ans9 { get; set; }
        //public string ans10 { get; set; }
        //public string ans11 { get; set; }
        //public string ans12 { get; set; }    
        public string enteredby { get; set; }  
    }

    public class SubmitAssessment
    {
        public string usermailid { get; set; }

        public int assessmentid { get; set; } 
        public string enteredby { get; set; }
    }
    public class FinanceBillingConversionAction
    { 
        public string pelogn { get; set; }
        public string billentity { get; set; }
        public int cuiden { get; set; }
        public DateTime kickofdate { get; set; }
        public DateTime Startdate { get; set; }
        public string FinanceAction { get; set; }
        public string FinanceComments { get; set; }
        public string FinanceLoginID { get; set; }
        public string currentreason { get; set; }
        public string newreason { get; set; }
        public string group { get; set; }
        public string reppelogn { get; set; }
    }

    public class AllocationUpdate
    {
        public string PeLogn { get; set; }
        public int CuIden { get; set; }
        public DateTime NewStart { get; set; }

        public decimal NewAllocation { get; set; }
        public string UserLognID { get; set; }
    }

    public class GroupUpdate
    {
        public string PeLogn { get; set; }
        public int CuIden { get; set; }
        public DateTime NewStartDate { get; set; } 
        public string Group { get; set; }
        public string UserLognID { get; set; }
    }

    public class RoleUpdate
    {
        public string PeLogn { get; set; }
        public int CuIden { get; set; }
        public DateTime NewStartDate { get; set; } 
        public string Role { get; set; }
        public string UserLognID { get; set; }
    }

    public class ReasonUpdate
    {
        public string PeLogn { get; set; }
        public int CuIden { get; set; }
        public DateTime NewStartDate { get; set; } 
        public string Reason { get; set; }
        public string UserLognID { get; set; } 

        public decimal BillPercentage { get; set; }
        public string ReplaceWith { get; set; }
    }


    public class Groups
    {
        public string Group { get; set; }
    }
    public class PersonGroup
    {
        public string Group { get; set; }
    }

    public class ResourceRoleBack
    {
        public string Logn { get; set; }
        public string CuIden { get; set; }
        public string ClientType { get; set; }

        public string Group { get; set; }
        public string ProjID { get; set; }

        public string ReqID { get; set; }
        public string PeLogn { get; set; }
        public string DOS { get; set; }
        public string KickOff { get; set; }

        public string newstartdate { get; set; } 
        public string AssignRole { get; set; }
        public string Allocation { get; set; }

        public string Reason { get; set; }

        public string Replacing { get; set; }

        public string BillStart { get; set; }

        public string BillPercentage { get; set; }

        public string ReportTo { get; set; }

        public string Supervisor { get; set; }

        public string Compliance { get; set; }

        public string OnboardComments { get; set; }
        public string IsFolderAccessRequired { get; set; }
        public string FolderAccessDetails { get; set; }

        public string IsEmailAccessRequired { get; set; }
        public string EmailAccessDetails { get; set; }
        public string ClientRoomDetails { get; set; }
        public string WorkStationDetails { get; set; }
        public string SOWno { get; set; }
        public string LognType { get; set; }
        public string UserLognID { get; set; }
        public string ChangeType { get; set; } 
        public string RoleReasonGroup { get; set; }

        public string comments { get; set; }
        public string replaceWith { get; set; }

        public int Tranid { get; set; }

        public string ActionTaken { get; set; }

    }


    public class ResourceOffboardRollBack
    {
        public string Logn { get; set; }
        public string CuIden { get; set; }
        public string Reason { get; set; }

        public string KickOffDate { get; set; }
        public string OffboardReason { get; set; }

        public string ReplacementReason { get; set; }
        public string ReplaceWith { get; set; }
        public DateTime OffboardDate { get; set; }
        public string WhoUpdate { get; set; }

        public string CmplComments { get; set; }
        public string OffboardComments { get; set; }

        public string itFolderAccess { get; set; }

        public string itFOlderAccessComments { get; set; }

        public string itEmailAccess { get; set; }

        public string itEmailAccessComments { get; set; }

        public string adminAccessComments { get; set; }

        public int Tranid { get; set; }

        public string ActionTaken { get; set; }

    }

    public class SaveHelpdeskTicket
    {
        public int ProjID { get; set; }
        public int ReqTypeID { get; set; }
        public int PriorityID { get; set; }

        public string TranDesc { get; set; }
        public string TranComments { get; set; }

        public string TranAttachFileName { get; set; }
        public string TranRequestor { get; set; } 

    }

    public class UpdateHelpdeskTicket
    {
        public int TranID { get; set; }  
        public int TranRequestStatus { get; set; }  
        public string TranActionBy { get; set; }
        public string EngineerComments { get; set; }

    }

    public class SaveProjectLogs
    {
        public int ProjectID { get; set; }
        public string UserPelogn { get; set; }  

    }
    public class KickOffStatus
    {
        public string nstatus { get; set; }
        public string kickoffdate { get; set; }
    }
    public class ResultTemp
    {
        public int ID { get; set; }
        public string Status { get; set; }
    }

    public class OnlineOffline
    {
        public int CU_IDEN { get; set; }

        public string? PE_LOGN { get; set; }

        public string Req_Id { get; set; } 

    }

    public class SaveUnbilledReason
    { 
        public string PELOGN { get; set; }

        public int SUBREASON { get; set; }
        public DateTime STARTDATE { get; set; }
        public string NOFUNDERDELLEAD { get; set; }

        public string CLIENTNAMEREASON { get; set; }
        public string DATEOFALLOCRESERV { get; set; }

        public string EXPBILLSTARTDT { get; set; }
        public string ISDEALSIGNED { get; set; }

        public string SkillSet { get; set; }
        public string USERLOGNID { get; set; }

    }

    public class SaveIndustriclassificationMaster
    {
        public string industryclassification { get; set; }  
        public string USERLOGNID { get; set; }

    }

    public class SaveclienttypeMaster
    {
        public string clienttype { get; set; }
        public string USERLOGNID { get; set; }

    }

    public class SavetypeofservicesMaster
    {
        public string typeofservices { get; set; }
        public string USERLOGNID { get; set; }

    }

    public class SaveLocationMaster
    {
        public string location { get; set; }
        public string USERLOGNID { get; set; }

    }

    public class SaveRequestRequestConfiguration
    {
        public string status { get; set; }
        public string USERLOGNID { get; set; }

    }

    public class UpdateRequestStatus
    {
        public int reqid { get; set; }
        public string status { get; set; }
        public string USERLOGNID { get; set; }

    }
    public class StatusModel
    {
        public int Sl { get; set; }
        public string Status { get; set; }
        public string OnboardStatus { get; set; }

        public string Reason { get; set; }
        public int Flag { get; set; }
    }

    public class ProjectDetail
    {
        public string Category { get; set; }
        public decimal? TotalEffort { get; set; } 

        public ProjectDetail(string Category1, decimal? TotalEffort1)
        {
            Category = Category1;
            TotalEffort = TotalEffort1; 
        }

    }

    public class GetRole
    {
        public string Category { get; set; }
        public string Role { get; set; }

        public GetRole(string Category1, string Role1)
        {
            Category = Category1;
            Role = Role1;
        }

    }
    public class webHoookModel
    {
        public string message { get; set; }
        public bool status { get; set; }
    }
    public class emailSendModelnew
    { 
        public string from { get; set; }
        public List<string> to { get; set; }
        public List<string> cc { get; set; }
        public List<string> bcc { get; set; }
        public string subject { get; set; }
        public string body { get; set; }
        public bool isHTML { get; set; }
    }

    public class emailSendModel
    {
        public string url { get; set; }
        public string from { get; set; }
        public List<string> to { get; set; } 
        public List<string> cc { get; set; } 
        public List<string> bcc { get; set; } 
        public string subject { get; set; } 
        public string body { get; set; } 
        public bool isHTML { get; set; }
    }

    public class InsertClientContact
    {
        public int cuiden { get; set; }
        public string Name { get; set; }
        public string emailid { get; set; } 
        public string phoneno { get; set; }
        public string role { get; set; }
        public string enteredby { get; set; }
    }

    public class UpdateClientContact
    {
        public int ID { get; set; } 
        public string Name { get; set; }
        public string emailid { get; set; }
        public string phoneno { get; set; }
        public string role { get; set; }
        public string updatedby { get; set; }
    }

    public class RoleProfiles
    {
        public string RoleType { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public bool View { get; set; }
        public bool New { get; set; }
        public bool Approve { get; set; }
        public bool Update { get; set; }
        public bool Delete { get; set; }
    }

    public class eventsProfile
    {
        public bool IsPresent { get; set; }
        public int screenId { get; set; }
        public int eventId { get; set; }

        public string screenName { get; set; }

        public string eventName { get; set; }
    }

    public class UserProfile
    {
        public bool isInitialSignoffDone { get; set; }
        public bool isWelcomeFirst { get; set; }
        public string label { get; set; }

        public string value { get; set; }
        public string AvatarData { get; set; }
        public string Id { get; set; }
        public string UserCode { get; set; }
        public string Username { get; set; }
        public int RoleId { get; set; }
        public string RoleName { get; set; }
        public string Location { get; set; }
        public string Email { get; set; }
        public string Windows { get; set; }
        public string Designation { get; set; }
        public string Department { get; set; }
        public RoleProfiles Rights { get; set; }

        public bool isWelcome { get; set; }
        public string[] Screens { get; set; }
        public int[] Sections { get; set; }
        public int[] Clients { get; set; }

        // public int[] EventIds { get; set; }
        public bool IsSidebar { get; set; }
        public List<eventsProfile> events { get; set; }

        public string joiningDate { get; set; }
        public string employeeNo { get; set; }

        public string mangerId { get; set; }

        public string managerName { get; set; }

        public int locationId { get; set; }

        public string deparatmentcode { get; set; }

        public string personrole { get; set; }
    }

    public class Session
    {
        public string Text { get; set; }
    }

    public class UserData
    {
        public string Name { get; set; }
        public string AuthenticationType { get; set; }
        public bool IsAuthenticated { get; set; }
        public DateTimeOffset Expiry { get; set; }
    }

    public class PersonTypeUpdate
    { 
        public List<ObjectList> objectList { get; set; }
    }

    public class ObjectList
    { 
        public string pelogn { get; set; }
        public int persontype { get; set; } 
    }

}
