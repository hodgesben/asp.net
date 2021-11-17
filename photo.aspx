<%@ Page Language="C#" AutoEventWireup="true" CodeFile="photo.aspx.cs" Inherits="db" EnableSessionState=true%>

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
  
    <asp:Button id="classHome" onclick="goHome" runat="server" Text="Photo Home"></asp:Button>
    <asp:Button id="adminHome" onclick="goAdminHome" runat="server" Text="Admin Home"></asp:Button> 
    <h1>Photo Add</h1>

    <!-- ADD PANNELS -->

    <asp:Panel ID="addPanel" runat="server" Wrap="true" Visible="true">
      <p>Pick an Instructor to add their Photo</p>
      <asp:DropDownList id="intructorNameDDL" runat="server"/></asp:DropDownList><br><br>
      <p>Choose the file to add to this instructor</p>
      <asp:FileUpload id="FileUploadControl" runat="server" />
      <asp:Button runat="server" id="UploadButton" text="Upload" onclick="UploadButton_Click" />
       <asp:Label runat="server" id="StatusLabel" text="Upload status: " />
      <asp:Image ID="Image1" runat="server" /><br><br>
      <asp:Button runat="server" id="UploadButton2" text="Add Photo" onclick="Update_Photo_Click" />
   </asp:Panel>    

    <asp:Panel ID="selectFile" runat="server" Wrap="true" Visible="false">      
    </asp:Panel> 

   <asp:Panel ID="addConformation" runat="server" Wrap="true" Visible="false">
     <p>Photo has been successfully Added</p>
   </asp:Panel>
    
    <!-- ERROR PANNELS -->

  <asp:Panel ID="errorCheck" runat="server" Wrap="true" Visible="false">    
    <asp:label id="lblInfo" runat="server" Height="128px" Width="464px" Font-Size="Small" Font-Names="Verdana" ForeColor="Maroon"></asp:label>
  </asp:Panel>   
  </form> 
</body>
</html>