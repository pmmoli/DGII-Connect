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
      string AprobadoFilePath = @".\APROBADO.txt";
      
      Logger.LogInfo("START");
      if (File.Exists(AprobadoFilePath))
      {
        File.Delete(AprobadoFilePath);
      }
      Factura factura = _service.LoadCsv(encabezadoFilePath, detalleFilePath);

      var options = new JsonSerializerOptions { WriteIndented = true };
      string json = JsonSerializer.Serialize(factura, options);
      Console.WriteLine(json);
      Logger.LogInfo(json);

      switch (factura.Encabezado.TipoeCF)
      {
        case "31":
          PostJsonToApi(json, "https://test.ecf.citrus.com.do/api/v1/Facturas");
          break;
        case "32":
          PostJsonToApi(json, "https://test.ecf.citrus.com.do/api/v1/FacturaConsumo");
          break;
        default:
          break;
      }
      // Post JSON data to RESTful API


      Console.WriteLine("Complete!");
    }

    static void PostJsonToApi(string json, string endpointFactura)
    {
      // URL of the RESTful API endpoint
      string apiUrl = endpointFactura;
      string responseText;

      // Authorization token (if required)
      string authToken =
          "eyJ0eXAiOiJKV1QiLCJhbGciOiJIUzUxMiJ9.eyJFeHBpcmEiOmZhbHNlLCJGZWNoYUV4cGlyYWNpb24iOm51bGwsIkZlY2hhQ3JlYWNpb24iOiIyMDI0LTA1LTMwVDE5OjI4OjM3Ljg5NTE5NDMtMDQ6MDAiLCJVc3VhcmlvQXNvY2lhZG8iOiJ0ZXN0ZGdpaSIsIkNvbXBhbmlhSWQiOjIyMTB9.EcvDegKaVRumQaMMZj1YJon5Dek08nF5gSh-cr0GnUFrH1OMI-_v2TNNkEYTXDJ7plICSjpWzGsBKFVqCbdJVQ";

      // Instantiate the HTTP service
      HttpService httpService = new();

      try
      {
        // Make a POST request to the API endpoint
        HttpResponseMessage response =
            httpService.PostAsync(apiUrl, json, authToken).Result;

        // Check if the request was successful
        if (response.IsSuccessStatusCode)
        {
          Console.WriteLine("POST request successful!");
          Logger.LogInfo($"SUCCESS {response.ReasonPhrase}");
          responseText = response.Content.ReadAsStringAsync().Result;
          CreateConfirmation(responseText);
        }
        else
        {
          Console.WriteLine(
              $"POST request failed with status code {response.StatusCode}");
          Console.WriteLine(
              $"POST request failed with status code {response.RequestMessage}");
          Logger.LogInfo($"FAILURE {response.StatusCode} - {response.ReasonPhrase} - {response.Content.ReadAsStringAsync().Result}");
        }
      }
      catch (Exception ex)
      {
        Console.WriteLine($"An error occurred: {ex.Message}");
      }
    }
    static void CreateConfirmation(string response)
    {
      string resultPath = @"./APROBADO.txt";
      CitrusApiResponse? apiResponse = JsonSerializer.Deserialize<CitrusApiResponse>(response);

      if (apiResponse == null)
      {
        Console.WriteLine("Deserialization failed: apiResponse is null.");
        return;
      }

      File.WriteAllText(resultPath, $"{apiResponse.eNCF}|{apiResponse.UrlCodigoQr}|{apiResponse.CodigoSeguridad}");
      Logger.LogInfo(response);
    }
  }
}