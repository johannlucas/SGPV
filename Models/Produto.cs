using System;
namespace SGPV.Models
{
    public class Produto
    {
        public Guid Id { get; set; }
        public string NomeProduto { get; set; }
        public string CategoriaProduto { get; set; }
        public double ValorVenda { get; set; }
        public string Referencia { get; set; }
        public string CodigoBarra { get; set; }
    }
}
