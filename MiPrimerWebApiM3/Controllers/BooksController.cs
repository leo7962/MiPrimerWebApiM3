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
    [Route("/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly ApplicationDbContext context;

        public BooksController(ApplicationDbContext context)
        {
            this.context = context;
        }

        [HttpGet]
        public ActionResult<IEnumerable<Book>> Get()
        {
            return context.Books.Include(x => x.Autor).ToList();
        }

        [HttpPost]
        public ActionResult Post([FromBody] Book book)
        {
            context.Books.Add(book);
            context.SaveChanges();
            return new CreatedAtRouteResult("obtenerLibro", new { id = book.Id }, book);
        }
    }
}