<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="ImageStoragePOC.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server" method="post" >
        <div>
            <table>
                <tr>
                    <td> Enter Image Path : </td>
                    <td>
                        <asp:FileUpload ID="FileUpload1" runat="server" />
         <br />
                   
                        </td>
                </tr>
                <tr>
                    <td> Enter Job ID : </td>
                    <td><asp:TextBox ID="TextBox2" runat="server" MaxLength="10"></asp:TextBox>
                   <asp:RequiredFieldValidator ID="RequiredFieldValidator2" runat="server" ForeColor="Red" ControlToValidate="TextBox2" ErrorMessage="Enter Job ID"
                        ></asp:RequiredFieldValidator>
                        </td>
                </tr>
                <tr>
                    <td> Enter Image Id : </td>
                    <td><asp:TextBox ID="TextBox3" runat="server" MaxLength="10"></asp:TextBox>                 
                    <asp:RequiredFieldValidator ID="RequiredFieldValidator3" runat="server" ForeColor="Red" ControlToValidate="TextBox3" ErrorMessage="Enter Image ID">
                    </asp:RequiredFieldValidator>
                        </td>
                </tr>
                <tr>
                    <td><asp:Button ID="Button1" runat="server" Text="Upload" OnClick="Button1_Click" /></td>
                </tr>
            </table>
                
            <asp:Label ID="Label1" runat="server" Text="" Font-Bold="true"></asp:Label><br />
            <asp:HyperLink ID="HyperLink1" runat="server"></asp:HyperLink><br /><br />
        
            <asp:Label ID="Label2" runat="server" Text="" Font-Bold="true"></asp:Label><br />

            <asp:HyperLink ID="HyperLink2" runat="server"></asp:HyperLink>


        </div>
    </form>
</body>
</html>
