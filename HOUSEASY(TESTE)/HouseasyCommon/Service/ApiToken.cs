using HouseasyCommon.Model;
using HouseasyModel.DTO;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Net.Http.Json;

namespace HouseasyCommon.Service
{
    public class ApiToken : IApiToken
    {
        private readonly IOptions<Database> _database;
        private readonly IOptions<LoginResponse> _loginResponse;
        private readonly HttpClient _httpClient;

        public ApiToken(IOptions<Database> database, IOptions<LoginResponse> loginResponse, HttpClient httpClient)
        {
            _database = database;
            _loginResponse = loginResponse;
            _httpClient = httpClient;
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

        }

        public async Task<string> Obter()
        {
            if (_loginResponse.Value.Authenticated == false)
                await ObterToken();

            else
            {
                if (DateTime.Now >= _loginResponse.Value.ExpirationDate)
                    await ObterToken();
            }

            return _loginResponse.Value.Token;
        }

        private async Task ObterToken()
        {
            LoginRequest loginRequest = new LoginRequest();
            loginRequest.User = _database.Value.API_USER;
            loginRequest.Password = _database.Value.API_PASSWORD;

            HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_database.Value.API_URL_BASE}login", loginRequest);

            if (response.IsSuccessStatusCode)
            {
                string content = response.Content.ReadAsStringAsync().Result;
                LoginResponse loginResponse = JsonConvert.DeserializeObject<LoginResponse>(content);

                if (loginResponse.Authenticated)
                {
                    _loginResponse.Value.Authenticated = loginResponse.Authenticated;
                    _loginResponse.Value.User = loginResponse.User;
                    _loginResponse.Value.ExpirationDate = loginResponse.ExpirationDate;
                    _loginResponse.Value.Token = loginResponse.Token;
                }
            }
            else
            {
                throw new Exception(response.ReasonPhrase);
            }
        }
    }
}
