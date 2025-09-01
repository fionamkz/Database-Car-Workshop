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
    public partial class Diagnostico : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            DateTime fechaInicio, fechaFin;
            int idCarro, idDiagnostico;
            int numContinua = 0;

            // Validación de los campos
            if (string.IsNullOrWhiteSpace(fecha_inicio.Text) ||
                string.IsNullOrWhiteSpace(fecha_fin.Text) ||
                string.IsNullOrWhiteSpace(id_carro.Text) ||
                string.IsNullOrWhiteSpace(id_diagnostico.Text))
            {
                Response.Write("Por favor, complete todos los campos.");
                return;
            }

            // Validación de las fechas
            if (!DateTime.TryParse(fecha_inicio.Text, out fechaInicio) ||
                !DateTime.TryParse(fecha_fin.Text, out fechaFin))
            {
                Response.Write("Por favor ingrese fechas válidas.");
                return;
            }

            // Validación de que la fecha de inicio sea antes de la fecha de finalización
            if (fechaInicio >= fechaFin)
            {
                Response.Write("Por favor ingrese fechas válidas.");
                return;
            }

            // Validación del ID Carro y ID Diagnóstico
            if (!int.TryParse(id_carro.Text, out idCarro) || !int.TryParse(id_diagnostico.Text, out idDiagnostico))
            {
                Response.Write("Por favor, ingrese valores númericos.");
                return;
            }

            // Obtener el valor seleccionado de la lista de radio
            if (continua.SelectedValue == "1")
            {
                numContinua = 1;  // "Sí" seleccionado
            }
            else if (continua.SelectedValue == "0")
            {
                numContinua = 0;  // "No" seleccionado
            }

            // Insertar los datos en la base de datos
            using (MySqlConnection connection = new MySqlConnection(Globales.connectionStringLocal))
            {
                using (MySqlCommand command = new MySqlCommand("INSERT INTO diagnostico (ID_Diagnostico, Fecha_Inicio, Fecha_Fin, ID_Carro, Continua) VALUES (@IDDiagnostico, @FechaInicio, @FechaFin, @IDCarro, @Continua)", connection))
                {
                    command.Parameters.AddWithValue("@IDDiagnostico", idDiagnostico);
                    command.Parameters.AddWithValue("@FechaInicio", fechaInicio);
                    command.Parameters.AddWithValue("@FechaFin", fechaFin);
                    command.Parameters.AddWithValue("@IDCarro", idCarro);
                    command.Parameters.AddWithValue("@Continua", numContinua);

                    try
                    {
                        // Abrir la conexión y ejecutar el comando
                        connection.Open();
                        command.ExecuteNonQuery();
                        Response.Write("Diagnóstico registrado exitosamente.");

                        // Recargar los resultados 
                        LoadDiagnosticos();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);
                    }
                }
            }
        }



        // Para cargar los registros de diagnóstico 
        private void LoadDiagnosticos()
        {
            using (MySqlConnection connection = new MySqlConnection(Globales.connectionStringLocal))
            {
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM diagnostico", connection))
                {
                    try
                    {
                        connection.Open();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            GridViewResults.DataSource = dataTable;
                            GridViewResults.DataBind();
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error al cargar los diagnósticos: " + ex.Message);
                    }
                }
            }
        }
    }
}
