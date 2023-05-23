using DATA.UPD8;
using Domain.UPD8.Entidades;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using UPD8.Web.Models;

namespace UPD8.Web.Controllers
{
    public class AutenticacoesController : Controller
    {
        private readonly AutenticacaoDBContext db;


        public AutenticacoesController(AutenticacaoDBContext db)
        {
            this.db = db;
        }

        [HttpGet]
        public ActionResult<List<Autenticacao>> Listar()
        {
            var modelos = this.db.Autenticacoes.ToList();
            return modelos;
        }

        public IActionResult Index()
        {
            //var result = db.Autenticacoes.ToList();
            var result = new Autenticacao() { Id = 1, Nome = "teste", Email = "@G", Senha = "seh" };

            return View(result);
        }

        public IActionResult Editar(int id)
        {
            Autenticacao autenticacao = db.Autenticacoes.First(f => f.Id == id);

            return View("Cadastrar", autenticacao);
        }

        public IActionResult Cadastrar()
        {
            return View("Cadastrar");
        }

        [HttpPost]
        public IActionResult Salvar(Autenticacao autenticacao)
        {
            if (autenticacao.Id == 0)
            {
                db.Autenticacoes.Add(autenticacao);
            }
            else
            {
                Autenticacao autent = db.Autenticacoes.First(registro => registro.Id == autenticacao.Id);
                autent.Nome = autenticacao.Nome;
                autent.Email = autenticacao.Email;
                autent.Senha = autenticacao.Senha;
            }

            db.SaveChanges();

            return RedirectToAction("Index");
        }

        public IActionResult Excluir(int id)
        {
            Autenticacao autenticacao = db.Autenticacoes.First(f => f.Id == id);

            db.Autenticacoes.Remove(autenticacao);
            db.SaveChanges();

            return RedirectToAction("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}