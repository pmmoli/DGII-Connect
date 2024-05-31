namespace DGII_Connect;

using System.Net.Http;
using System.Threading.Tasks;

public interface IHttpService
{
    Task<HttpResponseMessage> PostAsync(string url, string jsonContent, string authToken);
}