using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP11_ProyectoFinal.Models;

namespace TP11_ProyectoFinal.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.ListConciertos = BD.traerConciertos();
        return View();
    }

public IActionResult VerMasInfo(int idConcierto)
{
    List<Concierto> listaConciertos = new List<Concierto>();
    Concierto concierto = BD.traerConcierto(idConcierto);
    ViewBag.ListConciertos = listaConciertos;

    return View(concierto); 
}










    public IActionResult registrarse(){
        return View();
    }
    public IActionResult crearUsuario(Usuario usu){
        ViewBag.error1 = "";
        ViewBag.error2 = "";
        
        bool existem = BD.existeMail(usu.Email);
        if (existem) {
            ViewBag.error2 = "El email ya esta registrado en una cuenta, ingrese uno nuevo.";
        }
        else if ((!existem)&&(ViewBag.error1 == "")) {
            BD.crearUsuario(usu);
            ViewBag.nombre = usu.Nombre;
            ViewBag.email = usu.Email;
            ViewBag.telefono = usu.Clave;
            return View("bienvenido");
        }
        return View("registrarse", usu);
    }
}
