using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Npgsql;

namespace TradeFlowers.Model.Dictonary
{
    class CategoryModelContext : DbContext
    {
        public CategoryModelContext() : base("DefaultConnection")
        {

        }
        public DbSet<CategoryModel> CategoryModel { get; set; }
    }
}
