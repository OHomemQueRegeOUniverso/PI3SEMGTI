using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLogin.Classes;
using WebLogin;
using System.Data;
/// <summary>
/// Descrição resumida de ClienteBD
/// </summary>
public class ClienteBD
{
    public Cliente Select(string cnpj)
    {
        Cliente obj = null;

        System.Data.IDbConnection objConexao; System.Data.IDbCommand objCommand; System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM cliente WHERE cnpj = ?cnpj", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?cnpj", cnpj));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            obj = new Cliente();
            obj.Cnpj = Convert.ToString(objDataReader["cnpj"]);
        }
        objDataReader.Close(); objConexao.Close(); objCommand.Dispose(); objConexao.Dispose(); objDataReader.Dispose();


        return obj;
    }
    public DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        System.Data.IDbConnection objConexao; System.Data.IDbCommand objCommand; System.Data.IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection(); objCommand = Mapped.Command("select * from cli_cliente, pes_pessoa where pes_pessoa_pes_documento = pes_documento", objConexao);
        objDataAdapter = Mapped.Adapter(objCommand); objDataAdapter.Fill(ds); objConexao.Close(); objCommand.Dispose(); objConexao.Dispose();
        return ds;
    }
    public bool Insert(Cliente cliente)
    {
        System.Data.IDbConnection objConexao; System.Data.IDbCommand objCommand;
        string sql = "insert into cli_cliente(pes_pessoa_pes_documento) VALUES (?pes_pessoa_pes_documento)";
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?pes_pessoa_pes_documento", cliente.Cnpj));
        objCommand.ExecuteNonQuery(); objConexao.Close(); objCommand.Dispose(); objConexao.Dispose();

        return true;
    }


    public ClienteBD()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }
}