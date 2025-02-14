using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ControlBienes.Utils
{
	public static class BusTransformarUtils
	{
		public const string PrefijoMueble = "BM";
		public const string PrefijoVehiculo = "BV";
		public const string PrefijoInmueble = "BI";

		public const string DefaultFormatoNumeroFolioBien = "{0:D8}";
		public const string DefaultSeparadorNumero = ",";
		public const string DefaultSeparadorObjeto = "||";
		public const string DefaultSeparadorParametro = "|";
		public const string DefaultSeparadorClaveValor = ":";
		public const string DefaultLimitadorClaveValor = "'";
		public const int IndexClave = 0;
		public const int IndexValor = 1;

		public static IEnumerable<long> UObjetosToIDs(string objetos)
		{
			var idsObjeto = new List<long>();
			if (string.IsNullOrEmpty(objetos)) return idsObjeto;
			var listaObjetos = objetos.Split(DefaultSeparadorObjeto);

			foreach (var objeto in listaObjetos)
			{
				var parametrosObjeto = objeto.Split(DefaultSeparadorParametro);
				var idCadena = parametrosObjeto[IndexClave]
					.Split(DefaultSeparadorClaveValor)[IndexValor]
					.Replace(DefaultLimitadorClaveValor, string.Empty);
				
				var idObjeto = long.Parse(idCadena);
				idsObjeto.Add(idObjeto);
			}
			return idsObjeto;
		}

		public static IEnumerable<long> UStringToIDs(string idsCadena)
		{
			var ids = new List<long>();
			if (string.IsNullOrEmpty(idsCadena)) return ids;
			var listaIds = idsCadena.Split(DefaultSeparadorNumero);
			foreach (var id in listaIds)
			{
				ids.Add(long.Parse(id));
			}
			return ids;
		}

		public static string UGenerarFolioBien(string prefijo, long idBien)
		{
			return $"{prefijo}{string.Format(DefaultFormatoNumeroFolioBien, idBien)}";
		}

		public static double UCalcularImporteTotal(string articulos)
		{
			double importeTotal = 0;
			var listaArticulo = articulos.Split("||");
			foreach (var articulo in listaArticulo)
			{
				var parametros = articulo.Split("|");
				var keyCantidad = parametros[2];
				var keyPrecio = parametros[3];
				var valueCantida = keyCantidad.Split(":")[1].Trim('\'');
				var valuePrecio = keyPrecio.Split(":")[1].Trim('\'');
				var cantidad = string.IsNullOrEmpty(valueCantida) ? 0 : int.Parse(valueCantida);
				var precio = string.IsNullOrEmpty(valuePrecio) ? 0 : int.Parse(valuePrecio);
				importeTotal += (cantidad * precio);
			}
			return importeTotal;
		}
	}
}
