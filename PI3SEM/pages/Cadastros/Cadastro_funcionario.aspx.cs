using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebLogin.Classes;
using WebLogin.Persistencia;


public partial class pages_Cadastros_Cadastro_funcionario : System.Web.UI.Page
{
    public void cadastro_funcionario()
    {
        
        Funcionario funcionario = new Funcionario();
        funcionario.Setor = txt_fun_setor.Text;
        funcionario.Cargo = txt_fun_cargo.Text;
        funcionario.Sexo = txt_fun_sexo.Text;
        funcionario.docteste = txt_fun_documento.Text;
        FuncionarioBD bd = new FuncionarioBD();
        if (bd.Insert(funcionario)) { msg.Text = "CADASTRADO COM SUCESSO"; }
        else { msg.Text = "NÃO FOI POSSIVEL CADASTRAR "; }

        Pessoa pessoa = new Pessoa();
        pessoa.Documento = txt_fun_documento.Text;
        pessoa.Nome = txt_fun_nome.Text;
        pessoa.Telefone = Convert.ToInt32(txt_fun_telefone.Text);
        pessoa.Cidade = txt_fun_cidade.Text;
        pessoa.Endereço = txt_fun_endereco.Text;
        pessoa.Email = txt_fun_email.Text;
        pessoa.Cep = txt_fun_cep.Text;
        pessoa.Senha = txt_fun_senha.Text;

        PessoaBD bd2 = new PessoaBD();
        if (bd2.Insert(pessoa)) { msg.Text = "CADASTRADO COM SUCESSO"; txt_fun_senha.Text = ""; txt_fun_cep.Text = ""; txt_fun_email.Text = ""; txt_fun_endereco.Text=""; txt_fun_cidade.Text = ""; txt_fun_telefone.Text = ""; txt_fun_nome.Text = ""; txt_fun_documento.Text = ""; txt_fun_sexo.Text = ""; txt_fun_cargo.Text = ""; txt_fun_setor.Text = ""; txt_fun_documento.Text = "";}
        else { msg.Text = "NÃO FOI POSSIVEL CADASTRAR "; }



    }
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        cadastro_funcionario();

    }
}