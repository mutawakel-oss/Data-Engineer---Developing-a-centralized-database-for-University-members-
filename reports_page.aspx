<%@ Page Title="KSAU-HS Information Center System - Reports Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="reports_page.aspx.cs" Inherits="_Default" %>
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
    <div align="left">
    
    <br />
        <table cellpadding="0" cellspacing="0" border="0" width="100%"  >
            <tr>
                <td valign="top" >
                    <table border="0" cellpadding="0" cellspacing="0"  width="100%"  >
                        <tr >
                        <td valign="top">
                            <%-- The following table will contain the login control --%>
                            <asp:Table ID="tblSearchCreteria" runat="server" Width="100%">
                                <asp:TableRow>
                                    <asp:TableCell ColumnSpan="6">
                                        <div align="center" class="formTitle">
                                            <asp:Label ID="lblPageTitle" runat="server" Text="Reports Page" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                            
                                        </div>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:CheckBox ID="chkCamups" runat="server" OnCheckedChanged="mCampusCheckChanged" AutoPostBack="true"  />
                                        <asp:Label ID="lblCampus" runat="server" Text="Campus"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="ddlCampus" runat="server" Enabled="false"></asp:DropDownList>
                                    </asp:TableCell>
                                    <asp:TableCell >
                                    <asp:CheckBox ID="chkDepartment" runat="server" Enabled="false" OnCheckedChanged="mDepartmentCheckChanged" AutoPostBack="true"  />
                                        <asp:Label ID="lblDepartment" runat="server" Text="Department" Enabled="false"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="ddlDepartment" runat="server" Enabled="false"></asp:DropDownList>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:CheckBox ID="chkCollege" runat="server"  Enabled="false" OnCheckedChanged="mCollegeCheckChanged" AutoPostBack="true"/>
                                        <asp:Label ID="lblCollege" runat="server" Text="College" Enabled="false"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="ddlCollege" runat="server" Enabled="false">
                                            
                                        </asp:DropDownList>
                                    </asp:TableCell>
                                    
                                </asp:TableRow>
                                <asp:TableRow>
                                    
                                    <asp:TableCell>
                                        
                                        <asp:Label ID="lblCategory" runat="server" Text="Category"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:DropDownList ID="ddlCategory" runat="server">
                                            <asp:ListItem Text="Student" Value="1"></asp:ListItem>
                                            <asp:ListItem Text="Faculty" Value="2"></asp:ListItem>
                                            <asp:ListItem Text="Employee" Value="3"></asp:ListItem>
                                        </asp:DropDownList>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:Label ID="lblFromDate" runat="server" Text="From Date"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtFromDate"    runat="server"   ></asp:TextBox>
			                            <asp:Image ID="imgFromDate" runat="server"  ImageUrl="~/assets/date.gif"/>
			                            <ajaxToolkit:CalendarExtender Format="MM/dd/yyyy" id="fromDateExtender"  runat="server" PopupButtonID="imgFromDate" TargetControlID="txtFromDate" BehaviorID="fromDateExtender1" Enabled="True" ></ajaxToolkit:CalendarExtender>  
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:Label ID="lblToDate" runat="server" Text="To Date"></asp:Label>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:TextBox ID="txtToDate"    runat="server" ></asp:TextBox>
			                            <asp:Image ID="imgToDate" runat="server"  ImageUrl="~/assets/date.gif"/>
			                            <ajaxToolkit:CalendarExtender Format="MM/dd/yyyy" id="toDateExtender"  runat="server" PopupButtonID="imgToDate" TargetControlID="txtToDate" BehaviorID="toDateExtender1" Enabled="True" ></ajaxToolkit:CalendarExtender>  
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Button ID="btnDisplayReport" runat="server" Text="Display Rerpot" OnClick="mDisplayReport" CssClass="button"/>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            <asp:Table ID="tblReportGrid" runat="server" Width="100%">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <div align="center">
                                        <hr />
                                            <asp:Label ID="lblReportTitle" runat="server" Font-Bold="true" Font-Size="Medium"></asp:Label>
                                        </div>
                                    </asp:TableCell>
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:Label ID="lblRecordsTitlePart1" runat="server" Text="(" ></asp:Label>
                                        <asp:Label ID="lblRecordNo" runat="server" ></asp:Label>
                                        <asp:Label ID="lblRecordsTitlePart2" runat="server" Text=")Records Founded" Font-Bold="true"></asp:Label>
                                        
                                    </asp:TableCell>
                                    
                                </asp:TableRow>
                                <asp:TableRow>
                                    <asp:TableCell>
                                    <div align="center">
                                        <asp:DataGrid ID="ReportGrid" runat="server" Width="100%" BackColor="White" ForeColor="Black"
                                            HorizontalAlign="Center" GridLines="Vertical" CellPadding="4" BorderWidth="1px"
                                            BorderStyle="None" BorderColor="#DEDFDE" AutoGenerateColumns="False" AllowPaging="True" PageSize="5" 
                                            OnPageIndexChanged="reportGrid_pageIndexChanged" OnEditCommand="mDisplayDetails"  >
                                            <FooterStyle BackColor="#CCCC99" />
                                            <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                                            <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" />
                                            <AlternatingItemStyle BackColor="White" />
                                            <ItemStyle BackColor="#F7F7DE" Font-Size="small" />
                                            <Columns>
                                                 <asp:BoundColumn HeaderText="Nationl ID" DataField="nationalID"></asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Full Name" DataField="userFullName"></asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Role" DataField="role"></asp:BoundColumn>
                                                <asp:BoundColumn HeaderText="Entered By" DataField="by"></asp:BoundColumn>
                                                
                                            </Columns>
                                            <HeaderStyle BackColor="#6B696B" Font-Size="small" ForeColor="White" />
                                        </asp:DataGrid>
                                            </div>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                            <asp:Table ID="tblGeneration" runat="server">
                                <asp:TableRow>
                                    <asp:TableCell>
                                        <asp:CheckBox ID="chkOverallStatistics" runat="server" Text="Overall Statistics" Visible=false />
                                        <asp:Button ID="btnGenerateXml" runat="server" Text="Generate XML" OnClick="mGenerateXML" CssClass="button"/>
                                    </asp:TableCell>
                                    <asp:TableCell>
                                        <asp:Button ID="btnGeneratePdf" runat="server" Text="Generate PDF" OnClick="mDisplayPdfFile" CssClass="button"/>
                                    </asp:TableCell>
                                </asp:TableRow>
                            </asp:Table>
                  

                        </td>
                        </tr>
                        
                    </table>
                 </td>
            </tr>
        </table>        
    </div>
   
    
      
</asp:Panel>
</asp:Content>


