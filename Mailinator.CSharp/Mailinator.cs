using Newtonsoft.Json;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Mailinator.CSharp
{
    public class Mailinator : IDisposable
    {
        private const string ApiEndpoint = "https://api.mailinator.com/api/";

        public readonly string Token;
        public readonly bool UsePrivateDomain = false;

        private HttpClient _Client;

        public Mailinator(string token)
        {
            this.Token = token;

            _Client = new HttpClient();
        }

        public Mailinator(string token, bool usePrivateDomain)
        {
            this.Token = token;
            this.UsePrivateDomain = usePrivateDomain;

            _Client = new HttpClient();
        }

        private string BuildUrl(BaseRequest request, string apiCall)
        {
            if (request.UsePrivateDomain)
            {
                return String.Format("{0}{1}?token={2}&private_domain=true", ApiEndpoint, apiCall, request.Token ?? Token);
            }
            else
            {
                return String.Format("{0}{1}?token={2}", ApiEndpoint, apiCall, request.Token ?? Token);
            }
        }

        private async Task<T> Get<T>(string url)
        {
            var result = await _Client.GetAsync(new Uri(url));

            if (result.IsSuccessStatusCode)
            {
                var content = await result.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<T>(content, new JsonSerializerSettings()
                {
                    DateFormatString = "ddd, dd MMM yyyy hh:mm:ss zzz (PST)"
                });
            }
            else
            {
                throw new HttpRequestException(result.ReasonPhrase, new Exception(await result.Content.ReadAsStringAsync()));
            }
        }

        /// <summary>
        /// Gets a listing of the emails in the specified inbox
        /// </summary>
        /// <param name="request">The request object. Contains options and the inbox to fetch from</param>
        /// <returns></returns>
        public async Task<Inbox> ListInboxMessagesAsync(InboxRequest request)
        {
            return await Get<Inbox>(BuildUrl(request, "inbox") + "&to=" + request.To);
        }

        /// <summary>
        /// Gets a specific email and its contents
        /// </summary>
        /// <param name="request">The request object. Contains options and the email id to fetch</param>
        /// <returns></returns>
        public async Task<Email> GetEmailMessageAsync(EmailRequest request)
        {
            return await Get<Email>(BuildUrl(request, "email") + "&id=" + request.EmailId);
        }

        /// <summary>
        /// Deletes a specific email message
        /// </summary>
        /// <param name="request">The request object. Contains options and the email id to fetch</param>
        /// <returns></returns>
        public async Task<DeleteEmailResponse> DeleteEmailMessageAsync(EmailRequest request)
        {
            return await Get<DeleteEmailResponse>(BuildUrl(request, "delete") + "&id=" + request.EmailId);
        }

        public void Dispose()
        {
            _Client.Dispose();
        }
    }
}
