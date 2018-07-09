using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendamentoMedico.Models
{
    public class Cliente
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string EnderecoAlternativo { get; set; }
        public bool ExameSangue { get; set; }
        public bool ExameEsforco { get; set; }
        public bool ExameEntrevista { get; set; }
        public bool ExameToxicologico { get; set; }
        public bool Check { get; set; }
    }
}