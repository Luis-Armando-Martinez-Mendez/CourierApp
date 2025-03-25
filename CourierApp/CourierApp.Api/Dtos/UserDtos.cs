using CourierApp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourierApp.Domain.Entities
{
    public class UserDtos
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string Role { get; set; } // "Admin" o "User"
        public ICollection<Notification> Notifications { get; set; }

        // Constructor para inicializar las propiedades
        public UserDtos()
        {
            Name = string.Empty;
            Email = string.Empty;
            PasswordHash = string.Empty;
            Role = string.Empty;
            Notifications = new List<Notification>();
        }
    }
}