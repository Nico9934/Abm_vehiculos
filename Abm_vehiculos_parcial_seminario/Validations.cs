using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Abm_vehiculos_parcial_seminario
{
	internal class Validations
	{
		public static bool Complete(object obj)
		{
			foreach (PropertyInfo property in obj.GetType().GetProperties())
			{
				var value = property.GetValue(obj);
				if (value == null)
					return false;
				if (property.PropertyType == typeof(string) && string.IsNullOrWhiteSpace(value as string))
					return false;
				if (typeof(IEnumerable<object>).IsAssignableFrom(property.PropertyType) && !((IEnumerable<object>)value).Any())
					return false;
			}
			return true;
		}
		public static bool Dni(string dni)
		{
			string patron = @"^\d{7,8}$";
			return Regex.IsMatch(dni, patron);
		}
		public static bool onlyText(string text)
		{
			string patron = @"^[a-zA-Z\s-]{1,50}$";
			return Regex.IsMatch(text, patron);
		}
		public static bool Phone(string telefono)
		{
			string patron = @"^[0-9\s\-\(\)]{7,15}$";
			return Regex.IsMatch(telefono, patron);
		}
		public static bool ValidYear(string year)
		{
			int currentYear = DateTime.Now.Year;
			int minYear = currentYear - 30;
			string pattern = @"^\d{4}$";

			if (Regex.IsMatch(year, pattern))
			{
				int yearInt;
				if (int.TryParse(year, out yearInt))
				{
					return yearInt >= minYear && yearInt <= currentYear;
				}
			}
			return false;
		}
		public static bool ValidLicensePlate(string licensePlate)
		{
			// Patrones para los distintos formatos de patentes
			string oldPattern = @"^[A-Z]{3}\s?\d{3,4}$"; // Formato viejo: AAA 123 o AAA 1234
			string newPattern = @"^[A-Z]{2}\s?\d{3}\s?[A-Z]{2}$"; // Formato nuevo: AB 123 CD
			string motoPattern1 = @"^[A-Z]{1}\s?\d{3}\s?[A-Z]{3}$"; // Formato moto 1: A 123 ABC
			string motoPattern2 = @"^\d{3}\s?[A-Z]{3}$"; // Formato moto 2: 123 ABC

			return Regex.IsMatch(licensePlate, oldPattern) ||
				   Regex.IsMatch(licensePlate, newPattern) ||
				   Regex.IsMatch(licensePlate, motoPattern1) ||
				   Regex.IsMatch(licensePlate, motoPattern2);
		}


		public static bool ValidNumericPrice(string price)
		{
			// Patrón para validar precios que contienen solo números, puntos y comas
			string pattern = @"^\d{1,3}(,\d{3})*(\.\d+)?$|^\d+(\.\d+)?$";

			return Regex.IsMatch(price, pattern);
		}
		public static bool ValidKilometrage(string kilometrage)
		{
			if (kilometrage.EndsWith(" km"))
			{
				kilometrage = kilometrage.Substring(0, kilometrage.Length - 3).Trim();
			}
			int km;
			if (int.TryParse(kilometrage, out km))
			{
				return km >= 0;
			}

			return false;
		}
		public static bool ValidEntryDate(string yearStr, string monthStr, string dayStr, string modelYearStr)
		{
			int year, month, day, modelYear;
			if (!int.TryParse(yearStr, out year) || !int.TryParse(monthStr, out month) || !int.TryParse(dayStr, out day) || !int.TryParse(modelYearStr, out modelYear))
			{
				return false;
			}

			DateTime entryDate;
			try
			{
				entryDate = new DateTime(year, month, day);
			}
			catch (ArgumentOutOfRangeException)
			{
				return false;
			}
			return year >= modelYear;
		}
		public static bool CompleteDate(string year, string month, string day)
		{
			// Verificar que los parámetros no estén vacíos
			if (string.IsNullOrEmpty(year) || string.IsNullOrEmpty(month) || string.IsNullOrEmpty(day))
			{
				return false;
			}

			// Verificar que el año tenga 4 dígitos y sea un número válido
			if (year.Length != 4 || !int.TryParse(year, out int yearInt))
			{
				return false;
			}

			// Verificar que el mes sea un número válido y esté entre 1 y 12
			if (!int.TryParse(month, out int monthInt) || monthInt < 1 || monthInt > 12)
			{
				return false;
			}

			// Verificar que el día sea un número válido y esté entre 1 y 31
			if (!int.TryParse(day, out int dayInt) || dayInt < 1 || dayInt > 31)
			{
				return false;
			}

			// Crear una fecha a partir de los valores proporcionados
			DateTime birthDate;
			try
			{
				birthDate = new DateTime(yearInt, monthInt, dayInt);
			}
			catch
			{
				return false;
			}

			// Verificar que la fecha no sea mayor a 100 años atrás
			DateTime currentDate = DateTime.Now;
			DateTime hundredYearsAgo = currentDate.AddYears(-100);

			if (birthDate < hundredYearsAgo)
			{
				return false;
			}

			return true;
		}
	}
}
