using Application.DTO;
using Application.Interfaces;
using Ejercicio1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ejercicio1.Controllers
{
    public class ClientController : Controller
    {
        private readonly IServiceClient _serviceClient;

        public ClientController(IServiceClient serviceClient)
        {
            _serviceClient = serviceClient;
        }
        public async Task<IActionResult> Clients()
        {

            var clients = await _serviceClient.GetAllClientDtos();
            return View(clients);
        }
        public IActionResult CreateForm()
        {
            ViewData["Title"] = "Crear";
            ViewData["ActionType"] = "Agregar Cliente";
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ClientDTO clientDto)
        {
            if (!ModelState.IsValid)
            {
                return View(clientDto); 
            }

            var response = await _serviceClient.CreateClient(clientDto);
            return RedirectToAction("Clients");
        }

        public IActionResult Exercise()
        {
            return View();
        }

        public async Task<IActionResult> Edit(string cuit)
        {
            var clientToUpdate = await _serviceClient.GetClientByCUIT(cuit);
            if (clientToUpdate.Success)
            {
                ViewData["Title"] = "Editar";
                ViewData["ActionType"] = "Editar Cliente";
                return View("CreateForm", clientToUpdate.Data); 
            }
            await _serviceClient.UpdateClient(clientToUpdate.Data);
            return RedirectToAction("Clients");
        }
        public async Task<IActionResult> Delete(string cuit)
        {
            var clientDeleted = await _serviceClient.DeleteClient(cuit);

            return RedirectToAction("Clients");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }


        public async Task<IActionResult> GetNombreByCuit(string cuit)
        {
            Console.WriteLine(cuit);
            var URI = "https://sistemaintegracomex.com.ar/Account/GetNombreByCuit?cuit=";
            using var client = new HttpClient();
            var response = await client.GetAsync($"{URI}{cuit}");
            //var data = await response.Content.ReadAsStringAsync();
            ////////////////////////
            return Ok(new { nombre = "Razon Social Backend" });
        }
    }
}
