using System.Collections.Generic;
using TesteBNP.Dominio.Entidades;
using TesteBNP.Repositorio;

namespace TesteBNP.Negocio
{
    public class ProdutoCosifNegocio
    {
        private ProdutoCosifRepositorio _repositorio;

        public ProdutoCosifNegocio()
        {
            _repositorio = new ProdutoCosifRepositorio();
        }


        public List<ProdutoCosif> ConsultarTodos()
        {
            return _repositorio.ConsultarTodos();
        }
    }
}
