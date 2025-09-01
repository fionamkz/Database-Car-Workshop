<%@ Page Title="Results" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Query.aspx.cs" Inherits="ProyectoBD.Query" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <main>
        <div>
            <asp:GridView ID="GridViewQuery" runat="server" AutoGenerateColumns="true" CssClass="table table-bordered" />
        </div>

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
