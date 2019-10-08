using TesteBNP.Dominio.Enum;

namespace TesteBNP.Dominio.Entidades
{
    public class ProdutoCosif
    {
        public string CodigoProduto { get; set; }
        public string CodigoCosif { get; set; }
        public string CodigoClassificacao { get; set; }
        public string StaStatus { get; set; }
        public Sta_Status Status { get; }
    }
}
