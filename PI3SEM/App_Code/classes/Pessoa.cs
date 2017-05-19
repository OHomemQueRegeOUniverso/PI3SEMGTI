using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
namespace WebLogin.Classes
{
    /// <summary>
    /// author: Flávio Dias Maia Neto
    /// </summary>
    public class Pessoa
    {
        public string Documento { get; set; }
        public string Nome { get; set; }
        public int Telefone { get; set; }
        public string Cidade { get; set; }
        public string Endereço { get; set; }
        public string Email { get; set; }
        public string Cep { get; set; }
        public string Senha { get; set; }
        
        public Cliente cliente { get; set; }
        public Pessoa()
        {
            //
            // TODO: Add constructor logic here
            //
        }
    }
}