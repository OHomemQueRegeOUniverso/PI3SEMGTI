<%@ Page Language="C#" AutoEventWireup="true" CodeFile="login.aspx.cs" Inherits="pages_login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>

  <script src="https://cdnjs.cloudflare.com/ajax/libs/prefixfree/1.0.7/prefixfree.min.js"></script>
  <link href="../css/loginstyle.css" rel="stylesheet" />
</head>
  
<body>
  <div class="body"></div>
		<div class="grad"></div>
		<div class="header">
			<div>Cerâmicas<span>Paturi</span></div>
		</div>
		<br />
        <form runat="server">
		<div class="login">		
                <asp:TextBox ID="txtEmail" Type="email" class="input1" runat="server" required=""></asp:TextBox>
                <asp:TextBox ID="txtSenha" Type="password" class="input2" runat="server" required=""></asp:TextBox>
                <asp:Label ID="msgLabel" runat="server" Text="" ></asp:Label>
				<asp:Button ID="btnLogar" class="buttonlogin" runat="server" Text="Entrar" OnClick="btnLogar_Click"  />
				
        </div>
        </form>
  
    <script src='http://cdnjs.cloudflare.com/ajax/libs/jquery/2.1.3/jquery.min.js'></script>

</body>
</html>
