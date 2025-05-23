
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
        private readonly IConfiguration _config;

        public ClientController(IServiceClient serviceClient, IConfiguration config)
        {
            _serviceClient = serviceClient;
            _config = config;
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
                ModelState.AddModelError("", "Complete los campos requeridos.");
                return View(clientDto);
            }

            try {
                var response = await _serviceClient.CreateClient(clientDto);
                TempData["InfoMessage"] = response.Message;
                if (response.Success)
                {
                    return RedirectToAction("Clients");
                }
                ModelState.AddModelError("", response.Message);
                Console.WriteLine(response.Message);

            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Ocurri� un error al crear el cliente.");
                Console.WriteLine($"Error en Create: {ex.Message}");
            }

            return View(clientDto);
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
            var baseUrl = _config["WebMethod"];
            using var client = new HttpClient();
            var response = await client.GetAsync($"{baseUrl}{cuit}");
            var data = await response.Content.ReadAsStringAsync();
            ////////////////////////
            //return Ok(new { nombre = "Razon Social Backend" });
            if (data.Contains("@"))
            {
                return NotFound(new { nombre = ""});
        }
            return Ok(new { nombre = data });

        }
        
    }
}
