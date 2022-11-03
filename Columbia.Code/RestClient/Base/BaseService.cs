using $safesolutionname$.Dto.Base;
using Newtonsoft.Json;
using System.Net.Http.Json;

namespace $safesolutionname$.RestClient.Base
{
    public class BaseService
    {
        protected string BaseUrl { get; }
        protected Dictionary<string, string> Headers { get; }
        protected virtual string ApiController { get; } = null!;

        public BaseService(ServiceOptions options)
        {
            BaseUrl = options?.BaseUrl ?? string.Empty;
            Headers = options?.Headers ?? new Dictionary<string, string>();
        }

        protected async Task<ResponseDto> Get(string resource = "")
            => await Request((client) => client.GetAsync($"{BaseUrl}{ApiController}{resource}"));

        protected async Task<ResponseDto<TResponse>> Get<TResponse>(string resource = "")
            => await Request<TResponse>((client) => client.GetAsync($"{BaseUrl}{ApiController}{resource}"));

        protected async Task<HttpResponseMessage> GetResponse(string resource = "")
            => await RequestResponse((client) => client.GetAsync($"{BaseUrl}{ApiController}{resource}"));


        protected async Task<ResponseDto> Post<TRequest>(string resource = "", TRequest body = default!)
            => await Request((client, body) => client.PostAsJsonAsync($"{BaseUrl}{ApiController}{resource}", body), body);

        protected async Task<ResponseDto<TResponse>> Post<TRequest, TResponse>(string resource = "", TRequest body = default!)
            => await Request<TRequest, TResponse>((client, body) => client.PostAsJsonAsync($"{BaseUrl}{ApiController}{resource}", body), body);

        protected async Task<HttpResponseMessage> PostResponse<TRequest>(string resource = "", TRequest body = default!)
            => await RequestResponse((client, body) => client.PostAsJsonAsync($"{BaseUrl}{ApiController}{resource}", body), body);


        protected async Task<ResponseDto> Put<TRequest>(string resource = "", TRequest? body = default)
            => await Request((client, body) => client.PutAsJsonAsync($"{BaseUrl}{ApiController}{resource}", body), body);

        protected async Task<ResponseDto<TResponse>> Put<TRequest, TResponse>(string resource = "", TRequest? body = default)
            => await Request<TRequest, TResponse>((client, body) => client.PutAsJsonAsync($"{BaseUrl}{ApiController}{resource}", body), body);

        protected async Task<HttpResponseMessage> PutResponse<TRequest>(string resource = "", TRequest? body = default)
            => await RequestResponse((client, body) => client.PutAsJsonAsync($"{BaseUrl}{ApiController}{resource}", body), body);


        protected async Task<ResponseDto> Patch(string resource = "", HttpContent? body = default)
            => await Request((client, body) => client.PatchAsync($"{BaseUrl}{ApiController}{resource}", body), body);

        protected async Task<ResponseDto<TResponse>> Patch<TResponse>(string resource = "", HttpContent? body = default)
            => await Request<HttpContent, TResponse>((client, body) => client.PatchAsync($"{BaseUrl}{ApiController}{resource}", body), body);

        protected async Task<HttpResponseMessage> PatchResponse(string resource = "", HttpContent? body = default)
            => await RequestResponse((client, body) => client.PatchAsync($"{BaseUrl}{ApiController}{resource}", body), body);


        protected async Task<ResponseDto> Delete(string resource = "")
            => await Request((client) => client.DeleteAsync($"{BaseUrl}{ApiController}{resource}"));

        protected async Task<ResponseDto<TResponse>> Delete<TResponse>(string resource = "")
            => await Request<TResponse>((client) => client.DeleteAsync($"{BaseUrl}{ApiController}{resource}"));

        protected async Task<HttpResponseMessage> DeleteResponse(string resource = "")
            => await RequestResponse((client) => client.DeleteAsync($"{BaseUrl}{ApiController}{resource}"));


        private async Task<ResponseDto> Request(Func<HttpClient, Task<HttpResponseMessage>> func)
        {
            try
            {
                var http = GetHttpClient();
                var response = await func.Invoke(http);
                return await Deserialize<ResponseDto>(response);
            }
            catch (Exception ex)
            {
                var response = GetErrorResult(ex);
                return response;
            }
        }

        private async Task<ResponseDto<TResponse>> Request<TResponse>(Func<HttpClient, Task<HttpResponseMessage>> func)
        {
            try
            {
                var http = GetHttpClient();
                var response = await func.Invoke(http);
                return await Deserialize<ResponseDto<TResponse>>(response);
            }
            catch (Exception ex)
            {
                var response = GetErrorResult<TResponse>(ex);
                return response;
            }
        }

        private async Task<ResponseDto> Request<TRequest>(Func<HttpClient, TRequest, Task<HttpResponseMessage>> func, TRequest? body)
        {
            try
            {
                var http = GetHttpClient();
                var response = await func.Invoke(http, body!);
                return await Deserialize<ResponseDto>(response);
            }
            catch (Exception ex)
            {
                var response = GetErrorResult(ex);
                return response;
            }
        }

        private async Task<ResponseDto<TResponse>> Request<TRequest, TResponse>(Func<HttpClient, TRequest, Task<HttpResponseMessage>> func, TRequest? body)
        {
            try
            {
                var http = GetHttpClient();
                var response = await func.Invoke(http, body!);
                return await Deserialize<ResponseDto<TResponse>>(response);
            }
            catch (Exception ex)
            {
                var response = GetErrorResult<TResponse>(ex);
                return response;
            }
        }

        private async Task<HttpResponseMessage> RequestResponse(Func<HttpClient, Task<HttpResponseMessage>> func)
        {
            var http = GetHttpClient();
            return await func.Invoke(http);
        }

        private async Task<HttpResponseMessage> RequestResponse<TRequest>(Func<HttpClient, TRequest, Task<HttpResponseMessage>> func, TRequest? body)
        {
            var http = GetHttpClient();
            return await func.Invoke(http, body!);
        }

        protected static async Task<TResponse> Deserialize<TResponse>(HttpResponseMessage response)
        {
            var responseContent = await response.Content.ReadAsStringAsync();

            if (response.StatusCode != System.Net.HttpStatusCode.OK)
                throw new Exception(responseContent);

            return JsonConvert.DeserializeObject<TResponse>(responseContent!)!;
        }

        private HttpClient GetHttpClient()
        {
            var httpClient = new HttpClient();

            if (httpClient.DefaultRequestHeaders != null && Headers != null)
            {
                Headers.ToList().ForEach(h =>
                {
                    httpClient.DefaultRequestHeaders.Add(h.Key, h.Value);
                });
            }

            return httpClient;
        }

        private static ResponseDto GetErrorResult(Exception ex)
            => new() { Messages = GetMessages(ex) };

        private static ResponseDto<TResponse> GetErrorResult<TResponse>(Exception ex)
            => new() { Messages = GetMessages(ex) };

        private static List<ApplicationMessageDto> GetMessages(Exception ex)
        {
            return new List<ApplicationMessageDto>
            {
                new ApplicationMessageDto
                {
                    Message = ex.Message.Contains("connection attempt failed") ? "Error de conexión" : $"{ex.Message}{Environment.NewLine}{ex.StackTrace}",
                    MessageType = ApplicationMessageType.Error
                }
            };
        }
    }
}
