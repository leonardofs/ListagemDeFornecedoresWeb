namespace ListagemDeFornecedores.Domain.Entity
{
    public abstract class Fornecedor
    {
        
        public int FornecedorId { get; set; }

        //Navigation Properties
        public int EmpresaId { get; set; }
        public  Empresa Empresa { get; set; }

    }
}