<%@ Page Title="" Language="C#" MasterPageFile="~/MasterPage.Master" AutoEventWireup="true" CodeBehind="CityAddEdit.aspx.cs" Inherits="CRUD.CityAddEdit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="cphMainContent" runat="server">
    <asp:Label ID="lblMessage" runat="server"></asp:Label>
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-6">
                <div class="card">
                    <div class="card-header">
                        <h4>City Add/Edit</h4>
                    </div>
                    <div class="card-body">
                        <asp:TextBox
                            ID="txtCityName"
                            runat="server"
                            CssClass="form-control"
                            placeholder="Enter City Name"></asp:TextBox>
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
                            CssClass="form-control mt-3">
                            <asp:ListItem Value="0">Select State</asp:ListItem>
                        </asp:DropDownList>
                        <asp:TextBox
                            ID="txtSTDCode"
                            runat="server"
                            CssClass="form-control mt-3"
                            placeholder="Enter STD Code"></asp:TextBox>
                        <asp:TextBox
                            ID="txtPinCode"
                            runat="server"
                            CssClass="form-control mt-3"
                            placeholder="Enter PinCode"></asp:TextBox>
                        <asp:Button
                            ID="btnSave"
                            runat="server"
                            Text="Save"
                            CssClass="btn btn-success mt-3"
                            OnClick="btnSave_Click" />
                        <a href="CityList.aspx" class="btn btn-secondary mt-3 mx-3">Cancel</a>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
