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
    public partial class ViewCars : Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Crear la consulta SQL

                string query = "SELECT ID_Carro, ID_Cliente, ID_Modelo, Matricula, Año FROM automovil";

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

                                GridViewResults.DataSource = dataTable;

                                GridViewResults.DataBind();

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
        }
    }
}