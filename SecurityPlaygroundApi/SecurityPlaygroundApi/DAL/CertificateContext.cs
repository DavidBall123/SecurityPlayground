using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting.Internal;
using SecurityPlaygroundApi.Model;

namespace SecurityPlaygroundApi.DAL
{
    public class CertificateContext : DbContext
    {
        public DbSet<Certificate> Certificates { get; set; }
        public DbSet<Subject> Subjects { get; set; }

        public CertificateContext(DbContextOptions<CertificateContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var env = new HostingEnvironment();

            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile($"appsettings.json", optional: true)
                .Build();

            var connectionString = configuration.GetConnectionString("CertificateContext");
            optionsBuilder.UseSqlServer(connectionString);

            
        }

    }
}
