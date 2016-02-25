<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Monitor.aspx.cs" Inherits="GaleProjects.Monitor" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="http://ajax.aspnetcdn.com/ajax/jQuery/jquery-1.10.0.min.js" type="text/javascript"></script>
<script src="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/jquery-ui.min.js" type="text/javascript"></script>
<link href="http://ajax.aspnetcdn.com/ajax/jquery.ui/1.9.2/themes/blitzer/jquery-ui.css"
    rel="Stylesheet" type="text/css" />
    <script src="~/Scripts/bootstrap.js"></script>
    <script src="~/Backbone.js"></script>
    <link href="~/Content/bootstrap.css" rel="Stylesheet" />
    <script type="text/javascript">

        $(document).ready(function () {
            Sys.WebForms.PageRequestManager.getInstance().add_endRequest(EndRequestHandler);
            //   Sys.WebForms.PageRequestManager.getInstance().beginAsyncPostBack();
            function EndRequestHandler(sender, args) {
                $("[id$=txtDate]").datepicker({
                    dayOfWeekStart: 1,
                    lang: 'es',
                    step: 1,
                    ampm: true,
                    showOn: 'button',
                    minDate: '-10d', // your min date
                    maxDate: '0d',
                    buttonImageOnly: true,
                    buttonImage: 'http://jqueryui.com/demos/datepicker/images/calendar.gif'
                });
            }
        });
//        var SigninView = Backbone.View.extend ({
//    el: '#signin-container',
//    events: {
//        "click #btnSave" : "save"
//    },
//    
//});
//        $(document).ready(function () {
//            
//            $("#llbCity option").hover(
//            function () {
//                this.style.backgroundColor = 'red';
//            },
//            function () {
//                this.style.backgroundColor = 'white';
//            });
//        });
//        $(document).ready(function () {
//            $("#llbState option").hover(
//            function () {
//                this.style.backgroundColor = 'red';
//            },
//            function () {
//                this.style.backgroundColor = 'white';
//            });
//        });
      
    </script>
</head>
<body>
   
    
    <form id="form1" runat="server">
    <div>
        <asp:ScriptManager ID="ScriptManager1" runat="server">
        </asp:ScriptManager>
        
          <asp:UpdatePanel ID="UpdatePanel1" runat="server">
            <ContentTemplate>
                <table>
                    <tr style="width: 100%">
                        <td style="width: 50%">
                            State
                        </td>
                        <td style="width: 50%">
                            City
                        </td>
                    </tr>
                    <tr style="width:auto">
                        <td >
                            <asp:ListBox CssClass="list-group-item" AutoPostBack="true" ID="llbState" OnSelectedIndexChanged="llboxSate_OnSelectedIndexChangedEvent"
                                runat="server"></asp:ListBox>
                        </td>
                        <td >
                            <asp:ListBox ID="llbCity" CssClass="list-group-item" runat="server" 
                                onselectedindexchanged="llbCity_SelectedIndexChanged" AutoPostBack="true" ></asp:ListBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Station Code
                        </td>
                        <td>
                            Date
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtStationCode" BackColor="Gray" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                        <td>
                        <asp:TextBox ID="txtDate" runat="server" AutoPostBack="true"
                                ontextchanged="txtDate_TextChanged"></asp:TextBox>
 
                        </td>
                    </tr>
                     <tr>
                        <td>
                            Predicted Speed (km/h)
                        </td>
                        <td>
                            Actual Speed (km/h)</td>
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtPredicted" BackColor="Gray" ReadOnly="true" runat="server"></asp:TextBox>
                        </td>
                        <td>
                             <asp:TextBox ID="txtActual"  AutoPostBack="true" runat="server" ontextchanged="txtActual_TextChanged"></asp:TextBox>
                        </td>
                    </tr>
                     <tr>
                        <td>
                            Variance
                        </td>
                        <td> </td>
                          
                    </tr>
                    <tr>
                        <td>
                            <asp:TextBox ID="txtVariance" runat="server"></asp:TextBox>
                        </td>
                        <td>
                            <asp:Button ID="btnSave" runat="server" Text="Save" onclick="btnSave_Click" />  
                            <asp:Button ID="btnCancel" runat="server" Text="Cancel" onclick="btnCancel_Click" /> 
                        </td>
                    </tr>
                </table>
            </ContentTemplate>
        </asp:UpdatePanel>
    </div>
  

    </form>
</body>
</html>

