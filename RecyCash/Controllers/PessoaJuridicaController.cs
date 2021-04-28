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
    public class PessoaJuridicaController : Controller
    {
        private readonly MyDbContext _context;
        private readonly ILogger<PessoaJuridicaController> _logger;
        public PessoaJuridicaController(ILogger<PessoaJuridicaController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: values
        [HttpGet]
        public ActionResult<IEnumerable<PessoaJuridica>> Get()
        {
            var list = new List<PessoaJuridica>();
            try
            {
                list = _context.PessoaJuridica.Include(x => x.Pessoa).ToList();
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
        public ActionResult<PessoaJuridica> Get(int codigo)
        {
            try
            {
                var entity = _context.PessoaJuridica.Include(x => x.Pessoa).FirstOrDefault(x => x.CdPessoa == codigo);
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
        public ActionResult<PessoaJuridica> Post([FromBody] PessoaJuridica value)
        {
            try
            {
                if (value.Pessoa != null)
                    value.Pessoa.Tipo = Models.Enums.PessoaTipo.JURIDICA;

                _context.PessoaJuridica.Add(value);
                _context.SaveChanges();
                return CreatedAtAction(nameof(Get), new { codigo = value.CdPessoa }, value);
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
        public ActionResult<PessoaJuridica> Put(int codigo, [FromBody] PessoaJuridica value)
        {
            try
            {
                value.CdPessoa = codigo;
                if (value.Pessoa != null)
                {
                    value.Pessoa.Codigo = codigo;
                    value.Pessoa.Tipo = Models.Enums.PessoaTipo.JURIDICA;
                    _context.Entry(value.Pessoa).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
                }

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
                var entity = _context.PessoaJuridica.Include(x => x.Pessoa).FirstOrDefault(x => x.CdPessoa == codigo);
                if (entity != null)
                {
                    if (entity.Pessoa != null)
                        _context.Entry(entity.Pessoa).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;

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
