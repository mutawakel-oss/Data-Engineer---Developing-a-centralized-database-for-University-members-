<%@ Page Title="KSAU-HS Information Center System - User Home Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="user_home_page.aspx.cs" Inherits="_Default" %>
<%@ register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" Runat="Server">
    <asp:Button ID="btnStudentHomePage" runat=server CssClass="mainMenuButton"  Text="Student Entry" OnClick="mOpenStudentPage" Visible="false" />
    <asp:Button ID="btnFacultyHomePage" runat=server CssClass="mainMenuButton"  Text="Faculty Entry" OnClick="mOpenFacultyPage" Visible="false"/>
    <asp:Button ID="btnEmployeeHomePage" runat=server CssClass="mainMenuButton"  Text="Employee Entry" OnClick="mOpenEmployeePage" Visible="false"/>
    <asp:Button ID="btnReportReviewPage" runat=server CssClass="mainMenuButton"  Text="Report Review" OnClick="mOpenReportPage" />
    <asp:Button ID="btnUserControlPanel" runat=server CssClass="mainMenuButton"  Text="Control Panel" OnClick="mOpenControlPaenl" Visible="false"/>
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
<%-- The following panel will contain the University welcome Letter--%>
<asp:Panel ID="pnlWelcomeLetter" runat="server" Width="100%">
<asp:LinkButton ID="btnSendFeedback" runat="server" Text="Send Feedback" OnClick="mOpenFeedback"></asp:LinkButton>

    <div align="center">
    <br />
    <br />
    <br />
    <br />
    
        <table cellpadding="0" cellspacing="0" border="0" width="100%"  align="center" >
            <tr>
                <td valign="top" >
                    <table border="0" cellpadding="0" cellspacing="0"  width="100%"  >
                        <tr >
                        <td valign="top">
                        <div >
                        <font size="3px">
                            <%-- The following table will contain the login control --%>
                            Welcome in System Home Page
                            <br />
                            Please use the buttons at the top of this page to start using the system.
                            </font>
                            </div>
                        </td>
                        </tr>
                        
                    </table>
                 </td>
            </tr>
        </table>        
    </div>
   
    
      
</asp:Panel>
</asp:Content>


