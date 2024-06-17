using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ResourceRequestService.Models.EMPDATA;

namespace ResourceRequestService.Data
{
    public partial class EDMDbContext : DbContext
    {
        public EDMDbContext()
        {
        }

        public EDMDbContext(DbContextOptions<EDMDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<AmbaIplanmap> AmbaIplanmaps { get; set; }
        public virtual DbSet<EdmProc> EdmProcs { get; set; }
        public virtual DbSet<ExBenchreporting> ExBenchreportings { get; set; }
        public virtual DbSet<ExCompanyEntity> ExCompanyEntities { get; set; }
        public virtual DbSet<ExCompanyMaster> ExCompanyMasters { get; set; }
        public virtual DbSet<ExCompanyShiftMaster> ExCompanyShiftMasters { get; set; }
        public virtual DbSet<ExCompanySubEntity> ExCompanySubEntities { get; set; }
        public virtual DbSet<ExCompanyUnitMaster> ExCompanyUnitMasters { get; set; }
        public virtual DbSet<ExCustomerAdmin> ExCustomerAdmins { get; set; }
        public virtual DbSet<ExEditorialAllocation> ExEditorialAllocations { get; set; }
        public virtual DbSet<ExEffortsummary> ExEffortsummaries { get; set; }
        public virtual DbSet<ExEmploymentType> ExEmploymentTypes { get; set; }
        public virtual DbSet<ExEntityShiftMapping> ExEntityShiftMappings { get; set; }
        public virtual DbSet<ExIPcategoryLevel> ExIPcategoryLevels { get; set; }
        public virtual DbSet<ExIpbgcStatus> ExIpbgcStatuses { get; set; }
        public virtual DbSet<ExIpbgcVendormaster> ExIpbgcVendormasters { get; set; }
        public virtual DbSet<ExIpcategory> ExIpcategories { get; set; }
        public virtual DbSet<ExIpcategorySalaryBand> ExIpcategorySalaryBands { get; set; }
        public virtual DbSet<ExIpcity> ExIpcities { get; set; }
        public virtual DbSet<ExIpcountry> ExIpcountries { get; set; }
        public virtual DbSet<ExIpcustomer> ExIpcustomers { get; set; }
        public virtual DbSet<ExIpelement> ExIpelements { get; set; }
        public virtual DbSet<ExIplocationGeocode> ExIplocationGeocodes { get; set; }
        public virtual DbSet<ExIpperson> ExIppeople { get; set; }
        public virtual DbSet<ExIppersonAddress> ExIppersonAddresses { get; set; }
        public virtual DbSet<ExIppersonBgc> ExIppersonBgcs { get; set; }
        public virtual DbSet<ExIppersonBillable> ExIppersonBillables { get; set; }
        public virtual DbSet<ExIppersonCompensationLog> ExIppersonCompensationLogs { get; set; }
        public virtual DbSet<ExIppersonContractdetail> ExIppersonContractdetails { get; set; }
        public virtual DbSet<ExIppersonCourse> ExIppersonCourses { get; set; }
        public virtual DbSet<ExIppersonDept> ExIppersonDepts { get; set; }
        public virtual DbSet<ExIppersonDesg> ExIppersonDesgs { get; set; }
        public virtual DbSet<ExIppersonDesgAsOn23Nov2021> ExIppersonDesgAsOn23Nov2021s { get; set; }
        public virtual DbSet<ExIppersonDesgAsOn24Nov2021> ExIppersonDesgAsOn24Nov2021s { get; set; }
        public virtual DbSet<ExIppersonDesgCaValu1> ExIppersonDesgCaValu1s { get; set; }
        public virtual DbSet<ExIppersonDesgEnddateIsStartdate> ExIppersonDesgEnddateIsStartdates { get; set; }
        public virtual DbSet<ExIppersonDesgTmp> ExIppersonDesgTmps { get; set; }
        public virtual DbSet<ExIppersonDocdescMaster> ExIppersonDocdescMasters { get; set; }
        public virtual DbSet<ExIppersonDocstatusMaster> ExIppersonDocstatusMasters { get; set; }
        public virtual DbSet<ExIppersonEmployeeRecord> ExIppersonEmployeeRecords { get; set; }
        public virtual DbSet<ExIppersonEmployeeid> ExIppersonEmployeeids { get; set; }
        public virtual DbSet<ExIppersonEmployementtype> ExIppersonEmployementtypes { get; set; }
        public virtual DbSet<ExIppersonEntity> ExIppersonEntities { get; set; }
        public virtual DbSet<ExIppersonExitProcess> ExIppersonExitProcesses { get; set; }
        public virtual DbSet<ExIppersonExitreasonMaster> ExIppersonExitreasonMasters { get; set; }
        public virtual DbSet<ExIppersonFamilydet> ExIppersonFamilydets { get; set; }
        public virtual DbSet<ExIppersonHire> ExIppersonHires { get; set; }
        public virtual DbSet<ExIppersonLatesthiredate> ExIppersonLatesthiredates { get; set; }
        public virtual DbSet<ExIppersonLocation> ExIppersonLocations { get; set; }
        public virtual DbSet<ExIppersonNoticePeriod> ExIppersonNoticePeriods { get; set; }
        public virtual DbSet<ExIppersonNoticePeriodOldDatum> ExIppersonNoticePeriodOldData { get; set; }
        public virtual DbSet<ExIppersonOrgnrole> ExIppersonOrgnroles { get; set; }
        public virtual DbSet<ExIppersonPrevempoloyment> ExIppersonPrevempoloyments { get; set; }
        public virtual DbSet<ExIppersonResponsibility> ExIppersonResponsibilities { get; set; }
        public virtual DbSet<ExIppersonSbtrole> ExIppersonSbtroles { get; set; }
        public virtual DbSet<ExIppersonShiftTime> ExIppersonShiftTimes { get; set; }
        public virtual DbSet<ExIppersonTeamname> ExIppersonTeamnames { get; set; }
        public virtual DbSet<ExIppersonWelcomeaboard> ExIppersonWelcomeaboards { get; set; }
        public virtual DbSet<ExIppersonWorkPermitDetail> ExIppersonWorkPermitDetails { get; set; }
        public virtual DbSet<ExIppersonWorkingoffice> ExIppersonWorkingoffices { get; set; }
        public virtual DbSet<ExIppersonWorktype> ExIppersonWorktypes { get; set; }
        public virtual DbSet<ExIpteamName> ExIpteamNames { get; set; }
        public virtual DbSet<ExMailTemplate> ExMailTemplates { get; set; }
        public virtual DbSet<ExNamesMapping> ExNamesMappings { get; set; }
        public virtual DbSet<ExPersonIdAllocation> ExPersonIdAllocations { get; set; }
        public virtual DbSet<ExPoolMapping> ExPoolMappings { get; set; }
        public virtual DbSet<ExReportingManagerDel> ExReportingManagerDels { get; set; }
        public virtual DbSet<ExReportingmanager> ExReportingmanagers { get; set; }
        public virtual DbSet<ExReportingmanagerAsOn23Nov2021> ExReportingmanagerAsOn23Nov2021s { get; set; }
        public virtual DbSet<ExResourceSkill> ExResourceSkills { get; set; }
        public virtual DbSet<ExResourceclientanalyst> ExResourceclientanalysts { get; set; }
        public virtual DbSet<ExSeActivitySector> ExSeActivitySectors { get; set; }
        public virtual DbSet<ExSeActivitySectorHistoricalDatum> ExSeActivitySectorHistoricalData { get; set; }
        public virtual DbSet<ExSeActivitySectorLog> ExSeActivitySectorLogs { get; set; }
        public virtual DbSet<ExSeIndustrymaster> ExSeIndustrymasters { get; set; }
        public virtual DbSet<ExSeSectormaster> ExSeSectormasters { get; set; }
        public virtual DbSet<ExTakingManagerRecordsFrom120> ExTakingManagerRecordsFrom120s { get; set; }
        public virtual DbSet<ExTempPublicemail> ExTempPublicemails { get; set; }
        public virtual DbSet<ExWorkWiseToMrtDatum> ExWorkWiseToMrtData { get; set; }
        public virtual DbSet<ExceptionalEmployee> ExceptionalEmployees { get; set; }
        public virtual DbSet<IPLogin> IPLogins { get; set; }
        public virtual DbSet<IpCalendar> IpCalendars { get; set; }
        public virtual DbSet<IpCategory> IpCategories { get; set; }
        public virtual DbSet<IpCustomer> IpCustomers { get; set; }
        public virtual DbSet<IpElement> IpElements { get; set; }
        public virtual DbSet<IpLocation> IpLocations { get; set; }
        public virtual DbSet<IpOverview> IpOverviews { get; set; }
        public virtual DbSet<IpPerson> IpPeople { get; set; }
        public virtual DbSet<IpPersonAsOn23Nov2021> IpPersonAsOn23Nov2021s { get; set; }
        public virtual DbSet<IpPersonAsOn24Nov2021> IpPersonAsOn24Nov2021s { get; set; }
        public virtual DbSet<IpRolematch> IpRolematches { get; set; }
        public virtual DbSet<IplanProcsList> IplanProcsLists { get; set; }
        public virtual DbSet<Syncobj0x3041454532463741> Syncobj0x3041454532463741s { get; set; }
        public virtual DbSet<Syncobj0x3542374330434633> Syncobj0x3542374330434633s { get; set; }
        public virtual DbSet<Syncobj0x4130434246414335> Syncobj0x4130434246414335s { get; set; }
        public virtual DbSet<Syncobj0x4342313137304438> Syncobj0x4342313137304438s { get; set; }
        public virtual DbSet<Syncobj0x4444383944373336> Syncobj0x4444383944373336s { get; set; }
        public virtual DbSet<Syncobj0x4644463430313943> Syncobj0x4644463430313943s { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AmbaIplanmap>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("AMBA_IPLANMAP");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('A')")
                    .IsFixedLength();

                entity.Property(e => e.Activedirectoryname)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVEDIRECTORYNAME");

                entity.Property(e => e.Activedirectoryusername)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVEDIRECTORYUSERNAME");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("EmailID");

                entity.Property(e => e.EntryStamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.PeName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PE_NAME");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<EdmProc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EDM_Proc");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.IsMsShipped).HasColumnName("is_ms_shipped");

                entity.Property(e => e.IsPublished).HasColumnName("is_published");

                entity.Property(e => e.IsSchemaPublished).HasColumnName("is_schema_published");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modify_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name");

                entity.Property(e => e.ObjectId).HasColumnName("object_id");

                entity.Property(e => e.ParentObjectId).HasColumnName("parent_object_id");

                entity.Property(e => e.PrincipalId).HasColumnName("principal_id");

                entity.Property(e => e.SchemaId).HasColumnName("schema_id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("type")
                    .IsFixedLength()
                    .UseCollation("Latin1_General_CI_AS_KS_WS");

                entity.Property(e => e.TypeDesc)
                    .HasMaxLength(60)
                    .HasColumnName("type_desc")
                    .UseCollation("Latin1_General_CI_AS_KS_WS");
            });

