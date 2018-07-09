using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AgendamentoMedico.Models
{
    public class Agendamento
    {
        [Key]
        public int Id { get; set; }
        public int IdCliente { get; set; }
        public int TipoExame { get; set; }
        public int Dia { get; set; }
        public int Mes { get; set; }
        public int Ano { get; set; }
        public int Hora { get; set; }
        public int IdPrestador { get; set; }
    }
}