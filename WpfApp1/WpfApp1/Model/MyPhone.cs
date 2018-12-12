using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1
{
    class MyPhone
    {
        public MyPhone(string Id, string name)
        {
            this.Id = Id;
            this.Name = name;
          
        }
        public string Id { get; set; }
        public string Name { get; set; }
       
    }
}
