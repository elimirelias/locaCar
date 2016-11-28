using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCar.Model
{
    //Usa o Design Pattern Chain of Responsability (Cadeia de responsabilidades)
    public interface ILocacao
    {
        Locacao GetLocacao(Locacao locacao);
    }
    
    public class WestCar : ILocacao
    {
        public Locacao GetLocacao(Locacao locacao)
        {
            if ("WestCar".Equals(locacao.loja))
            {
                locacao.ValorSemanalRegular = 530;
                locacao.ValorSemanalFidelidade = 150;
                locacao.ValorFDSRegular = 200;
                locacao.ValorFDSFidelidade = 90;

                return locacao;
            }
            else
            {
                return new SouthCar().GetLocacao(locacao);
            }
        }
    }

    public class SouthCar : ILocacao
    {
        public Locacao GetLocacao(Locacao locacao)
        {
            if ("SouthCar".Equals(locacao.loja))
            {
                locacao.ValorSemanalRegular = 210;
                locacao.ValorSemanalFidelidade = 150;
                locacao.ValorFDSRegular = 200;
                locacao.ValorFDSFidelidade = 90;

                return locacao;
            }
            else
            {
                return new NorthCar().GetLocacao(locacao);
            }
        }
    }

    public class NorthCar : ILocacao
    {
        public ILocacao Proxima { get; set; }

        public Locacao GetLocacao(Locacao locacao)
        {
            if ("NorthCar".Equals(locacao.loja))
            {
                locacao.ValorSemanalRegular = 630;
                locacao.ValorSemanalFidelidade = 580;
                locacao.ValorFDSRegular = 600;
                locacao.ValorFDSFidelidade = 590;

                return locacao;
            }
            else
            {
                return new LojaPadrao().GetLocacao(locacao);
            }
        }
    }

    public class LojaPadrao : ILocacao
    {
        public Locacao GetLocacao(Locacao locacao)
        {
            locacao.ValorSemanalRegular = 610;
            locacao.ValorSemanalFidelidade = 550;
            locacao.ValorFDSRegular = 590;
            locacao.ValorFDSFidelidade = 580;

            return locacao;
        }
    }
}
