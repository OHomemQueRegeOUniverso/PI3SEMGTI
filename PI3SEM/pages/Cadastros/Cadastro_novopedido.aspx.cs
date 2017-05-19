using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebLogin.Persistencia;
public partial class pages_Cadastros_Cadastro_perdas : System.Web.UI.Page
{
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
        if (!Page.IsPostBack) {
            Preenche_dropdownCliente();
            Preenche_dropdownProduto();
        }
        

    }
    private void Cadastro_pedido()
    {
        Pedido ped = new Pedido();
        ped.Datahora = txt_ped_datahora.Text;
        ped.Statuspedido = dropstatus.SelectedItem.Text;
        ped.Id_cliente = dropcliente.SelectedItem.Value;
        ped.Id_produto = dropproduto.SelectedItem.Value;
        ped.Quantidade = txt_ped_quantidade.Text;
        PedidoBD bd = new PedidoBD();
        if (bd.Insert(ped)){ msg.Text ="CADASTRADO COM SUCESSO"; }
        else { msg.Text ="NÃO FOI POSSIVEL CADASTRAR "; }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Cadastro_pedido();
    }
}