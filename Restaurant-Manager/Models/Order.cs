using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Models
{
    class Order
    {
        public int id { get; set; }

        public DateTime date { get; set; }
        public int[] menuItems { get; set; }

        public Order(int id, DateTime date, int[] menuItems)
        {
            this.id = id;
            this.date = date;
            this.menuItems = menuItems;
        }

        public string arrayAsString()
        {
            return string.Join(" ", menuItems.Select(x => x.ToString()).ToArray());
        }

        public override string ToString()
        {
            return id + " " + date + " " + arrayAsString();

        }

        public string ToStringFile()
        {
            return id + "," + date + "," + arrayAsString();
        }

    }

}
