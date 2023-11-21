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
    ViewBag.ObjetoConcierto = new Concierto();

    return View(concierto); 
}
    public IActionResult FormularioCompra(int Cantidad, string Email, int idConcierto){
        /*llamar a InsertarCompra*/
        return View();
    }
     

}
