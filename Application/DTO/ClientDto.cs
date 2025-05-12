using Domain.Entities;
using System.ComponentModel.DataAnnotations;

namespace Application.DTO
{
    public class ClientDTO
    {
        [Required(ErrorMessage = "El CUIT es obligatorio.")]
        [StringLength(11, MinimumLength = 11, ErrorMessage = "El CUIT debe tener exactamente 11 dígitos.")]
        public string CUIT { get; set; }

        [Required(ErrorMessage = "La razón social es obligatoria.")]
        public string RazonSocial { get; set; }

        [Required(ErrorMessage = "El teléfono es obligatorio.")]
        [Phone(ErrorMessage = "Ingrese un número de teléfono válido.")]
        public string Telefono { get; set; }

        [Required(ErrorMessage = "La dirección es obligatoria.")]
        public string Direccion { get; set; }

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
