using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCar.Model
{
    public class LocadoraBusiness
    {
        public List<Locadora> CalculaLocacao(List<Locadora> locadoras)
        {
            foreach (var item in locadoras)
	        {
                switch (item.locacao.loja)
                {
                    case "SouthCar":
                        var south = new SouthCar();
                        south.CalculaLocacao(locadoras);
                        break;
                    case "WestCar":
                        break;
                    case "NorthCar":
                        break;
                }
	        }

            return false;
        }

    }


}
