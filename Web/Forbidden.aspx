<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Forbidden.aspx.cs" Inherits="Forbidden" %>

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

                  <h1>Access forbidden! Please authorize from the main page.</h1>

                </td>
            </tr>


        </table>


    
    </div>
    </form>
</body>
</html>
