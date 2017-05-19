using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace WebLogin.Classes
{
    /// <summary>
    /// Summary description for Pessoa
    /// </summary>
    public class Funcionario:Pessoa
    {
        public string Setor { get; set; }
        public string Cargo { get; set; }
        public string Sexo { get; set; }
        public string docteste { get; set; }

        public Funcionario()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}