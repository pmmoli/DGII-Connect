namespace DGII_Connect;
using System.Text.Json;
class Program
{
    static void Main(string[] args)
    {
        Transporte transporte = new Transporte()
        {
            Conductor = "John Doe",
            DocumentoTransporte = "123456",
            Ficha = "789",
            Placa = "ABC123",
            RutaTransporte = "Route 66",
            ZonaTransporte = "Zone A",
            NumeroAlbaran = "987654"
        };

        string json = JsonSerializer.Serialize(transporte);
        Console.WriteLine(json);
        Console.WriteLine("Complete!");
    }
}
