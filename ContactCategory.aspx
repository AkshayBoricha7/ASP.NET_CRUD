<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ContactCategory.aspx.cs" Inherits="CRUD.ContactCategory" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <div class="container mt-5">
        <div class="d-flex justify-content-between align-items-center mb-4 px-5">
            <h2>Contact Category List</h2>
            <a href="ContactCategoryAddEdit.aspx" class="btn btn-success">Add Contact Category</a>
        </div>
        <div class="table-responsive text-center">
            <table class="table table-bordered">
                <thead class="thead-dark">
                    <tr>
                        <th scope="col">Contact Category Id</th>
                        <th scope="col">Contact Category Name</th>
                        <th scope="col">Creation Date</th>
                        <th scope="col">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptState" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("ContactCategoryID") %></td>
                                <td><%# Eval("ContactCategoryName") %></td>
                                <td><%# Eval("CreationDate") %></td>
                                <td>
                                    <a href="ContactCategoryAddEdit.aspx?ContactCategoryID=<%# Eval("ContactCategoryID") %>&ContactCategoryName=<%# Eval("ContactCategoryName") %>" class="btn btn-primary btn-sm">Edit</a>
                                    <a href="ContactCategory.aspx?ContactCategoryID=<%# Eval("ContactCategoryID") %>" class="btn btn-danger btn-sm">Delete</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
