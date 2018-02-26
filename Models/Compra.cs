using System;
namespace SGPV.Models
{
    public class Compra
    {
        public Guid Id { get; set; }
        public Guid IdVendedor { get; set; }
        public DateTime DataCompra { get; set; }
    }
}
