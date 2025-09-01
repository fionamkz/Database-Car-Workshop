using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.IsisMtt.Ocsp;

namespace ProyectoBD
{
    public partial class Query : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string consultaId = Request.QueryString["consultaId"];
                if (!string.IsNullOrEmpty(consultaId))
                {
                    ExecuteQuery(consultaId);
                }
            }
        }

        protected void ExecuteQuery(string consultaId)

        {

            // Crear la consulta SQL

            string query = GetQuery(consultaId);



            // Crear una conexión MySQL aqui deben poner la información del servidor, de la bdd, usuario y password

            using (MySqlConnection connection = new MySqlConnection(Globales.connectionStringLocal))

            {

                // Crear un comando MySQL

                using (MySqlCommand command = new MySqlCommand(query, connection))
                {

                    try

                    {

                        // Abrir la conexión

                        connection.Open();



                        // Crear un adaptador de datos

                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))

                        {

                            // Crear un DataTable para almacenar los datos

                            DataTable dataTable = new DataTable();



                            // Llenar el DataTable

                            adapter.Fill(dataTable);



                            // Asignar el DataTable al GridView

                            GridViewQuery.DataSource = dataTable;

                            GridViewQuery.DataBind();

                        }

                    }

                    catch (Exception ex)

                    {

                        // Manejo de excepciones

                        // Puedes mostrar un mensaje de error o registrar el error

                        Response.Write("Error: " + ex.Message);

                    }

                }

            }

        }

        private string GetQuery(string consultaId)
        {
            switch (consultaId)
            {
                case "1":
                    return "SELECT * FROM vw_empleado_garantias_aplicadas";
                case "2":
                    return "SELECT * FROM vw_promociones_dep_mecanico";
                case "3":
                    return "SELECT * FROM vw_refacciones";
                case "4":
                    return "SELECT * FROM vw_ventas_diagnostico";
                case "6":
                    return "SELECT * FROM vw_deparamentos_gastos_garantias";
                case "8":
                    return "SELECT * FROM vw_empleados_dep4";
                case "9":
                    return "SELECT * FROM vw_cliente_automovil";
                case "10":
                    return "SELECT * FROM vw_reportes_refacciones";
                case "15":
                    return "SELECT * FROM vw_top_reparaciones";
                default:
                    return null;
            }
        }
    }
}