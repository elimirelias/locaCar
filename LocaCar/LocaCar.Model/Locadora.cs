using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCar.Model
{
    public class Locadora
    {
        public Locacao locacao { get; set; }
        public string loja { get; set; }
        public string tipoCarro { get; set; }
        public int qteMaxPessoas { get; set; }
        public string modelo { get; set; }
        public DateTime dataIniDisponivel { get; set; }
        public DateTime dataFimDisponivel { get; set; }
    }
}
