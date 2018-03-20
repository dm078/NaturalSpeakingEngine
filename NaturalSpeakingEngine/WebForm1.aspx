<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="Rhipe_WebApp1.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Label ID="Label1" runat="server" Text="Please tell the system what do you want it to display by using your natural language:"></asp:Label>
        <br />
&nbsp;&nbsp;&nbsp;
        <asp:Label ID="Label2" runat="server" Text="E.g Draw a circle with a radius of 100"></asp:Label>
&nbsp;, Draw a square with a side length of 200 , Draw a rectangle with a width of 250 and a height of 400<br />
        <asp:TextBox ID="txtInput" runat="server" BackColor="#009999" Font-Bold="True" Font-Size="Large" Height="81px" TextMode="MultiLine" Width="896px">Draw a(n) &lt;shape&gt; with a(n) &lt;measurement&gt; of &lt;amount&gt; (and a(n) &lt;measurement&gt; of &lt;amount&gt;)</asp:TextBox>
&nbsp;&nbsp;&nbsp;
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Draw the Image" Width="148px" />
        <br />
        <asp:Label ID="Label3" runat="server" Text="Please note that only Isosceles Triangle, Scalene Triangle, Equilateral Triangle, Rectangle, Square, Octagon, Circle, Oval are supported at this point in time."></asp:Label>    
    </div>
        <br /><br />               
        <span id="myControl" runat="server"></span>
       
    </form>
    
   </body>
</html>
