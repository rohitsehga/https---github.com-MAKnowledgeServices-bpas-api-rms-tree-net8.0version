using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ResourceRequestService.Models.Repository;

namespace ResourceRequestService.Data
{
    public partial class RepositoryDbContext : DbContext
    {
        public RepositoryDbContext()
        {
        }

        public RepositoryDbContext(DbContextOptions<RepositoryDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AmbTtphasemap> AmbTtphasemaps { get; set; }
        public virtual DbSet<AmbaJobRefNo> AmbaJobRefNos { get; set; }
        public virtual DbSet<BillEntityMaster> BillEntityMasters { get; set; }
        public virtual DbSet<ClientWorkordersWithAnalyst> ClientWorkordersWithAnalysts { get; set; }
        public virtual DbSet<ClientreportConfig> ClientreportConfigs { get; set; }
        public virtual DbSet<Cupload> Cuploads { get; set; }
        public virtual DbSet<ExAccessMaster> ExAccessMasters { get; set; }
        public virtual DbSet<ExAccessMasterByIpcustomer> ExAccessMasterByIpcustomers { get; set; }
        public virtual DbSet<ExBillcategorymaster> ExBillcategorymasters { get; set; }
        public virtual DbSet<ExChecklistMaster> ExChecklistMasters { get; set; }
        public virtual DbSet<ExClientCallFeedback> ExClientCallFeedbacks { get; set; }
        public virtual DbSet<ExClientCallPostPone> ExClientCallPostPones { get; set; }
        public virtual DbSet<ExClientClause> ExClientClauses { get; set; }
        public virtual DbSet<ExClientClauseDepartment> ExClientClauseDepartments { get; set; }
        public virtual DbSet<ExClientClauseMasterCommunicateto> ExClientClauseMasterCommunicatetos { get; set; }
        public virtual DbSet<ExClientClausePublish> ExClientClausePublishes { get; set; }
        public virtual DbSet<ExClientClauseType> ExClientClauseTypes { get; set; }
        public virtual DbSet<ExClientClauseTypeDeptMap> ExClientClauseTypeDeptMaps { get; set; }
        public virtual DbSet<ExClientClauseTypeMaster> ExClientClauseTypeMasters { get; set; }
        public virtual DbSet<ExClientConfiguration> ExClientConfigurations { get; set; }
        public virtual DbSet<ExClientIndustoryClassification> ExClientIndustoryClassifications { get; set; }
        public virtual DbSet<ExClientPlOwner> ExClientPlOwners { get; set; }
        public virtual DbSet<ExClientProjectIsEnable> ExClientProjectIsEnables { get; set; }
        public virtual DbSet<ExClientServiceline> ExClientServicelines { get; set; }
        public virtual DbSet<ExClientServicelineNew> ExClientServicelineNews { get; set; }
        public virtual DbSet<ExClientWorkDemand> ExClientWorkDemands { get; set; }
        public virtual DbSet<ExClientcontact> ExClientcontacts { get; set; }
        public virtual DbSet<ExClientcontract> ExClientcontracts { get; set; }
        public virtual DbSet<ExClientcontractBlackoutperiod> ExClientcontractBlackoutperiods { get; set; }
        public virtual DbSet<ExClientsow> ExClientsows { get; set; }
        public virtual DbSet<ExClientsowBlackoutperiod> ExClientsowBlackoutperiods { get; set; }
        public virtual DbSet<ExCompanyMaster> ExCompanyMasters { get; set; }
        public virtual DbSet<ExContractMaster> ExContractMasters { get; set; }
        public virtual DbSet<ExCsatHelpdesk> ExCsatHelpdesks { get; set; }
        public virtual DbSet<ExCsatHelpdeskLink> ExCsatHelpdeskLinks { get; set; }
        public virtual DbSet<ExCsatHelpdeskMaster> ExCsatHelpdeskMasters { get; set; }
        public virtual DbSet<ExCsatHelpdeskTask> ExCsatHelpdeskTasks { get; set; }
        public virtual DbSet<ExCuIdenSowIsmandate> ExCuIdenSowIsmandates { get; set; }
        public virtual DbSet<ExDataCutOffDate> ExDataCutOffDates { get; set; }
        public virtual DbSet<ExDetailedDataLog> ExDetailedDataLogs { get; set; }
        public virtual DbSet<ExEmailTemplate> ExEmailTemplates { get; set; }
        public virtual DbSet<ExEmailVariable> ExEmailVariables { get; set; }
        public virtual DbSet<ExEmailnotification> ExEmailnotifications { get; set; }
        public virtual DbSet<ExEngagementType> ExEngagementTypes { get; set; }
        public virtual DbSet<ExEscalationMatrix> ExEscalationMatrices { get; set; }
        public virtual DbSet<ExEventMaster> ExEventMasters { get; set; }
        public virtual DbSet<ExExceptionRole> ExExceptionRoles { get; set; }
        public virtual DbSet<ExGeneralParameterConfiguration> ExGeneralParameterConfigurations { get; set; }
        public virtual DbSet<ExGroupMainservice> ExGroupMainservices { get; set; }
        public virtual DbSet<ExGroupSubservice> ExGroupSubservices { get; set; }
        public virtual DbSet<ExHraccessEntitywise> ExHraccessEntitywises { get; set; }
        public virtual DbSet<ExHrmodulemaster> ExHrmodulemasters { get; set; }
        public virtual DbSet<ExIndustoryClassificationMaster> ExIndustoryClassificationMasters { get; set; }
        public virtual DbSet<ExInfrastructure> ExInfrastructures { get; set; }
        public virtual DbSet<ExIpclientGroup> ExIpclientGroups { get; set; }
        public virtual DbSet<ExIpclientGroupMaster> ExIpclientGroupMasters { get; set; }
        public virtual DbSet<ExIpcustomer> ExIpcustomers { get; set; }
        public virtual DbSet<ExIpcustomerActype> ExIpcustomerActypes { get; set; }
        public virtual DbSet<ExIpcustomerBgc> ExIpcustomerBgcs { get; set; }
        public virtual DbSet<ExIpcustomerBilling> ExIpcustomerBillings { get; set; }
        public virtual DbSet<ExIpcustomerBusinessProcessMaster> ExIpcustomerBusinessProcessMasters { get; set; }
        public virtual DbSet<ExIpcustomerCancellation> ExIpcustomerCancellations { get; set; }
        public virtual DbSet<ExIpcustomerContact> ExIpcustomerContacts { get; set; }
        public virtual DbSet<ExIpcustomerConversion> ExIpcustomerConversions { get; set; }
        public virtual DbSet<ExIpcustomerConvertFromCat5> ExIpcustomerConvertFromCat5s { get; set; }
        public virtual DbSet<ExIpcustomerEngagement> ExIpcustomerEngagements { get; set; }
        public virtual DbSet<ExIpcustomerEngagementtype> ExIpcustomerEngagementtypes { get; set; }
        public virtual DbSet<ExIpcustomerGeo> ExIpcustomerGeos { get; set; }
        public virtual DbSet<ExIpcustomerGroup> ExIpcustomerGroups { get; set; }
        public virtual DbSet<ExIpcustomerJob> ExIpcustomerJobs { get; set; }
        public virtual DbSet<ExIpcustomerLocation> ExIpcustomerLocations { get; set; }
        public virtual DbSet<ExIpcustomerLocationNew> ExIpcustomerLocationNews { get; set; }
        public virtual DbSet<ExIpcustomerOther> ExIpcustomerOthers { get; set; }
        public virtual DbSet<ExIpcustomerOtherNew> ExIpcustomerOtherNews { get; set; }
        public virtual DbSet<ExIpcustomerProject> ExIpcustomerProjects { get; set; }
        public virtual DbSet<ExIpcustomerReason> ExIpcustomerReasons { get; set; }
        public virtual DbSet<ExIpcustomerRole> ExIpcustomerRoles { get; set; }
        public virtual DbSet<ExIpcustomerService> ExIpcustomerServices { get; set; }
        public virtual DbSet<ExIpcustomerServicesNew> ExIpcustomerServicesNews { get; set; }
        public virtual DbSet<ExIpcustomerSopDoc> ExIpcustomerSopDocs { get; set; }
        public virtual DbSet<ExIpcustomerSow> ExIpcustomerSows { get; set; }
        public virtual DbSet<ExIpcustomerTeam> ExIpcustomerTeams { get; set; }
        public virtual DbSet<ExIpcustomerUnbilledReason> ExIpcustomerUnbilledReasons { get; set; }
        public virtual DbSet<ExIppersonModuleMaster> ExIppersonModuleMasters { get; set; }
        public virtual DbSet<ExIppersonReplaceClient> ExIppersonReplaceClients { get; set; }
        public virtual DbSet<ExIppersonRoleMaster> ExIppersonRoleMasters { get; set; }
        public virtual DbSet<ExIppersonRoleModuleMapping> ExIppersonRoleModuleMappings { get; set; }
        public virtual DbSet<ExIpproject> ExIpprojects { get; set; }
        public virtual DbSet<ExIpprojectBillpercent> ExIpprojectBillpercents { get; set; }
        public virtual DbSet<ExIpprojectReason> ExIpprojectReasons { get; set; }
        public virtual DbSet<ExIpprojectRole> ExIpprojectRoles { get; set; }
        public virtual DbSet<ExIpprojectTeamAllocation> ExIpprojectTeamAllocations { get; set; }
        public virtual DbSet<ExIprolecoreskill> ExIprolecoreskills { get; set; }
        public virtual DbSet<ExLastClientUnLock> ExLastClientUnLocks { get; set; }
        public virtual DbSet<ExModuleAccessLog> ExModuleAccessLogs { get; set; }
        public virtual DbSet<ExModuleMaster> ExModuleMasters { get; set; }
        public virtual DbSet<ExModulePeLognAccess> ExModulePeLognAccesses { get; set; }
        public virtual DbSet<ExNewclientrequest> ExNewclientrequests { get; set; }
        public virtual DbSet<ExOffboardReasonMaster> ExOffboardReasonMasters { get; set; }
        public virtual DbSet<ExOffboardsDocumentation> ExOffboardsDocumentations { get; set; }
        public virtual DbSet<ExPeerqcdataMaster> ExPeerqcdataMasters { get; set; }
        public virtual DbSet<ExPoolMapping> ExPoolMappings { get; set; }
        public virtual DbSet<ExProductMaster> ExProductMasters { get; set; }
        public virtual DbSet<ExProjectAllocationPercentage> ExProjectAllocationPercentages { get; set; }
        public virtual DbSet<ExQueryBuilderColumn> ExQueryBuilderColumns { get; set; }
        public virtual DbSet<ExQueryBuilderSaveQuery> ExQueryBuilderSaveQueries { get; set; }
        public virtual DbSet<ExReplacementReasonMaster> ExReplacementReasonMasters { get; set; }
        public virtual DbSet<ExResourceAssignmentSendBack> ExResourceAssignmentSendBacks { get; set; }
        public virtual DbSet<ExResourceOmc> ExResourceOmcs { get; set; }
        public virtual DbSet<ExResourceOmcp> ExResourceOmcps { get; set; }
        public virtual DbSet<ExResourceOthassignment> ExResourceOthassignments { get; set; }
        public virtual DbSet<ExResourcePhaseHour> ExResourcePhaseHours { get; set; }
        public virtual DbSet<ExResourceProjectsStatus> ExResourceProjectsStatuses { get; set; }
        public virtual DbSet<ExResourceTentativeLongLeave> ExResourceTentativeLongLeaves { get; set; }
        public virtual DbSet<ExResourceallocation> ExResourceallocations { get; set; }
        public virtual DbSet<ExResourceallocationLog> ExResourceallocationLogs { get; set; }
        public virtual DbSet<ExResourceassignment> ExResourceassignments { get; set; }
        public virtual DbSet<ExResourceassignmentChecklist> ExResourceassignmentChecklists { get; set; }
        public virtual DbSet<ExResourceassignmentTran> ExResourceassignmentTrans { get; set; }
        public virtual DbSet<ExResourceassignmentlog> ExResourceassignmentlogs { get; set; }
        public virtual DbSet<ExResourceassignmentstatus> ExResourceassignmentstatuses { get; set; }
        public virtual DbSet<ExResourcebillpercent> ExResourcebillpercents { get; set; }
        public virtual DbSet<ExResourcebillpercentLog> ExResourcebillpercentLogs { get; set; }
        public virtual DbSet<ExResourcerequest> ExResourcerequests { get; set; }
        public virtual DbSet<ExResourcerequestLog> ExResourcerequestLogs { get; set; }
        public virtual DbSet<ExResourcerequestRole> ExResourcerequestRoles { get; set; }
        public virtual DbSet<ExResourcerequestSector> ExResourcerequestSectors { get; set; }
        public virtual DbSet<ExResourcerequestSkill> ExResourcerequestSkills { get; set; }
        public virtual DbSet<ExResourceresume> ExResourceresumes { get; set; }
        public virtual DbSet<ExResourceroleskill> ExResourceroleskills { get; set; }
        public virtual DbSet<ExResourceroleskillLog> ExResourceroleskillLogs { get; set; }
        public virtual DbSet<ExResourcerolestatus> ExResourcerolestatuses { get; set; }
        public virtual DbSet<ExResourcerolestatusLog> ExResourcerolestatusLogs { get; set; }
        public virtual DbSet<ExResourceskillmgrrating> ExResourceskillmgrratings { get; set; }
        public virtual DbSet<ExResourceskillmgrratingLog> ExResourceskillmgrratingLogs { get; set; }
        public virtual DbSet<ExResourceskillsevaluation> ExResourceskillsevaluations { get; set; }
        public virtual DbSet<ExResourceskilltraining> ExResourceskilltrainings { get; set; }
        public virtual DbSet<ExResourceskilltraininglog> ExResourceskilltraininglogs { get; set; }
        public virtual DbSet<ExResourceworkevaluation> ExResourceworkevaluations { get; set; }
        public virtual DbSet<ExRiskIden> ExRiskIdens { get; set; }
        public virtual DbSet<ExRiskMitPlan> ExRiskMitPlans { get; set; }
        public virtual DbSet<ExRiskSymptomMaster> ExRiskSymptomMasters { get; set; }
        public virtual DbSet<ExRiskcatMaster> ExRiskcatMasters { get; set; }
        public virtual DbSet<ExRiskscaleMaster> ExRiskscaleMasters { get; set; }
        public virtual DbSet<ExRoleMaster> ExRoleMasters { get; set; }
        public virtual DbSet<ExRoleTypeMaster> ExRoleTypeMasters { get; set; }
        public virtual DbSet<ExScreenMaster> ExScreenMasters { get; set; }
        public virtual DbSet<ExServicetype> ExServicetypes { get; set; }
        public virtual DbSet<ExSkillsetMasterLevel> ExSkillsetMasterLevels { get; set; }
        public virtual DbSet<ExSlalevelMaster> ExSlalevelMasters { get; set; }
        public virtual DbSet<ExSownumber> ExSownumbers { get; set; }
        public virtual DbSet<ExStatusdesc> ExStatusdescs { get; set; }
        public virtual DbSet<ExSubreasonMaster> ExSubreasonMasters { get; set; }
        public virtual DbSet<ExSummaryDataLog> ExSummaryDataLogs { get; set; }
        public virtual DbSet<ExSysReleaseUpdate> ExSysReleaseUpdates { get; set; }
        public virtual DbSet<ExSysReleaseUpdateReadBy> ExSysReleaseUpdateReadBies { get; set; }
        public virtual DbSet<ExTransactionApproval> ExTransactionApprovals { get; set; }
        public virtual DbSet<ExUnbilledMaster> ExUnbilledMasters { get; set; }
        public virtual DbSet<ExUsageClauseMaster> ExUsageClauseMasters { get; set; }
        public virtual DbSet<ExUtilizationMaster> ExUtilizationMasters { get; set; }
        public virtual DbSet<ExUtilizationMasterBilling> ExUtilizationMasterBillings { get; set; }
        public virtual DbSet<GroupRoleMapping> GroupRoleMappings { get; set; }
        public virtual DbSet<HcActionItem> HcActionItems { get; set; }
        public virtual DbSet<HcAduitDm> HcAduitDms { get; set; }
        public virtual DbSet<HcCommStatsBenchMark> HcCommStatsBenchMarks { get; set; }
        public virtual DbSet<HcDatum> HcData { get; set; }
        public virtual DbSet<HcMaster> HcMasters { get; set; }
        public virtual DbSet<HcMetaDatum> HcMetaData { get; set; }
        public virtual DbSet<HcQuery> HcQueries { get; set; }
        public virtual DbSet<HcRealtimeSummary> HcRealtimeSummaries { get; set; }
        public virtual DbSet<HcTrigger> HcTriggers { get; set; }
        public virtual DbSet<HcVacomment> HcVacomments { get; set; }
        public virtual DbSet<IpActivity> IpActivities { get; set; }
        public virtual DbSet<IpCustomer> IpCustomers { get; set; }
        public virtual DbSet<IpDailyeff> IpDailyeffs { get; set; }
        public virtual DbSet<IpNewproj> IpNewprojs { get; set; }
        public virtual DbSet<IpPhase> IpPhases { get; set; }
        public virtual DbSet<IpProject> IpProjects { get; set; }
        public virtual DbSet<IpTasktype> IpTasktypes { get; set; }
        public virtual DbSet<MailLog> MailLogs { get; set; }
        public virtual DbSet<MasterAbbrevation> MasterAbbrevations { get; set; }
        public virtual DbSet<Phcsummary> Phcsummaries { get; set; }
        public virtual DbSet<Productconfig> Productconfigs { get; set; }
        public virtual DbSet<ProjRequestDetail> ProjRequestDetails { get; set; }
        public virtual DbSet<ProjRequestStatus> ProjRequestStatuses { get; set; }
        public virtual DbSet<ProjStatusMaster> ProjStatusMasters { get; set; }
        public virtual DbSet<ProjTeam> ProjTeams { get; set; }
        public virtual DbSet<PromotionNomination> PromotionNominations { get; set; }
        public virtual DbSet<PromotionPanelMember> PromotionPanelMembers { get; set; }
        public virtual DbSet<QAvailableField> QAvailableFields { get; set; }
        public virtual DbSet<QReportName> QReportNames { get; set; }
        public virtual DbSet<QSelectedFieldsReportMapping> QSelectedFieldsReportMappings { get; set; }
        public virtual DbSet<RealtimeHcsummary> RealtimeHcsummaries { get; set; }
        public virtual DbSet<RfpBugCapture> RfpBugCaptures { get; set; }
        public virtual DbSet<RfpDproposal> RfpDproposals { get; set; }
        public virtual DbSet<RfpDquesresp> RfpDquesresps { get; set; }
        public virtual DbSet<RfpHproposal> RfpHproposals { get; set; }
        public virtual DbSet<RfpHquesresp> RfpHquesresps { get; set; }
        public virtual DbSet<Rfpemailtemplate> Rfpemailtemplates { get; set; }
        public virtual DbSet<RrApproval> RrApprovals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmbTtphasemap>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AMB_TTPHASEMAP");

                entity.Property(e => e.PhCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PH_CODE");

                entity.Property(e => e.Projtype)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PROJTYPE");

                entity.Property(e => e.TtBillable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TT_BILLABLE")
                    .IsFixedLength();

                entity.Property(e => e.TtCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TT_CODE");

                entity.Property(e => e.TtRole)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TT_Role");

                entity.Property(e => e.TtStatus).HasColumnName("TT_Status");
            });

            modelBuilder.Entity<AmbaJobRefNo>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Amba_JobRefNo");
            });

            modelBuilder.Entity<BillEntityMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Bill_Entity_Master");

                entity.Property(e => e.EntityDesc).HasMaxLength(1000);

                entity.Property(e => e.EntityName).HasMaxLength(100);

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ClientWorkordersWithAnalyst>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ClientWorkordersWithAnalyst");

                entity.Property(e => e.AccountManager).HasMaxLength(255);

                entity.Property(e => e.Ambaanalystname).HasMaxLength(255);

                entity.Property(e => e.BillingAddress1).HasMaxLength(255);

                entity.Property(e => e.BillingAddress2).HasMaxLength(255);

                entity.Property(e => e.BillingAddress3).HasMaxLength(255);

                entity.Property(e => e.BillingAddress4).HasMaxLength(255);

                entity.Property(e => e.BillingAddress5).HasMaxLength(255);

                entity.Property(e => e.BillingCity).HasMaxLength(255);

                entity.Property(e => e.BillingCountry).HasMaxLength(255);

                entity.Property(e => e.BillingCurrency).HasMaxLength(255);

                entity.Property(e => e.BillingFrequency).HasMaxLength(255);

                entity.Property(e => e.BillingMethod).HasMaxLength(255);

