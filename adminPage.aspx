<%@ Page Language="C#" AutoEventWireup="true" CodeFile="adminPage.aspx.cs" Inherits="db" EnableSessionState=true%>

<!DOCTYPE html>
<head>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
  <style>
      p{font-size: 15px;}
      .hyperlink{font-size: 15px;}
  </style>
</head>

<body onload="Page_Load()">
  <h1>Connected to Admin Page<h1>
  <form id="adminPage" runat="server">
    <asp:Panel ID="tableList" runat="server" Wrap="true" Visible="true">
        <p>Choose which table You want to modify</p>
    <asp:DropDownList ID="selectTable" runat="server">
       <asp:ListItem Enabled="true" Text="Session" Value="1"></asp:ListItem>
       <asp:ListItem Text="Class" Value="2"></asp:ListItem>
       <asp:ListItem Text="Time" Value="3"></asp:ListItem>
       <asp:ListItem Text="Instructor" Value="4"></asp:ListItem>
       <asp:ListItem Text="Parent" Value="5"></asp:ListItem>
       <asp:ListItem Text="Enrollment" Value="6"></asp:ListItem>
     </asp:DropDownList>
     <asp:Button id="selectTableBTN" onclick="changeTable" runat="server" Text="Next"></asp:Button>
    </asp:Panel>
    <asp:Panel id="adminLinks" runat="server" Wrap="true" Visible="true">
      <asp:Label class="hyperlink" ID="assignPhotos" runat="server" Text="<a href='photo.aspx'>Assign Photos to Instuctors</a>"></asp:Label><br>
      <asp:Label class="hyperlink" ID="assignClasses" runat="server" Text="<a href='assignClasses.aspx'>Assign Classes to Instuctors</a>"></asp:Label><br>
      <asp:Label class="hyperlink" ID="gerateRoster" runat="server" Text="<a href='Roster.aspx'>Generate Roster</a>"></asp:Label>
    </asp:Panel>
  <asp:Panel ID="errorCheck" runat="server" Wrap="true" Visible="false">    
    <asp:label id="lblInfo" runat="server" Height="128px" Width="464px" Font-Size="Small" Font-Names="Verdana" ForeColor="Maroon"></asp:label>
  </asp:Panel>   
  </form> 
</body>
</html>