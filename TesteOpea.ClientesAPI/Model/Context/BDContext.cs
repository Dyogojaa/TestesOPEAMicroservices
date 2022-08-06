using Microsoft.EntityFrameworkCore;

namespace TesteOpea.ClientesAPI.Model.Context
{
    public class BDContext : DbContext
    {

        protected readonly IConfiguration Configuration;

        public BDContext(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            // connect to sql server with connection string from app settings
            options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
        }

        public DbSet<Cliente> Clientes { get; set; }



    }
}
