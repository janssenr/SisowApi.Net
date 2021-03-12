using SisowApi.Net.Exceptions;
using SisowApi.Net.Resources;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SisowApi.Net.Endpoints
{
    public class MerchantEndpoint : AbstractEndpoint
    {
        public MerchantEndpoint(SisowClient client) : base(client) { }

        public async Task<Merchant> Get()
        {
            var data = new Dictionary<string, string>();
            data.Add("merchantid", GetMerchantId());
            data.Add("sha1", GetSHA1(GetMerchantId() + GetMerchantKey()));
            var response = await Execute<CheckMerchantResponse>("CheckMerchantRequest", data);

            // validate signature
            if (response.Signature.SHA1 != GetSHA1(GetMerchantId() + GetMerchantKey()))
            {
                throw new SisowException("Invalid response!");
            }
            return response.Merchant;
        }
    }
}
