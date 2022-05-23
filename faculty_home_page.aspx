<%@ Page Title="KSAU-HS Information Center System - Faculty Staff Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="faculty_home_page.aspx.cs" Inherits="_Default" %>
<%@ register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" Runat="Server">
<asp:Button ID="btnHomePage" runat="server" CssClass="mainMenuButton" Text="Home Page"
        PostBackUrl="~/user_home_page.aspx" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
<asp:Panel ID="pnlFacultyPage" runat="server" Width="100%" DefaultButton="btnCanelChanges">
<div align="left">
<div align="center" class="formTitle">
<asp:Label ID="lblPageTitle" runat="server" Text="Add/Edit Faculty Staff Data" Font-Size="Large"></asp:Label>
    </div>
    <asp:Table ID="tblForms" runat="server" >
        <asp:TableRow>
            <asp:TableCell CssClass='leftColumn'>
                 <asp:Table ID="tblEmployeeDataLeft" runat="server" dir="ltr">
        <asp:TableRow>
            <asp:TableCell >
                <asp:Button ID="btnClearFields" runat="server"  Text="Clear Fields" OnClick="mBtnClearClicked" CssClass="button"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnSearch" runat="server" Text="Search" OnClick="mSearch" CssClass="button" />
            </asp:TableCell>
        </asp:TableRow>
            <asp:TableRow>
            <asp:TableCell>
                    <asp:Label ID="lblCampus" runat="server" Text="Campus"></asp:Label>
            </asp:TableCell>
            <asp:TableCell ColumnSpan="2">
                <asp:DropDownList ID="ddlCampus" runat="server">
                
                </asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblFirstName" runat="server" Text="First Name"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtFirstName" runat="server" MaxLength="30"  CssClass="ControlWidth"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="validFirstName" runat="server" ControlToValidate="txtFirstName" ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtMiddleName" runat="server"  MaxLength="60" CssClass="ControlWidth"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="validMiddleName" runat="server" ControlToValidate="txtMiddleName" ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblLastName" runat="server" Text="Last Name"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtLastName" runat="server" MaxLength="30" CssClass="ControlWidth"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="validLastName" runat="server" ControlToValidate="txtLastName" ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblNationalId" runat="server" Text="National ID"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtNationalId" runat="server" MaxLength="10" CssClass="ControlWidth"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="validNationalID" runat="server" ControlToValidate="txtNationalId" ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="expresNationalID"  Font-Bold="true" ControlToValidate="txtNationalId" ErrorMessage="Enter valid numbers" runat="server" ValidationExpression="[0-9]{10,}" ValidationGroup="FacultyDataGroup"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblBirthDate" runat="server" Text="Birth Date"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtBirthDate"    runat="server"   CssClass="ControlWidth"></asp:TextBox>
			 <asp:Image ID="imgBirthDate" runat="server"  ImageUrl="~/assets/date.gif"/>
			 <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" id="BirthDateExtender"  runat="server" PopupButtonID="imgBirthDate" TargetControlID="txtBirthDate" BehaviorID="BirthDateExtender1" Enabled="True" ></ajaxToolkit:CalendarExtender>  
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="validBirthDate" runat="server" ControlToValidate="txtBirthDate" ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblGender" runat="server" Text="Gender" ></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlGender" runat="server" CssClass="ControlWidth"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblNationality" runat="server" Text="Nationality"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlNationality" runat="server" CssClass="ControlWidth"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>

        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblMaritalStatus" runat="server" Text="Marital Status"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlMaritalStatus" runat="server" CssClass="ControlWidth"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblReligion" runat="server" Text="Religion"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlReligion" runat="server" CssClass="ControlWidth"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblEmail" runat="server" Text="Email"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtEmail" runat="server" MaxLength="100" CssClass="ControlWidth"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="validEmail" runat="server" ControlToValidate="txtEmail" ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="EmailExpressionValidator"  Font-Bold="true" ControlToValidate="txtEmail" ErrorMessage="Entered Email is Invalid" runat="server" ValidationExpression="^([0-9a-zA-Z]([-\.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$" ValidationGroup="FacultyDataGroup"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblInstitutionId" runat="server" Text="Institution ID"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtInstitutionID" runat="server" Text="019" CssClass="ControlWidth"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="validInstitutionID" runat="server" ControlToValidate="txtInstitutionID" ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblLocationCode" runat="server" Text="Location"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlLocation" runat="server" CssClass="ControlWidth"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblBadgeNo" runat="server" Text="Badge No"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtBadgeNo" runat="server" MaxLength="7" CssClass="ControlWidth"></asp:TextBox>
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="validBadgeNo" runat="server" ControlToValidate="txtBadgeNo" ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="expressBadgeNo"  Font-Bold="true" ControlToValidate="txtBadgeNo" ErrorMessage="Enter valid numbers" runat="server" ValidationExpression="^\d+$" ValidationGroup="FacultyDataGroup"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblPosition" runat="server" Text="Position"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlPosition" runat="server" CssClass="ControlWidth"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblHiringDate" runat="server" Text="Position Date"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtHiringDate"    runat="server"  CssClass="ControlWidth"></asp:TextBox>
			    <asp:Image ID="hiringDateImage" runat="server"  ImageUrl="~/assets/date.gif"/>
			    <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" id="hiringDateExtender"  runat="server" PopupButtonID="hiringDateImage" TargetControlID="txtHiringDate" BehaviorID="HiringDateExtender1" Enabled="True" ></ajaxToolkit:CalendarExtender>  
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="validPositionDate" runat="server" ControlToValidate="txtHiringDate" ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblDepartment" runat="server" Text="Department"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlDepartment" runat="server" CssClass="ControlWidth"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblStartHiringDate" runat="server" Text="Start Hiring Date"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtStartHiringDate"    runat="server"  CssClass="ControlWidth"></asp:TextBox>
			    <asp:Image ID="startHiringImage" runat="server"  ImageUrl="~/assets/date.gif"/>
			    <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" id="StartHiringExtender"  runat="server" PopupButtonID="startHiringImage" TargetControlID="txtStartHiringDate" BehaviorID="StartHiringDateExtender" Enabled="True" ></ajaxToolkit:CalendarExtender>  
            </asp:TableCell>
            <asp:TableCell>
                <asp:RequiredFieldValidator ID="validHiringDate" runat="server" ControlToValidate="txtStartHiringDate" ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblDegree" runat="server" Text="Degree"></asp:Label>
            </asp:TableCell>
            <asp:TableCell> 
                <asp:DropDownList ID="ddlDegree" runat="server" CssClass="ControlWidth"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblBasicSalary" runat="server" Text="Basic Salary"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtBasicSalary" runat="server" MaxLength="10" CssClass="ControlWidth"></asp:TextBox>
            </asp:TableCell>
             <asp:TableCell>
                <asp:RequiredFieldValidator ID="validBasicSalary" runat="server" ControlToValidate="txtBasicSalary" ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="expressBasicSalary"  Font-Bold="true" ControlToValidate="txtBasicSalary" ErrorMessage="Enter valid numbers" runat="server" ValidationExpression="^\d+$" ValidationGroup="FacultyDataGroup"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblTotalSalary" runat="server" Text="Total Salary"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:TextBox ID="txtTotalSalary" runat="server" MaxLength="10" CssClass="ControlWidth"></asp:TextBox>
            </asp:TableCell>
              <asp:TableCell>
                <asp:RequiredFieldValidator ID="validTotalSalary" runat="server" ControlToValidate="txtTotalSalary" ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                <asp:RegularExpressionValidator ID="expressTotalSalary"  Font-Bold="true" ControlToValidate="txtTotalSalary" ErrorMessage="Enter valid numbers" runat="server" ValidationExpression="^\d+$" ValidationGroup="FacultyDataGroup"></asp:RegularExpressionValidator>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Label ID="lblAccommodation" runat="server" Text="Accommodation"></asp:Label>
            </asp:TableCell>
            <asp:TableCell>
                <asp:DropDownList ID="ddlAccommodation" runat="server" CssClass="ControlWidth"></asp:DropDownList>
            </asp:TableCell>
        </asp:TableRow>
        <asp:TableRow>
            <asp:TableCell>
                <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="mSaveData" CausesValidation="true"  ValidationGroup="FacultyDataGroup" CssClass="button"/>
            </asp:TableCell>
            <asp:TableCell>
                <asp:Button ID="btnCanelChanges" runat="server" Text="Cancel" OnClick="mCancleChanges" CausesValidation="false" CssClass="button"/>
            </asp:TableCell>
        </asp:TableRow>
       
    </asp:Table>
            </asp:TableCell>
            
            <asp:TableCell VerticalAlign="Top">
            <br />
            <br />
                <asp:Table ID="tblEmployeeDataRight" runat="server" >
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblCollegeName" runat="server" Text="College"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlCollege" runat="server"  CssClass="ControlWidth280"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblHiringCateogry" runat="server" Text="Hiring Category"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlHiringCategory" runat="server" CssClass="ControlWidth280"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblHiringStatus" runat="server" Text="Hiring Status"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlHiringStatus" runat="server" CssClass="ControlWidth280"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                         <asp:TableCell>
                           <asp:Label ID="lblGraduationDate" runat="server" Text="Graduation Date"></asp:Label>
                         </asp:TableCell>
                         <asp:TableCell>
                             <asp:TextBox ID="txtGraduationDate"    runat="server" CssClass="ControlWidth280" ></asp:TextBox>
			                <asp:Image ID="imageGruadionDate" runat="server"  ImageUrl="~/assets/date.gif"/>
			                <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" id="GraduationDateExtender"  runat="server" PopupButtonID="imageGruadionDate" TargetControlID="txtGraduationDate" BehaviorID="GraduationDateExtender" Enabled="True" ></ajaxToolkit:CalendarExtender>  
                        </asp:TableCell>
                         <asp:TableCell>
                             <asp:RequiredFieldValidator ID="RequiredFieldValidator1" runat="server" ControlToValidate="txtGraduationDate" ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblGraduationOrg" runat="server" Text="Graduation Organization"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtGraduationOrg" runat="server" MaxLength="50" CssClass="ControlWidth280"></asp:TextBox>
                        </asp:TableCell>
                        <asp:TableCell>
                             <asp:RequiredFieldValidator ID="graduationOrgValidator" runat="server" ControlToValidate="txtGraduationOrg" ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblGraduationCountry" runat="server" Text="Graduation Country"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlGraduationCountry" runat="server" CssClass="ControlWidth280"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblMajorSpecialization" runat="server" Text="Major Field"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlMajorSpecialization" runat="server" CssClass="ControlWidth280"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblMajorSpecializationName" runat="server" Text="Field Name"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtMajorSpecializationName" runat="server" MaxLength="80" CssClass="ControlWidth280"></asp:TextBox>
                        </asp:TableCell>
                          <asp:TableCell>
                             <asp:RequiredFieldValidator ID="MajorSpecializationValidator" runat="server" ControlToValidate="txtMajorSpecializationName" ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblAdvancedSpecialization" runat="server" Text="Detailed Field"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:TextBox ID="txtAdvancedField" runat="server" MaxLength="80" CssClass="ControlWidth280" ></asp:TextBox>
                        </asp:TableCell>
                         <asp:TableCell>
                             <asp:RequiredFieldValidator ID="advancedFieldValidator" runat="server" ControlToValidate="txtAdvancedField" ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblCurrentOrganization" runat="server" Text="Current Organization"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlCurrentOrganization" runat="server"  CssClass="ControlWidth280"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                    <asp:TableRow>
                        <asp:TableCell>
                            <asp:Label ID="lblPositionDescription" runat="server" Text="Position Description"></asp:Label>
                        </asp:TableCell>
                        <asp:TableCell>
                            <asp:DropDownList ID="ddlPositionDescription" runat="server" CssClass="ControlWidth280"></asp:DropDownList>
                        </asp:TableCell>
                    </asp:TableRow>
                </asp:Table>
            </asp:TableCell>
        </asp:TableRow>
    </asp:Table>
   
