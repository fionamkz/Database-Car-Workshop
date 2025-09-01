<%@ Page Title="Query Menu" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ProyectoBD._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <style>
            .menu-grid {
                display: grid;
                grid-template-columns: repeat(auto-fill, minmax(300px, 1fr));
                gap: 20px;
                margin-top: 20px;
            }

            .menu-box {
                border: 1px solid #ccc;
                padding: 15px;
                background-color: #f9f9f9;
                text-align: left;
                border-radius: 10px;
                box-shadow: 2px 2px 10px rgba(0, 0, 0, 0.1);
                transition: transform 0.3s ease, background-color 0.3s ease;
                cursor: pointer;
            }

            .menu-box:hover {
                background-color: #eaeaea;
                transform: scale(1.05);
            }

            .menu-box a {
                text-decoration: none;
                color: #333;
                font-size: 16px;
                display: block;
            }

            .menu-box h2 {
                font-size: 20px;
                margin-bottom: 10px;
            }

            .menu-box p {
                font-size: 14px;
                color: #555;
            }
        </style>

        <div>
            <h1>Taller Mecani-Kon</h1>

            <div class="menu-grid">
                <!-- Acceso al Reporteador -->
                <div class="menu-box">
                    <a href="QueryMenu.aspx">
                        <h2>Reporteador Principal</h2>
                        <p>Accede a los reportes de información del taller para supervisión y análisis de datos.</p>
                    </a>
                </div>

                <!-- Gestión de Clientes -->
                <div class="menu-box">
                    <a href="Clientes.aspx">
                        <h2>Clientes</h2>
                        <p>Gestiona la información de los clientes y registra nuevos.</p>
                    </a>
                </div>

                <!-- Gestión de Automóviles -->
                <div class="menu-box">
                    <a href="Automoviles.aspx">
                        <h2>Automóviles</h2>
                        <p>Gestiona la información de los automóviles y registra nuevos.</p>
                    </a>
                </div>

                <!-- Gestión de Diagnósticos -->
                <div class="menu-box">
                    <a href="Diagnostico.aspx">
                        <h2>Añadir Diagnóstico</h2>
                        <p>Registra nuevos diagnósticos.</p>
                    </a>
                </div>

                <!-- Gestión de Ventas -->
                <div class="menu-box">
                    <a href="Venta.aspx">
                        <h2>Ventas</h2>
                        <p>Gestiona la información de las ventas y registra nuevas ventas.</p>
                    </a>
                </div>
            </div>
        </div>
    </main>

</asp:Content>
