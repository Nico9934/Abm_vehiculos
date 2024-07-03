using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abm_vehiculos_parcial_seminario
{
	public partial class Form_principal : Form
	{
		public Form_principal()
		{
			InitializeComponent();
		}

		private void form_principal_Load(object sender, EventArgs e)
		{

		}
		private void OnRecordCreated(object sender, EventArgs e)
		{
			LoadData();
		}
		private void LoadData()
		{
			try
			{
				Queries queries = new Queries();
				dgv_data.DataSource = queries.read_registers();
				dgv_data.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgv_data_RowPostPaint);
				dgv_data.ClearSelection();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		private void btn_getDataVehicles_Click(object sender, EventArgs e)
		{
			LoadData();
		}	
		private void btn_newVehicle_Click(object sender, EventArgs e)
		{
			Functions.clean_fields();
			dgv_data.ClearSelection();
			DataEntry formData = new DataEntry();
			formData.RecordCreated += new DataEntry.RecordCreatedEventHandler(this.OnRecordCreated);
			formData.ShowDialog();
		}
		private void btn_unsubscribeVehicle_Click(object sender, EventArgs e)
		{

			if (dgv_data.SelectedRows.Count == 0)
			{
				MessageBox.Show("Debes seleccionar un vehiculo", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				try
				{

					Queries queries = new Queries();
					bool response = queries.logic_down_register(Variables.selectedVehicle.codigo);

					if (response)
					{
						dgv_data.ClearSelection();
						LoadData(); //
					}
				}
				catch (Exception ex)
				{
					MessageBox.Show("Ha ocurrido un error: " + ex.Message);
					System.Media.SystemSounds.Hand.Play();
				}
			}
		}
		private void btn_updateVehicle_Click(object sender, EventArgs e)
		{
			if (dgv_data.SelectedRows.Count == 0)
			{
				MessageBox.Show("Debes seleccionar un vehiculo", "Oops...", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
			else
			{
				DataEntry formData = new DataEntry(true);
				formData.RecordCreated += new DataEntry.RecordCreatedEventHandler(this.OnRecordCreated);
				formData.ShowDialog();
			}
		}
		private void row_selectionChanged(object sender, EventArgs e)
		{
			if (dgv_data.SelectedRows.Count > 0)
			{
				DataGridViewRow selectedRow = dgv_data.SelectedRows[0];
				string in_date = selectedRow.Cells["Ingreso"].Value.ToString();

				DateTime ingresoDate = DateTime.Parse(in_date);

				Variables.selectedVehicle.codigo = selectedRow.Cells["Codigo"].Value.ToString();
				Variables.selectedVehicle.tipo = selectedRow.Cells["Tipo"].Value.ToString();
				Variables.selectedVehicle.marca = selectedRow.Cells["Marca"].Value.ToString();
				Variables.selectedVehicle.modelo = selectedRow.Cells["Modelo"].Value.ToString();
				Variables.selectedVehicle.año = Convert.ToInt32(selectedRow.Cells["año"].Value);
				Variables.selectedVehicle.caracteristicas = selectedRow.Cells["Caracteristicas"].Value.ToString();
				Variables.selectedVehicle.patente = selectedRow.Cells["Patente"].Value.ToString();
				Variables.selectedVehicle.condicion = selectedRow.Cells["Condicion"].Value.ToString();
				Variables.selectedVehicle.kilometraje = Convert.ToInt32(selectedRow.Cells["Kilometraje"].Value);
				Variables.selectedVehicle.precio = Convert.ToDecimal(selectedRow.Cells["precio"].Value);

				Variables.selectedVehicle.ingreso = ingresoDate;
				Variables.selectedVehicle.disponibilidad = true;

				Variables.selectedVehicle.dia_ingreso = ingresoDate.Day.ToString();
				Variables.selectedVehicle.mes_ingreso = ingresoDate.Month.ToString();
				Variables.selectedVehicle.año_ingreso = ingresoDate.Year.ToString();
			}
			//if (dgv_data.SelectedRows.Count > 0)
			//{
			//	DataGridViewRow selectedRow = dgv_data.SelectedRows[0];
			//	string in_date = selectedRow.Cells["Ingreso"].Value.ToString();

			//	string day = inYear.day;
			//	string month = inYear.month;
			//	string year = inYear.Year

			//	Variables.selectedVehicle.codigo = selectedRow.Cells["Codigo"].Value.ToString();
			//	Variables.selectedVehicle.tipo = selectedRow.Cells["Tipo"].Value.ToString();
			//	Variables.selectedVehicle.marca = selectedRow.Cells["Marca"].Value.ToString();
			//	Variables.selectedVehicle.modelo = selectedRow.Cells["Modelo"].Value.ToString();
			//	Variables.selectedVehicle.año = Convert.ToInt32(selectedRow.Cells["año"].Value);
			//	Variables.selectedVehicle.caracteristicas = selectedRow.Cells["Caracteristicas"].Value.ToString();
			//	Variables.selectedVehicle.patente = selectedRow.Cells["Patente"].Value.ToString();
			//	Variables.selectedVehicle.condicion = selectedRow.Cells["Condicion"].Value.ToString();
			//	Variables.selectedVehicle.kilometraje = Convert.ToInt32(selectedRow.Cells["Kilometraje"].Value);
			//	Variables.selectedVehicle.precio = Convert.ToDecimal(selectedRow.Cells["precio"].Value);

			//	Variables.selectedVehicle.ingreso = DateTime.Parse(in_date);
			//	Variables.selectedVehicle.disponibilidad = true;
			//}


			//if (dgv_data.SelectedRows.Count > 0)
			//{
			//	DataGridViewRow selectedRow = dgv_data.SelectedRows[0];
			//	string birthdayString = selectedRow.Cells["FechNac"].Value.ToString();

			//	Variables.selectedClient.dni = Convert.ToInt32(selectedRow.Cells["dni"].Value);
			//	Variables.selectedClient.firstName = selectedRow.Cells["Nombre"].Value.ToString();
			//	Variables.selectedClient.lastName = selectedRow.Cells["Apellido"].Value.ToString();
			//	Variables.selectedClient.phone = selectedRow.Cells["Telefono"].Value.ToString();
			//	Variables.selectedClient.adress = selectedRow.Cells["Direccion"].Value.ToString();

			//	// Asegurarse de convertir correctamente el string a DateTime
			//	Variables.selectedClient.birthday = DateTime.Parse(birthdayString);

			//	// Verificar si birthday tiene valor y extraer año, mes y día
			//	if (Variables.selectedClient.birthday.HasValue)
			//	{
			//		DateTime birthday = Variables.selectedClient.birthday.Value;
			//		int year = birthday.Year;
			//		int month = birthday.Month;
			//		int day = birthday.Day;

			//		// Asignar los valores a las variables correspondientes
			//		Variables.selectedClient.year = year.ToString();
			//		Variables.selectedClient.month = month.ToString();
			//		Variables.selectedClient.day = day.ToString();
			//	}
			//	else
			//	{
			//		// Manejar el caso cuando birthday no tiene valor
			//		Variables.selectedClient.year = null;
			//		Variables.selectedClient.month = null;
			//		Variables.selectedClient.day = null;
			//	}
			//}
		}
		private void dgv_data_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
		{
			using (Pen pen = new Pen(Color.FromArgb(175, 35, 79)))
			{
				int rowIndex = e.RowIndex;
				DataGridViewRow row = dgv_data.Rows[rowIndex];
				Rectangle rowBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, e.RowBounds.Width, e.RowBounds.Height);

				e.Graphics.DrawLine(pen, rowBounds.Left, rowBounds.Bottom - 1, rowBounds.Right, rowBounds.Bottom - 1);
			}
		}
		private void dgv_data_CellMouseEnter(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				dgv_data.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(175, 35, 79);
			}
		}
		private void dgv_data_CellMouseLeave(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex >= 0)
			{
				dgv_data.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(105, 35, 79);
			}
		}

		private void btn_MouseEnter(object sender, EventArgs e)
		{
			// Cambiar el color de fondo del botón al pasar el ratón por encima
			Button button = sender as Button;
			if (button != null)
			{
				button.BackColor = Color.FromArgb(175, 35, 79);
			}
		}

		private void btn_MouseLeave(object sender, EventArgs e)
		{
			// Restaurar el color de fondo original del botón al retirar el ratón
			Button button = sender as Button;
			if (button != null)
			{
				button.BackColor = Color.FromArgb(101, 32, 71);
			}
		}

		private void btn_vehicles_down_Click(object sender, EventArgs e)
		{
			try
			{
				Queries queries = new Queries();
				dgv_data.DataSource = queries.read_registers_down();
				dgv_data.RowPostPaint += new DataGridViewRowPostPaintEventHandler(dgv_data_RowPostPaint);
				dgv_data.ClearSelection();
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido un error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}
