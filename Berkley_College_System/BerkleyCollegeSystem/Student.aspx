<%@ Page Title="Student" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Student.aspx.cs" Inherits="BerkleyCollegeSystem.Contact" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
		<div class="col d-flex comfortaa-light text-sm">
			<div class="card flex-fill p-4 shadow">
				

                <div class="mb-2">
                    <h5><asp:Label ID="Label1" class="intro-rust" runat="server" Text="Student Details"></asp:Label></h5>
                    <hr />
                </div>

                <div class="form-group row mb-2">
                    <asp:Label ID="Label2" class="col-sm-2 col-form-label" runat="server" for="TextBoxFirstName" Text="First Name * : "></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox class="form-control font-small" ID="TextBoxFirstName" runat="server" MaxLength="25" required="true"></asp:TextBox>
                    </div>
                </div>
                
                <div class="form-group row mb-2">
                    <asp:Label ID="Label3" class="col-sm-2 col-form-label" runat="server" for="TextBoxLasttName" Text="Last Name * : "></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox class="form-control font-small" ID="TextBoxLasttName" runat="server" MaxLength="25" required="true"></asp:TextBox>
                    </div>
                </div>
                
                <div class="form-group row mb-2">
                    <asp:Label ID="Label4" class="col-sm-2 col-form-label" runat="server" for="DateTimeDOB" Text="Date of Birth * : "></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox class="form-control font-small" textmode="Date" ID="DateTimeDOB" runat="server" required="true"></asp:TextBox>
                    </div>
                </div>
                
                <div class="form-group row mb-2">
                    <asp:Label ID="Label5" class="col-sm-2 col-form-label" runat="server" for="DDLGender" Text="Gender * : "></asp:Label>
                    <div class="col-sm-10">
                        <asp:DropDownList ID="DDLGender" runat="server" class="form-control font-small">
                            <asp:ListItem Value="Male">Male</asp:ListItem>
                            <asp:ListItem Value="Female">Female</asp:ListItem>
                            <asp:ListItem Value="Other">Others</asp:ListItem>
                        </asp:DropDownList>
                    </div>
                </div>
                
                <div class="form-group row mb-2">
                    <asp:Label ID="Label6" class="col-sm-2 col-form-label" runat="server" for="TextBoxEmail" Text="Email * : "></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox class="form-control font-small" textmode="Email" ID="TextBoxEmail" runat="server" MaxLength="50" title="Please enter a valid Email Address." required="true"></asp:TextBox>
                    </div>
                </div>
                
                <div class="form-group row mb-2">
                    <asp:Label ID="Label7" class="col-sm-2 col-form-label" runat="server" for="TextBoxPhoneNumber" Text="Phone Number * : "></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox class="form-control font-small" ID="TextBoxPhoneNumber" runat="server" MinLength="10" MaxLength="10" title="Please enter a valid 10 digit phone number." required="true"></asp:TextBox>
                    </div>
                </div>
                
                <div class="form-group row mb-2">
                    <asp:Label ID="Label8" class="col-sm-2 col-form-label" runat="server" for="DateTimeEnrollDate" Text="Enroll Date * : "></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox class="form-control font-small" textmode="Date" ID="DateTimeEnrollDate" runat="server" required="true"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group row mb-2">
                    <asp:Label ID="Label9" class="col-sm-2 col-form-label" runat="server" for="TextBoxEmergencyContact" Text="Emergency Contact : "></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox class="form-control font-small" ID="TextBoxEmergencyContact" runat="server" MinLength="10" MaxLength="10" title="Please enter a valid 10 digit phone number."></asp:TextBox>
                    </div>
                </div>

                <div class="form-group row mb-2">
                    <asp:Label ID="Label10" class="col-sm-2 col-form-label" runat="server" for="CheckBoxIsFeeDue" Text="Is Fee Due ? : "></asp:Label>
                    <div class="col-sm-10">
                        <asp:CheckBox class="form-control font-small border-0" ID="CheckBoxIsFeeDue" runat="server" Text="&nbsp; Yes"></asp:CheckBox>
                    </div>
                </div>

                <div class="form-group row mb-2">
                    <asp:Label ID="Label12" class="col-sm-2 col-form-label" runat="server" for="CheckBoxIsAttendanceEligible" Text="Is Attendance Eligible ? : "></asp:Label>
                    <div class="col-sm-10">
                        <asp:CheckBox class="form-control font-small border-0" ID="CheckBoxIsAttendanceEligible" runat="server" Text="&nbsp; Yes"></asp:CheckBox>
                    </div>
                </div>
                
                <div class="form-group row mb-2">
                    <asp:Label ID="Label11" class="col-sm-2 col-form-label" runat="server" for="CheckBoxIsGraduate" Text="Is Graduate ? : "></asp:Label>
                    <div class="col-sm-10">
                        <asp:CheckBox class="form-control font-small border-0" ID="CheckBoxIsGraduate" runat="server" Text="&nbsp; Yes"></asp:CheckBox>
                    </div>
                </div>

                
                <div>
                    <asp:TextBox ID="StudentID" runat="server" Visible ="false"></asp:TextBox>
                </div>
                

                <div class="mt-5 text-end">
                    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" class="btn btn-primary btn-lg px-4 font-small" onclick="ButtonSubmit_Click"></asp:Button>
                </div>
            
            </div>
        </div>
    </div>
    
    <div class="row mt-2">
		<div class="col d-flex">
			<div class="card flex-fill p-4 shadow">

				<div class="">
                    
                    <asp:GridView   ID="StudentGridView" runat="server" DataKeyNames="Student ID" 
                                    OnRowDataBound="OnRowDataBound" 
                                    OnRowEditing="OnRowEditing" 
                                    OnRowCancelingEdit="OnRowCancelingEdit"  
                                    OnRowDeleting="OnRowDeleting" 
                                    EmptyDataText="No records has been added." 
                                    AutoGenerateEditButton="True" 
                                    AutoGenerateDeleteButton="True"
                                    class="table table-hover table-responsive border-0 comfortaa-light text-sm">

                        <RowStyle CssClass="table-responsive table-hover opacity-75" />
                        

                    </asp:GridView>

                </div>
            
            </div>
        </div>
    </div>
    
</asp:Content>