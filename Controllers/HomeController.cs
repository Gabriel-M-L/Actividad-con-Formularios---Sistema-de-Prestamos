using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Actividad_con_formularios.Models;

namespace Actividad_con_formularios.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    public IActionResult comprobarApto(string nombre, int edad, int dni, bool trabajo, int tipoTrabajo, int ingresos, bool deuda, bool tarjetaCredito, bool prestamoBancario, bool prestamoInformal, int monto, int plazo, string terminos){
        bool apto = false;
        if(edad >= 18 && trabajo && ingresos > 250000 && monto <= (ingresos/5) && !deuda && terminos == "on"){
            apto = true;
        }
        ViewBag.apto = apto;
        ViewBag.nombre = nombre;
        return View("mostrarApto");
    }


    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
