using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using RecyCash.DAL;
using RecyCash.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RecyCash.Controllers
{
    [ApiController]
    public class AutenticacaoController : Controller
    {
        private readonly MyDbContext _context;
        private readonly ILogger<PessoaController> _logger;
        private IConfiguration _configuration { get; }

        public AutenticacaoController(ILogger<PessoaController> logger, MyDbContext context, IConfiguration configuration)
        {
            _logger = logger;
            _context = context;
            _configuration = configuration;
        }

        // POST values
        [HttpPost]
        [Route("login")]
        [AllowAnonymous]
        public ActionResult<AutenticacaoRetorno> Autenticar([FromBody] Autenticacao value)
        {
            try
            {
                var pessoa = _context.Pessoa.FirstOrDefault(x => x.Email.Equals(value.Email) && x.Senha.Equals(value.Senha));
                if (pessoa == null)
                    return NotFound(new { message = "Usuário ou senha inválidos" });

                return new AutenticacaoRetorno
                {
                    Autenticado = true, 
                    Email = value.Email, 
                    Token = GenerateToken(pessoa)
                };
            }
            catch (Exception ex)
            {
                _logger.LogError("Post", ex);
                return BadRequest(new { message = ex.Message } );
            }
        }

       
        private string GenerateToken(Pessoa model)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration.GetValue<string>("SecretKey"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, model.Nome),
                    new Claim(ClaimTypes.Email, model.Email)
                }),
                Expires = DateTime.UtcNow.AddHours(2),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}