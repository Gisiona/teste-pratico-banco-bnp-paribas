using System;

namespace TesteBNP.Dominio.Entidades
{
    public class MovimentoManual
    {
        public int CodigoMovimento { get; set; }
        public int? MesMovimento { get; set; }
        public int? AnoMovimento { get; set; }
        public int QtdeLancamento { get; set; }
        public string CodigoProduto { get; set; }
        public string CodigoCosif { get; set; }
        public decimal? ValorMovimento { get; set; }
        public string DescricaoMovimento { get; set; }
        public DateTime DataMovimento { get; set; }
        public string CodigoUsuario { get; set; }
        public Produto Produtos { get; set; }

        public MovimentoManual()
        {
            Produtos = new Produto();
        }
    }
}
