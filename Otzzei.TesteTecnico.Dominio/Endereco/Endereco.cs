using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.TesteTecnico.Dominio
{
    [Serializable]
    public class Endereco
    {
        public Guid Id { get; set; }
        public Guid AdvogadoId { get; set; }
        public Advogado Advogado { get; set; }

        [Required(ErrorMessage = "O logradouro é obrigatório")]
        public LogradouroEnum Logradouro { get; set; }

        [Required(ErrorMessage = "O nome da Cidade é obrigatório")]
        public string Cidade { get; set; }

        [Required(ErrorMessage = "O bairro é obrigatório")]
        public string Bairro { get; set; }

        [Required(ErrorMessage = "O estado é obrigatório")]
        public EstadoEnum Estado { get; set; }

        [Required(ErrorMessage = "O CEP é obrigatório")]
        [RegularExpression(@"^\d{5}-\d{3}$", ErrorMessage = "CEP inválido (ex: 00000-000)")]
        public string Cep { get; set; }

        [Required(ErrorMessage = "O número é obrigatório")]
        public string Numero { get; set; }

        public string Complemento { get; set; }

        public Endereco(Endereco endereco)
        {
            Id = Guid.NewGuid();
            Logradouro = endereco.Logradouro;
            Cidade = endereco.Cidade;
            Bairro = endereco.Bairro;
            Estado = endereco.Estado;
            Cep = endereco.Cep;
            Numero = endereco.Numero;
            Complemento = endereco.Complemento;
        }

        public void Atualizar(string advogadoId, Endereco endereco)
        {
            Logradouro = endereco.Logradouro;
            Cidade = endereco.Cidade;
            Bairro = endereco.Bairro;
            Estado = endereco.Estado;
            Cep = endereco.Cep;
            Numero = endereco.Numero;
            Complemento = endereco.Complemento;
        }
    }
}
