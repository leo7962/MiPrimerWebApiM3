using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore;
using MiPrimerWebApiM3.Contexts;
using MiPrimerWebApiM3.Entities;
using MiPrimerWebApiM3.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApiModulo4.Services;

namespace MiPrimerWebApiM3.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class AutoresController : ControllerBase
    {
        private readonly ApplicationDbContext context;
        private readonly IClaseB claseB;

        public AutoresController(ApplicationDbContext context, ClaseB claseB)
        {
            this.context = context;
            this.claseB = claseB;
        }

        // GET api/autores
        [HttpGet("/listado")]
        [HttpGet("listado")]
        [HttpGet]
        [ServiceFilter(typeof(MyActionFilter))]
        public ActionResult<IEnumerable<Autor>> Get()
        {
            throw new NotImplementedException();
            claseB.HacerAlgo();
            return context.Autors.ToList();
        }

        [HttpGet("Primer")]
        public ActionResult<Autor> GetPrimerAutor()
        {
            return context.Autors.FirstOrDefault();
        }

        // GET api/autores/5 
        // GET api/autores/5/felipe
        [HttpGet("{id}/{param2=Gavilan}")]
        public async Task<ActionResult<Autor>> Get(int id, string param2)
        {
            var autor = await context.Autors.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

            if (autor == null)
            {
                return NotFound();
            }

            return autor;
        }

        // POST api/autores
        [HttpPost]
        public ActionResult Post([FromBody] Autor autor)
        {
            context.Add(autor);
            context.SaveChanges();
            return new CreatedAtRouteResult("ObtenerAutor", new { id = autor.Id }, autor);
        }

        // PUT api/autores/5
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] Autor author)
        {
            context.Entry(author).State = EntityState.Modified;
            context.SaveChanges();
            return Ok();
        }

        // DELETE api/autores/5
        [HttpDelete("{id}")]
        public ActionResult<Autor> Delete(int id)
        {
            var autor = context.Autors.FirstOrDefault(x => x.Id == id);

            if (autor == null)
            {
                return NotFound();
            }

            context.Remove(autor);
            context.SaveChanges();
            return Ok(autor);
        }

        //Este código no sirve por ahora...
        //private readonly ApplicationDbContext context;

        //public AutoresController(ApplicationDbContext context, ClaseB claseB)
        //{
        //    this.context = context;
        //    claseB = claseB;
        //}

        //// Get de autores
        //[HttpGet("/listado")]
        //[HttpGet("listado")]
        //public ActionResult<IEnumerable<Autor>> Get()
        //{
        //    return context.Autors.ToList();
        //}

        //[HttpGet("Primero")]
        //public ActionResult<Autor> GetFirsAutor()
        //{
        //    return context.Autors.FirstOrDefault();
        //}

        ////Get de autors/1/leonardo o /Get de autors/1
        //[HttpGet("{id}", Name = "ObtenerAutor")]
        //public ActionResult<Autor> Get(int id)
        //{
        //    var autor = context.Autors.Include(x => x.Books).FirstOrDefault(x => x.Id == id);

        //    if (autor == null)
        //    {
        //        return NotFound();
        //    }

        //    return autor;
        //}

        ////Get /autores/5 o get Autores/5/ñepmardo

        ////[HttpGet("{id}")]
        ////public async Task<ActionResult<Autor>> Get(int id,[BindRequired] string param2)
        ////{
        ////    var autor = await context.Autors.FirstOrDefaultAsync(x => x.Id == id).ConfigureAwait(false);

        ////    if (autor == null)
        ////    {
        ////        return NotFound();                
        ////    }

        ////    return autor;
        ////}
        ////Post de autors/
        //[HttpPost]
        //public ActionResult Post([FromBody] Autor autor)
        //{
        //    TryValidateModel(autor);
        //    context.Autors.Add(autor);
        //    context.SaveChanges();
        //    return new CreatedAtRouteResult("ObtenerAutor", new { id = autor.Id }, autor);
        //}
        ////put autors/1
        //[HttpPut("{id}")]
        //public ActionResult Put(int id, [FromBody] Autor value)
        //{
        //    if (id != value.Id)
        //    {
        //        return BadRequest();
        //    }
        //    context.Entry(value).State = EntityState.Modified;
        //    context.SaveChanges();
        //    return Ok();
        //}
        ////delete autors/1
        //[HttpDelete("{id}")]
        //public ActionResult<Autor> Delete(int id)
        //{
        //    var autor = context.Autors.FirstOrDefault(x => x.Id == id);

        //    if (autor == null)
        //    {
        //        return NotFound();
        //    }
        //    context.Autors.Remove(autor);
        //    context.SaveChanges();
        //    return autor;
        //}

        ////public IActionResult Index()
        ////{
        ////    return View();
        ////}
    }
}