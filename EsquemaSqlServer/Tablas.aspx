<%@ Page Title="Tablas" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Tablas.aspx.cs" Inherits="EsquemaSqlServer.Tablas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <fieldset>
        <legend></legend>

        <div class="form-horizontal">
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtConnectionString" CssClass="col-sm-2 control-label">Connection String:</asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" ID="txtConnectionString" CssClass="form-control large" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtNombreEsquema" CssClass="col-sm-2 control-label">Esquema:</asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" ID="txtNombreEsquema" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <asp:Label runat="server" AssociatedControlID="txtNombreTabla" CssClass="col-sm-2 control-label">Tabla:</asp:Label>
                <div class="col-sm-10">
                    <asp:TextBox runat="server" ID="txtNombreTabla" CssClass="form-control" />
                </div>
            </div>
            <div class="form-group">
                <div class="col-sm-10 col-sm-offset-2">
                    <asp:Button runat="server" ID="btnObtener" Text="Obtener metadata" CssClass="btn btn-primary" OnClick="btnObtener_Click" />
                </div>
            </div>
        </div>

        <asp:Panel runat="server" ID="panMensaje" CssClass="alert alert-danger" Visible="false" />
        <asp:ValidationSummary runat="server" ID="summary" CssClass="alert alert-danger"
                DisplayMode="List" ShowValidationErrors="true" />
    
        <asp:RequiredFieldValidator runat="server" ID="rfvConnectionString" ControlToValidate="txtConnectionString"
            ErrorMessage="Debes ingresar la Connection String." Display="None" />
        <asp:RequiredFieldValidator runat="server" ID="rfvNombreTabla" ControlToValidate="txtNombreTabla"
            ErrorMessage="Debes ingresar el nombre de la tabla." Display="None" />

        <div class="row">
            <div class="grid-container">
                <asp:GridView runat="server" ID="gvDatos" AutoGenerateColumns="true" CssClass="table table-bordered table-condensed"
                    EmptyDataText="No hay datos para mostrar.">
                </asp:GridView>
            </div>
        </div>
    </fieldset>
</asp:Content>
