namespace DGII_Connect;

public class Encabezado
{
    public string? eNCF { get; set; }
    public string? TipoIngresos { get; set; }
    public string? IndicadorMontoGravado { get; set; }
    public string? TipoPago { get; set; }
    public string? TerminoPago { get; set; }
    public string? FechaLimitePago { get; set; }
    public required List<FormasPago> FormasPago { get; set; }
    public string? TipoCuentaPago { get; set; }
    public string? NumeroCuentaPago { get; set; }
    public string? BancoPago { get; set; }
    public required Comprador Comprador { get; set; }
    public int TotalPaginas { get; set; }
    public InformacionesAdicionales? InformacionesAdicionales { get; set; }
    public required Transporte Transporte { get; set; }
    public required OtraMoneda OtraMoneda { get; set; }
}
