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
        public FornecedoresContext _context { get; }
        public EmpresaRepository _empresaRepository { get; }

        public DadosTeste(EmpresaRepository empresaRepository)
        {

            _empresaRepository = empresaRepository;

            var haDados = _context.Fornecedores.Any();
            if (!haDados)
            {
                Task.Run(() => PopulaBancoEmpresas()).Wait();
                Task.Run(() => PopulaBancoFornecedorEmpresa()).Wait();
            }

            _empresaRepository = empresaRepository;
        }

        private async Task PopulaBancoEmpresas()
        {

            var data = System.IO.File.ReadAllText("Data/json/Empresas.json");
            var _empresas = JsonSerializer.Deserialize<List<Empresa>>(data);
            foreach (var empresa in _empresas)
            {
                var _empresa = new Empresa
                {
                    CNPJ = empresa.CNPJ,
                    Nome = empresa.Nome,
                    UF = empresa.UF
                };

                await _context.Empresas.AddAsync(_empresa);
            }

            await _context.SaveChangesAsync();

        }

        private async Task PopulaBancoFornecedorEmpresa()
        {

            var pjdata = System.IO.File.ReadAllText("Data/json/FornecedoresPJ.json");

            var _fornecedoresPJ = JsonSerializer.Deserialize<List<FornecedorPJ>>(pjdata);
            foreach (var _fornecedor in _fornecedoresPJ)
            {
                await _context.Fornecedores.AddAsync(_fornecedor);
            }

            var pfdata = System.IO.File.ReadAllText("Data/json/FornecedoresPF.json");
            var _fornecedoresPF = JsonSerializer.Deserialize<List<FornecedorPF>>(pfdata);
            foreach (var _fornecedor in _fornecedoresPF)
            {
                await _context.Fornecedores.AddAsync(_fornecedor);
            }

            await _context.SaveChangesAsync();

        }

    }
}