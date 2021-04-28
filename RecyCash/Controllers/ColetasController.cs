using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using RecyCash.DAL;
using RecyCash.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecyCash.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ColetasController : Controller
    {
        private readonly MyDbContext _context;
        private readonly ILogger<ColetasController> _logger;
        public ColetasController(ILogger<ColetasController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: values
        [HttpGet]
        public ActionResult<IEnumerable<Coleta>> Get()
        {
            var list = new List<Coleta>();
            try
            {
                list = _context.Coleta.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError("Get", ex);
            }

            return list;
        }

        // GET values/5
        [HttpGet("{codigo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Coleta> Get(int codigo)
        {
            try
            {
                var entity = _context.Coleta
                    .FirstOrDefault(x => x.Codigo == codigo);

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

        // POST values
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Coleta> Post([FromBody] Coleta value)
        {
            try
            {
                _context.Coleta.Add(value);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Get), new { codigo = value.Codigo }, value);
            }
            catch (Exception ex)
            {
                _logger.LogError("Post", ex);
                return BadRequest();
            }
        }

        // PUT values/5
        [HttpPut("{codigo}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<Coleta> Put(int codigo, [FromBody] Coleta value)
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

        // DELETE values/5
        [HttpDelete("{codigo}")]
        public void Delete(int codigo)
        {
            try
            {
                var entity = _context.Coleta.FirstOrDefault(x => x.Codigo == codigo);
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
