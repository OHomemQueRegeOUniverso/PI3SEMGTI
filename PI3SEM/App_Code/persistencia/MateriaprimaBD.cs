using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLogin;
using System.Data;

/// <summary>
/// Descrição resumida de MateriaprimaBD
/// </summary>
public class MateriaprimaBD
{
    public bool Insert(Materiaprima materiaprima)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "INSERT INTO mat_materiaprima(mat_nome, mat_quantidade) VALUES (?mat_nome, ?mat_quantidade)";
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConexao);

        objCommand.Parameters.Add(Mapped.Parameter("?mat_nome", materiaprima.Nome));
        objCommand.Parameters.Add(Mapped.Parameter("?mat_quantidade", materiaprima.Quantidade));

        objCommand.ExecuteNonQuery(); objConexao.Close(); objCommand.Dispose(); objConexao.Dispose();

        return true;
    }
    public DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        System.Data.IDbConnection objConexao; System.Data.IDbCommand objCommand; System.Data.IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection(); objCommand = Mapped.Command("SELECT * FROM mat_materiaprima", objConexao);
        objDataAdapter = Mapped.Adapter(objCommand); objDataAdapter.Fill(ds); objConexao.Close(); objCommand.Dispose(); objConexao.Dispose();
        return ds;
    }
    public MateriaprimaBD()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }
}