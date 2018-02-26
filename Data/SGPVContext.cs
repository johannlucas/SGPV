using Microsoft.EntityFrameworkCore;
using SGPV.Models;

namespace SGPV.Data
{
    public class SGPVContext : DbContext
    {
        public SGPVContext(DbContextOptions<SGPVContext> options) : base(options) { }

        public DbSet<Produto> Produto { get; set; }

        public DbSet<SGPV.Models.Venda> Venda { get; set; }

        public DbSet<SGPV.Models.ItemVenda> ItemVenda { get; set; }

        public DbSet<SGPV.Models.CategoriaFornecedores> CategoriaFornecedores { get; set; }

        public DbSet<SGPV.Models.Usuario> Usuario { get; set; }

        public DbSet<SGPV.Models.Vendedor> Vendedor { get; set; }

        public DbSet<SGPV.Models.Fornecedor> Fornecedor { get; set; }

        public DbSet<SGPV.Models.ItemCompra> ItemCompra { get; set; }

        public DbSet<SGPV.Models.Estoque> Estoque { get; set; }
    }
}
