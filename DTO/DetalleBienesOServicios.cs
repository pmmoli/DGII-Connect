namespace DGII_Connect;

public class DetalleBienesOServicios
{
    public decimal CantidadItem { get; set; }
    public decimal CantidadReferencia { get; set; }
    public List<CodigosItem>? CodigosItem { get; set; }
    public string? DescripcionItem { get; set; }
    public decimal DescuentoMonto { get; set; }
    public DateTime FechaElaboracion { get; set; }
    public DateTime FechaVencimientoItem { get; set; }
    public decimal GradosAlcohol { get; set; }
    public string? IndicadorBienoServicio { get; set; }
    public string? IndicadorFacturacion { get; set; }
    public List<ImpuestoAdicional>? ImpuestoAdicional { get; set; }
    public Mineria? Mineria { get; set; }
    public string? NombreItem { get; set; }
    public decimal PrecioUnitarioItem { get; set; }
    public decimal PrecioUnitarioReferencia { get; set; }
    public decimal RecargoMonto { get; set; }
    public List<SubCantidad>? SubCantidad { get; set; }
    public List<SubDescuento>? SubDescuento { get; set; }
    public List<Subrecargo>? Subrecargo { get; set; }
    public int UnidadMedida { get; set; }
    public string? UnidadReferencia { get; set; }
}
