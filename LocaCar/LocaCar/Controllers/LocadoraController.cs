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
            using (StreamReader r = new StreamReader(file))
            {
                string json = r.ReadToEnd();
                locadoras = JsonConvert.DeserializeObject<List<Locadora>>(json);
            }

            //Carros disponíveis nas datas
            locadoras = locadoras.Where(x => qtePessoas <= x.qteMaxPessoas && (x.dataIniDisponivel >= dataIni && x.dataFimDisponivel <= dataFim))
                                 .OrderBy(x => x.locacao.ValorSemanalFidelidade)
                                 .ToList();

            var model = new LocadoraViewModel();
            model.temCartao = temCartao;
            model.locadora = new Locadora();
            model.locadora.qteMaxPessoas = qtePessoas;
            model.locadora.dataIniDisponivel = dataIni;
            model.locadora.dataFimDisponivel = dataFim;
            model.locadoras = locadoras;

            if (locadoras.Count > 0) 
            { 
                int day = (int)dataIni.DayOfWeek;
                if (day == 0 && day == 6) //sunday e saturday
                {
                    if (temCartao)
                        model.valorDiaria = locadoras[0].locacao.ValorFDSFidelidade;
                    else
                        model.valorDiaria = locadoras[0].locacao.ValorFDSRegular;
                }
                else
                {
                    if (temCartao)
                        model.valorDiaria = locadoras[0].locacao.ValorSemanalFidelidade;
                    else
                        model.valorDiaria = locadoras[0].locacao.ValorSemanalRegular;
                }
            }

            return View(model);
        }

    }
}
