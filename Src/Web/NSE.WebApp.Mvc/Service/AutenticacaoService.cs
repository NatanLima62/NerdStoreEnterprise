using System.Text;
using System.Text.Json;
using NSE.WebApp.Mvc.Models;

namespace NSE.WebApp.Mvc.Service;

public class AutenticacaoService : IAutenticacaoService
{
    private readonly HttpClient _httpClient;

    public AutenticacaoService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<UsuarioRespostaLogin?> Login(UsuarioLogin usuarioLogin)
    {
        var loginContent = new StringContent(JsonSerializer.Serialize(usuarioLogin), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://localhost:7166/api/identidade/autenticar", loginContent);
        return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync());
    }

    public async Task<UsuarioRespostaLogin?> Registro(UsuarioRegistro usuarioRegistro)
    {
        var registroContent = new StringContent(JsonSerializer.Serialize(usuarioRegistro), Encoding.UTF8, "application/json");
        var response = await _httpClient.PostAsync("https://localhost:7166/api/identidade/nova-conta", registroContent);
        return JsonSerializer.Deserialize<UsuarioRespostaLogin>(await response.Content.ReadAsStringAsync());
    }
}