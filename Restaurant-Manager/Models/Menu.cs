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
        public int id { get; set; }
        public string name { get; set; }
        public int[] products { get; set; }

        public Menu(int id, string name, int[] products)
        {
            this.id = id;
            this.name = name;
            this.products = products;
        }

        public string arrayAsString()
        {
            return string.Join(" ", products.Select(x => x.ToString()).ToArray());
        }

        public override string ToString()
        {
           
            return id + " " + name + " " + arrayAsString();

        }

        public string ToStringFile()
        {
            string concatenated = string.Join(" ", products.Select(x => x.ToString()).ToArray());
            return id + "," + name + "," + arrayAsString();
        }

    }
}
