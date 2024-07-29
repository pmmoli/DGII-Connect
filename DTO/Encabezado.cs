namespace DGII_Connect;
using System.Text.Json.Serialization;
public class Encabezado
{
    public string? eNCF { get; set; }
    public string? TipoIngresos { get; set; }
    public string? IndicadorMontoGravado { get; set; }
    public string? TipoPago { get; set; }
    public string FechaVencimientoSecuencia { get; set; } = string.Empty;
    public string FechaLimitePago { get; set; } = string.Empty;
    /* public List<FormasPago>? FormasPago { get; set; }
    public string? TipoCuentaPago { get; set; }
    public string? NumeroCuentaPago { get; set; }
    public string? BancoPago { get; set; }
 */    public required Comprador Comprador { get; set; }
/*     public int TotalPaginas { get; set; }
    public InformacionesAdicionales? InformacionesAdicionales { get; set; }
    public Transporte? Transporte { get; set; }
    //[JsonConverter(typeof(NullToEmptyObjectConverter<OtraMoneda>))]
    public OtraMoneda? OtraMoneda { get; set; } */
}
