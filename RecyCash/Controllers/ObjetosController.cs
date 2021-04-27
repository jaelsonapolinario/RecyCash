using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecyCash.DAL;
using RecyCash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecyCash.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ObjetosController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly ILogger<ObjetosController> _logger;
        public ObjetosController(ILogger<ObjetosController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }
      
        // GET: <ObjetosController>
        [HttpGet]
        public ActionResult<IEnumerable<Objeto>> Get()
        {
            var list = new List<Objeto>();
            try
            {
                list = _context.Objeto.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Get", ex);
            }

            return list;
        }

        // GET <ObjetosController>/5
        [HttpGet("{codigo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Objeto> Get(int codigo)
        {
            try
            {
                var entity = _context.Objeto.FirstOrDefault(x => x.Codigo == codigo);
                if (entity != null)
                    return entity;
                else
                    return NotFound();
            }
            catch (Exception ex)
            {
                _logger.LogError("GetId", ex);
                return BadRequest();
            }
        }

        // POST <ObjetosController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Objeto> Post([FromBody] Objeto value)
        {
            try
            {
                _context.Objeto.Add(value);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Get), new { codigo = value.Codigo }, value);
            }
            catch (Exception ex)
            {
                _logger.LogError("Post", ex);
                return BadRequest();
            }
        }

        // PUT <ObjetosController>/5
        [HttpPut("{codigo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Objeto> Put(int codigo, [FromBody] Objeto value)
        {
            try
            {
                value.Codigo = codigo;
                _context.Entry(value).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                _context.SaveChanges();
                return Ok(value);
            }
            catch (Exception ex)
            {
                _logger.LogError("Put", ex);
                return BadRequest();
            }
        }

        // DELETE <ObjetosController>/5
        [HttpDelete("{codigo}")]
        public void Delete(int codigo)
        {
            try
            {
                var entity = _context.Objeto.FirstOrDefault(x => x.Codigo == codigo);
                if (entity != null)
                {
                    _context.Entry(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    _context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError("Delete", ex);
            }
        }
    }
}
