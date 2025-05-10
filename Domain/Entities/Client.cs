namespace Domain.Entities
{
    public class Client
    {
        public string CUIT { get; set; }
        public string RazonSocial { get; set; } // read only
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public bool Activo { get; set; }
    }

}
