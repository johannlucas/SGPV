using System;
namespace SGPV.Models
{
    public class Fornecedor
    {
        public Guid Id { get; set; }
        public Guid IdCategoria { get; set; }
        public string Telefone { get; set; }
        public string Endereco { get; set; }
    }
}
