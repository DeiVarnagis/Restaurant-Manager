using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Models
{
    class Order
    {
        private int id { get; set; }

        private DateTime date;
        private int[] menuItems { get; set; }

        public Order(int id, DateTime date, int[] menuItems)
        {
            this.id = id;
            this.date = date;
            this.menuItems = menuItems;
        }

        public override string ToString()
        {
            string concatenated = string.Join(" ", menuItems.Select(x => x.ToString()).ToArray());
            return id + " " + date + " " + concatenated;

        }

    }

}
