using HouseasyCommon.Model;
using HouseasyCommon.Service;
using HouseasyModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using System.Net.Http.Headers;

namespace Houseasy.Controllers
{
    public class UsersController : Controller
    {
        private readonly IOptions<Database> _data;
        private readonly IApiToken _apiToken;
        private readonly HttpClient _httpClient;

        public UsersController(IOptions<Database> data,
                               IApiToken apiToken,
                               IHttpClientFactory httpClient)
        {
            _data = data;
            _apiToken = apiToken;
            _httpClient = httpClient.CreateClient();
            _httpClient.DefaultRequestHeaders.Accept.Clear();
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IActionResult> Index(string? mensagem, bool sucesso = true)
        {
            if (sucesso)
                TempData["success"] = mensagem;
            else
                TempData["error"] = mensagem;

            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Get());
            HttpResponseMessage response = await _httpClient.GetAsync($"{_data.Value.API_URL_BASE}Users");

            if (response.IsSuccessStatusCode)
                return View(JsonConvert.DeserializeObject<List<User>>(await response.Content.ReadAsStringAsync()));
            else
                throw new Exception(response.ReasonPhrase);
        }

        public ActionResult Details(int id)
        {
            return View();
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Get());
                    HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_data.Value.API_URL_BASE}Users", user);

                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index), new { mensagem = "Cadastro realizado!", sucesso = true });
                    else
                        throw new Exception(response.ReasonPhrase);
                }
                else
                {
                    TempData["error"] = "Algum campo está faltando ser preenchido";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Algum erro aconteceu - " + ex.Message;
                return View();
            }
        }

        public async Task<ActionResult> Edit(string id)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Get());
            HttpResponseMessage response = await _httpClient.GetAsync($"{_data.Value.API_URL_BASE}Users/GetByCPF?cpf={id}");

            if (response.IsSuccessStatusCode)
                return View(JsonConvert.DeserializeObject<User>(await response.Content.ReadAsStringAsync()));
            else
                throw new Exception(response.ReasonPhrase);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] User user)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Get());
                    HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_data.Value.API_URL_BASE}Users", user);

                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index), new { mensagem = "Alterações feitas com sucesso!", sucesso = true });
                    else
                        throw new Exception(response.ReasonPhrase);
                }
                else
                {
                    TempData["error"] = "Algum campo está faltando ser preenchido";
                    return View();
                }
            }
            catch (Exception ex)
            {
                TempData["error"] = "Algum erro aconteceu - " + ex.Message;
                return View();
            }
        }

        public async Task<IActionResult> Delete(string cpf)
        {
            try
            {
                    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Get());
                    HttpResponseMessage response = await _httpClient.DeleteAsync($"{_data.Value.API_URL_BASE}Users?cpf={cpf}");

                    if (response.IsSuccessStatusCode)
                        return RedirectToAction(nameof(Index), new { mensagem = "Exclusão realizada com sucesso!", sucesso = true });
                    else
                        throw new Exception(response.ReasonPhrase);
            }
            catch (Exception ex)
            {
                TempData["error"] = "Algum erro aconteceu - " + ex.Message;
                return View();
            }
        }
    }
}