using AppWebCompleto.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AppWebCompleto.Controllers
{
    public class VeiculosController : Controller
    {
        // GET: Veiculos
        public ActionResult Adicionar()
        {
            ViewBag.Title = "Veiculos";
            ViewBag.Message = "Adicionar Veiculo:  ";

            return View();
        }

        public ActionResult Alterar(int id)
        {
            ViewBag.Title = "Veiculos";
            ViewBag.Message = "Alterar Id: " + id;

            var veiculo = new Veiculos();
            veiculo.GetVeiculo(id);
            ViewBag.Veiculo = veiculo;

            return View();
        }

        public ActionResult Excluir(int id)
        {
            ViewBag.Title = "Veiculos";
            ViewBag.Message = "Excluir Id: " + id;

            var veiculo = new Veiculos();
            veiculo.GetVeiculo(id);
            ViewBag.Veiculo = veiculo;

            return View();
        }

        [HttpPost]
        public void Salvar()
        {
            try
            {
                var veiculo = new Veiculos
                {
                    Id = Convert.ToInt32("0" + Request["id"]),
                    Nome = Request["nome"],
                    Modelo = Request["modelo"],
                    Ano = Convert.ToInt16(Request["fabricacao"]),
                    Fabricacao = Convert.ToInt16(Request["fabricacao"]),
                    Cor = Request["cor"],
                    Combustivel = Convert.ToByte(Request["combustivel"]),
                    Automatico = Convert.ToBoolean(Request["automatico"]),
                    Valor = Convert.ToDecimal(Request["valor"]),
                    Ativo = true
                };

                veiculo.Salvar();

                Response.Redirect("/Home/Veiculo");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro: " + ex.Message);
                throw;
            }
        }

        [HttpPost]
        public void Excluir()
        {
            var veiculo = new Veiculos();
            veiculo.Id = Convert.ToInt32("0" + Request["id"]);

            veiculo.Excluir();

            Response.Redirect("/Home/Veiculo");
        }
    }
}