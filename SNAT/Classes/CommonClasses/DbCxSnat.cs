using SNAT.Models;
using System.Configuration;
using System.Data.Entity;

namespace SNAT.Classes.CommonClasses
{
    internal class DbCxSnat : DbContext
    {
        
        public DbCxSnat() : base("snatburi_snat")
        {
            Database.Initialize(false);
        }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<DbCxSnat>(null);
            base.OnModelCreating(modelBuilder);
        }
 public DbSet<mLogin> MLogins { get; set; }

        public DbSet<mMember> mMembers { get; set; }

        public DbSet<mSchool> mSchools { get; set; }

        public System.Data.Entity.DbSet<SNAT.Models.mBeneficiary> mBeneficiaries { get; set; }

        public System.Data.Entity.DbSet<SNAT.Models.mMemberDocument> mMemberDocuments { get; set; }

        public System.Data.Entity.DbSet<SNAT.Models.mDocumentType> mDocumentTypes { get; set; }

        public System.Data.Entity.DbSet<SNAT.Models.mClaimDocType> mClaimDocTypes { get; set; }

        public System.Data.Entity.DbSet<SNAT.Models.mChequeDocType> mChequeDocTypes { get; set; }
        public System.Data.Entity.DbSet<SNAT.Models.mBeneficiryDocuments> mBeneficiryDocuments { get; set; }

        public System.Data.Entity.DbSet<SNAT.Models.mMemberWegesProcess> mMemberWegesProcesses { get; set; }

        public System.Data.Entity.DbSet<SNAT.Models.mWagesUpload> mWagesUploads { get; set; }
        //public DbSet<mProjectMenu> MProjectMenu { get; set; }
        //public DbSet<mUserRights> MUserRights { get; set; }

        //public DbSet<mDepartment> MDepartments { get; set; }
        //public DbSet<mDesignation> MDesignations { get; set; }
        //public DbSet<mEmployees> MEmployees { get; set; }
    }
}