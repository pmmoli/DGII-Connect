﻿namespace DGII_Connect;

public class Factura
{
    public DateTime Fecha { get; set; }
    // public string? NumeroFacturaInterna { get; set; }
    // public string? Sucursal { get; set; }
    // public string? CodigoVendedor { get; set; }
    public required Encabezado Encabezado { get; set; }
    public required List<DetalleBienesOServicios> DetalleBienesOServicios { get; set; }
    // public string? DescuentosORecargos { get; set; }
    // //public List<DescuentosORecargos>? DescuentosORecargos { get; set; }
    // public InformacionReferencia? InformacionReferencia { get; set; }
    // public string Atributo1 { get; set; } = string.Empty;
    // public string Atributo2 { get; set; } = string.Empty;
    // public string Atributo3 { get; set; } = string.Empty;
    // public string Atributo4 { get; set; } = string.Empty;
    // public string Atributo5 { get; set; } = string.Empty;
}
