using Otzzei.TesteTecnico.Dominio;
using Otzzei.TesteTecnico.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Otzzei.TesteTecnico.Repositorio.Implementacao
{
    public class AdvogadoRepositorio : IAdvogadoRepositorio
    {
        private static List<Advogado> _advogados = new List<Advogado>();
        private static int _contador = 1;

        public void AdicionarAdvogado(Advogado advogado)
        {
            _advogados.Add(advogado);
        }

        public void AtualizarAdvogado(Advogado advogado)
        {
            var advogadoExistente = _advogados.FirstOrDefault(a => a.Id == advogado.Id && a.IsDeleted == false);
            if (advogadoExistente != null)
            {
                advogadoExistente.AtualizarDados(advogado.Nome, advogado.Senioridade);
            }
        }

        public IEnumerable<Advogado> ListarAdvogados()
        {
            return _advogados;
        }

        public Advogado ObterAdvogadoPorId(Guid id)
        {
            return _advogados.FirstOrDefault(a => a.Id == id);
        }

        public Advogado ObterAdvogadoPorNome(string nome)
        {
            return _advogados.FirstOrDefault(a => a.Nome.ToUpper() == nome.ToUpper());
        }

        public Advogado ObterAdvogadoPorOAB(string oab)
        {
            return _advogados.FirstOrDefault(a => a.OAB.ToUpper() == oab.ToUpper());
        }

        public void ReativarAdvogado(Guid id)
        {
            var advogado = _advogados.FirstOrDefault(a => a.Id == id && a.IsDeleted == true);
            if (advogado != null) advogado.Reativar();
        }

        public void RemoverAdvogado(Guid id)
        {
            var advogado = _advogados.FirstOrDefault(a => a.Id == id);
            if (advogado != null) advogado.Deletar();
        }

    }
}
