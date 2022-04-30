using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Test.Core.Common;
using Test.Core.Interfaces.Repository.RestClients;
using Test.Core.Models.DTO;
using Test.Repository.Base;

namespace Test.Repository.RestClients
{
    public class UserClient : BaseApiClient, IUserClient
    {
        #region Properties
        private readonly IHttpClientFactory _httpClientFactory;
        #endregion

        #region Constructor
        public UserClient(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        #endregion

        public async Task<UserDto> GetUser(int id)
        {
            HttpClient client = _httpClientFactory.CreateClient(HttpClientName.User);
            HttpRequestMessage request = CreateHttpRequestMesssage(HttpMethod.Get, $"users/{id}");
            HttpResponseMessage response = await SendAsyncBase(client, request);
            UserDto result = await GetContentResultAsyn<UserDto>(response);

            return result;
        }

        public async Task<IEnumerable<UserDto>> GetUsers()
        {
            HttpClient client = _httpClientFactory.CreateClient(HttpClientName.User);
            HttpRequestMessage request = CreateHttpRequestMesssage(HttpMethod.Get, $"users/");
            HttpResponseMessage response = await SendAsyncBase(client, request);
            IEnumerable<UserDto> result = await GetContentResultAsyn<IEnumerable<UserDto>>(response);

            return result;
        }

        public async Task<bool> Put(int id, UserDto userDto)
        {
            HttpClient client = _httpClientFactory.CreateClient(HttpClientName.User);
            HttpRequestMessage request = CreateHttpRequestMesssage(HttpMethod.Put, $"users/{id}");
            AddJsonContent(request, userDto);
            HttpResponseMessage response = await SendAsyncBase(client, request);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Post(UserDto userDto)
        {
            HttpClient client = _httpClientFactory.CreateClient(HttpClientName.User);
            HttpRequestMessage request = CreateHttpRequestMesssage(HttpMethod.Post, $"users/");
            AddJsonContent(request, userDto);
            HttpResponseMessage response = await SendAsyncBase(client, request);

            return response.IsSuccessStatusCode;
        }

        public async Task<bool> Delete(int userId, int userDelete)
        {
            HttpClient client = _httpClientFactory.CreateClient(HttpClientName.User);
            HttpRequestMessage request = CreateHttpRequestMesssage(HttpMethod.Post, $"users/{userId}?userId={userDelete}");
            HttpResponseMessage response = await SendAsyncBase(client, request);

            return response.IsSuccessStatusCode;
        }
    }
}
