using System.Collections.Generic;
using TesteBNP.Dominio.Entidades;
using TesteBNP.Repositorio;

namespace TesteBNP.Negocio
{
    public class ProdutoNegocio
    {
        private readonly ProdutoRepositorio _produtoRepositorio;

        public ProdutoNegocio()
        {
            _produtoRepositorio = new ProdutoRepositorio();
        }


        public void Cadastrar(Produto produto)
        {
            _produtoRepositorio.Cadastrar(produto);
        }

        public List<Produto> ConsultarTodos()
        {
            return _produtoRepositorio.ConsultarTodos();
        }
        
    }
}
