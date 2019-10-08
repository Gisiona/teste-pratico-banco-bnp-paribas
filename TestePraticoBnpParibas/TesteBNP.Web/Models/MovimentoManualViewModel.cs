using System.Collections.Generic;
using TesteBNP.Dominio.Entidades;

namespace TesteBNP.Web.Models
{
    public class MovimentoManualViewModel
    {
        public List<MovimentoManual> MovimentoManualLista { get; set; }
        public List<ProdutoCosif> ProdutoCosifLista { get; set; }
        public List<Produto> ProdutoLista { get; set; }
    }
}