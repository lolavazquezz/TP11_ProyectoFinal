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
        return BD.traerConcierto(idConcierto);
    }

     public IActionResult login(string username, string contraseña)
    {
        Usuario user = BD.login(username, contraseña);
        if (user == null){
            ViewBag.mensajeError = "Usuario o contraseña incorrecta";
            return View("Index");
        }
        else
        {
            ViewBag.nombre = user.Nombre;
            ViewBag.email = user.Email;
            return View("bienvenido");
        }
    }
    public IActionResult registrarse(){
        return View();
    }
    public IActionResult crearUsuario(Usuario usu){
        ViewBag.error1 = "";
        ViewBag.error2 = "";
        if (usu.contraseña != usu.contraseña2){
            ViewBag.error1 = "Verifique que las dos contraseñas sean iguales";
        }
        
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
    public IActionResult olvideContra(){
        return View();
    }
    public IActionResult traerPregunta(string email){
        ViewBag.validar="";
        bool valido = BD.existeMail(email);
        if (!valido){
            ViewBag.validar="El mail ingresado no pertenece a una cuenta";
            return View("olvideContra");
        }
        ViewBag.pregunta = BD.traerPregunta(email);
        ViewBag.email= email;
        return View("traerContra", ViewBag.email);
    }
    public IActionResult traerContra(string email, string respuesta, string pregunta){
        ViewBag.validar ="";
        ViewBag.pregunta = pregunta;
        ViewBag.email = email;
        bool valido = BD.validarRta(respuesta);
        if (!valido){
            ViewBag.validar="Respuesta incorrecta";
            return View("traerContra", ViewBag.email);
        }
        string contraseña = BD.traerContra(email);
        ViewBag.contraseña = contraseña;
        return View("mostrarContra");
    }
}
