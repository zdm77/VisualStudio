using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace TradeFlowers.Model.Dictonary
{
    class CategoryModel
    {
        private int Id { get; set; }
        private int PId { get; set; }
        private string Name { get; set; }
        private int OrderBy { get; set; }
    }
}
