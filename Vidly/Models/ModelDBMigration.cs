using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class ModelDBMigration : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Movies> Movies { get; set; }
    }
    
}