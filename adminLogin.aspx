<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminLogin.aspx.cs" Inherits="db" EnableSessionState=true%>
<!DOCTYPE html>
<head>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
  <style>
  .header1{
      font-size: 30px;
      font-weight: bolder:
  }
  </style>
</head>

<body>
  <form id="adminForm" runat="server">
    <asp:Panel ID="adminFormPanel" runat="server" Wrap="true" Visible="true">
                <!--REGISTERED USER --> 
      <p class="header1">Admin Login</p>
                  <!--Email Adress -->
      <asp:Label ID="AdminName_lbl" Text="Username" runat="server"/></td><br><br>
      <asp:TextBox ID="Aname" MaxLength="20" runat="server"/></td><br><br>
                  <!--PASSWORD-->
      <asp:Label ID="AdminPass_lbl" Text="Password" runat="server"/></td><br><br>
      <asp:TextBox ID="AdminPass" MaxLength="20" runat="server"/></td><br><br>
      <asp:Button id="AdminLoginButton" onclick="loginAdmin" runat="server" Text="Enter Admin Site"></asp:Button>
    </asp:panel>


    <asp:Panel ID="errorChecker" runat="server" Wrap="true" Visible="false">    
      <asp:label id="errorInfo" runat="server" Height="128px" Width="464px" Font-Size="Small" Font-Names="Verdana" ForeColor="Maroon"></asp:label>
    </asp:Panel>
  </form>
</body>
</html>
