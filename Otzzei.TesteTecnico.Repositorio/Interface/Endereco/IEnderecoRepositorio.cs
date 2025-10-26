using Otzzei.TesteTecnico.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.TesteTecnico.Repositorio.Interface
{
    public interface IEnderecoRepositorio
    {
        IEnumerable<Endereco> ListarEnderecos();
        Endereco ObterEnderecoPorAdvogado(string key);
        void IncluirEndereco(Advogado advogado, Endereco enderecoRequest);
        void AtualizarEndereco(Guid advogadoId, Endereco enderecoRequest);
    }
}
