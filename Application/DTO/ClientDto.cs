using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class ClientDTO
    {
        [Required(ErrorMessage = "El CUIT es obligatorio.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El CUIT debe contener 11 dígitos.")]
        [RegularExpression(@"^\d{11}$", ErrorMessage = "El CUIT debe contener 11 dígitos.")]
        public string CUIT { get; set; }

        public string? RazonSocial { get; set; }
        [Required(ErrorMessage = "Ingrese telefono.")]

        [RegularExpression(@"^\d{7,15}$", ErrorMessage = "El teléfono debe contener entre 7 y 15 dígitos numéricos.")]
        public string? Telefono { get; set; }

        [Required(ErrorMessage = "Ingrese direccion.")]
        [StringLength(200, ErrorMessage = "La dirección no puede superar los 200 caracteres.")]
        public string? Direccion { get; set; } 

        public bool Activo { get; set; }

        public ClientDTO(Client client)
        {
            CUIT = client.CUIT;
            RazonSocial = client.RazonSocial;
            Telefono = client.Telefono;
            Direccion = client.Direccion;
            Activo = client.Activo;
        }
        public ClientDTO() { }
    }

}
