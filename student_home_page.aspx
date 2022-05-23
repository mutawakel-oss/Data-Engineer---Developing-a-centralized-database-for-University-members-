<%@ Page Title="KSAU-HS Information Center System - Student Page" Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="student_home_page.aspx.cs" Inherits="_Default" %>
<%@ register Assembly="AjaxControlToolkit"
    Namespace="AjaxControlToolkit"
    TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="mainMenuContent" Runat="Server">
<asp:Button ID="btnHomePage" runat="server" CssClass="mainMenuButton" Text="Home Page"
        PostBackUrl="~/user_home_page.aspx" />
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="content" Runat="Server">
    <asp:Panel ID="pnlStudentPage" runat="server" Width="100%" DefaultButton="btnCanelChanges">
        <div align="left">
            <div align="center" class="formTitle">
                <asp:Label ID="lblPageTitle" runat="server" Text="Add/Edit Student Data" Font-Size="Large"></asp:Label>
            </div>
            <asp:Table ID="tblForms" runat="server">
                <asp:TableRow>
                    <asp:TableCell CssClass='leftColumn'>
                        <asp:Table ID="tblEmployeeDataLeft" runat="server" dir="ltr">
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Button ID="btnClearFields" runat="server" Text="Clear Fields" OnClick="mBtnClearClicked"
                                        CssClass="button" />
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
                                    <asp:TextBox ID="txtFirstName" runat="server" MaxLength="30" CssClass="ControlWidth"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:RequiredFieldValidator ID="validFirstName" runat="server" ControlToValidate="txtFirstName"
                                        ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblMiddleName" runat="server" Text="Middle Name"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtMiddleName" runat="server" MaxLength="60" CssClass="ControlWidth"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:RequiredFieldValidator ID="validMiddleName" runat="server" ControlToValidate="txtMiddleName"
                                        ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="validLastName" runat="server" ControlToValidate="txtLastName"
                                        ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
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
                                    <asp:RequiredFieldValidator ID="validNationalID" runat="server" ControlToValidate="txtNationalId"
                                        ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                                    <asp:RegularExpressionValidator ID="expresNationalID" Font-Bold="true" ControlToValidate="txtNationalId"
                                        ErrorMessage="Enter valid numbers" runat="server" ValidationExpression="[0-9]{10,}"
                                        ValidationGroup="FacultyDataGroup"></asp:RegularExpressionValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblBirthDate" runat="server" Text="Birth Date"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtBirthDate" runat="server" CssClass="ControlWidth"></asp:TextBox>
                                    <asp:Image ID="imgBirthDate" runat="server" ImageUrl="~/assets/date.gif" />
                                    <ajaxToolkit:CalendarExtender Format="dd/MM/yyyy" ID="BirthDateExtender" runat="server"
                                        PopupButtonID="imgBirthDate" TargetControlID="txtBirthDate" BehaviorID="BirthDateExtender1"
                                        Enabled="True">
                                    </ajaxToolkit:CalendarExtender>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:RequiredFieldValidator ID="validBirthDate" runat="server" ControlToValidate="txtBirthDate"
                                        ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblGender" runat="server" Text="Gender"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlGender" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblNationality" runat="server" Text="Nationality"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlNationality" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblSecondaryType" runat="server" Text="Secondary Certificate"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlSecondaryType" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblSecondaryGraduation" runat="server" Text="Graduation Year"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlGraduationYear" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
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
                                    <asp:RequiredFieldValidator ID="validInstitutionID" runat="server" ControlToValidate="txtInstitutionID"
                                        ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblLocationCode" runat="server" Text="Graduation Location"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlLocation" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblSecondaryPercentage" runat="server" Text="Secondary Percentage"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtSecondaryPercentage" runat="server" MaxLength="6" CssClass="ControlWidth"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:RequiredFieldValidator ID="ValidSecondaryPercentage" runat="server" ControlToValidate="txtSecondaryPercentage"
                                        ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rngSecondaryPercentage" runat="server" ControlToValidate="txtSecondaryPercentage"
                                        MaximumValue="999998" MinimumValue="1" Type="Double" ErrorMessage="Enter valid percentage."
                                        ValidationGroup="FacultyDataGroup"></asp:RangeValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblQudratGrade" runat="server" Text="Qudrat Mark"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtQudratMark" runat="server" MaxLength="3" CssClass="ControlWidth"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:RequiredFieldValidator ID="validQudratMark" runat="server" ControlToValidate="txtQudratMark"
                                        ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rngQudratMark" runat="server" ControlToValidate="txtQudratMark"
                                        MaximumValue="998" MinimumValue="0" Type="Integer" ErrorMessage="Enter valid Mark."
                                        ValidationGroup="FacultyDataGroup"></asp:RangeValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblTahseleMarks" runat="server" Text="Tahsili Mark"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtTahsleiMark" runat="server" MaxLength="3" CssClass="ControlWidth"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:RequiredFieldValidator ID="validTahseliMark" runat="server" ControlToValidate="txtTahsleiMark"
                                        ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rngThasiliMark" runat="server" ControlToValidate="txtTahsleiMark"
                                        MaximumValue="998" MinimumValue="0" Type="Integer" ErrorMessage="Enter valid Mark."
                                        ValidationGroup="FacultyDataGroup"></asp:RangeValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblStudentNo" runat="server" Text="Student ID"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtStudentID" runat="server" MaxLength="10" CssClass="ControlWidth"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:RequiredFieldValidator ID="validStudentID" runat="server" ControlToValidate="txtStudentID"
                                        ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblUniveristyLocation" runat="server" Text="Organization Location"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlOrganizationLocation" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblRegistrationYear" runat="server" Text="Registration Year"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlRegistraitonYear" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblSemester" runat="server" Text="Registration Semester"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlRegistrationSemester" runat="server">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblRegisteredCollegeName" runat="server" Text="Registered College"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlCollege" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblCurrentCollege" runat="server" Text="Current College"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlCurrentCollege" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblPreCollege" runat="server" Text="Previous College"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlPrevCollege" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblMajorSpecialization" runat="server" Text="Major Field"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlMajorSpecialization" runat="server" CssClass="ControlWidth"
                                        OnSelectedIndexChanged="mFillMajorFieldName" AutoPostBack="true">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblMajorFieldName" runat="server" Text="Field Name"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtMajorFieldName" runat="server" MaxLength="80" CssClass="ControlWidth"></asp:TextBox>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:RequiredFieldValidator ID="validMajorFieldName" runat="server" ControlToValidate="txtMajorFieldName"
                                        ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblMinorFieldName" runat="server" Text="Minor Field"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlMinorFieldName" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="mSaveData" CausesValidation="true"
                                        ValidationGroup="FacultyDataGroup" CssClass="button" />
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:Button ID="btnCanelChanges" runat="server" Text="Cancel" OnClick="mCancleChanges"
                                        CausesValidation="false" CssClass="button" />
                                </asp:TableCell>
                            </asp:TableRow>
                        </asp:Table>
                    </asp:TableCell>
                    <asp:TableCell VerticalAlign="Top">
                        <br />
                        <br />
                        <asp:Table ID="tblEmployeeDataRight" runat="server">
                            <asp:TableRow>
                                <asp:TableCell>
                            
                         
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblPrevField" runat="server" Text="Previous Field"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlPreviousField" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblDegree" runat="server" Text="Targeted Degree"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlDegree" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblDegreePeriod" runat="server" Text="Degree Period"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlDegreeDuration" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblPeriodUnit" runat="server" Text="Period Unit"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlPeriodUnit" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblReequiredUnits" runat="server" Text="Required Units"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlRequiredUnits" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblRegisteredUnits" runat="server" Text="Registered Units"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlRegisteredUnits" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblPassedUnits" runat="server" Text="Passed Units"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlPassedUnits" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblTotalPassedUnits" runat="server" Text="Total Passed Units"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlTotalPassedUnits" runat="server" CssClass="ControlWidth"
                                        OnSelectedIndexChanged="mCalculateRemainedUnits" AutoPostBack="true">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblRemainedUnits" runat="server" Text="Remained Units"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlRemainedUnits" runat="server" CssClass="ControlWidth" Enabled="false">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblRegisteredSemesters" runat="server" Text="Registered Semesters"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlRegisteredSemesters" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblSummerSemester" runat="server" Text="Summer Semester"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlSummerSemester" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblWithdrawnAttempts" runat="server" Text="Withdrawn Attempts"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlWithdrawnAttempts" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblAcademicYear" runat="server" Text="Academic Year"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlAcademicYear" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblGpaCreteria" runat="server" Text="GPA Creteria"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlGpaCreteria" runat="server" CssClass="ControlWidth" OnSelectedIndexChanged="mFillGpaDropDownList"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblGpa" runat="server" Text="GPA"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtGpa" runat="server" CssClass="ControlWidth" MaxLength="6"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validGpa" runat="server" ControlToValidate="txtGpa"
                                        ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rngGpa" runat="server" ControlToValidate="txtGpa" MaximumValue="5"
                                        MinimumValue="0" Type="Double" ErrorMessage="Enter valid GPA." ValidationGroup="FacultyDataGroup"></asp:RangeValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblWarnings" runat="server" Text="Warning No"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:TextBox ID="txtWarnings" runat="server" CssClass="ControlWidth" MaxLength="3"></asp:TextBox>
                                    <asp:RequiredFieldValidator ID="validWarnings" runat="server" ControlToValidate="txtWarnings"
                                        ErrorMessage="*" ValidationGroup="FacultyDataGroup"></asp:RequiredFieldValidator>
                                    <asp:RangeValidator ID="rngWarnings" runat="server" ControlToValidate="txtWarnings"
                                        MaximumValue="999" MinimumValue="0" Type="Double" ErrorMessage="Enter valid number."
                                        ValidationGroup="FacultyDataGroup"></asp:RangeValidator>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblGeneralStatus" runat="server" Text="General Status"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlGeneralStatus" runat="server" CssClass="ControlWidth" OnSelectedIndexChanged="mUpdateStudyStatusDDL"
                                        AutoPostBack="true">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblRegStatus" runat="server" Text="Registration Status"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlRegistraitonStatus" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblStudyStatus" runat="server" Text="Study Status"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlStudyStatus" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblScholarShip" runat="server" Text="Scholar Ship"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlScholarShip" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblTransferStatus" runat="server" Text="Transfer Status"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlTransferStatus" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblGrantedDegree" runat="server" Text="Granted Degree"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlGrantedDegree" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblDegreeWeight" runat="server" Text="Degree Weight"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlDegreeWeight" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
                                </asp:TableCell>
                            </asp:TableRow>
                            <asp:TableRow>
                                <asp:TableCell>
                                    <asp:Label ID="lblAccommodation" runat="server" Text="Accommodation"></asp:Label>
                                </asp:TableCell>
                                <asp:TableCell>
                                    <asp:DropDownList ID="ddlAccommodation" runat="server" CssClass="ControlWidth">
                                    </asp:DropDownList>
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
                PopupControlID="pnlSearch" BackgroundCssClass="modalBackground" DropShadow="false"
                CancelControlID="btnCloseSearch">
            </ajaxToolkit:ModalPopupExtender>
            <asp:Panel ID="pnlSearch" runat="server" Direction="LeftToRight" CssClass="modalPopup"
                Style="display: none" Width="500" Height="500" DefaultButton="btnSearchNow">
                <asp:ImageButton ID="imgClosePopup" runat="server" ImageUrl="~/assets/close.png"
                    ToolTip="Close Popup Window" />
                <center>
                    <asp:Label ID="lblUniveristyLogo" runat="server" Text="KSAU-HS  Information Center"
                        Font-Bold="true"></asp:Label>
                </center>
                <hr />
                <br />
                <div align="center">
                    <asp:Label ID="lblControl" runat="server" Text="User Search Popup Window"></asp:Label>
                    <asp:Table ID="tblSearch" runat="server">
                        <asp:TableRow>
                            <asp:TableCell>
                        Student ID
                            </asp:TableCell>
                            <asp:TableCell>
                                <asp:TextBox ID="txtSearchStudentID" runat="server" MaxLength="10"></asp:TextBox>
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
                    <asp:Button ID="btnSearchNow" runat="server" Text="Search" OnClick="mSearchStudent"
                        CssClass="button" />
                    &nbsp;&nbsp;
                    <asp:Button ID="btnCloseSearch" runat="server" Text="Close" CssClass="button" />
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
                                    <asp:BoundColumn HeaderText="National ID" DataField="StudentID"></asp:BoundColumn>
                                    <asp:BoundColumn HeaderText="Full Name" DataField="studentName"></asp:BoundColumn>
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


