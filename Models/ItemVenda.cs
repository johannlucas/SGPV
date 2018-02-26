using System;
namespace SGPV.Models
{
    public class ItemVenda
    {
        public Guid Id { get; set; }
        public Guid IdVenda { get; set; }
        public Guid IdProduto { get; set; }
        public int Quantidade { get; set; }
        public double Valor { get; set; }
    }
}
