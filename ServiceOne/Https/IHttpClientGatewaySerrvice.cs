using System.Threading.Tasks;

namespace ServiceOne.Https
{
    public interface IHttpClientGatewaySerrvice
    {
        Task RegisterService();
        Task DestroyService();
    }
}
