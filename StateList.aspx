<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="StateList.aspx.cs" Inherits="CRUD.StateList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <div class="container mt-5">
        <div class="d-flex justify-content-between align-items-center mb-4 px-5">
            <h2>State List</h2>
            <a href="StateAddEdit.aspx" class="btn btn-success">Add State</a>
        </div>
        <div class="table-responsive text-center">
            <table class="table table-bordered">
                <thead class="thead-dark">
                    <tr>
                        <th scope="col">State Id</th>
                        <th scope="col">State Name</th>
                        <th scope="col">State Code</th>
                        <th scope="col">Country Name</th>
                        <th scope="col">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptState" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("StateID") %></td>
                                <td><%# Eval("StateName") %></td>
                                <td><%# Eval("StateCode") %></td>
                                <td><%# Eval("CountryName") %></td>
                                <td>
                                    <a href="StateAddEdit.aspx?StateID=<%# Eval("StateID") %>&StateName=<%# Eval("StateName") %>&StateCode=<%# Eval("StateCode") %>" class="btn btn-primary btn-sm">Edit</a>
                                    <a href="StateList.aspx?StateID=<%# Eval("StateID") %>" class="btn btn-danger btn-sm">Delete</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
