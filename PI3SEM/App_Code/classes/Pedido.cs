using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Descrição resumida de Pedido
/// </summary>
public class Pedido
{
    public string Codigo { get; set; }
    public string Datahora { get; set; }
    public string Statuspedido { get; set; }
    public string Id_cliente { get; set; }
    public string Id_produto { get; set; }
    public string Quantidade { get; set; }


    public Pedido()
    {
        //
        // TODO: Adicionar lógica do construtor aqui
        //
    }
}