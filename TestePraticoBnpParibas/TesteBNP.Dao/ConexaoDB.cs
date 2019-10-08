using System;
using System.Data.SqlClient;

namespace TesteBNP.Dao
{
    public class ConexaoDB
    {
        private SqlConnection _conn = null;

        /// <summary>
        /// Abre uma conexão com o banco de dados e devolve uma conexão SQLConnection aberta pronto para uso.
        /// </summary>
        /// <autor>Gisiona Costa</autor>
        /// <data>26/01/2019</data>
        /// <returns>New SqlConnection</returns>
        public SqlConnection GetConnection()
        {
            try
            {
                _conn = new SqlConnection(@"Data Source=WIN-68GCQG5NS0\SQLEXPRESS;Initial Catalog=TESTEBNP;Integrated Security=True");
				_conn.Open();
                return _conn;
            }
            catch { throw new Exception("ERRO AO CONECTAR COM O BANCO DE DADOS."); }
        }


        /// <summary>
        /// Encerra uma conexão caso esteja aberta e libera o objeto da memoria.
        /// </summary>
        /// <autor>Gisiona Costa</autor>
        /// <data>26/01/2019</data>
        /// <returns>New SqlConnection</returns>
        public void FecharConexao()
        {
            try
            {
                if (_conn != null)
                {
                    _conn.Close();
                }
                _conn.Dispose();
            }
            catch { throw new Exception("ERRO AO CONECTAR COM O BANCO DE DADOS."); }
        }
    }
}
