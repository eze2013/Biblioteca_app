<%@ Page Title="Consulta Autores" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ConsultaAutores.aspx.cs" Inherits="Biblioteca.Web.ConsultaAutores" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
    <h2>Consulta de Autores por País</h2>
    <style>
        h2{
            color:green;
            text-align:center;
        }
    </style>
    <hr />

    <div class="row">
        <div class="col-md-4">
            <div class="form-group">
                <label for="ddlPaises">Seleccione un País:</label>
                <%-- DropDownList para los países --%>
                <asp:DropDownList ID="ddlPaises" runat="server" 
                    CssClass="form-control">
                    <%-- Los países se cargarán aquí --%>
                </asp:DropDownList>
            </div>
            
            <%-- Botón que activa la consulta al Code-Behind --%>
            <asp:Button ID="btnConsultar" runat="server" 
                Text="Consultar Autores" 
                CssClass="btn btn-primary" 
                OnClick="btnConsultar_Click" />
            
            <%-- Literal para mostrar mensajes de éxito o error --%>
            <asp:Literal ID="litMensaje" runat="server" EnableViewState="false"></asp:Literal>
        </div>
        <style>
            .row{
                text-align:center;
            }
        </style>
    </div>
    
    <br />
    
    <div class="row">
        <div class="col-md-12">
            <h3>Autores Encontrados</h3>
            <%-- GridView que listará los autores --%>
            <asp:GridView ID="gvAutores" runat="server" 
                AutoGenerateColumns="true" 
                CssClass="table table-striped table-hover"
                EmptyDataText="No se encontraron autores para el país seleccionado.">
            </asp:GridView>
        </div>
        <style>
            body{
                text-align:center;
            }
        </style>
    </div>
</asp:Content>
