namespace ControlBienes.Entities.Catalogos.Subfamilia
{
    public class EntSubfamiliaRequest
    {
        public long IdSubfamilia { get; set; } = 0;
        public long IdFamilia { get; set; } = 0;
        public string Nombre { get; set; } = string.Empty;
        public string Descripcion { get; set; } = string.Empty;
        public double ValorRecuperable { get; set; } = 0;
    }
}
