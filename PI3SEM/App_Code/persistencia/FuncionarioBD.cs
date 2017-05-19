using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebLogin.Classes;

namespace WebLogin.Persistencia
{
    /// <summary>
    /// Summary description for PessoaBD
    /// </summary>
    public class FuncionarioBD
    {
        public Funcionario Autentica(string email, string senha)
        {
            Funcionario obj = null;

            System.Data.IDbConnection objConexao; System.Data.IDbCommand objCommand; System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("select * from fun_funcionario,pes_pessoa where pes_email = ?email and pes_senha = ?senha", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?email",email));
            objCommand.Parameters.Add(Mapped.Parameter("?senha",senha));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Funcionario();
                obj.Email = Convert.ToString(objDataReader["pes_email"]);
                obj.Senha = Convert.ToString(objDataReader["pes_senha"]);
                obj.Cargo = Convert.ToString(objDataReader["fun_cargo"]);
            }
            objDataReader.Close(); objConexao.Close(); objCommand.Dispose(); objConexao.Dispose(); objDataReader.Dispose();

            return obj;
        }
        public bool Insert(Funcionario funcionario)
        {

            System.Data.IDbConnection objConexao; System.Data.IDbCommand objCommand;
            string sql = "insert into fun_funcionario(fun_setor,fun_cargo,fun_sexo,pes_pessoa_pes_documento) values (?fun_setor, ?fun_cargo, ?fun_sexo, ?pes_pessoa_pes_documento)";
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command(sql, objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?fun_setor", funcionario.Setor));
            objCommand.Parameters.Add(Mapped.Parameter("?fun_cargo", funcionario.Cargo));
            objCommand.Parameters.Add(Mapped.Parameter("?fun_sexo", funcionario.Sexo));
            objCommand.Parameters.Add(Mapped.Parameter("?pes_pessoa_pes_documento", funcionario.docteste));
            objCommand.ExecuteNonQuery(); objConexao.Close(); objCommand.Dispose(); objConexao.Dispose();

            return true;
        }
        public Funcionario Select( string cpf)
        {
            Funcionario obj = null;

            System.Data.IDbConnection objConexao; System.Data.IDbCommand objCommand; System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("select * from fun_funcionario, pes_pessoa where pes_pessoa_pes_cpf = ?pes_cpf", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?pes_cpf", cpf));
            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read()) {
                obj = new Funcionario();
                obj.Email = Convert.ToString(objDataReader["pes_email"]);
                obj.Senha = Convert.ToString(objDataReader["pes_senha"]);
                //obj.Tipo = Convert.ToInt32(objDataReader["tipo"]);
            }
            objDataReader.Close(); objConexao.Close();objCommand.Dispose(); objConexao.Dispose(); objDataReader.Dispose();


            return obj;
        }
        public Funcionario Altera(String pes_cpf)
        {
            Funcionario obj = null;
            System.Data.IDbConnection objConexao;System.Data.IDbCommand objCommand;System.Data.IDataReader objDataReader;
            objConexao = Mapped.Connection();
            objCommand = Mapped.Command("SELECT * FROM fun_funcionario where pes_pessoa_pes_cpf= ?cpf", objConexao);
            objCommand.Parameters.Add(Mapped.Parameter("?cpf", pes_cpf));

            objDataReader = objCommand.ExecuteReader();
            while (objDataReader.Read())
            {
                obj = new Funcionario();
                obj.Setor = Convert.ToString(objDataReader["fun_setor"]);
                obj.Cargo = Convert.ToString(objDataReader["fun_cargo"]);
                obj.Sexo = Convert.ToString(objDataReader["fun_sexo"]);
                
            }

            objDataReader.Close();
            objConexao.Close();

            objCommand.Dispose();
            objConexao.Dispose();
            objDataReader.Dispose();

            return obj;
        }

        public FuncionarioBD()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}