using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ResourceRequestService.Models.CustomerFeedback;

namespace ResourceRequestService.Data
{
    public partial class CustomerFeedbackDbContext : DbContext
    {
        public CustomerFeedbackDbContext()
        {
        }

        public CustomerFeedbackDbContext(DbContextOptions<CustomerFeedbackDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExAssesmentFrequency> ExAssesmentFrequencies { get; set; }
        public virtual DbSet<ExAssesmentNomination> ExAssesmentNominations { get; set; }
        public virtual DbSet<ExAssesmentNominationDatum> ExAssesmentNominationData { get; set; }
        public virtual DbSet<ExAssesmentReminderLog> ExAssesmentReminderLogs { get; set; }
        public virtual DbSet<ExAssesmentSetup> ExAssesmentSetups { get; set; }
        public virtual DbSet<ExAssessmentScheduling> ExAssessmentSchedulings { get; set; }
        public virtual DbSet<ExCategory> ExCategories { get; set; }
        public virtual DbSet<ExContributor> ExContributors { get; set; }
        public virtual DbSet<ExFrequencyMaster> ExFrequencyMasters { get; set; }
        public virtual DbSet<ExQuestionBank> ExQuestionBanks { get; set; }
        public virtual DbSet<ExQuestionBankSetup> ExQuestionBankSetups { get; set; }
        public virtual DbSet<ExResponseType> ExResponseTypes { get; set; }
        public virtual DbSet<ExResponseTypeMaster> ExResponseTypeMasters { get; set; }
        public virtual DbSet<ExTmpContributor> ExTmpContributors { get; set; }
        public virtual DbSet<ExType> ExTypes { get; set; }
        public virtual DbSet<ExUserResponse> ExUserResponses { get; set; }
        public virtual DbSet<ExUserScoring> ExUserScorings { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExAssesmentFrequency>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_Assesment_Frequency");

                entity.Property(e => e.AssesmentId).HasColumnName("AssesmentID");

                entity.Property(e => e.EndDate).HasColumnType("datetime");

                entity.Property(e => e.FormFrequencyId).HasColumnName("FormFrequencyID");

                entity.Property(e => e.FrequencyId).HasColumnName("FrequencyID");

                entity.Property(e => e.StartDate).HasColumnType("datetime");

                entity.Property(e => e.Status)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExAssesmentNomination>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_Assesment_Nomination");

                entity.Property(e => e.AssesmentDepartment).HasColumnName("Assesment_Department");

                entity.Property(e => e.AssesmentDesignation).HasColumnName("Assesment_Designation");

                entity.Property(e => e.AssesmentId).HasColumnName("Assesment_Id");

                entity.Property(e => e.AssesmentLocation).HasColumnName("Assesment_Location");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createdon)
                    .HasColumnType("datetime")
                    .HasColumnName("createdon");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifiedon)
                    .HasColumnType("datetime")
                    .HasColumnName("modifiedon");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<ExAssesmentNominationDatum>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_Assesment_Nomination_data");

                entity.Property(e => e.AssesmentQbId).HasColumnName("Assesment_QB_ID");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createdon)
                    .HasColumnType("datetime")
                    .HasColumnName("createdon");

                entity.Property(e => e.CuIden).HasColumnName("cu_iden");

                entity.Property(e => e.Modifiedby).HasColumnName("modifiedby");

                entity.Property(e => e.Modifiedon)
                    .HasColumnType("datetime")
                    .HasColumnName("modifiedon");

                entity.Property(e => e.PeLogn).HasColumnName("Pe_logn");

                entity.Property(e => e.SessionId).HasColumnName("Session_Id");

