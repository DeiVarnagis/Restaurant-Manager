using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Models
{
    public class Order
    {
        private int id { get; set; }

        private DateTime date { get; set; }
        private int[] menuItems { get; set; }

        public Order(int id, DateTime date, int[] menuItems)
        {
            this.id = id;
            this.date = date;
            this.menuItems = menuItems;
        }

        public int getID()
        {
            return id;
        }

        public DateTime getDate()
        {
            return date;
        }

        public int[] getMenuItems()
        {
            return menuItems;
        }

        public void setID(int id)
        {
            this.id = id;
        }

        public void setDate(DateTime date)
        {
            this.date = date;
        }

        public void setMenuItems(int[] menuItems)
        {
            this.menuItems = menuItems;
        }

        public string arrayAsString()
        {
            return string.Join(" ", menuItems.Select(x => x.ToString()).ToArray());
        }

        public override string ToString()
        {
            return string.Format("|{0,5}|{1,25}|{2,15}|", id, date, arrayAsString());

        }

        public string ToStringFile()
        {
            return id + "," + date + "," + arrayAsString();
        }

    }

}
