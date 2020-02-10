using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListagemDeFornecedores.API.Data;
using ListagemDeFornecedores.API.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace ListagemDeFornecedores.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FornecedorController : ControllerBase
    {
        public FornecedoresContext Context { get; }
        public FornecedorController(FornecedoresContext context)
        {
            this.Context = context;
        }
        private readonly ILogger<FornecedorController> _logger;

        public FornecedorController(ILogger<FornecedorController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {                
                var results =  await Context.Fornecedores.ToListAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {

              return this.StatusCode(StatusCodes.Status500InternalServerError,"Requisição Falhou");
            }
        }

        



    }
}
