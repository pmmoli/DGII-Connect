namespace DGII_Connect;
using System.Text.Json;
class Program()
{
    private static CsvToDtoService? _service;

    static void Main(string[] args)
    {
        _service = new CsvToDtoService();
        
        string encabezadoFilePath = @".\Encabezado.txt";
        string DetalleFilePath = @".\Encabezado.txt";
        Factura factura = _service.LoadCsv(encabezadoFilePath, DetalleFilePath);

        string json = JsonSerializer.Serialize(factura);
        Console.WriteLine(json);
        Console.WriteLine("Complete!");
    }
}
