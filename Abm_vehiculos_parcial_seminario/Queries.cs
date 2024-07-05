using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Data.Odbc;

namespace Abm_vehiculos_parcial_seminario
{
	public class Queries
	{
		private DBConnection dbConnection;

		public Queries()
		{
			dbConnection = new DBConnection();
		}
		
		public bool create_register(string codigo, string tipo, string marca, string modelo, int año,
			string caracteristicas, string patente, string condicion, int kilometraje, decimal precio,
			DateTime ingreso, bool disponibilidad)
		{
			string consultaCheck = "SELECT COUNT(*) FROM Vehiculos WHERE patente = @patente";
			string consultaInsert = "INSERT INTO Vehiculos (codigo, tipo, marca, modelo, año, caracteristicas," +
				"patente, condicion, " +
				"kilometraje, precio, ingreso, disponibilidad)" +
				"VALUES (@codigo, @tipo, @marca, @modelo, @año, @caracteristicas, @patente, @condicion, @kilometraje, " +
				"@precio, @ingreso, @disponibilidad)";

			using (SqlConnection conexion = new SqlConnection(dbConnection.strConexion))
			{
				try
				{
					conexion.Open();

					// Verificar si la patente ya existe
					using (SqlCommand commandCheck = new SqlCommand(consultaCheck, conexion))
					{
						commandCheck.Parameters.AddWithValue("@patente", patente);

						int count = (int)commandCheck.ExecuteScalar();
						if (count > 0)
						{
							MessageBox.Show("El vehículo con la patente ingresada ya existe.", "Vehículo ya existe", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return false;
						}
					}

					// Insertar el nuevo registro
					using (SqlCommand commandInsert = new SqlCommand(consultaInsert, conexion))
					{
						commandInsert.Parameters.AddWithValue("@codigo", codigo);
						commandInsert.Parameters.AddWithValue("@tipo", tipo);
						commandInsert.Parameters.AddWithValue("@marca", marca);
						commandInsert.Parameters.AddWithValue("@modelo", modelo);
						commandInsert.Parameters.AddWithValue("@año", año);
						commandInsert.Parameters.AddWithValue("@caracteristicas", caracteristicas);
						commandInsert.Parameters.AddWithValue("@patente", patente);
						commandInsert.Parameters.AddWithValue("@condicion", condicion);
						commandInsert.Parameters.AddWithValue("@kilometraje", kilometraje);
						commandInsert.Parameters.AddWithValue("@precio", precio);
						commandInsert.Parameters.AddWithValue("@ingreso", ingreso);
						commandInsert.Parameters.AddWithValue("@disponibilidad", disponibilidad);

						int rowsAffected = commandInsert.ExecuteNonQuery();
						return rowsAffected > 0; // Retorna true si al menos una fila fue afectada
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Error al crear el registro: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return false;
				}
			}
		}

		public DataTable read_filter_condition_registers(string consulta)
		{
			DataTable dataTable = new DataTable();
			SqlConnection Conexion;
			SqlCommand Command;
			SqlDataReader Reader;

			try
			{
				Conexion = new SqlConnection(dbConnection.strConexion);
				Command = new SqlCommand(consulta, Conexion);

				Conexion.Open();
				Reader = Command.ExecuteReader();

				dataTable.Load(Reader);

				Conexion.Close();
				Reader.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al leer los registros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return dataTable;
		}
		public DataTable read_registers()
		{
			string consulta = "SELECT Codigo,Tipo,Marca,Modelo,Año,Caracteristicas,Patente,Condicion,Kilometraje,Precio,Ingreso FROM Vehiculos WHERE Disponibilidad = 1";
			DataTable dataTable = new DataTable();
			SqlConnection Conexion;
			SqlCommand Command;
			SqlDataReader Reader;

			try
			{
				Conexion = new SqlConnection(dbConnection.strConexion);
				Command = new SqlCommand(consulta, Conexion);

				Conexion.Open();
				Reader = Command.ExecuteReader();

				dataTable.Load(Reader);

				Conexion.Close();
				Reader.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al leer los registros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return dataTable;
		}
		public DataTable read_filter_registers(string filter)
		{
			// Agregar el filtro de patente a la consulta
			string consulta = "SELECT Codigo, Tipo, Marca, Modelo, Año, Caracteristicas, Patente, Condicion, Kilometraje, Precio, Ingreso " +
				  "FROM Vehiculos " +
				  "WHERE Patente LIKE" + "'" + @filter + "%';";

			DataTable dataTable = new DataTable();
			SqlConnection Conexion;
			SqlCommand Command;
			SqlDataReader Reader;

			try
			{
				Conexion = new SqlConnection(dbConnection.strConexion);
				Command = new SqlCommand(consulta, Conexion);

				Command.Parameters.AddWithValue("@filter", "%" + filter + "%");

				Conexion.Open();
				Reader = Command.ExecuteReader();

				dataTable.Load(Reader);
				Conexion.Close();
				Reader.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al leer los registros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return dataTable;
		}
		public bool logic_down_register(string codigo)
		{
			string consulta = "UPDATE Vehiculos SET Disponibilidad = 0 WHERE Codigo = @codigo";

			using (SqlConnection conexion = new SqlConnection(dbConnection.strConexion))
			{
				using (SqlCommand command = new SqlCommand(consulta, conexion))
				{
					command.Parameters.AddWithValue("@codigo", codigo);
					DialogResult result = MessageBox.Show("¿Está seguro que desea dar de baja este vehiculo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (result == DialogResult.Yes)
					{
						try
						{
							conexion.Open();
							int rowsAffected = command.ExecuteNonQuery();
							if (rowsAffected > 0)
							{
								MessageBox.Show("Vehiculo dado de baja con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
							else
							{
								MessageBox.Show("No se encontró ningún vehiculo con el código especificado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
							return rowsAffected > 0;
						}
						catch (Exception ex)
						{
							MessageBox.Show("Error al dar de baja el vehiculo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return false;
						}
					}
					else
					{
						return false;
					}
				}
			}
		}
		public bool delete_register(string codigo)
		{
			string consulta = "DELETE FROM Vehiculos WHERE Codigo = @codigo";

			using (SqlConnection conexion = new SqlConnection(dbConnection.strConexion))
			{
				using (SqlCommand command = new SqlCommand(consulta, conexion))
				{
					command.Parameters.AddWithValue("@codigo", codigo);
					DialogResult result = MessageBox.Show("¿Está seguro que desea eliminar este registro?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (result == DialogResult.Yes)
					{
						try
						{
							conexion.Open();
							int rowsAffected = command.ExecuteNonQuery();
							if (rowsAffected > 0)
							{
								MessageBox.Show("Vehículo eliminado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
							else
							{
								MessageBox.Show("No se encontró ningún vehículo con el código especificado", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
							}
							return rowsAffected > 0;
						}
						catch (Exception ex)
						{
							MessageBox.Show("Error al dar de baja el vehículo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return false;
						}
					}
					else
					{
						return false;
					}
				}
			}
		}
		public bool update_register(string codigo, string tipo, string marca, string modelo, int año, string caracteristicas, string patente, string condicion, int kilometraje, decimal precio, DateTime ingreso, bool disponibilidad)
		{
			string consulta = "UPDATE Vehiculos SET tipo = @tipo, marca = @marca, modelo = @modelo, año = @año, caracteristicas = @caracteristicas, patente = @patente, condicion = @condicion, kilometraje = @kilometraje, precio = @precio, ingreso = @ingreso, disponibilidad = @disponibilidad WHERE codigo = @codigo";

			using (SqlConnection conexion = new SqlConnection(dbConnection.strConexion))
			{
				using (SqlCommand command = new SqlCommand(consulta, conexion))
				{
					command.Parameters.AddWithValue("@codigo", codigo);
					command.Parameters.AddWithValue("@tipo", tipo);
					command.Parameters.AddWithValue("@marca", marca);
					command.Parameters.AddWithValue("@modelo", modelo);
					command.Parameters.AddWithValue("@año", año);
					command.Parameters.AddWithValue("@caracteristicas", caracteristicas);
					command.Parameters.AddWithValue("@patente", patente);
					command.Parameters.AddWithValue("@condicion", condicion);
					command.Parameters.AddWithValue("@kilometraje", kilometraje);
					command.Parameters.AddWithValue("@precio", precio);
					command.Parameters.AddWithValue("@ingreso", ingreso);
					command.Parameters.AddWithValue("@disponibilidad", disponibilidad);

					DialogResult result = MessageBox.Show("¿Está seguro que desea actualizar este vehículo?", "Confirmación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

					if (result == DialogResult.Yes)
					{
						try
						{
							conexion.Open();
							int rowsAffected = command.ExecuteNonQuery();
							MessageBox.Show("Vehículo actualizado con éxito", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
							return rowsAffected > 0;
						}
						catch (Exception ex)
						{
							MessageBox.Show("Error al actualizar el vehículo: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
							return false;
						}
					}
					else
					{
						return false;
					}
				}
			}
		}
		public DataTable read_registers_down()
		{
			string consulta = "SELECT Codigo,Tipo,Marca,Modelo,Año,Caracteristicas,Patente,Condicion,Kilometraje,Precio,Ingreso FROM Vehiculos WHERE Disponibilidad = 0";
			DataTable dataTable = new DataTable();
			SqlConnection Conexion;
			SqlCommand Command;
			SqlDataReader Reader;

			try
			{
				Conexion = new SqlConnection(dbConnection.strConexion);
				Command = new SqlCommand(consulta, Conexion);

				Conexion.Open();
				Reader = Command.ExecuteReader();

				dataTable.Load(Reader);

				Conexion.Close();
				Reader.Close();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Error al leer los registros: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			return dataTable;
		}
		public string get_lastCode()
		{
			string consulta = "SELECT TOP 1 Codigo FROM Vehiculos ORDER BY Codigo DESC";
			string lastId = "";

			using (SqlConnection conexion = new SqlConnection(dbConnection.strConexion))
			{
				using (SqlCommand command = new SqlCommand(consulta, conexion))
				{
					try
					{
						conexion.Open();
						using (SqlDataReader reader = command.ExecuteReader())
						{
							if (reader.Read())
							{
								lastId = reader["Codigo"].ToString();
							}
						}
					}
					catch (Exception ex)
					{
						MessageBox.Show("Error al obtener el último código: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					}
				}
			}
			return lastId;
		}
	}
}
