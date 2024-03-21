using Microsoft.AspNetCore.Mvc;
using NSE.WebApp.Mvc.Models;

namespace NSE.WebApp.Mvc.Controllers;

public class IdentidadeController : Controller
{
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
        // if (!ModelState.IsValid) return View(usuarioLogin);
        //
        // //Api - Login
        //
        // if (false) return View(usuarioLogin);
        //
        // //Realizar login na API
        
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