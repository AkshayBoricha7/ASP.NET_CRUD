<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="ContactAddEdit.aspx.cs" Inherits="CRUD.ContactAddEdit" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">
                        <h4>Contact Add/Edit</h4>
                    </div>
                    <div class="card-body">
                        <asp:TextBox
                            ID="txtContactName"
                            runat="server"
                            CssClass="form-control mt-3"
                            placeholder="Enter Contact Name"></asp:TextBox>
                        <asp:TextBox
    ID="txtContactNo"
    runat="server"
    CssClass="form-control mt-3"
    placeholder="Enter Contact No"></asp:TextBox>
                                            <asp:TextBox
ID="txtWhatsAppNo"
runat="server"
CssClass="form-control mt-3"
placeholder="Enter WhatsApp No"></asp:TextBox>

                        <asp:DropDownList
                            ID="ddlCountry"
                            runat="server"
                            CssClass="form-control mt-3"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="ddlCountry_SelectedIndexChanged">
                            <asp:ListItem Value="0">Select Country</asp:ListItem>
                        </asp:DropDownList>

                        <asp:DropDownList
                            ID="ddlState"
                            runat="server"
                            CssClass="form-control mt-3"
                            AutoPostBack="true"
                            OnSelectedIndexChanged="ddlState_SelectedIndexChanged">
                            <asp:ListItem Value="0">Select State</asp:ListItem>
                        </asp:DropDownList>
    <asp:DropDownList
    ID="ddlContactCategory"
    runat="server"
    CssClass="form-control mt-3">
    <asp:ListItem Value="0">Select Contact Category</asp:ListItem>
</asp:DropDownList>
                        <asp:DropDownList
    ID="ddlCity"
    runat="server"
    CssClass="form-control mt-3">
    <asp:ListItem Value="0">Select City</asp:ListItem>
</asp:DropDownList>
                        <asp:TextBox
                            ID="txtBirthDate"
                            runat="server"
                            CssClass="form-control mt-3"
                            placeholder="Enter Birth Date"></asp:TextBox>
                        <asp:TextBox
                            ID="txtEmail"
                            runat="server"
                            CssClass="form-control mt-3"
                            placeholder="Enter Email"></asp:TextBox>
                        <asp:TextBox
    ID="txtAge"
    runat="server"
    CssClass="form-control mt-3"
    placeholder="Enter Age"></asp:TextBox>
                        <asp:TextBox
    ID="txtAddress"
    runat="server"
    CssClass="form-control mt-3"
    placeholder="Enter Address"></asp:TextBox>
                        <asp:TextBox
    ID="txtBloodGroup"
    runat="server"
    CssClass="form-control mt-3"
    placeholder="Enter Blood Group"></asp:TextBox>
                        <asp:TextBox
    ID="txtFacebookID"
    runat="server"
    CssClass="form-control mt-3"
    placeholder="Enter Facebook ID"></asp:TextBox>

                        <asp:TextBox
    ID="txtLinkedINID"
    runat="server"
    CssClass="form-control mt-3"
    placeholder="Enter LinkedIN ID"></asp:TextBox>
                        <asp:Button
                            ID="btnSave"
                            runat="server"
                            Text="Save"
                            CssClass="btn btn-success mt-3"
                            OnClick="btnSave_Click" />
                        <a href="ContactList.aspx" class="btn btn-secondary mt-3 mx-3">Cancel</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
