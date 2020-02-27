using System.Collections.Generic;
using System.Threading.Tasks;
using ListagemDeFornecedores.Domain.Entity;

namespace ListagemDeFornecedores.Repository
{
    public interface IEmpresaRepository
    {
        Task<Empresa> GetEmpresaAsyncById(int id);
        Task<IEnumerable<Empresa>> GetEmpresasAsync();
        Task<Empresa> PostEmpresaAsync(Empresa value);
        Task<Empresa> PutEmpresaAsyncById(int id, Empresa value );
        Task<bool> DeleteEmpresaAsyncById(int id);
    }
}