using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using TesteBNP.Dominio.Entidades;

namespace TesteBNP.Repositorio
{
    public  class MovimentoManualRepositorio
    {
        #region Variaveis Locais
        private readonly RepositorioConexaoDB _repositorio;
        private MovimentoManual _movimentoManual;
        #endregion

        #region Ctor
        public MovimentoManualRepositorio()
        {
            _repositorio = new RepositorioConexaoDB();
        }
        #endregion

        #region CadastrarMovimento
        public void CadastrarMovimento(MovimentoManual movimento)
        {

            try
            {
                using (var conn = _repositorio.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    cmd.Connection = conn;
                    cmd.CommandText = "SP_BNP_INSERIR_MOVIMENTO";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@DAT_MES", movimento.MesMovimento);
                    cmd.Parameters.AddWithValue("@DAT_ANO", movimento.AnoMovimento);
                    cmd.Parameters.AddWithValue("@COD_PRODUTO", movimento.CodigoProduto);
                    cmd.Parameters.AddWithValue("@COD_COSIF", movimento.CodigoCosif);
                    cmd.Parameters.AddWithValue("@VAL_VALOR", movimento.ValorMovimento);
                    cmd.Parameters.AddWithValue("@DES_DESCRICAO", movimento.DescricaoMovimento);

                    cmd.ExecuteNonQuery();
                }
            }
            catch
            {
                throw new Exception("ENTRE EM CONTATO COM O ADMINISTRADOR DO SISTEMA E INFORME O CÓDIGO (MOVIMA01)");
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        #endregion
        
        #region ConsultarPorId
        public DataSet ConsultarPorId(int codigo)
        {
            try
            {
                using (var conn = _repositorio.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    SqlDataAdapter da;
                    DataSet ds = new DataSet();

                    cmd.Connection = conn;
                    cmd.CommandText = "SP_BNP_CONSULTAR_PRODUTO";
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@COD_PRODUTO", codigo);
                    da = new SqlDataAdapter(cmd);
                    da.Fill(ds, "produtos");
                    return ds;
                }
            }
            catch (SqlException sqlex)
            {
                throw new Exception("PRODSQLEX02");
            }
            catch
            {
                throw new Exception("ENTRE EM CONTATO COM O ADMINISTRADOR DO SISTEMA E INFORME O CÓDIGO (MOVIMA02)");
            }
            finally
            {
                _repositorio.FecharConexao();
            }
        }
        #endregion
                     
        #region ConsultarTodos
        public List<MovimentoManual> ConsultarTodos()
        {
            List<MovimentoManual> movimentoManualLista = new List<MovimentoManual>();

            try
            {
                using (var conn = _repositorio.GetConnection())
                {
                    SqlCommand cmd = new SqlCommand();
                    DbDataReader dr = null;

                    cmd.Connection = conn;
                    cmd.CommandText = "SP_BNP_CONSULTAR_MOVIMENTO_TODOS";
                    cmd.CommandType = CommandType.StoredProcedure;

                    dr = cmd.ExecuteReader();

                    while (dr.Read())
                    {
                        _movimentoManual = new MovimentoManual();
                        _movimentoManual.CodigoMovimento = Convert.ToInt32(dr["CODIGO_MOVIMENTO"]);
                        _movimentoManual.MesMovimento = Convert.ToInt32(dr["DAT_MES"]);
                        _movimentoManual.AnoMovimento = Convert.ToInt32(dr["DAT_ANO"]);
                        _movimentoManual.QtdeLancamento = Convert.ToInt32(dr["NUM_LANCAMENTO"]);
                        _movimentoManual.Produtos.CodProduto = dr["COD_PRODUTO"].ToString();
                        _movimentoManual.Produtos.DescricaoProduto = dr["DESCRICAO_PRODUTO"].ToString();
                        _movimentoManual.CodigoCosif = dr["COD_COSIF"].ToString();
                        _movimentoManual.ValorMovimento = Convert.ToDecimal(dr["VAL_VALOR"]);
                        _movimentoManual.DescricaoMovimento = dr["DESCRICAO_MOVIMENTO"].ToString();
                        _movimentoManual.DataMovimento = Convert.ToDateTime(dr["DAT_MOVIMENTO"]);
                        _movimentoManual.CodigoUsuario = dr["COD_USUARIO"].ToString();

                        movimentoManualLista.Add(_movimentoManual);
                    }
                }
            }
            catch
            {
                throw new Exception("ENTRE EM CONTATO COM O ADMINISTRADOR DO SISTEMA E INFORME O CÓDIGO (MOVIMA03)");
            }
            finally
            {
                _repositorio.FecharConexao();
            }
            return movimentoManualLista;
        }
        #endregion
    }
}
