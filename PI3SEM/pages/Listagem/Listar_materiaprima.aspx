<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Listar_materiaprima.aspx.cs" Inherits="pages_Listagem_Listar_materiaprima" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>

     <title>Cerâmicas Paturi</title>
    
    <script type="text/javascript">
        window.onload = function () {
            //Função para rodar no LoadScreen 
        };
    </script>

    <link href="../../Content/bootstrap.min.css" rel="stylesheet" />
    <link href="../../css/font-awesome.min.css" rel="stylesheet" />


    <link href="../../css/custom.css" rel="stylesheet" />
    <link href="../../css/forms.css" rel="stylesheet" />
   
</head>

<body class="nav-md" style="overflow-x: hidden">
        <form runat="server">
        <div class="container body">
            <div class="main_container">
                <div class="col-md-3 left_col">
                    <div class="left_col scroll-view">
                        <div class="navbar nav_title" style="border: 0;">
                            <a href="homepage.aspx" class="site_title"><i class="fa fa-refresh fa-spin"></i><span>Paturi System</span></a>
                        </div>
                        <div class="clearfix"></div>
                        <!-- menu profile quick info -->
                        <div class="profile">
                            <div class="profile_pic">
                                <img src="../../imagens/img.jpg" alt="..." class="img-circle profile_img"/>
                            </div>
                            <div class="profile_info">
                                <span>Bem Vindo,</span>
                                <h2>Administrador</h2>
                            </div>
                        </div>
                        <!-- /menu profile quick info -->
                        <br />
                        <!-- sidebar menu -->

                        <div id="sidebar-menu" class="main_menu_side hidden-print main_menu">
                            <div class="menu_section">
                                <h3>General</h3>
                                <ul class="nav side-menu">
                                    <li><a><i class="fa fa-edit"></i>Cadastros <span class="fa fa-chevron-down"></span></a>
                                        <ul class="nav child_menu">
                                           
                                            <li><a href="../Cadastros/Cadastro_produtos.aspx">Cadastrar novo produto</a></li>
                                            <li><a href="../Cadastros/Cadastro_cliente.aspx">Cadastrar novo cliente</a></li>
                                            <li><a href="../Cadastros/Cadastro_novopedido.aspx">Cadastrar novo pedido</a></li>
                                            <li><a href="../Cadastros/Cadastro_materiaprima.aspx">Cadastrar nova materia prima</a></li>
                                            
                                        </ul>
                                    </li>
                                    <li><a><i class="fa fa-desktop"></i>Consultar <span class="fa fa-chevron-down"></span></a>
                                        <ul class="nav child_menu">
                                           
                                            <li><a href="../Listagem/Listar_clientes.aspx">Listar Clientes</a></li>
                                            <li><a href="../Listagem/Listar_materiaprima.aspx">Listar materia prima</a></li>
                                            <li><a href="../Listagem/Listar_pedidos.aspx">Listar pedidos</a></li>
                                             <li><a href="../Listagem/Listar_produtos.aspx">Listar produtos</a></li>
                                           
                                        </ul>
                                    </li>
                                    <li><a><i class="fa fa-table"></i>Editar <span class="fa fa-chevron-down"></span></a>
                                        <ul class="nav child_menu">           
                                            <li><a href="../Tabelas_edicoes/Edicao_cadastro_produtos.aspx">Edição de produtos</a></li>
                                            <li><a href="../Tabelas_edicoes/Edicao_pedido.aspx">Edição de pedidos</a></li>
                                        </ul>
                                    </li>
                                    <li><a><i class="fa fa-bar-chart-o"></i>Relatorios <span class="fa fa-chevron-down"></span></a>
                                        <ul class="nav child_menu"></ul>
                                    </li>
                                </ul>
                            </div>
                        </div>

                    </div>
                </div>
            </div>
        </div>


        <!--BARRA DE OPÇÕES SUPERIOR -->
        <div class="top_nav">
            <div class="nav_menu">

                <nav>
                    <div class="nav toggle">
                        <a id="menu_toggle"><i class="fa fa-bars"></i></a>
                    </div>

                    <ul class="nav navbar-nav navbar-right">
                        <li class="">
                            <a href="javascript:;" class="user-profile dropdown-toggle" data-toggle="dropdown" aria-expanded="false">
                                <img src="../../imagens/img.jpg" alt=""/><asp:Label ID="userlabel" runat="server" Text=""></asp:Label>
                                <span class=" fa fa-angle-down"></span>
                            </a>
                            <ul class="dropdown-menu dropdown-usermenu pull-right">
                                <li><a href="javascript:;">Conta</a></li>
                                <li><a href="javascript:;">Ajuda</a></li>
                                <li><a href="login.aspx"><i class="fa fa-sign-out pull-right"></i>Log Out</a></li>
                            </ul>
                        </li>
                    </ul>
                </nav>
            </div>
        </div>

        <!-- CONTEUDO-->


        <asp:GridView ID="GridView1" runat="server" Style="display:inline-block !important; margin-left: 300px; margin-top: 40px; width: auto;" 
        CssClass="table table-striped table-bordered table-condensed"></asp:GridView>






        <!--FIM CONTEUDO -->






    </form>

    <!-- jQuery -->
    <script src="../../Scripts/jquery-1.9.1.min.js"></script>
    <!-- Bootstrap -->
    <script src="../../Scripts/bootstrap.min.js"></script>
    <!-- Custom Theme Scripts -->
    <script src="../../Scripts/custom.js"></script>

</body>
</html>
