using CourierApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierApp.Domain.Entities
{
    public class NotificationDtos
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public int UserId { get; set; }
        public UserDtos User { get; set; }
        public DateTime CreatedAt { get; set; }

        // Constructor para inicializar las propiedades
        public NotificationDtos()
        {
            Message = string.Empty;
            User = new UserDtos(); // Inicializamos User como una nueva instancia.
            CreatedAt = DateTime.UtcNow; // Inicializamos con la fecha y hora actual en formato UTC.
        }
    }
}