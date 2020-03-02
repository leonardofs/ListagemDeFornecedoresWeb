namespace ListagemDeFornecedores.API.DTO
{
    public class EmpresaDTO
    {
        public int EmpresaId { get; set; }

        public string Nome { get; set; }

        public string UF { get; set; }

        public string CNPJ { get; set; }

        //Navigation Properties

        //public ICollection<Fornecedor> Fornecedores { get; set; }

        //public virtual FornecedorPJ fornecedorPJ { get; set; }

    }
}