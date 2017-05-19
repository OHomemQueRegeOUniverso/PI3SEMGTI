using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLogin;
using System.Data;
/// <summary>
/// Descrição resumida de PedidoBD
/// </summary>
public class PedidoBD
{
    public bool Insert(Pedido pedido)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "INSERT INTO ped_pedidos(ped_datahora,ped_status,cli_cliente_cli_id,pro_produto_pro_id,ped_quantidade) VALUES (?ped_datahora, ?ped_status, ?cli_cliente_cli_id, ?pro_produto_pro_id, ?ped_quantidade)";
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command(sql, objConexao);

        objCommand.Parameters.Add(Mapped.Parameter("?ped_datahora", pedido.Datahora));
        objCommand.Parameters.Add(Mapped.Parameter("?ped_status", pedido.Statuspedido));
        objCommand.Parameters.Add(Mapped.Parameter("?cli_cliente_cli_id", pedido.Id_cliente));
        objCommand.Parameters.Add(Mapped.Parameter("?pro_produto_pro_id", pedido.Id_produto));
        objCommand.Parameters.Add(Mapped.Parameter("?ped_quantidade", pedido.Quantidade));       
        objCommand.ExecuteNonQuery(); objConexao.Close(); objCommand.Dispose(); objConexao.Dispose();

        return true;
    }
    public DataSet SelectAll()
    {
        DataSet ds = new DataSet();
        System.Data.IDbConnection objConexao; System.Data.IDbCommand objCommand; System.Data.IDataAdapter objDataAdapter;
        objConexao = Mapped.Connection(); objCommand = Mapped.Command("select * from ped_pedidos", objConexao);
        objDataAdapter = Mapped.Adapter(objCommand); objDataAdapter.Fill(ds); objConexao.Close(); objCommand.Dispose(); objConexao.Dispose();
        return ds;
    }
    public Pedido Select(int id)
    {
        Pedido obj = null;
        System.Data.IDbConnection objConexao; System.Data.IDbCommand objCommand; System.Data.IDataReader objDataReader;
        objConexao = Mapped.Connection();
        objCommand = Mapped.Command("SELECT * FROM ped_pedidos WHERE ped_codigo = ?codigo", objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?codigo", id));
        objDataReader = objCommand.ExecuteReader();
        while (objDataReader.Read())
        {
            obj = new Pedido();
            obj.Codigo = Convert.ToString(objDataReader["ped_codigo"]);
            obj.Datahora = Convert.ToString(objDataReader["ped_datahora"]);
            obj.Statuspedido = Convert.ToString(objDataReader["ped_status"]);
            obj.Id_cliente = Convert.ToString(objDataReader["cli_cliente_cli_id"]);
            obj.Id_produto = Convert.ToString(objDataReader["pro_produto_pro_id"]);
            obj.Quantidade = Convert.ToString(objDataReader["ped_quantidade"]);
        }
        objDataReader.Close(); objConexao.Close();
        objCommand.Dispose(); objConexao.Dispose(); objDataReader.Dispose();
        return obj;
    }
    public bool Update(Pedido pedido)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "UPDATE ped_pedidos SET ped_datahora=?ped_datahora, ped_status=?ped_status, cli_cliente_cli_id=?cli_cliente_cli_id, pro_produto_pro_id=?pro_produto_pro_id, ped_quantidade=?ped_quantidade WHERE ped_codigo=?codigo";
        objConexao = Mapped.Connection(); objCommand = Mapped.Command(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?codigo", pedido.Codigo));
        objCommand.Parameters.Add(Mapped.Parameter("?ped_datahora", pedido.Datahora));
        objCommand.Parameters.Add(Mapped.Parameter("?ped_status", pedido.Statuspedido));
        objCommand.Parameters.Add(Mapped.Parameter("?cli_cliente_cli_id", pedido.Id_cliente));
        objCommand.Parameters.Add(Mapped.Parameter("?pro_produto_pro_id", pedido.Id_produto));
        objCommand.Parameters.Add(Mapped.Parameter("?ped_quantidade", pedido.Quantidade));
        objCommand.ExecuteNonQuery();
        objConexao.Close();
        objCommand.Dispose(); objConexao.Dispose();
        return true;
    }
    public bool Update_cancelar(Pedido pedido)
    {
        System.Data.IDbConnection objConexao;
        System.Data.IDbCommand objCommand;
        string sql = "UPDATE ped_pedidos SET ped_status=?ped_status WHERE ped_codigo=?codigo";
        objConexao = Mapped.Connection(); objCommand = Mapped.Command(sql, objConexao);
        objCommand.Parameters.Add(Mapped.Parameter("?codigo", pedido.Codigo));
        objCommand.Parameters.Add(Mapped.Parameter("?ped_status", pedido.Statuspedido));
        objCommand.ExecuteNonQuery();
        objConexao.Close();
        objCommand.Dispose(); objConexao.Dispose();
        return true;
    }
    public PedidoBD()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }
}