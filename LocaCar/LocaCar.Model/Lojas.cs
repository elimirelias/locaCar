using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCar.Model
{
    public class ValorDiaria {
        public decimal valorSemanalRegular { get; set; }
        public decimal valorSemanalFidelidade { get; set; }
        public decimal valorFDSRegular { get; set; }
        public decimal valorFDSFidelidade { get; set; }
    }

    public class SouthCar : ValorDiaria {
        public SouthCar() { 
            valorSemanalRegular = 210;
            valorSemanalFidelidade = 150;
            valorFDSRegular = 200;
            valorFDSFidelidade = 90;
        }
    }

    public class WestCar : ValorDiaria  {
        public WestCar() { 
            valorSemanalRegular  = 530; 
            valorSemanalFidelidade = 150; 
            valorFDSRegular = 200; 
            valorFDSFidelidade  = 90; 
        }
    }
    public class NorthCar : ValorDiaria {
        public NorthCar() { 
            valorSemanalRegular = 630; 
            valorSemanalFidelidade  = 580; 
            valorFDSRegular  = 600; 
            valorFDSFidelidade = 590; 
        }
    }

}
