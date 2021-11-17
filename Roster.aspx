<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Roster.aspx.cs"  Inherits="db" EnableSessionState=true%>

<!DOCTYPE html>
<head>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
  <style>
      p{font-size: 15px;}
  </style>
</head>

<body onload="Page_Load()">
  <form id="adminPage" runat="server"> 
  
    <asp:Button id="rosterHome" onclick="goHome" runat="server" Text="Roster Home"></asp:Button>
    <asp:Button id="adminHome" onclick="goAdminHome" runat="server" Text="Admin Home"></asp:Button> 
    <h1>Roster Home</h1>
    
    <asp:Panel ID="rosterSelectForm" runat="server" Wrap="true" Visible="true">
      <br><div class="header1">Select the Session/Class you&#39d like to generate a roster for</div><br>
      <div>Session</div><br>
      <asp:DropDownList ID="sessionDDL" runat="server"></asp:DropDownList><br><br>
      <div>Class</div><br>
      <asp:DropDownList ID="classDDL" runat="server"></asp:DropDownList><br><br>
      <asp:Button id="getRos" onclick="getRoster" runat="server" Text="Get Roster"></asp:Button> 
    </asp:Panel>



    <asp:Panel ID="classInformationTable" runat="server" Wrap="true" Visible="false">

    <h3>Class Informtion</h3>
        <asp:Label ID="className" Text="" runat="server"/>
        <asp:Label ID="classDes" Text="" runat="server"/><br><br>
        <asp:Label ID="sessionName" Text="" runat="server"/>
        <asp:Label ID="sessionDates" Text="" runat="server"/><br><br>
    </asp:Panel>

    <asp:Panel ID="instructorInformationTable" runat="server" Wrap="true" Visible="false">
        <h3>Instructor Informtion</h3>
        <asp:GridView id="instructor_data" AutoGenerateColumns="false" BorderWidth="2" 
            BorderStyle="Solid" BorderColor="Red" CellPadding="5" GridLines="Vertical" runat="server">
          <HeaderStyle Font-Bold="true" BackColor="DarkBlue" ForeColor="White"/>
          <AlternatingRowStyle BackColor="LightGray"/>
          <Columns>
           <asp:BoundField DataField="instructor_lname" HeaderText="Last Name"/>
           <asp:BoundField DataField="instructor_fname" HeaderText="First Name"/>
           <asp:BoundField DataField="instructor_email" HeaderText="Email"/>
           <asp:BoundField DataField="instructor_phone" HeaderText="Phone"/>
           <asp:ImageField DataImageUrlField="photo_filename" HeaderText="Photo"></asp:ImageField>
          </Columns>
        </asp:GridView>
    </asp:Panel><br><br>

      <asp:Panel ID="childInformationTable" runat="server" Wrap="true" Visible="false">
          <h3>Child Informtion</h3>
        <asp:GridView id="child_data" AutoGenerateColumns="false" BorderWidth="2" 
            BorderStyle="Solid" BorderColor="Red" CellPadding="5" GridLines="Vertical" runat="server">
          <HeaderStyle Font-Bold="true" BackColor="DarkBlue" ForeColor="White"/>
          <AlternatingRowStyle BackColor="LightGray"/>
          <Columns>
           <asp:BoundField DataField="child_fname" HeaderText="Child First Name"/>
           <asp:BoundField DataField="child_lname" HeaderText="Child Last Name"/>
           <asp:BoundField DataField="parent_fname" HeaderText="Parent First Name"/>
           <asp:BoundField DataField="parent_lname" HeaderText="Parent Last Name"/>
            <asp:BoundField DataField="parent_email" HeaderText="Parent Email"/>
            <asp:BoundField DataField="parent_phone" HeaderText="Parent Phone"/>
          </Columns>
        </asp:GridView>
    </asp:Panel>
    
    <!-- ERROR PANNELS -->

  <asp:Panel ID="errorCheck" runat="server" Wrap="true" Visible="false">    
    <asp:label id="lblInfo" runat="server" Height="128px" Width="464px" Font-Size="Small" Font-Names="Verdana" ForeColor="Maroon"></asp:label>
  </asp:Panel>   
  </form> 
</body>
</html>