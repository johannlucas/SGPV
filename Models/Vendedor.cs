using System;
namespace SGPV.Models
{
    public class Vendedor
    {
        public Guid Id { get; set; }
        public Guid IdFornecedor { get; set; }
        public string NomeVendedor { get; set; }
        public string TelefoneVendedor { get; set; }
        public string Situacao { get; set; }
    }
}
