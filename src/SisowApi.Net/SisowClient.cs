using SisowApi.Net.Endpoints;
using SisowApi.Net.Exceptions;
using SisowApi.Net.Helpers;
using SisowApi.Net.Resources;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;

namespace SisowApi.Net
{
    public class SisowClient
    {
        private string _merchantId;
        private string _merchantKey;
        private string _shopId;

        private readonly string _apiUrl = "https://www.sisow.nl/Sisow/iDeal/RestHandler.ashx/";
        private readonly HttpClient _httpClient;

        public MerchantEndpoint Merchants;
        public IssuerEndpoint Issuers;
        public TransactionEndpoint Transactions;
        public InvoiceEndpoint Invoices;
        public PingEndpoint Ping;

        public SisowClient() : this(new HttpClient()) { }

        public SisowClient(HttpClient httpClient)
        {
            _httpClient = httpClient;

            Merchants = new MerchantEndpoint(this);
            Issuers = new IssuerEndpoint(this);
            Transactions = new TransactionEndpoint(this);
            Invoices = new InvoiceEndpoint(this);
            Ping = new PingEndpoint(this);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="merchantId"></param>
        /// <param name="merchantKey"></param>
        /// <param name="shopId"></param>
        public void SetApiKey(string merchantId, string merchantKey, string shopId = "")
        {
            _merchantId = merchantId;
            _merchantKey = merchantKey;
            _shopId = shopId;
        }

        public async Task<T> ApiRequest<T>(string endPoint, Dictionary<string, string> data = null)
        {
            if (string.IsNullOrEmpty(_merchantId))
                throw new SisowException("You have not set a MerchantId. Please use SetApiKey() to set the MerchantId.");
            if (string.IsNullOrEmpty(_merchantKey))
                throw new SisowException("You have not set a MerchantKey. Please use SetApiKey() to set the MerchantKey.");

            string url = _apiUrl + endPoint;

            //_httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            //_httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", _apiKey);

            var method = data == null ? HttpMethod.Get : HttpMethod.Post;
            HttpRequestMessage request = new HttpRequestMessage(method, url);
            if (data != null)
            {
                request.Content = new FormUrlEncodedContent(data);
            }
            HttpResponseMessage response = await _httpClient.SendAsync(request);

            //switch (httpMethod)
            //{
            //    case HTTP_GET:
            //        {
            //            response = await _httpClient.GetAsync(url).ConfigureAwait(false);
            //            break;
            //        }
            //    case HTTP_POST:
            //        {
            //            var content = new StringContent(httpBody);
            //            content.Headers.Clear();
            //            content.Headers.Add("Content-Type", "application/json");
            //            //content.Headers.Add("Content-Type", "application/json;charset=utf-8");
            //            response = await _httpClient.PostAsync(url, content).ConfigureAwait(false);
            //            break;
            //        }
            //    case HTTP_DELETE:
            //        {
            //            response = await _httpClient.DeleteAsync(url).ConfigureAwait(false);
            //            break;
            //        }
            //    //case HTTP_PATCH:
            //    //    {
            //    //        var content = new StringContent(httpBody);
            //    //        content.Headers.Clear();
            //    //        content.Headers.Add("Content-Type", "application/json");
            //    //        //content.Headers.Add("Content-Type", "application/json;charset=utf-8");
            //    //        response = await _httpClient.PatchAsync(url, content).ConfigureAwait(false);
            //    //        break;
            //    //    }
            //}

            if (response == null)
                throw new SisowException("Did not receive API response.");

            return await ParseResponseBody<T>(response);
        }

        private async Task<T> ParseResponseBody<T>(HttpResponseMessage response)
        {
            if (response.IsSuccessStatusCode)
            {
                string body = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
                if (string.IsNullOrEmpty(body))
                {
                    if (response.StatusCode == HttpStatusCode.NoContent)
                        return default(T);

                    throw new SisowException("No response body found.");
                }
                try
                {
                    return XmlHelper.Deserialize<T>(body);
                }
                catch
                {
                    try
                    {
                        var errorResponse = XmlHelper.Deserialize<ErrorResponse>(body);
                        throw new SisowException(errorResponse.Error.ErrorMessage);
                    }
                    catch
                    {
                        throw new SisowException($"Unable to decode Sisow response: '{body}'.");
                    }
                }
            }
            else
            {
                throw new SisowException("TODO");
                //throw await SisowException.CreateFromResponse(response);
            }
        }

        public string GetMerchantId()
        {
            return _merchantId;
        }

        public string GetMerchantKey()
        {
            return _merchantKey;
        }

        public string GetShopId()
        {
            return _shopId;
        }
    }
}
