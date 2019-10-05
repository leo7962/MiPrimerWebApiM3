using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MiPrimerWebApiM3.Contexts;
using MiPrimerWebApiM3.Entities;

namespace MiPrimerWebApiM3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public AutoresController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            return context.Autors.ToList();
        }

        [HttpGet("{id}", Name = "ObtenerAutor")]
        public ActionResult<Autor> Get(int id)
        {
            var autor = context.Autors.FirstOrDefault(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        [HttpPost]
        public ActionResult Post([FromBody] Autor autor)
        {
            context.Autors.Add(autor);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerAutor", new { id = autor.Id}, autor);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor value)
        {
            if (id != value.Id)
            {
                return BadRequest();
            }
            context.Entry(value).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete (int id)
        {
            var autor = context.Autors.FirstOrDefault(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }
            context.Autors.Remove(autor);
            context.SaveChanges();
            return autor;
        }

        //public IActionResult Index()
        //{
        //    return View();
        //}
    }
}