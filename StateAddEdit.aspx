<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="StateAddEdit.aspx.cs" Inherits="CRUD.StateAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <div class="container mt-5">
        <div class="d-flex justify-content-between align-items-center mb-4">
        </div>
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">
                        <h4>State Add/Edit</h4>
                    </div>
                    <div class="card-body">
                        <asp:TextBox
                            ID="txtStateName"
                            runat="server"
                            CssClass="form-control"
                            placeholder="Enter State Name"></asp:TextBox>
                        <asp:TextBox
                            ID="txtStateCode"
                            runat="server"
                            CssClass="form-control mt-3"
                            placeholder="Enter State Code"></asp:TextBox>
                        <asp:DropDownList
                            ID="ddlCountry"
                            runat="server"
                            CssClass="form-control mt-3">
                            <asp:ListItem Value="0">Select Country</asp:ListItem>
                        </asp:DropDownList>
                        <asp:Button
                            ID="btnSave"
                            runat="server"
                            Text="Save"
                            CssClass="btn btn-success mt-3"
                            OnClick="btnSave_Click" />
                        <a href="StateList.aspx" class="btn btn-primary mt-3">Cancel</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
