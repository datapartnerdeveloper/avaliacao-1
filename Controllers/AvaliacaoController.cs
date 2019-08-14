using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using avaliacoes.Models;
using System.Collections;
using System.Net.Mail;
using System.Net;

namespace dpApp.Controllers
{
    public class AvaliacaoController : Controller
    {
        private readonly AppDbContext _context;
        private SmtpClient smtpClient;

        //private readonly IEmailClientSender EmailClientSender;

        public AvaliacaoController(AppDbContext context, SmtpClient smtpClient)
        {
            _context = context;
            this.smtpClient = smtpClient;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: Avaliacao/Create
        public IActionResult Create()
        {

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("AvaliacaoId,Nome,Email,Ao1,Ao2,Ao2_1,Ao2_2,Ao3,Ao4,Ao5,Ao6,Ao7,Ao8,Ao9,Ao10,Ao11,Ao12,Ao13,Ao14,Ao15,Ao16,Ao17,Ao18,Ao19,Ao20,Ao21,Ao22,Ao23,Ao24,Ao25,Ao26,Ao27,Ao28,Ao29,Ao30,Ao31,Ao32,Ao33,Ao34,Ao35,Ao36,Ao37,Ao38,Ao39,Ao40,Ao41,Ao42,Ao43,Ao44,TipoAvaliacao,Criada_em")] Avaliacao avaliacao)
        {

            if (ModelState.IsValid)
            {

                // DEBUG
                TempData["DEBUG_DP"] = false;
                TempData["Restam"] = 0;
                TempData["R2"] = "";
                TempData["ReqAdesao"] = "";
                TempData["ReqBasico"] = "";
                TempData["ReqIntermediario"] = "";
                TempData["ReqPleno"] = "";
                TempData["NextNivel"] = "";
                TempData["Eletiva"] = "";
                TempData["GoTo"] = false;


                // CHECK EIXO INFO
                if (
                    avaliacao.Ao18 == 1 ||
                    avaliacao.Ao19 == 1 ||
                    avaliacao.Ao20 == 1 ||
                    avaliacao.Ao21 == 1 ||
                    avaliacao.Ao22 == 1

                    )
                {
                    TempData["EixoInfo"] = true;
                }
                else
                {
                    TempData["EixoInfo"] = false;
                }

                // COUNT EIXO INFO
                IList ArrayInfo = new ArrayList();

                if (avaliacao.Ao18 == 1) { ArrayInfo.Add("Ao18"); }
                if (avaliacao.Ao19 == 1) { ArrayInfo.Add("Ao19"); }
                if (avaliacao.Ao20 == 1) { ArrayInfo.Add("Ao20"); }
                if (avaliacao.Ao21 == 1) { ArrayInfo.Add("Ao21"); }
                if (avaliacao.Ao22 == 1) { ArrayInfo.Add("Ao22"); }


                var continfo = ArrayInfo.Count;
                if ((int)continfo >= 1 && (int)continfo <= 3)
                {
                    TempData["ContInfoInter"] = true;
                }
                else
                {
                    TempData["ContInfoInter"] = false;
                }

                if ((int)continfo >= 4)
                {
                    TempData["ContInfoPleno"] = true;
                }
                else
                {
                    TempData["ContInfoPleno"] = false;
                }


                // CHECK EIXO FISICO

                if (
                    avaliacao.Ao23 == 1 ||
                    avaliacao.Ao24 == 1 ||
                    avaliacao.Ao25 == 1 ||
                    avaliacao.Ao26 == 1 ||
                    avaliacao.Ao27 == 1 ||
                    avaliacao.Ao28 == 1 ||
                    avaliacao.Ao29 == 1 ||
                    avaliacao.Ao30 == 1 ||
                    avaliacao.Ao31 == 1 ||
                    avaliacao.Ao32 == 1 ||
                    avaliacao.Ao33 == 1
                    )
                {
                    TempData["EixoFisi"] = true;
                }
                else
                {
                    TempData["EixoFisi"] = false;
                }
                
                // COUNT EIXO FISICO
                IList ArrayFisi = new ArrayList();

                if (avaliacao.Ao23 == 1) { ArrayInfo.Add("Ao23"); }
                if (avaliacao.Ao24 == 1) { ArrayFisi.Add("Ao24"); }
                if (avaliacao.Ao25 == 1) { ArrayFisi.Add("Ao25"); }
                if (avaliacao.Ao26 == 1) { ArrayFisi.Add("Ao26"); }
                if (avaliacao.Ao27 == 1) { ArrayFisi.Add("Ao27"); }
                if (avaliacao.Ao28 == 1) { ArrayFisi.Add("Ao28"); }
                if (avaliacao.Ao29 == 1) { ArrayFisi.Add("Ao29"); }
                if (avaliacao.Ao30 == 1) { ArrayFisi.Add("Ao30"); }
                if (avaliacao.Ao31 == 1) { ArrayFisi.Add("Ao31"); }
                if (avaliacao.Ao32 == 1) { ArrayFisi.Add("Ao32"); }
                if (avaliacao.Ao33 == 1) { ArrayFisi.Add("Ao33"); }


                var contafisi = ArrayFisi.Count;
                if ((int)contafisi >= 1 && (int)contafisi <= 3)
                {
                    TempData["ContFisiInter"] = true;
                }
                else
                {
                    TempData["ContFisiInter"] = false;
                }

                if ((int)contafisi >= 4)
                {
                    TempData["ContFisiPleno"] = true;
                }
                else
                {
                    TempData["ContFisiPleno"] = false;
                }

                // CHECK EIXO ASSISTÊNCIAL
                if (
                     avaliacao.Ao34 == 1 ||
                     avaliacao.Ao35 == 1 ||
                     avaliacao.Ao36 == 1 ||
                     avaliacao.Ao37 == 1 ||
                     avaliacao.Ao38 == 1 ||
                     avaliacao.Ao39 == 1 ||
                     avaliacao.Ao40 == 1 ||
                     avaliacao.Ao41 == 1 ||
                     avaliacao.Ao42 == 1 ||
                     avaliacao.Ao43 == 1 ||
                     avaliacao.Ao44 == 1
                     )
                {
                    TempData["EixoAssi"] = true;
                }
                else
                {
                    TempData["EixoAssi"] = false;
                }

                // COUNT EIXO ASSISTÊNCIAL
                IList ArrayAssi = new ArrayList();

                if (avaliacao.Ao34 == 1) { ArrayAssi.Add("Ao34"); }
                if (avaliacao.Ao35 == 1) { ArrayAssi.Add("Ao35"); }
                if (avaliacao.Ao36 == 1) { ArrayAssi.Add("Ao36"); }
                if (avaliacao.Ao37 == 1) { ArrayAssi.Add("Ao37"); }
                if (avaliacao.Ao38 == 1) { ArrayAssi.Add("Ao38"); }
                if (avaliacao.Ao39 == 1) { ArrayAssi.Add("Ao39"); }
                if (avaliacao.Ao40 == 1) { ArrayAssi.Add("Ao40"); }
                if (avaliacao.Ao41 == 1) { ArrayAssi.Add("Ao41"); }
                if (avaliacao.Ao42 == 1) { ArrayAssi.Add("Ao42"); }
                if (avaliacao.Ao43 == 1) { ArrayAssi.Add("Ao43"); }
                if (avaliacao.Ao44 == 1) { ArrayAssi.Add("Ao44"); }

                var contassi = ArrayAssi.Count;
                if ((int)contassi >= 1 && (int)contassi <= 3)
                {
                    TempData["ContAssiInter"] = true;
                }
                else
                {
                    TempData["ContAssiInter"] = false;
                }

                if ((int)contassi >= 4)
                {
                    TempData["ContAssiPleno"] = true;
                }
                else
                {
                    TempData["ContAssiPleno"] = false;
                }




                // CONTA ADESÃO
                IList ArrayAdesYes = new ArrayList();

                if (avaliacao.Ao1 == 1) { ArrayAdesYes.Add("Ao1"); }
                if (avaliacao.Ao2 == 1) { ArrayAdesYes.Add("Ao2"); }
                if (avaliacao.Ao3 == 1) { ArrayAdesYes.Add("Ao3"); }
                if (avaliacao.Ao4 == 1) { ArrayAdesYes.Add("Ao4"); }
                if (avaliacao.Ao5 == 1) { ArrayAdesYes.Add("Ao5"); }
                if (avaliacao.Ao6 == 1) { ArrayAdesYes.Add("Ao6"); }
                if (avaliacao.Ao7 == 1) { ArrayAdesYes.Add("Ao7"); }

                var contadesyes = ArrayAdesYes.Count;


                // ADESÃO
                if ((int)contadesyes == 1 || (int)contadesyes <= 6)
                {
                    IList ArrayAdes = new ArrayList();

                    if (avaliacao.Ao1 == 2) { ArrayAdes.Add("Ao1"); }
                    if (avaliacao.Ao2 == 2) { ArrayAdes.Add("Ao2"); }
                    if (avaliacao.Ao3 == 2) { ArrayAdes.Add("Ao3"); }
                    if (avaliacao.Ao4 == 2) { ArrayAdes.Add("Ao4"); }
                    if (avaliacao.Ao5 == 2) { ArrayAdes.Add("Ao5"); }
                    if (avaliacao.Ao6 == 2) { ArrayAdes.Add("Ao6"); }
                    if (avaliacao.Ao7 == 2) { ArrayAdes.Add("Ao7"); }

                    var contades = ArrayAdes.Count;
                    if (contades <= 7)
                    {
                        TempData["ContAdes"] = true;
                    }
                    else
                    {
                        TempData["ContAdes"] = false;
                    }

                    TempData["ReqAdesao"] = true;
                    TempData["ReqBasico"] = false;
                    TempData["ReqIntermediario"] = false;
                    TempData["ReqPleno"] = false;
                    TempData["Restam"] = contades;
                    var Restam = TempData["Restam"];
                    var Acao = "";
                    if ((int)Restam == 1)
                    {
                        Acao = Restam + " ação obrigatória.";
                    }
                    else
                    {
                        Acao = Restam + " ações obrigatórias.";
                    }
                    avaliacao.TipoAvaliacao = "Nível Adesão";
                    TempData["NextNivel"] = "Nível Inicial";
                    TempData["Implementar"] = " " + Acao;
                }



                // CONTA INICIAL
                IList ArrayBasiYes = new ArrayList();


                if (avaliacao.Ao8 == 1) { ArrayBasiYes.Add("Ao8"); }
                if (avaliacao.Ao9 == 1) { ArrayBasiYes.Add("Ao9"); }
                if (avaliacao.Ao10 == 1) { ArrayBasiYes.Add("Ao10"); }
                if (avaliacao.Ao11 == 1) { ArrayBasiYes.Add("Ao11"); }
                if (avaliacao.Ao12 == 1) { ArrayBasiYes.Add("Ao12"); }
                if (avaliacao.Ao13 == 1) { ArrayBasiYes.Add("Ao13"); }
                if (avaliacao.Ao14 == 1) { ArrayBasiYes.Add("Ao14"); }
                if (avaliacao.Ao15 == 1) { ArrayBasiYes.Add("Ao15"); }
                if (avaliacao.Ao16 == 1) { ArrayBasiYes.Add("Ao16"); }
                if (avaliacao.Ao17 == 1) { ArrayBasiYes.Add("Ao17"); }

                var contbasiyes = ArrayBasiYes.Count;

                if (((int)contadesyes == 7 && contbasiyes <= 10) && (((int)continfo >= 1) && ((int)contafisi >= 1) && ((int)contassi >= 1)))
                {
                    TempData["GoTo"] = true;
                }
               

                // INICIAL
                    if (((int)contadesyes == 7 && contbasiyes <= 10) && (((int)continfo == 0) || ((int)contafisi == 0) || ((int)contassi == 0)) && ((bool)TempData["GoTo"] == false))
                {
                    IList ArrayBasi = new ArrayList();

                    if (avaliacao.Ao7 == 2) { ArrayBasi.Add("Ao7"); }
                    if (avaliacao.Ao8 == 2) { ArrayBasi.Add("Ao8"); }
                    if (avaliacao.Ao9 == 2) { ArrayBasi.Add("Ao9"); }
                    if (avaliacao.Ao10 == 2) { ArrayBasi.Add("Ao10"); }
                    if (avaliacao.Ao11 == 2) { ArrayBasi.Add("Ao11"); }
                    if (avaliacao.Ao12 == 2) { ArrayBasi.Add("Ao12"); }
                    if (avaliacao.Ao13 == 2) { ArrayBasi.Add("Ao13"); }
                    if (avaliacao.Ao14 == 2) { ArrayBasi.Add("Ao14"); }
                    if (avaliacao.Ao15 == 2) { ArrayBasi.Add("Ao15"); }
                    if (avaliacao.Ao16 == 2) { ArrayBasi.Add("Ao16"); }
                    if (avaliacao.Ao17 == 2) { ArrayBasi.Add("Ao17"); }

                    var contbasi = ArrayBasi.Count;
                    if ((int)contbasi <= 10)
                    {
                        TempData["ContBasi"] = true;
                    }
                    else
                    {
                        TempData["ContBasi"] = false;
                    }

                    TempData["ReqAdesao"] = true;
                    TempData["ReqBasico"] = true;
                    TempData["ReqIntermediario"] = false;
                    TempData["ReqPleno"] = false;
                    TempData["Restam"] = contbasi;
                    TempData["ContaInicial"] = contbasiyes;
                    TempData["Conta_eixo_info"] = continfo;
                    TempData["Conta_eixo_fisi"] = contafisi;
                    TempData["Conta_eixo_assi"] = contassi;

                    var Restam = TempData["Restam"];
                    avaliacao.TipoAvaliacao = "Nível Inicial";
                    TempData["NextNivel"] = "Nível Intermediário";
                    var Acao = "";
                    if ((int)Restam == 1)
                    {
                        Acao = Restam + " ação obrigatória.";
                    }
                    else
                    {
                        Acao = Restam + " ações obrigatórias.";
                    }
                    if (Restam != null)
                    {
                        TempData["Implementar"] = " " + Acao;
                    }
                    var eou = "";
                    if ((int)Restam == 0)
                    {
                        eou = "";
                    }
                    else
                    {
                        eou = "e(ou)";
                    }

                    if ((int)continfo == 0 || (int)contafisi == 0 || (int)contassi == 0)
                    {
                        TempData["Eletiva"] = " " + eou + "no mínimo 1 ação eletiva de cada eixo.";
                    }
                }


                // INTERMEDIÁRIO
                if (
                    ((int)contadesyes == 7 && (int)contbasiyes == 10) &&
                    (((int)continfo >= 1 && (int)continfo <= 3) || ((int)contafisi >= 1 && (int)contafisi <= 3) || ((int)contassi >= 1 && (int)contassi <= 3))&& ((bool)TempData["GoTo"] == true)
               )
                {
                    TempData["ReqAdesao"] = true;
                    TempData["ReqBasico"] = true;
                    TempData["ReqIntermediario"] = true;
                    TempData["ReqPleno"] = false;
                    TempData["Restam"] = 0;
                    avaliacao.TipoAvaliacao = "Nível Intermediário";
                    TempData["NextNivel"] = "Nível Pleno";
                    TempData["Eletiva"] = " no mínimo 4 ações eletivas de cada eixo.";

                }
                else
                {
                    TempData["ReqIntermediario"] = false;
                }




                // PLENO

                if (
               ((int)contadesyes == 7 && (int)contbasiyes == 10) && (((int)continfo >= 4) && ((int)contafisi >= 4) && ((int)contassi >= 4))

                     )
                {
                    TempData["ReqAdesao"] = true;
                    TempData["ReqBasico"] = true;
                    TempData["ReqIntermediario"] = true;
                    TempData["ReqPleno"] = true;
                    TempData["Eletiva"] = null;

                    avaliacao.TipoAvaliacao = "Nível Pleno";
                    TempData["NextNivel"] = null;
                }

                avaliacao.Criada_em = DateTime.Now;

                _context.Add(avaliacao);

                var create = await _context.SaveChangesAsync();

                // Envia o E-mail 
                await smtpClient.SendMailAsync(new MailMessage(
                    from: "noreply@seloamigodoidoso.saude.sp.gov.br",
                    to: "alopez@institutototum.com.br",
                    subject: "testes",
                    body:"testes"
                    ));

                //await EmailClientSender.SendAvaliacaoEmail(
                //    avaliacao.Email,
                //    avaliacao.Nome,
                //    avaliacao.TipoAvaliacao,
                //    avaliacao.Ao1,
                //    avaliacao.Ao2,
                //    avaliacao.Ao2_1,
                //    avaliacao.Ao2_2,
                //    avaliacao.Ao3,
                //    avaliacao.Ao4,
                //    avaliacao.Ao5,
                //    avaliacao.Ao6,
                //    avaliacao.Ao7,
                //    avaliacao.Ao8,
                //    avaliacao.Ao9,
                //    avaliacao.Ao10,
                //    avaliacao.Ao11,
                //    avaliacao.Ao12,
                //    avaliacao.Ao13,
                //    avaliacao.Ao14,
                //    avaliacao.Ao15,
                //    avaliacao.Ao16,
                //    avaliacao.Ao17,
                //    avaliacao.Ao18,
                //    avaliacao.Ao19,
                //    avaliacao.Ao20,
                //    avaliacao.Ao21,
                //    avaliacao.Ao22,
                //    avaliacao.Ao23,
                //    avaliacao.Ao24,
                //    avaliacao.Ao25,
                //    avaliacao.Ao26,
                //    avaliacao.Ao27,
                //    avaliacao.Ao28,
                //    avaliacao.Ao29,
                //    avaliacao.Ao30,
                //    avaliacao.Ao31,
                //    avaliacao.Ao32,
                //    avaliacao.Ao33,
                //    avaliacao.Ao34,
                //    avaliacao.Ao35,
                //    avaliacao.Ao36,
                //    avaliacao.Ao37,
                //    avaliacao.Ao38,
                //    avaliacao.Ao39,
                //    avaliacao.Ao40,
                //    avaliacao.Ao41,
                //    avaliacao.Ao42,
                //    avaliacao.Ao43,
                //    avaliacao.Ao44
                //    );

                TempData["Nivel"] = avaliacao.TipoAvaliacao;
                TempData["Nome"] = avaliacao.Nome;
                TempData["Email"] = avaliacao.Email;
                return RedirectToAction("Index");

            }
            return View(avaliacao);
        }

        private bool AvaliacaoExists(int id)
        {
            return _context.Avaliacao.Any(e => e.AvaliacaoId == id);
        }
    }
}
