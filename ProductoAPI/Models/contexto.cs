using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductoAPI.Models
{
    public class contexto : DbContext
    {
        public contexto(DbContextOptions <contexto> options) : base(options)
        {

        }

        public DbSet <Producto> producto { get; set; }

    }
}
