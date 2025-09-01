using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using MySql.Data.MySqlClient;

namespace ProyectoBD
{
    public partial class Ventas : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
          
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            int idVenta, idDiagnostico;
            int? idProm = null;
            decimal costoTotal;
            string tipoPago = tipo_pago.SelectedValue; // Efectivo, Tarjeta de Crédito o Tarjeta de Débito

            // Validación de los campos
            if (string.IsNullOrWhiteSpace(id_venta.Text) ||
                string.IsNullOrWhiteSpace(costo_total.Text) ||
                string.IsNullOrWhiteSpace(id_diagnostico.Text) ||
                string.IsNullOrWhiteSpace(tipoPago))
            {
                Response.Write("Por favor, complete todos los campos.");
                return;
            }

            // Validación de los ID 
            if (!int.TryParse(id_venta.Text, out idVenta) || !int.TryParse(id_diagnostico.Text, out idDiagnostico))
            {
                Response.Write("Por favor, ingrese valores numéricos para los ID.");
                return;
            }

            // Validación del costo total 
            if (!decimal.TryParse(costo_total.Text, out costoTotal) || costoTotal <= 0)
            {
                Response.Write("Por favor, ingrese un costo total válido.");
                return;
            }

            // Si el campo de ID Promoción no está vacío, entonces lo asignamos
            if (!string.IsNullOrWhiteSpace(id_prom.Text))
            {
                if (!int.TryParse(id_prom.Text, out int parsedIdProm))
                {
                    Response.Write("Por favor, ingrese un valor numérico para el ID de Promoción.");
                    return;
                }
                idProm = parsedIdProm; // Asignamos el valor si es válido
            }


            // Insertar los datos en la base de datos
            using (MySqlConnection connection = new MySqlConnection(Globales.connectionStringLocal))
            {
                using (MySqlCommand command = new MySqlCommand("INSERT INTO venta (ID_Venta, Costo_Total, ID_Prom, ID_Diagnostico, Fecha, Tipo_Pago) VALUES (@IDVenta, @CostoTotal, @IDProm, @IDDiagnostico, @Fecha, @TipoPago)", connection))
                {
                    command.Parameters.AddWithValue("@IDVenta", idVenta);
                    command.Parameters.AddWithValue("@CostoTotal", costoTotal);
                    command.Parameters.AddWithValue("@IDProm", (object)idProm ?? DBNull.Value); // Permitir valores nulos para ID_Prom
                    command.Parameters.AddWithValue("@IDDiagnostico", idDiagnostico);
                    command.Parameters.AddWithValue("@Fecha", DateTime.Now); // Usar la fecha actual del sistema
                    command.Parameters.AddWithValue("@TipoPago", tipoPago);

                    try
                    {
                        // Abrir la conexión y ejecutar el comando
                        connection.Open();
                        command.ExecuteNonQuery();
                        Response.Write("Venta registrada exitosamente.");

                        // Recargar los resultados 
                        LoadVentas();
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error: " + ex.Message);
                    }
                }
            }
        }

        // Para cargar los registros de venta 
        private void LoadVentas()
        {
            using (MySqlConnection connection = new MySqlConnection(Globales.connectionStringLocal))
            {
                using (MySqlCommand command = new MySqlCommand("SELECT * FROM venta", connection))
                {
                    try
                    {
                        connection.Open();
                        using (MySqlDataAdapter adapter = new MySqlDataAdapter(command))
                        {
                            System.Data.DataTable dataTable = new System.Data.DataTable();
                            adapter.Fill(dataTable);
                            GridViewResults.DataSource = dataTable;
                            GridViewResults.DataBind();
                        }
                    }
                    catch (Exception ex)
                    {
                        Response.Write("Error al cargar las ventas: " + ex.Message);
                    }
                }
            }
        }
    }
}
