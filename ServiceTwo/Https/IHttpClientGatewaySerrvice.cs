using System.Threading.Tasks;

namespace ServiceTwo.Https
{
    public interface IHttpClientGatewaySerrvice
    {
        Task RegisterService();
        Task DestroyService();
    }
}
