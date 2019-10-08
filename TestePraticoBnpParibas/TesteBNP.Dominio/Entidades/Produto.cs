using TesteBNP.Dominio.Enum;

namespace TesteBNP.Dominio.Entidades
{
    public class Produto
    {
        public string CodProduto { get; set; }
        public string DescricaoProduto { get; set; }
        public Sta_Status Status { get; }
        public string StaStatus { get; set; }
    }
}
