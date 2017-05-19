using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using WebLogin.Persistencia;
public partial class pages_Listagem_Listar_pedidos : System.Web.UI.Page
{
    private void Carrega()
    {
        PedidoBD bd = new PedidoBD();
       
        DataSet ds = bd.SelectAll();
        GridView1.DataSource = ds.Tables[0].DefaultView;
        GridView1.DataBind();
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        Carrega();
    }
}