namespace ListagemDeFornecedores.Domain
{
    public class FornecedorPJ:Fornecedor
    {
     
        //Navigation Properties

        public int EmpresaFornecedorId { get; set; }
        public virtual Empresa EmpresaFornecedor { get; set; }
    }
}