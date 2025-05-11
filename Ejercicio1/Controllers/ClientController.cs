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
        public IActionResult Exercise()
        {
            return View();
        }
        public async Task<IActionResult> Clients()
        {

            var clients = await _serviceClient.GetAllClientDtos();
            return View(clients);
        }
        public IActionResult Create()
        {
            return View(new ClientDTO()); // Vista de creación con un modelo vacío
        }

        [HttpPost]
        public async Task<IActionResult> Create(ClientDTO clientDto)
        {
            if (!ModelState.IsValid)
            {
                return View(clientDto); // Si hay errores, muestra la vista de creación con los datos ingresados
            }

            var response = await _serviceClient.CreateClient(clientDto);
            if (response.Success)
            {
                return RedirectToAction("Clients");
            }

            ModelState.AddModelError("", "Error al crear el cliente.");
            return View(clientDto);
        }


        public async Task<IActionResult> Update(string cuit)
        {
            var clientToUpdate = await _serviceClient.GetClientByCUIT(cuit);

            if (clientToUpdate.Success)
            {
                return View("Update", clientToUpdate.Data);
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
            if (response.Success)
            {
                return RedirectToAction("Clients");
            }

            ModelState.AddModelError("", "Error al actualizar el cliente.");
            return View(clientDto);
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
