<%@ Page Language="C#" AutoEventWireup="true" CodeFile="userPage.aspx.cs" Inherits="db" EnableSessionState=true%>

<!DOCTYPE html>
<head>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<title></title>
  <style>

  .sessionGridView {
     font-size: 15px; 
  }
  .text {font-size: 20px;}

  body {font-size: 8px;}

  .header1{
    font-size: 20px;
    font-weight:bolder;
    }

  .classCost{text-align: right;}
  </style>
</head>

<body onload="Page_Load()">
    <h1>Find Your Lesson<h1>
    <form id="lessonSelection" runat="server">
    <asp:Panel ID="sessionDates" runat="server" Wrap="true" Visible="true">
      <asp:GridView class="sessionGridView" id="sessionData" AutoGenerateColumns="false" BorderWidth="2" BorderStyle="Solid" GridLines="Vertical" runat="server">
      <HeaderStyle Font-Bold="true" BackColor="White" ForeColor="Black"/>
      <AlternatingRowStyle BackColor="LightGray"/>
      <Columns>
        <asp:BoundField HeaderText="Session Dates" DataField="session_name"/>
        <asp:BoundField DataField="session_dates"/>
      </Columns>
      </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="sessionImg" runat="server" Wrap="true" Visible="true">
      <img src="swim_image.png" alt="Swim Table" height= 300px; Width="600px"><br><br>
    </asp:Panel>


    <asp:Panel ID="text" runat="server" Wrap="true" Visible="true">
    <div class="text">All classes meet for 30 minutes<br>Level 1-7 classes meet for 60 minutes<br>All sessions are 6 lessons<br><br>class fees per student</div><br>
    </asp:Panel>


    <asp:Panel ID="costTable" runat="server" Wrap="true" Visible="true">
      <asp:GridView class="classFeeTable" id="costFeeTable" AutoGenerateColumns="false" BorderWidth="3" BorderStyle="Solid" GridLines="Vertical" runat="server" >
      <HeaderStyle Font-Bold="true" BackColor="White" ForeColor="Black"/>
      <AlternatingRowStyle BackColor="LightGray"/>
      <Columns >
        <asp:BoundField HeaderText="Class Level" DataField="class_name"/>
        <asp:BoundField  HeaderText="Price" DataField="class_cost"/>
      </Columns>
      </asp:GridView>
    </asp:Panel>

    <asp:Panel ID="classEnrolment" runat="server" Wrap="true" Visible="true">
      <br><div class="header1">Select one each of the following</div><br>
      <div>Session Selection</div><br>
      <asp:DropDownList ID="sessionDDL" runat="server"></asp:DropDownList><br><br>
      <div>Class Type</div><br>
      <asp:DropDownList ID="classDDL" runat="server"></asp:DropDownList><br><br>
      <div>Session Time</div><br>
      <asp:DropDownList ID="timeDDL" runat="server"></asp:DropDownList><br><br>
      
      <asp:Label ID="pName" Text="" runat="server"/><br><br>
      <asp:Label ID="pEmail" Text="" runat="server"/><br><br>
      <asp:Label ID="child_fNameLBL" Text="Child first name" runat="server"/></td><br><br>
      <asp:TextBox ID="child_fName" MaxLength="20" runat="server" required="required"/></td><br><br>
      <asp:Label ID="child_lNameLBL" Text="Child last name" runat="server"/></td><br><br>
      <asp:TextBox ID="child_lName" MaxLength="20" runat="server" required="required"/></td><br><br>
      <asp:Button id="childReg" onclick="regChild" runat="server" Text="Register"></asp:Button><br><br>
    </asp:Panel>

  <asp:Panel ID="errorCheck" runat="server" Wrap="true" Visible="false">    
    <asp:label id="lblInfo" runat="server" Height="128px" Width="464px" Font-Size="Small" Font-Names="Verdana" ForeColor="Maroon"></asp:label>
  </asp:Panel>    
  </form>
</body>
</html>