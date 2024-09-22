<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CountryAddEdit.aspx.cs" Inherits="CRUD.CountryAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="container mt-5">
        <h2>
            <asp:Label ID="lblTitle" runat="server" Text="Add/Edit Country" />
        </h2>
        <div cssclass="mt-4">
            <asp:TextBox
                ID="txtCountryName"
                runat="server"
                CssClass="form-control"
                Placeholder="Country Name" />
            <asp:TextBox
                ID="txtCountryCode"
                runat="server"
                CssClass="form-control mt-2"
                Placeholder="Country Code" />

            <asp:Button
                ID="btnSave"
                runat="server"
                Text="Save"
                CssClass="btn btn-primary mt-3"
                OnClick="btnSave_Click" />
            <asp:Button
                ID="btnCancel"
                runat="server"
                Text="Cancel"
                CssClass="btn btn-secondary mt-3"
                OnClick="btnCancel_Click" />
        </div>
    </div>
</asp:Content>
