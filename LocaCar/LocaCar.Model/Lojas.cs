using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCar.Model
{
    public class Locar
    {
        private LojaStrategy _lojaStrategy;

        public void SetLoja(LojaStrategy lojaStrategy) {
            _lojaStrategy = lojaStrategy;
        }

        public Locacao SetLocacao(Locacao locacao, DateTime data, bool temCartao)
        {
            //Seleciona a loja
            switch (locacao.loja) {
                case "WestCar": 
                    _lojaStrategy = new WestCar(); 
                    break;
                case "SouthCar": 
                    _lojaStrategy = new SouthCar(); 
                    break;
                default: 
                    _lojaStrategy = new NorthCar(); 
                    break;
            }

            locacao = _lojaStrategy.GetLocacao(locacao);
            locacao.ValorMenorDiaria = this.valorDiaria(locacao, data, temCartao);

            return locacao;
        }

        internal Decimal valorDiaria(Locacao locacao, DateTime data, bool temCartao)
        {
            int day = (int)data.DayOfWeek;
            Decimal valorDiaria = 0;

            if (day % 6 == 0) //sunday e saturday
            {
                if (temCartao)
                    valorDiaria = locacao.ValorFDSFidelidade;
                else
                    valorDiaria = locacao.ValorFDSRegular;
            }
            else
            {
                if (temCartao)
                    valorDiaria = locacao.ValorSemanalFidelidade;
                else
                    valorDiaria = locacao.ValorSemanalRegular;
            }

            return valorDiaria;
        }
    }

    //Usa o Design Pattern Strategy (Encapsula o comportamento em classes)
    public abstract class LojaStrategy
    {
        public abstract Locacao GetLocacao(Locacao locacao);
    }

    public class SouthCar : LojaStrategy 
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

    public class WestCar : LojaStrategy
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

    public class NorthCar : LojaStrategy
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
