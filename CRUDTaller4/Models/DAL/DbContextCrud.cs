using CRUDTaller4.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CRUDTaller4.Models.DAL
{
    public class DbContextCrud:DbContext
    {
        public DbContextCrud(DbContextOptions<DbContextCrud> options): base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public object Cliente { get; internal set; }
    }
}
