namespace ControlBienes.Business.Exceptions
{
    public class BusRequestException : Exception
    {

        public string Errores { get; set; }
        public BusRequestException(string mensaje, string errores) : base(mensaje)
        {
            Errores = errores;
        }

    }
}
