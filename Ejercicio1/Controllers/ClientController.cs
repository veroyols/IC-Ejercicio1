using System.Diagnostics;
using Application.Interfaces;
using Ejercicio1.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ejercicio1.Controllers
{
    public class ClientController : Controller
    {
        private readonly IServiceClient _serviceClient;

        public ClientController(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }
        // vista Home con la tabla de clientes
        public IActionResult Index()
        {
            var clients = _serviceClient.GetAllClientDtos();
            return View(); 
        }
        //vista Add o Update
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
