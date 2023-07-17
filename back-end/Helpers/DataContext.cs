using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using testAPI.Models;

namespace testAPI.Helpers
{
    public class DataContext : DbContext
    {
        protected readonly IConfiguration Configuration;

        public DataContext()
        {
        }

        public DataContext(DbContextOptions<DataContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     // No need to configure the connection here since it's already done in the constructor.
        //     base.OnConfiguring(optionsBuilder);
        // }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                IConfigurationRoot configuration = new ConfigurationBuilder()
                   .SetBasePath(Directory.GetCurrentDirectory())
                   .AddJsonFile("appsettings.json")
                   .Build();
                var connectionString = configuration.GetConnectionString("WebApiDatabase");
                optionsBuilder.UseSqlServer(connectionString);
            }
        }

        public DbSet<UserDetails> Users { get; set; }
    }
}
