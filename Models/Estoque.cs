using System;
namespace SGPV.Models
{
    public class Estoque
    {
        public Guid Id { get; set; }
        public Guid IdProduto { get; set; }
        public Guid IdCompra { get; set; }
        public double Valor { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataAtualizacao { get; set; }
    }
}
