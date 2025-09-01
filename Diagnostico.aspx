<%@ Page Title="Añadir Diagnóstico" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Diagnostico.aspx.cs" Inherits="ProyectoBD.Diagnostico" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <main>
        <h1>Añadir Diagnóstico</h1>

        <div>
            <label for="id_diagnostico">ID Diagnóstico:</label>
            <asp:TextBox ID="id_diagnostico" runat="server" CssClass="form-control" Placeholder="123"></asp:TextBox>
        </div>

        <div>
            <label for="fecha_inicio">Fecha de Inicio:</label>
            <asp:TextBox ID="fecha_inicio" runat="server" CssClass="form-control" Placeholder="YYYY-MM-DD"></asp:TextBox>
        </div>

        <div>
            <label for="fecha_fin">Fecha de Finalización:</label>
            <asp:TextBox ID="fecha_fin" runat="server" CssClass="form-control" Placeholder="YYYY-MM-DD"></asp:TextBox>
        </div>

        <div>
            <label for="id_carro">ID Carro:</label>
            <asp:TextBox ID="id_carro" runat="server" CssClass="form-control" Placeholder="123"></asp:TextBox>
        </div>

        <div>
            <label>Continua en el Taller:</label>
            <asp:RadioButtonList ID="continua" runat="server" CssClass="form-control">
                <asp:ListItem Text="Sí" Value="1" />
                <asp:ListItem Text="No" Value="0" />
            </asp:RadioButtonList>
        </div>

        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="Registrar Diagnóstico" OnClick="btnSubmit_Click" CssClass="submit-button" />
        </div>

        <asp:GridView ID="GridViewResults" runat="server" AutoGenerateColumns="true" CssClass="table table-bordered" />

        <style>
            .form-control {
                margin: 5px 0;
                padding: 8px;
                width: 250px;
                display: block;
            }

            .submit-button {
                padding: 10px;
                background-color: #3498db;
                color: white;
                border: none;
                cursor: pointer;
            }

            .submit-button:hover {
                background-color: #2980b9;
            }

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
