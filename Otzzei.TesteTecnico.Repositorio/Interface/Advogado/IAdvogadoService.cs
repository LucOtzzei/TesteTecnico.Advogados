using Otzzei.TesteTecnico.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.TesteTecnico.Repositorio.Interface
{
    public interface IAdvogadoService
    {
        IEnumerable<Advogado> ListarAdvogados();
        IEnumerable<Advogado> ListarAdvogadosPorEspecialidade(string especialidade);
        IEnumerable<Advogado> ListarAdvogadosPorSenioridade(string senioridade);
        Advogado ObterAdvogadoPorId(Guid id);
        Advogado ObterAdvogadoPorNome(string nome);
        Advogado ObterAdvogadoPorOAB(string oab);
        void AdicionarAdvogado(string nome, string oab, SenioridadeEnum senioridade, EspecialidadeEnum especialidade);
        void AtualizarAdvogado(Guid id, string nome, SenioridadeEnum senioridade);
        void RemoverAdvogado(Guid id);
        void ReativarAdvogado(Guid id);
    }
}
