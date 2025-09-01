using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Web.UI;

namespace ProyectoBD
{
    public partial class AddCar : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            // Verificar si hay campos vacíos
            if (string.IsNullOrWhiteSpace(id_carro.Text) ||
                string.IsNullOrWhiteSpace(id_cliente.Text) ||
                string.IsNullOrWhiteSpace(modelo.Text) ||
                string.IsNullOrWhiteSpace(marca.Text) ||
                string.IsNullOrWhiteSpace(matricula.Text) ||
                string.IsNullOrWhiteSpace(año.Text))
            {
                Response.Write("Todos los campos son obligatorios. Por favor, complete todos los campos.<br>");
                return;
            }

            // Variables para almacenar los datos convertidos
            int id_CarroIN, id_ClienteIN, añoIN;

            // Validación de id_carro y id_cliente (números enteros)
            if (!int.TryParse(id_carro.Text, out id_CarroIN) || !int.TryParse(id_cliente.Text, out id_ClienteIN))
            {
                Response.Write("Por favor, ingrese ID Carro e ID Cliente válidos.<br>");
                return;
            }

            string modeloIN = modelo.Text.Trim();
            string marcaIN = marca.Text.Trim();

            // Validación de la matrícula (formato AAA123)
            string matriculaIN = matricula.Text.Trim();

            if (!Regex.IsMatch(matriculaIN, @"^[A-Z]{3}\d{3}$"))
            {
                Response.Write("Por favor, ingresa una matrícula válida.<br>");
                return;
            }

            // Validación del año (rango permitido)
            if (!int.TryParse(año.Text, out añoIN) || añoIN < 1900 || añoIN > 2024)
            {
                Response.Write("Por favor, ingrese un año válido.<br>");
                return;
            }

            // Validación completa: proceder con la inserción en la base de datos
            using (MySqlConnection connection = new MySqlConnection(Globales.connectionStringLocal))
            {
                using (MySqlCommand command = new MySqlCommand("CALL stp_InsertarCarroYModelo(@id_CarroIN, @id_ClienteIN, @modeloIN, @marcaIN, @matriculaIN, @añoIN)", connection))
                {
                    // Agregar parámetros al comando
                    command.Parameters.AddWithValue("@id_CarroIN", id_CarroIN);
                    command.Parameters.AddWithValue("@id_ClienteIN", id_ClienteIN);
                    command.Parameters.AddWithValue("@modeloIN", modeloIN);
                    command.Parameters.AddWithValue("@marcaIN", marcaIN);
                    command.Parameters.AddWithValue("@matriculaIN", matriculaIN);
                    command.Parameters.AddWithValue("@añoIN", añoIN);

                    connection.Open();

                    try
                    {
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            GridViewResults.DataSource = dataTable;
                            GridViewResults.DataBind();

                            Response.Write("El vehículo se agregó exitosamente.<br>");
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
