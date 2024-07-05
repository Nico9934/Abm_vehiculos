using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abm_vehiculos_parcial_seminario
{
	public class DBConnection
	{
		//public string strConexionParcial = "Data Source = NOTEBOOK_NICO; Initial Catalog = Concesionaria_DB; Integrated Security = True;";
		public string strConexion = "Data Source = NOTEBOOK_NICO; Initial Catalog = Concesionaria_parcial; Integrated Security = True;";

		static SqlConnection Conexion;

		public void Conectar()
		{
			try
			{
				Conexion = new SqlConnection(strConexion);
				Conexion.Open();
				MessageBox.Show("Exito");
			}
			catch (Exception e)
			{
				MessageBox.Show("Ha ocurrido un error: " + e.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}

		public void Desconectar()
		{
			if (Conexion != null && Conexion.State == ConnectionState.Open)
				Conexion.Close();
		}

	}
}
