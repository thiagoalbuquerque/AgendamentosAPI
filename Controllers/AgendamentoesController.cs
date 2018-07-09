using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;
using System.Web.Http.Description;
using AgendamentoMedico.Models;

namespace AgendamentoMedico.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    //Permite acesso de qualquer usuario

    public class AgendamentoesController : ApiController
    {
        private AgendamentoContext db = new AgendamentoContext();

        // GET: api/Agendamentoes
        public IQueryable<Agendamento> GetAgendamentos()
        {
            return db.Agendamentos;
        }

        // GET: api/Agendamentoes/5
        [ResponseType(typeof(Agendamento))]
        public IHttpActionResult GetAgendamento(int id)
        {
            //Agendamento agendamento = db.Agendamentos.Find(id);
            var agendamento = db.Agendamentos.ToList();

            List<Agendamento> match = new List<Agendamento>();
            foreach (var item in agendamento)
            {
                if (item.IdCliente == id)
                {
                    match.Add(item);
                }
            }
            if (agendamento == null)
            {
                return NotFound();
            }

            return Ok(match);
        }

        // PUT: api/Agendamentoes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAgendamento(int id, Agendamento agendamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != agendamento.Id)
            {
                return BadRequest();
            }

            db.Entry(agendamento).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!AgendamentoExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Agendamentoes
        [ResponseType(typeof(Agendamento))]
        public IHttpActionResult PostAgendamento(Agendamento agendamento)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Agendamentos.Add(agendamento);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = agendamento.Id }, agendamento);
        }

        // DELETE: api/Agendamentoes/5
        [ResponseType(typeof(Agendamento))]
        public IHttpActionResult DeleteAgendamento(int id)
        {
            Agendamento agendamento = db.Agendamentos.Find(id);
            if (agendamento == null)
            {
                return NotFound();
            }

            db.Agendamentos.Remove(agendamento);
            db.SaveChanges();

            return Ok(agendamento);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool AgendamentoExists(int id)
        {
            return db.Agendamentos.Count(e => e.Id == id) > 0;
        }
    }
}