using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLogin.Classes;
using System.Data;
/// <summary>
/// Descrição resumida de PessoaBD
/// </summary>

namespace WebLogin.Persistencia
{
    public class PessoaBD
    {
        public bool Insert(Pessoa pessoa)
        {
                System.Data.IDbConnection objConexao;
                System.Data.IDbCommand objCommand;
                string sql = "insert into pes_pessoa(pes_documento,pes_nome,pes_telefone ,pes_cidade,pes_endereco,pes_email,pes_cep,pes_senha) VALUES (?pes_documento,?nome,?telefone,?cidade,?endereco,?email,?cep,?senha)";
                objConexao = Mapped.Connection();
                objCommand = Mapped.Command(sql, objConexao);
                objCommand.Parameters.Add(Mapped.Parameter("?pes_documento", pessoa.Documento));
                objCommand.Parameters.Add(Mapped.Parameter("?nome", pessoa.Nome));
                objCommand.Parameters.Add(Mapped.Parameter("?telefone", pessoa.Telefone));
                objCommand.Parameters.Add(Mapped.Parameter("?cidade", pessoa.Cidade));
                objCommand.Parameters.Add(Mapped.Parameter("?endereco", pessoa.Endereço));
                objCommand.Parameters.Add(Mapped.Parameter("?email", pessoa.Email));
                objCommand.Parameters.Add(Mapped.Parameter("?cep", pessoa.Cep));
                objCommand.Parameters.Add(Mapped.Parameter("?senha", pessoa.Senha));
                objCommand.ExecuteNonQuery(); objConexao.Close(); objCommand.Dispose(); objConexao.Dispose();
            
           
            return true;
        }

        public DataSet SelectAll()
        {
            DataSet ds = new DataSet();
            System.Data.IDbConnection objConexao; System.Data.IDbCommand objCommand; System.Data.IDataAdapter objDataAdapter;
            objConexao = Mapped.Connection(); objCommand = Mapped.Command("SELECT * FROM pes_pessoa WHERE pes_cpf = ?cpf", objConexao);
            //objCommand.Parameters.Add(Mapped.Parameter("?cpf", ));
            objDataAdapter = Mapped.Adapter(objCommand); objDataAdapter.Fill(ds); objConexao.Close(); objCommand.Dispose(); objConexao.Dispose();
            return ds;
        }
        public bool UpdatePessoa(Pessoa pessoa)
        {
            System.Data.IDbConnection objConexao;
            System.Data.IDbCommand objCommand;
            string sql = "UPDATE pes_pessoa SET pes_nome= ?nome, pes_telefone = ?telefone, pes_cidade = ?cidade, pes_endereco = ?endereco, pes_email = ?email, pes_cep = ?cep, pes_senha = ?senha  WHERE pes_cpf = ?cpf";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?nome", pessoa.Nome));
            objCommand.Parameters.Add(Mapped.Parameter("?telefone", pessoa.Telefone));
            objCommand.Parameters.Add(Mapped.Parameter("?cidade", pessoa.Cidade));
            objCommand.Parameters.Add(Mapped.Parameter("?endereco", pessoa.Endereço));
            objCommand.Parameters.Add(Mapped.Parameter("?email", pessoa.Email));
            objCommand.Parameters.Add(Mapped.Parameter("?cep", pessoa.Cep));
            objCommand.Parameters.Add(Mapped.Parameter("?senha", pessoa.Senha));
            objCommand.ExecuteNonQuery();objConexao.Close();objCommand.Dispose();objConexao.Dispose();

            return true;
        }


        public PessoaBD()
        {
            //
            // TODO: Adicionar lógica do construtor aqui
            //
        }
    }
}