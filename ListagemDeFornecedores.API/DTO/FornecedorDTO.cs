namespace ListagemDeFornecedores.API.DTO
{
    public class FornecedorDTO
    {
        public int FornecedorId { get; set; }
        //Navigation Properties
       // public int EmpresaId { get; set; }
        public  EmpresaDTO Empresa { get; set; }

    

    //TODO: herança no mapper
    
    }
}