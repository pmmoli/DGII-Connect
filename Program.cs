namespace DGII_Connect;
using System.Text.Json;
class Program()
{
    private static CsvToDtoService _service;

    static void Main(string[] args)
    {
        _service = new CsvToDtoService();

        var encabezadoFilePath = ".\Encabezado.txt";
        Factura factura = CsvToDtoService

        string json = JsonSerializer.Serialize(transporte);
        Console.WriteLine(json);
        Console.WriteLine("Complete!");
    }
}
