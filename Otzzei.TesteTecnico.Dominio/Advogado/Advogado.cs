using System;
using System.ComponentModel.DataAnnotations;

namespace Otzzei.TesteTecnico.Dominio
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
        public SenioridadeEnum Senioridade { get; private set; }
        public EspecialidadeEnum Especialidade { get; private set; }
        public bool IsDeleted { get; private set; } = false;
        public DateTime CreatedAt { get; private set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; private set; } = DateTime.UtcNow;

        public Advogado(string nome, string oab, SenioridadeEnum senioridade)
        {
            Id = Guid.NewGuid();
            Nome = nome;
            OAB = oab;
            Senioridade = senioridade;
        }
        public void AtualizarDados(string nome, SenioridadeEnum senioridade)
        {
            Nome = nome;
            Senioridade = senioridade;
        }
        public void Deletar()
        {
            IsDeleted = true;
        }

        public void Reativar()
        {
            IsDeleted = false;
        }
    }
}
