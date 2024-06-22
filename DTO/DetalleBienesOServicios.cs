namespace DGII_Connect;
using System.Text.Json.Serialization;

public class DetalleBienesOServicios
{
    public decimal CantidadItem { get; set; }
    // public decimal CantidadReferencia { get; set; }
    // public List<CodigosItem>? CodigosItem { get; set; }
    // public string? DescripcionItem { get; set; }
    public decimal DescuentoMonto { get; set; }
    // public DateTime FechaElaboracion { get; set; }
    // public DateTime FechaVencimientoItem { get; set; }
    // public decimal GradosAlcohol { get; set; }
    public string? IndicadorBienoServicio { get; set; }
    public string? IndicadorFacturacion { get; set; }
    // public string? ImpuestoAdicional { get; set; }
    //public List<ImpuestoAdicional>? ImpuestoAdicional { get; set; }
    // public Mineria? Mineria { get; set; }
    public string? NombreItem { get; set; }
    public decimal PrecioUnitarioItem { get; set; }
    public decimal PrecioUnitarioReferencia { get; set; }
    // public decimal RecargoMonto { get; set; }
    // public string? SubCantidad { get; set; }
    // public string? SubDescuento { get; set; }
    // public string? Subrecargo { get; set; }

    //public List<SubCantidad>? SubCantidad { get; set; }
    //[JsonConverter(typeof(NullToEmptyObjectListConverter<SubDescuento>))]
    //public List<SubDescuento>? SubDescuento { get; set; }
    //[JsonConverter(typeof(NullToEmptyObjectListConverter<Subrecargo>))]
    //public List<Subrecargo>? Subrecargo { get; set; }
    // public int UnidadMedida { get; set; }
    // public string? UnidadReferencia { get; set; }
}
