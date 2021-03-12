using SisowApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisowApi.Net.Endpoints
{
    public class IssuerEndpoint : AbstractEndpoint
    {
        public IssuerEndpoint(SisowClient client) : base(client) { }

        public async Task<List<Issuer>> Get()
        {
            var response = await Execute<DirectoryResponse>("DirectoryRequest");
            return response.Issuers;
        }
    }
}
