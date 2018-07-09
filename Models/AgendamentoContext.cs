using AgendamentoMedico.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgendamentoMedico.Models
{
    public class AgendamentoContext : DbContext
    {
        public DbSet<Agendamento> Agendamentos { get; set; }

        public AgendamentoContext() : base("name=ClientContext")
        {

        }

        //customizacao das entidades x database
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Agendamento>().ToTable("AgendamentoDB");
            base.OnModelCreating(modelBuilder);
        }
    }
}