using Domain.Entities;

namespace Application.DTO
{
    public class ClientDTO
    {
        public string CUIT { get; set; }
        public string RazonSocial { get; set; }
        public string Telefono { get; set; }
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
