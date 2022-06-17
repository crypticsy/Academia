﻿<%@ Page Title="Department" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Department.aspx.cs" Inherits="BerkleyCollegeSystem.About" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <div class="row">
		<div class="col d-flex comfortaa-light text-sm">
			<div class="card flex-fill p-4 shadow">
				

                <div class="mb-2">
                    <h5><asp:Label ID="Label1" class="intro-rust" runat="server" Text="Department Details"></asp:Label></h5>
                    <hr />
                </div>

                <div class="form-group row mb-2">
                    <asp:Label ID="Label2" class="col-sm-2 col-form-label" runat="server" for="TextBoxName" Text="Department Name * : "></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox class="form-control font-small" ID="TextBoxName" runat="server" MaxLength="50" required="true"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group row mb-2">
                    <asp:Label ID="Label3" class="col-sm-2 col-form-label" runat="server" for="TextBoxType" Text="Department Type * : "></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox class="form-control font-small" ID="TextBoxType" runat="server" MaxLength="25" required="true"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group row mb-2">
                    <asp:Label ID="Label4" class="col-sm-2 col-form-label" runat="server" for="TextBoxBuilding" Text="Building * : "></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox class="form-control font-small" ID="TextBoxBuilding" runat="server" MaxLength="50" required="true"></asp:TextBox>
                    </div>
                </div>

                <div class="form-group row mb-2">
                    <asp:Label ID="Label5" class="col-sm-2 col-form-label" runat="server" for="TextBoxRoom" Text="Room * : "></asp:Label>
                    <div class="col-sm-10">
                        <asp:TextBox class="form-control font-small" ID="TextBoxRoom" runat="server" MaxLength="25" required="true"></asp:TextBox>
                    </div>
                </div>
                
                <div>
                    <asp:TextBox ID="DepartmentID" runat="server" Visible ="false"></asp:TextBox>
                </div>
                

                <div class="mt-5 text-end">
                    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" class="btn btn-primary btn-lg px-4 font-small" OnClick="ButtonSubmit_Click"/>
                </div>
            
            </div>
        </div>
    </div>
    
    <div class="row mt-2">
		<div class="col d-flex">
			<div class="card flex-fill p-4 shadow">

				<div class="">
                    
                    <asp:GridView   ID="DepartmentGridView" runat="server" DataKeyNames="Department ID" 
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