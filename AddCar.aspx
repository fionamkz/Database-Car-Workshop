<%@ Page Title="Query with Date" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="AddCar.aspx.cs" Inherits="ProyectoBD.AddCar" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">
   
    <main>
        <div>
            <label for="id_carro">ID Carro:</label>
            <asp:TextBox ID="id_carro" runat="server" CssClass="form-control" Placeholder="123"></asp:TextBox>
        </div>

        <div>
            <label for="id_cliente">ID Cliente:</label>
            <asp:TextBox ID="id_cliente" runat="server" CssClass="form-control" Placeholder="123"></asp:TextBox>
        </div>

        <div>
            <label for="mddelo">Modelo:</label>
            <asp:TextBox ID="modelo" runat="server" CssClass="form-control" Placeholder="Civic"></asp:TextBox>
        </div>

        <div>
            <label for="marca">Marca:</label>
            <asp:TextBox ID="marca" runat="server" CssClass="form-control" Placeholder="Honda"></asp:TextBox>
        </div>

        <div>
            <label for="matricula">Matrícula:</label>
            <asp:TextBox ID="matricula" runat="server" CssClass="form-control" Placeholder="ABC123"></asp:TextBox>
        </div>

        <div>
            <label for="año">Año:</label>
            <asp:TextBox ID="año" runat="server" CssClass="form-control" Placeholder="YYYY"></asp:TextBox>
        </div>


        <asp:Button ID="btnSubmit" runat="server" Text="Submit" OnClick="btnSubmit_Click" CssClass="submit-button" />

        <asp:GridView ID="GridViewResults" runat="server" AutoGenerateColumns="true"></asp:GridView>

        <style>
            .form-control {
                margin: 5px 0;
                padding: 8px;
                width: 250px;
                display: block;
            }

            .submit-button {
                padding: 10px;
                background-color: #2ecc71;
                color: white;
                border: none;
                cursor: pointer;
            }

            .submit-button:hover {
                background-color: #27ae60;
            }
        </style>
    </main>

</asp:Content>
