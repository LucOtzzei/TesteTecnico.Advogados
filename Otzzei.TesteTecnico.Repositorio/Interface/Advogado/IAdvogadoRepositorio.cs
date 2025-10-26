using Otzzei.TesteTecnico.Dominio;
using System;
using System.Collections.Generic;

namespace Otzzei.TesteTecnico.Repositorio.Interface
{
    public interface IAdvogadoRepositorio
    {
        IEnumerable<Advogado> ListarAdvogados();
        Advogado ObterAdvogadoPorId(Guid id);
        Advogado ObterAdvogadoPorNome(string nome);
        Advogado ObterAdvogadoPorOAB(string oab);
        void AdicionarAdvogado(Advogado advogado);
        void AtualizarAdvogado(Advogado advogado);
        void RemoverAdvogado(Guid id);
        void ReativarAdvogado(Guid id);
    }
}
