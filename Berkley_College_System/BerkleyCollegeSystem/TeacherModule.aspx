<%@ Page Title="TeacherModule" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="TeacherModule.aspx.cs" Inherits="BerkleyCollegeSystem.WebForm4" %>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="row">
		<div class="col d-flex comfortaa-light text-sm">
			<div class="card flex-fill p-4 shadow">
				

                <div class="mb-2">
                    <h5><asp:Label ID="Label1" class="intro-rust" runat="server" Text="Teacher Module Mapping Form"></asp:Label></h5>
                    <hr />
                </div>

                <div class="form-group row mb-2">
                    <asp:Label ID="Label2" class="col-sm-2 col-form-label" runat="server" for="DDLTeacher" Text="Teacher : "></asp:Label>
                    <div class="col-sm-10">
                        <div class="row">
                        
                        <div class="col-lg">
                            <asp:DropDownList ID="DDLTeacher" runat="server" class="form-control font-small">
                            </asp:DropDownList>
                        </div>

                        <div class="col">
                            <asp:Button ID="ButtonSubmit" runat="server" Text="Search" class="btn btn-primary btn-lg px-4 font-small" OnClick="ButtonSubmit_Click">
                            </asp:Button>
                        </div>

                        </div>
                    </div>

                </div>
                
                <div class="mt-5 text-end">
                    <asp:Button ID="ButtonShowAll" runat="server" Text="View All" class="btn btn-primary btn-lg px-4 font-small" OnClick="ShowAllSubmit_Click">
                    </asp:Button>
                </div>
            </div>
        </div>
    </div>
    
    <div class="row mt-2">
		<div class="col d-flex">
			<div class="card flex-fill p-4 shadow">

				<div class="">
                    
                    <asp:GridView   ID="TeacherModuleGridView" runat="server"
                                    EmptyDataText="No records found for the given teacher."
                                    class="table table-hover table-responsive border-0 comfortaa-light text-sm">
                        
                        <RowStyle CssClass="table-responsive table-hover opacity-75" />
                        
                    </asp:GridView>

                </div>
            
            </div>
        </div>
    </div>


</asp:Content>