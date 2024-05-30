namespace DGII_Connect;

public class Comprador
{
    public required string RNCComprador { get; set; }
    public required string RazonSocialComprador { get; set; }
    public string? ContactoComprador { get; set; }
    public string? CorreoComprador { get; set; }
    public string? DireccionComprador { get; set; }
    public string? MunicipioComprador { get; set; }
    public string? ProvinciaComprador { get; set; }
    public string? CodigoInternoComprador { get; set; }
    public string? ResponsablePago { get; set; }
    public string? InformacionAdicionalComprador { get; set; }
}
