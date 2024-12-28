namespace ControlBienes.Entities.Catalogos.CaracteristicaBien
{
    public class EntCaracteristicaBienRequest
    {
        public long? IdFamilia { get; set; } = 0;
        public long? IdSubfamilia { get; set; } = 0;
        public string Etiqueta { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
    }
}
