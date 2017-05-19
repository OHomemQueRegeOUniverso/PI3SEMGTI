using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebLogin.Classes;
using WebLogin.Persistencia;

public partial class pages_login : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {   

    }
    private bool IsPreenchido(string str) //metodo para saber se o retorno esta vazio
    {
        bool retorno = false;
        if (str != string.Empty)
        {
            retorno = true;
        }
        return retorno;
    }
    private bool UsuarioEncontrado(Funcionario funcionario) 
    {
        bool retorno = false;
        if (funcionario != null)
        {
            retorno = true;
        }
        return retorno;
    }

    protected void btnLogar_Click(object sender, EventArgs e) 
    {
        string email = txtEmail.Text.Trim();
        string senha = txtSenha.Text.Trim();

        if (!IsPreenchido(email)) 
        {
            msgLabel.Text = "Preencha o email";
            txtEmail.Focus();
            return;
        }
        if (!IsPreenchido(senha)) 
        {
            msgLabel.Text = "Preencha a senha";
            txtSenha.Focus();
            return;
        }        FuncionarioBD bd = new FuncionarioBD();
        Funcionario funcionario = new Funcionario();
        funcionario = bd.Autentica(email, senha);
        if (!UsuarioEncontrado(funcionario))
        {
            msgLabel.Text = "Usuário não encontrado";
            txtEmail.Focus();
            return;
        }
        Session["ID"] = funcionario.Cargo;
        switch (funcionario.Cargo)
        {
            case "Administrador":
                Response.Redirect("homepage.aspx");
                break;
            case "Funcionario":
                Response.Redirect("homepage.aspx");
                break;
            default:break;

        }
        
    }
}