<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CityList.aspx.cs" Inherits="CRUD.CityList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <div class="container mt-5">
        <div class="d-flex px-5 justify-content-between align-items-center mb-4">
            <h2>City List</h2>
            <a href="CityAddEdit.aspx" class="btn btn-success">Add City</a>
        </div>
        <div class="table-responsive text-center">
            <table class="table table-bordered">
                <thead class="thead-dark">
                    <tr>
                        <th scope="col">City Id</th>
                        <th scope="col">City Name</th>
                        <th scope="col">State Name</th>
                        <th scope="col">Country Name</th>
                        <th scope="col">Pincode</th>
                        <th scope="col">STD Code</th>
                        <th scope="col">Creation Date</th>
                        <th scope="col">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptCity" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("CityID") %></td>
                                <td><%# Eval("CityName") %></td>
                                <td><%# Eval("StateName") %></td>
                                <td><%# Eval("CountryName") %></td>
                                <td><%# Eval("PinCode") %></td>
                                <td><%# Eval("STDCode") %></td>
                                <td><%# Eval("CreationDate") %></td>
                                <td>
                                    <a href="CityAddEdit.aspx?CityID=<%# Eval("CityID") %>" class="btn btn-primary btn-sm">Edit</a>
                                    <a href="CityList.aspx?CityID=<%# Eval("CityID") %>" class="btn btn-danger btn-sm">Delete</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
