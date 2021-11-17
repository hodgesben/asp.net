<%@ Page Language="C#" AutoEventWireup="true" CodeFile="thankYou.aspx.cs" Inherits="db" EnableSessionState=true%>

<!DOCTYPE html>
<head>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
  <style>

  .header{
		font-size: 3em;
    text-align: center;
    font-weight: bolder;
    }

		body{
			font-size: 10px;
		}

  </style>
</head>

<body onload="Page_Load()">
  <form id="thankYouPage" runat="server">
  <h1 class="header">Thank You<h1>
	<asp:Panel ID="enrolmentInfo" runat="server" Wrap="true" Visible="true">
		<asp:Label ID="name" runat="server"/><br><br>
		<asp:Label ID="session" runat="server"/><br><br>
		<asp:Label ID="class2" runat="server"/><br><br>
		<asp:Label ID="cost" runat="server"/><br><br>
		<asp:Label ID="time" runat="server"/><br><br>
		<asp:Button ID=emailAdm  onclick="emailAdmin" runat="server" Text="Contact Us"></asp:Button> 
	</asp:Panel>
	</form>
</body>
</html>