<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ContactList.aspx.cs" Inherits="CRUD.ContactList" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <div class="container mt-5">
        <div class="d-flex px-5 justify-content-between align-items-center mb-4">
            <h2>Contact List</h2>
            <a href="ContactAddEdit.aspx" class="btn btn-success">Add Contact</a>
        </div>
        <div class="table-responsive text-center">
            <table class="table table-bordered">
                <thead class="thead-dark">
                    <tr>
                        <th scope="col">Contact Name</th>
                        <th scope="col">Contact No</th>
                        <th scope="col">WhatsApp No</th>
                        <th scope="col">Country Name</th>
                        <th scope="col">State Name</th>
                        <th scope="col">City Name</th>
                        <th scope="col">BirthDate</th>
                        <th scope="col">Email</th>
                        <th scope="col">Age</th>
                        <th scope="col">Address</th>
                        <th scope="col">BloodGroup</th>
                        <th scope="col">FacebookID</th>
                        <th scope="col">LinkedINID</th>
                        <th scope="col">Creation Date</th>
                        <th scope="col">Actions</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptContact" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("ContactName") %></td>
                                <td><%# Eval("ContactNo") %></td>
                                <td><%# Eval("WhatsAppNo") %></td>
                                <td><%# Eval("CountryName") %></td>
                                <td><%# Eval("StateName") %></td>
                                <td><%# Eval("CityName") %></td>                                
                                <td><%# Eval("BirthDate") %></td>
                                <td><%# Eval("Email") %></td>
                                <td><%# Eval("Age") %></td>
                                <td><%# Eval("Address") %></td>
                                <td><%# Eval("BloodGroup") %></td>
                                <td><%# Eval("FacebookID") %></td>
                                <td><%# Eval("LinkedINID") %></td>
                                <td><%# Eval("CreationDate") %></td>
                                <td>
                                    <a href="ContactAddEdit.aspx?ContactID=<%# Eval("ContactID") %>" class="btn btn-primary btn-sm">Edit</a>
                                    <a href="ContactList.aspx?ContactID=<%# Eval("ContactID") %>" class="btn btn-danger btn-sm">Delete</a>
                                </td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>
</asp:Content>
