using Otzzei.TesteTecnico.Dominio;
using Otzzei.TesteTecnico.Repositorio.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
namespace Otzzei.TesteTecnico.Repositorio.Implementacao
{
    public class EnderecoRepositorio : IEnderecoRepositorio
    {
        private static List<Endereco> _enderecos = new List<Endereco>();
        public void IncluirEndereco(Advogado advogado, Endereco enderecoRequest)
        {
            var novoEndereco = new Endereco(enderecoRequest)
            {
                Advogado = advogado
            };
            _enderecos.Add(novoEndereco);
        }

        public void AtualizarEndereco(Guid advogadoId, Endereco enderecoRequest)
        {
            var endereco = _enderecos.FirstOrDefault(e => e.Advogado != null
                                                          && e.Advogado.Id == advogadoId
                                                          && !e.Advogado.IsDeleted);
            if (endereco != null)
            {
                endereco.Atualizar(advogadoId.ToString(), enderecoRequest);
            }
        }

        public IEnumerable<Endereco> ListarEnderecos()
        {
            return _enderecos.Where(e => e.Advogado.IsDeleted == false).ToList();
        }

        public Endereco ObterEnderecoPorAdvogado(string key)
        {
            throw new NotImplementedException();
        }
    }
}
