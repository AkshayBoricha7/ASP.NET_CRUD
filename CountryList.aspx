<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CountryList.aspx.cs" Inherits="CRUD.CountryList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <div class="container mt-5">
        <div class="d-flex px-5 justify-content-between align-items-center mb-4">
            <h2>Country List</h2>
            <a href="CountryAddEdit.aspx" class="btn btn-success">Add Country</a>
        </div>
        <div class="table-responsive text-center">
            <table class="table table-bordered">
                <thead class="thead-dark">
                    <tr>
                        <th scope="col">Country Id</th>
                        <th scope="col">Country Name</th>
                        <th scope="col">Country Code</th>
                        <th scope="col">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptCountry" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("CountryID") %></td>
                                <td><%# Eval("CountryName") %></td>
                                <td><%# Eval("CountryCode") %></td>
                                <td>
                                    <a href="CountryAddEdit.aspx?CountryID=<%# Eval("CountryID") %>" class="btn btn-primary btn-sm">Edit</a>
                                    <a href="CountryList.aspx?CountryID=<%# Eval("CountryID") %>" class="btn btn-danger btn-sm">Delete</a>
                                </td>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
