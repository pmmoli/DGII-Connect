namespace DGII_Connect;

public class InformacionesAdicionales
{
    public DateTime FechaEmbarque { get; set; } = DateTime.Today;
    public string NumeroEmbarque { get; set; } = string.Empty;
    public string NumeroContenedor { get; set; } = string.Empty;
    public string NumeroReferencia { get; set; } = string.Empty;
    public string NombrePuertoEmbarque { get; set; } = string.Empty;
    public decimal PesoBruto { get; set; } = 0;
    public decimal PesoNeto { get; set; } = 0;
    public int UnidadPesoBruto { get; set; } = 0;
    public int UnidadPesoNeto { get; set; } = 0;
    public int CantidadBulto { get; set; } = 0;
    public int UnidadBulto { get; set; } = 0;
    public decimal VolumenBulto { get; set; } = 0;
    public int UnidadVolumen { get; set; } = 0;
}
