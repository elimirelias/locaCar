using LocaCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocaCar.Models
{
    public class LocadoraViewModel
    {
        public Locadora locadora { get; set; }
        public decimal valorDiaria { get; set; }
        public bool temCartao { get; set; }

        public IEnumerable<Locadora> locadoras { get; set; }
    }
}