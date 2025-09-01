<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="AddVenta.aspx.cs" Inherits="ProyectoBD.Ventas" MasterPageFile="~/Site.Master" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <main>
        <div>
            <label for="id_venta">ID Venta:</label>
            <asp:TextBox ID="id_venta" runat="server" CssClass="form-control" Placeholder="Ej: 123"></asp:TextBox>
        </div>

        <div>
            <label for="costo_total">Costo Total:</label>
            <asp:TextBox ID="costo_total" runat="server" CssClass="form-control" Placeholder="0.00"></asp:TextBox>
        </div>

        <div>
            <label for="id_prom">ID Promoción (Opcional):</label>
            <asp:TextBox ID="id_prom" runat="server" CssClass="form-control" Placeholder="123"></asp:TextBox>
        </div>

        <div>
            <label for="id_diagnostico">ID Diagnóstico:</label>
            <asp:TextBox ID="id_diagnostico" runat="server" CssClass="form-control" Placeholder="123"></asp:TextBox>
        </div>

        <div>
            <label for="tipo_pago">Tipo de Pago:</label>
            <asp:DropDownList ID="tipo_pago" runat="server" CssClass="form-control">
                <asp:ListItem Value="Efectivo">Efectivo</asp:ListItem>
                <asp:ListItem Value="Tarjeta de Crédito">Tarjeta de Crédito</asp:ListItem>
                <asp:ListItem Value="Tarjeta de Débito">Tarjeta de Débito</asp:ListItem>
            </asp:DropDownList>
        </div>

        <div>
            <asp:Button ID="btnSubmit" runat="server" Text="Registrar Venta" OnClick="btnSubmit_Click" CssClass="submit-button" />
        </div>

        <div>
            <asp:GridView ID="GridViewResults" runat="server" AutoGenerateColumns="true" CssClass="table table-bordered" />
        </div>

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

