namespace DGII_Connect;

public class InformacionesAdicionales
{
    public DateTime FechaEmbarque { get; set; }
    public string? NumeroEmbarque { get; set; }
    public string? NumeroContenedor { get; set; }
    public string? NumeroReferencia { get; set; }
    public string? NombrePuertoEmbarque { get; set; }
    public decimal PesoBruto { get; set; }
    public decimal PesoNeto { get; set; }
    public int UnidadPesoBruto { get; set; }
    public int UnidadPesoNeto { get; set; }
    public int CantidadBulto { get; set; }
    public int UnidadBulto { get; set; }
    public decimal VolumenBulto { get; set; }
    public int UnidadVolumen { get; set; }
}
