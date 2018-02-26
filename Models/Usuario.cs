using System;
namespace SGPV.Models
{
    public class Usuario
    {
        public Guid Id { get; set; }
        public string NomeUsuario { get; set; }
        public int LoginUsuario { get; set; }
        public string Senha { get; set; }
        public double Valor { get; set; }
    }
}
