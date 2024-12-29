using FluentValidation.Results;

namespace ControlBienes.Utils
{
    public class BusConvertirErrors
    {
        public static string UFormatearTexto(List<ValidationFailure> errores)
        {
            string resultado = "";
            foreach (var error in errores)
            {
                resultado += $"{error.ErrorMessage},";
            }

            if (errores.Count > 0)
                resultado = URemoverComillaFinal(resultado);

            return resultado;
        }

        public static string URemoverComillaFinal(string errores)
        {
            if (string.IsNullOrEmpty(errores)) return string.Empty;
            string resultado = errores;
            string ultimooCaracter = errores.Substring(errores.Length - 1);

            if (ultimooCaracter.Equals(",", StringComparison.OrdinalIgnoreCase))
                resultado = resultado.Remove(resultado.Length - 1);

            return resultado;
        }

    }
}