            modelBuilder.Entity<ExBenchreporting>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_BENCHREPORTING");

                entity.Property(e => e.Dept)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.IpLocn).HasColumnName("IP_Locn");

                entity.Property(e => e.Mngrlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExCompanyEntity>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_CompanyEntity");

                entity.Property(e => e.BusinessUnitId)
                    .HasMaxLength(20)
                    .HasColumnName("BusinessUnit_ID");

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

                entity.Property(e => e.CntrlCc).HasColumnName("Cntrl_CC");

                entity.Property(e => e.CntrlEntityId).HasColumnName("Cntrl_EntityID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

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

                entity.Property(e => e.OfficeName).HasMaxLength(100);

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.RegistrationNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SiteName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();
            });

            modelBuilder.Entity<ExCompanyMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_CompanyMaster");

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

                entity.Property(e => e.CntrlCc).HasColumnName("Cntrl_CC");

                entity.Property(e => e.EntreredbY)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

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

            modelBuilder.Entity<ExCompanyShiftMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_CompanyShiftMaster");

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasMaxLength(20);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.ShiftEndTime).HasMaxLength(200);

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.ShiftName).HasMaxLength(200);

                entity.Property(e => e.ShiftStartTime).HasMaxLength(200);

                entity.Property(e => e.Status).HasMaxLength(1);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExCompanySubEntity>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Company_SubEntity");

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

                entity.Property(e => e.CcShortDesc)
                    .HasMaxLength(100)
                    .HasColumnName("CC_ShortDesc");

                entity.Property(e => e.CcSubUnitName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CC_SubUnitName");

                entity.Property(e => e.CntrlCc).HasColumnName("Cntrl_CC");

                entity.Property(e => e.CntrlEntityId).HasColumnName("Cntrl_EntityID");

                entity.Property(e => e.CntrlSubEntityId).HasColumnName("Cntrl_SubEntityID");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

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

            modelBuilder.Entity<ExCompanyUnitMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_CompanyUnitMaster");

                entity.Property(e => e.AddrLine1)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddrLine2)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddrLine3)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.AddrLine4)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.CntlCc).HasColumnName("Cntl_CC");

                entity.Property(e => e.CntlOc).HasColumnName("Cntl_OC");

                entity.Property(e => e.CntlUc).HasColumnName("Cntl_UC");

                entity.Property(e => e.CntrlEntityId).HasColumnName("Cntrl_EntityID");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.EmpSlno).HasColumnName("EmpSLNo");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.LocnId).HasColumnName("LocnID");

                entity.Property(e => e.OfficeEndTimeHh).HasColumnName("OfficeEndTime_HH");

                entity.Property(e => e.OfficeEndTimeMm).HasColumnName("OfficeEndTime_MM");

                entity.Property(e => e.OfficeStartTimeHh).HasColumnName("OfficeStartTime_HH");

                entity.Property(e => e.OfficeStartTimeMm).HasColumnName("OfficeStartTime_MM");

                entity.Property(e => e.OwnerName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RegistrationDate).HasColumnType("datetime");

                entity.Property(e => e.RegistrationNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ShortName)
                    .HasMaxLength(5)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UcName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UC_Name");
            });

            modelBuilder.Entity<ExCustomerAdmin>(entity =>
            {
                entity.HasKey(e => new { e.IplanCustid, e.IplanCustomername, e.IpLanPersonlOgin, e.Entrystamp });

                entity.ToTable("Ex_CUSTOMER_ADMIN");

                entity.Property(e => e.IplanCustid).HasColumnName("IPLAN_CUSTID");

                entity.Property(e => e.IplanCustomername)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("IPLAN_CUSTOMERNAME");

                entity.Property(e => e.IpLanPersonlOgin)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("IpLAN_PERSONlOGIN");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Comments)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.EntryAccess)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Entry_access")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

                entity.Property(e => e.IsAdmin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

                entity.Property(e => e.IsApprover)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

                entity.Property(e => e.IsBdadmin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IsBDAdmin")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

                entity.Property(e => e.IsCompAdmin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsDeptAdmin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsDeptFinance)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsDeptHr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IsDeptHR")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsDeptIt)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IsDeptIT")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsDeptMpm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IsDeptMPM")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsDeptSubs)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsDeptTkm)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IsDeptTKM")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsEdtlAdmin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsEquitAdmin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

                entity.Property(e => e.IsFicAdmin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

                entity.Property(e => e.IsPtadmin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IsPTAdmin")
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsQntsAdmin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

                entity.Property(e => e.IsSuperAdmin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')");

                entity.Property(e => e.IsTrajanAdmin)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.LoginRequired)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Login_Required")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

                entity.Property(e => e.ReportAccess)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Report_Access")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .HasDefaultValueSql("('A')")
                    .IsFixedLength();

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ViewAccess)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("View_access")
                    .HasDefaultValueSql("('N')")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ExEditorialAllocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_EDITORIAL_ALLOCATION");

                entity.Property(e => e.Allocation).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.Cnt).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExEffortsummary>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_EFFORTSUMMARY");

                entity.Property(e => e.AcIden).HasColumnName("AC_IDEN");

                entity.Property(e => e.AcName)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("AC_NAME");

                entity.Property(e => e.AmbBillable).HasColumnName("AMB_BILLABLE");

                entity.Property(e => e.Clientanalyst)
                    .HasMaxLength(120)
                    .IsUnicode(false)
                    .HasColumnName("CLIENTANALYST");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.DeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DE_DATE");

                entity.Property(e => e.DeEffo).HasColumnName("DE_EFFO");

                entity.Property(e => e.Group)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.NpRole)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("NP_ROLE");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.PhCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PH_CODE");

                entity.Property(e => e.PrCust)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PR_CUST");

                entity.Property(e => e.PrIden).HasColumnName("PR_IDEN");

                entity.Property(e => e.Projtype)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PROJTYPE");

                entity.Property(e => e.TtCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("TT_CODE");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("UPDATED_ON");
            });

            modelBuilder.Entity<ExEmploymentType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_EmploymentType");

                entity.Property(e => e.EmploymentTypeName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("EmploymentType_Name");

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasMaxLength(20);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("status")
                    .IsFixedLength();

                entity.Property(e => e.UserLognid)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExEntityShiftMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Entity_Shift_Mapping");

                entity.Property(e => e.CntrlEntityId).HasColumnName("Cntrl_EntityID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EndEntryStamp).HasColumnType("datetime");

                entity.Property(e => e.EndUserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("EndUserLognID");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(1);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIPcategoryLevel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_iPCategoryLevel");

                entity.Property(e => e.CaCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ca_code");

                entity.Property(e => e.CaLevel).HasColumnName("Ca_level");

                entity.Property(e => e.CaValu)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ca_valu");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExIpbgcStatus>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPBGC_STATUS");

                entity.Property(e => e.BgcstatusDesc).HasColumnName("BGCStatusDesc");

                entity.Property(e => e.BgcstatusId)
                    .HasMaxLength(20)
                    .HasColumnName("BGCStatusID");

                entity.Property(e => e.BgcstatusName)
                    .HasMaxLength(100)
                    .HasColumnName("BGCStatusName");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasMaxLength(40);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(2);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(40)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIpbgcVendormaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPBGC_VENDORMASTER");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy).HasMaxLength(20);

                entity.Property(e => e.LastupdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(1);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");

                entity.Property(e => e.VendorAddress1).HasMaxLength(1000);

                entity.Property(e => e.VendorAddress2).HasMaxLength(50);

                entity.Property(e => e.VendorAddress3).HasMaxLength(50);

                entity.Property(e => e.VendorCity).HasMaxLength(50);

                entity.Property(e => e.VendorCountry).HasMaxLength(50);

                entity.Property(e => e.VendorId).HasColumnName("VendorID");

                entity.Property(e => e.VendorLandline).HasMaxLength(50);

                entity.Property(e => e.VendorMobile).HasMaxLength(50);

                entity.Property(e => e.VendorName).HasMaxLength(200);

                entity.Property(e => e.VendorPinCode).HasMaxLength(50);
            });

            modelBuilder.Entity<ExIpcategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPCATEGORY");

                entity.Property(e => e.CaArch)
                    .HasMaxLength(1)
                    .HasColumnName("CA_ARCH");

                entity.Property(e => e.CaCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CA_CODE");

                entity.Property(e => e.CaName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("CA_NAME");

                entity.Property(e => e.CaOrdr).HasColumnName("CA_ORDR");

                entity.Property(e => e.CaValu)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CA_VALU");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.JobCode)
                    .HasMaxLength(20)
                    .HasColumnName("JOB_CODE");

                entity.Property(e => e.Lastupdatedby)
                    .HasMaxLength(20)
                    .HasColumnName("LASTUPDATEDBY");

                entity.Property(e => e.Lastupdatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("LASTUPDATEDON");

                entity.Property(e => e.Lob)
                    .HasMaxLength(50)
                    .HasColumnName("LOB");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(20)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIpcategorySalaryBand>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_IPCategory_SalaryBand");

                entity.Property(e => e.CaCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ca_code");

                entity.Property(e => e.CaSalaryband).HasColumnName("ca_salaryband");

                entity.Property(e => e.CaValu)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ca_valu");

                entity.Property(e => e.EndUserlognid).HasMaxLength(20);

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.EnddateStamp).HasColumnType("datetime");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExIpcity>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPCities");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .HasMaxLength(300)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.StateId).HasColumnName("state_id");
            });

            modelBuilder.Entity<ExIpcountry>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPCountries");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("name");

                entity.Property(e => e.Phonecode).HasColumnName("phonecode");

                entity.Property(e => e.Sortname)
                    .IsRequired()
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("sortname");
            });

            modelBuilder.Entity<ExIpcustomer>(entity =>
            {
                entity.HasKey(e => new { e.CuIden, e.CuSl });

                entity.ToTable("Ex_IPCUSTOMER");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.CuSl).HasColumnName("CU_SL");

                entity.Property(e => e.CuAccountmanager)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CU_ACCOUNTMANAGER");

                entity.Property(e => e.CuAddr1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CU_ADDR1");

                entity.Property(e => e.CuAddr2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CU_ADDR2");

                entity.Property(e => e.CuAddr3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CU_ADDR3");

                entity.Property(e => e.CuAddr4)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CU_ADDR4");

                entity.Property(e => e.CuBillingfrequency).HasColumnName("CU_BILLINGFREQUENCY");

                entity.Property(e => e.CuCode)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("CU_CODE");

                entity.Property(e => e.CuCurrencytypeid).HasColumnName("CU_CURRENCYTYPEID");

                entity.Property(e => e.CuEmailcc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CU_EMAILCC");

                entity.Property(e => e.CuEmailto)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("CU_EMAILTO");

                entity.Property(e => e.CuLocn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CU_LOCN");

                entity.Property(e => e.CuModeofbillid).HasColumnName("CU_MODEOFBILLID");

                entity.Property(e => e.CuName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("CU_NAME");

                entity.Property(e => e.CuTypeid).HasColumnName("CU_TYPEID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP")
                    .HasDefaultValueSql("(getdate())");

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

            modelBuilder.Entity<ExIpelement>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPELEMENT");

                entity.Property(e => e.CaCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CA_CODE");

                entity.Property(e => e.Deptcode)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("DEPTCODE");

                entity.Property(e => e.ElArch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EL_ARCH");

                entity.Property(e => e.ElCode)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EL_CODE");

                entity.Property(e => e.ElName)
                    .HasMaxLength(150)
                    .IsUnicode(false)
                    .HasColumnName("EL_NAME");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.ExtnElname)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EXTN_ELNAME");

                entity.Property(e => e.Lastupdatedby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATEDBY");

                entity.Property(e => e.Lastupdatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("LASTUPDATEDON");

                entity.Property(e => e.Loginid)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("LOGINID");

                entity.Property(e => e.RoleInd)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Role_Ind");
            });

            modelBuilder.Entity<ExIplocationGeocode>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPLOCATION_GEOCODE");

                entity.Property(e => e.GeoCode)
                    .HasMaxLength(50)
                    .HasColumnName("GEO_CODE");

                entity.Property(e => e.IpLocn).HasColumnName("IP_LOCN");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");
            });

            modelBuilder.Entity<ExIpperson>(entity =>
            {
                //entity.HasNoKey();

                entity.HasKey(e => e.PeLogn);

                entity.ToTable("EX_IPPERSON");

                entity.Property(e => e.AadharCardDob)
                    .HasColumnType("datetime")
                    .HasColumnName("AadharCard_DOB");

                entity.Property(e => e.AadharCardFatherName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("AadharCard_FatherName");

                entity.Property(e => e.AadharCardGender)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("AadharCard_Gender");

                entity.Property(e => e.AadharCardName)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("AadharCard_Name");

                entity.Property(e => e.AadharCardNo)
                    .HasMaxLength(18)
                    .IsUnicode(false)
                    .HasColumnName("AadharCard_No");

                entity.Property(e => e.AdDeactivatedDate)
                    .HasColumnType("datetime")
                    .HasColumnName("AD_Deactivated_Date");

                entity.Property(e => e.AlertFindStatus)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("AlertFind_Status");

                entity.Property(e => e.AlertFindUpdatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("AlertFind_UpdatedBy");

                entity.Property(e => e.AlertFindUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("AlertFind_UpdatedOn");

                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ApprovedEntryStamp).HasColumnType("datetime");

                entity.Property(e => e.BandWidth)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BankAc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("BankAC");

                entity.Property(e => e.BankActype)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("BankACType");

                entity.Property(e => e.BankName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BgvComments)
                    .IsUnicode(false)
                    .HasColumnName("BGV_Comments");

                entity.Property(e => e.BgvIniDt)
                    .HasColumnType("datetime")
                    .HasColumnName("BGV_Ini_Dt");

                entity.Property(e => e.BgvStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("BGV_Status");

                entity.Property(e => e.BgvVendorId).HasColumnName("BGV_VendorID");

                entity.Property(e => e.BgvclosureDate)
                    .HasColumnType("datetime")
                    .HasColumnName("BGVClosureDate");

                entity.Property(e => e.BirthPlace)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.BloodGroup)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Comments).IsUnicode(false);

                entity.Property(e => e.Configuration)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmationDate).HasColumnType("datetime");

                entity.Property(e => e.Confirmed)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ConfirmedAcknowledgedBy)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Confirmed_AcknowledgedBy");

                entity.Property(e => e.ConfirmedAcknowledgedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Confirmed_AcknowledgedOn");

                entity.Property(e => e.ConfirmedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.ConfirmedEntryStamp).HasColumnType("datetime");

                entity.Property(e => e.ConfirmedStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.CopalEmailId)
                    .HasMaxLength(400)
                    .IsUnicode(false)
                    .HasColumnName("CopalEmailID");

                entity.Property(e => e.CriminalBackVeri)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CriminalBack_Veri");

                entity.Property(e => e.CriminalDatabaseCheck)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CriminalDatabase_Check");

                entity.Property(e => e.DrugTestCompletionDate).HasColumnType("datetime");

                entity.Property(e => e.DrugTestStatus)
                    .HasMaxLength(3)
                    .IsUnicode(false)
                    .HasColumnName("DrugTest_Status");

                entity.Property(e => e.Ecnr)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ECNR");

                entity.Property(e => e.EduBackVeri)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EduBack_Veri");

                entity.Property(e => e.EmergencyContact)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyContactRelationId).HasColumnName("EmergencyContactRelationID");

                entity.Property(e => e.EmergencyLandLine)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EmergencyMobile)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.EntryStampTemp).HasColumnType("datetime");

                entity.Property(e => e.Esidespensary)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ESIDespensary");

                entity.Property(e => e.Esinumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ESINumber");

                entity.Property(e => e.ExitReasonDesc).HasMaxLength(2000);

                entity.Property(e => e.ExtnNo)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.FatherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.FunctMngrLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FunctMngr_Logn");

                entity.Property(e => e.Hobbies)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.Hrisid).HasColumnName("HRISID");

                entity.Property(e => e.Hukouid).HasColumnName("HUKOUID");

                entity.Property(e => e.IdbcompletionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDBCompletionDate");

                entity.Property(e => e.IdentityCheckCompletionDate).HasColumnType("datetime");

                entity.Property(e => e.Internet)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsEmpRetain).HasMaxLength(20);

                entity.Property(e => e.IsEsiapplicable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IsESIApplicable");

                entity.Property(e => e.IsFirstCompany).HasMaxLength(20);

                entity.Property(e => e.IsPfapplicable)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("IsPFApplicable");

                entity.Property(e => e.IsReHire).HasMaxLength(10);

                entity.Property(e => e.Isbillable)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("ISBillable");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastWorkingDate).HasColumnType("datetime");

                entity.Property(e => e.LastWorkingDateTemp).HasColumnType("datetime");

                entity.Property(e => e.LatestEmploymentChangeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Latest_Employment_Change_Date");

                entity.Property(e => e.LatestHireDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Latest_Hire_Date");

                entity.Property(e => e.MarriageDate).HasColumnType("datetime");

                entity.Property(e => e.MotherName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.NationalId)
                    .HasMaxLength(18)
                    .HasColumnName("NationalID");

                entity.Property(e => e.NiNumber)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("NI_Number");

                entity.Property(e => e.NortelExtnNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.OldMailId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Old_MailID");

                entity.Property(e => e.Pan)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PAN");

                entity.Property(e => e.PassportIssueDt).HasColumnType("datetime");

                entity.Property(e => e.PassportIssuePlace)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PassportName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.PaymentMode)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Pc)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PC");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.PerEmail)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PersonalEmail1)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PersonalEmail2)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.PersonalMailId)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Pfnumber)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PFNumber");

                entity.Property(e => e.PmsfinalRating)
                    .HasMaxLength(20)
                    .HasColumnName("PMSFinalRating");

                entity.Property(e => e.PoliceVeriDetail)
                    .IsUnicode(false)
                    .HasColumnName("PoliceVeri_Detail");

                entity.Property(e => e.PoliceVeriDt)
                    .HasColumnType("datetime")
                    .HasColumnName("PoliceVeri_Dt");

                entity.Property(e => e.PoliceVeriFromDt)
                    .HasColumnType("datetime")
                    .HasColumnName("PoliceVeri_FromDt");

                entity.Property(e => e.PoliceVeriRefNo)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PoliceVeri_RefNo");

                entity.Property(e => e.PoliceVeriToDt)
                    .HasColumnType("datetime")
                    .HasColumnName("PoliceVeri_ToDt");

                entity.Property(e => e.PrvEmpBackVeri)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PrvEmpBack_Veri");

                entity.Property(e => e.QuitDateTemp).HasColumnType("datetime");

                entity.Property(e => e.Reason)
                    .HasMaxLength(5000)
                    .IsUnicode(false);

                entity.Property(e => e.ResignationDate).HasColumnType("datetime");

                entity.Property(e => e.ResignationDateTemp).HasColumnType("datetime");

                entity.Property(e => e.ServiceLine)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("SERVICE_LINE");

                entity.Property(e => e.SourceHiringId).HasColumnName("SourceHiringID");

                entity.Property(e => e.Sports)
                    .HasMaxLength(2000)
                    .IsUnicode(false);

                entity.Property(e => e.SpouseDob)
                    .HasColumnType("datetime")
                    .HasColumnName("SpouseDOB");

                entity.Property(e => e.SpouseName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.StatusTemp)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TshirtSize)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("TShirt_Size");

                entity.Property(e => e.Uan)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("UAN");

                entity.Property(e => e.UpdatedByTemp)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");

                entity.Property(e => e.VisaValidity)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Visa_Validity");

                entity.Property(e => e.WwPersonId)
                    .HasMaxLength(20)
                    .HasColumnName("WW_PersonID");

                entity.Property(e => e.PersonType)
                   .HasMaxLength(1000)
                   .HasColumnName("PersonType");
            });

            modelBuilder.Entity<ExIppersonAddress>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_ADDRESS");

                entity.Property(e => e.OvPad1).HasColumnName("OV_PAD1");

                entity.Property(e => e.OvPad2).HasColumnName("OV_PAD2");

                entity.Property(e => e.OvPad3).HasColumnName("OV_PAD3");

                entity.Property(e => e.OvPcit).HasColumnName("OV_PCIT");

                entity.Property(e => e.OvPcnt).HasColumnName("OV_PCNT");

                entity.Property(e => e.OvPpin)
                    .HasMaxLength(50)
                    .HasColumnName("OV_PPIN");

                entity.Property(e => e.OvPsta).HasColumnName("OV_PSTA");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .HasColumnName("Pe_Logn");
            });

            modelBuilder.Entity<ExIppersonBgc>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_BGC");

                entity.Property(e => e.BgvComments).HasColumnName("bgv_comments");

                entity.Property(e => e.BgvIniDt)
                    .HasColumnType("datetime")
                    .HasColumnName("bgv_ini_dt");

                entity.Property(e => e.BgvStatus)
                    .HasMaxLength(10)
                    .HasColumnName("bgv_status");

                entity.Property(e => e.BgvVendorId).HasColumnName("BGV_VendorID");

                entity.Property(e => e.BgvclosureDate)
                    .HasColumnType("datetime")
                    .HasColumnName("BGVClosureDate");

                entity.Property(e => e.DrugTestCompletionDate).HasColumnType("datetime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EndEntrystamp).HasColumnType("datetime");

                entity.Property(e => e.EndUserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("EndUserLognID");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.IdbcompletionDate)
                    .HasColumnType("datetime")
                    .HasColumnName("IDBCompletionDate");

                entity.Property(e => e.IdentityCheckCompletionDate).HasColumnType("datetime");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasMaxLength(1);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonBillable>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_BILLABLE");

                entity.Property(e => e.BillableEnddt)
                    .HasColumnType("datetime")
                    .HasColumnName("BILLABLE_ENDDT");

                entity.Property(e => e.BillableStartdt)
                    .HasColumnType("datetime")
                    .HasColumnName("BILLABLE_STARTDT");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Isbillable)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ISBILLABLE");

                entity.Property(e => e.Lastupdatedby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATEDBY");

                entity.Property(e => e.Lastupdatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("LASTUPDATEDON");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIppersonCompensationLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPerson_Compensation_Log");

                entity.Property(e => e.CompCategory)
                    .HasMaxLength(50)
                    .HasColumnName("Comp_Category");

                entity.Property(e => e.CompType)
                    .HasMaxLength(10)
                    .HasColumnName("comp_type")
                    .IsFixedLength();

                entity.Property(e => e.Modifiedby)
                    .HasMaxLength(50)
                    .HasColumnName("modifiedby");

                entity.Property(e => e.Modifiedon)
                    .HasColumnType("datetime")
                    .HasColumnName("modifiedon");

                entity.Property(e => e.NewValue).HasColumnName("New_Value");

                entity.Property(e => e.OldValue).HasColumnName("Old_Value");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .HasColumnName("pe_logn");
            });

            modelBuilder.Entity<ExIppersonContractdetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_CONTRACTDETAILS");

                entity.Property(e => e.ContractEndDt)
                    .HasColumnType("datetime")
                    .HasColumnName("Contract_EndDt");

                entity.Property(e => e.ContractStartDt)
                    .HasColumnType("datetime")
                    .HasColumnName("Contract_StartDt");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserlognId)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExIppersonCourse>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_IPPERSON_COURSE");

                entity.Property(e => e.ApproveStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ApprovedBy).HasMaxLength(20);

                entity.Property(e => e.ApprovedOn).HasColumnType("datetime");

                entity.Property(e => e.CourseTypeId).HasColumnName("CourseTypeID");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.InstitutionName).HasMaxLength(2000);

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.QualificationId).HasColumnName("QualificationID");

                entity.Property(e => e.QualificationTypeId).HasColumnName("QualificationTypeID");

                entity.Property(e => e.UniversityId).HasColumnName("UniversityID");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonDept>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_DEPT");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.PeDept)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Dept");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonDesg>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_DESG");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.PeDesg)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Desg");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonDesgAsOn23Nov2021>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_DESG_as_On_23_Nov_2021");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.PeDesg)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Desg");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonDesgAsOn24Nov2021>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_DESG_as_on_24_Nov_2021");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.PeDesg)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Desg");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonDesgCaValu1>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_DESG_ca_valu_1");

                entity.Property(e => e.CaArch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CA_ARCH");

                entity.Property(e => e.CaCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CA_CODE");

                entity.Property(e => e.CaName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CA_NAME");

                entity.Property(e => e.CaOrdr).HasColumnName("CA_ORDR");

                entity.Property(e => e.CaValu)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CA_VALU");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.PeDesg)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Desg");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonDesgEnddateIsStartdate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ex_ipperson_desg_enddate_is_startdate");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.PeDesg)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Desg");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonDesgTmp>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ex_ipperson_desg_tmp");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.PeDesg)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Desg");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonDocdescMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_DOCDESC_MASTER");

                entity.Property(e => e.DocDescId).HasColumnName("Doc_Desc_Id");

                entity.Property(e => e.DocDescription)
                    .IsRequired()
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Doc_Description");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.IsApprovalRequired).HasMaxLength(3);

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LastUpdated_By");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdated_On");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonDocstatusMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_DOCSTATUS_MASTER");

                entity.Property(e => e.DocDescId).HasColumnName("Doc_Desc_Id");

                entity.Property(e => e.DocStatusId).HasColumnName("Doc_Status_Id");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LastUpdated_By");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdated_On");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonEmployeeRecord>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_EMPLOYEE_RECORDS");

                entity.Property(e => e.ApproveStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.ApprovedBy).HasMaxLength(20);

                entity.Property(e => e.ApprovedOn).HasColumnType("datetime");

                entity.Property(e => e.DocDescId).HasColumnName("Doc_Desc_Id");

                entity.Property(e => e.DocName)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("Doc_Name");

                entity.Property(e => e.DocTitle)
                    .IsRequired()
                    .HasMaxLength(2000)
                    .IsUnicode(false)
                    .HasColumnName("Doc_Title");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.LastUpdaetdOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdaetd_On");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LastUpdated_By");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(20)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLogn_Id");
            });

            modelBuilder.Entity<ExIppersonEmployeeid>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_EMPLOYEEID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.PeEmid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_emid");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonEmployementtype>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_EMPLOYEMENTTYPE");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.PeEmid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_emid");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonEntity>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_ENTITY");

                entity.Property(e => e.CntrlCc).HasColumnName("Cntrl_CC");

                entity.Property(e => e.CntrlEntityId).HasColumnName("Cntrl_EntityID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.PeLocn).HasColumnName("Pe_Locn");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonExitProcess>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_EXIT_PROCESS");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("entrystamp");

                entity.Property(e => e.Expectedrelivingdate)
                    .HasColumnType("datetime")
                    .HasColumnName("expectedrelivingdate");

                entity.Property(e => e.Hrcomments).HasColumnName("hrcomments");

                entity.Property(e => e.Hrstatus).HasColumnName("hrstatus");

                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Lastworkingday)
                    .HasColumnType("datetime")
                    .HasColumnName("lastworkingday");

                entity.Property(e => e.Managercomments).HasColumnName("managercomments");

                entity.Property(e => e.Managerstatus).HasColumnName("managerstatus");

                entity.Property(e => e.PeLmgr)
                    .HasMaxLength(20)
                    .HasColumnName("pe_lmgr");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .HasColumnName("pe_logn");

                entity.Property(e => e.Quitreason).HasColumnName("quitreason");

                entity.Property(e => e.Resignationsubmitdate)
                    .HasColumnType("datetime")
                    .HasColumnName("resignationsubmitdate");

                entity.Property(e => e.Usrlognid)
                    .HasMaxLength(20)
                    .HasColumnName("usrlognid");
            });

            modelBuilder.Entity<ExIppersonExitreasonMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_EXITREASON_MASTER");

                entity.Property(e => e.EnteredBy)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.ReasonDesc)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Reason_Desc");

                entity.Property(e => e.ReasonId).HasColumnName("Reason_ID");

                entity.Property(e => e.ReasonStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Reason_Status")
                    .IsFixedLength();
            });

            modelBuilder.Entity<ExIppersonFamilydet>(entity =>
            {
                entity.HasKey(e => new { e.PeLogn, e.Sl })
                    .HasName("PK_Ex_IPPerson_FamilyDet");

                entity.ToTable("EX_IPPERSON_FAMILYDET");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.ConfirmBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Confirm_By");

                entity.Property(e => e.ConfirmOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Confirm_On");

                entity.Property(e => e.ConfirmStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("Confirm_Status")
                    .HasDefaultValueSql("('P')")
                    .IsFixedLength();

                entity.Property(e => e.Dob)
                    .HasColumnType("datetime")
                    .HasColumnName("DOB");

                entity.Property(e => e.Dom)
                    .HasColumnType("datetime")
                    .HasColumnName("DOM");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LastUpdated_By");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LastUpdated_On");

                entity.Property(e => e.Name)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.Profession)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.RelationId).HasColumnName("RelationID");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonHire>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_HIRE");

                entity.Property(e => e.CreatedBy).HasMaxLength(20);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastWorkingDate).HasColumnType("datetime");

                entity.Property(e => e.PeJoin)
                    .HasColumnType("datetime")
                    .HasColumnName("Pe_Join");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.PeQuit)
                    .HasColumnType("datetime")
                    .HasColumnName("Pe_Quit");

                entity.Property(e => e.QuitBy).HasMaxLength(20);

                entity.Property(e => e.QuitOn).HasColumnType("datetime");

                entity.Property(e => e.ResignationDate).HasColumnType("datetime");

                entity.Property(e => e.SourceHiringId).HasColumnName("SourceHiringID");
            });

            modelBuilder.Entity<ExIppersonLatesthiredate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_LATESTHIREDATE");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Recordsource)
                    .HasMaxLength(50)
                    .HasColumnName("RECORDSOURCE");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDATE");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(20)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIppersonLocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_LOCATION");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.PeEmId)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("Pe_EmId");

                entity.Property(e => e.PeLocn).HasColumnName("Pe_Locn");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonNoticePeriod>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_Notice_Period");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.ExitDate).HasColumnType("datetime");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.ResignDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLogn).HasMaxLength(20);
            });

            modelBuilder.Entity<ExIppersonNoticePeriodOldDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_Notice_Period_OLD_DATA");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.ExitDate).HasColumnType("datetime");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.ResignDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy).HasMaxLength(20);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLogn).HasMaxLength(20);
            });

            modelBuilder.Entity<ExIppersonOrgnrole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_ORGNROLE");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.PeRole)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Role");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonPrevempoloyment>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_PREVEMPOLOYMENT");

                entity.Property(e => e.ApprovedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Approved_By");

                entity.Property(e => e.AprroveOn)
                    .HasColumnType("datetime")
                    .HasColumnName("Aprrove_On");

                entity.Property(e => e.CityId).HasColumnName("CityID");

                entity.Property(e => e.CompanyName)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.DesignationId)
                    .HasMaxLength(500)
                    .HasColumnName("DesignationID");

                entity.Property(e => e.EffectiveFromDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EffectiveFrom_Date");

                entity.Property(e => e.EffectiveToDate)
                    .HasColumnType("datetime")
                    .HasColumnName("EffectiveTO_Date");

                entity.Property(e => e.Entrystamp).HasColumnType("datetime");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("pe_logn");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WorktypeId).HasColumnName("WorktypeID");
            });

            modelBuilder.Entity<ExIppersonResponsibility>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_RESPONSIBILITY");

                entity.Property(e => e.CaCode)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CA_CODE");

                entity.Property(e => e.ElCode)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("EL_CODE");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.LastupdatedBy)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATED_BY");

                entity.Property(e => e.LastupdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("LASTUPDATED_ON");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Startdt)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDT");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userlognid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIppersonSbtrole>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_SBTROLE");

                entity.Property(e => e.CaCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("CA_CODE");

                entity.Property(e => e.ElCode)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("EL_CODE");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDate");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Type)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");
            });

            modelBuilder.Entity<ExIppersonShiftTime>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_ShiftTime");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.ShiftId).HasColumnName("ShiftID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserLognId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonTeamname>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_TEAMNAME");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Lognid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("LOGNID");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Startdt)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDT");

                entity.Property(e => e.Status)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.TnCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TN_CODE");
            });

            modelBuilder.Entity<ExIppersonWelcomeaboard>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_WELCOMEABOARD");

                entity.Property(e => e.Dept)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Description)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.DoB).HasColumnType("datetime");

                entity.Property(e => e.DoC).HasColumnType("datetime");

                entity.Property(e => e.Doj)
                    .HasColumnType("datetime")
                    .HasColumnName("DOJ");

                entity.Property(e => e.DomainAccount)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Email)
                    .HasMaxLength(150)
                    .IsUnicode(false);

                entity.Property(e => e.EmpNo)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Fbdays)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("FBDAYS");

                entity.Property(e => e.Gender)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.Image).HasColumnType("image");

                entity.Property(e => e.ImageName)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Itstatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("ITStatus")
                    .IsFixedLength();

                entity.Property(e => e.LastName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Location)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.MailStatusAll)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MailStatusBoard)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.MiddleName)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PublishStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Title)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.WinId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("WinID");
            });

            modelBuilder.Entity<ExIppersonWorkPermitDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_WORK_PERMIT_DETAIL");

                entity.Property(e => e.CountryId).HasColumnName("CountryID");

                entity.Property(e => e.EntryStmap).HasColumnType("datetime");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.IssueDate).HasColumnType("datetime");

                entity.Property(e => e.IssuingAuthority).HasMaxLength(2000);

                entity.Property(e => e.IssuingPlace).HasMaxLength(2000);

                entity.Property(e => e.LastUpdateBy).HasMaxLength(20);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .HasColumnName("pe_logn");

                entity.Property(e => e.Sl).HasColumnName("SL");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExIppersonWorkingoffice>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_WORKINGOFFICE");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UpdatedBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.WorkingOffice)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExIppersonWorktype>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPPERSON_WORKTYPE");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.Lastupdatedby)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("LASTUPDATEDBY");

                entity.Property(e => e.Lastupdatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("LASTUPDATEDON");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");

                entity.Property(e => e.Worktype).HasColumnName("WORKTYPE");

                entity.Property(e => e.WorktypeEnddt)
                    .HasColumnType("datetime")
                    .HasColumnName("WORKTYPE_ENDDT");

                entity.Property(e => e.WorktypeStartdt)
                    .HasColumnType("datetime")
                    .HasColumnName("WORKTYPE_STARTDT");
            });

            modelBuilder.Entity<ExIpteamName>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_IPTeamName");

                entity.Property(e => e.TnCode)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TN_CODE");

                entity.Property(e => e.TnEntrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("TN_ENTRYSTAMP");

                entity.Property(e => e.TnLognid)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TN_LOGNID");

                entity.Property(e => e.TnName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("TN_NAME");

                entity.Property(e => e.TnStatus)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("TN_STATUS");
            });

            modelBuilder.Entity<ExMailTemplate>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ex_Mail_Template");

                entity.Property(e => e.CreatedBy).HasMaxLength(100);

                entity.Property(e => e.Createdon).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.TemplateName).HasColumnName("Template_Name");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(100)
                    .HasColumnName("updatedby");

                entity.Property(e => e.Updatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedon");
            });

            modelBuilder.Entity<ExNamesMapping>(entity =>
            {
                entity.HasKey(e => e.PeLogn)
                    .HasName("PK_Ex_Names_Mapping");

                entity.ToTable("EX_NAMES_MAPPING");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.ShName)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("Sh_Name");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExPersonIdAllocation>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_PersonID_Allocation");

                entity.Property(e => e.Createdon).HasColumnType("datetime");

                entity.Property(e => e.LastPersonId).HasColumnName("LastPersonID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExPoolMapping>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_POOL_MAPPING");

                entity.Property(e => e.Allocation).HasColumnType("decimal(10, 2)");

                entity.Property(e => e.CuIden).HasColumnName("Cu_Iden");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.LeadLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Lead_Logn");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.PoolId).HasColumnName("Pool_Id");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExReportingManagerDel>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_ReportingManagerDel");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

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

                entity.Property(e => e.Group)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.Inscomment)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("INSCOMMENT");

                entity.Property(e => e.Insdate)
                    .HasColumnType("datetime")
                    .HasColumnName("INSDATE");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.Mngrlognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MNGRLOGNID");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Startdt)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDT");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");

                entity.Property(e => e.Valognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VALOGNID");
            });

            modelBuilder.Entity<ExReportingmanager>(entity =>
            {
                entity.ToTable("EX_REPORTINGMANAGER");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

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

                entity.Property(e => e.Group)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.Mngrlognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MNGRLOGNID");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Startdt)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDT");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");

                entity.Property(e => e.Valognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VALOGNID");
            });

            modelBuilder.Entity<ExReportingmanagerAsOn23Nov2021>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_REPORTINGMANAGER_As_On_23_Nov_2021");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.DateOfMove)
                    .HasColumnType("datetime")
                    .HasColumnName("DATE_OF_MOVE");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("ENDDATE");

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

                entity.Property(e => e.Group)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("GROUP");

                entity.Property(e => e.KickOff)
                    .HasColumnType("datetime")
                    .HasColumnName("KICK_OFF");

                entity.Property(e => e.Mngrlognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("MNGRLOGNID");

                entity.Property(e => e.ProjId).HasColumnName("PROJ_ID");

                entity.Property(e => e.Startdt)
                    .HasColumnType("datetime")
                    .HasColumnName("STARTDT");

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("STATUS")
                    .IsFixedLength();

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("USERLOGNID");

                entity.Property(e => e.Valognid)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("VALOGNID");
            });

            modelBuilder.Entity<ExResourceSkill>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCE_SKILL");

                entity.Property(e => e.ApproveBy).HasMaxLength(20);

                entity.Property(e => e.ApproveOn).HasColumnType("datetime");

                entity.Property(e => e.ApproveStatus).HasMaxLength(1);

                entity.Property(e => e.AquiredAt).HasMaxLength(50);

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.Proficiencyscale).HasColumnName("proficiencyscale");

                entity.Property(e => e.Requiredrefreshtime).HasColumnName("requiredrefreshtime");

                entity.Property(e => e.Shortskilldescription)
                    .HasMaxLength(2000)
                    .HasColumnName("shortskilldescription");

                entity.Property(e => e.SkillCode).HasMaxLength(10);

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(20)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExResourceclientanalyst>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_RESOURCECLIENTANALYST");

                entity.Property(e => e.AmbaLogn)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Amba_Logn");

                entity.Property(e => e.ClientAnal)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.ClientAnalystCostcenterNo)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("Client_analystCostcenterNo");

                entity.Property(e => e.ClientAnalystDesgn)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Client_analystDesgn");

                entity.Property(e => e.ClientAnalystEmail)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("Client_analystEmail");

                entity.Property(e => e.ClientAnalystEndDt)
                    .HasColumnType("datetime")
                    .HasColumnName("Client_analystEndDt");

                entity.Property(e => e.ClientAnalystName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Client_analystName");

                entity.Property(e => e.ClientAnalystPhone)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Client_analystPhone");

                entity.Property(e => e.ClientAnalystStartDt)
                    .HasColumnType("datetime")
                    .HasColumnName("Client_AnalystStartDt");

                entity.Property(e => e.ClientAnalystaddr1)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Client_analystaddr1");

                entity.Property(e => e.ClientAnalystaddr2)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Client_analystaddr2");

                entity.Property(e => e.ClientAnalystaddr3)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Client_analystaddr3");

                entity.Property(e => e.ClientAnalystaddr4)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Client_analystaddr4");

                entity.Property(e => e.ClientAnalystlocn)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Client_analystlocn");

                entity.Property(e => e.CuIden).HasColumnName("Cu_iden");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.MainAnalyst)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("Pe_logn");

                entity.Property(e => e.RecordType)
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.UserlognId)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("UserlognID");
            });

            modelBuilder.Entity<ExSeActivitySector>(entity =>
            {
                entity.HasKey(e => new { e.PrIden, e.AcIden, e.PeLogn })
                    .HasName("PK_Ex_SE_Activity_Sector");

                entity.ToTable("EX_SE_ACTIVITY_SECTOR");

                entity.Property(e => e.PrIden).HasColumnName("PR_IDEN");

                entity.Property(e => e.AcIden).HasColumnName("AC_IDEN");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.CatId).HasColumnName("Cat_Id");

                entity.Property(e => e.DeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("DE_DATE");

                entity.Property(e => e.EntryStamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IndId).HasColumnName("Ind_Id");

                entity.Property(e => e.RegId).HasColumnName("Reg_Id");

                entity.Property(e => e.SeId).HasColumnName("SE_Id");
            });

            modelBuilder.Entity<ExSeActivitySectorHistoricalDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_SE_ACTIVITY_SECTOR_HISTORICAL_DATA");

                entity.Property(e => e.AcIden).HasColumnName("Ac_Iden");

                entity.Property(e => e.CatId).HasColumnName("Cat_Id");

                entity.Property(e => e.CuIden).HasColumnName("cu_iden");

                entity.Property(e => e.DataGivenBy)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.DeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("De_Date");

                entity.Property(e => e.Effort).HasColumnType("decimal(15, 2)");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.IndId).HasColumnName("Ind_Id");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.PrIden).HasColumnName("Pr_Iden");

                entity.Property(e => e.RegId).HasColumnName("Reg_Id");

                entity.Property(e => e.SeId).HasColumnName("SE_Id");
            });

            modelBuilder.Entity<ExSeActivitySectorLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_SE_ACTIVITY_SECTOR_LOG");

                entity.Property(e => e.AcIden).HasColumnName("Ac_Iden");

                entity.Property(e => e.CatId).HasColumnName("Cat_Id");

                entity.Property(e => e.DeDate)
                    .HasColumnType("datetime")
                    .HasColumnName("De_Date");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.IndId).HasColumnName("Ind_Id");

                entity.Property(e => e.NoSector).HasColumnName("No_Sector");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("Pe_Logn");

                entity.Property(e => e.PrIden).HasColumnName("Pr_Iden");

                entity.Property(e => e.RegId).HasColumnName("Reg_Id");

                entity.Property(e => e.SeId).HasColumnName("SE_Id");
            });

            modelBuilder.Entity<ExSeIndustrymaster>(entity =>
            {
                entity.HasKey(e => new { e.SectorId, e.IndId })
                    .HasName("PK_Ex_SE_IndustryMaster");

                entity.ToTable("EX_SE_INDUSTRYMASTER");

                entity.Property(e => e.SectorId).HasColumnName("Sector_Id");

                entity.Property(e => e.IndId).HasColumnName("Ind_Id");

                entity.Property(e => e.EntryStamp)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IndName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Ind_Name");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExSeSectormaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_SE_SECTORMASTER");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.SeName)
                    .IsRequired()
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("Se_Name");

                entity.Property(e => e.SectorId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("Sector_Id");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UserId)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExTakingManagerRecordsFrom120>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_Taking_Manager_Records_From_120");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.PeArch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PE_ARCH");

                entity.Property(e => e.PeCrby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_CRBY");

                entity.Property(e => e.PeCrdt)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_CRDT");

                entity.Property(e => e.PeDept)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PE_DEPT");

                entity.Property(e => e.PeDesg)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PE_DESG");

                entity.Property(e => e.PeEmid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PE_EMID");

                entity.Property(e => e.PeIden).HasColumnName("PE_IDEN");

                entity.Property(e => e.PeJoin)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_JOIN");

                entity.Property(e => e.PeLmgr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LMGR");

                entity.Property(e => e.PeLocn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOCN");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.PeLopw)
                    .HasMaxLength(15)
                    .HasColumnName("PE_LOPW");

                entity.Property(e => e.PeMail)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PE_MAIL");

                entity.Property(e => e.PeMctc).HasColumnName("PE_MCTC");

                entity.Property(e => e.PeMoby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_MOBY");

                entity.Property(e => e.PeModt)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_MODT");

                entity.Property(e => e.PeName)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("PE_NAME");

                entity.Property(e => e.PeProx)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_PROX");

                entity.Property(e => e.PePswd)
                    .HasMaxLength(15)
                    .HasColumnName("PE_PSWD");

                entity.Property(e => e.PePtyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PE_PTYP");

                entity.Property(e => e.PeQuit)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_QUIT");
            });

            modelBuilder.Entity<ExTempPublicemail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_temp_Publicemail");

                entity.Property(e => e.Dept).HasColumnName("dept");

                entity.Property(e => e.Desg).HasColumnName("desg");

                entity.Property(e => e.Domainid).HasColumnName("domainid");

                entity.Property(e => e.Emailid).HasColumnName("emailid");

                entity.Property(e => e.Location).HasColumnName("location");

                entity.Property(e => e.Name).HasColumnName("name");

                entity.Property(e => e.Pelogn).HasColumnName("pelogn");

                entity.Property(e => e.Type).HasColumnName("type");
            });

            modelBuilder.Entity<ExWorkWiseToMrtDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_WorkWise_To_MRT_Data");

                entity.Property(e => e.CcName)
                    .HasMaxLength(100)
                    .HasColumnName("CC_NAME");

                entity.Property(e => e.EffectiveDate)
                    .HasMaxLength(100)
                    .HasColumnName("Effective_Date");

                entity.Property(e => e.EmploymentType).HasMaxLength(100);

                entity.Property(e => e.ErrorDescription).HasMaxLength(1000);

                entity.Property(e => e.EventName).HasMaxLength(100);

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.IsError)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.OvBrdt)
                    .HasMaxLength(100)
                    .HasColumnName("OV_BRDT");

                entity.Property(e => e.OvMale)
                    .HasMaxLength(100)
                    .HasColumnName("OV_MALE");

                entity.Property(e => e.OvNatl)
                    .HasMaxLength(100)
                    .HasColumnName("OV_NATL");

                entity.Property(e => e.OvPad1)
                    .HasMaxLength(250)
                    .HasColumnName("OV_PAD1");

                entity.Property(e => e.OvPad2)
                    .HasMaxLength(250)
                    .HasColumnName("OV_PAD2");

                entity.Property(e => e.OvPad3)
                    .HasMaxLength(250)
                    .HasColumnName("OV_PAD3");

                entity.Property(e => e.OvPcit)
                    .HasMaxLength(100)
                    .HasColumnName("OV_PCIT");

                entity.Property(e => e.OvPcnt)
                    .HasMaxLength(100)
                    .HasColumnName("OV_PCNT");

                entity.Property(e => e.OvPpin)
                    .HasMaxLength(100)
                    .HasColumnName("OV_PPIN");

                entity.Property(e => e.OvPsta)
                    .HasMaxLength(100)
                    .HasColumnName("OV_PSTA");

                entity.Property(e => e.OvSngl)
                    .HasMaxLength(100)
                    .HasColumnName("OV_SNGL");

                entity.Property(e => e.OvSsno)
                    .HasMaxLength(100)
                    .HasColumnName("OV_SSNO");

                entity.Property(e => e.PeDept)
                    .HasMaxLength(100)
                    .HasColumnName("PE_DEPT");

                entity.Property(e => e.PeDesg)
                    .HasMaxLength(100)
                    .HasColumnName("PE_DESG");

                entity.Property(e => e.PeEmid)
                    .HasMaxLength(100)
                    .HasColumnName("PE_EMID");

                entity.Property(e => e.PeJoin)
                    .HasMaxLength(100)
                    .HasColumnName("PE_JOIN");

                entity.Property(e => e.PeLmgr)
                    .HasMaxLength(100)
                    .HasColumnName("PE_LMGR");

                entity.Property(e => e.PeLocn)
                    .HasMaxLength(100)
                    .HasColumnName("PE_LOCN");

                entity.Property(e => e.PeMail)
                    .HasMaxLength(250)
                    .HasColumnName("PE_MAIL");

                entity.Property(e => e.PeName)
                    .HasMaxLength(200)
                    .HasColumnName("PE_NAME");

                entity.Property(e => e.PeQuit)
                    .HasMaxLength(100)
                    .HasColumnName("PE_Quit");

                entity.Property(e => e.StartDate).HasMaxLength(100);

                entity.Property(e => e.TriggeredStamp).HasColumnType("datetime");

                entity.Property(e => e.TriggeredStatus).HasMaxLength(500);

                entity.Property(e => e.WorkType).HasMaxLength(100);
            });

            modelBuilder.Entity<ExceptionalEmployee>(entity =>
            {
                entity.HasNoKey();

                entity.Property(e => e.EmpId)
                    .HasMaxLength(50)
                    .HasColumnName("Emp_ID");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");
            });

            modelBuilder.Entity<IPLogin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("iP_Login");

                entity.Property(e => e.LgLogn)
                    .IsRequired()
                    .HasMaxLength(256)
                    .IsUnicode(false)
                    .HasColumnName("LG_LOGN");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");
            });

            modelBuilder.Entity<IpCalendar>(entity =>
            {
                entity.HasKey(e => e.CaIden);

                entity.ToTable("IP_CALENDAR");

                entity.Property(e => e.CaIden)
                    .ValueGeneratedNever()
                    .HasColumnName("CA_IDEN");

                entity.Property(e => e.CaArch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CA_ARCH")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CaBase)
                    .HasColumnName("CA_BASE")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CaFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CA_FLAG");

                entity.Property(e => e.CaMida)
                    .HasColumnName("CA_MIDA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CaMiwk)
                    .HasColumnName("CA_MIWK")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CaMnda)
                    .HasColumnName("CA_MNDA")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CaMnwk)
                    .HasColumnName("CA_MNWK")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CaMxda)
                    .HasColumnName("CA_MXDA")
                    .HasDefaultValueSql("((1440))");

                entity.Property(e => e.CaMxwk)
                    .HasColumnName("CA_MXWK")
                    .HasDefaultValueSql("((10080))");

                entity.Property(e => e.CaName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CA_NAME");

                entity.Property(e => e.IpLocn)
                    .HasColumnName("IP_LOCN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.TzIden)
                    .HasColumnName("TZ_IDEN")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<IpCategory>(entity =>
            {
                entity.HasKey(e => e.CaCode);

                entity.ToTable("IP_CATEGORY");

                entity.Property(e => e.CaCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CA_CODE");

                entity.Property(e => e.CaArch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CA_ARCH")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.CaName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CA_NAME");

                entity.Property(e => e.CaOrdr)
                    .HasColumnName("CA_ORDR")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.CaValu)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CA_VALU");
            });

            modelBuilder.Entity<IpCustomer>(entity =>
            {
                entity.HasKey(e => e.CuIden);

                entity.ToTable("IP_CUSTOMER");

                entity.Property(e => e.CuIden)
                    .ValueGeneratedNever()
                    .HasColumnName("CU_IDEN");

                entity.Property(e => e.CuComp)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("CU_COMP");

                entity.Property(e => e.ExCuHmth).HasColumnName("EX_CU_HMTH");
            });

            modelBuilder.Entity<IpElement>(entity =>
            {
                entity.HasKey(e => new { e.ElCode, e.CaCode });

                entity.ToTable("IP_ELEMENT");

                entity.Property(e => e.ElCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("EL_CODE");

                entity.Property(e => e.CaCode)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CA_CODE");

                entity.Property(e => e.ElArch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EL_ARCH")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.ElName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EL_NAME");
            });

            modelBuilder.Entity<IpLocation>(entity =>
            {
                entity.HasKey(e => e.IpLocn);

                entity.ToTable("IP_LOCATION");

                entity.Property(e => e.IpLocn)
                    .ValueGeneratedNever()
                    .HasColumnName("IP_LOCN");

                entity.Property(e => e.LnCaid)
                    .HasColumnName("LN_CAID")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LnDblo)
                    .HasColumnName("LN_DBLO")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.LnName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("LN_NAME");

                entity.Property(e => e.TmpPeln)
                    .HasColumnName("TMP_PELN")
                    .HasDefaultValueSql("((0))");
            });

            modelBuilder.Entity<IpOverview>(entity =>
            {
                entity.HasKey(e => e.PeLogn);

                entity.ToTable("IP_OVERVIEW");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.OvBrdt)
                    .HasColumnType("datetime")
                    .HasColumnName("OV_BRDT");

                entity.Property(e => e.OvCad1)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("OV_CAD1");

                entity.Property(e => e.OvCad2)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("OV_CAD2");

                entity.Property(e => e.OvCad3)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("OV_CAD3");

                entity.Property(e => e.OvCcit)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("OV_CCIT");

                entity.Property(e => e.OvCcnt)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("OV_CCNT");

                entity.Property(e => e.OvCpin)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("OV_CPIN");

                entity.Property(e => e.OvCsta)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("OV_CSTA");

                entity.Property(e => e.OvCtel)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("OV_CTEL");

                entity.Property(e => e.OvMale)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OV_MALE");

                entity.Property(e => e.OvMtel)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("OV_MTEL");

                entity.Property(e => e.OvNatl)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("OV_NATL");

                entity.Property(e => e.OvOtel)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("OV_OTEL");

                entity.Property(e => e.OvPad1)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("OV_PAD1");

                entity.Property(e => e.OvPad2)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("OV_PAD2");

                entity.Property(e => e.OvPad3)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("OV_PAD3");

                entity.Property(e => e.OvPcit)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("OV_PCIT");

                entity.Property(e => e.OvPcnt)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("OV_PCNT");

                entity.Property(e => e.OvPpin)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("OV_PPIN");

                entity.Property(e => e.OvPsta)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("OV_PSTA");

                entity.Property(e => e.OvPtel)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("OV_PTEL");

                entity.Property(e => e.OvSngl)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("OV_SNGL");

                entity.Property(e => e.OvSsno)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("OV_SSNO");

                entity.Property(e => e.OvUsr1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("OV_USR1");

                entity.Property(e => e.OvUsr2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("OV_USR2");

                entity.Property(e => e.OvUsr3)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("OV_USR3");
            });

            modelBuilder.Entity<IpPerson>(entity =>
            {
                entity.HasKey(e => e.PeLogn);

                entity.ToTable("IP_PERSON");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.CuIden)
                    .HasColumnName("CU_IDEN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PeArch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PE_ARCH")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PeCrby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_CRBY");

                entity.Property(e => e.PeCrdt)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_CRDT");

                entity.Property(e => e.PeDept)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PE_DEPT");

                entity.Property(e => e.PeDesg)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PE_DESG");

                entity.Property(e => e.PeEmid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PE_EMID");

                entity.Property(e => e.PeIden)
                    .HasColumnName("PE_IDEN")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PeJoin)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_JOIN");

                entity.Property(e => e.PeLmgr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LMGR");

                entity.Property(e => e.PeLocn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOCN");

                entity.Property(e => e.PeLopw)
                    .HasMaxLength(15)
                    .HasColumnName("PE_LOPW");

                entity.Property(e => e.PeMail)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PE_MAIL");

                entity.Property(e => e.PeMctc)
                    .HasColumnName("PE_MCTC")
                    .HasDefaultValueSql("((0))");

                entity.Property(e => e.PeMoby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_MOBY");

                entity.Property(e => e.PeModt)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_MODT");

                entity.Property(e => e.PeName)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("PE_NAME");

                entity.Property(e => e.PeProx)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_PROX");

                entity.Property(e => e.PePswd)
                    .HasMaxLength(15)
                    .HasColumnName("PE_PSWD");

                entity.Property(e => e.PePtyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PE_PTYP")
                    .HasDefaultValueSql("('0')");

                entity.Property(e => e.PeQuit)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_QUIT");
            });

            modelBuilder.Entity<IpPersonAsOn23Nov2021>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ip_person_as_on_23_nov_2021");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.PeArch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PE_ARCH");

                entity.Property(e => e.PeCrby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_CRBY");

                entity.Property(e => e.PeCrdt)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_CRDT");

                entity.Property(e => e.PeDept)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PE_DEPT");

                entity.Property(e => e.PeDesg)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PE_DESG");

                entity.Property(e => e.PeEmid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PE_EMID");

                entity.Property(e => e.PeIden).HasColumnName("PE_IDEN");

                entity.Property(e => e.PeJoin)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_JOIN");

                entity.Property(e => e.PeLmgr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LMGR");

                entity.Property(e => e.PeLocn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOCN");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.PeLopw)
                    .HasMaxLength(15)
                    .HasColumnName("PE_LOPW");

                entity.Property(e => e.PeMail)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PE_MAIL");

                entity.Property(e => e.PeMctc).HasColumnName("PE_MCTC");

                entity.Property(e => e.PeMoby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_MOBY");

                entity.Property(e => e.PeModt)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_MODT");

                entity.Property(e => e.PeName)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("PE_NAME");

                entity.Property(e => e.PeProx)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_PROX");

                entity.Property(e => e.PePswd)
                    .HasMaxLength(15)
                    .HasColumnName("PE_PSWD");

                entity.Property(e => e.PePtyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PE_PTYP");

                entity.Property(e => e.PeQuit)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_QUIT");
            });

            modelBuilder.Entity<IpPersonAsOn24Nov2021>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("ip_person_as_on_24_nov_2021");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.PeArch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PE_ARCH");

                entity.Property(e => e.PeCrby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_CRBY");

                entity.Property(e => e.PeCrdt)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_CRDT");

                entity.Property(e => e.PeDept)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PE_DEPT");

                entity.Property(e => e.PeDesg)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PE_DESG");

                entity.Property(e => e.PeEmid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PE_EMID");

                entity.Property(e => e.PeIden).HasColumnName("PE_IDEN");

                entity.Property(e => e.PeJoin)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_JOIN");

                entity.Property(e => e.PeLmgr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LMGR");

                entity.Property(e => e.PeLocn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOCN");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.PeLopw)
                    .HasMaxLength(15)
                    .HasColumnName("PE_LOPW");

                entity.Property(e => e.PeMail)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PE_MAIL");

                entity.Property(e => e.PeMctc).HasColumnName("PE_MCTC");

                entity.Property(e => e.PeMoby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_MOBY");

                entity.Property(e => e.PeModt)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_MODT");

                entity.Property(e => e.PeName)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("PE_NAME");

                entity.Property(e => e.PeProx)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_PROX");

                entity.Property(e => e.PePswd)
                    .HasMaxLength(15)
                    .HasColumnName("PE_PSWD");

                entity.Property(e => e.PePtyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PE_PTYP");

                entity.Property(e => e.PeQuit)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_QUIT");
            });

            modelBuilder.Entity<IpRolematch>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("IP_ROLEMATCH");

                entity.Property(e => e.IpLocn).HasColumnName("IP_LOCN");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.PrIden).HasColumnName("PR_IDEN");

                entity.Property(e => e.RmAcby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RM_ACBY");

                entity.Property(e => e.RmAcdt)
                    .HasColumnType("datetime")
                    .HasColumnName("RM_ACDT");

                entity.Property(e => e.RmAltv).HasColumnName("RM_ALTV");

                entity.Property(e => e.RmBill).HasColumnName("RM_BILL");

                entity.Property(e => e.RmBilv).HasColumnName("RM_BILV");

                entity.Property(e => e.RmCaid).HasColumnName("RM_CAID");

                entity.Property(e => e.RmLink).HasColumnName("RM_LINK");

                entity.Property(e => e.RmLoad).HasColumnName("RM_LOAD");

                entity.Property(e => e.RmPlfi)
                    .HasColumnType("datetime")
                    .HasColumnName("RM_PLFI");

                entity.Property(e => e.RmPlst)
                    .HasColumnType("datetime")
                    .HasColumnName("RM_PLST");

                entity.Property(e => e.RmPrim).HasColumnName("RM_PRIM");

                entity.Property(e => e.RmRoid).HasColumnName("RM_ROID");

                entity.Property(e => e.RmRole)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("RM_ROLE");

                entity.Property(e => e.RmSkil)
                    .HasMaxLength(46)
                    .IsUnicode(false)
                    .HasColumnName("RM_SKIL");

                entity.Property(e => e.RmStat).HasColumnName("RM_STAT");

                entity.Property(e => e.RmUsr1)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("RM_USR1");

                entity.Property(e => e.RmUsr2)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("RM_USR2");

                entity.Property(e => e.RqIden).HasColumnName("RQ_IDEN");
            });

            modelBuilder.Entity<IplanProcsList>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("iplan_procs_List");

                entity.Property(e => e.CreateDate)
                    .HasColumnType("datetime")
                    .HasColumnName("create_date");

                entity.Property(e => e.IsMsShipped).HasColumnName("is_ms_shipped");

                entity.Property(e => e.IsPublished).HasColumnName("is_published");

                entity.Property(e => e.IsSchemaPublished).HasColumnName("is_schema_published");

                entity.Property(e => e.ModifyDate)
                    .HasColumnType("datetime")
                    .HasColumnName("modify_date");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(128)
                    .HasColumnName("name");

                entity.Property(e => e.ObjectId).HasColumnName("object_id");

                entity.Property(e => e.ParentObjectId).HasColumnName("parent_object_id");

                entity.Property(e => e.PrincipalId).HasColumnName("principal_id");

                entity.Property(e => e.SchemaId).HasColumnName("schema_id");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false)
                    .HasColumnName("type")
                    .IsFixedLength()
                    .UseCollation("Latin1_General_CI_AS_KS_WS");

                entity.Property(e => e.TypeDesc)
                    .HasMaxLength(60)
                    .HasColumnName("type_desc")
                    .UseCollation("Latin1_General_CI_AS_KS_WS");
            });

            modelBuilder.Entity<Syncobj0x3041454532463741>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("syncobj_0x3041454532463741");

                entity.Property(e => e.Active)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength();

                entity.Property(e => e.Activedirectoryname)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVEDIRECTORYNAME");

                entity.Property(e => e.Activedirectoryusername)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("ACTIVEDIRECTORYUSERNAME");

                entity.Property(e => e.EmailId)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("EmailID");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.PeLogn)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.PeName)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("PE_NAME");

                entity.Property(e => e.PersonId).HasColumnName("PersonID");

                entity.Property(e => e.Title)
                    .HasMaxLength(250)
                    .IsUnicode(false)
                    .HasColumnName("TITLE");
            });

            modelBuilder.Entity<Syncobj0x3542374330434633>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("syncobj_0x3542374330434633");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.PeArch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PE_ARCH");

                entity.Property(e => e.PeCrby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_CRBY");

                entity.Property(e => e.PeCrdt)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_CRDT");

                entity.Property(e => e.PeDept)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PE_DEPT");

                entity.Property(e => e.PeDesg)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("PE_DESG");

                entity.Property(e => e.PeEmid)
                    .HasMaxLength(15)
                    .IsUnicode(false)
                    .HasColumnName("PE_EMID");

                entity.Property(e => e.PeIden).HasColumnName("PE_IDEN");

                entity.Property(e => e.PeJoin)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_JOIN");

                entity.Property(e => e.PeLmgr)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LMGR");

                entity.Property(e => e.PeLocn)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOCN");

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_LOGN");

                entity.Property(e => e.PeLopw)
                    .HasMaxLength(15)
                    .HasColumnName("PE_LOPW");

                entity.Property(e => e.PeMail)
                    .HasMaxLength(60)
                    .IsUnicode(false)
                    .HasColumnName("PE_MAIL");

                entity.Property(e => e.PeMctc).HasColumnName("PE_MCTC");

                entity.Property(e => e.PeMoby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_MOBY");

                entity.Property(e => e.PeModt)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_MODT");

                entity.Property(e => e.PeName)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("PE_NAME");

                entity.Property(e => e.PeProx)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("PE_PROX");

                entity.Property(e => e.PePswd)
                    .HasMaxLength(15)
                    .HasColumnName("PE_PSWD");

                entity.Property(e => e.PePtyp)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("PE_PTYP");

                entity.Property(e => e.PeQuit)
                    .HasColumnType("datetime")
                    .HasColumnName("PE_QUIT");
            });

            modelBuilder.Entity<Syncobj0x4130434246414335>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("syncobj_0x4130434246414335");

                entity.Property(e => e.CaArch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CA_ARCH");

                entity.Property(e => e.CaBase).HasColumnName("CA_BASE");

                entity.Property(e => e.CaFlag)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CA_FLAG");

                entity.Property(e => e.CaIden).HasColumnName("CA_IDEN");

                entity.Property(e => e.CaMida).HasColumnName("CA_MIDA");

                entity.Property(e => e.CaMiwk).HasColumnName("CA_MIWK");

                entity.Property(e => e.CaMnda).HasColumnName("CA_MNDA");

                entity.Property(e => e.CaMnwk).HasColumnName("CA_MNWK");

                entity.Property(e => e.CaMxda).HasColumnName("CA_MXDA");

                entity.Property(e => e.CaMxwk).HasColumnName("CA_MXWK");

                entity.Property(e => e.CaName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CA_NAME");

                entity.Property(e => e.IpLocn).HasColumnName("IP_LOCN");

                entity.Property(e => e.TzIden).HasColumnName("TZ_IDEN");
            });

            modelBuilder.Entity<Syncobj0x4342313137304438>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("syncobj_0x4342313137304438");

                entity.Property(e => e.CuComp)
                    .HasMaxLength(45)
                    .IsUnicode(false)
                    .HasColumnName("CU_COMP");

                entity.Property(e => e.CuIden).HasColumnName("CU_IDEN");

                entity.Property(e => e.ExCuHmth).HasColumnName("EX_CU_HMTH");
            });

            modelBuilder.Entity<Syncobj0x4444383944373336>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("syncobj_0x4444383944373336");

                entity.Property(e => e.CaArch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CA_ARCH");

                entity.Property(e => e.CaCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CA_CODE");

                entity.Property(e => e.CaName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("CA_NAME");

                entity.Property(e => e.CaOrdr).HasColumnName("CA_ORDR");

                entity.Property(e => e.CaValu)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("CA_VALU");
            });

            modelBuilder.Entity<Syncobj0x4644463430313943>(entity =>
            {
                entity.HasNoKey();

                entity.ToView("syncobj_0x4644463430313943");

                entity.Property(e => e.CaCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("CA_CODE");

                entity.Property(e => e.ElArch)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("EL_ARCH");

                entity.Property(e => e.ElCode)
                    .IsRequired()
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasColumnName("EL_CODE");

                entity.Property(e => e.ElName)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("EL_NAME");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
