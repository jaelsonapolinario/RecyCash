using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RecyCash.DAL;
using RecyCash.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?Linkcodigo=397860

namespace RecyCash.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class PessoasController : ControllerBase
    {
        private readonly MyDbContext _context;
        private readonly ILogger<PessoasController> _logger;
        public PessoasController(ILogger<PessoasController> logger, MyDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        // GET: <PessoasController>
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

        // GET <PessoasController>/5
        [HttpGet("{codigo}")]
        public string Get(int codigo)
        {
            return "value";
        }

        // POST <PessoasController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT <PessoasController>/5
        [HttpPut("{codigo}")]
        public void Put(int codigo, [FromBody] string value)
        {
        }

        // DELETE <PessoasController>/5
        [HttpDelete("{codigo}")]
        public void Delete(int codigo)
        {
        }
    }
}
