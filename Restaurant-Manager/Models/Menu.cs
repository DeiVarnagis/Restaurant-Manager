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
        private int id;
        private string name;
        private int[] products;

        public Menu(int id, string name, int[] products)
        {
            this.id = id;
            this.name = name;
            this.products = products;
        }

        public int getID()
        {
            return id;
        }

        public string getName()
        {
            return name;
        }

        public int[] getProducts()
        {
            return products;
        }

        public void setID(int id)
        {
            this.id = id;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setProducts(int[] products)
        {
            this.products = products;
        }

        public string arrayAsString()
        {
            return string.Join(" ", products.Select(x => x.ToString()).ToArray());
        }

        public override string ToString()
        {
         
            return string.Format("|{0,5}|{1,25}|{2,10}|", id, name, arrayAsString());

        }

        public string ToStringFile()
        {
            string concatenated = string.Join(" ", products.Select(x => x.ToString()).ToArray());
            return id + "," + name + "," + arrayAsString();
        }

    }
}
