using System.Collections.Generic;
using System.Threading.Tasks;
using ListagemDeFornecedores.Domain.Entity;

namespace ListagemDeFornecedores.Repository
{
    public interface IEmpresaRepository
    {
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<Empresa> GetAsyncById(int id);
        Task<IEnumerable<Empresa>> GetAsync();
        Task<bool> HaEmpresas();
        Task<bool> SaveChangesAsync();
    }
}