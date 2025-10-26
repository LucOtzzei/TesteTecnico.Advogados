using Otzzei.TesteTecnico.Dominio;
using Otzzei.TesteTecnico.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Otzzei.TesteTecnico.Repositorio.Implementacao
{
    public class AdvogadoService : IAdvogadoService
    {
        private readonly IAdvogadoRepositorio _advogadoRepositorio;

        public AdvogadoService(IAdvogadoRepositorio repositorio)
        {
            _advogadoRepositorio = repositorio;
        }

        public IEnumerable<Advogado> ListarAdvogados()
        {
            return _advogadoRepositorio.ListarAdvogados().Where(a => !a.IsDeleted);
        }

        public IEnumerable<Advogado> ListarAdvogadosPorEspecialidade(string especialidade)
        {
            var advogados =  _advogadoRepositorio.ListarAdvogados();
            return advogados.Where(x => x.Especialidade.ToString() == especialidade && !x.IsDeleted);
        }

        public IEnumerable<Advogado> ListarAdvogadosPorSenioridade(string senioridade)
        {
            var advogados =  _advogadoRepositorio.ListarAdvogados();
            return advogados.Where(x => x.Senioridade.ToString() == senioridade && !x.IsDeleted);
        }

        public Advogado ObterAdvogadoPorId(Guid id)
        {
            var advogado = _advogadoRepositorio.ObterAdvogadoPorId(id);
            return advogado != null && !advogado.IsDeleted ? advogado : null;
        }

        public Advogado ObterAdvogadoPorNome(string nome)
        {
            var advogado = _advogadoRepositorio.ObterAdvogadoPorNome(nome);
            return advogado != null && !advogado.IsDeleted ? advogado : null;
        }

        public Advogado ObterAdvogadoPorOAB(string oab)
        {
            var advogado = _advogadoRepositorio.ObterAdvogadoPorOAB(oab);
            return advogado != null && !advogado.IsDeleted ? advogado : null;
        }

        public void AdicionarAdvogado(string nome, string oab, SenioridadeEnum senioridade, EspecialidadeEnum especialidade)
        {
            if (_advogadoRepositorio.ObterAdvogadoPorOAB(oab) != null)
                throw new InvalidOperationException("Já existe um advogado com essa OAB.");

            var advogado = new Advogado(nome, oab, senioridade, especialidade);

            _advogadoRepositorio.AdicionarAdvogado(advogado);
        }

        public void AtualizarAdvogado(Guid id, string nome, SenioridadeEnum senioridade)
        {
            var advogado = _advogadoRepositorio.ObterAdvogadoPorId(id);
            if (advogado == null || advogado.IsDeleted)
                throw new InvalidOperationException("Advogado não encontrado ou está deletado.");

            advogado.AtualizarDados(nome, senioridade);
            _advogadoRepositorio.AtualizarAdvogado(advogado);
        }

        public void RemoverAdvogado(Guid id)
        {
            _advogadoRepositorio.RemoverAdvogado(id);
        }

        public void ReativarAdvogado(Guid id)
        {
            _advogadoRepositorio.ReativarAdvogado(id);
        }
    }
}
