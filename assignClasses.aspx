<%@ Page Language="C#" AutoEventWireup="true" CodeFile="assignClasses.aspx.cs" Inherits="db" EnableSessionState=true%>

<!DOCTYPE html>
<head>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
  <style>
     p{font-size: 15px;}
     #one_data{font-size: 15px;}
     .instuctorAssigned{font-size: 25px;}
  </style>
</head>

<body onload="Page_Load()">
  <form id="adminPage" runat="server">
    <asp:Button id="classHome" onclick="goHome" runat="server" Text="Assign Classes Home"></asp:Button>
    <asp:Button id="adminHome" onclick="goAdminHome" runat="server" Text="Admin Home"></asp:Button> 
    <h1>Assign Classes<h1>
    <asp:Panel ID="classAssign" runat="server" Wrap="true" Visible="true">
        <p>Choose a Class you want to Assign an Instuctor to</p>
    <asp:DropDownList ID="classAssignDDL" runat="server"></asp:DropDownList>
         <asp:Button id="classAssignBTN" onclick="Get_data" runat="server" Text="Next"></asp:Button>
    </asp:Panel>
    <asp:Panel ID="subEnrolTable" runat="server" Wrap="true" Visible="false">
        <asp:GridView id="one_data" AutoGenerateColumns="false" BorderWidth="2" 
            BorderStyle="Solid" BorderColor="Red" CellPadding="5" GridLines="Vertical" runat="server">
          <HeaderStyle Font-Bold="true" BackColor="DarkBlue" ForeColor="White"/>
          <AlternatingRowStyle BackColor="LightGray"/>
          <Columns>
           <asp:BoundField DataField="enrollment_id" HeaderText="Enrollment ID"/>
           <asp:BoundField DataField="class_id" HeaderText="Class ID"/>
           <asp:BoundField DataField="session_id" HeaderText="Session ID"/>
           <asp:BoundField DataField="child_id" HeaderText="Child ID"/>
          </Columns>
        </asp:GridView>
    </asp:Panel>
    <asp:Panel ID="instuctorAssign" runat="server" Wrap="true" Visible="false">
      <p>Choose which Instuctor you want to Assign to this class</p>
      <asp:DropDownList ID="instuctorAssignDDL" runat="server"></asp:DropDownList>
      <asp:Button id="instuctorAssignBTN" onclick="updateEnrolTable" runat="server" Text="Assign Instructor"></asp:Button>
    </asp:Panel>
    <asp:Panel ID="updateComplete" runat="server" Wrap="true" Visible="false">
      <h1 class="instuctorAssigned">Instuctor Asssigned to Class</h1>
    </asp:Panel>
  <asp:Panel ID="errorCheck" runat="server" Wrap="true" Visible="false">    
    <asp:label id="lblInfo" runat="server" Height="128px" Width="464px" Font-Size="Small" Font-Names="Verdana" ForeColor="Maroon"></asp:label>
  </asp:Panel>   
  </form> 
</body>
</html>