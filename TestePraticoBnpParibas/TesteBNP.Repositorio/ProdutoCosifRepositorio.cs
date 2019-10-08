using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using TesteBNP.Dominio.Entidades;

namespace TesteBNP.Repositorio
{
    public class ProdutoCosifRepositorio
    {

        private RepositorioConexaoDB _repositorio;
        private ProdutoCosif _produtoCosif;

        public ProdutoCosifRepositorio()
        {
            _repositorio = new RepositorioConexaoDB();
            _produtoCosif = new ProdutoCosif();
        }

        public List<ProdutoCosif> ConsultarTodos()
        {
            List<ProdutoCosif> produtoCosifLista = new List<ProdutoCosif>();
            try
            {
                using (var conn = _repositorio.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    DbDataReader dr = null;

                    cmd.Connection = conn;
                    cmd.CommandText = "SP_BNP_CONSULTAR_PRODUTO_COSIF";
                    cmd.CommandType = CommandType.StoredProcedure;

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        _produtoCosif = new ProdutoCosif();

                        _produtoCosif.CodigoCosif = dr["COD_COSIF"].ToString();
                        _produtoCosif.CodigoProduto = dr["COD_PRODUTO"].ToString();
                        _produtoCosif.CodigoClassificacao = dr["COD_CLASSIFICACAO"].ToString();
                        _produtoCosif.StaStatus = dr["STA_STATUS"].ToString();

                        produtoCosifLista.Add(_produtoCosif);
                    }
                    return produtoCosifLista;
                }
            }
            catch (Exception ex)
            {
                throw new Exception("ENTRE EM CONTATO COM O ADMINISTRADOR DO SISTEMA E INFORME O CÓDIGO (PRODCOS01");
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
    }
}
