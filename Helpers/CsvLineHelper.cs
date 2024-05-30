namespace DGII_Connect;

public static class CsvLineHelper
{


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
