<%@ Page Title="KSAU-HS Information Center System" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="index.aspx.cs" Inherits="_Default" %>
<%@ register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" Runat="Server">
    
                
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
<%-- The following panel will contain the University welcome Letter--%>
<asp:Panel ID="pnlWelcomeLetter" runat="server" Width="100%" DefaultButton="btnLogin">
<div align="center">
<br />
<br />
  <asp:Table ID="tblLogin" runat="server" GridLines="None" CssClass="loginTable" >
                                <asp:TableRow CssClass='loginTableHeader'>
                                      <asp:TableCell>
                                      </asp:TableCell>
                                      <asp:TableCell>
                                     </asp:TableCell>
                                </asp:TableRow>
                                  <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label ID="lblDomainName" runat=server Text="Domain"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell HorizontalAlign="Justify">
					                    <asp:DropDownList ID="ddlDomain" runat=server Width="125px"  >
					                    <asp:ListItem Text="Med" Value="1" Selected=true></asp:ListItem>
				                        <asp:ListItem Text="Ksuhs" Value="2"></asp:ListItem>
					                    </asp:DropDownList>
                                    </asp:TableCell>
                                  </asp:TableRow>
                                  <asp:TableRow>
                                      <asp:TableCell>
                                         <asp:Label ID="lblUserNAME" runat=server Text="User Name" ></asp:Label>
                                      </asp:TableCell>
                                      <asp:TableCell>
                                          <asp:TextBox ID="txtUserName" runat="server"  Width="120px" MaxLength="40"></asp:TextBox>
                                          <asp:RequiredFieldValidator ID="userNameVlidator" runat="server" ControlToValidate="txtUserName" ErrorMessage="*" ValidationGroup="loginGroup"></asp:RequiredFieldValidator>
                                     </asp:TableCell>
                                    </asp:TableRow>
                                  <asp:TableRow>
                                       <asp:TableCell>
                                            <asp:Label ID="lblPassword" runat="server" Text="Password" ></asp:Label>
                                        </asp:TableCell>
                                        <asp:TableCell>
                                             <asp:TextBox ID="txtPassword" runat="server" Width="120px" MaxLength="70" TextMode="Password"></asp:TextBox>
                                             <asp:RequiredFieldValidator ID="passwordValidator" runat="server" ControlToValidate="txtPassword" ErrorMessage="*" ValidationGroup="loginGroup"></asp:RequiredFieldValidator>
                                         </asp:TableCell>
                                 </asp:TableRow>
                                  <asp:TableRow  HorizontalAlign="Center">
                                   <asp:TableCell Width="100px">
                                        <asp:LinkButton ID="lnkForgotePassword" runat="server" Text=" " PostBackUrl="~/getpassword.aspx"></asp:LinkButton>
                                     </asp:TableCell>
                                      <asp:TableCell >
                                         <asp:Button ID="btnLogin" runat="server" CausesValidation="true" ValidationGroup="loginGroup"  CssClass='loginButton' OnClick="mLogin"  />
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


