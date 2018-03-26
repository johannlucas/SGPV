using System;
namespace SGPV.Models
{
    public class Pagamento
    {
        public Guid Id { get; set; }
        public String Nome { get; set; }
        public String Beneficiario { get; set; }
        public double Valor { get; set; }
        public DateTime Data { get; set; }
        public bool Pago { get; set; }
    }
}
