using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Restaurant_Manager.Models
{
    class Menu
    {
        private int id { get; set; }
        private string name { get; set; }
        private int[] products { get; set; }

        public Menu(int id, string name, int[] products)
        {
            this.id = id;
            this.name = name;
            this.products = products;
        }

        public override string ToString()
        {
            string concatenated = string.Join(" ",products.Select(x => x.ToString()).ToArray());
            return id + " " + name + " " + concatenated;

        }

    }
}
