using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ListagemDeFornecedores.API.Models;
using ListagemDeFornecedores.API.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ListagemDeFornecedores.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        public FornecedoresContext Context { get; }
        public EmpresaController(FornecedoresContext context)
        {
            this.Context = context;
        }

        // GET api/empresa
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Empresa>>> Get()
        {
            try
            {
                var results = await Context.Empresas.ToListAsync();
                return Ok (results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Requisição Falhou");    
            }

        }

        // GET api/empresa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresaById(int id)
        {
            try
            {
                var result = await Context.Empresas.Where(e=>e.EmpresaId==id).FirstOrDefaultAsync();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Requisição Falhou");
            }
        }


        // POST api/empresa
        [HttpPost("")]
        public async Task<IActionResult> PostEmpresa(Empresa value)
        {
                try
                {     
                    Console.WriteLine("valor do id:"+value.EmpresaId.ToString());
                 
                   await Context.Empresas.AddAsync(value);

                  Console.WriteLine("novo valor do id:"+value.EmpresaId.ToString());
                    
                    return Created(this.Request.Path+value.EmpresaId, value);
                }
                catch (System.Exception)
                {
                    
                    return this.StatusCode(StatusCodes.Status400BadRequest,"Não foi possivel salvar");
                }
        }

        // PUT api/empresa/5
        [HttpPut("{id}")]
        public void Putstring(int id, string value)
        {

        }

        // DELETE api/empresa/5
        [HttpDelete("{id}")]
        public void DeletestringById(int id)
        {


        }
    }
}