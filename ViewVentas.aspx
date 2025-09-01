<%@ Page Title="Results" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="ViewVentas.aspx.cs" Inherits="ProyectoBD.ViewVentas" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <h1>Ventas</h1>

        <asp:GridView ID="GridViewResults" runat="server" AutoGenerateColumns="true" CssClass="table table-bordered" />

        <style>
            .table {
                width: 100%;
                margin-top: 20px;
                border-collapse: collapse;
            }

            .table-bordered {
                border: 1px solid #ddd;
            }

            .table-bordered th, .table-bordered td {
                padding: 8px;
                text-align: left;
                border: 1px solid #ddd;
            }
        </style>
    </main>

</asp:Content>
