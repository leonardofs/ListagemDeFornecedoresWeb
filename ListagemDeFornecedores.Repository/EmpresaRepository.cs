using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ListagemDeFornecedores.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ListagemDeFornecedores.Repository
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private FornecedoresContext _context;

        public EmpresaRepository(FornecedoresContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Empresa>> GetEmpresasAsync()
        {
            return await _context.Empresas.ToListAsync();
        }

        public async Task<Empresa> GetEmpresaAsyncById(int id)
        {
            return await _context.Empresas.Where(e => e.EmpresaId == id).FirstOrDefaultAsync();
        }

        public async Task<Empresa> PostEmpresaAsync(Empresa value)
        {
            try
            {

                await _context.Empresas.AddAsync(value);
                await _context.SaveChangesAsync();
                return value;

            }
            catch (System.Exception)
            {

                throw;
            }
        }
        public async Task<bool> DeleteEmpresaAsyncById(int id)
        {
            try
            {
                var result = await GetEmpresaAsyncById(id);
                _context.Empresas.Remove(result);
                return await _context.SaveChangesAsync()> 0 ; 
            }
            catch (System.Exception)
            {
                return false;
            }
        }

        public async Task<Empresa> PutEmpresaAsyncById(int id, Empresa value)
        {

            // var result = db.Empresas.Where(emp => emp.EmpresaId == _empresa.EmpresaId).FirstOrDefault();
            //     if (result != null)
            //     {
            //         result.Nome = _empresa.Nome;
            //         result.CNPJ = _empresa.CNPJ;
            //         result.UF = _empresa.UF;

            //         await db.SaveChangesAsync();

            //     }
            // TODO: edit empresa
          throw new System.NotImplementedException();
        }
    }
}