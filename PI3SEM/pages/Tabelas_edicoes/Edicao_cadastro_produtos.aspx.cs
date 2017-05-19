using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebLogin.Classes;
using WebLogin.Persistencia;
using System.Data;

public partial class pages_Tabelas_edicoes_Edicao_cadastro : System.Web.UI.Page
{
    private void Carrega() { ProdutoBD bd = new ProdutoBD(); DataSet ds = bd.SelectAll(); GridView1.DataSource = ds.Tables[0].DefaultView; GridView1.DataBind(); }
    protected void Page_Load(object sender, EventArgs e)
    {
        Carrega();

    }


    protected void GridView1_RowCommand(object sender, GridViewCommandEventArgs e)
    {
        int codigo = 0;
        switch (e.CommandName)
        {
            case "Alterar":
                codigo = Convert.ToInt32(e.CommandArgument); Session["ID"] = codigo;
                msgalterarprod.Text = "Pronto pra alterar o produto de id :" + codigo;
                break;
            case "Deletar":
                codigo = Convert.ToInt32(e.CommandArgument); ProdutoBD bd = new ProdutoBD();
                bd.Delete(codigo); Carrega();
                break;
            default: break;
        }
    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        ProdutoBD bd = new ProdutoBD(); Produto produto = bd.Select(Convert.ToInt32(Session["ID"]));
        produto.Modelo = modelo.Text;
        produto.Quantidade = Convert.ToString(Quantidade.Text);
        if (bd.Update(produto)) { msgalterarprod.Text = "Funcionário alterado com sucesso"; modelo.Focus();Carrega(); }
        else { msgalterarprod.Text = "Erro ao salvar."; }
    }
}