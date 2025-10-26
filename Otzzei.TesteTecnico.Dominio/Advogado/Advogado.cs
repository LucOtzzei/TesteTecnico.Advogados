using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Otzzei.TesteTecnico.Dominio.Advogado
{
    [Serializable]
    public class Advogado
    {
        public Guid Id { get; private set; }

        [Required(ErrorMessage = "O nome é obrigatorio para realizar o cadastro")]
        public string Nome { get; private set; }

        [Required(ErrorMessage = "O OAB é obrigatorio para realizar o cadastro")]
        public string OAB { get; private set; }

        [Required(ErrorMessage = "O Senioridade é obrigatorio para realizar o cadastro")]
        public SenioridadeEnum senioridade { get; private set; }

        public Advogado(string nome, string oab, SenioridadeEnum senioridade)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            OAB = oab;
            this.senioridade = senioridade;
        }
    }
}
