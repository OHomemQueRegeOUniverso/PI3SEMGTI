using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebLogin.Persistencia;
using WebLogin;
using WebLogin.Classes;
public partial class pages_Cadastros_Cadastro_materiaprima : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }
    private void Cadastro_materiaprima()
    {
        Materiaprima matprim = new Materiaprima();
        matprim.Nome = txt_matprim_nome.Text;
        matprim.Quantidade = txt_matprim_quantidade.Text;
        MateriaprimaBD bd = new MateriaprimaBD();
        if (bd.Insert(matprim)) { msg.Text = "CADASTRADO COM SUCESSO"; txt_matprim_nome.Text = ""; txt_matprim_quantidade.Text = ""; }
        else { msg.Text = "NÃO FOI POSSIVEL CADASTRAR "; }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Cadastro_materiaprima();
    }
}