                entity.Property(e => e.BillingPersonEmailId)
                    .HasMaxLength(255)
                    .HasColumnName("BillingPersonEMailID");

                entity.Property(e => e.BillingPersonName).HasMaxLength(255);

                entity.Property(e => e.ClientCode)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.ClientCodeWithLocation).HasMaxLength(255);

                entity.Property(e => e.ClientGroup).HasMaxLength(255);

                entity.Property(e => e.ClientType).HasMaxLength(255);

                entity.Property(e => e.ContractNo).HasMaxLength(255);

                entity.Property(e => e.EmailCc)
                    .HasMaxLength(255)
                    .HasColumnName("EmailCC");

                entity.Property(e => e.Msadate)
                    .HasColumnType("datetime")
                    .HasColumnName("MSADate");

                entity.Property(e => e.Msano)
                    .HasMaxLength(255)
                    .HasColumnName("MSANo");

                entity.Property(e => e.Nextrevision).HasMaxLength(255);

                entity.Property(e => e.PresentationCurrency).HasMaxLength(255);

                entity.Property(e => e.RateType)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.WorkOrderNumber).HasMaxLength(255);

                entity.Property(e => e.WorkorderContactName).HasMaxLength(255);

                entity.Property(e => e.WorkorderDate).HasMaxLength(255);
            });

            modelBuilder.Entity<ClientreportConfig>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CLIENTREPORT_CONFIG");

                entity.Property(e => e.Client).HasColumnName("CLIENT");

                entity.Property(e => e.Link)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("LINK");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<Cupload>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("CUpload");

                entity.Property(e => e.AcceptanceProcedures).HasColumnName("Acceptance Procedures");

                entity.Property(e => e.AdminRelated).HasColumnName("Admin Related");

                entity.Property(e => e.BackgroundChecking).HasColumnName("Background checking");

                entity.Property(e => e.BcpRequirements).HasColumnName("BCP Requirements");

                entity.Property(e => e.BlackOutPeriod).HasColumnName("Black out Period");

                entity.Property(e => e.ChangesRequestProcedure).HasColumnName("Changes Request Procedure");

                entity.Property(e => e.ClientCode)
                    .HasMaxLength(255)
                    .HasColumnName("Client Code");

                entity.Property(e => e.ConfidentialityClause).HasColumnName("Confidentiality Clause");

                entity.Property(e => e.ContractCommencementDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Contract Commencement Date");

                entity.Property(e => e.ContractType)
                    .HasMaxLength(255)
                    .HasColumnName("Contract Type");

                entity.Property(e => e.CuIden).HasColumnName("Cu_Iden");

                entity.Property(e => e.DataSources).HasColumnName("Data Sources");

                entity.Property(e => e.DeliveryManager)
                    .HasMaxLength(255)
                    .HasColumnName("Delivery Manager");

                entity.Property(e => e.DeliveryRelated).HasColumnName("Delivery Related");

                entity.Property(e => e.HrRelated).HasColumnName("HR Related");

                entity.Property(e => e.ImWaiver).HasColumnName("IM Waiver");

                entity.Property(e => e.IpRights).HasColumnName("IP Rights");

                entity.Property(e => e.ItIsRelated).HasColumnName("IT/IS Related");

                entity.Property(e => e.LegalIdentity)
                    .HasMaxLength(255)
                    .HasColumnName("Legal Identity");

                entity.Property(e => e.LiabilityClause).HasColumnName("Liability Clause");

                entity.Property(e => e.MnpiRequirements).HasColumnName("MNPI Requirements");

                entity.Property(e => e.NonSolicitationClause).HasColumnName("Non Solicitation clause");

                entity.Property(e => e.OtherComments).HasColumnName("Other Comments");

                entity.Property(e => e.OtherObligations).HasColumnName("Other Obligations");

                entity.Property(e => e.OverlapPeriod).HasColumnName("Overlap Period");

                entity.Property(e => e.RelationshipManagement).HasColumnName("Relationship Management");

                entity.Property(e => e.SeatingArrangments).HasColumnName("Seating Arrangments");

                entity.Property(e => e.SecurityTokens).HasColumnName("Security Tokens");

                entity.Property(e => e.ServiceLince)
                    .HasMaxLength(255)
                    .HasColumnName("Service Lince");

                entity.Property(e => e.SubContracting).HasColumnName("Sub Contracting");

                entity.Property(e => e.TerminationClause).HasColumnName("Termination Clause");

                entity.Property(e => e.TerminationRelatedObligations).HasColumnName("Termination Related obligations");

                entity.Property(e => e.UseOfResources).HasColumnName("Use of Resources");
            });

            modelBuilder.Entity<ExAccessMaster>(entity =>
            {
                entity.ToTable("EX_ACCESS_MASTER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Admin).HasColumnName("ADMIN");

                entity.Property(e => e.Approver).HasColumnName("APPROVER");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.EntityId)
                    .HasMaxLength(1000)
                    .HasColumnName("EntityID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Role)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.ServiceLine)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SERVICE_LINE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Superadmin).HasColumnName("SUPERADMIN");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExAccessMasterByIpcustomer>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Access_master_by_IPCustomer");

                entity.Property(e => e.Admin).HasColumnName("ADMIN");

                entity.Property(e => e.CuIden).HasColumnName("cu_iden");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.EnddateEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate_entrystamp");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("enddate_userlognid");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("entrystamp");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pe_logn");

                entity.Property(e => e.ServiceLine)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("service_Line");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("userlognid");
            });

            modelBuilder.Entity<ExBillcategorymaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_BILLCATEGORYMASTER");

                entity.Property(e => e.BillcatId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("BILLCAT_ID");

                entity.Property(e => e.BillcatName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BILLCAT_NAME");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Lognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LOGNID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ExChecklistMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_CHECKLIST_MASTER");

                entity.Property(e => e.ChecklistDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CHECKLIST_DESC");

                entity.Property(e => e.ChecklistId).HasColumnName("CHECKLIST_ID");

                entity.Property(e => e.ChecklistNote)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CHECKLIST_NOTE");

                entity.Property(e => e.ChecklistType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CHECKLIST_TYPE");

                entity.Property(e => e.Enteredby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENTEREDBY");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<ExClientCallFeedback>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.PeLogn, e.KickOffDt, e.Sl });

                entity.ToTable("Ex_ClientCall_Feedback");

                entity.Property(e => e.CuIden).HasColumnName("Cu_Iden");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.KickOffDt).HasColumnType("datetime");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.CallPeriod).HasColumnType("datetime");

                entity.Property(e => e.CalledDate).HasColumnType("datetime");

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.ScheduledDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserDesg)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExClientCallPostPone>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.PeLogn, e.KickOffDt, e.Sl });

                entity.ToTable("Ex_ClientCall_PostPone");

                entity.Property(e => e.CuIden).HasColumnName("Cu_Iden");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.KickOffDt).HasColumnType("datetime");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.CallPeriod).HasColumnType("datetime");

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.PostPonedDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserDesg)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExClientClause>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.ClauseId, e.ClauseSubid, e.CommenceStartDate });

                entity.ToTable("EX_CLIENT_CLAUSE");

                entity.Property(e => e.CuIden).HasColumnName("cu_iden");

                entity.Property(e => e.ClauseId).HasColumnName("clause_id");

                entity.Property(e => e.ClauseSubid).HasColumnName("clause_subid");

                entity.Property(e => e.CommenceStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Commence_StartDate");

                entity.Property(e => e.Attachment)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.ClauseDesc)
                    .IsUnicode(false)
                    .HasColumnName("clause_Desc");

                entity.Property(e => e.CommenceEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Commence_EndDate");

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExClientClauseDepartment>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.ClauseId, e.ClauseSubid, e.ElCode });

                entity.ToTable("EX_CLIENT_CLAUSE_DEPARTMENTS");

                entity.Property(e => e.CuIden).HasColumnName("cu_iden");

                entity.Property(e => e.ClauseId).HasColumnName("clause_id");

                entity.Property(e => e.ClauseSubid).HasColumnName("clause_subid");

                entity.Property(e => e.ElCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("el_code");

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExClientClauseMasterCommunicateto>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.CaCode });

                entity.ToTable("EX_CLIENT_CLAUSE_MASTER_COMMUNICATETO");

                entity.Property(e => e.Id)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("id");

                entity.Property(e => e.CaCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ca_code");

                entity.Property(e => e.CommunicateTo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Communicate_To");

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.RelatedTo)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExClientClausePublish>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.ClauseId, e.ClauseSubid });

                entity.ToTable("EX_CLIENT_CLAUSE_PUBLISH");

                entity.Property(e => e.CuIden).HasColumnName("cu_iden");

                entity.Property(e => e.ClauseId).HasColumnName("clause_id");

                entity.Property(e => e.ClauseSubid).HasColumnName("clause_subid");

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.PublishYn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Publish_YN")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExClientClauseType>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.ClauseId, e.ClauseSubid, e.ClauseTypeId });

                entity.ToTable("EX_CLIENT_CLAUSE_TYPE");

                entity.Property(e => e.CuIden).HasColumnName("cu_iden");

                entity.Property(e => e.ClauseId).HasColumnName("clause_id");

                entity.Property(e => e.ClauseSubid).HasColumnName("clause_subid");

                entity.Property(e => e.ClauseTypeId).HasColumnName("Clause_TypeId");

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExClientClauseTypeDeptMap>(entity =>
            {
                entity.HasKey(e => new { e.ClauseMapId, e.ElCode, e.EffectiveStartDate });

                entity.ToTable("EX_CLIENT_CLAUSE_TYPE_DEPT_MAP");

                entity.Property(e => e.ClauseMapId).HasColumnName("Clause_MapID");

                entity.Property(e => e.ElCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("El_code");

                entity.Property(e => e.EffectiveStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Effective_StartDate");

                entity.Property(e => e.EffectiveEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Effective_EndDate");

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExClientClauseTypeMaster>(entity =>
            {
                entity.HasKey(e => new { e.ClauseTypeId, e.TypeDesc, e.CatId });

                entity.ToTable("EX_CLIENT_CLAUSE_TYPE_MASTER");

                entity.Property(e => e.ClauseTypeId).HasColumnName("Clause_TypeID");

                entity.Property(e => e.TypeDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Type_Desc");

                entity.Property(e => e.CatId).HasColumnName("Cat_ID");

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExClientConfiguration>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Client_Configuration");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.ElCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EL_CODE");

                entity.Property(e => e.IsAcuityDriveReq)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsBgcmandatory)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IsBGCMandatory");

                entity.Property(e => e.IsCompliacneMandatory)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsComplianceAutoApprove)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsDrugTestMandatory)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsFinanceAutoApprove)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsFinanceMandatory)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsIdentityTestMandatory)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsSowmandatory)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IsSOWMandatory");

                entity.Property(e => e.IsTimeSheetReq)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.IsVdireq)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IsVDIReq");
            });

            modelBuilder.Entity<ExClientIndustoryClassification>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.ClassificationId });

                entity.ToTable("EX_CLIENT_Industory_Classification");

                entity.Property(e => e.CuIden).HasColumnName("cu_iden");

                entity.Property(e => e.ClassificationId).HasColumnName("Classification_id");

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExClientPlOwner>(entity =>
            {
                entity.HasKey(e => new { e.PeLogn, e.ServiceLine, e.Startdate });

                entity.ToTable("EX_CLIENT_PL_OWNER");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.ServiceLine)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SERVICE_LINE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.MailStatus).HasColumnName("MAIL_STATUS");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExClientProjectIsEnable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_Client_Project_IsEnable");

                entity.Property(e => e.CuIden).HasColumnName("Cu_Iden");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ServiceLine)
                    .HasMaxLength(100)
                    .HasColumnName("Service_Line");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(100)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExClientServiceline>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.ServiceLine, e.Startdate, e.Entrystamp });

                entity.ToTable("Ex_CLIENT_SERVICELINE");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.ServiceLine)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SERVICE_LINE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.MailStatus)
                    .HasColumnName("MAIL_STATUS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExClientServicelineNew>(entity =>
            {
                entity.ToTable("Ex_CLIENT_SERVICELINE_New");

                entity.HasIndex(e => new { e.CuIden, e.ServiceLine, e.Startdate }, "uq_CLIENT_SERVICELINE")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.MailStatus)
                    .HasColumnName("MAIL_STATUS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.ServiceLine)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SERVICE_LINE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExClientWorkDemand>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.FromDate, e.Projectname });

                entity.ToTable("EX_ClientWorkDemand");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.FromDate)
                    .HasColumnType("datetime")
                    .HasColumnName("FROM_DATE");

                entity.Property(e => e.Projectname)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PROJECTNAME");

                entity.Property(e => e.ClarityOfCommunicationWithClientClntDem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Clarity_of_communication_with_client_ClntDem");

                entity.Property(e => e.ClientSupportClntDem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Client_support_ClntDem");

                entity.Property(e => e.ComplexityOfFinancialModelingClntDem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Complexity_of_financial_modeling_ClntDem");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.InvestmentIdeasAndIndependentThinkingClntDem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Investment_ideas_and_independent_thinking_ClntDem");

                entity.Property(e => e.KnowledgeOfIndustryFundamentalsClntDem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Knowledge_of_industry_fundamentals_ClntDem");

                entity.Property(e => e.KnowledgeOfMarketsMarketdriversNewsClntDem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Knowledge_of_markets_marketdrivers_news_ClntDem");

                entity.Property(e => e.KnowledgeOfValuationTechniquesClntDem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Knowledge_of_valuation_techniques_ClntDem");

                entity.Property(e => e.LongWorkingHoursClntDem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Long_working_hours_ClntDem");

                entity.Property(e => e.QuickTurnaroundDeadlinePressureClntDem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Quick_turnaround_deadline_pressure_ClntDem");

                entity.Property(e => e.StandardOfWrittenEnglishAndReportWritingClntDem)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Standard_of_written_English_and_report_writing_ClntDem");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.ToDate)
                    .HasColumnType("datetime")
                    .HasColumnName("TO_DATE");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExClientcontact>(entity =>
            {
                entity.ToTable("EX_CLIENTCONTACT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Emailid)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("EMAILID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EnteredOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("NAME");

                entity.Property(e => e.PhoneNumber)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExClientcontract>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.ClientGroup, e.Serialno })
                    .HasName("PK_Ex_ClientContract_1");

                entity.ToTable("EX_CLIENTCONTRACT");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.ClientGroup)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Serialno).HasColumnName("SERIALNO");

                entity.Property(e => e.AgreedNoticePeriod).HasColumnName("Agreed_Notice_Period");

                entity.Property(e => e.BlackoutDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BlackoutPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Comcontracteffectfrom)
                    .HasColumnType("datetime")
                    .HasColumnName("COMCONTRACTEFFECTFROM");

                entity.Property(e => e.Comcontracteffectto)
                    .HasColumnType("datetime")
                    .HasColumnName("COMCONTRACTEFFECTTO");

                entity.Property(e => e.Comcontractsigned)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("COMCONTRACTSIGNED")
                    .IsFixedLength();

                entity.Property(e => e.Comcontractsigneddate)
                    .HasColumnType("datetime")
                    .HasColumnName("COMCONTRACTSIGNEDDATE");

                entity.Property(e => e.Comkickoffapproved)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("COMKICKOFFAPPROVED")
                    .IsFixedLength();

                entity.Property(e => e.CommNegStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COMM_NEG_STATUS");

                entity.Property(e => e.ContractStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACT_STATUS");

                entity.Property(e => e.Contracteffectfrom)
                    .HasColumnType("datetime")
                    .HasColumnName("CONTRACTEFFECTFROM");

                entity.Property(e => e.Contracteffectto)
                    .HasColumnType("datetime")
                    .HasColumnName("CONTRACTEFFECTTO");

                entity.Property(e => e.Contractrefdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CONTRACTREFDATE");

                entity.Property(e => e.Contractrefno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACTREFNO");

                entity.Property(e => e.Contractsigneddate)
                    .HasColumnType("datetime")
                    .HasColumnName("CONTRACTSIGNEDDATE");

                entity.Property(e => e.Contractsoftcopy)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACTSOFTCOPY");

                entity.Property(e => e.EntereredbyFinance)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTEREREDBY_Finance");

                entity.Property(e => e.EntereredbyLegal)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTEREREDBY_Legal");

                entity.Property(e => e.EntrystampFinance)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP_Finance");

                entity.Property(e => e.EntrystampLegal)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP_Legal");

                entity.Property(e => e.FinDeptComment)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Fin_Dept_comment");

                entity.Property(e => e.Iscontractsigned)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ISCONTRACTSIGNED");

                entity.Property(e => e.Isoktoonboard)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ISOKTOONBOARD")
                    .IsFixedLength();

                entity.Property(e => e.LegalDeptComment)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Legal_Dept_Comment");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Typeofservices)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TYPEOFSERVICES");
            });

            modelBuilder.Entity<ExClientcontractBlackoutperiod>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.Clientgroup, e.Location, e.Sl });

                entity.ToTable("EX_CLIENTCONTRACT_BLACKOUTPERIOD");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Clientgroup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTGROUP");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Blackoutdesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("BLACKOUTDESC");

                entity.Property(e => e.Blackoutperiod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BLACKOUTPERIOD");

                entity.Property(e => e.Contractrefdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CONTRACTREFDATE");

                entity.Property(e => e.Contractrefno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACTREFNO");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Startdt)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDT");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExClientsow>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.Serialno, e.Sowno })
                    .HasName("PK_Ex_ClientSOW_1");

                entity.ToTable("EX_CLIENTSOW");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Serialno).HasColumnName("SERIALNO");

                entity.Property(e => e.Sowno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SOWNO");

                entity.Property(e => e.AgreedNoticePeriod).HasColumnName("Agreed_Notice_Period");

                entity.Property(e => e.BlackoutDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BlackoutPeriod)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ComNegotiationStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Com_Negotiation_Status");

                entity.Property(e => e.ContractSoftcopy)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Entereredby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENTEREREDBY");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.FinComments)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Fin_comments");

                entity.Property(e => e.Grp)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.KickOffDt).HasColumnType("datetime");

                entity.Property(e => e.LegalComments)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("Legal_Comments");

                entity.Property(e => e.Msano)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MSANO");

                entity.Property(e => e.Oktoonboard)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Sowapproved)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("SOWApproved")
                    .IsFixedLength();

                entity.Property(e => e.Sowdate)
                    .HasColumnType("datetime")
                    .HasColumnName("SOWDATE");

                entity.Property(e => e.SowlegalStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SOWLegalStatus");

                entity.Property(e => e.Sowstatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SOWStatus");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Typeofservices)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TYPEOFSERVICES");
            });

            modelBuilder.Entity<ExClientsowBlackoutperiod>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.ClientGroup, e.Sl, e.Contractsowno, e.Contractsowdate });

                entity.ToTable("EX_CLIENTSOW_BLACKOUTPERIOD");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.ClientGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Contractsowno)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACTSOWNO");

                entity.Property(e => e.Contractsowdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CONTRACTSOWDATE");

                entity.Property(e => e.Blackoutdesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("BLACKOUTDESC");

                entity.Property(e => e.Blackoutperiod)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("BLACKOUTPERIOD");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.StartDt).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExCompanyMaster>(entity =>
            {
                entity.HasKey(e => e.CntrlCc)
                    .HasName("PK__Ex_Compa__39AF3E98FDB8D3FE");

                entity.ToTable("Ex_CompanyMaster");

                entity.Property(e => e.CntrlCc).HasColumnName("Cntrl_CC");

                entity.Property(e => e.CcAddrLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CC_AddrLine1");

                entity.Property(e => e.CcAddrLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CC_AddrLine2");

                entity.Property(e => e.CcAddrLine3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CC_AddrLine3");

                entity.Property(e => e.CcAddrLine4)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CC_AddrLine4");

                entity.Property(e => e.CcCountryId).HasColumnName("CC_CountryID");

                entity.Property(e => e.CcLocnId).HasColumnName("CC_LocnID");

                entity.Property(e => e.CcName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CC_name");

                entity.Property(e => e.Countrycode)
                    .HasMaxLength(100)
                    .HasColumnName("countrycode");

                entity.Property(e => e.EntreredbY)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Industryvertical)
                    .HasMaxLength(200)
                    .HasColumnName("industryvertical");

                entity.Property(e => e.MailAddrLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MailAddrLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MailAddrLine3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MailAddrLine4)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MailCountryId).HasColumnName("MailCountryID");

                entity.Property(e => e.MailLocnId).HasColumnName("MailLocnID");

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.RegistrationNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ExContractMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Contract_MASTER");

                entity.Property(e => e.Backgroundcheck)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.Cuiden).HasColumnName("CUIDEN");

                entity.Property(e => e.Drugcheck)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.Enteredby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENTEREDBY");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Idenditycheck)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.Msadate)
                    .HasColumnType("datetime")
                    .HasColumnName("MSADate");

                entity.Property(e => e.MsafileName)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("MSAFileName");

                entity.Property(e => e.MsafilePath)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("MSAFilePath");

                entity.Property(e => e.Msanumber)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("MSANumber");

                entity.Property(e => e.ServiceLine)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.Sowdate)
                    .HasColumnType("datetime")
                    .HasColumnName("SOWDate");

                entity.Property(e => e.SowfileName)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("SOWFileName");

                entity.Property(e => e.SowfilePath)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("SOWFilePath");

                entity.Property(e => e.Sownumber)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SOWNumber");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<ExCsatHelpdesk>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_CSAT_HELPDESK");

                entity.Property(e => e.Benefitarea)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("BENEFITAREA");

                entity.Property(e => e.Clientanal)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTANAL");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.ReqAttendedEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("REQ_ATTENDED_ENTRYSTAMP");

                entity.Property(e => e.ReqAttendedLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REQ_ATTENDED_LOGN");

                entity.Property(e => e.ReqId).HasColumnName("REQ_ID");

                entity.Property(e => e.ReviewFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("REVIEW_FROM");

                entity.Property(e => e.ReviewTo)
                    .HasColumnType("datetime")
                    .HasColumnName("REVIEW_TO");

                entity.Property(e => e.Sector)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SECTOR");

                entity.Property(e => e.Skillset)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SKILLSET");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExCsatHelpdeskLink>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_CSAT_HELPDESK_LINKS");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Links)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("LINKS");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.ReqId).HasColumnName("REQ_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExCsatHelpdeskMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_CSAT_HELPDESK_MASTERS");

                entity.Property(e => e.RecId)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("REC_ID");

                entity.Property(e => e.Rectype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RECTYPE");

                entity.Property(e => e.Recvalue)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("RECVALUE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<ExCsatHelpdeskTask>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_CSAT_HELPDESK_TASKS");

                entity.Property(e => e.Clientanal)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTANAL");

                entity.Property(e => e.ReqId).HasColumnName("REQ_ID");

                entity.Property(e => e.Tasks)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("TASKS");
            });

            modelBuilder.Entity<ExCuIdenSowIsmandate>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.Issowmandate });

                entity.ToTable("EX_CU_IDEN_SOW_ISMANDATE");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Issowmandate).HasColumnName("ISSOWMANDATE");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(20)
                    .HasColumnName("UPDATEDBY");

                entity.Property(e => e.Updatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATEDON");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(20)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExDataCutOffDate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Data_CutOff_Dates");

                entity.Property(e => e.CutOffDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(100);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(100)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExDetailedDataLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Detailed_Data_Logs");

                entity.Property(e => e.Allocation).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.BillEnd).HasColumnType("datetime");

                entity.Property(e => e.BillEntity).HasMaxLength(100);

                entity.Property(e => e.BillPercent).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.BillStart).HasColumnType("datetime");

                entity.Property(e => e.ClientType).HasMaxLength(100);

                entity.Property(e => e.CuIden)
                    .HasMaxLength(10)
                    .HasColumnName("Cu_Iden");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Of_Move");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.FinalStatus).HasMaxLength(100);

                entity.Property(e => e.ForDepartment).HasMaxLength(100);

                entity.Property(e => e.ForEntity).HasMaxLength(100);

                entity.Property(e => e.ForMonth).HasMaxLength(100);

                entity.Property(e => e.ForTheDate).HasColumnType("datetime");

                entity.Property(e => e.Group).HasMaxLength(100);

                entity.Property(e => e.KickOffDate).HasColumnType("datetime");

                entity.Property(e => e.Lobgrouping)
                    .HasMaxLength(1000)
                    .HasColumnName("LOBGrouping");

                entity.Property(e => e.PeLocn)
                    .HasMaxLength(10)
                    .HasColumnName("Pe_Locn");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(100)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.Reason).HasMaxLength(100);

                entity.Property(e => e.ReplaceWith).HasMaxLength(200);

                entity.Property(e => e.Role).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.Property(e => e.StatusLvl)
                    .HasMaxLength(10)
                    .HasColumnName("Status_Lvl");

                entity.Property(e => e.TransactionEntryStamp).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExEmailTemplate>(entity =>
            {
                entity.HasKey(e => e.Templateid)
                    .HasName("PK_rfpemailtemplate");

                entity.ToTable("EX_Email_Template");

                entity.Property(e => e.Templateid)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("templateid");

                entity.Property(e => e.Creby)
                    .HasMaxLength(100)
                    .HasColumnName("creby");

                entity.Property(e => e.Credate)
                    .HasColumnType("datetime")
                    .HasColumnName("credate");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("is_enabled")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Templatebody).HasColumnName("templatebody");

                entity.Property(e => e.Templatedesc).HasColumnName("templatedesc");

                entity.Property(e => e.Templatename)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("templatename");

                entity.Property(e => e.Templatesubject)
                    .HasMaxLength(2000)
                    .HasColumnName("templatesubject");

                entity.Property(e => e.Updby)
                    .HasMaxLength(100)
                    .HasColumnName("updby");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");
            });

            modelBuilder.Entity<ExEmailVariable>(entity =>
            {
                entity.HasKey(e => e.Variableid)
                    .HasName("PK_rfpvariable");

                entity.ToTable("EX_Email_variable");

                entity.Property(e => e.Variableid).HasColumnName("variableid");

                entity.Property(e => e.Creby)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("creby");

                entity.Property(e => e.Credate)
                    .HasColumnType("datetime")
                    .HasColumnName("credate");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsEnabled).HasColumnName("is_enabled");

                entity.Property(e => e.Updby)
                    .HasMaxLength(100)
                    .HasColumnName("updby");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Variabledesc).HasColumnName("variabledesc");

                entity.Property(e => e.Variablename)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .HasColumnName("variablename");
            });

            modelBuilder.Entity<ExEmailnotification>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_EMAILNOTIFICATION");

                entity.Property(e => e.Bccmailid)
                    .IsUnicode(false)
                    .HasColumnName("BCCMAILID");

                entity.Property(e => e.Ccmailid)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("CCMAILID");

                entity.Property(e => e.CuCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CU_CODE");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Dept)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DEPT");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Location).HasColumnName("LOCATION");

                entity.Property(e => e.Moduleid).HasColumnName("MODULEID");

                entity.Property(e => e.Modulename)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MODULENAME");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Tomailid)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("TOMAILID");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExEngagementType>(entity =>
            {
                entity.ToTable("EX_Engagement_type");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.Engagement)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EntityId)
                    .HasMaxLength(1000)
                    .HasColumnName("EntityID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExEscalationMatrix>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Escalation_Matrix");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.LevelId).HasColumnName("LevelID");

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExEventMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Event_Master");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.EventDesc).HasMaxLength(2000);

                entity.Property(e => e.EventId).HasColumnName("EventID");

                entity.Property(e => e.EventName).HasMaxLength(1000);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExExceptionRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_EXCEPTION_ROLES");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Role)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExGeneralParameterConfiguration>(entity =>
            {
                entity.HasKey(e => e.ParameterId);

                entity.ToTable("EX_General_Parameter_Configuration");

                entity.Property(e => e.ParameterId).HasColumnName("ParameterID");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasMaxLength(20);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.ParameterName).HasMaxLength(1000);

                entity.Property(e => e.ParameterValue).HasMaxLength(1000);

                entity.Property(e => e.ParametervalueType).HasMaxLength(100);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExGroupMainservice>(entity =>
            {
                entity.HasKey(e => e.Maingroupid);

                entity.ToTable("EX_GROUP_MAINSERVICES");

                entity.Property(e => e.Maingroupid).HasColumnName("MAINGROUPID");

                entity.Property(e => e.Clientgroup)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTGROUP");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Maingroupdesc)
                    .IsRequired()
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("MAINGROUPDESC");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExGroupSubservice>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_GROUP_SUBSERVICES");

                entity.Property(e => e.Clientgroup)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTGROUP");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Maingroupid).HasColumnName("MAINGROUPID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Subgroupdesc)
                    .IsRequired()
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("SUBGROUPDESC");

                entity.Property(e => e.Subgroupid).HasColumnName("SUBGROUPID");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExHraccessEntitywise>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_HRACCESS_ENTITYWISE");

                entity.Property(e => e.CntrlEntityid).HasColumnName("CNTRL_ENTITYID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Lastupdatedby)
                    .HasMaxLength(20)
                    .HasColumnName("LASTUPDATEDBY");

                entity.Property(e => e.Lastupdatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("LASTUPDATEDON");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(20)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExHrmodulemaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_HRMODULEMASTER");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasMaxLength(20);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.ModuleName).HasMaxLength(300);

                entity.Property(e => e.Status).HasMaxLength(1);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIndustoryClassificationMaster>(entity =>
            {
                entity.HasKey(e => e.ClassificationId);

                entity.ToTable("EX_Industory_Classification_master");

                entity.Property(e => e.ClassificationId).HasColumnName("Classification_id");

                entity.Property(e => e.Classification)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EntryBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExInfrastructure>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_Infrastructure");

                entity.Property(e => e.Enteredby).HasColumnName("enteredby");

                entity.Property(e => e.Enteredon)
                    .HasColumnType("datetime")
                    .HasColumnName("enteredon");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ServerIp).HasColumnName("ServerIP");

                entity.Property(e => e.Updatedby).HasColumnName("updatedby");

                entity.Property(e => e.Updatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedon");
            });

            modelBuilder.Entity<ExIpclientGroup>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.GroupId, e.Status });

                entity.ToTable("EX_IPCLIENT_GROUP");

                entity.Property(e => e.CuIden).HasColumnName("CU_Iden");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExIpclientGroupMaster>(entity =>
            {
                entity.HasKey(e => new { e.GroupId, e.GroupName, e.Status });

                entity.ToTable("EX_IPCLIENT_GROUP_MASTER");

                entity.Property(e => e.GroupId).HasColumnName("GroupID");

                entity.Property(e => e.GroupName).HasMaxLength(500);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExIpcustomer>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.CuCode, e.CuName });

                entity.ToTable("EX_IPCUSTOMER");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.CuCode)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("CU_CODE");

                entity.Property(e => e.CuName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CU_NAME");

                entity.Property(e => e.Bgv)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("BGV");

                entity.Property(e => e.ClientGroup)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Clienttype)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTTYPE");

                entity.Property(e => e.DrugTestReq)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DrugTest_Req");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastupdatedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATED_BY");

                entity.Property(e => e.LastupdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LASTUPDATED_ON");

                entity.Property(e => e.Lastupdatedby1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATEDBY");

                entity.Property(e => e.Lastupdatedon1)
                    .HasColumnType("datetime")
                    .HasColumnName("LASTUPDATEDON");

                entity.Property(e => e.NdasignDate)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NDASignDate");

                entity.Property(e => e.RepliconDataPort)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Replicon_DataPort");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.WinLoginid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WIN_LOGINID");
            });

            modelBuilder.Entity<ExIpcustomerActype>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPCUSTOMER_ACTYPE");

                entity.Property(e => e.CuAccountType)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CU_AccountType");

                entity.Property(e => e.CuFromdate)
                    .HasColumnType("datetime")
                    .HasColumnName("CU_FROMDATE");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.CuTodate)
                    .HasColumnType("datetime")
                    .HasColumnName("CU_TODATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.WinLoginid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WIN_LOGINID");
            });

            modelBuilder.Entity<ExIpcustomerBgc>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.PeLogn, e.BgcinitiateDate });

                entity.ToTable("EX_IPCUSTOMER_BGC");

                entity.Property(e => e.CuIden).HasColumnName("cu_iden");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .HasColumnName("pe_logn");

                entity.Property(e => e.BgcinitiateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("BGCInitiateDate");

                entity.Property(e => e.BgcclosureDate)
                    .HasColumnType("datetime")
                    .HasColumnName("BGCClosureDate");

                entity.Property(e => e.Bgccomments).HasColumnName("BGCComments");

                entity.Property(e => e.Bgcstatus)
                    .HasMaxLength(100)
                    .HasColumnName("BGCStatus");

                entity.Property(e => e.BgcvendorId).HasColumnName("BGCVendorID");

                entity.Property(e => e.DrugTestDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.IdbcompletionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDBCompletionDate");

                entity.Property(e => e.IdccheckDate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDCCheckDate");

                entity.Property(e => e.NdasignDate)
                    .HasColumnType("datetime")
                    .HasColumnName("NDASignDate");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIpcustomerBilling>(entity =>
            {
                entity.HasKey(e => new { e.PeLogn, e.CuIden, e.KickOff, e.BillStartdt, e.Entrystamp });

                entity.ToTable("EX_IPCUSTOMER_BILLING");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.BillStartdt)
                    .HasColumnType("datetime")
                    .HasColumnName("BILL_STARTDT");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.BillEnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("BILL_ENDDATE");

                entity.Property(e => e.BillcatId).HasColumnName("BILLCAT_ID");

                entity.Property(e => e.BillingRate)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("BILLING_RATE");

                entity.Property(e => e.BillingRole)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("BILLING_ROLE");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.Group)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.Jobrefno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JOBREFNO");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpcustomerBusinessProcessMaster>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.BpId });

                entity.ToTable("EX_IPCustomer_BusinessProcess_Master");

                entity.Property(e => e.CuIden).HasColumnName("Cu_Iden");

                entity.Property(e => e.BpId).HasColumnName("BP_ID");

                entity.Property(e => e.BpDesc)
                    .HasMaxLength(2000)
                    .HasColumnName("BP_Desc");

                entity.Property(e => e.BpName)
                    .HasMaxLength(2000)
                    .HasColumnName("BP_Name");

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(1);

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExIpcustomerCancellation>(entity =>
            {
                entity.HasKey(e => new { e.Sl, e.CuIden });

                entity.ToTable("EX_IPCUSTOMER_CANCELLATION");

                entity.Property(e => e.Sl)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("SL");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.AcmngrLogn)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("ACMNGR_LOGN");

                entity.Property(e => e.Approvedby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APPROVEDBY");

                entity.Property(e => e.Approvedon)
                    .HasColumnType("datetime")
                    .HasColumnName("APPROVEDON");

                entity.Property(e => e.BillingEnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("BILLING_ENDDATE");

                entity.Property(e => e.CancellationType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CANCELLATION_TYPE");

                entity.Property(e => e.CancelledDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CANCELLED_DATE");

                entity.Property(e => e.CdhCancelreason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CDH_CANCELREASON");

                entity.Property(e => e.CdhDetailreason)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("CDH_DETAILREASON");

                entity.Property(e => e.CdhEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("CDH_ENTRYSTAMP");

                entity.Property(e => e.CdhHindsight)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("CDH_HINDSIGHT");

                entity.Property(e => e.CdhOffbrdreason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CDH_OFFBRDREASON");

                entity.Property(e => e.CdhStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CDH_STATUS");

                entity.Property(e => e.CdhUserlogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CDH_USERLOGN");

                entity.Property(e => e.CheadLogn)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("CHEAD_LOGN");

                entity.Property(e => e.Comments)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.CuCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CU_CODE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Grp)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GRP");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.MngrLogn)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("MNGR_LOGN");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.SentBy)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SENT_BY");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpcustomerContact>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPCUSTOMER_CONTACT");

                entity.Property(e => e.Address).HasColumnName("ADDRESS");

                entity.Property(e => e.Contactfor)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTACTFOR");

                entity.Property(e => e.Contactname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTACTNAME");

                entity.Property(e => e.Contactnumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTACTNUMBER");

                entity.Property(e => e.CuCode)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("CU_CODE");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Email)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAIL");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Location)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOCATION");

                entity.Property(e => e.Responsibility)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RESPONSIBILITY");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");

                entity.Property(e => e.Winlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WINLOGNID");
            });

            modelBuilder.Entity<ExIpcustomerConversion>(entity =>
            {
                entity.HasKey(e => new { e.Sl, e.PeLogn, e.CuIden, e.KickOff, e.Entrystamp });

                entity.ToTable("EX_IPCUSTOMER_CONVERSION");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.BillEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("BILL_END");

                entity.Property(e => e.BillStart)
                    .HasColumnType("datetime")
                    .HasColumnName("BILL_START");

                entity.Property(e => e.CurrentReason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CURRENT_REASON");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.FinComments)
                    .IsUnicode(false)
                    .HasColumnName("FIN_COMMENTS");

                entity.Property(e => e.FinEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("FIN_ENTRYSTAMP");

                entity.Property(e => e.FinStatus)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("FIN_STATUS");

                entity.Property(e => e.FinUsrlogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FIN_USRLOGN");

                entity.Property(e => e.Group)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REASON");

                entity.Property(e => e.RepLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REP_LOGN");

                entity.Property(e => e.Role)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpcustomerConvertFromCat5>(entity =>
            {
                entity.HasKey(e => new { e.Sl, e.PeLogn, e.CuIden, e.KickOff, e.Entrystamp });

                entity.ToTable("EX_IPCUSTOMER_CONVERT_FROM_CAT5");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.BillEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("BILL_END");

                entity.Property(e => e.FinComments)
                    .IsUnicode(false)
                    .HasColumnName("FIN_COMMENTS");

                entity.Property(e => e.FinEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("FIN_ENTRYSTAMP");

                entity.Property(e => e.FinStatus)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("FIN_STATUS");

                entity.Property(e => e.FinUsrlogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("FIN_USRLOGN");

                entity.Property(e => e.Group)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REASON");

                entity.Property(e => e.RepLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REP_LOGN");

                entity.Property(e => e.Role)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpcustomerEngagement>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.Engagement, e.Startdate });

                entity.ToTable("EX_IPCUSTOMER_Engagement");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Lastupdatedby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATEDBY");

                entity.Property(e => e.Lastupdatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("LASTUPDATEDON");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.UserLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USER_LOGN");
            });

            modelBuilder.Entity<ExIpcustomerEngagementtype>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.EngagementtypeId, e.Clientgroup, e.Entrystamp });

                entity.ToTable("EX_IPCUSTOMER_ENGAGEMENTTYPE");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.EngagementtypeId).HasColumnName("ENGAGEMENTTYPE_ID");

                entity.Property(e => e.Clientgroup)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTGROUP");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.LastupdatedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATED_BY");

                entity.Property(e => e.LastupdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LASTUPDATED_ON");

                entity.Property(e => e.Startdt)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDT");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpcustomerGeo>(entity =>
            {
                entity.HasKey(e => new { e.Sl, e.CuIden, e.PeLogn, e.Group, e.Entrystamp });

                entity.ToTable("EX_IPCUSTOMER_GEO");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Group)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.Geo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("GEO");

                entity.Property(e => e.GeoEnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("GEO_ENDDATE");

                entity.Property(e => e.GeoStartdt)
                    .HasColumnType("datetime")
                    .HasColumnName("GEO_STARTDT");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpcustomerGroup>(entity =>
            {
                entity.HasKey(e => new { e.PeLogn, e.CuIden, e.Group, e.GroupStartdt, e.Entrystamp });

                entity.ToTable("EX_IPCUSTOMER_GROUP");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Group)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.GroupStartdt)
                    .HasColumnType("datetime")
                    .HasColumnName("GROUP_STARTDT");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.GroupEnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("GROUP_ENDDATE");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpcustomerJob>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.Sl, e.Jobrefno });

                entity.ToTable("EX_IPCUSTOMER_JOBS");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Jobrefno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JOBREFNO");

                entity.Property(e => e.AcMngr)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AC_MNGR");

                entity.Property(e => e.Billaddr1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BILLADDR1");

                entity.Property(e => e.Billaddr2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BILLADDR2");

                entity.Property(e => e.Billaddr3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BILLADDR3");

                entity.Property(e => e.Billaddr4)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BILLADDR4");

                entity.Property(e => e.Billaddr5)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BILLADDR5");

                entity.Property(e => e.Billcurrency)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BILLCURRENCY");

                entity.Property(e => e.Billfrequency)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BILLFREQUENCY");

                entity.Property(e => e.Billpersonname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BILLPERSONNAME");

                entity.Property(e => e.Billto)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BILLTO");

                entity.Property(e => e.Cityid).HasColumnName("CITYID");

                entity.Property(e => e.Clientgeo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTGEO");

                entity.Property(e => e.Clientgroup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTGROUP");

                entity.Property(e => e.Comments)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.Contactname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CONTACTNAME");

                entity.Property(e => e.Contractrefno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CONTRACTREFNO");

                entity.Property(e => e.CuCode)
                    .IsRequired()
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("CU_CODE");

                entity.Property(e => e.Emailcc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EMAILCC");

                entity.Property(e => e.Enddt)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDT");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Modeofbill)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MODEOFBILL");

                entity.Property(e => e.Presentationcurrency)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PRESENTATIONCURRENCY");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Startdt)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDT");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ExIpcustomerLocation>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.Sl, e.Clientgeo });

                entity.ToTable("EX_IPCUSTOMER_LOCATION");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Clientgeo)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTGEO");

                entity.Property(e => e.Clientgroup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTGROUP");

                entity.Property(e => e.Clienttype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTTYPE");

                entity.Property(e => e.CuCode)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("CU_CODE");

                entity.Property(e => e.Enddt)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDT");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.LastupdatedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATED_BY");

                entity.Property(e => e.LastupdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LASTUPDATED_ON");

                entity.Property(e => e.Mailstatus)
                    .HasColumnName("MAILSTATUS")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Startdt)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDT");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpcustomerLocationNew>(entity =>
            {
                entity.ToTable("EX_IPCUSTOMER_LOCATION_New");

                entity.HasIndex(e => new { e.CuIden, e.Sl, e.Clientgeo }, "uq_EX_IPCUSTOMER_LOCATION_New")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Clientgeo)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTGEO");

                entity.Property(e => e.Clientgroup)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTGROUP");

                entity.Property(e => e.Clienttype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTTYPE");

                entity.Property(e => e.CuCode)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("CU_CODE");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Enddt)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDT");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.LastupdatedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATED_BY");

                entity.Property(e => e.LastupdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LASTUPDATED_ON");

                entity.Property(e => e.Mailstatus).HasColumnName("MAILSTATUS");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Startdt)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDT");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpcustomerOther>(entity =>
            {
                entity.HasKey(e => new { e.Sl, e.CuIden, e.PeLogn, e.Role, e.Startdt });

                entity.ToTable("EX_IPCUSTOMER_OTHER");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Role)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Startdt)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDT");

                entity.Property(e => e.Clientgeo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTGEO");

                entity.Property(e => e.Clientgroup)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTGROUP");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Geo).HasColumnName("GEO");

                entity.Property(e => e.LastupdatedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATED_BY");

                entity.Property(e => e.LastupdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LASTUPDATED_ON");

                entity.Property(e => e.Mailstatus).HasColumnName("MAILSTATUS");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpcustomerOtherNew>(entity =>
            {
                entity.ToTable("EX_IPCUSTOMER_OTHER_New");

                entity.HasIndex(e => new { e.Sl, e.CuIden, e.PeLogn, e.Role, e.Startdt }, "uq_EX_IPCUSTOMER_OTHER_New")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.Clientgeo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTGEO");

                entity.Property(e => e.Clientgroup)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTGROUP");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Geo).HasColumnName("GEO");

                entity.Property(e => e.LastupdatedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATED_BY");

                entity.Property(e => e.LastupdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LASTUPDATED_ON");

                entity.Property(e => e.Mailstatus).HasColumnName("MAILSTATUS");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Role)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Startdt)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDT");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpcustomerProject>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPCUSTOMER_PROJECT");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Group)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.ProjId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("PROJ_ID");

                entity.Property(e => e.ProjName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PROJ_NAME");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Startdt)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDT");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpcustomerReason>(entity =>
            {
                entity.HasKey(e => new { e.PeLogn, e.CuIden, e.KickOff, e.Reason, e.EffectiveFrom, e.Entrystamp });

                entity.ToTable("EX_IPCUSTOMER_REASON");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REASON");

                entity.Property(e => e.EffectiveFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("EFFECTIVE_FROM");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Comments)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.EffectiveTo)
                    .HasColumnType("datetime")
                    .HasColumnName("EFFECTIVE_TO");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Replacewith)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REPLACEWITH");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpcustomerRole>(entity =>
            {
                entity.HasKey(e => new { e.PeLogn, e.CuIden, e.Role, e.RoleStartdt, e.Entrystamp });

                entity.ToTable("EX_IPCUSTOMER_ROLE");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Role)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.RoleStartdt)
                    .HasColumnType("datetime")
                    .HasColumnName("ROLE_STARTDT");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.ConfirmedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmedDate).HasColumnType("datetime");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.RoleEnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ROLE_ENDDATE");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpcustomerService>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.MainService, e.Startdate })
                    .HasName("PK_Ex_iPCustomer_Services");

                entity.ToTable("EX_IPCUSTOMER_SERVICES");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.MainService).HasColumnName("MAIN_SERVICE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Group)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.Lastupdatedby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATEDBY");

                entity.Property(e => e.Lastupdatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("LASTUPDATEDON");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.SubService).HasColumnName("SUB_SERVICE");

                entity.Property(e => e.UserLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USER_LOGN");
            });

            modelBuilder.Entity<ExIpcustomerServicesNew>(entity =>
            {
                entity.ToTable("EX_IPCUSTOMER_SERVICES_New");

                entity.HasIndex(e => new { e.CuIden, e.MainService, e.Startdate }, "uq_EX_IPCUSTOMER_SERVICES_New")
                    .IsUnique();

                entity.Property(e => e.Id)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Group)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.Lastupdatedby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATEDBY");

                entity.Property(e => e.Lastupdatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("LASTUPDATEDON");

                entity.Property(e => e.MainService).HasColumnName("MAIN_SERVICE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.SubService).HasColumnName("SUB_SERVICE");

                entity.Property(e => e.UserLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USER_LOGN");
            });

            modelBuilder.Entity<ExIpcustomerSopDoc>(entity =>
            {
                entity.HasKey(e => new { e.ClientCode, e.ClientGroup, e.Sl, e.UploadedEntryStamp })
                    .HasName("PK_EX_IPCUSTOMER_SOP_DOCS_1");

                entity.ToTable("EX_IPCUSTOMER_SOP_DOCS");

                entity.Property(e => e.ClientCode)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientGroup)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UploadedEntryStamp).HasColumnType("datetime");

                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedEntryStamp).HasColumnType("datetime");

                entity.Property(e => e.ApprovedStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Dm)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DM");

                entity.Property(e => e.DocumentName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentTitle)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Keywords)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Status)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Uploadedby)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExIpcustomerSow>(entity =>
            {
                entity.HasKey(e => new { e.Sl, e.CuIden, e.PeLogn, e.Sow, e.Entrystamp });

                entity.ToTable("EX_IPCUSTOMER_SOW");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Sow)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SOW");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Blackout).HasColumnName("BLACKOUT");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.SowEnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("SOW_ENDDATE");

                entity.Property(e => e.SowStartdt)
                    .HasColumnType("datetime")
                    .HasColumnName("SOW_STARTDT");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Usageclauseid).HasColumnName("USAGECLAUSEID");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpcustomerTeam>(entity =>
            {
                entity.HasKey(e => new { e.Sl, e.CuIden, e.PeLogn, e.Entrystamp });

                entity.ToTable("Ex_IPCUSTOMER_TEAM");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.EnddateEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_ENTRYSTAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpcustomerUnbilledReason>(entity =>
            {
                entity.HasKey(e => new { e.PeLogn, e.SubreasonSl, e.Startdate, e.Entrystamp });

                entity.ToTable("EX_IPCUSTOMER_UNBILLED_REASON");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.SubreasonSl).HasColumnName("SUBREASON_SL");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.ClientNameReason).HasColumnName("CLIENT_NAME_REASON");

                entity.Property(e => e.Comments).HasColumnName("COMMENTS");

                entity.Property(e => e.DateOfAllocReserv).HasColumnName("DATE_OF_ALLOC_RESERV");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(50)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.ExpBillStartdt).HasColumnName("EXP_BILL_STARTDT");

                entity.Property(e => e.IsDealSigned).HasColumnName("IS_DEAL_SIGNED");

                entity.Property(e => e.NofUnderDelLead).HasColumnName("NOF_UNDER_DEL_LEAD");

                entity.Property(e => e.Skillset).HasColumnName("SKILLSET");

                entity.Property(e => e.Status)
                    .HasMaxLength(5)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(30)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIppersonModuleMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_Module_Master");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ModuleDescription).HasMaxLength(1000);

                entity.Property(e => e.ModuleName).HasMaxLength(100);

                entity.Property(e => e.Screens).HasMaxLength(1000);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLogn).HasMaxLength(20);
            });

            modelBuilder.Entity<ExIppersonReplaceClient>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPerson_ReplaceClient");

                entity.Property(e => e.ApproveComments).HasColumnName("Approve_Comments");

                entity.Property(e => e.ApproveEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("Approve_Entrystamp");

                entity.Property(e => e.ApproveStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Approve_Status")
                    .IsFixedLength();

                entity.Property(e => e.ApproveUserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("Approve_UserLognID");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ReplaceOnDate).HasColumnType("datetime");

                entity.Property(e => e.ReplaceWithCuIden).HasColumnName("ReplaceWith_cu_iden");

                entity.Property(e => e.ReplaceWithPeLogn)
                    .HasMaxLength(20)
                    .HasColumnName("ReplaceWith_pe_logn");

                entity.Property(e => e.ReplacingCuIden).HasColumnName("Replacing_cu_iden");

                entity.Property(e => e.ReplacingKickOffDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Replacing_kick_off_date");

                entity.Property(e => e.ReplacingPeLogn)
                    .HasMaxLength(20)
                    .HasColumnName("Replacing_pe_logn");

                entity.Property(e => e.ReplacingWithKickOffDate)
                    .HasColumnType("datetime")
                    .HasColumnName("ReplacingWith_kick_off_date");

                entity.Property(e => e.TranType).HasMaxLength(50);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonRoleMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_ROLE_Master");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.RoleDescription).HasMaxLength(1000);

                entity.Property(e => e.RoleName).HasMaxLength(100);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLogn).HasMaxLength(20);
            });

            modelBuilder.Entity<ExIppersonRoleModuleMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_ROLE_Module_Mapping");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.RoleId).HasColumnName("RoleID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLogn).HasMaxLength(20);
            });

            modelBuilder.Entity<ExIpproject>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPProject");

                entity.Property(e => e.ApprovedBy).HasMaxLength(100);

                entity.Property(e => e.ApprovedOn).HasColumnType("datetime");

                entity.Property(e => e.CategoryId).HasColumnName("category_id");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .HasColumnName("createdby");

                entity.Property(e => e.Createdon)
                    .HasColumnType("datetime")
                    .HasColumnName("createdon");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Department).HasMaxLength(100);

                entity.Property(e => e.IsBudgeted)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.PartnerId).HasColumnName("Partner_id");

                entity.Property(e => e.PlanFinishDate).HasColumnType("datetime");

                entity.Property(e => e.PlanStartDate).HasColumnType("datetime");

                entity.Property(e => e.PmoplanFinishDate)
                    .HasColumnType("datetime")
                    .HasColumnName("PMOPlanFinishDate");

                entity.Property(e => e.PmoplanStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("PMOPlanStartDate");

                entity.Property(e => e.Pmopriority)
                    .HasMaxLength(100)
                    .HasColumnName("PMOPriority");

                entity.Property(e => e.PrIden).HasColumnName("PR_IDEN");

                entity.Property(e => e.Priority).HasMaxLength(100);

                entity.Property(e => e.ProjectManager).HasMaxLength(100);

                entity.Property(e => e.ProjectSponsor).HasMaxLength(100);

                entity.Property(e => e.ResourceCost).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.ThemeId).HasColumnName("theme_id");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(100)
                    .HasColumnName("updatedby");

                entity.Property(e => e.Updatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedon");
            });

            modelBuilder.Entity<ExIpprojectBillpercent>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPROJECT_BILLPERCENT");

                entity.Property(e => e.Billpercent)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("BILLPERCENT");

                entity.Property(e => e.BillpercentEnddt)
                    .HasColumnType("datetime")
                    .HasColumnName("BILLPERCENT_ENDDT");

                entity.Property(e => e.BillpercentStartdt)
                    .HasColumnType("datetime")
                    .HasColumnName("BILLPERCENT_STARTDT");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.FinComments)
                    .IsUnicode(false)
                    .HasColumnName("FIN_COMMENTS");

                entity.Property(e => e.FinEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("FIN_ENTRYSTAMP");

                entity.Property(e => e.FinLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIN_LOGN");

                entity.Property(e => e.FinStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FIN_STATUS");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.UpdateEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_ENTRYSTAMP");

                entity.Property(e => e.UpdateUserlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_USERLOGNID");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpprojectReason>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPROJECT_REASON");

                entity.Property(e => e.Comments)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.EffectiveFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("EFFECTIVE_FROM");

                entity.Property(e => e.EffectiveTo)
                    .HasColumnType("datetime")
                    .HasColumnName("EFFECTIVE_TO");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REASON");

                entity.Property(e => e.Replacewith)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REPLACEWITH");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpprojectRole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPROJECT_ROLE");

                entity.Property(e => e.ConfirmedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmedDate).HasColumnType("datetime");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Role)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.RoleEnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ROLE_ENDDATE");

                entity.Property(e => e.RoleStartdt)
                    .HasColumnType("datetime")
                    .HasColumnName("ROLE_STARTDT");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpprojectTeamAllocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_IPProject_Team_Allocation");

                entity.Property(e => e.AllocPercentage)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("Alloc_Percentage");

                entity.Property(e => e.AllocSlno).HasColumnName("Alloc_Slno");

                entity.Property(e => e.CreatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.CreatedTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("createdTimestamp");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pe_logn");

                entity.Property(e => e.ProjEnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("proj_enddate");

                entity.Property(e => e.ProjId).HasColumnName("Proj_ID");

                entity.Property(e => e.ProjStartdate)
                    .HasColumnType("datetime")
                    .HasColumnName("proj_startdate");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("updatedby");

                entity.Property(e => e.Updatedtimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedtimestamp");
            });

            modelBuilder.Entity<ExIprolecoreskill>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_IPROLECORESKILLS");

                entity.Property(e => e.CaCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CA_Code");

                entity.Property(e => e.CaValu)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CA_VALU");

                entity.Property(e => e.ClientGroup)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("client_group");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.ElCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EL_Code");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Rating)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RATING");

                entity.Property(e => e.RatingFromdt)
                    .HasColumnType("datetime")
                    .HasColumnName("RATING_FROMDT");

                entity.Property(e => e.RatingTodate)
                    .HasColumnType("datetime")
                    .HasColumnName("RATING_TODATE");

                entity.Property(e => e.RoleCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ROLE_CODE");

                entity.Property(e => e.Skilltype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SKILLTYPE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExLastClientUnLock>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_LastClient_UnLock");

                entity.Property(e => e.AdminComments)
                    .IsUnicode(false)
                    .HasColumnName("Admin_Comments");

                entity.Property(e => e.AdminEntryStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("Admin_EntryStamp");

                entity.Property(e => e.AdminLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Admin_LognID");

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.CuIden).HasColumnName("Cu_Iden");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasComment("P=Pending to open month;O=Open for the month;C=Closed");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExModuleAccessLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_ModuleAccess_Logs");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .HasColumnName("Pe_Logn");
            });

            modelBuilder.Entity<ExModuleMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_ModuleMaster");

                entity.Property(e => e.ApplicationId).HasColumnName("ApplicationID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.ModuleName).HasMaxLength(500);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("status");

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExModulePeLognAccess>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_Module_PeLogn_Access");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasMaxLength(50);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExNewclientrequest>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_NEWCLIENTREQUEST");

                entity.Property(e => e.Acmngr)
                    .IsUnicode(false)
                    .HasColumnName("ACMngr");

                entity.Property(e => e.Chead)
                    .IsUnicode(false)
                    .HasColumnName("CHead");

                entity.Property(e => e.ClientAnalyCountryRegion).IsUnicode(false);

                entity.Property(e => e.ClientStDt).HasColumnType("datetime");

                entity.Property(e => e.ClientType).IsUnicode(false);

                entity.Property(e => e.CuCode)
                    .IsUnicode(false)
                    .HasColumnName("Cu_Code");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Group).IsUnicode(false);

                entity.Property(e => e.LegalName).IsUnicode(false);

                entity.Property(e => e.MainEquitServ).IsUnicode(false);

                entity.Property(e => e.QntsServ).IsUnicode(false);

                entity.Property(e => e.ServiceType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ServicesId)
                    .IsUnicode(false)
                    .HasColumnName("ServicesID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.SubEquitServ).IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExOffboardReasonMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_OffboardReason_Master");

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastUpdatedBy).HasMaxLength(20);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.ShortDescription).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExOffboardsDocumentation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_OFFBOARDS_DOCUMENTATION");

                entity.Property(e => e.CkmsDb)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CKMS_DB");

                entity.Property(e => e.Clearance)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("clearance");

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.CuIden).HasColumnName("cu_iden");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("entrystamp");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LeaveProcessed)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Leave_processed");

                entity.Property(e => e.LeaveYettoapprove)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Leave_yettoapprove");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pe_logn");

                entity.Property(e => e.Sl).HasColumnName("sl");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength();

                entity.Property(e => e.Timesheet)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExPeerqcdataMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_PEERQCDATA_MASTER");

                entity.Property(e => e.AnalystLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Analyst_Logn");

                entity.Property(e => e.AsgSl).HasColumnName("Asg_SL");

                entity.Property(e => e.Assignment).IsUnicode(false);

                entity.Property(e => e.Category).IsUnicode(false);

                entity.Property(e => e.ClosedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ClosedOn).HasColumnType("datetime");

                entity.Property(e => e.CuCode)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Cu_Code");

                entity.Property(e => e.CuIden).HasColumnName("Cu_Iden");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Grade10Rating).HasColumnName("Grade10_Rating");

                entity.Property(e => e.Grade1Rating).HasColumnName("Grade1_Rating");

                entity.Property(e => e.Grade2Rating).HasColumnName("Grade2_Rating");

                entity.Property(e => e.Grade3Rating).HasColumnName("Grade3_Rating");

                entity.Property(e => e.Grade4Rating).HasColumnName("Grade4_Rating");

                entity.Property(e => e.Grade5Rating).HasColumnName("Grade5_Rating");

                entity.Property(e => e.Grade6Rating).HasColumnName("Grade6_Rating");

                entity.Property(e => e.Grade7Rating).HasColumnName("Grade7_Rating");

                entity.Property(e => e.Grade8Rating).HasColumnName("Grade8_Rating");

                entity.Property(e => e.Grade9Rating).HasColumnName("Grade9_Rating");

                entity.Property(e => e.Issues1).IsUnicode(false);

                entity.Property(e => e.Issues10).IsUnicode(false);

                entity.Property(e => e.Issues2).IsUnicode(false);

                entity.Property(e => e.Issues3).IsUnicode(false);

                entity.Property(e => e.Issues4).IsUnicode(false);

                entity.Property(e => e.Issues5).IsUnicode(false);

                entity.Property(e => e.Issues6).IsUnicode(false);

                entity.Property(e => e.Issues7).IsUnicode(false);

                entity.Property(e => e.Issues8).IsUnicode(false);

                entity.Property(e => e.Issues9).IsUnicode(false);

                entity.Property(e => e.PeerOrVp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PeerOrVP")
                    .IsFixedLength();

                entity.Property(e => e.PostingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("POSTING_Date");

                entity.Property(e => e.Qcdate)
                    .HasColumnType("datetime")
                    .HasColumnName("QCDate");

                entity.Property(e => e.Qcnumber)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("QCNumber")
                    .IsFixedLength();

                entity.Property(e => e.ReopenedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ReopenedOn).HasColumnType("datetime");

                entity.Property(e => e.Score)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("SCORE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Suggestions1).IsUnicode(false);

                entity.Property(e => e.Suggestions10).IsUnicode(false);

                entity.Property(e => e.Suggestions2).IsUnicode(false);

                entity.Property(e => e.Suggestions3).IsUnicode(false);

                entity.Property(e => e.Suggestions4).IsUnicode(false);

                entity.Property(e => e.Suggestions5).IsUnicode(false);

                entity.Property(e => e.Suggestions6).IsUnicode(false);

                entity.Property(e => e.Suggestions7).IsUnicode(false);

                entity.Property(e => e.Suggestions8).IsUnicode(false);

                entity.Property(e => e.Suggestions9).IsUnicode(false);

                entity.Property(e => e.TaskType).IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExPoolMapping>(entity =>
            {
                entity.ToTable("EX_POOL_MAPPING");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExProductMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Product_Master");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.ProductDesc).HasMaxLength(2000);

                entity.Property(e => e.ProductId).HasColumnName("ProductID");

                entity.Property(e => e.ProductName).HasMaxLength(1000);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExProjectAllocationPercentage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_Project_Allocation_percentage");

                entity.Property(e => e.AllocationPercentage).HasColumnName("Allocation_percentage");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("End_date");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(500)
                    .HasColumnName("Entered_by");

                entity.Property(e => e.EnteredOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Entered_On");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("Kick_Off");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(500)
                    .HasColumnName("pe_logn");

                entity.Property(e => e.PrIden).HasColumnName("pr_Iden");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_date");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(500)
                    .HasColumnName("Updated_By");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Updated_On");
            });

            modelBuilder.Entity<ExQueryBuilderColumn>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_QueryBuilder_Column");

                entity.Property(e => e.ColumnDatatype).HasMaxLength(100);

                entity.Property(e => e.ReportColumn).HasMaxLength(100);

                entity.Property(e => e.Sqlcolumn)
                    .HasMaxLength(100)
                    .HasColumnName("SQLColumn");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ExQueryBuilderSaveQuery>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_QueryBuilder_Save_Queries");

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasMaxLength(20);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Title).HasMaxLength(500);
            });

            modelBuilder.Entity<ExReplacementReasonMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_ReplacementReason_Master");

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.LastUpdatedBy).HasMaxLength(20);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.ShortDescription).HasMaxLength(100);

                entity.Property(e => e.StartDate).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExResourceAssignmentSendBack>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_ResourceAssignment_SendBack");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.ReSubmitBy).HasMaxLength(20);

                entity.Property(e => e.ReSubmitOn).HasColumnType("datetime");

                entity.Property(e => e.SendBackBy).HasMaxLength(20);

                entity.Property(e => e.SendBackOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.TranId).HasColumnName("TranID");
            });

            modelBuilder.Entity<ExResourceOmc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Resource_OMC");

                entity.Property(e => e.CalledDate).HasColumnType("datetime");

                entity.Property(e => e.ClientAnalystName)
                    .IsUnicode(false)
                    .HasColumnName("Client_AnalystName");

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.CuIden).HasColumnName("Cu_Iden");

                entity.Property(e => e.DueCallDt).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.KickOffDt).HasColumnType("datetime");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.ScheduledDate).HasColumnType("datetime");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserDesg)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExResourceOmcp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Resource_OMCP");

                entity.Property(e => e.ClientAnalystName)
                    .IsUnicode(false)
                    .HasColumnName("Client_AnalystName");

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.CuIden).HasColumnName("Cu_Iden");

                entity.Property(e => e.DueCallDt).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.KickOffDt).HasColumnType("datetime");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.PostPonedDate).HasColumnType("datetime");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserDesg)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExResourceOthassignment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_ResourceOTHAssignment");

                entity.Property(e => e.Assigndate)
                    .HasColumnType("datetime")
                    .HasColumnName("ASSIGNDATE");

                entity.Property(e => e.Assignto)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ASSIGNTO")
                    .IsFixedLength();

                entity.Property(e => e.Comments)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourcePhaseHour>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Resource_Phase_Hours");

                entity.Property(e => e.CuIden).HasColumnName("cu_iden");

                entity.Property(e => e.Hrs).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.Percnt).HasColumnType("decimal(10, 0)");

                entity.Property(e => e.Phase)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.Shrs)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("SHrs");
            });

            modelBuilder.Entity<ExResourceProjectsStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_ResourceProjectsStatus");

                entity.Property(e => e.CuIden).HasColumnName("cu_iden");

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Pe_logn");

                entity.Property(e => e.PrEnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("Pr_enddate");

                entity.Property(e => e.PrIden).HasColumnName("Pr_iden");

                entity.Property(e => e.PrStartdate)
                    .HasColumnType("datetime")
                    .HasColumnName("Pr_startdate");

                entity.Property(e => e.PrStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Pr_status");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ExResourceTentativeLongLeave>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCE_TENTATIVE_LONG_LEAVE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.LeaveEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LEAVE_END_DATE");

                entity.Property(e => e.LeaveStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LEAVE_START_DATE");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(20)
                    .HasColumnName("UPDATEDBY");

                entity.Property(e => e.Updatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATEDON");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(20)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourceallocation>(entity =>
            {
                entity.HasKey(e => new { e.PeLogn, e.CuIden, e.AllocStartdt, e.Entrystamp });

                entity.ToTable("EX_RESOURCEALLOCATION");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.AllocStartdt)
                    .HasColumnType("datetime")
                    .HasColumnName("ALLOC_STARTDT");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.AllocEnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ALLOC_ENDDATE");

                entity.Property(e => e.Allocation)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("ALLOCATION");

                entity.Property(e => e.CheadComments)
                    .IsUnicode(false)
                    .HasColumnName("CHEAD_COMMENTS");

                entity.Property(e => e.CheadEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("CHEAD_ENTRYSTAMP");

                entity.Property(e => e.CheadLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CHEAD_LOGN");

                entity.Property(e => e.CheadStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHEAD_STATUS");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.PostStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("POST_STATUS")
                    .IsFixedLength();

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.UpdateEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_ENTRYSTAMP");

                entity.Property(e => e.UpdateUserlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_USERLOGNID");

                entity.Property(e => e.UpdatedEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_ENTRYSTAMP");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourceallocationLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCEALLOCATION_LOG");

                entity.Property(e => e.AllocEnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ALLOC_ENDDATE");

                entity.Property(e => e.AllocStartdt)
                    .HasColumnType("datetime")
                    .HasColumnName("ALLOC_STARTDT");

                entity.Property(e => e.Allocation)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("ALLOCATION");

                entity.Property(e => e.CheadComments)
                    .IsUnicode(false)
                    .HasColumnName("CHEAD_COMMENTS");

                entity.Property(e => e.CheadEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("CHEAD_ENTRYSTAMP");

                entity.Property(e => e.CheadLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CHEAD_LOGN");

                entity.Property(e => e.CheadStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CHEAD_STATUS");

                entity.Property(e => e.Comments)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.LogEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("LOG_ENTRYSTAMP");

                entity.Property(e => e.LogUserlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LOG_USERLOGNID");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.PostStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("POST_STATUS")
                    .IsFixedLength();

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.UpdateEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_ENTRYSTAMP");

                entity.Property(e => e.UpdateUserlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_USERLOGNID");

                entity.Property(e => e.UpdatedEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_ENTRYSTAMP");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourceassignment>(entity =>
            {
                entity.ToTable("EX_RESOURCEASSIGNMENT");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AdminComment)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("ADMIN_COMMENT");

                entity.Property(e => e.AdminCommentsOnapprove)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("ADMIN_COMMENTS_ONAPPROVE");

                entity.Property(e => e.AdminStatusEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ADMIN_STATUS_ENTRYSTAMP");

                entity.Property(e => e.AdminStatusLognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ADMIN_STATUS_LOGNID");

                entity.Property(e => e.AdminStatusOnapprove)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ADMIN_STATUS_ONAPPROVE");

                entity.Property(e => e.Allocation)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("ALLOCATION");

                entity.Property(e => e.ApproveStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("APPROVE_STATUS")
                    .IsFixedLength()
                    .HasComment("To Save the Approve Status P=Pending,A=Approved,R=Rejected");

                entity.Property(e => e.AssignType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ASSIGN_TYPE");

                entity.Property(e => e.BcatId).HasColumnName("BCAT_ID");

                entity.Property(e => e.BillDate)
                    .HasColumnType("datetime")
                    .HasColumnName("BILL_DATE");

                entity.Property(e => e.BillEntity)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BILL_ENTITY");

                entity.Property(e => e.BillFrequency)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BILL_FREQUENCY");

                entity.Property(e => e.BillingDetails)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BILLING_DETAILS");

                entity.Property(e => e.BillingRate)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("BILLING_RATE");

                entity.Property(e => e.BillingRole)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BILLING_ROLE");

                entity.Property(e => e.BillingStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BILLING_STATUS");

                entity.Property(e => e.Billpercent)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("BILLPERCENT");

                entity.Property(e => e.Blackout).HasColumnName("BLACKOUT");

                entity.Property(e => e.CheadEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("CHEAD_ENTRYSTAMP");

                entity.Property(e => e.CheadTypeoflead)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CHEAD_TYPEOFLEAD");

                entity.Property(e => e.CheadUpdatedbychead)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CHEAD_UPDATEDBYCHEAD");

                entity.Property(e => e.ComplComment)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("COMPL_COMMENT");

                entity.Property(e => e.ComplianceComments)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("COMPLIANCE_COMMENTS");

                entity.Property(e => e.ComplianceEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("COMPLIANCE_ENTRYSTAMP");

                entity.Property(e => e.ComplianceLognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("COMPLIANCE_LOGNID");

                entity.Property(e => e.ComplianceStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("COMPLIANCE_STATUS");

                entity.Property(e => e.ConversionCheadApprovalStatus)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CONVERSION_CHEAD_APPROVAL_STATUS");

                entity.Property(e => e.ConversionCheadComment)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("CONVERSION_CHEAD_COMMENT");

                entity.Property(e => e.ConversionCheadEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("CONVERSION_CHEAD_ENTRYSTAMP");

                entity.Property(e => e.ConversionCheadLoginid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CONVERSION_CHEAD_LOGINID");

                entity.Property(e => e.ConversionComment)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("CONVERSION_COMMENT");

                entity.Property(e => e.ConversionComplComments)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("CONVERSION_COMPL_COMMENTS");

                entity.Property(e => e.ConversionComplEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("CONVERSION_COMPL_ENTRYSTAMP");

                entity.Property(e => e.ConversionComplLognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CONVERSION_COMPL_LOGNID");

                entity.Property(e => e.ConversionComplStatus)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CONVERSION_COMPL_STATUS");

                entity.Property(e => e.ConversionEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("CONVERSION_ENTRYSTAMP");

                entity.Property(e => e.ConversionUserlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CONVERSION_USERLOGNID");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.CuType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CU_TYPE");

                entity.Property(e => e.DateOfSelectionOrMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_SELECTION_OR_MOVE");

                entity.Property(e => e.DeliveryLed)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("DELIVERY_LED");

                entity.Property(e => e.DmKickOffDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DM_KICK_OFF_DATE");

                entity.Property(e => e.Documentation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DOCUMENTATION")
                    .IsFixedLength();

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.FinanceComments)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("FINANCE_COMMENTS");

                entity.Property(e => e.FinanceEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("FINANCE_ENTRYSTAMP");

                entity.Property(e => e.FinanceLognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FINANCE_LOGNID");

                entity.Property(e => e.FinanceStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FINANCE_STATUS");

                entity.Property(e => e.Groups)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GROUPS");

                entity.Property(e => e.HrRdAccFinComment)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("HR_RD_ACC_FIN_COMMENT");

                entity.Property(e => e.InvoiceNo)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("INVOICE_NO");

                entity.Property(e => e.IpLocn)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("IP_LOCN");

                entity.Property(e => e.ItComment)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("IT_COMMENT");

                entity.Property(e => e.ItCommentsOnapprove)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("IT_COMMENTS_ONAPPROVE");

                entity.Property(e => e.ItStatusEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("IT_STATUS_ENTRYSTAMP");

                entity.Property(e => e.ItStatusLognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("IT_STATUS_LOGNID");

                entity.Property(e => e.ItStatusOnapprove)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IT_STATUS_ONAPPROVE");

                entity.Property(e => e.Jobrefno)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("JOBREFNO");

                entity.Property(e => e.KickOffDate)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF_DATE");

                entity.Property(e => e.LockId).HasColumnName("Lock_ID");

                entity.Property(e => e.LockPeriod)
                    .HasColumnType("datetime")
                    .HasColumnName("Lock_Period");

                entity.Property(e => e.LockStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Lock_Status")
                    .IsFixedLength();

                entity.Property(e => e.LockedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Locked_By");

                entity.Property(e => e.LockedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Locked_On");

                entity.Property(e => e.ManagerComments)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("MANAGER_COMMENTS");

                entity.Property(e => e.ManagerEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("MANAGER_ENTRYSTAMP");

                entity.Property(e => e.ManagerLognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MANAGER_LOGNID");

                entity.Property(e => e.ManagerUpdate)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MANAGER_UPDATE");

                entity.Property(e => e.Ndaconfirm)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NDAConfirm");

                entity.Property(e => e.Ndasigneddate)
                    .HasColumnType("datetime")
                    .HasColumnName("NDASIGNEDDATE");

                entity.Property(e => e.NewDmSupr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NEW_DM_SUPR");

                entity.Property(e => e.NewDmSuprConfirm)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NEW_DM_SUPR_CONFIRM");

                entity.Property(e => e.OffboardComfirmcomments)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("OFFBOARD_COMFIRMCOMMENTS");

                entity.Property(e => e.OffboardComfirmcommentsAdmn)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("OFFBOARD_COMFIRMCOMMENTS_ADMN");

                entity.Property(e => e.OffboardComfirmcommentsIt)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("OFFBOARD_COMFIRMCOMMENTS_IT");

                entity.Property(e => e.OffboardConfirm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OFFBOARD_CONFIRM")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.OffboardConfirmedby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("OFFBOARD_CONFIRMEDBY");

                entity.Property(e => e.OffboardConfirmedon)
                    .HasColumnType("datetime")
                    .HasColumnName("OFFBOARD_CONFIRMEDON");

                entity.Property(e => e.OnOff).HasColumnName("ON_OFF");

                entity.Property(e => e.OnboardComments)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ONBOARD_COMMENTS");

                entity.Property(e => e.OrgnRole)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("ORGN_ROLE");

                entity.Property(e => e.PeLmgr)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PE_LMGR");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.ProjDuration)
                    .HasColumnType("numeric(18, 2)")
                    .HasColumnName("PROJ_DURATION");

                entity.Property(e => e.ProjFrequency)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PROJ_FREQUENCY");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Reason)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REASON");

                entity.Property(e => e.ReasonDetail)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("REASON_DETAIL");

                entity.Property(e => e.RepValognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REP_VALOGNID");

                entity.Property(e => e.ReqId).HasColumnName("REQ_ID");

                entity.Property(e => e.ResgclntComment)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("RESGCLNT_COMMENT");

                entity.Property(e => e.ServiceLed)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("SERVICE_LED");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Sow)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SOW");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Supr)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SUPR");

                entity.Property(e => e.TdaComments)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("TDA_COMMENTS");

                entity.Property(e => e.Usageclauseid).HasColumnName("USAGECLAUSEID");

                entity.Property(e => e.Userapprovestatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("USERAPPROVESTATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");

                entity.Property(e => e.WorkType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("WORK_TYPE");
            });

            modelBuilder.Entity<ExResourceassignmentChecklist>(entity =>
            {
                entity.HasKey(e => e.Slno);

                entity.ToTable("EX_RESOURCEASSIGNMENT_CHECKLIST");

                entity.Property(e => e.Slno).HasColumnName("SLNO");

                entity.Property(e => e.ChecklistId).HasColumnName("CHECKLIST_ID");

                entity.Property(e => e.ChecklistType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CHECKLIST_TYPE");

                entity.Property(e => e.Comments)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.OffId).HasColumnName("OFF_ID");

                entity.Property(e => e.OnOff).HasColumnName("ON_OFF");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("('P')");

                entity.Property(e => e.YesNoInd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("YES_NO_IND");
            });

            modelBuilder.Entity<ExResourceassignmentTran>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCEASSIGNMENT_TRAN");

                entity.Property(e => e.Allocation)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("ALLOCATION");

                entity.Property(e => e.Approvedby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("APPROVEDBY");

                entity.Property(e => e.Approvedon)
                    .HasColumnType("datetime")
                    .HasColumnName("APPROVEDON");

                entity.Property(e => e.ApproverComments)
                    .HasMaxLength(2500)
                    .IsUnicode(false)
                    .HasColumnName("APPROVER_COMMENTS");

                entity.Property(e => e.ChangeType)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CHANGE_TYPE");

                entity.Property(e => e.Comments)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Group)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.Newvalue)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("NEWVALUE");

                entity.Property(e => e.Oldvalue)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("OLDVALUE");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REASON");

                entity.Property(e => e.Role)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Tranid).HasColumnName("TRANID");

                entity.Property(e => e.Userlognid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourceassignmentlog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCEASSIGNMENTLOG");

                entity.Property(e => e.ApproveStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("APPROVE_STATUS")
                    .IsFixedLength();

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.EffectiveFrom)
                    .HasColumnType("datetime")
                    .HasColumnName("EFFECTIVE_FROM");

                entity.Property(e => e.EffectiveTo)
                    .HasColumnType("datetime")
                    .HasColumnName("EFFECTIVE_TO");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Group)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Reason)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REASON");

                entity.Property(e => e.RepValognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("REP_VALOGNID");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourceassignmentstatus>(entity =>
            {
                entity.HasKey(e => new { e.PeLogn, e.CuIden, e.KickOff, e.Startdate, e.Entrystamp });

                entity.ToTable("EX_RESOURCEASSIGNMENTSTATUS");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.ApproveStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("APPROVE_STATUS")
                    .HasComment("To Save the Approve Status P=Pending,A=Approved,R=Rejected");

                entity.Property(e => e.BillEnd)
                    .HasColumnType("datetime")
                    .HasColumnName("BILL_END");

                entity.Property(e => e.BillStart)
                    .HasColumnType("datetime")
                    .HasColumnName("BILL_START");

                entity.Property(e => e.BillpauseEnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("BILLPAUSE_ENDDATE");

                entity.Property(e => e.BillpauseStartdate)
                    .HasColumnType("datetime")
                    .HasColumnName("BILLPAUSE_STARTDATE");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.FinStatus)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("FIN_STATUS");

                entity.Property(e => e.Group)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.OffboardReason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("OFFBOARD_REASON");

                entity.Property(e => e.OffboardStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("OFFBOARD_STAMP");

                entity.Property(e => e.OffboardStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OFFBOARD_STATUS");

                entity.Property(e => e.OffboardUserlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("OFFBOARD_USERLOGNID");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Reason)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("REASON");

                entity.Property(e => e.Role)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.StatusLevelId).HasColumnName("STATUS_LEVEL_ID");

                entity.Property(e => e.Tranid).HasColumnName("TRANID");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourcebillpercent>(entity =>
            {
                entity.HasKey(e => new { e.PeLogn, e.CuIden, e.KickOff, e.BillpercentStartdt, e.Entrystamp });

                entity.ToTable("EX_RESOURCEBILLPERCENT");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.BillpercentStartdt)
                    .HasColumnType("datetime")
                    .HasColumnName("BILLPERCENT_STARTDT");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Billpercent)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("BILLPERCENT");

                entity.Property(e => e.BillpercentEnddt)
                    .HasColumnType("datetime")
                    .HasColumnName("BILLPERCENT_ENDDT");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.FinComments)
                    .IsUnicode(false)
                    .HasColumnName("FIN_COMMENTS");

                entity.Property(e => e.FinEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("FIN_ENTRYSTAMP");

                entity.Property(e => e.FinLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIN_LOGN");

                entity.Property(e => e.FinStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FIN_STATUS");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.UpdateEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_ENTRYSTAMP");

                entity.Property(e => e.UpdateUserlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_USERLOGNID");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourcebillpercentLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCEBILLPERCENT_LOG");

                entity.Property(e => e.Billpercent)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("BILLPERCENT");

                entity.Property(e => e.BillpercentEnddt)
                    .HasColumnType("datetime")
                    .HasColumnName("BILLPERCENT_ENDDT");

                entity.Property(e => e.BillpercentStartdt)
                    .HasColumnType("datetime")
                    .HasColumnName("BILLPERCENT_STARTDT");

                entity.Property(e => e.Comments)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.FinComments)
                    .IsUnicode(false)
                    .HasColumnName("FIN_COMMENTS");

                entity.Property(e => e.FinEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("FIN_ENTRYSTAMP");

                entity.Property(e => e.FinLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FIN_LOGN");

                entity.Property(e => e.FinStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("FIN_STATUS");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.LogEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("LOG_ENTRYSTAMP");

                entity.Property(e => e.LogUserlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LOG_USERLOGNID");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.UpdateEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATE_ENTRYSTAMP");

                entity.Property(e => e.UpdateUserlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UPDATE_USERLOGNID");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourcerequest>(entity =>
            {
                entity.ToTable("EX_RESOURCEREQUEST");

                entity.Property(e => e.Id)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.ActualCount).HasColumnName("ACTUAL_COUNT");

                entity.Property(e => e.Amvp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AMVP");

                entity.Property(e => e.AssignmentType)
                    .HasMaxLength(50)
                    .HasColumnName("ASSIGNMENT_TYPE");

                entity.Property(e => e.ClientStratImp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_STRAT_IMP");

                entity.Property(e => e.Clientanalystsectorname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTANALYSTSECTORNAME");

                entity.Property(e => e.CompletionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("COMPLETION_DATE");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.GroupCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_CODE");

                entity.Property(e => e.IpLocn).HasColumnName("IP_LOCN");

                entity.Property(e => e.Mngrcomments)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("MNGRCOMMENTS");

                entity.Property(e => e.Mngrstatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MNGRSTATUS")
                    .IsFixedLength();

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.ReplacementLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REPLACEMENT_LOGN");

                entity.Property(e => e.ReqId).HasColumnName("REQ_ID");

                entity.Property(e => e.RequestClosingdate)
                    .HasColumnType("datetime")
                    .HasColumnName("REQUEST_CLOSINGDATE");

                entity.Property(e => e.RequestDate)
                    .HasColumnType("datetime")
                    .HasColumnName("REQUEST_DATE");

                entity.Property(e => e.RequestSl)
                    .HasColumnName("REQUEST_SL")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ResourceComments)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("RESOURCE_COMMENTS");

                entity.Property(e => e.ResourceCount)
                    .HasColumnType("numeric(7, 2)")
                    .HasColumnName("RESOURCE_COUNT");

                entity.Property(e => e.ResourceDuration)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("RESOURCE_DURATION");

                entity.Property(e => e.ResourceReason)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("RESOURCE_REASON");

                entity.Property(e => e.ResourceSkillset)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("RESOURCE_SKILLSET");

                entity.Property(e => e.ResourceType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESOURCE_TYPE");

                entity.Property(e => e.Sow)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SOW");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength()
                    .HasComment("P:Pending\r\nC:Closed");

                entity.Property(e => e.Supr)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SUPR");

                entity.Property(e => e.Tdacomments)
                    .HasMaxLength(5000)
                    .IsUnicode(false)
                    .HasColumnName("TDAComments");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_ON");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourcerequestLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCEREQUEST_LOG");

                entity.Property(e => e.ActualCount).HasColumnName("ACTUAL_COUNT");

                entity.Property(e => e.Amvp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AMVP");

                entity.Property(e => e.AssignmentType)
                    .HasMaxLength(50)
                    .HasColumnName("ASSIGNMENT_TYPE");

                entity.Property(e => e.ClientStratImp)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CLIENT_STRAT_IMP");

                entity.Property(e => e.Clientanalystsectorname)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTANALYSTSECTORNAME");

                entity.Property(e => e.CompletionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("COMPLETION_DATE");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.GroupCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GROUP_CODE");

                entity.Property(e => e.Historyentrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("HISTORYENTRYSTAMP");

                entity.Property(e => e.IpLocn).HasColumnName("IP_LOCN");

                entity.Property(e => e.Mngrcomments)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("MNGRCOMMENTS");

                entity.Property(e => e.Mngrstatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MNGRSTATUS")
                    .IsFixedLength();

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.ReplacementLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REPLACEMENT_LOGN");

                entity.Property(e => e.ReqId).HasColumnName("REQ_ID");

                entity.Property(e => e.RequestClosingdate)
                    .HasColumnType("datetime")
                    .HasColumnName("REQUEST_CLOSINGDATE");

                entity.Property(e => e.RequestDate)
                    .HasColumnType("datetime")
                    .HasColumnName("REQUEST_DATE");

                entity.Property(e => e.RequestSl).HasColumnName("REQUEST_SL");

                entity.Property(e => e.ResourceComments)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("RESOURCE_COMMENTS");

                entity.Property(e => e.ResourceCount)
                    .HasColumnType("numeric(7, 2)")
                    .HasColumnName("RESOURCE_COUNT");

                entity.Property(e => e.ResourceDuration)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("RESOURCE_DURATION");

                entity.Property(e => e.ResourceReason)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("RESOURCE_REASON");

                entity.Property(e => e.ResourceSkillset)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("RESOURCE_SKILLSET");

                entity.Property(e => e.ResourceType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RESOURCE_TYPE");

                entity.Property(e => e.Sow)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SOW");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength()
                    .HasComment("P:Pending\r\nC:Closed");

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UPDATED_BY");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_ON");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourcerequestRole>(entity =>
            {
                entity.ToTable("EX_RESOURCEREQUEST_ROLE");

                entity.Property(e => e.Id)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Billpercent)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("BILLPERCENT");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.IpLocn).HasColumnName("IP_LOCN");

                entity.Property(e => e.Noofresource).HasColumnName("NOOFRESOURCE");

                entity.Property(e => e.OtherAllocn)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("OTHER_ALLOCN");

                entity.Property(e => e.Priority)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PRIORITY");

                entity.Property(e => e.Remarks)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("REMARKS");

                entity.Property(e => e.ReqId).HasColumnName("REQ_ID");

                entity.Property(e => e.RequiredDate)
                    .HasColumnType("datetime")
                    .HasColumnName("REQUIRED_DATE");

                entity.Property(e => e.ResourceAllocn)
                    .HasColumnType("decimal(18, 2)")
                    .HasColumnName("RESOURCE_ALLOCN");

                entity.Property(e => e.Rolesl).HasColumnName("ROLESL");

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourcerequestSector>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCEREQUEST_SECTOR");

                entity.Property(e => e.CatId).HasColumnName("CAT_ID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.IndId).HasColumnName("IND_ID");

                entity.Property(e => e.RegionId).HasColumnName("REGION_ID");

                entity.Property(e => e.ReqId).HasColumnName("REQ_ID");

                entity.Property(e => e.Rolesl).HasColumnName("ROLESL");

                entity.Property(e => e.SectorId).HasColumnName("SECTOR_ID");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourcerequestSkill>(entity =>
            {
                entity.ToTable("EX_RESOURCEREQUEST_SKILLS");

                entity.Property(e => e.Id)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.ReqId).HasColumnName("REQ_ID");

                entity.Property(e => e.Rolesl).HasColumnName("ROLESL");

                entity.Property(e => e.Skilllevel)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SKILLLEVEL");

                entity.Property(e => e.Skills)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SKILLS");

                entity.Property(e => e.Skillscode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SKILLSCODE");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourceresume>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_RESOURCERESUMES");

                entity.Property(e => e.EditorialCvFoldername)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("EDITORIAL_CV_FOLDERNAME");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.OriginalCvFoldername)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("ORIGINAL_CV_FOLDERNAME");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourceroleskill>(entity =>
            {
                entity.ToTable("EX_RESOURCEROLESKILL");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Ambarole)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AMBAROLE");

                entity.Property(e => e.CaCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CA_CODE");

                entity.Property(e => e.Comments)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.ConfirmedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmedOn).HasColumnType("datetime");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.ElCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EL_CODE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.EvaluationMethod)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.MgrPelogn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MGR_PELOGN");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Rating)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RATING");

                entity.Property(e => e.RatingFromdt)
                    .HasColumnType("datetime")
                    .HasColumnName("RATING_FROMDT");

                entity.Property(e => e.RatingTodate)
                    .HasColumnType("datetime")
                    .HasColumnName("RATING_TODATE");

                entity.Property(e => e.Skilltype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SKILLTYPE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Tdaconfirm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TDAConfirm");

                entity.Property(e => e.TdaconfirmedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TDAConfirmedBy");

                entity.Property(e => e.TdaconfirmedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("TDAConfirmedOn");

                entity.Property(e => e.Type)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourceroleskillLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCEROLESKILL_LOG");

                entity.Property(e => e.Ambarole)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AMBAROLE");

                entity.Property(e => e.CaCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CA_CODE");

                entity.Property(e => e.Comments)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.ElCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EL_CODE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Logenteredby)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOGENTEREDBY");

                entity.Property(e => e.Logentrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("LOGENTRYSTAMP");

                entity.Property(e => e.MgrPelogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MGR_PELOGN");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Rating)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RATING");

                entity.Property(e => e.RatingFromdt)
                    .HasColumnType("datetime")
                    .HasColumnName("RATING_FROMDT");

                entity.Property(e => e.RatingTodate)
                    .HasColumnType("datetime")
                    .HasColumnName("RATING_TODATE");

                entity.Property(e => e.Skilltype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SKILLTYPE");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Type)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourcerolestatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCEROLESTATUS");

                entity.Property(e => e.ApproveStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("APPROVE_STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Comments)
                    .HasMaxLength(2500)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmedOn).HasColumnType("datetime");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.EvaluationMethod)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.TdaConfirmedOn).HasColumnType("datetime");

                entity.Property(e => e.Tdaconfirm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TDAConfirm");

                entity.Property(e => e.TdaconfirmedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TDAConfirmedBy");

                entity.Property(e => e.Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.Property(e => e.Userloginid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGINID");
            });

            modelBuilder.Entity<ExResourcerolestatusLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCEROLESTATUS_LOG");

                entity.Property(e => e.ApproveStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("APPROVE_STATUS")
                    .IsFixedLength();

                entity.Property(e => e.ConfirmedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmedOn).HasColumnType("datetime");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.EvaluationMethod)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Logcomments)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("LOGCOMMENTS");

                entity.Property(e => e.LogcrdtDate)
                    .HasColumnType("datetime")
                    .HasColumnName("LOGCRDT_DATE");

                entity.Property(e => e.LogcrdtLogin)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LOGCRDT_LOGIN");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Role)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.TdaConfirmedOn).HasColumnType("datetime");

                entity.Property(e => e.Tdaconfirm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TDAConfirm");

                entity.Property(e => e.TdaconfirmedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("TDAConfirmedBy");

                entity.Property(e => e.Type)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.Property(e => e.Userloginid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGINID");
            });

            modelBuilder.Entity<ExResourceskillmgrrating>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCESKILLMGRRATING");

                entity.Property(e => e.Ambarole)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AMBAROLE");

                entity.Property(e => e.CaCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CA_Code");

                entity.Property(e => e.Comments)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.ElCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EL_Code");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.MgrPelogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("MGR_PELOGN");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Rating)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RATING");

                entity.Property(e => e.RatingFromdt)
                    .HasColumnType("datetime")
                    .HasColumnName("RATING_FROMDT");

                entity.Property(e => e.RatingTodate)
                    .HasColumnType("datetime")
                    .HasColumnName("RATING_TODATE");

                entity.Property(e => e.Skilltype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SKILLTYPE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourceskillmgrratingLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCESKILLMGRRATING_LOG");

                entity.Property(e => e.Ambarole)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("AMBAROLE");

                entity.Property(e => e.CaCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CA_Code");

                entity.Property(e => e.Comments)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("COMMENTS");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.ElCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EL_Code");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Logenteredby)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOGENTEREDBY");

                entity.Property(e => e.Logentrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("LOGENTRYSTAMP");

                entity.Property(e => e.MgrPelogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MGR_PELOGN");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Rating)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RATING");

                entity.Property(e => e.RatingFromdt)
                    .HasColumnType("datetime")
                    .HasColumnName("RATING_FROMDT");

                entity.Property(e => e.RatingTodate)
                    .HasColumnType("datetime")
                    .HasColumnName("RATING_TODATE");

                entity.Property(e => e.Skilltype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("SKILLTYPE");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourceskillsevaluation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCESKILLSEVALUATION");

                entity.Property(e => e.AtdDataaccuracy)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ATD_DATAACCURACY")
                    .IsFixedLength()
                    .HasComment("Excellent: E, Good: G, Poor: P, Excellent: E, Poor: P, Not Satisfied: N");

                entity.Property(e => e.AtdPresentation)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ATD_PRESENTATION")
                    .IsFixedLength();

                entity.Property(e => e.CommVerbal)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("COMM_VERBAL")
                    .IsFixedLength()
                    .HasComment("Excellent: E, Good: G, Poor: P, Excellent: E, Poor: P, Not Satisfied: N");

                entity.Property(e => e.CommWritten)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("COMM_WRITTEN")
                    .IsFixedLength()
                    .HasComment("Excellent: E, Good: G, Poor: P, Excellent: E, Poor: P, Not Satisfied: N");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Dedication)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("DEDICATION")
                    .IsFixedLength();

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.FromDate)
                    .HasColumnType("datetime")
                    .HasColumnName("FROM_DATE");

                entity.Property(e => e.MeetingDeadlines)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("MEETING_DEADLINES")
                    .IsFixedLength()
                    .HasComment("Yes : Y, No : N");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Proactive)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PROACTIVE")
                    .IsFixedLength()
                    .HasComment("Yes: Y, No:N");

                entity.Property(e => e.ProdQuality)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PROD_QUALITY")
                    .IsFixedLength()
                    .HasComment("Excellent: E, Good: G, Poor: P, Excellent: E, Poor: P, Not Satisfied: N");

                entity.Property(e => e.Responsiveness)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RESPONSIVENESS")
                    .IsFixedLength()
                    .HasComment("Yes: Y, No:N");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.StrongModelSkill)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STRONG_MODEL_SKILL")
                    .IsFixedLength()
                    .HasComment("Excellent: E, Good: G, Poor: P, Excellent: E, Poor: P, Not Satisfied: N");

                entity.Property(e => e.ToDate)
                    .HasColumnType("datetime")
                    .HasColumnName("TO_DATE");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourceskilltraining>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCESKILLTRAINING");

                entity.Property(e => e.CaCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CA_CODE");

                entity.Property(e => e.Datasource)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("datasource");

                entity.Property(e => e.ElCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EL_CODE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.EvaluationMethod)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PassTraining)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASS_TRAINING");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.SkillGrade)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SKILL_GRADE");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.TrainingActualenddate)
                    .HasColumnType("datetime")
                    .HasColumnName("TRAINING_ACTUALENDDATE");

                entity.Property(e => e.TrainingEnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("TRAINING_ENDDATE");

                entity.Property(e => e.TrainingSkilltype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRAINING_SKILLTYPE");

                entity.Property(e => e.TrainingSl).HasColumnName("TRAINING_SL");

                entity.Property(e => e.TrainingStartdate)
                    .HasColumnType("datetime")
                    .HasColumnName("TRAINING_STARTDATE");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourceskilltraininglog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCESKILLTRAININGLOG");

                entity.Property(e => e.CaCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CA_CODE");

                entity.Property(e => e.ElCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EL_CODE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PassTraining)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PASS_TRAINING");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.SkillGrade)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("SKILL_GRADE");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.TrainingActualenddate)
                    .HasColumnType("datetime")
                    .HasColumnName("TRAINING_ACTUALENDDATE");

                entity.Property(e => e.TrainingEnddate)
                    .HasColumnType("datetime")
                    .HasColumnName("TRAINING_ENDDATE");

                entity.Property(e => e.TrainingSkilltype)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("TRAINING_SKILLTYPE");

                entity.Property(e => e.TrainingSl).HasColumnName("TRAINING_SL");

                entity.Property(e => e.TrainingStartdate)
                    .HasColumnType("datetime")
                    .HasColumnName("TRAINING_STARTDATE");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExResourceworkevaluation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCEWORKEVALUATION");

                entity.Property(e => e.CdClarityOfCommunicationWithClientAbility1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CD_Clarity_of_communication_with_client_Ability1");

                entity.Property(e => e.CdClientSupportAbility1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CD_Client_support_Ability1");

                entity.Property(e => e.CdComplexityOfFinancialModelingAbility1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CD_Complexity_of_financial_modeling_Ability1");

                entity.Property(e => e.CdInvestmentIdeasAndIndependentThinkingAbility1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CD_Investment_ideas_and_independent_thinking_Ability1");

                entity.Property(e => e.CdKnowledgeOfIndustryFundamentalsAbility1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CD_Knowledge_of_industry_fundamentals_Ability1");

                entity.Property(e => e.CdKnowledgeOfMarketsMarketdriversNewsAbility1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CD_Knowledge_of_markets_marketdrivers_news_Ability1");

                entity.Property(e => e.CdKnowledgeOfValuationTechniquesAbility1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CD_Knowledge_of_valuation_techniques_Ability1");

                entity.Property(e => e.CdLongWorkingHoursAbility1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CD_Long_working_hours_Ability1");

                entity.Property(e => e.CdQuickTurnaroundDeadlinePressureAbility1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CD_Quick_turnaround_deadline_pressure_Ability1");

                entity.Property(e => e.CdStandardOfWrittenEnglishAndReportWritingAbility1)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CD_Standard_of_written_English_and_report_writing_Ability1");

                entity.Property(e => e.ClarityOfCommunicationWithClientAbility)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Clarity_of_communication_with_client_Ability");

                entity.Property(e => e.ClientSupportAbility)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Client_support_Ability");

                entity.Property(e => e.ComplexityOfFinancialModelingAbility)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Complexity_of_financial_modeling_Ability");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.FromDate)
                    .HasColumnType("datetime")
                    .HasColumnName("FROM_DATE");

                entity.Property(e => e.InvestmentIdeasAndIndependentThinkingAbility)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Investment_ideas_and_independent_thinking_Ability");

                entity.Property(e => e.KnowledgeOfIndustryFundamentalsAbility)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Knowledge_of_industry_fundamentals_Ability");

                entity.Property(e => e.KnowledgeOfMarketsMarketdriversNewsAbility)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Knowledge_of_markets_marketdrivers_news_Ability");

                entity.Property(e => e.KnowledgeOfValuationTechniquesAbility)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Knowledge_of_valuation_techniques_Ability");

                entity.Property(e => e.LongWorkingHoursAbility)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Long_working_hours_Ability");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.QuickTurnaroundDeadlinePressureAbility)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Quick_turnaround_deadline_pressure_Ability");

                entity.Property(e => e.StandardOfWrittenEnglishAndReportWritingAbility)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Standard_of_written_English_and_report_writing_Ability");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.ToDate)
                    .HasColumnType("datetime")
                    .HasColumnName("TO_DATE");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExRiskIden>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Risk_Iden");

                entity.Property(e => e.ClosingDate).HasColumnType("datetime");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("createdby");

                entity.Property(e => e.CuIden).HasColumnName("cu_iden");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("entrystamp");

                entity.Property(e => e.IdentifiedDate).HasColumnType("datetime");

                entity.Property(e => e.LastClientCall).HasColumnType("datetime");

                entity.Property(e => e.MngrComments).HasColumnName("mngr_comments");

                entity.Property(e => e.PeLognIden)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pe_logn_iden");

                entity.Property(e => e.Pid).HasColumnName("PID");

                entity.Property(e => e.RcatId).HasColumnName("RCatID");

                entity.Property(e => e.Rid).HasColumnName("RID");

                entity.Property(e => e.RiskCloseBy).HasColumnName("RiskCloseBY");

                entity.Property(e => e.RiskCloseDate).HasColumnType("datetime");

                entity.Property(e => e.RiskCloseOn).HasColumnType("datetime");

                entity.Property(e => e.Riskdate).HasColumnType("datetime");

                entity.Property(e => e.Roc)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("ROC");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UpdateTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("updateTimestamp");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("updatedby");
            });

            modelBuilder.Entity<ExRiskMitPlan>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Risk_Mit_Plans");

                entity.Property(e => e.AssignPeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Assign_Pe_Logn");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("createdby");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("entrystamp");

                entity.Property(e => e.Mid).HasColumnName("MID");

                entity.Property(e => e.MitPlan).HasColumnName("MIT_Plan");

                entity.Property(e => e.MitigationClosingDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Mitigation_Closing_Date");

                entity.Property(e => e.Rid).HasColumnName("RID");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("status");

                entity.Property(e => e.UpdateTimestamp)
                    .HasColumnType("datetime")
                    .HasColumnName("updateTimestamp");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("updatedby");
            });

            modelBuilder.Entity<ExRiskSymptomMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RISK_SYMPTOM_MASTER");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.RcatId).HasColumnName("RCatID");

                entity.Property(e => e.Rsid)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("RSID");

                entity.Property(e => e.Rsname)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("RSNAME");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExRiskcatMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RISKCAT_MASTER");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.RcatId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("RCatID");

                entity.Property(e => e.RiskName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExRiskscaleMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RISKSCALE_MASTER");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.RiskScale)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("RiskSCALE");

                entity.Property(e => e.RscaleId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("RScaleID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExRoleMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Role_Master");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.RoleId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("RoleID");

                entity.Property(e => e.RoleName).HasMaxLength(100);

                entity.Property(e => e.RoleTypeId).HasColumnName("RoleTypeID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExRoleTypeMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Role_Type_Master");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.RoleType).HasMaxLength(100);

                entity.Property(e => e.RoleTypeId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("RoleTypeID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExScreenMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Screen_Master");

                entity.Property(e => e.Description).HasMaxLength(1000);

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.ScreenId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ScreenID");

                entity.Property(e => e.ScreenName).HasMaxLength(100);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExServicetype>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_SERVICETYPES");

                entity.Property(e => e.Services)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ExSkillsetMasterLevel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_SKILLSET_MASTER_LEVEL");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Level)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LEVEL");

                entity.Property(e => e.LevelId).HasColumnName("LEVEL_ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExSlalevelMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_SLALevel_Master");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.LevelDesc).HasMaxLength(2000);

                entity.Property(e => e.LevelId).HasColumnName("LevelID");

                entity.Property(e => e.LevelName).HasMaxLength(1000);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExSownumber>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_SOWNumber");

                entity.Property(e => e.Bgccheck).HasColumnName("BGCCheck");

                entity.Property(e => e.CuIden).HasColumnName("Cu_Iden");

                entity.Property(e => e.ElCode)
                    .HasMaxLength(20)
                    .HasColumnName("El_Code");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.FileName).HasMaxLength(1000);

                entity.Property(e => e.Msadate)
                    .HasColumnType("datetime")
                    .HasColumnName("MSADate");

                entity.Property(e => e.MsafileName).HasColumnName("MSAFileName");

                entity.Property(e => e.MsafilePath).HasColumnName("MSAFilePath");

                entity.Property(e => e.Msanumber).HasColumnName("MSANumber");

                entity.Property(e => e.Slnumber).HasColumnName("SLNumber");

                entity.Property(e => e.SowNumber).HasMaxLength(500);

                entity.Property(e => e.Sowdate)
                    .HasColumnType("datetime")
                    .HasColumnName("SOWDate");

                entity.Property(e => e.SowrenewDate)
                    .HasColumnType("datetime")
                    .HasColumnName("SOWRenewDate");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExStatusdesc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_STATUSDESC");

                entity.Property(e => e.Bill)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("BILL");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Level)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LEVEL");

                entity.Property(e => e.OnOff).HasColumnName("ON_OFF");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.StatusDesc)
                    .HasMaxLength(200)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_DESC");

                entity.Property(e => e.StatusIndicator)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_INDICATOR");

                entity.Property(e => e.StatusLevelId).HasColumnName("STATUS_LEVEL_ID");

                entity.Property(e => e.StatusShortDesc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("STATUS_SHORT_DESC");

                entity.Property(e => e.Type)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExSubreasonMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_SUBREASON_MASTER");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Status)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.SubreasonComments)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SUBREASON_comments");

                entity.Property(e => e.SubreasonDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SUBREASON_DESC");

                entity.Property(e => e.SubreasonSl).HasColumnName("SUBREASON_SL");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExSummaryDataLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Summary_Data_Logs");

                entity.Property(e => e.Allocation).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Billing).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Filter).HasMaxLength(400);

                entity.Property(e => e.FilterType).HasMaxLength(100);

                entity.Property(e => e.ForMonth).HasMaxLength(100);

                entity.Property(e => e.ForTheDate).HasColumnType("datetime");

                entity.Property(e => e.PartialBenchHc)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("PartialBenchHC");

                entity.Property(e => e.PureBenchHc)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("PureBenchHC");

                entity.Property(e => e.TotalHc).HasColumnName("TotalHC");
            });

            modelBuilder.Entity<ExSysReleaseUpdate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Sys_ReleaseUpdate");

                entity.Property(e => e.Enddate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Heading).HasMaxLength(1000);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.ModifiedBy).HasMaxLength(20);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.ModuleId).HasColumnName("ModuleID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserLogn).HasMaxLength(20);
            });

            modelBuilder.Entity<ExSysReleaseUpdateReadBy>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Sys_ReleaseUpdate_ReadBy");

                entity.Property(e => e.ReadBy)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.ReadStamp).HasColumnType("datetime");

                entity.Property(e => e.ReleaseId).HasColumnName("ReleaseID");
            });

            modelBuilder.Entity<ExTransactionApproval>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_Transaction_Approval");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.LockedBy).HasMaxLength(20);

                entity.Property(e => e.LockedOn).HasColumnType("datetime");

                entity.Property(e => e.ServiceLine).HasMaxLength(10);

                entity.Property(e => e.Status).HasMaxLength(10);

                entity.Property(e => e.UnLockBy).HasMaxLength(20);

                entity.Property(e => e.UnLockOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExUnbilledMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_UNBILLED_MASTER");

                entity.Property(e => e.EnddateStamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE_STAMP");

                entity.Property(e => e.EnddateUserlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ENDDATE_USERLOGNID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Status)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.SubreasonComments)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SUBREASON_comments");

                entity.Property(e => e.SubreasonDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("SUBREASON_DESC");

                entity.Property(e => e.SubreasonSl).HasColumnName("SUBREASON_SL");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExUsageClauseMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_USAGE_CLAUSE_MASTER");

                entity.Property(e => e.Cid).HasColumnName("CID");

                entity.Property(e => e.Clause)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CLAUSE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Isblackout).HasColumnName("ISBLACKOUT");

                entity.Property(e => e.Lastupdatedby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATEDBY");

                entity.Property(e => e.Lastupdatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("LASTUPDATEDON");

                entity.Property(e => e.Status)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExUtilizationMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_UTILIZATION_MASTER");

                entity.Property(e => e.BillHrs)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("BILL_HRS");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpectedHrs)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("EXPECTED_HRS");

                entity.Property(e => e.Group)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.HolidayCount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("HOLIDAY_COUNT");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.LeaveCount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("LEAVE_COUNT");

                entity.Property(e => e.Noeffort)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("NOEFFORT");

                entity.Property(e => e.NonbillHrs)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("NONBILL_HRS");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Utilization)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("UTILIZATION");

                entity.Property(e => e.Workingdays)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("WORKINGDAYS");
            });

            modelBuilder.Entity<ExUtilizationMasterBilling>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_UTILIZATION_MASTER_BILLING");

                entity.Property(e => e.BillHrs)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("BILL_HRS");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.ExpectedHrs)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("EXPECTED_HRS");

                entity.Property(e => e.Group)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.HolidayCount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("HOLIDAY_COUNT");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.LeaveCount)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("LEAVE_COUNT");

                entity.Property(e => e.Noeffort)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("NOEFFORT");

                entity.Property(e => e.NonbillHrs)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("NONBILL_HRS");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Utilization)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("UTILIZATION");

                entity.Property(e => e.Workingdays)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("WORKINGDAYS");
            });

            modelBuilder.Entity<GroupRoleMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("GROUP_ROLE_MAPPING");

                entity.Property(e => e.Group)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<HcActionItem>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HC_ActionItems");

                entity.Property(e => e.ActionItems)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.AssignedTo)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Comments)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.CompletionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Completion_Date");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HcAduitDm>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HC_AduitDM");

                entity.Property(e => e.AduitLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Aduit_Logn");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HcCommStatsBenchMark>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HC_CommStats_BenchMark");

                entity.Property(e => e.Calls).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Mails).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HcDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HC_Data");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Field)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Link)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Rating)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");
            });

            modelBuilder.Entity<HcMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HC_Master");

                entity.Property(e => e.ClientAnal)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.CuIden).HasColumnName("Cu_Iden");

                entity.Property(e => e.HcDate)
                    .HasColumnType("datetime")
                    .HasColumnName("HC_Date");

                entity.Property(e => e.HcKeyOb)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("HC_KeyOb");

                entity.Property(e => e.HcTrigger)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("HC_Trigger");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.Service)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_Date");
            });

            modelBuilder.Entity<HcMetaDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HC_MetaData");

                entity.Property(e => e.Filed)
                    .HasMaxLength(256)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HcQuery>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HC_Query");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Query)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HcRealtimeSummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HC_REALTIME_SUMMARY");

                entity.Property(e => e.Allocn).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.BillEnd).HasColumnType("datetime");

                entity.Property(e => e.BillPercent).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.BillStart).HasColumnType("datetime");

                entity.Property(e => e.BillingStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.BlackOut)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CuIden).HasColumnName("Cu_Iden");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Of_Move");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FinalStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Geo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Group)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("Kick_Off");

                entity.Property(e => e.Lob)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("LOB");

                entity.Property(e => e.MainBillingStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OffBoardReason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.OverallBillingStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PeLocn).HasColumnName("Pe_Locn");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.Period).HasColumnType("datetime");

                entity.Property(e => e.ProjId).HasColumnName("Proj_Id");

                entity.Property(e => e.Reason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Sbt)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SBT");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.Sow)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("SOW");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusLvl).HasColumnName("Status_Lvl");

                entity.Property(e => e.UsageClause)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.UtilBench)
                    .HasMaxLength(100)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HcTrigger>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HC_Trigger");

                entity.Property(e => e.AuditDmStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("AuditDM_Status");

                entity.Property(e => e.CdhComments)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("CDH_Comments");

                entity.Property(e => e.CdhLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CDH_Logn");

                entity.Property(e => e.ClosureEntryStamp).HasColumnType("datetime");

                entity.Property(e => e.ClosureLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Closure_Logn");

                entity.Property(e => e.ClosureStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.CsatDate)
                    .HasColumnType("datetime")
                    .HasColumnName("CSAT_Date");

                entity.Property(e => e.CuIden).HasColumnName("Cu_Iden");

                entity.Property(e => e.DmLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("DM_Logn");

                entity.Property(e => e.DmStatus)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("DM_Status");

                entity.Property(e => e.EndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("End_Date");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Group)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.RecordDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Record_Date");

                entity.Property(e => e.StartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Start_Date");

                entity.Property(e => e.Status)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Trigger)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.Type)
                    .HasMaxLength(90)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<HcVacomment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("HC_VAComments");

                entity.Property(e => e.Comments)
                    .HasMaxLength(8000)
                    .IsUnicode(false);

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Qid).HasColumnName("QID");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<IpActivity>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ip_activity");

                entity.Property(e => e.AcAccr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AC_ACCR");

                entity.Property(e => e.AcAcct).HasColumnName("AC_ACCT");

                entity.Property(e => e.AcAcdf).HasColumnName("AC_ACDF");

                entity.Property(e => e.AcAcef).HasColumnName("AC_ACEF");

                entity.Property(e => e.AcAcfi)
                    .HasColumnType("datetime")
                    .HasColumnName("AC_ACFI");

                entity.Property(e => e.AcAcrw).HasColumnName("AC_ACRW");

                entity.Property(e => e.AcAcst)
                    .HasColumnType("datetime")
                    .HasColumnName("AC_ACST");

                entity.Property(e => e.AcAcsz).HasColumnName("AC_ACSZ");

                entity.Property(e => e.AcAdap)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AC_ADAP");

                entity.Property(e => e.AcAdef).HasColumnName("AC_ADEF");

                entity.Property(e => e.AcAfix).HasColumnName("AC_AFIX");

                entity.Property(e => e.AcArwc).HasColumnName("AC_ARWC");

                entity.Property(e => e.AcBcwp).HasColumnName("AC_BCWP");

                entity.Property(e => e.AcBcws).HasColumnName("AC_BCWS");

                entity.Property(e => e.AcBill)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AC_BILL");

                entity.Property(e => e.AcBkst)
                    .HasColumnType("datetime")
                    .HasColumnName("AC_BKST");

                entity.Property(e => e.AcBlct).HasColumnName("AC_BLCT");

                entity.Property(e => e.AcBlef).HasColumnName("AC_BLEF");

                entity.Property(e => e.AcBlfi)
                    .HasColumnType("datetime")
                    .HasColumnName("AC_BLFI");

                entity.Property(e => e.AcBlst)
                    .HasColumnType("datetime")
                    .HasColumnName("AC_BLST");

                entity.Property(e => e.AcBlsz).HasColumnName("AC_BLSZ");

                entity.Property(e => e.AcCodt)
                    .HasColumnType("datetime")
                    .HasColumnName("AC_CODT");

                entity.Property(e => e.AcCoty).HasColumnName("AC_COTY");

                entity.Property(e => e.AcDedt)
                    .HasColumnType("datetime")
                    .HasColumnName("AC_DEDT");

                entity.Property(e => e.AcDfdt)
                    .HasColumnType("datetime")
                    .HasColumnName("AC_DFDT");

                entity.Property(e => e.AcDisp).HasColumnName("AC_DISP");

                entity.Property(e => e.AcDocs)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AC_DOCS");

                entity.Property(e => e.AcDura).HasColumnName("AC_DURA");

                entity.Property(e => e.AcErfi)
                    .HasColumnType("datetime")
                    .HasColumnName("AC_ERFI");

                entity.Property(e => e.AcErst)
                    .HasColumnType("datetime")
                    .HasColumnName("AC_ERST");

                entity.Property(e => e.AcFixc).HasColumnName("AC_FIXC");

                entity.Property(e => e.AcFixp).HasColumnName("AC_FIXP");

                entity.Property(e => e.AcForm).HasColumnName("AC_FORM");

                entity.Property(e => e.AcFsef).HasColumnName("AC_FSEF");

                entity.Property(e => e.AcFtok).HasColumnName("AC_FTOK");

                entity.Property(e => e.AcFunc)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AC_FUNC");

                entity.Property(e => e.AcHodt)
                    .HasColumnType("datetime")
                    .HasColumnName("AC_HODT");

                entity.Property(e => e.AcHoef).HasColumnName("AC_HOEF");

                entity.Property(e => e.AcIden).HasColumnName("AC_IDEN");

                entity.Property(e => e.AcInpt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AC_INPT");

                entity.Property(e => e.AcLafi)
                    .HasColumnType("datetime")
                    .HasColumnName("AC_LAFI");

                entity.Property(e => e.AcLast)
                    .HasColumnType("datetime")
                    .HasColumnName("AC_LAST");

                entity.Property(e => e.AcLevl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AC_LEVL");

                entity.Property(e => e.AcLink).HasColumnName("AC_LINK");

                entity.Property(e => e.AcMdid).HasColumnName("AC_MDID");

                entity.Property(e => e.AcMeid).HasColumnName("AC_MEID");

                entity.Property(e => e.AcName)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("AC_NAME");

                entity.Property(e => e.AcNote).HasColumnName("AC_NOTE");

                entity.Property(e => e.AcNumb)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("AC_NUMB");

                entity.Property(e => e.AcNumu).HasColumnName("AC_NUMU");

                entity.Property(e => e.AcOutt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AC_OUTT");

                entity.Property(e => e.AcParn).HasColumnName("AC_PARN");

                entity.Property(e => e.AcPhse)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("AC_PHSE");

                entity.Property(e => e.AcPldf).HasColumnName("AC_PLDF");

                entity.Property(e => e.AcPlef).HasColumnName("AC_PLEF");

                entity.Property(e => e.AcPlfi)
                    .HasColumnType("datetime")
                    .HasColumnName("AC_PLFI");

                entity.Property(e => e.AcPlrw).HasColumnName("AC_PLRW");

                entity.Property(e => e.AcPlst)
                    .HasColumnType("datetime")
                    .HasColumnName("AC_PLST");

                entity.Property(e => e.AcPlsz).HasColumnName("AC_PLSZ");

                entity.Property(e => e.AcPrid).HasColumnName("AC_PRID");

                entity.Property(e => e.AcPrj1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("AC_PRJ1");

                entity.Property(e => e.AcPrj2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("AC_PRJ2");

                entity.Property(e => e.AcPrj3)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("AC_PRJ3");

                entity.Property(e => e.AcPrj4)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("AC_PRJ4");

                entity.Property(e => e.AcPrty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AC_PRTY");

                entity.Property(e => e.AcPrwc).HasColumnName("AC_PRWC");

                entity.Property(e => e.AcQuer)
                    .HasMaxLength(255)
                    .IsUnicode(false)
                    .HasColumnName("AC_QUER");

                entity.Property(e => e.AcRept)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("AC_REPT");

                entity.Property(e => e.AcResp)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AC_RESP");

                entity.Property(e => e.AcRevu)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AC_REVU");

                entity.Property(e => e.AcRisk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AC_RISK");

                entity.Property(e => e.AcRmdf).HasColumnName("AC_RMDF");

                entity.Property(e => e.AcScmo).HasColumnName("AC_SCMO");

                entity.Property(e => e.AcScva).HasColumnName("AC_SCVA");

                entity.Property(e => e.AcStat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AC_STAT");

                entity.Property(e => e.AcStok).HasColumnName("AC_STOK");

                entity.Property(e => e.AcType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AC_TYPE");

                entity.Property(e => e.AcUnit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AC_UNIT");

                entity.Property(e => e.AcUser)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("AC_USER");

                entity.Property(e => e.AcUsr1)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("AC_USR1");

                entity.Property(e => e.AcUsr2)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("AC_USR2");

                entity.Property(e => e.AcUsr3)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("AC_USR3");

                entity.Property(e => e.AcUsr4)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("AC_USR4");

                entity.Property(e => e.AcUtyp)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("AC_UTYP");

                entity.Property(e => e.AcVarc).HasColumnName("AC_VARC");

                entity.Property(e => e.AcVarp).HasColumnName("AC_VARP");

                entity.Property(e => e.AcWbst)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("AC_WBST");

                entity.Property(e => e.CaIden).HasColumnName("CA_IDEN");

                entity.Property(e => e.IpLocn).HasColumnName("IP_LOCN");

                entity.Property(e => e.PrIden).HasColumnName("PR_IDEN");
            });

            modelBuilder.Entity<IpCustomer>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.CuComp });

                entity.ToTable("IP_CUSTOMER");

                entity.Property(e => e.CuIden)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("CU_IDEN");

                entity.Property(e => e.CuComp)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("cu_comp");

                entity.Property(e => e.ExCuHmth).HasColumnName("ex_cu_hmth");
            });

            modelBuilder.Entity<IpDailyeff>(entity =>
            {
                entity.HasKey(e => new { e.PrIden, e.AcIden, e.PeLogn, e.DeDate });

                entity.ToTable("IP_DAILYEFF");

                entity.Property(e => e.PrIden).HasColumnName("PR_IDEN");

                entity.Property(e => e.AcIden).HasColumnName("AC_IDEN");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.DeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DE_DATE");

                entity.Property(e => e.AmbBillable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("AMB_BILLABLE")
                    .IsFixedLength();

                entity.Property(e => e.DeEffo).HasColumnName("DE_EFFO");

                entity.Property(e => e.EntryStamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IpLocn).HasColumnName("IP_LOCN");
            });

            modelBuilder.Entity<IpNewproj>(entity =>
            {
                entity.HasKey(e => new { e.PeLogn, e.PrIden });

                entity.ToTable("IP_NEWPROJ");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.PrIden).HasColumnName("PR_IDEN");

                entity.Property(e => e.IpLocn).HasColumnName("IP_LOCN");

                entity.Property(e => e.NpApdt)
                    .HasColumnType("datetime")
                    .HasColumnName("NP_APDT");

                entity.Property(e => e.NpBill)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NP_BILL");

                entity.Property(e => e.NpCost)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NP_COST");

                entity.Property(e => e.NpDura).HasColumnName("NP_DURA");

                entity.Property(e => e.NpEffo).HasColumnName("NP_EFFO");

                entity.Property(e => e.NpFidt)
                    .HasColumnType("datetime")
                    .HasColumnName("NP_FIDT");

                entity.Property(e => e.NpNote).HasColumnName("NP_NOTE");

                entity.Property(e => e.NpPosn).HasColumnName("NP_POSN");

                entity.Property(e => e.NpPrim)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NP_PRIM");

                entity.Property(e => e.NpResp)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NP_RESP");

                entity.Property(e => e.NpReto)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("NP_RETO");

                entity.Property(e => e.NpRjdt)
                    .HasColumnType("datetime")
                    .HasColumnName("NP_RJDT");

                entity.Property(e => e.NpRole)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("NP_ROLE");

                entity.Property(e => e.NpSbdt)
                    .HasColumnType("datetime")
                    .HasColumnName("NP_SBDT");

                entity.Property(e => e.NpStat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NP_STAT");

                entity.Property(e => e.NpStdt)
                    .HasColumnType("datetime")
                    .HasColumnName("NP_STDT");

                entity.Property(e => e.NpTag1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NP_TAG1");

                entity.Property(e => e.NpTag2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("NP_TAG2");
            });

            modelBuilder.Entity<IpPhase>(entity =>
            {
                entity.HasKey(e => new { e.ElCode, e.PhCode });

                entity.ToTable("IP_PHASE");

                entity.Property(e => e.ElCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("EL_CODE");

                entity.Property(e => e.PhCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("PH_CODE");

                entity.Property(e => e.PhName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PH_NAME");

                entity.Property(e => e.PhOrdr)
                    .HasColumnName("PH_ORDR")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<IpProject>(entity =>
            {
                entity.HasKey(e => e.PrIden);

                entity.ToTable("IP_PROJECT");

                entity.Property(e => e.PrIden)
                    .ValueGeneratedNever()
                    .HasColumnName("PR_IDEN");

                entity.Property(e => e.ClIden).HasColumnName("CL_IDEN");

                entity.Property(e => e.IpLocn).HasColumnName("IP_LOCN");

                entity.Property(e => e.PrAcct).HasColumnName("PR_ACCT");

                entity.Property(e => e.PrAcdf).HasColumnName("PR_ACDF");

                entity.Property(e => e.PrAcef).HasColumnName("PR_ACEF");

                entity.Property(e => e.PrAcfi)
                    .HasColumnType("datetime")
                    .HasColumnName("PR_ACFI");

                entity.Property(e => e.PrAcrw).HasColumnName("PR_ACRW");

                entity.Property(e => e.PrAcst)
                    .HasColumnType("datetime")
                    .HasColumnName("PR_ACST");

                entity.Property(e => e.PrAcsz).HasColumnName("PR_ACSZ");

                entity.Property(e => e.PrAdef).HasColumnName("PR_ADEF");

                entity.Property(e => e.PrApby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PR_APBY");

                entity.Property(e => e.PrApdt)
                    .HasColumnType("datetime")
                    .HasColumnName("PR_APDT");

                entity.Property(e => e.PrArwc).HasColumnName("PR_ARWC");

                entity.Property(e => e.PrBill)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PR_BILL");

                entity.Property(e => e.PrBlam).HasColumnName("PR_BLAM");

                entity.Property(e => e.PrBldt)
                    .HasColumnType("datetime")
                    .HasColumnName("PR_BLDT");

                entity.Property(e => e.PrBlef).HasColumnName("PR_BLEF");

                entity.Property(e => e.PrBuct).HasColumnName("PR_BUCT");

                entity.Property(e => e.PrBuef).HasColumnName("PR_BUEF");

                entity.Property(e => e.PrCcap).HasColumnName("PR_CCAP");

                entity.Property(e => e.PrCcpi).HasColumnName("PR_CCPI");

                entity.Property(e => e.PrCont)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PR_CONT");

                entity.Property(e => e.PrCrby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PR_CRBY");

                entity.Property(e => e.PrCrdt)
                    .HasColumnType("datetime")
                    .HasColumnName("PR_CRDT");

                entity.Property(e => e.PrCrin).HasColumnName("PR_CRIN");

                entity.Property(e => e.PrCspi).HasColumnName("PR_CSPI");

                entity.Property(e => e.PrCurr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PR_CURR");

                entity.Property(e => e.PrCust)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("PR_CUST");

                entity.Property(e => e.PrCval).HasColumnName("PR_CVAL");

                entity.Property(e => e.PrCycl).HasColumnName("PR_CYCL");

                entity.Property(e => e.PrDept)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PR_DEPT");

                entity.Property(e => e.PrFixc).HasColumnName("PR_FIXC");

                entity.Property(e => e.PrFixp).HasColumnName("PR_FIXP");

                entity.Property(e => e.PrHodt)
                    .HasColumnType("datetime")
                    .HasColumnName("PR_HODT");

                entity.Property(e => e.PrHoef).HasColumnName("PR_HOEF");

                entity.Property(e => e.PrIact).HasColumnName("PR_IACT");

                entity.Property(e => e.PrIaef).HasColumnName("PR_IAEF");

                entity.Property(e => e.PrIarc).HasColumnName("PR_IARC");

                entity.Property(e => e.PrIarw).HasColumnName("PR_IARW");

                entity.Property(e => e.PrIpct).HasColumnName("PR_IPCT");

                entity.Property(e => e.PrIpef).HasColumnName("PR_IPEF");

                entity.Property(e => e.PrIprc).HasColumnName("PR_IPRC");

                entity.Property(e => e.PrIprw).HasColumnName("PR_IPRW");

                entity.Property(e => e.PrLevl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PR_LEVL");

                entity.Property(e => e.PrLocn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PR_LOCN");

                entity.Property(e => e.PrMngr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PR_MNGR");

                entity.Property(e => e.PrMoby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PR_MOBY");

                entity.Property(e => e.PrModt)
                    .HasColumnType("datetime")
                    .HasColumnName("PR_MODT");

                entity.Property(e => e.PrName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PR_NAME");

                entity.Property(e => e.PrNumb).HasColumnName("PR_NUMB");

                entity.Property(e => e.PrObje)
                    .HasMaxLength(90)
                    .IsUnicode(false)
                    .HasColumnName("PR_OBJE");

                entity.Property(e => e.PrOptn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PR_OPTN");

                entity.Property(e => e.PrPlct).HasColumnName("PR_PLCT");

                entity.Property(e => e.PrPldf).HasColumnName("PR_PLDF");

                entity.Property(e => e.PrPlef).HasColumnName("PR_PLEF");

                entity.Property(e => e.PrPlfi)
                    .HasColumnType("datetime")
                    .HasColumnName("PR_PLFI");

                entity.Property(e => e.PrPlrw).HasColumnName("PR_PLRW");

                entity.Property(e => e.PrPlst)
                    .HasColumnType("datetime")
                    .HasColumnName("PR_PLST");

                entity.Property(e => e.PrPlsz).HasColumnName("PR_PLSZ");

                entity.Property(e => e.PrProc)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PR_PROC");

                entity.Property(e => e.PrPrty)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PR_PRTY");

                entity.Property(e => e.PrPrwc).HasColumnName("PR_PRWC");

                entity.Property(e => e.PrPswd)
                    .HasMaxLength(15)
                    .HasColumnName("PR_PSWD");

                entity.Property(e => e.PrPtyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PR_PTYP");

                entity.Property(e => e.PrQchk)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PR_QCHK");

                entity.Property(e => e.PrQual)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PR_QUAL");

                entity.Property(e => e.PrRefn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PR_REFN");

                entity.Property(e => e.PrReso)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PR_RESO");

                entity.Property(e => e.PrRmdf).HasColumnName("PR_RMDF");

                entity.Property(e => e.PrRsrv).HasColumnName("PR_RSRV");

                entity.Property(e => e.PrStat)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PR_STAT");

                entity.Property(e => e.PrTech)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PR_TECH");

                entity.Property(e => e.PrTerm).HasColumnName("PR_TERM");

                entity.Property(e => e.PrTval).HasColumnName("PR_TVAL");

                entity.Property(e => e.PrUnit)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PR_UNIT");

                entity.Property(e => e.PrUsr1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PR_USR1");

                entity.Property(e => e.PrUsr2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PR_USR2");

                entity.Property(e => e.PrUsr3)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PR_USR3");

                entity.Property(e => e.PrUsr4)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PR_USR4");

                entity.Property(e => e.PrVarc).HasColumnName("PR_VARC");

                entity.Property(e => e.PrVarp).HasColumnName("PR_VARP");

                entity.Property(e => e.PrWarn).HasColumnName("PR_WARN");

                entity.Property(e => e.PtCrby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PT_CRBY");

                entity.Property(e => e.PtCrdt)
                    .HasColumnType("datetime")
                    .HasColumnName("PT_CRDT");

                entity.Property(e => e.PtMoby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PT_MOBY");

                entity.Property(e => e.PtModt)
                    .HasColumnType("datetime")
                    .HasColumnName("PT_MODT");

                entity.Property(e => e.PtPswd)
                    .HasMaxLength(15)
                    .HasColumnName("PT_PSWD");

                entity.Property(e => e.PtPtyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PT_PTYP");
            });

            modelBuilder.Entity<IpTasktype>(entity =>
            {
                entity.HasKey(e => e.TtCode);

                entity.ToTable("IP_TASKTYPE");

                entity.Property(e => e.TtCode)
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("TT_CODE");

                entity.Property(e => e.TtArch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("TT_ARCH")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.TtEnvr)
                    .HasMaxLength(61)
                    .IsUnicode(false)
                    .HasColumnName("TT_ENVR");

                entity.Property(e => e.TtName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TT_NAME");

                entity.Property(e => e.TtNote)
                    .HasColumnName("TT_NOTE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TtPhse)
                    .HasMaxLength(31)
                    .IsUnicode(false)
                    .HasColumnName("TT_PHSE");
            });

            modelBuilder.Entity<MailLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MAIL_LOGS");

                entity.Property(e => e.Approval)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("APPROVAL");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Exception)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("EXCEPTION");

                entity.Property(e => e.MailBody)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("MAIL_BODY");

                entity.Property(e => e.MailCc)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("MAIL_CC");

                entity.Property(e => e.MailFrom)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MAIL_FROM");

                entity.Property(e => e.MailSub)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("MAIL_SUB");

                entity.Property(e => e.MailTo)
                    .HasMaxLength(8000)
                    .IsUnicode(false)
                    .HasColumnName("MAIL_TO");

                entity.Property(e => e.Modu)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("MODU");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<MasterAbbrevation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("MASTER_ABBREVATION");

                entity.Property(e => e.Abbr)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("ABBR");

                entity.Property(e => e.Code)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CODE");

                entity.Property(e => e.Groupcode)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("GROUPCODE");

                entity.Property(e => e.Groupping)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("GROUPPING");

                entity.Property(e => e.Lob)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LOB");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Type)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TYPE");
            });

            modelBuilder.Entity<Phcsummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PHCSUMMARY");

                entity.Property(e => e.Allocation)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("ALLOCATION");

                entity.Property(e => e.Billend)
                    .HasColumnType("datetime")
                    .HasColumnName("BILLEND");

                entity.Property(e => e.Billpercent)
                    .HasColumnType("decimal(10, 2)")
                    .HasColumnName("BILLPERCENT");

                entity.Property(e => e.Billstart)
                    .HasColumnType("datetime")
                    .HasColumnName("BILLSTART");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Currentstatus)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("CURRENTSTATUS");

                entity.Property(e => e.Date)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Finalstatus)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("FINALSTATUS");

                entity.Property(e => e.Group)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.Offboardreason)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("OFFBOARDREASON");

                entity.Property(e => e.Onboardreason)
                    .HasMaxLength(70)
                    .IsUnicode(false)
                    .HasColumnName("ONBOARDREASON");

                entity.Property(e => e.PeLocn).HasColumnName("PE_LOCN");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Role)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ROLE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Status)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.StatusLvlId).HasColumnName("STATUS_LVL_ID");
            });

            modelBuilder.Entity<Productconfig>(entity =>
            {
                entity.ToTable("productconfig");

                entity.Property(e => e.Id)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Authtype)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("authtype");

                entity.Property(e => e.CntrlCc)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("Cntrl_CC");

                entity.Property(e => e.Creby)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("creby");

                entity.Property(e => e.Credate)
                    .HasColumnType("datetime")
                    .HasColumnName("credate");

                entity.Property(e => e.FromMailId)
                    .HasMaxLength(100)
                    .HasColumnName("fromMailId");

                entity.Property(e => e.IntegrationData).HasColumnName("integration_data");

                entity.Property(e => e.Logobase64).HasColumnName("logobase64");

                entity.Property(e => e.Mfa).HasColumnName("mfa");

                entity.Property(e => e.Mfatype)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("mfatype");

                entity.Property(e => e.NotifyDays).HasDefaultValueSql("((0))");

                entity.Property(e => e.PasswordPolicy).HasColumnName("passwordPolicy");

                entity.Property(e => e.Productname)
                    .IsRequired()
                    .HasMaxLength(200)
                    .HasColumnName("productname");

                entity.Property(e => e.Updby)
                    .HasMaxLength(200)
                    .HasColumnName("updby");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");

                entity.Property(e => e.Welcomemail).HasColumnName("welcomemail");
            });

            modelBuilder.Entity<ProjRequestDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Proj_Request_Details");

                entity.Property(e => e.AboutClient)
                    .IsUnicode(false)
                    .HasColumnName("About_Client");

                entity.Property(e => e.BilledYn)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Billed_YN");

                entity.Property(e => e.Client)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.Converted)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.CuComp)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("Cu_Comp");

                entity.Property(e => e.Description).IsUnicode(false);

                entity.Property(e => e.EffortEstimate)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Effort_Estimate");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Group)
                    .HasMaxLength(300)
                    .IsUnicode(false);

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.ProjEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Proj_EndDate");

                entity.Property(e => e.ProjStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Proj_StartDate");

                entity.Property(e => e.ProjType)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Proj_Type");

                entity.Property(e => e.ProjValue).HasColumnName("Proj_Value");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.RiskRating)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Risk_Rating");

                entity.Property(e => e.Rt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RT");

                entity.Property(e => e.ScopePrjCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Scope_Prj_code");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjRequestStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Proj_Request_Status");

                entity.Property(e => e.Comment).IsUnicode(false);

                entity.Property(e => e.CuComp)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("cu_comp");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.Rt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("RT")
                    .IsFixedLength();

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Userlogn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjStatusMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Proj_StatusMaster");

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.Id).ValueGeneratedOnAdd();

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Status_Id");

                entity.Property(e => e.Type)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Userlogn)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ProjTeam>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Proj_Team");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PE_Logn");

                entity.Property(e => e.Role)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.StartDt).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<PromotionNomination>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PROMOTION_NOMINATION");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.FinalComments)
                    .IsUnicode(false)
                    .HasColumnName("FINAL_COMMENTS");

                entity.Property(e => e.FinalStatus)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FINAL_STATUS");

                entity.Property(e => e.NominationDate)
                    .HasColumnType("datetime")
                    .HasColumnName("NOMINATION_DATE");

                entity.Property(e => e.NominationStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("NOMINATION_STATUS");

                entity.Property(e => e.PeDept)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_DEPT");

                entity.Property(e => e.PeDesg)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_DESG");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.PeSbt)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_SBT");

                entity.Property(e => e.PromotionType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PROMOTION_TYPE");

                entity.Property(e => e.SbtStartdate)
                    .HasColumnType("datetime")
                    .HasColumnName("SBT_STARTDATE");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<PromotionPanelMember>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("PROMOTION_PANEL_MEMBER");

                entity.Property(e => e.Department)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEPARTMENT");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.FromDate)
                    .HasColumnType("datetime")
                    .HasColumnName("FROM_DATE");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.ReviewerType)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("REVIEWER_TYPE");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.ToDate)
                    .HasColumnType("datetime")
                    .HasColumnName("TO_DATE");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("UPDATEDBY");
            });

            modelBuilder.Entity<QAvailableField>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Q_Available_Fields");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FieldId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("FieldID");

                entity.Property(e => e.FieldType)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ReferDbname)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("ReferDBName");

                entity.Property(e => e.ReferFieldName)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ReferTableName)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.ShowFieldName)
                    .IsRequired()
                    .HasMaxLength(2000);

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(200)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<QReportName>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Q_ReportName");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ReportDesc).HasMaxLength(2000);

                entity.Property(e => e.ReportId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ReportID");

                entity.Property(e => e.ReportName).HasMaxLength(2000);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<QSelectedFieldsReportMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Q_Selected_Fields_Report_Mapping");

                entity.Property(e => e.FieldId).HasColumnName("FieldID");

                entity.Property(e => e.ReportId).HasColumnName("ReportID");
            });

            modelBuilder.Entity<RealtimeHcsummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("REALTIME_HCSUMMARY");

                entity.Property(e => e.Allocn).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.BillEnd).HasColumnType("datetime");

                entity.Property(e => e.BillPercent).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.BillStart).HasColumnType("datetime");

                entity.Property(e => e.CuIden).HasColumnName("Cu_Iden");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("Date_Of_Move");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.FinalStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Group)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("Kick_Off");

                entity.Property(e => e.OffBoardReason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PeLocn).HasColumnName("Pe_Locn");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.Period).HasColumnType("datetime");

                entity.Property(e => e.ProjId).HasColumnName("Proj_Id");

                entity.Property(e => e.Reason)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StatusLvl).HasColumnName("Status_Lvl");
            });

            modelBuilder.Entity<RfpBugCapture>(entity =>
            {
                entity.ToTable("rfp_bug_capture");

                entity.Property(e => e.Id)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.BugDesc)
                    .IsRequired()
                    .HasColumnName("bug_desc");

                entity.Property(e => e.CreBy)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("cre_by");

                entity.Property(e => e.CreDate)
                    .HasColumnType("smalldatetime")
                    .HasColumnName("cre_date");

                entity.Property(e => e.EmailId)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("email_id");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsBug)
                    .IsRequired()
                    .HasMaxLength(1)
                    .HasColumnName("isBug");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("name");
            });

            modelBuilder.Entity<RfpDproposal>(entity =>
            {
                entity.ToTable("rfp_dproposal");

                entity.Property(e => e.Id)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.AssignTo)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("assign_to");

                entity.Property(e => e.CreBy)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("cre_by");

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasColumnName("cre_date");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.ProId)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("pro_id");

                entity.Property(e => e.QuesId).HasColumnName("ques_id");

                entity.Property(e => e.ResponseId).HasColumnName("response_id");

                entity.Property(e => e.UpdBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("upd_by");

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasColumnName("upd_date");
            });

            modelBuilder.Entity<RfpDquesresp>(entity =>
            {
                entity.ToTable("rfp_dquesresp");

                entity.Property(e => e.Id)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.AttachId)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("attach_id");

                entity.Property(e => e.CreBy)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cre_by");

                entity.Property(e => e.CreDate).HasColumnName("cre_date");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsEncrypted)
                    .HasColumnName("is_encrypted")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.QuesId)
                    .HasColumnType("decimal(18, 0)")
                    .HasColumnName("ques_id");

                entity.Property(e => e.ResStatus).HasColumnName("res_status");

                entity.Property(e => e.RespHtml).HasColumnName("resp_html");

                entity.Property(e => e.RespSfdt).HasColumnName("resp_sfdt");

                entity.Property(e => e.Response)
                    .IsRequired()
                    .HasColumnName("response");

                entity.Property(e => e.SecId).HasColumnName("sec_id");

                entity.Property(e => e.UpdBy)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("upd_by");

                entity.Property(e => e.UpdDate).HasColumnName("upd_date");
            });

            modelBuilder.Entity<RfpHproposal>(entity =>
            {
                entity.ToTable("rfp_hproposal");

                entity.Property(e => e.Id)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("id");

                entity.Property(e => e.ClientId).HasColumnName("client_id");

                entity.Property(e => e.Comments)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("comments");

                entity.Property(e => e.Config)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .HasColumnName("config")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CreBy)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("cre_by");

                entity.Property(e => e.CreDate)
                    .HasColumnType("datetime")
                    .HasColumnName("cre_date");

                entity.Property(e => e.DraftData).HasColumnName("draft_data");

                entity.Property(e => e.EngagementDetails).HasColumnName("engagement_details");

                entity.Property(e => e.ExpiryCount).HasColumnName("expiry_count");

                entity.Property(e => e.InvestmentDetails).HasColumnName("investment_details");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsClientEnv)
                    .HasColumnName("isClientEnv")
                    .HasDefaultValueSql("((10))");

                entity.Property(e => e.IsEngagement).HasColumnName("is_engagement");

                entity.Property(e => e.ProDomain).HasColumnName("pro_domain");

                entity.Property(e => e.ProjName)
                    .IsRequired()
                    .HasMaxLength(500)
                    .HasColumnName("proj_name");

                entity.Property(e => e.ProjStatus).HasColumnName("proj_status");

                entity.Property(e => e.UpdBy)
                    .HasMaxLength(20)
                    .HasColumnName("upd_by");

                entity.Property(e => e.UpdDate)
                    .HasColumnType("datetime")
                    .HasColumnName("upd_date");
            });

            modelBuilder.Entity<RfpHquesresp>(entity =>
            {
                entity.HasKey(e => e.QuesId);

                entity.ToTable("rfp_hquesresp");

                entity.Property(e => e.QuesId)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ques_id");

                entity.Property(e => e.CreBy)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("cre_by");

                entity.Property(e => e.CreDate).HasColumnName("cre_date");

                entity.Property(e => e.IsActive).HasColumnName("is_active");

                entity.Property(e => e.IsEnabled).HasColumnName("is_enabled");

                entity.Property(e => e.QuesStatus).HasColumnName("ques_status");

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasColumnName("question");

                entity.Property(e => e.UpdBy)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("upd_by");

                entity.Property(e => e.UpdDate).HasColumnName("upd_date");
            });

            modelBuilder.Entity<Rfpemailtemplate>(entity =>
            {
                entity.HasKey(e => e.Templateid)
                    .HasName("PK1_rfpemailtemplate");

                entity.ToTable("rfpemailtemplate");

                entity.Property(e => e.Templateid)
                    .HasColumnType("decimal(18, 0)")
                    .ValueGeneratedOnAdd()
                    .HasColumnName("templateid");

                entity.Property(e => e.Creby)
                    .HasMaxLength(100)
                    .HasColumnName("creby");

                entity.Property(e => e.Credate)
                    .HasColumnType("datetime")
                    .HasColumnName("credate");

                entity.Property(e => e.IsEnabled)
                    .HasColumnName("is_enabled")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.Isactive).HasColumnName("isactive");

                entity.Property(e => e.Templatebody).HasColumnName("templatebody");

                entity.Property(e => e.Templatedesc).HasColumnName("templatedesc");

                entity.Property(e => e.Templatename)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("templatename");

                entity.Property(e => e.Templatesubject)
                    .HasMaxLength(2000)
                    .HasColumnName("templatesubject");

                entity.Property(e => e.Updby)
                    .HasMaxLength(100)
                    .HasColumnName("updby");

                entity.Property(e => e.Upddate)
                    .HasColumnType("datetime")
                    .HasColumnName("upddate");
            });

            modelBuilder.Entity<RrApproval>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.Group, e.Locn, e.PeLogn });

                entity.ToTable("RR_APPROVAL");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.Group)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.Locn).HasColumnName("LOCN");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
