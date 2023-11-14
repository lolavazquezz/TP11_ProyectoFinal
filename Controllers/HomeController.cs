using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP11_ProyectoFinal.Models;

namespace TP11_ProyectoFinal.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.ListConciertos = BD.listaConciertos();
        return View();
    }

    public IActionResult VerMasInfo(int idConcierto)
    {
        return BD.traerConcierto(idConcierto);
    }

    public IActionResult Login(string UN, string PW)
    {
        ViewBag.usuario=BD.login(UN,PW);
        if(ViewBag.usuario == null){
             ViewBag.Error = "El usuario o la contraseña es incorrecto.";
            return View("Login");
        }
        return View("Bienvenida");
    }

    [HttpPost]public IActionResult Registro(Usuario usuario)
    {
        ViewBag.uSuario=BD.BuscarUser(usuario.UserName);
        if(ViewBag.uSuario==null){
           BD.RegistroUser(usuario);
            return View("Registro");
        }
        return View("Bienvenida");
    }
}
