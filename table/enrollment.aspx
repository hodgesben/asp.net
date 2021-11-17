<%@ Page Language="C#" AutoEventWireup="true" CodeFile="enrollment.aspx.cs" Inherits="db" EnableSessionState=true%>

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
  
    <asp:Button id="classHome" onclick="goHome" runat="server" Text="Enrollment Home"></asp:Button>
    <asp:Button id="adminHome" onclick="goAdminHome" runat="server" Text="Admin Home"></asp:Button> 
    <h1>Enrollment Table</h1>

    <asp:Panel ID="modifyList" runat="server" Wrap="true" Visible="true">
      <p>Choose What you would Like to do Update/Delete</p>
      <asp:DropDownList ID="selectTable" runat="server">
        <asp:ListItem Text="Update" Value="1"></asp:ListItem>
        <asp:ListItem Text="Delete" Value="2"></asp:ListItem>
      </asp:DropDownList>
      <asp:Button id="AddUpdteDelete" onclick="buttonAUD" runat="server" Text="Next"></asp:Button>
    </asp:Panel>

    <!-- UPDATE PANNELS -->

    <asp:Panel ID="updateTable" runat="server" Wrap="true" Visible="false">
      <h3>Pick which record you would like to Update</h3>
      <asp:ListBox id="update_enrollLB" AutoPostBack="true" OnSelectedIndexChanged="update_record" runat="server"/></asp:ListBox>
    </asp:Panel>

    <asp:Panel ID="updatePannel" runat="server" Wrap="true" Visible="false">
      <h2>Update the record you selected</h2>
      <asp:label id="update_id" runat="server" Height="128px" Width="464px" Font-Size="Small" Font-Names="Verdana" ForeColor="Maroon"></asp:label> 
      <h3>Enrollment ID</h3><asp:TextBox id="update_enrollIDTB" runat="server"/>
      <h3>Class ID</h3><asp:TextBox id="update_classIDTB" runat="server"/>
      <h3>Session ID</h3><asp:TextBox id="update_sessionIDTB" runat="server"/>
      <h3>Instructor ID</h3><asp:TextBox id="update_instructorIDTB" runat="server"/>
      <h3>Child ID</h3><asp:TextBox id="update_childIDTB" runat="server"/>
      <asp:Button id=updateRecordBTN  onclick="update_recordBTN" runat="server" Text="Update"></asp:Button> 
    </asp:Panel> 

    <asp:Panel ID="updateConformation" runat="server" Wrap="true" Visible="false">
     <p>Record has been successfully Updated</p>
    </asp:Panel>

    <!-- DELETE PANNELS -->

    <asp:Panel ID="deleteTable" runat="server" Wrap="true" Visible="false">
      <h3>Pick which record you would like to delete</h3>
      <asp:ListBox id="delete_enrollLB" AutoPostBack="true" OnSelectedIndexChanged="delete_record" runat="server"/></asp:ListBox>
    </asp:Panel> 
    <asp:Panel ID="deletePannel" runat="server" Wrap="true" Visible="false">
      <h2>Delete the record you selected</h2>
      <asp:label id="delete_id" runat="server" Height="128px" Width="464px" Font-Size="Small" Font-Names="Verdana" ForeColor="Maroon"></asp:label> 
      <h3>Enrollment ID</h3><asp:TextBox id="delete_enrollIDTB" runat="server"/>
      <h3>Class ID</h3><asp:TextBox id="delete_classIDTB" runat="server"/>
      <h3>Session ID</h3><asp:TextBox id="delete_sessionIDTB" runat="server"/>
      <h3>Instructor ID</h3><asp:TextBox id="delete_instructorIDTB" runat="server"/>
      <h3>Child ID</h3><asp:TextBox id="delete_childIDTB" runat="server"/>
      <asp:Button id=deleteRecordBTN  onclick="delete_recordBTN" runat="server" Text="Delete"></asp:Button>  
    </asp:Panel> 
    
    <asp:Panel ID="deleteConformation" runat="server" Wrap="true" Visible="false">
     <p>Record has been successfully Deleted</p>
    </asp:Panel>
    
    <!-- ERROR PANNELS -->

  <asp:Panel ID="errorCheck" runat="server" Wrap="true" Visible="false">    
    <asp:label id="lblInfo" runat="server" Height="128px" Width="464px" Font-Size="Small" Font-Names="Verdana" ForeColor="Maroon"></asp:label>
  </asp:Panel>   
  </form> 
</body>
</html>