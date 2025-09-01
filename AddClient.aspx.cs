using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ProyectoBD
{
    public partial class AddClient : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string nombreIn = nombre.Text;
            string telefonoIn = telefono.Text;
            string correoIn = correo.Text;

            if (string.IsNullOrEmpty(nombreIn) || string.IsNullOrEmpty(telefonoIn) || string.IsNullOrEmpty(correoIn))
            {
                Response.Write("Por favor ingrese todos los campos.");
                return;
            }

            // Crear una conexión MySQL
            using (MySqlConnection connection = new MySqlConnection(Globales.connectionStringLocal))
            {
                // Crear un comando MySQL
                using (MySqlCommand command = new MySqlCommand("CALL stp_InsertarCliente(@nombreIn, @telefonoIn, @correoIn)", connection))
                {
                    command.Parameters.AddWithValue("@nombreIn", nombreIn);
                    command.Parameters.AddWithValue("@telefonoIn", telefonoIn);
                    command.Parameters.AddWithValue("@correoIn", correoIn);

                    // Abrir la conexión
                    connection.Open();

                    try
                    {
                        // Crear un adaptador de datos
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            // Crear un DataTable para almacenar los datos
                            System.Data.DataTable dataTable = new System.Data.DataTable();

                            // Llenar el DataTable
                            adapter.Fill(dataTable);

                            // Asignar el DataTable al GridView
                            GridViewResults.DataSource = dataTable;
                            GridViewResults.DataBind();

                            Response.Write("El cliente se agregó exitosamente.<br>");
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejo de excepciones
                        Response.Write("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}