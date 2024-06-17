using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ResourceRequestService.Models.ServiceManagement;

namespace ResourceRequestService.Data
{
    public partial class ServiceManagementDbContext : DbContext
    {
        public ServiceManagementDbContext()
        {
        }

        public ServiceManagementDbContext(DbContextOptions<ServiceManagementDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<ExAccessLog> ExAccessLogs { get; set; }
        public virtual DbSet<ExPriorityMaster> ExPriorityMasters { get; set; }
        public virtual DbSet<ExProjectMaster> ExProjectMasters { get; set; }
        public virtual DbSet<ExRequestType> ExRequestTypes { get; set; }
        public virtual DbSet<ExRequesttran> ExRequesttrans { get; set; }
        public virtual DbSet<ExStatusMaster> ExStatusMasters { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ExAccessLog>(entity =>
            {
                entity.ToTable("EX_ACCESS_LOG");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Entrystamp)
                    .HasColumnType("datetime")
                    .HasColumnName("ENTRYSTAMP");

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.UserPelogn)
                    .HasMaxLength(150)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<ExPriorityMaster>(entity =>
            {
                entity.HasKey(e => e.PriorityId);

                entity.ToTable("EX_Priority_Master");

                entity.Property(e => e.PriorityId).HasColumnName("PriorityID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Priority)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Updateby)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExProjectMaster>(entity =>
            {
                entity.HasKey(e => e.ProjId)
                    .HasName("PK_Ex_PROJECT_Master");

                entity.ToTable("Ex_Project_Master");

                entity.Property(e => e.ProjId).HasColumnName("projID");

                entity.Property(e => e.ProjCreatedby)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("projCreatedby");

                entity.Property(e => e.ProjCreatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("projCreatedon");

                entity.Property(e => e.ProjName)
                    .HasMaxLength(100)
                    .IsUnicode(false)
                    .HasColumnName("projName");

                entity.Property(e => e.ProjStatus)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .HasColumnName("projStatus");

                entity.Property(e => e.ProjUpdatedby)
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("projUpdatedby");

                entity.Property(e => e.ProjUpdatedon)
                    .HasColumnType("datetime")
                    .HasColumnName("projUpdatedon");
            });

            modelBuilder.Entity<ExRequestType>(entity =>
            {
                entity.HasKey(e => e.ReqTypeId);

                entity.ToTable("EX_Request_Type");

                entity.Property(e => e.ReqTypeId).HasColumnName("ReqTypeID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.RequestType)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.Updateby)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExRequesttran>(entity =>
            {
                entity.HasKey(e => e.TranId);

                entity.ToTable("EX_REQUESTTRAN");

                entity.Property(e => e.TranId).HasColumnName("TranID");

                entity.Property(e => e.EngineerComments).IsUnicode(false);

                entity.Property(e => e.PriorityId).HasColumnName("PriorityID");

                entity.Property(e => e.ProjId).HasColumnName("ProjID");

                entity.Property(e => e.ReqTypeId).HasColumnName("ReqTypeID");

                entity.Property(e => e.TranActionBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TranActionOn).HasColumnType("datetime");

                entity.Property(e => e.TranAttachFileName)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.TranComments).IsUnicode(false);

                entity.Property(e => e.TranDesc).IsUnicode(false);

                entity.Property(e => e.TranRaiseOn).HasColumnType("datetime");

                entity.Property(e => e.TranRequestStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TranRequestor)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TranUpdateBy)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.TranUpdateOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ExStatusMaster>(entity =>
            {
                entity.HasKey(e => e.StatusId);

                entity.ToTable("EX_Status_Master");

                entity.Property(e => e.StatusId).HasColumnName("StatusID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Createdby)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.Status)
                    .HasMaxLength(1)
                    .IsUnicode(false);

                entity.Property(e => e.TranStatus)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Updateby)
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
