using LocaCar.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LocaCar.Business
{
    public class LocadoraBusiness
    {
        private LocacaoStrategy _locacaoStrategy;

        public void SetLoja(LocacaoStrategy locacaoStrategy) {
            _locacaoStrategy = locacaoStrategy;
        }

        public Locacao SetLocacao(Locacao locacao, DateTime data, bool temCartao)
        {
            //Seleciona a loja
            switch (locacao.loja) {
                case "WestCar": 
                    _locacaoStrategy = new WestCar(); 
                    break;
                case "SouthCar": 
                    _locacaoStrategy = new SouthCar(); 
                    break;
                default: 
                    _locacaoStrategy = new NorthCar(); 
                    break;
            }

            locacao = _locacaoStrategy.GetLocacao(locacao);
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
}
