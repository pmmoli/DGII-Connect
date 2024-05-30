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
            RazonSocialComprador = razonSocial,
            ContactoComprador = "",
            CorreoComprador = "",
            DireccionComprador = "",
            MunicipioComprador = "",
            ProvinciaComprador = "",
            CodigoInternoComprador = "",
            ResponsablePago = "",
            InformacionAdicionalComprador = ""
        };

        return comprador;

    }
}
