using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebLogin.Persistencia;
public partial class pages_Tabelas_edicoes_Edicao_pedido : System.Web.UI.Page
{
    private void Carrega() { PedidoBD bd = new PedidoBD(); DataSet ds = bd.SelectAll(); GridView1.DataSource = ds.Tables[0].DefaultView; GridView1.DataBind(); }
    private void Preenche_dropdownCliente()
    {
        ClienteBD bdc = new ClienteBD();
        DataSet ds = null;
        ds = bdc.SelectAll();

        dropcliente.DataSource = ds.Tables[0].DefaultView;
        dropcliente.DataTextField = "pes_nome";
        dropcliente.DataValueField = "pes_documento";
        dropcliente.DataBind();
        dropcliente.Items.Insert(0, "Selecione o cliente");

    }
    private void Preenche_dropdownProduto()
    {
        ProdutoBD bdp = new ProdutoBD();
        DataSet ds = null;
        ds = bdp.SelectAll();

        dropproduto.DataSource = ds.Tables[0].DefaultView;
        dropproduto.DataTextField = "prod_modelo";
        dropproduto.DataValueField = "prod_codigo";
        dropproduto.DataBind();
        dropproduto.Items.Insert(0, "Selecione o produto");

    }
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            Preenche_dropdownCliente();
            Preenche_dropdownProduto();
        }
        Carrega();
    }
    protected void cancelapedido()
    {
        PedidoBD bd = new PedidoBD();
        Pedido pedido = bd.Select(Convert.ToInt32(Session["ID"]));
        pedido.Statuspedido = "PEDIDO CANCELADO";
        if (bd.Update_cancelar(pedido)) {  Carrega(); }
        else {  }

    }
    
    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int codigo = 0;
        switch (e.CommandName)
        {
            case "Alterar":
                codigo = Convert.ToInt32(e.CommandArgument); Session["ID"] = codigo;
                msg.Text = "Pronto pra alterar o produto de id :" + codigo;
                
                break;
            case "Cancelar":
                codigo = Convert.ToInt32(e.CommandArgument); Session["ID"] = codigo;
                cancelapedido();
                Carrega();
                break;
            default: break;
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
   
        PedidoBD bd = new PedidoBD();
        Pedido pedido = bd.Select(Convert.ToInt32(Session["ID"]));
        pedido.Datahora = txt_ped_datahora.Text;
        pedido.Statuspedido = dropstatus.SelectedItem.Text;
        pedido.Id_cliente = dropcliente.SelectedItem.Value;
        pedido.Id_produto = dropproduto.SelectedItem.Value;
        pedido.Quantidade = txt_ped_quantidade.Text;
        if (bd.Update(pedido)) { msg.Text = "Pedido alterado com sucesso";Carrega(); }
        else { msg.Text = "Erro ao alterar."; }
    }
}