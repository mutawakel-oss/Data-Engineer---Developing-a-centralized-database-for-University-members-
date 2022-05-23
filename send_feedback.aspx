<%@ Page Title="KSAU-HS Information Center System" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="send_feedback.aspx.cs" Inherits="_Default" %>
<%@ register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" Runat="Server">
    
        <asp:Button ID="btnHomePage" runat="server" CssClass="mainMenuButton" Text="Home Page"
        PostBackUrl="~/user_home_page.aspx" />        
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
<%-- The following panel will contain the University welcome Letter--%>
<asp:Panel ID="pnlWelcomeLetter" runat="server" Width="100%" >
<div align="center">
<br />
<br />
  <asp:Table ID="tblLogin" runat="server" GridLines="None"   >
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblSubject" runat="server" Text="Subject"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtSubject" runat="server" MaxLength="150" Width="250px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="subjectValidator" runat="server" ControlToValidate="txtSubject" ErrorMessage="*" ValidationGroup="feedbackGroup"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblDescription" runat="server" Text="Description"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtDescription" runat="server" TextMode="MultiLine" MaxLength="700" Width="250px" Height="300px"></asp:TextBox>
                <asp:RequiredFieldValidator ID="descriptionValidator" runat="server" ControlToValidate="txtDescription" ErrorMessage="*" ValidationGroup="feedbackGroup"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell ColumnSpan="2">
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="mSendFeedback" CausesValidation="true" ValidationGroup="feedbackGroup" />
                <asp:Button ID="btnCancel" runat="server" Text="Cancel" PostBackUrl="~/user_home_page.aspx" />
            </asp:TableCell>
        </asp:TableRow>
   </asp:Table>
</div>
    <div align="center">
    
        <table cellpadding="0" cellspacing="0" border="0" width="100%"  >
            <tr>
                <td valign="top" >
                    <table border="0" cellpadding="0" cellspacing="0"  width="100%"  >
                        <tr >
                        <td valign="top">
                            <%-- The following table will contain the login control --%>
                          

                        </td>
                        </tr>
                        
                    </table>
                 </td>
            </tr>
        </table>        
    </div>
   
    
      
</asp:Panel>
</asp:Content>


