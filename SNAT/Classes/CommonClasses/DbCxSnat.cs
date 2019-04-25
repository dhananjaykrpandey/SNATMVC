using SNAT.Models;
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
        //public DbSet<mProjectMenu> MProjectMenu { get; set; }
        //public DbSet<mUserRights> MUserRights { get; set; }
       
        //public DbSet<mDepartment> MDepartments { get; set; }
        //public DbSet<mDesignation> MDesignations { get; set; }
        //public DbSet<mEmployees> MEmployees { get; set; }
    }
}