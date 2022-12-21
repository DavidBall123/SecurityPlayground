using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using SecurityPlaygroundApi.Model;

namespace SecurityPlaygroundApi.DAL
{
    public class CertificateContext : DbContext
    {
        public CertificateContext() : base("CertificateContext")
        {

        }

        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }
    }
}