                entity.Property(e => e.Status).HasColumnName("status");
            });

            modelBuilder.Entity<ExAssesmentReminderLog>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_Assesment_Reminder_logs");

                entity.Property(e => e.AssesmentId).HasColumnName("Assesment_Id");

                entity.Property(e => e.Createdby).HasColumnName("createdby");

                entity.Property(e => e.Createdon)
                    .HasColumnType("datetime")
                    .HasColumnName("createdon");

                entity.Property(e => e.Reminderdaretime)
                    .HasColumnType("datetime")
                    .HasColumnName("reminderdaretime");

                entity.Property(e => e.Userid).HasColumnName("userid");
            });

            modelBuilder.Entity<ExAssesmentSetup>(entity =>
            {
                entity.HasKey(e => e.AssessmentId);

                entity.ToTable("EX_Assesment_Setup");

                entity.Property(e => e.AssessmentId).HasColumnName("Assessment_ID");

                entity.Property(e => e.AssessmentComments)
                    .IsUnicode(false)
                    .HasColumnName("Assessment_comments");

                entity.Property(e => e.AssessmentEndDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Assessment_EndDate");

                entity.Property(e => e.AssessmentFrequency)
                    .IsUnicode(false)
                    .HasColumnName("Assessment_Frequency");

                entity.Property(e => e.AssessmentName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Assessment_Name");

                entity.Property(e => e.AssessmentOwner)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Assessment_Owner");

                entity.Property(e => e.AssessmentPurpose)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("Assessment_Purpose");

                entity.Property(e => e.AssessmentQbId).HasColumnName("Assessment_QB_ID");

                entity.Property(e => e.AssessmentStartDate)
                    .HasColumnType("datetime")
                    .HasColumnName("Assessment_StartDate");

                entity.Property(e => e.AssessmentStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Assessment_Status");

                entity.Property(e => e.AssessmentType)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("Assessment_Type");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("createdOn");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("createdby");

                entity.Property(e => e.CuIden).HasColumnName("Cu_Iden");

                entity.Property(e => e.ProjectName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Surveytype)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("surveytype");

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedOn");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .HasColumnName("updatedby");
            });

            modelBuilder.Entity<ExAssessmentScheduling>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_Assessment_Scheduling");

                entity.Property(e => e.AssessmentId).HasColumnName("Assessment_id");

                entity.Property(e => e.Enddate)
                    .HasColumnType("datetime")
                    .HasColumnName("enddate");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("entrystamp");

                entity.Property(e => e.LastupdatedBy)
                    .HasMaxLength(20)
                    .HasColumnName("lastupdated_by");

                entity.Property(e => e.LastupdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("lastupdated_on");

                entity.Property(e => e.RandomQuestion).HasMaxLength(200);

                entity.Property(e => e.Startdate)
                    .HasColumnType("datetime")
                    .HasColumnName("startdate");

                entity.Property(e => e.Status)
                    .HasMaxLength(2)
                    .HasColumnName("status");

                entity.Property(e => e.Userlognid)
                    .HasMaxLength(20)
                    .HasColumnName("userlognid");
            });

            modelBuilder.Entity<ExCategory>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_Category");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasMaxLength(50);

                entity.Property(e => e.PassingScore).HasColumnName("Passing Score");

                entity.Property(e => e.RandomSeq).HasColumnName("Random/Seq");

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<ExContributor>(entity =>
            {
                entity.ToTable("EX_Contributor");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.AssesmentId).HasColumnName("assesment_id");

                entity.Property(e => e.AssessmentStatus).HasMaxLength(100);

                entity.Property(e => e.Contributorcategory)
                    .HasMaxLength(1000)
                    .HasColumnName("contributorcategory");

                entity.Property(e => e.Designation).HasMaxLength(500);

                entity.Property(e => e.EnteredBy).HasMaxLength(200);

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Location).HasMaxLength(1000);

                entity.Property(e => e.MailId)
                    .HasMaxLength(1000)
                    .HasColumnName("MailID");

                entity.Property(e => e.PersonName).HasMaxLength(1000);

                entity.Property(e => e.PhoneNo).HasMaxLength(100);

                entity.Property(e => e.Status).HasMaxLength(100);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.Updatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedon");
            });

            modelBuilder.Entity<ExFrequencyMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_FrequencyMaster");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.FrequencyId).HasColumnName("FrequencyID");

                entity.Property(e => e.FrequencyName).HasMaxLength(1000);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasMaxLength(1000);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(1000)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExQuestionBank>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_QuestionBank");

                entity.Property(e => e.AssessmentQbId).HasColumnName("Assessment_QB_ID");

                entity.Property(e => e.CategoryId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasMaxLength(50);

                entity.Property(e => e.QuestionId)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("QuestionID");
            });

            modelBuilder.Entity<ExQuestionBankSetup>(entity =>
            {
                entity.HasKey(e => e.AssessmentQbId);

                entity.ToTable("EX_QuestionBank_Setup");

                entity.Property(e => e.AssessmentQbId).HasColumnName("Assessment_QB_ID");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("createdOn");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("createdby");

                entity.Property(e => e.QuestionBankName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("QuestionBank_Name");

                entity.Property(e => e.QuestionBankType)
                    .HasMaxLength(1000)
                    .IsUnicode(false)
                    .HasColumnName("QuestionBank_Type");

                entity.Property(e => e.Status).HasMaxLength(50);

                entity.Property(e => e.UpdatedOn)
                    .HasColumnType("datetime")
                    .HasColumnName("updatedOn");

                entity.Property(e => e.Updatedby)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("updatedby");
            });

            modelBuilder.Entity<ExResponseType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_ResponseType");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasMaxLength(50);

                entity.Property(e => e.Response1).IsUnicode(false);

                entity.Property(e => e.Response10).IsUnicode(false);

                entity.Property(e => e.Response11).IsUnicode(false);

                entity.Property(e => e.Response12).IsUnicode(false);

                entity.Property(e => e.Response2).IsUnicode(false);

                entity.Property(e => e.Response3).IsUnicode(false);

                entity.Property(e => e.Response4).IsUnicode(false);

                entity.Property(e => e.Response5).IsUnicode(false);

                entity.Property(e => e.Response6).IsUnicode(false);

                entity.Property(e => e.Response7).IsUnicode(false);

                entity.Property(e => e.Response8).IsUnicode(false);

                entity.Property(e => e.Response9).IsUnicode(false);
            });

            modelBuilder.Entity<ExResponseTypeMaster>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Ex_ResponseTypeMaster");

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.ResponseName).HasMaxLength(1000);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedBy).HasMaxLength(1000);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.UserLognId)
                    .HasMaxLength(1000)
                    .HasColumnName("UserLognID");
            });

            modelBuilder.Entity<ExTmpContributor>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_TMP_contributor");

                entity.Property(e => e.Cuiden).HasColumnName("cuiden");

                entity.Property(e => e.EnteredBy).HasMaxLength(20);

                entity.Property(e => e.EntryStamp).HasColumnType("datetime");

                entity.Property(e => e.Id)
                    .ValueGeneratedOnAdd()
                    .HasColumnName("ID");

                entity.Property(e => e.MailId)
                    .HasMaxLength(1000)
                    .HasColumnName("MailID");

                entity.Property(e => e.PersonName).HasMaxLength(1000);

                entity.Property(e => e.PhoneNo).HasMaxLength(100);

                entity.Property(e => e.Role).HasMaxLength(500);
            });

            modelBuilder.Entity<ExType>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_Type");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasMaxLength(50);

                entity.Property(e => e.TypeId).HasColumnName("TypeID");
            });

            modelBuilder.Entity<ExUserResponse>(entity =>
            {
                entity.ToTable("EX_User_Response");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Assesmentid).HasColumnName("assesmentid");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasColumnType("datetime");

                entity.Property(e => e.QuestionId).HasColumnName("QuestionID");

                entity.Property(e => e.Usermailid)
                    .HasMaxLength(500)
                    .IsUnicode(false)
                    .HasColumnName("usermailid");
            });

            modelBuilder.Entity<ExUserScoring>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("EX_User_Scoring");

                entity.Property(e => e.CategoryId).HasColumnName("CategoryID");

                entity.Property(e => e.CreatedBy).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasMaxLength(50);

                entity.Property(e => e.DateTime).HasMaxLength(50);

                entity.Property(e => e.ModifiedBy).HasMaxLength(50);

                entity.Property(e => e.ModifiedOn).HasMaxLength(50);

                entity.Property(e => e.PeLogn)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("pe_logn");

                entity.Property(e => e.Sl).HasColumnName("sl");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
