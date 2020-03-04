using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using ListagemDeFornecedores.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ListagemDeFornecedores.Repository
{
    public class DadosTeste
    {

        public IEmpresaRepository _repo { get; }
        public FornecedoresContext _context { get; }

        public DadosTeste(FornecedoresContext context, IEmpresaRepository repo)
        //public DadosTeste( EmpresaRepository repo)
        {
            //todo: temporario até implementação do repositorio para os fornecedores
           // _context = context;
            _repo = repo;

           var dados = Task<bool>.Run(async () => { return  await _repo.HaEmpresas(); });

            if (!dados.Result)
            {
                Task.Run(() => PopulaBancoEmpresas()).Wait();
                Task.Run(() => PopulaBancoFornecedorEmpresa()).Wait();
            }
        }

        private async Task PopulaBancoEmpresas()
        {

            var data = System.IO.File.ReadAllText("..//ListagemDeFornecedores.Repository/json/Empresas.json");
            var _empresas = JsonSerializer.Deserialize<List<Empresa>>(data);
            foreach (var empresa in _empresas)
            {
                var _empresa = new Empresa
                {
                    CNPJ = empresa.CNPJ,
                    Nome = empresa.Nome,
                    UF = empresa.UF
                };

                _repo.Add(_empresa);
            }
            await _repo.SaveChangesAsync();
        }

        private async Task PopulaBancoFornecedorEmpresa()
        {

            var pjdata = System.IO.File.ReadAllText("..//ListagemDeFornecedores.Repository/json/FornecedoresPJ.json");

            var _fornecedoresPJ = JsonSerializer.Deserialize<List<FornecedorPJ>>(pjdata);
            foreach (var _fornecedor in _fornecedoresPJ)
            {
                //TODO:  corrigir com repositorio
                await _context.Fornecedores.AddAsync(_fornecedor);
            }

            var pfdata = System.IO.File.ReadAllText("..//ListagemDeFornecedores.Repository/json/FornecedoresPF.json");
            var _fornecedoresPF = JsonSerializer.Deserialize<List<FornecedorPF>>(pfdata);
            foreach (var _fornecedor in _fornecedoresPF)
            {
                //Todo: corrigir com repositorio
                await _context.Fornecedores.AddAsync(_fornecedor);
            }
            await _context.SaveChangesAsync();
        }

    }
}