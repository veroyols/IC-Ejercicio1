using Application.DTO;
using Application.Interfaces;
using Azure;
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
        public IActionResult Exercise()
        {
            return View();
        }
        
        // List Clients
        public async Task<IActionResult> Clients()
        {
            var clients = await _serviceClient.GetAllClientDtos();
            return View(clients);
        }

        // Create Client
        public IActionResult Create()
        {
            return View(new ClientDTO ());
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientDTO clientDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Por favor, complete todos los campos requeridos.");
                return View(clientDto);
            }

            var response = await _serviceClient.CreateClient(clientDto);
            TempData["InfoMessage"] = response.Message;
            if (response.Success)
            {
                return RedirectToAction("Clients");
            }
            else {
                Console.WriteLine(response.Message);
                ModelState.AddModelError("", response.Message);
                return View(clientDto);
            }


        }

        // Detail Client
        public async Task<IActionResult> Detail(string cuit)
        {
            var clientDetail = await _serviceClient.GetClientByCUIT(cuit);

            if (clientDetail.Success)
            {
                return View("Detail", clientDetail.Data);
            }

            return RedirectToAction("Clients");
        }

        // Update Client

        public async Task<IActionResult> Update(string cuit)
        {
            var clientToUpdate = await _serviceClient.GetClientByCUIT(cuit);

            if (clientToUpdate.Success)
            {
                return View("Update", clientToUpdate.Data);
            }
            else
            {
                TempData["InfoMessage"] = clientToUpdate.Message;
                Console.WriteLine(clientToUpdate.Message);
            }

            return RedirectToAction("Clients");
        }
        [HttpPost]
        public async Task<IActionResult> Update(ClientDTO clientDto)
        {
            if (!ModelState.IsValid)
            {
                return View(clientDto); 
            }

            var response = await _serviceClient.UpdateClient(clientDto);
            TempData["InfoMessage"] = response.Message;
            if (response.Success)
            {
                return RedirectToAction("Clients");
            }

            ModelState.AddModelError("", response.Message);
            return View(clientDto);
        }
        public async Task<IActionResult> Delete(string cuit)
        {
            var clientDeleted = await _serviceClient.DeleteClient(cuit);
            TempData["InfoMessage"] = clientDeleted.Message;

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
