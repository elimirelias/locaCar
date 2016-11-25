using LocaCar.Business;
using LocaCar.Model;
using LocaCar.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LocaCar.Controllers
{
    public class LocadoraController : Controller
    {
        public ActionResult Index(bool temCartao, int qtePessoas, DateTime dataIni, DateTime dataFim)
        {
            //Busca arquivo json contendo os dados das locadoras e os carros disponíveis
            string path = System.Web.HttpContext.Current.Request.PhysicalApplicationPath;
            string file = string.Format("{0}{1}", path, @"\Script\dadosLocadora.json");

            //Lê json e monta o Model com os dados
            List<Locadora> locadoras;
            using (StreamReader r = new StreamReader(file)) {
                string json = r.ReadToEnd();
                locadoras = JsonConvert.DeserializeObject<List<Locadora>>(json);
            }

            //Preenche as locações com os valores correspondentes de cada loja
            locadoras.ForEach(x => { x.locacao = (Locacao)new LocadoraBusiness().SetLocacao(x.locacao, dataIni, temCartao); });

            //Seleciona apenas os Veículos com capacidade de pessoas e disponíveis nas datas (com overlaps)
            locadoras = locadoras.Where(x => x.qteMaxPessoas >= qtePessoas && (x.dataIniDisponivel <= dataFim && x.dataFimDisponivel >= dataIni))
                        .OrderBy(x => x.locacao.ValorSemanalRegular) //Orderna pela locacao mais barata
                        .ToList();

            var model = new LocadoraViewModel();
            model.temCartao = temCartao;
            model.qtePessoas = qtePessoas;
            model.dataIniDisponivel = dataIni;
            model.dataFimDisponivel = dataFim;
            model.locadoras = locadoras;
            if(locadoras.Count > 0) // Locação mais barata
                model.valorDiaria = locadoras.Min(x => x.locacao.ValorMenorDiaria);

            return View(model);
        }

    }
}
