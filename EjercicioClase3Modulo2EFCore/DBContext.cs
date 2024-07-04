using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EjercicioClase3Modulo2EFCore
{
    public class DBContext : DbContext
    {
        public DbSet<Actor> Actor { get; set; }
       public DBContext(DbContextOptions<DBContext> options) : base(options) 
        { 
        
        }
    }
}
