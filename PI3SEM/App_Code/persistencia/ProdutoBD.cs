using WebLogin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLogin.Classes;
using System.Data;

namespace WebLogin.Persistencia
{

    public class ProdutoBD
    {
        public bool Insert(Produto produto)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "INSERT INTO prod_produto(prod_modelo, prod_quantidade) VALUES (?prod_modelo, ?prod_quantidade)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?prod_modelo", produto.Modelo));
            objCommand.Parameters.Add(Mapped.Parameter("?prod_quantidade", produto.Quantidade));

            objCommand.ExecuteNonQuery(); objConexao.Close(); objCommand.Dispose(); objConexao.Dispose();

            return true;
        }
        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();
            System.Data.IDbConnection objConexao; System.Data.IDbCommand objCommand; System.Data.IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection();objCommand = Mapped.Command("SELECT * FROM prod_produto", objConexao);
            objDataAdapter = Mapped.Adapter(objCommand);objDataAdapter.Fill(ds);objConexao.Close();objCommand.Dispose();objConexao.Dispose();
            return ds;
        }
        
        public Produto Select(int id)
        {
            Produto obj = null;
            System.Data.IDbConnection objConexao; System.Data.IDbCommand objCommand; System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM prod_produto WHERE prod_codigo = ?codigo", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo", id));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Produto(); obj.Codigo = Convert.ToInt32(objDataReader["prod_codigo"]);
                obj.Modelo = Convert.ToString(objDataReader["prod_modelo"]);
                obj.Quantidade = Convert.ToString(objDataReader["prod_quantidade"]);
            }
            objDataReader.Close(); objConexao.Close();
            objCommand.Dispose(); objConexao.Dispose(); objDataReader.Dispose();
            return obj;
        }

        public bool Update(Produto produto)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "UPDATE prod_produto SET prod_modelo=?modelo, prod_quantidade=?quantidade WHERE prod_codigo=?codigo";
            objConexao = Mapped.Connection(); objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?codigo",produto.Codigo));
            objCommand.Parameters.Add(Mapped.Parameter("?modelo", produto.Modelo));
            objCommand.Parameters.Add(Mapped.Parameter("?quantidade", produto.Quantidade));
            objCommand.ExecuteNonQuery();
            objConexao.Close(); objCommand.Dispose(); objConexao.Dispose();
            return true;
        }

        public bool Delete(int id)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "DELETE FROM prod_produto WHERE prod_codigo=?codigo";

            objConexao = Mapped.Connection(); objCommand = Mapped.Command(sql, objConexao);

            objCommand.Parameters.Add(Mapped.Parameter("?codigo", id));
            objCommand.ExecuteNonQuery(); objConexao.Close(); objCommand.Dispose(); objConexao.Dispose();

            return true;
        }

        public ProdutoBD()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}