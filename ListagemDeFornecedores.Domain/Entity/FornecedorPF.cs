using System;

namespace ListagemDeFornecedores.Domain.Entity
{
    public class FornecedorPF:Fornecedor
    {

        public string NomeFornecedor { get; set; }

        public string Cpf { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}