using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AgendamentoMedico.Models
{
    public class ClientContext : DbContext

    {
        public DbSet<Cliente> Clientes { get; set; }
        public ClientContext() : base("name=ClientContext")
        {

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().ToTable("Clientes");
            base.OnModelCreating(modelBuilder);
        }
    }
}