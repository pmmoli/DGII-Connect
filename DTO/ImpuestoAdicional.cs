using System.Data.SqlTypes;

namespace DGII_Connect;

public class ImpuestoAdicional
{
    public string TipoImpuesto { get; set; } = string.Empty;
    public decimal MontoImpuestoAdicional { get; set; } = 0;
    public decimal TasaImpuestoAdicional { get; set; } = 0;
}
