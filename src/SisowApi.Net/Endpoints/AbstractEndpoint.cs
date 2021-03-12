using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SisowApi.Net.Endpoints
{
    public abstract class AbstractEndpoint
    {
        private readonly SisowClient _client;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        protected AbstractEndpoint(SisowClient client)
        {
            _client = client;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="data"></param>
        /// <returns></returns>
        protected async Task<T> Execute<T>(string endpoint, Dictionary<string, string> data = null)
        {
            return await _client.ApiRequest<T>(endpoint, data);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected string GetMerchantId()
        {
            return _client.GetMerchantId();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected string GetMerchantKey()
        {
            return _client.GetMerchantKey();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected string GetShopId()
        {
            return _client.GetShopId();
        }

        protected string GetSHA1(string key)
        {
            SHA1Managed sha = new SHA1Managed();
            UTF8Encoding enc = new UTF8Encoding();
            byte[] bytes = sha.ComputeHash(enc.GetBytes(key));
            string sha1 = "";
            for (int j = 0; j < bytes.Length; j++)
                sha1 += bytes[j].ToString("x2");
            return sha1;
        }
    }
}
