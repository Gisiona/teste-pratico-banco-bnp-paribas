using System.Collections.Generic;
using TesteBNP.Dominio.Entidades;
using TesteBNP.Repositorio;

namespace TesteBNP.Negocio
{
    public  class MovimentoManualNegocio
    {
        private readonly MovimentoManualRepositorio _movimentoManualRepositorio;

        public MovimentoManualNegocio()
        {
            _movimentoManualRepositorio = new MovimentoManualRepositorio();
        }


        public void Cadastrar(MovimentoManual movimento)
        {
            _movimentoManualRepositorio.CadastrarMovimento(movimento);
        }

        public List<MovimentoManual> ConsultarTodos()
        {
            return _movimentoManualRepositorio.ConsultarTodos();
        }
    }
}
