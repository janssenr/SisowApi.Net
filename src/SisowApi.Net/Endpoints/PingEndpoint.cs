using SisowApi.Net.Resources;
using System.Threading.Tasks;

namespace SisowApi.Net.Endpoints
{
    public class PingEndpoint : AbstractEndpoint
    {
        public PingEndpoint(SisowClient client) : base(client) { }

        public async Task<PingResponse> Get()
        {
            return await Execute<PingResponse>("PingRequest");
        }
    }
}
