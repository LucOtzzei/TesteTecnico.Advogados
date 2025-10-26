using Otzzei.TesteTecnico.Repositorio.Interface;
using Otzzei.TesteTecnico.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Otzzei.TesteTecnico.Web.Controllers
{
    public class AdvogadoController : Controller
    {
        private readonly IAdvogadoService _advogadoService;
        private readonly IEnderecoRepositorio _enderecoRepositorio; // para linkar endereço depois

        public AdvogadoController(IAdvogadoService advogadoService, IEnderecoRepositorio enderecoRepositorio)
        {
            _advogadoService = advogadoService;
            _enderecoRepositorio = enderecoRepositorio;
        }

        // GET: Advogado
        public ActionResult Index()
        {
            var advogados = _advogadoService.ListarAdvogados();
            return View(advogados);
        }

        // GET: Advogado/Criar
        public ActionResult Criar()
        {
            return View();
        }

        // POST: Advogado/Criar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Criar(AdvogadoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _advogadoService.AdicionarAdvogado(model.Nome, model.OAB, model.Senioridade, model.Especialidade);
                TempData["Sucesso"] = "Advogado cadastrado com sucesso!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        // GET: Advogado/Editar/{id}
        public ActionResult Editar(Guid id)
        {
            var advogado = _advogadoService.ObterAdvogadoPorId(id);
            if (advogado == null)
                return HttpNotFound();

            var model = new AdvogadoViewModel
            {
                Id = advogado.Id,
                Nome = advogado.Nome,
                OAB = advogado.OAB,
                Senioridade = advogado.Senioridade,
                Especialidade = advogado.Especialidade
            };
            return View(model);
        }

        // POST: Advogado/Editar
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Editar(AdvogadoViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                _advogadoService.AtualizarAdvogado(model.Id, model.Nome, model.Senioridade);
                TempData["Sucesso"] = "Advogado atualizado!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", ex.Message);
                return View(model);
            }
        }

        // POST: Advogado/Remover/{id}
        [HttpPost]
        public ActionResult Remover(Guid id)
        {
            _advogadoService.RemoverAdvogado(id);
            TempData["Sucesso"] = "Advogado removido (soft delete).";
            return RedirectToAction("Index");
        }

        // POST: Advogado/Reativar/{id}
        [HttpPost]
        public ActionResult Reativar(Guid id)
        {
            _advogadoService.ReativarAdvogado(id);
            TempData["Sucesso"] = "Advogado reativado!";
            return RedirectToAction("Index");
        }

        // GET: Advogado/Detalhes/{id}
        public ActionResult Detalhes(Guid id)
        {
            var advogado = _advogadoService.ObterAdvogadoPorId(id);
            if (advogado == null)
                return HttpNotFound();

            var endereco = _enderecoRepositorio.ListarEnderecos()
                                .FirstOrDefault(e => e.Advogado != null && e.Advogado.Id == id);

            var vm = new AdvogadoDetalhesViewModel
            {
                Advogado = advogado,
                Endereco = endereco
            };

            return View(vm);
        }
    }
}