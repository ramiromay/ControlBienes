namespace ControlBienes.Business.Exceptions
{
    public class BusRecursoNoEncontradoException : Exception
    {
        public string Mensaje { get; set; }

        public BusRecursoNoEncontradoException(string mensaje) : base(mensaje)
        {
            this.Mensaje = mensaje;
        }

    }
}
