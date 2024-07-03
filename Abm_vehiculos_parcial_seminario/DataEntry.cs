using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abm_vehiculos_parcial_seminario
{
	public partial class DataEntry : Form
	{
		public delegate void RecordCreatedEventHandler(object sender, EventArgs e);
		public event RecordCreatedEventHandler RecordCreated;
		private bool isEditMode;

		public DataEntry(bool isEditMode = false)
		{
			InitializeComponent();
			this.isEditMode = isEditMode;
		}
		private void DataEntry_Load(object sender, EventArgs e)
		{
			if (isEditMode)
			{
				btn_submit_data.Text = "Guardar cambios";
				btn_submit_data.BackColor = Color.FromArgb(170, 149, 237);

				txb_type.Text = Variables.selectedVehicle.tipo;
				txb_brand.Text = Variables.selectedVehicle.marca;
				txb_model.Text = Variables.selectedVehicle.modelo;
				txb_year.Text = Variables.selectedVehicle.año.ToString();
				txb_characteristics.Text = Variables.selectedVehicle.caracteristicas;
				txb_patent.Text = Variables.selectedVehicle.patente;
				rb_new.Checked = (Variables.selectedVehicle.condicion == "Nuevo");
				rb_used.Checked = (Variables.selectedVehicle.condicion != "Nuevo");
				txb_price.Text = Variables.selectedVehicle.precio.ToString();
				txb_kilometers.Text = Variables.selectedVehicle.kilometraje.ToString();
				txb_in_day.Text = Variables.selectedVehicle.dia_ingreso;
				txb_in_month.Text = Variables.selectedVehicle.mes_ingreso;
				txb_in_year.Text = Variables.selectedVehicle.año_ingreso;
			}
		}
		private void btn_submit_data_Click(object sender, EventArgs e)
		{
			Queries queries = new Queries();
			Vehiculo newVehicle = new Vehiculo();
			string newCodigo = Functions.generate_newCode();

			bool hasErrors = false;

			if (!Validations.onlyText(txb_type.Text))
			{
				error_type.SetError(txb_type, "Debes ingresar un Tipo válido");
				hasErrors = true;
			}
			if (!Validations.onlyText(txb_brand.Text))
			{
				error_type.SetError(txb_brand, "Debes ingresar una marca válida");
				hasErrors = true;
			}
			if (!Validations.onlyText(txb_model.Text))
			{
				error_type.SetError(txb_model, "Debes ingresar un modelo válido");
				hasErrors = true;
			}
			if (!Validations.ValidYear(txb_year.Text))
			{
				error_type.SetError(txb_year, "Debes ingresar un Año válido");
				hasErrors = true;
			}
			if (!Validations.ValidLicensePlate(txb_patent.Text))
			{
				error_type.SetError(txb_patent, "Debes ingresar una patente válida");
				hasErrors = true;
			}
			if (!Validations.ValidNumericPrice(txb_price.Text))
			{
				error_type.SetError(txb_price, "Debes ingresar un precio válido");
				hasErrors = true;
			}
			if (!Validations.ValidKilometrage(txb_kilometers.Text))
			{
				error_type.SetError(txb_kilometers, "Debes ingresar kilometros");
				hasErrors = true;
			}
			if (!Validations.ValidEntryDate(txb_in_year.Text, txb_in_month.Text, txb_in_day.Text, txb_year.Text))
			{
				error_type.SetError(txb_in_year, "Debes ingresar una fecha de ingreso válida");
				hasErrors = true;
			}

			if (hasErrors) return;

			newVehicle.codigo = newCodigo;
			newVehicle.tipo = txb_type.Text;
			newVehicle.marca = txb_brand.Text;
			newVehicle.modelo = txb_model.Text;
			newVehicle.año = Convert.ToInt32(txb_year.Text);
			newVehicle.caracteristicas = txb_characteristics.Text;
			newVehicle.patente = txb_patent.Text;
			newVehicle.condicion = rb_new.Checked ? rb_new.Text : rb_used.Text;
			newVehicle.kilometraje = Convert.ToInt32(txb_kilometers.Text);
			newVehicle.precio = Convert.ToDecimal(txb_price.Text);

			int year = Convert.ToInt32(txb_in_year.Text);
			int month = Convert.ToInt32(txb_in_month.Text);
			int day = Convert.ToInt32(txb_in_day.Text);

			newVehicle.ingreso = new DateTime(year, month, day);
			newVehicle.disponibilidad = true;

			try
			{
				bool response;

				if (isEditMode)
				{
					response = queries.update_register(
						Variables.selectedVehicle.codigo,
						newVehicle.tipo,
						newVehicle.marca,
						newVehicle.modelo,
						newVehicle.año,
						newVehicle.caracteristicas,
						newVehicle.patente,
						newVehicle.condicion,
						newVehicle.kilometraje,
						newVehicle.precio,
						newVehicle.ingreso,
						newVehicle.disponibilidad
					);
				}
				else
				{
					response = queries.create_register(
						newVehicle.codigo,
						newVehicle.tipo,
						newVehicle.marca,
						newVehicle.modelo,
						newVehicle.año,
						newVehicle.caracteristicas,
						newVehicle.patente,
						newVehicle.condicion,
						newVehicle.kilometraje,
						newVehicle.precio,
						newVehicle.ingreso,
						newVehicle.disponibilidad
					);
				}

				if (response)
				{
					RecordCreated?.Invoke(this, EventArgs.Empty);
					this.Close();
				}
			}
			catch (Exception ex)
			{
				MessageBox.Show("Ha ocurrido un error: " + ex.Message);
			}
		}
		private void radioButton_CheckedChanged(object sender, EventArgs e)
		{
			if (rb_new.Checked)
			{
			}
			else if (rb_used.Checked)
			{
			}
		}
	}
}