using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCar.Model
{
    public class Locacao
    {
        public string loja { get; set; }
        public Decimal ValorSemanalRegular { get; set; }
        public Decimal ValorSemanalFidelidade { get; set; }
        public Decimal ValorFDSRegular { get; set; }
        public Decimal ValorFDSFidelidade { get; set; }
    }
}
