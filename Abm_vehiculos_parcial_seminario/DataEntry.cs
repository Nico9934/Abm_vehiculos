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
	public partial class D : Form
	{
		public delegate void RecordCreatedEventHandler(object sender, EventArgs e);
		public event RecordCreatedEventHandler RecordCreated;
		private bool isEditMode;

		public D(bool isEditMode = false)
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
			ClearErrors();
			bool hasErrors = !ValidateFields();

			if (hasErrors) return;

			Queries queries = new Queries();
			Vehiculo newVehicle = new Vehiculo();
			string newCodigo = Functions.generate_newCode();

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
		private bool ValidateFields()
		{
			bool isValid = true;

			if (!Validations.onlyText(txb_type.Text))
			{
				error_type.SetError(txb_type, "Este campo solo permite letras");
				isValid = false;
			}
			if (!Validations.onlyText(txb_brand.Text))
			{
				error_brand.SetError(txb_brand, "Este campo solo permite letras");
				isValid = false;
			}
			if (!Validations.onlyText(txb_model.Text))
			{
				error_model.SetError(txb_model, "Este campo solo permite letras");
				isValid = false;
			}
			if (!Validations.ValidYear(txb_year.Text))
			{
				error_year.SetError(txb_year, "Debes ingresar un Año válido. A partir del 1990");
				isValid = false;
			}
			if (!Validations.ValidLicensePlate(txb_patent.Text))
			{
				error_patent.SetError(txb_patent, "Debes ingresar una patente válida");
				isValid = false;
			}
			if (!Validations.ValidNumericPrice(txb_price.Text))
			{
				error_price.SetError(txb_price, "Debes ingresar un precio válido, con comas al final y decimales. Ej.: 12000,00");
				isValid = false;
			}
			if (!Validations.ValidKilometrage(txb_kilometers.Text))
			{
				error_kilometers.SetError(txb_kilometers, "Debes ingresar kilometros");
				isValid = false;
			}
			else if (!Validations.ValidKilometrageCondition(txb_kilometers.Text, rb_new.Checked))
			{
				if (rb_new.Checked)
				{
					error_kilometers.SetError(txb_kilometers, "No puedes ingresar un auto nuevo con kilometros");
				}
				else if (rb_used.Checked)
				{
					error_kilometers.SetError(txb_kilometers, "No puedes ingresar un auto usado con 0 kilometros");
				}
				isValid = false;
			}
			if (!Validations.ValidEntryDate(txb_in_year.Text, txb_in_month.Text, txb_in_day.Text, txb_year.Text))
			{
				error_in_year.SetError(txb_in_year, "Debes ingresar una fecha de ingreso válida");
				isValid = false;
			}
			return isValid;
		}
		private void ClearErrors()
		{
			error_type.Clear();
			error_brand.Clear();
			error_model.Clear();
			error_year.Clear();
			error_patent.Clear();
			error_price.Clear();
			error_kilometers.Clear();
			error_in_year.Clear();
		}
		
	}
}
