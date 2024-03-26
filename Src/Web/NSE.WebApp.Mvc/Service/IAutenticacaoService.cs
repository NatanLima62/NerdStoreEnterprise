using NSE.WebApp.Mvc.Models;

namespace NSE.WebApp.Mvc.Service;

public interface IAutenticacaoService
{
    Task<UsuarioRespostaLogin?> Login(UsuarioLogin usuarioLogin);
    Task<UsuarioRespostaLogin?> Registro(UsuarioRegistro usuarioRegistro);
}