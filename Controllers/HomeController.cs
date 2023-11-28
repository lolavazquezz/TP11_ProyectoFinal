using System.ComponentModel.DataAnnotations;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TPFinal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using System.IO;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
namespace TPFinal.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IWebHostEnvironment Environment;

    public HomeController(IWebHostEnvironment environment)
    {
        Environment = environment;
    }

    public IActionResult Index()
    {
        return View("IniciarSesion");
    }
    public IActionResult Creditos()
    {
        return View();
    }
    public IActionResult VerificarTarjeta(Tarjeta T)
    {
        Tarjeta tarjeta = BD.VerificarSiExisteTarjeta(T.Numero);
        if (tarjeta != null)
        {
            return RedirectToAction("Compra", "Home");
        }
        else
        {
            return RedirectToAction("Error", "Home");
        }
    }
    public IActionResult Compra()
    {
        return View();
    }
    public IActionResult VerificarUsuario(Usuario U)
    {

        if (VerificarSiExisteUsuario(U) == true)
        {
            Usuario usuarioBD = BD.BuscarUsuarioXNombre(U.Nombre);
            if (usuarioBD.Contraseña == U.Contraseña)
            {
            return RedirectToAction("PaginaPrincipal", "Home", new { IdUsuario = usuarioBD.IdUsuario});
            }
            else
            {
                ViewBag.Mensaje = "La contraseña es incorrecta";
                return View("IniciarSesion");
            }
        }
        else
        {
            ViewBag.Mensaje = "El usuario no existe o es incorrecto";
            return View("IniciarSesion");
        }
    }
    public bool VerificarSiExisteUsuario(Usuario U)
    {
        return BD.BuscarUsuarioXNombre(U.Nombre) != null;
    }
    public IActionResult VerificarUsuarioRegistro(Usuario U, string Contraseña2)
    {

        if(VerificarSiExisteUsuario(U) == true)
        {
            ViewBag.Mensaje = "El usuario ya existe, ingrese otro nombre";
            return View("Registrarse");
        }
        if(U.Contraseña != Contraseña2)
        {
            ViewBag.Mensaje = "Las contraseñas no coinciden";
            return View("Registrarse");
        }
        BD.AgregarUsuarioSP(U);

        return RedirectToAction("PaginaPrincipal", "Home");
    }
    public IActionResult Registrarse()
    {
        return View();
    }
    public IActionResult OlvidoContraseña(Usuario U)
    {
        ViewBag.Usuario = BD.BuscarContraXUsuario(U.Nombre);
        if (ViewBag.Usuario != null) {
        ViewBag.Mensaje = "La contraseña es: " + ViewBag.Usuario.Contraseña;
        }
        else
        {
            ViewBag.Mensaje = "No encontramos el usuario ingresado";
        }
        return View();
    }
        public IActionResult BuscarOlvidoContraseña()
    {
        return View("OlvidoContraseña");
    }
    [HttpPost]
    public IActionResult InsertarUsuario(Usuario U, string Contraseña2)
    {
        if (U.Contraseña == Contraseña2)
        {
            BD.AgregarUsuarioSP(U);
            return RedirectToAction("PaginaPrincipal", "Home");
        }
        else
        {
            ViewBag.Mensaje = "Las contraseñas no coinciden";
            return View("Registrarse");
        }
    }
    
    public IActionResult PaginaPrincipal()
    {

        ViewBag.listaconciertos = BD.Traerconciertos();
        return View("Index");
    }
    public IActionResult Comprarconcierto()
    {
        return View();
    }
    public concierto MostrarconciertosAjax(int Idconcierto)
    {
        return BD.verInfoconcierto(Idconcierto);
    }

    public IActionResult Agregarconcierto(int Idconcierto)
    {
        ViewBag.listaCategorias = BD.TraerCategorias();
        ViewBag.concierto = Idconcierto;
        return View();
    }
    public IActionResult Guardarconcierto(concierto Jue, IFormFile Imagen)
    {
        if (Imagen.Length > 0)
        {
            string wwwRootLocal = this.Environment.ContentRootPath + @"\wwwroot\" + Imagen.FileName;
            using (var stream = System.IO.File.Create(wwwRootLocal))
            {
                Imagen.CopyTo(stream);
            }
            Jue.Imagen = Imagen.FileName;
        }
        BD.AgregarconciertoSP(Jue);
        ViewBag.detalleconciertos = BD.verInfoconcierto(Jue.Idconcierto);
        ViewBag.listaconciertos = BD.Traerconciertos();
        return RedirectToAction("PaginaPrincipal", "Home");
    }

    public concierto MostrarMasInfoAjax(int Idconcierto)
    {
        return BD.verInfoconcierto(Idconcierto);
    }

    //Retorna la nueva cantidad de likes
    [HttpPost]
    public int LikesAjax(int Idconcierto, int cantLikes, int IdUsuario)
    {
        BD.ActualizarLikesconciertoSP(Idconcierto, cantLikes);
        return BD.VerCantLikes(Idconcierto);
    }

    public IActionResult CrearCuentaAjax(Usuario usuario)
    {
        BD.AgregarUsuarioSP(usuario);
        return View("Index");

    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}