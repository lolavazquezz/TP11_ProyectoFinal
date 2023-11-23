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

public IActionResult InfoConciertos(string nombre)
{
    ViewBag.concierto= new List<Concierto>();
    ViewBag.conciertos = BD.traerConciertosIguales(nombre);
    ViewBag.nombreConcierto=nombre;
    return View("InfoConciertos"); 
}
    public IActionResult FormularioCompra(int Cantidad, string Email, int idConcierto){
        /*llamar a InsertarCompra*/
        return View();
    }
     

}
