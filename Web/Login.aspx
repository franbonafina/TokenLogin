<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login.aspx.cs" EnableEventValidation="false" Inherits="Login" %>
<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="cc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link href="css/admin.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        .style1
        {
            font-size: x-large;
            font-weight: bold;
        }
        
        
        
    </style>      
    
    
    <title>AdminTool</title>
    <link  rel="image" src=./images/icon"/>
</head>
<body>

    <table width="100%" border="0" bgcolor="#006699">
        <tr height="10%">
        <td  width="20%">        
        </td>
        <td align="center">
        <div style="color:White" <span class="style1">AdminTool</span></div>
        </td>
        <td width="20%"></td>
        </tr>    
    </table>

    <form id="form1" runat="server">
    <div>
        <br><br><br><br><br>
        <table border="0" style="width:100%">
            <tr>
                <td align="center">                    
                    <table border="0" cellpadding="5" cellspacing="5">

                        <tr>
                            <td colspan="2" align="center">
                                <asp:Label runat="server" ID="lblErrText" Text="" ForeColor="Red"></asp:Label>
                            </td>
                        </tr>


                        <tr>
                            <td style="font-size:larger">
                                User:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtUser"></asp:TextBox>
                            </td>                            
                        </tr>

                        <tr>
                            <td style="font-size:larger">
                                Password:
                            </td>
                            <td>
                                <asp:TextBox runat="server" ID="txtPwd" TextMode="Password"></asp:TextBox>                                
                            </td>                            
                        </tr>

                        <tr>
                            <td colspan="2" align="center">
                                <asp:Button runat="server" ID="btnLogin" OnClick="btnLogin_Click" Text="Log In"/>                                
                            </td>

                        </tr>

                    </table>

                </td>
            </tr>


        </table>

    
    </div>
    </form>
</body>
</html>
