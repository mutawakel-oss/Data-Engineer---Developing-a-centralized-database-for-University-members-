<%@ Page Title="KSAU-HS Information Center System - User Control Panel" Language="C#" MasterPageFile="~/MasterPage.master"
    AutoEventWireup="true" CodeFile="user_control_panel.aspx.cs" Inherits="_Default" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" runat="Server">
    <asp:Button ID="btnHomePage" runat="server" CssClass="mainMenuButton" Text="Home Page"
        PostBackUrl="~/user_home_page.aspx" />
    
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" runat="Server">
    <%-- The following panel will contain the University welcome Letter--%>
    <asp:Panel ID="pnlWelcomeLetter" runat="server" Width="830px" DefaultButton="btnSearch" >
        <div align="left">
            <br />
            <div align="center" class="formTitle">
              <asp:Label ID="lblPageTitle" runat="server" Text="User Control Panel Page" Font-Bold="true" Font-Size="Medium"></asp:Label>
             </div>
             <br />
             <br />
            <asp:Table ID="tblUserSearch" runat="server" Width="100%">
              
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblUserName" runat="server" Text="User Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtUserName" runat="server" MaxLength="100"></asp:TextBox>
                        <asp:RequiredFieldValidator ID="validUserName" runat="server" ControlToValidate="txtUserName"
                            ErrorMessage="*" ValidationGroup="userSearchGroup"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblFullName" runat="server" Text="Full Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtFull" runat="server" MaxLength="150"></asp:TextBox>
                         <asp:RequiredFieldValidator ID="validFullName" runat="server" ControlToValidate="txtFull"
                            ErrorMessage="*" ValidationGroup="userSearchGroup"></asp:RequiredFieldValidator>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:Button ID="btnSearch" runat="server" Text="Add" CausesValidation="true" ValidationGroup="userSearchGroup"
                            OnClick="mSearch" CssClass="button"/>
                    </asp:TableCell>
                </asp:TableRow>
              
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:DataGrid ID="gridUsers" runat="server" Width="500px" BackColor="White" ForeColor="Black"
                            HorizontalAlign="Center" GridLines="Vertical" CellPadding="4" BorderWidth="1px"
                            BorderStyle="None" BorderColor="#DEDFDE" AutoGenerateColumns="False" OnEditCommand="mDisplaySpecification"
                            OnDeleteCommand="mDeleteEmployee" >
                            <FooterStyle BackColor="#CCCC99" />
                            <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" />
                            <AlternatingItemStyle BackColor="White" />
                            <ItemStyle BackColor="#F7F7DE" Font-Size="small" />
                            <Columns>
                                
                                <asp:BoundColumn HeaderText="Full Name" DataField="userFullName"></asp:BoundColumn>
                                <asp:BoundColumn HeaderText="User Name" DataField="userName"></asp:BoundColumn>
                                <asp:ButtonColumn HeaderText="Previliges" CommandName="Delete" Text="Add" ItemStyle-ForeColor="Red">
                                </asp:ButtonColumn>
                            </Columns>
                            <HeaderStyle BackColor="#6B696B" Font-Size="small" ForeColor="White" />
                        </asp:DataGrid>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
              <%-- User Previliges Popup Extender Control--%>
    <asp:Button ID="btnSearchHidden" Style="display: none;" runat="server" Text="Fake" />
    <ajaxToolkit:ModalPopupExtender ID="mpeUserPreviliges" runat="server" TargetControlID="btnSearchHidden"
        PopupControlID="pnlSearch" BackgroundCssClass="modalBackground"
        DropShadow="false" CancelControlID="btnCloseMpe">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlSearch" runat="server" Direction="LeftToRight" CssClass="modalPopup"
        Style="display: none" Width="700" Height="500" ScrollBars="Vertical" >
        
        <asp:ImageButton ID="imgClosePopup" runat="server" ImageUrl="~/assets/close.png" ToolTip="Close Popup Window" />
        <center>
            <asp:Label ID="lblUniveristyLogo" runat="server" Text="KSAU-HS  Information Center"
                Font-Bold="true"></asp:Label>
        </center>
        <hr />
        <br />
        <div >
        <div align="center">
            <asp:Label ID="lblControl" runat="server" Text="User Previliges Popup Window" Font-Bold="true"></asp:Label>
            <br />
            </div>
           
            <asp:Table ID="tblResults" runat="server">
             <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblUserFullName" runat="server" Text="User Full Name"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Label ID="txtUserFullName" runat="server"></asp:Label>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblPrevilige" runat="server" Text="Previlige"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="2">
                        <asp:DropDownList ID="ddlPrevilige" runat="server" AutoPostBack="true" OnSelectedIndexChanged="mCheckPreviligeItems">
                            <asp:ListItem Text="Faculty Data Entry" Value="1"></asp:ListItem>
                            <asp:ListItem Text="Student Data Entry" Value="2"></asp:ListItem>
                            <asp:ListItem Text="Employee Data Entry" Value="3"></asp:ListItem>
                            <asp:ListItem Text="Reports Viewer" Value="4"></asp:ListItem>
                        </asp:DropDownList>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        <asp:Label ID="lblCampus" runat="server" Text="Campus"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:Panel ID="Panel1" runat="server" Height="100px" Width="300px" BorderStyle="Groove">
                            <asp:CheckBoxList ID="chkCampus" runat="server">
                                <asp:ListItem Text="Riyadh" Value="1"></asp:ListItem>
                                <asp:ListItem Text="Jeddah" Value="2"></asp:ListItem>
                                <asp:ListItem Text="Hasaa" Value="3"></asp:ListItem>
                            </asp:CheckBoxList>
                        </asp:Panel>
                    </asp:TableCell>
                </asp:TableRow>
                     <asp:TableRow ID="rowCollege" runat="server">
                    <asp:TableCell>
                        <asp:Label ID="lblGainedCollege" runat="server" Text="College"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="2">
                        <asp:Panel ID="pnlCollege" runat="server" Height="100px" Width="300px" ScrollBars="Vertical"   BorderStyle="Groove">
                            <asp:CheckBoxList ID="chkCollege" runat="server">
                            </asp:CheckBoxList>
                        </asp:Panel>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow ID="rowDepartment" runat="server">
                    <asp:TableCell>
                        <asp:Label ID="lblDepartmentCollege" runat="server" Text="Department"></asp:Label>
                    </asp:TableCell>
                    <asp:TableCell ColumnSpan="2">
                        <asp:Panel ID="pnlDepartment" runat="server" Height="100px" Width="300px" ScrollBars="Vertical"   BorderStyle="Groove">
                            <asp:CheckBoxList ID="chkDepartment" runat="server">
                                
                            </asp:CheckBoxList>
                        </asp:Panel>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="2">
                        <asp:CheckBox ID="chkAdministration" runat="server" Text="Control Panel Administrator" Visible="false" />
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="3">
                        <div align="center">
                            <asp:Button ID="btnAddPreviliges" runat="server" Text="Add Previliges" OnClick="mAddPreviliges" CssClass="button"/>
                        </div>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="3" >
                        <div align="center">
                            <asp:Label ID="lblCurrentPreviliges" runat="server" Text="Current User Previliges"
                                Font-Bold="true"></asp:Label>
                        </div>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell ColumnSpan="3"> 
                          <asp:DataGrid ID="grdCurrentPreviliges" runat="server" Width="700px" BackColor="White" ForeColor="Black"
                            HorizontalAlign="Center" GridLines="Vertical" CellPadding="4" BorderWidth="1px"
                            BorderStyle="None" BorderColor="#DEDFDE" AutoGenerateColumns="False"  >
                            <FooterStyle BackColor="#CCCC99" />
                            <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" />
                            <AlternatingItemStyle BackColor="White" />
                            <ItemStyle BackColor="#F7F7DE" Font-Size="small" />
                            <Columns>
                                
                                    
                                    <asp:BoundColumn HeaderText="Faculty Entry" DataField="faculty_entry"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Student Entry" DataField="student_entry"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Employee Entry" DataField="employee_entry"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Report View" DataField="report_review"></asp:BoundColumn>
                                    
                            </Columns>
                            <HeaderStyle BackColor="#6B696B" Font-Size="small" ForeColor="White" />
                        </asp:DataGrid>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
            <asp:Label ID="lblHiddenUserName" runat="server" Visible="false"></asp:Label>
            <div align="center">
        <asp:Button ID="btnCloseMpe" runat="server" Text="Close" CssClass="button" />
        </div>
    </asp:Panel>
    <%-- End Of User Previliges Popup Extender Control --%>
        </div>
    </asp:Panel>
</asp:Content>
