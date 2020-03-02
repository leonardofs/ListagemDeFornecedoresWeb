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

         public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }

        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);

        }

        public async Task<IEnumerable<Empresa>> GetAsync()
        {
            return await _context.Empresas.ToListAsync();
        }

        public async Task<Empresa> GetAsyncById(int id)
        {
            return await _context.Empresas.Where(e => e.EmpresaId == id).FirstOrDefaultAsync();
        }


        public async Task<bool> SaveChangesAsync()
        {
           return(await _context.SaveChangesAsync()) >0;
        }
    }
}