using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Abm_vehiculos_parcial_seminario
{
	public class Functions
	{
		public static void clean_fields()
		{
			//Variables.selectedVehicle.dni = null;
			//Variables.selectedVehicle.firstName = null;
			//Variables.selectedVehicle.lastName = null;
			//Variables.selectedVehicle.adress = null;
			//Variables.selectedVehicle.phone = null;
			//Variables.selectedVehicle.birthday = null;
		}

		public static string generate_newCode()
		{
			Queries queries = new Queries();
			string ultimoCodigo = queries.get_lastCode();
		

			int siguienteCodigo = 0;
			if (!string.IsNullOrEmpty(ultimoCodigo) && int.TryParse(ultimoCodigo, out int codigoActual))
			{
				siguienteCodigo = codigoActual + 1;
			}
			else
			{
				siguienteCodigo = 1;
			}
			return siguienteCodigo.ToString().PadLeft(4, '0');
		}

	}
}
