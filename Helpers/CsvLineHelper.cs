namespace DGII_Connect;

public static class CsvLineHelper
{
    public static Comprador GetComprador(this string[] input)
    {
        // Implementation
        // This is loading empty values for now, but we should have this mocked for future implementations
        Comprador comprador = new Comprador
        {
            RNCComprador = input.Last(),
            IdentificadorExtranjero = "",
            RazonSocialComprador = "",
            ContactoComprador = "",
            CorreoComprador = "",
            DireccionComprador = "",
            MunicipioComprador = "",
            ProvinciaComprador = "",
            FechaEntrega = "",
            ContactoEntrega = "",
            DireccionEntrega = "",
            TelefonoAdicional = "",
            FechaOrdenCompra = "",
            NumeroOrdenCompra = "",
            CodigoInternoComprador = "",
            ResponsablePago = "",
            InformacionAdicionalComprador = ""
        };

        return comprador;

    }

    public static Transporte GetTransporte(this string[] input)
    {
        Transporte transporte = new Transporte
        {
            Conductor = "",
            DocumentoTransporte = "",
            Ficha = "",
            Placa = "",
            RutaTransporte = "",
            ZonaTransporte = "",
            NumeroAlbaran = ""
        };

        return transporte;
    }
}
