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

        public IEmpresaRepository _repo { get; }

        public EmpresaController(IEmpresaRepository repo)
        {
            _repo = repo;
        }

        // GET api/empresa
        [HttpGet("")]
        public async Task<ActionResult<IEnumerable<Empresa>>> GetEmpresasAsync()
        {
            try
            {
                var results = await _repo.GetAsync();
                return Ok(results);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Requisição Falhou");
            }

        }

        // GET api/empresa/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Empresa>> GetEmpresaAsyncById(int id)
        {
            try
            {
                var result = await _repo.GetAsyncById(id);
                return Ok(result);
            }
            catch (System.Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Requisição Falhou");
            }
        }
        // POST api/empresa
        [HttpPost]
        public async Task<IActionResult> PostEmpresaAsync(Empresa value)
        {
            try
            {
                _repo.Add(value);
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/Empresa/{value.EmpresaId}", value);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status400BadRequest, "Não foi possivel salvar");
            }
            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> PostEmpresaAsync(int id, Empresa value)
        {
            try
            {
                var _empresa = await _repo.GetAsyncById(id);
                if (_empresa == null) return NotFound();

                _repo.Update(value);
               
                if (await _repo.SaveChangesAsync())
                {
                    return Created($"/api/Empresa/{value.EmpresaId}", value);
                }
            }
            catch (System.Exception)
            {

                return this.StatusCode(StatusCodes.Status400BadRequest, "Não foi possivel salvar");
            }
            return BadRequest();
        }

        // DELETE api/empresa/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(Empresa value)
        {
                var _empresa = await _repo.GetAsyncById(value.EmpresaId);

                if (_empresa == null) return NotFound();

                _repo.Delete(value);

             if (await _repo.SaveChangesAsync())
                {
                    return Ok();
                }
            return BadRequest();
        }
    }
}