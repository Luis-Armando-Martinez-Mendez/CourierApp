using CourierApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierApp.Domain.Entities
{
    public class Notification
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }

        // Constructor para inicializar las propiedades
        public Notification()
        {
            Message = string.Empty;
            User = new User(); // Inicializamos User como una nueva instancia.
            CreatedAt = DateTime.UtcNow; // Inicializamos con la fecha y hora actual en formato UTC.
        }
    }
}