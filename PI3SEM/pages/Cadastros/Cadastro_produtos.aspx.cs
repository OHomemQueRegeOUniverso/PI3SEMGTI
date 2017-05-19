using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebLogin.Classes;
using WebLogin.Persistencia;
using System.Data;

public partial class pages_Cadastros_Cadastro_produtos : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void Cadastro_produto()
    {
        Produto produto = new Produto();
        produto.Modelo = txt_prod_modelo.Text;
        produto.Quantidade = txt_prod_quantidade.Text;
        ProdutoBD bd = new ProdutoBD();
        if (bd.Insert(produto)) { msg.Text = "CADASTRADO COM SUCESSO"; txt_prod_modelo.Text = ""; txt_prod_quantidade.Text = ""; }
        else { msg.Text = "NÃO FOI POSSIVEL CADASTRAR "; }
    }
    protected void Button1_Click(object sender, EventArgs e){ Cadastro_produto(); }
}