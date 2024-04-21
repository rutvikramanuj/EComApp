using EComApp.Web.Models;
using EComApp.Web.Models.Dtos;
using System.Linq.Expressions;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace EComApp.Web.Service
{
    public class BaseService : IBaseService
    {
        public BaseService(IHttpClientFactory http)
        {
            _http = http;
        }

        public IHttpClientFactory _http { get; }

        public async Task<ResponseDto?> SendAsync(RequestDto requestDto)
        {
            try
            {
            HttpClient httpCall = _http.CreateClient("EComApp");
            HttpRequestMessage msg = new();
            HttpResponseMessage responseAPI = null;
            msg.Headers.Add("Accept", "application/json");
            msg.RequestUri = new Uri(requestDto.Url);
            if (requestDto.Data != null)
            {
                msg.Content = new StringContent(JsonSerializer.Serialize(requestDto.Data), Encoding.UTF8, "application/json");
            }
            switch (requestDto.ApiType)
            {
                case Utility.SD.ApiType.GET:
                    msg.Method = HttpMethod.Get;
                    break;
                case Utility.SD.ApiType.POST:
                    msg.Method = HttpMethod.Post;
                    break;
                case Utility.SD.ApiType.PUT:
                    msg.Method = HttpMethod.Put;
                    break;
                case Utility.SD.ApiType.DELETE:
                    msg.Method = HttpMethod.Delete;
                    break;
            }
            responseAPI = await httpCall.SendAsync(msg);
            switch (responseAPI.StatusCode)
            {
                case System.Net.HttpStatusCode.BadRequest:
                    return new()
                    {
                        isSuccess = false,
                        message = "BadRequest"
                    };
                    break;
                case System.Net.HttpStatusCode.Unauthorized:
                    return new()
                    {
                        isSuccess = false,
                        message = "Unauthorized"
                    };
                    break;
                case System.Net.HttpStatusCode.Forbidden:
                    return new()
                    {
                        isSuccess = false,
                        message = "Forbidden"
                    };
                    break;
                case System.Net.HttpStatusCode.NotFound:
                    return new()
                    {
                        isSuccess = false,
                        message = "Not Found"
                    };
                    break;
                default:
                    var apiContent = await responseAPI.Content.ReadAsStringAsync();
                    if (apiContent != null)
                    {
                    ResponseDto parsedResponse = JsonSerializer.Deserialize<ResponseDto>(apiContent);

                    return parsedResponse;
                    }
                    else
                    {
                        return new ResponseDto
                        {
                            isError = true,
                        };
                    }
            }
            }
            catch (Exception err)
            {
                return new ResponseDto()
                {
                    isError = true,
                    message = err.Message
                };
            }
        }
    }
}
