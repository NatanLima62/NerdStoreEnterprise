using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.Mvc.Models;
using NSE.WebApp.Mvc.Service;

namespace NSE.WebApp.Mvc.Controllers;

public class IdentidadeController : Controller
{
    private readonly IAutenticacaoService _authenticationService;

    public IdentidadeController(IAutenticacaoService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpGet]
    [Route("nova-conta")]
    public IActionResult Registro()
    {
        return View();
    }
    
    [HttpPost]
    [Route("nova-conta")]
    public async Task<IActionResult> Registro(UsuarioRegistro usuarioRegistro)
    {
        if (!ModelState.IsValid) return View(usuarioRegistro);
        
        //Api - Registro
        var response = await _authenticationService.Registro(usuarioRegistro);
        if (false) return View(usuarioRegistro);
        
        //Realizar login na API
        
        return RedirectToAction("Index", "Home");
    }
    
    [HttpGet]
    [Route("login")]
    public IActionResult Login()
    {
        return View();
    }
    
    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login(UsuarioLogin usuarioLogin)
    {
        if (!ModelState.IsValid) return View(usuarioLogin);
        
        //Api - Login
        await _authenticationService.Login(usuarioLogin);
        if (false) return View(usuarioLogin);
        
        //Realizar login na API
        
        return RedirectToAction("Index", "Home");
    }
    
    [HttpGet]
    [Route("sair")]
    public async Task<IActionResult> Logout()
    {
        //Api - Logout

        return RedirectToAction("Index", "Home");
    }
}