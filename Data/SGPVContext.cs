using Microsoft.EntityFrameworkCore;
using SGPV.Models;

namespace SGPV.Data
{
    public class SGPVContext : DbContext
    {
        public SGPVContext(DbContextOptions<SGPVContext> options) : base(options) { }

        public DbSet<Produto> Produto { get; set; }
    }
}
