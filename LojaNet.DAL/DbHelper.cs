using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data.Common;
using System.Data;



namespace LojaNet.DAL
{
    public static class DbHelper
    {
        private static string Conexao
        {
            get
            {
                return @"Data Source = (localDb)\MSSQLLocalDb; " +
                    "Initial Catalog=LojanetDb;" +
                    "Integrated Security=true";
            }
        }

        public static IDataReader ExecuteReader(string storedProcedure, params object[] parametros)
        {
            var cn = new SqlConnection(Conexao);
            var cmd = new SqlCommand(storedProcedure, cn);
            cmd.CommandType = CommandType.StoredProcedure;
            PreencerParametros(parametros, cmd);
            cn.Open();
            var reader = cmd.ExecuteReader(CommandBehavior.CloseConnection);
            return reader;
        }
        public static int ExecuteNonQuery(string storedProcedure, params object[] parametros)
        {
            int retorno = 0;
            using (var cn = new SqlConnection(Conexao))
            {
                using (var cmd = new SqlCommand(storedProcedure, cn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    PreencerParametros(parametros, cmd);
                    cn.Open();
                    retorno = cmd.ExecuteNonQuery();
                }
            }
            return retorno;
        }

        private static void PreencerParametros(object[] parametros, SqlCommand cmd)
        {
            if (parametros.Length > 0)
            {
                for (int i = 0; i < parametros.Length; i += 2)
                {
                    cmd.Parameters.AddWithValue(parametros[i].ToString(), parametros[i + 1]);
                }
            }
        }
    }
}
