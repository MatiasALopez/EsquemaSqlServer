<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="EsquemaSqlServer._Default" %>
<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend></legend>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label runat="server" ID="lblConnectionString" AssociatedControlID="txtConnectionString" CssClass="col-sm-2 control-label">Connection String:</asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" ID="txtConnectionString" CssClass="form-control large" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" ID="lblNombreColeccion" AssociatedControlID="ddlNombreColeccion" CssClass="col-sm-2 control-label">Colección:</asp:Label>
                <div class="col-sm-10">
                    <asp:DropDownList runat="server" ID="ddlNombreColeccion" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-10 col-sm-offset-2">
                    <asp:Button runat="server" ID="btnObtener" Text="Obtener metadata" CssClass="btn btn-primary" OnClick="btnObtener_Click" />
                </div>
            </div>
        </div>

        <asp:Panel runat="server" ID="panMensaje" CssClass="alert alert-danger" />
        <asp:ValidationSummary runat="server" ID="summary" CssClass="alert alert-danger"
                DisplayMode="List" ShowValidationErrors="true" />
    
        <asp:RequiredFieldValidator runat="server" ID="rfvConnectionString" ControlToValidate="txtConnectionString"
            ErrorMessage="Debes ingresar la Connection String." Display="None" />
        <asp:RequiredFieldValidator runat="server" ID="rfvNombreColeccion" ControlToValidate="ddlNombreColeccion"
            ErrorMessage="Debes seleccionar la colección." Display="None" />

        <div class="row">
            <div class="grid-container">
                <asp:GridView runat="server" ID="gvDatos" AutoGenerateColumns="true" CssClass="table table-bordered table-condensed"
                    EmptyDataText="No hay datos para mostrar.">
                </asp:GridView>
            </div>
        </div>
    </fieldset>
</asp:Content>
