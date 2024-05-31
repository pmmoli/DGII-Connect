namespace DGII_Connect;

public class DescuentosORecargos
{
    public string TipoAjuste { get; set; } = string.Empty;
    public int IndicadorNorma1007 { get; set; }
    public string? DescripcionDescuentooRecargo { get; set; } = string.Empty;
    public string TipoValor { get; set; } = "%";
    public decimal ValorDescuentooRecargo { get; set; }
    public decimal MontoDescuentooRecargo { get; set; }
    public string IndicadorFacturacionDescuentooRecargo { get; set; } = string.Empty;
}
