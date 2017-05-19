using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebLogin.Persistencia;
using WebLogin.Classes;

public partial class pages_Cadastros_Cadastro_cliente : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    public void cadastro_cliente()
    {
        Cliente cliente = new Cliente();
        cliente.Cnpj = txt_cli_cnpj.Text;
        ClienteBD bd = new ClienteBD();
        if (bd.Insert(cliente)) { msg.Text = "CADASTRADO COM SUCESSO";}
        else { msg.Text = "NÃO FOI POSSIVEL CADASTRAR "; }

        Pessoa pessoa = new Pessoa();
        pessoa.Documento = txt_cli_cnpj.Text;
        pessoa.Nome = txt_cli_nome.Text;
        pessoa.Telefone = Convert.ToInt32(txt_cli_telefone.Text);
        pessoa.Cidade = txt_cli_cidade.Text;
        pessoa.Endereço = txt_cli_endereco.Text;
        pessoa.Email =txt_cli_email.Text;
        pessoa.Cep = txt_cli_cep.Text;
        pessoa.Senha = "";
       
        PessoaBD bd2 = new PessoaBD();
        if (bd2.Insert(pessoa)) { msg.Text = "CADASTRADO COM SUCESSO"; txt_cli_cnpj.Text = ""; txt_cli_nome.Text = ""; txt_cli_telefone.Text = ""; txt_cli_cidade.Text = ""; txt_cli_endereco.Text = ""; txt_cli_email.Text = ""; txt_cli_cep.Text = ""; txt_cli_cep.Text = ""; txt_cli_cnpj.Text = ""; }
        else { msg.Text = "NÃO FOI POSSIVEL CADASTRAR "; }

        

    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        cadastro_cliente();
    }
}