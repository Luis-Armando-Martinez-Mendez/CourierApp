using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using CourierApp.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CourierApp.infrastructure.Context
{
    public class CourierAppContext : DbContext
    {
        public CourierAppContext(DbContextOptions<CourierAppContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Notification> Notifications { get; set; }



    }
}