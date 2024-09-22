<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ContactCategoryAddEdit.aspx.cs" Inherits="CRUD.ContactCategoryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">
                        <h4>Contact Category Add/Edit</h4>
                    </div>
                    <div class="card-body">
                        <asp:TextBox
                            ID="txtContactCategoryName"
                            runat="server"
                            CssClass="form-control"
                            placeholder="Enter Contact Category Name"></asp:TextBox>
                        <asp:Button
                            ID="btnSave"
                            runat="server"
                            Text="Save"
                            CssClass="btn btn-success mt-3"
                            OnClick="btnSave_Click" />
                        <a href="ContactCategory.aspx" class="btn btn-secondary mt-3 mx-3">Cancel</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
