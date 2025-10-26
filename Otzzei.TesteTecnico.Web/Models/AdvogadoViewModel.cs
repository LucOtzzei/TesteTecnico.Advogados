using Otzzei.TesteTecnico.Dominio;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Otzzei.TesteTecnico.Web.Models
{
    public class AdvogadoViewModel
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "A OAB é obrigatória.")]
        public string OAB { get; set; }

        [Required(ErrorMessage = "A senioridade é obrigatória.")]
        public SenioridadeEnum Senioridade { get; set; }

        [Required(ErrorMessage = "A especialidade é obrigatória.")]
        public EspecialidadeEnum Especialidade { get; set; }
    }
}