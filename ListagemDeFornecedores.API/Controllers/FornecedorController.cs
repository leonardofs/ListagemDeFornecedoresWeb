using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListagemDeFornecedores.Repository;
using ListagemDeFornecedores.Domain.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace ListagemDeFornecedores.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FornecedorController : ControllerBase
    {
        public FornecedoresContext Context { get; }
        public FornecedorController(FornecedoresContext context)
        {
            this.Context = context;
        }
         // GET api/fornecedor
        [HttpGet("")]
        public async Task <ActionResult<IEnumerable<Fornecedor>>> Get()
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

        // GET api/fornecedor/5 
        [HttpGet("{id}")]
        public async Task <ActionResult<IEnumerable<Empresa>>> GetFornecedoresByEmpresaId(int id)
        {
            try
            {
                var results = await Context.Fornecedores.Where(f=>f.EmpresaId==id).ToListAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Requisição Falhou");
            }

        }



    }
}
