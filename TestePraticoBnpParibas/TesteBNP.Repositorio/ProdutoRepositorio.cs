using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using TesteBNP.Dominio.Entidades;
using TesteBNP.Dominio.Enum;

namespace TesteBNP.Repositorio
{
    public class ProdutoRepositorio
    {

        private RepositorioConexaoDB _repositorio;
        private Produto _produto;

        public ProdutoRepositorio()
        {
            _repositorio = new RepositorioConexaoDB();
        }


        public void Cadastrar(Produto produto)
        {
            try
            {
                using (var conn = _repositorio.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();                    
                    cmd.Connection = conn;
                    cmd.CommandText = "SP_BNP_INSERIR_PRODUTO";
                    cmd.CommandType = CommandType.StoredProcedure;

                    produto.DescricaoProduto = "PREVIDENCIA";


                    //Adicionar os paramentros passado para a procedures
                    cmd.Parameters.AddWithValue("@COD_PRODUTO", produto.CodProduto);
                    cmd.Parameters.AddWithValue("@DES_PRODUTO", produto.DescricaoProduto);
                    cmd.Parameters.AddWithValue("@STA_STATUS", Sta_Status.ATIVO.ToString());

                    cmd.ExecuteNonQuery();
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ENTRE EM CONTATO COM O ADMINISTRADOR DO SISTEMA E INFORME O CÓDIGO (PROD01)");
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }


        public List<Produto> ConsultarTodos()
        {
            List<Produto> produtoLista = new List<Produto>();
            try
            {
                using (var conn = _repositorio.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    DbDataReader dr = null;

                    cmd.Connection = conn;
                    cmd.CommandText = "SP_BNP_CONSULTAR_PRODUTO";
                    cmd.CommandType = CommandType.StoredProcedure;
                    
                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        _produto = new Produto();
                        _produto.CodProduto = dr["COD_PRODUTO"].ToString();
                        _produto.DescricaoProduto = dr["DES_PRODUTO"].ToString();
                        _produto.StaStatus = dr["STA_STATUS"].ToString();

                        produtoLista.Add(_produto);
                    }
                    return produtoLista;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ENTRE EM CONTATO COM O ADMINISTRADOR DO SISTEMA E INFORME O CÓDIGO (PROD02)");
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
    }
}
