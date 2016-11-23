using LocaCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LocaCar.Models
{
    public class LocadoraViewModel
    {
        public DateTime DataIni { get; set; }
        public DateTime DataFim { get; set; }
        public int qtePessoas { get; set; }
        public decimal ValorDiaria { get; set; }
        public bool temCartao { get; set; }

        public IEnumerable<Locadora> locadoras { get; set; }
    }
}