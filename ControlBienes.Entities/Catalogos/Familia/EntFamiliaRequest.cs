namespace ControlBienes.Entities.Catalogos.Familia
{
    public class EntFamiliaRequest
    {
        public long IdFamilia { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public long IdTipoBien { get; set; } = 0;
    }
}
