using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCar.Model
{
    //Usa o Design Pattern Strategy (Encapsula o comportamento em classes)
    public abstract class LocacaoStrategy
    {
        public abstract Locacao GetLocacao(Locacao locacao);
    }

    public class SouthCar : LocacaoStrategy 
    {
        public override Locacao GetLocacao(Locacao locacao)
        {
            locacao.ValorSemanalRegular = 210;
            locacao.ValorSemanalFidelidade = 150;
            locacao.ValorFDSRegular = 200;
            locacao.ValorFDSFidelidade = 90;

            return locacao;
        }
    }

    public class WestCar : LocacaoStrategy
    {
        public override Locacao GetLocacao(Locacao locacao)
        {
            locacao.ValorSemanalRegular = 530;
            locacao.ValorSemanalFidelidade = 150;
            locacao.ValorFDSRegular = 200;
            locacao.ValorFDSFidelidade = 90;

            return locacao;
        }
    }

    public class NorthCar : LocacaoStrategy
    {
        public override Locacao GetLocacao(Locacao locacao)
        {
            locacao.ValorSemanalRegular = 630;
            locacao.ValorSemanalFidelidade = 580;
            locacao.ValorFDSRegular = 600;
            locacao.ValorFDSFidelidade = 590;

            return locacao;
        }
    }

}