<asp:Label ID="lblEntryStatus" runat="server" Visible="false" Text="new"></asp:Label>
      <%-- search Modal Popup Extender Control--%>
    <asp:Button ID="btnSearchHidden" Style="display: none;" runat="server" Text="Fake" />
    <ajaxToolkit:ModalPopupExtender ID="mpeSearch" runat="server" TargetControlID="btnSearchHidden"
        PopupControlID="pnlSearch" BackgroundCssClass="modalBackground"
        DropShadow="false" CancelControlID="btnCloseSearch">
    </ajaxToolkit:ModalPopupExtender>
    <asp:Panel ID="pnlSearch" runat="server" Direction="LeftToRight" CssClass="modalPopup"
        Style="display: none" Width="500" Height="500" DefaultButton="btnSearchNow">
        
        <asp:ImageButton ID="imgClosePopup" runat="server" ImageUrl="~/assets/close.png" ToolTip="Close Popup Window" />
        <center>
            <asp:Label ID="lblUniveristyLogo" runat="server" Text="KSAU-HS  Information Center"
                Font-Bold="true"></asp:Label>
        </center>
        
        <hr />
        <br />
        <div align=center>
            <asp:Label ID="lblControl" runat="server" Text="User Search Popup Window"></asp:Label>
            <asp:Table ID="tblSearch" runat="server">
                <asp:TableRow>
                    <asp:TableCell>
                        Badge No
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSearchBadgeNo" runat="server" MaxLength="10"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        National ID
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSearchNationalID" runat="server" MaxLength="10"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        First Name
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSearchFirstName" runat="server"></asp:TextBox>
                    </asp:TableCell>
                    <asp:TableCell>
                        MiddleName
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSearchMiddleName" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
                <asp:TableRow>
                    <asp:TableCell>
                        LastName
                    </asp:TableCell>
                    <asp:TableCell>
                        <asp:TextBox ID="txtSearchLastName" runat="server"></asp:TextBox>
                    </asp:TableCell>
                </asp:TableRow>
            </asp:Table>
        </div>
        <br />
        <center>
            <asp:Button ID="btnSearchNow" runat="server" Text="Search" OnClick="mSearchFaculty" CssClass="button" />
            &nbsp;&nbsp;
            <asp:Button ID="btnCloseSearch" runat="server" Text="Close" CssClass="button"/>
        </center>
        <hr />
        <asp:Table ID="tblResults" runat="server">
            <asp:TableRow>
                <asp:TableCell>
                    <asp:DataGrid ID="resultsGrid" runat="server" Width="500px" BackColor="White" ForeColor="Black"
                        HorizontalAlign="Center" GridLines="Vertical" CellPadding="4" BorderWidth="1px"
                        BorderStyle="None" BorderColor="#DEDFDE" AutoGenerateColumns="False" OnEditCommand="mDisplaySpecification"
                        OnDeleteCommand="mDeleteEmployee">
                        <FooterStyle BackColor="#CCCC99" />
                        <SelectedItemStyle BackColor="#CE5D5A" Font-Bold="True" ForeColor="White" />
                        <PagerStyle BackColor="#F7F7DE" ForeColor="Black" HorizontalAlign="Right" Mode="NumericPages" />
                        <AlternatingItemStyle BackColor="White" />
                        <ItemStyle BackColor="#F7F7DE" Font-Size="small" />
                        <Columns>
                            <asp:EditCommandColumn CancelText="Details" EditText="Details" UpdateText="Update"
                                ItemStyle-ForeColor="blue"></asp:EditCommandColumn>
                            <asp:BoundColumn HeaderText="National ID" DataField="employeeNationalID"></asp:BoundColumn>
                            <asp:BoundColumn HeaderText="Full Name" DataField="employeeName"></asp:BoundColumn>
                            <asp:ButtonColumn HeaderText="Delete" CommandName="Delete" Text="Delete" ItemStyle-ForeColor="Red">
                            </asp:ButtonColumn>
                        </Columns>
                        <HeaderStyle BackColor="#6B696B" Font-Size="small" ForeColor="White" />
                    </asp:DataGrid>
                </asp:TableCell>
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>
    <%-- End Of search Popup Extender Control --%>
   
        
    </div>
    </asp:Panel>
</asp:Content>


