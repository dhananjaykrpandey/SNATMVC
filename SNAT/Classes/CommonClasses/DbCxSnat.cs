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

        public DbSet<mBeneficiary> mBeneficiaries { get; set; }

        public DbSet<mMemberDocument> mMemberDocuments { get; set; }

        public DbSet<mDocumentType> mDocumentTypes { get; set; }

        public DbSet<mClaimDocType> mClaimDocTypes { get; set; }

        public DbSet<mChequeDocType> mChequeDocTypes { get; set; }
        public DbSet<mBeneficiryDocuments> mBeneficiryDocuments { get; set; }

        public DbSet<mMemberWegesProcess> mMemberWegesProcesses { get; set; }

        public DbSet<mWagesUpload> mWagesUploads { get; set; }
        public DbSet<mEmployeeDetails> mEmployeeDetails { get; set; }
        

    }
}