using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TradeFlowers.Model.Dictonary
{
   
    class ProductModel
    {
        private int _id;
        private string _name;
        //private int _pid;
        public ProductModel(int Id, string name)
        {
            this._id = Id;
            this._name = name;
            //this._pid = pid;

        }
        public int Id { get => _id; set => _id = value; }
        public string Name { get => _name; set => _name = value; }
       // public int PId { get => _pid; set => _pid = value; }
    }
}
