namespace ControlBienes.Entities.General.Cuenta
{
    public class EntCuentaResponse
    {
        public long? IdCuenta { get; set; }
        public string? Nombre { get; set; }
        public string? Clave { get; set; }
        public int? Nivel { get; set; }
        public string? NivelCompleto { get; set; }
    }
}
