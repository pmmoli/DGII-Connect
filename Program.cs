namespace DGII_Connect
{
    using System;
    using System.Text.Json;
    
    class Program
    {
        private static CsvToDtoService? _service;

        static void Main(string[] args)
        {
            ICompradorService compradorService = new CompradorService();
            _service = new CsvToDtoService(compradorService);
            
            string encabezadoFilePath = @".\Encabezado.txt";
            string detalleFilePath = @".\Detalle.txt";
            Factura factura = _service.LoadCsv(encabezadoFilePath, detalleFilePath);

            string json = JsonSerializer.Serialize(factura);
            Console.WriteLine(json);

            // Post JSON data to RESTful API
            PostJsonToApi(json);

            Console.WriteLine("Complete!");
        }

static void PostJsonToApi(string json)
{
    // URL of the RESTful API endpoint
    string apiUrl = "https://test.ecf.citrus.com.do/api/v1/FacturaConsumo";

    // Authorization token (if required)
    string authToken = "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJFeHBpcmEiOmZhbHNlLCJGZWNoYUV4cGlyYWNpb24iOm51bGwsIkZlY2hhQ3JlYWNpb24iOiIyMDI0LTA1LTMwVDE5OjI4OjM3Ljg5NTE5NDMtMDQ6MDAiLCJVc3VhcmlvQXNvY2lhZG8iOiJ0ZXN0ZGdpaSIsIkNvbXBhbmlhSWQiOjIyMTB9.EcvDegKaVRumQaMMZj1YJon5Dek08nF5gSh-cr0GnUFrH1OMI-_v2TNNkEYTXDJ7plICSjpWzGsBKFVqCbdJVQ";

    // Instantiate the HTTP service
    HttpService httpService = new();

    try
    {
        // Make a POST request to the API endpoint
        HttpResponseMessage response = httpService.PostAsync(apiUrl, json, authToken).Result;

        // Check if the request was successful
        if (response.IsSuccessStatusCode)
        {
            Console.WriteLine("POST request successful!");
        }
        else
        {
            Console.WriteLine($"POST request failed with status code {response.StatusCode}");
            Console.WriteLine($"POST request failed with status code {response.RequestMessage.ToString()}");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}

    }
}
