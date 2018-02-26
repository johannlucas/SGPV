using System;
namespace SGPV.Models
{
    public class ItemCompra
    {
        public Guid Id { get; set; }
        public Guid IdCompra { get; set; }
        public Guid IdProduto { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
    }
}
