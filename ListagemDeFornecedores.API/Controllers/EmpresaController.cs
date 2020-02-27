using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using ListagemDeFornecedores.Repository;
using ListagemDeFornecedores.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;

namespace ListagemDeFornecedores.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        public FornecedoresContext _context { get; }
        public EmpresaController(FornecedoresContext context)
        {
            _context = context;
        }

        // GET api/empresa
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresasAsync()
        {
            try
            {
                var results = await _context.Empresas.ToListAsync();
                return Ok (results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Requisição Falhou");    
            }

        }

        // GET api/empresa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresaAsyncById(int id)
        {
            try
            {
                var result = await _context.Empresas.Where(e=>e.EmpresaId==id).FirstOrDefaultAsync();
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError,"Requisição Falhou");
            }
        }


        // POST api/empresa
        [HttpPost("")]
        public async Task<IActionResult> PostEmpresaAsync(Empresa value)
        {
                try
                {     
                    Console.WriteLine("valor do id:"+value.EmpresaId.ToString());
                 
                   await _context.Empresas.AddAsync(value);


                    
                    return Created(this.Request.Path+value.EmpresaId, value);
                }
                catch (System.Exception)
                {
                    
                    return this.StatusCode(StatusCodes.Status400BadRequest,"Não foi possivel salvar");
                }
        }

        // PUT api/empresa/5
        [HttpPut("{id}")]
        public void PutEmpresa(int id, Empresa value )
        {
            //TODO: atualizar empresa

        }

        // DELETE api/empresa/5
        [HttpDelete("{id}")]
        public void DeletestringById(int id)
        {


        }
    }
}