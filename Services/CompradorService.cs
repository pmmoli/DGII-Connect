namespace DGII_Connect;

public class CompradorService : ICompradorService
{
    public Comprador GetComprador(string rnc, string razonSocial)
    {
        // Implementation
        // This is loading empty values for now, but we should have this mocked for future implementations
        Comprador comprador = new()
        {
            RNCComprador = rnc,
            IdentificadorExtranjero = razonSocial,
            RazonSocialComprador = string.Empty,
            ContactoComprador = string.Empty,
            CorreoComprador = string.Empty,
            DireccionComprador = string.Empty,
            MunicipioComprador = string.Empty,
            ProvinciaComprador = string.Empty,
            FechaEntrega = DateTime.Today.ToString(),
            ContactoEntrega = string.Empty,
            DireccionEntrega = string.Empty,
            TelefonoAdicional = string.Empty,
            FechaOrdenCompra = string.Empty,
            NumeroOrdenCompra = string.Empty,
            CodigoInternoComprador = string.Empty,
            ResponsablePago = string.Empty,
            InformacionAdicionalComprador = string.Empty
        };

        return comprador;

    }
}
