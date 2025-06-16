<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Student Attendance Tracker</title>
</head>
<body>
    <form id="form1" runat="server">
        <div style="padding:20px;">
            <h2>Mark Attendance</h2>

            <asp:Label ID="Label1" runat="server" Text="Select Student:"></asp:Label><br />
            <asp:DropDownList ID="ddlStudents" runat="server"></asp:DropDownList><br /><br />

            <asp:Label ID="Label2" runat="server" Text="Select Date:"></asp:Label><br />
            <asp:TextBox ID="txtDate" runat="server" placeholder="yyyy-mm-dd"></asp:TextBox><br /><br />

            <asp:CheckBox ID="chkPresent" runat="server" Text="Present" /><br /><br />

            <asp:Button ID="btnSubmit" runat="server" Text="Save Attendance" OnClick="btnSubmit_Click" /><br /><br />

            <asp:GridView ID="gvAttendance" runat="server" AutoGenerateColumns="true" />
        </div>
    </form>
</body>
</html>
