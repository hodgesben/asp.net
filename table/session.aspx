<%@ Page Language="C#" AutoEventWireup="true" CodeFile="session.aspx.cs" Inherits="db" EnableSessionState=true%>

<!DOCTYPE html>
<head>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
  <style>
      p{font-size: 15px;}
  </style>
</head>

<body>
  <form id="adminPage" runat="server">  
    <asp:Button id="sessionHome" onclick="goHome" runat="server" Text="Session Home"></asp:Button>
    <asp:Button id="adminHome" onclick="goAdminHome" runat="server" Text="Admin Home"></asp:Button>

    <h1>Session Table</h1>
    <asp:Panel ID="modifyList" runat="server" Wrap="true" Visible="true">
      <p>Choose What you would Like to do Add/Update/Delete</p>
      <asp:DropDownList ID="selectTable" runat="server">
        <asp:ListItem Enabled="true" Text="Add" Value="1"></asp:ListItem>
        <asp:ListItem Text="Update" Value="2"></asp:ListItem>
        <asp:ListItem Text="Delete" Value="3"></asp:ListItem>
      </asp:DropDownList>
      <asp:Button id="AddUpdteDelete" onclick="buttonAUD" runat="server" Text="Next"></asp:Button><br><br>
    </asp:Panel>

    <!-- ADD PANNELS -->
    <asp:Panel ID="addPanel" runat="server" Wrap="true" Visible="false">
      <h2>enter the following information</h2>
      <h3>Session Name</h3><asp:TextBox ID="add_sessionNameTB" MaxLength="20" runat="server"/> 
      <h3>Session Date</h3><asp:TextBox ID="add_sessionDateTB" MaxLength="20" runat="server"/> 
      <asp:Button id="btnSubmit" onclick="add_record" runat="server" Text="Add Record"></asp:Button><br><br>
   </asp:Panel>

   <asp:Panel ID="addConformation" runat="server" Wrap="true" Visible="false">
     <p>Record has been successfully Added</p>
   </asp:Panel>

    <!-- UPDATE PANNELS -->

    <asp:Panel ID="updateTable" runat="server" Wrap="true" Visible="false">
      <h3>Pick which record you would like to Update</h3>
      <asp:ListBox id="update_sessionNamesLB" AutoPostBack="true" OnSelectedIndexChanged="update_record" runat="server"/></asp:ListBox><br><br>
    </asp:Panel>

    <asp:Panel ID="updatePannel" runat="server" Wrap="true" Visible="false">
      <h2>Update the record you selected</h2>
      <asp:label id="update_id" runat="server" Height="128px" Width="464px" Font-Size="Small" Font-Names="Verdana" ForeColor="Maroon"></asp:label> 
      <h3>Session Name</h3>
      <asp:TextBox id="update_SessionNameTB" runat="server"/>
      <h3>Session Date</h3>
      <asp:TextBox id="update_SessionDateTB" runat="server"/>
      <asp:Button id=updateRecordBTN  onclick="update_recordBTN" runat="server" Text="Update"></asp:Button><br><br>
    </asp:Panel> 

    <asp:Panel ID="updateConformation" runat="server" Wrap="true" Visible="false">
     <p>Record has been successfully Updated</p>
    </asp:Panel>

    <!-- DELETE PANNELS -->

    <asp:Panel ID="deleteTable" runat="server" Wrap="true" Visible="false">
      <h3>Pick which record you would like to delete</h3>
      <asp:ListBox id="delete_sessionNamesLB" AutoPostBack="true" OnSelectedIndexChanged="delete_record" runat="server"/></asp:ListBox><br><br>
    </asp:Panel> 

    <asp:Panel ID="deletePannel" runat="server" Wrap="true" Visible="false">
      <h2>Delete the record you selected</h2>
      <asp:label id="delete_id" runat="server" Height="128px" Width="464px" Font-Size="Small" Font-Names="Verdana" ForeColor="Maroon"></asp:label> 
      <h3>Session Name</h3>
      <asp:TextBox id="delete_SessionNameTB" runat="server"/>
      <h3>Session Date</h3>
      <asp:TextBox id="delete_SessionDateTB" runat="server"/>
      <asp:Button id=deleteRecordBTN  onclick="delete_recordBTN" runat="server" Text="Delete"></asp:Button><br><br> 
    </asp:Panel>

    <asp:Panel ID="deleteConformation" runat="server" Wrap="true" Visible="false">
     <p>Record has been successfully Deleted</p>
    </asp:Panel>
        
  <asp:Panel ID="errorCheck" runat="server" Wrap="true" Visible="false">    
    <asp:label id="lblInfo" runat="server" Height="128px" Width="464px" Font-Size="Small" Font-Names="Verdana" ForeColor="Maroon"></asp:label>
  </asp:Panel>   
  </form> 
</body>
</html>