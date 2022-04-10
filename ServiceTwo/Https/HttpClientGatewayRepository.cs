using GatewayLibrary;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ServiceTwo.Https
{
    public class HttpClientGatewayRepository : IHttpClientGatewaySerrvice
    {
        private readonly HttpClient _client;
        public HttpClientGatewayRepository(HttpClient client)
        {
            _client = client;
        }
        public async Task DestroyService()
        {
            var response = await _client.DeleteAsync("/api/initial?serviceName=URBOX");
            response.EnsureSuccessStatusCode();
        }

        public async Task RegisterService()
        {
            var service = new ServiceInfo() { ServiceName = "URBOX",ServiceUrl = "https://localhost:4004" };
            string payload = JsonConvert.SerializeObject(service, Formatting.Indented);
            var content = new StringContent(payload, Encoding.UTF8, "application/json");
            var response = await _client.PostAsync("/api/initial", content);
            response.EnsureSuccessStatusCode();
        }
    }
}
