using System;

namespace BackTest.Domain.Entities
{
    public class MarcaAuto
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string PaisDeOrigen { get; set; }
        public DateTime Fundacion { get; set; }
        public string SitioWeb { get; set; }
        public bool Activa { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime? FechaModificacion { get; set; }

    }
}
