using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecyCash.DAL;
using RecyCash.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecyCash.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PessoaController : Controller
    {
        private readonly MyDbContext _context;
        private readonly ILogger<PessoaController> _logger;

        public PessoaController(ILogger<PessoaController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: values
        [HttpGet]
        public ActionResult<IEnumerable<Pessoa>> Get()
        {
            var list = new List<Pessoa>();
            try
            {
                list = _context.Pessoa.ToList();
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
        public ActionResult<Pessoa> Get(int codigo)
        {
            try
            {
                var entity = _context.Pessoa.FirstOrDefault(x => x.Codigo == codigo);
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
        public ActionResult<Pessoa> Post([FromBody] Pessoa value)
        {
            try
            {
                _context.Pessoa.Add(value);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Get), new {codigo = value}, value);
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
        public ActionResult<Pessoa> Put(int codigo, [FromBody] Pessoa value)
        {
            try
            {
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
                var entity = _context.Pessoa
                    .FirstOrDefault(x => x.Codigo == codigo);
                
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