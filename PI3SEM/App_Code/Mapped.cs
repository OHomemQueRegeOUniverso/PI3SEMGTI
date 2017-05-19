

using MySql.Data.MySqlClient;

using System.Data;

using System.Configuration;


namespace WebLogin
{

    public class Mapped
    {
        
        public static IDbConnection Connection()
        {
            MySqlConnection conn = new MySqlConnection(ConfigurationManager.AppSettings["strConexao"]);
            conn.Open();
            return conn;
        }

        //Executa comando no BD
        public static IDbCommand Command(string query, IDbConnection conexao)
        {
            IDbCommand comando = conexao.CreateCommand();
            comando.CommandText = query;
            return comando;
        }

        //Retorna um Adapter (SELECT)
        public static IDataAdapter Adapter(IDbCommand comando)
        {
            IDbDataAdapter adap = new MySqlDataAdapter();
            adap.SelectCommand = comando;
            return adap;
        }

        //Cria parametro da SQL
        public static IDbDataParameter Parameter(string nome, object valor)
        {
            return new MySqlParameter(nome, valor);
        
        }



        public Mapped()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}