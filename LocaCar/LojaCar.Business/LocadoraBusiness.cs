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
        public Locacao SetLocacao(Locacao locacao, DateTime data, bool temCartao)
        {
            //Usa o Design Pattern Chain of Responsability (Cadeia de responsabilidades)
            ILocacao westcar = new WestCar();
            locacao = westcar.GetLocacao(locacao);
            locacao.ValorDiaria = this.valorDiaria(locacao, data, temCartao);

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
