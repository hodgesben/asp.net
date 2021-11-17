<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userLogin.aspx.cs" Inherits="db" EnableSessionState=true%>
<!DOCTYPE html>
<head>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
  <style>
    .header1{
      font-size: 20px;
      font-weight:bold;
    }
  </style>
</head>

<body>
  <div>
    <form id="userForm" runat="server">
      <asp:Panel ID="userFormPanel" runat="server" Wrap="true" Visible="true">
                <!--REGISTERED USER --> 
      <p class="header1">Registered User</p>
                  <!--Email Adress -->
      <asp:Label ID="userlbl" Text="Username (email address)" runat="server"/></td><br><br>
      <asp:TextBox ID="userTB" MaxLength="20" runat="server"/></td><br><br>
                  <!--PASSWORD-->
      <asp:Label ID="lname_lbl" Text="Password " runat="server"/></td><br><br>
      <asp:TextBox ID="passwordTB" MaxLength="20" runat="server"/></td>
      <asp:Button id="grid" onclick="loginUser" runat="server" Text="Login"></asp:Button><br><br>
      <hr>
                  <!--NEW USER --> 
      <p class="header1">New User</p>
                <!--Email Adress -->
      <asp:Label ID="newUserEmail_lbl" Text="Email Address" runat="server"/></td><br><br>
      <asp:TextBox ID="newUserEmail" MaxLength="20" runat="server"/></td><br><br>
                <!--PASSWORD-->
      <asp:Label ID="newUserPassword_lbl" Text="Password " runat="server" /></td><br><br>
      <asp:TextBox ID="newUserPassword" MaxLength="20" runat="server"/></td><br><br>
                <!--Parents first name-->
      <asp:Label ID="newUserFirstName_lbl" Text="Parents First Name" runat="server"/></td><br><br>
      <asp:TextBox ID="newUserFirstName" MaxLength="20" runat="server"/></td><br><br>
                <!--Parents last name-->
      <asp:Label ID="newUserLastName_lbl" Text="Parents Last Name" runat="server"/></td><br><br>
      <asp:TextBox ID="newUserLastName" MaxLength="20" runat="server"/></td><br><br>
                    <!--Phone-->
      <asp:Label ID="newUserPhone_lbl" Text="Phone" runat="server"/></td><br><br>
      <asp:TextBox ID="newUserPhone" MaxLength="20" runat="server"/></td>

      <asp:Button id="grid2" onclick="regUser" runat="server" Text="Register"></asp:Button><br><br>
  </asp:Panel>

  <asp:Panel ID="adminaccess" runat="server" Wrap="true" Visible="true">
      <asp:Button id="adminButton" onclick="adminLogin" runat="server" Text="Admin Login"></asp:Button>
  </asp:Panel>

  <asp:Panel ID="errorChecker" runat="server" Wrap="true" Visible="false">    
    <asp:label id="errorInfo" runat="server" Height="128px" Width="464px" Font-Size="Small" Font-Names="Verdana" ForeColor="Maroon"></asp:label>
  </asp:Panel>
  </div>
  </form>
</body>
</html>