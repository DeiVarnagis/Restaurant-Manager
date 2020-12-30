using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_Manager.Models;

namespace Restaurant_Manager.Containers
{
    class MenuContainer
    {

        private Menu[] menuArray;
        private int size;
        private int index = 0;

        public MenuContainer(int size)
        {
            this.size = size;
            menuArray = new Menu[size];
        }

        public void addMenuElement(Menu element)
        {
            menuArray[index++] = element;
        }

        /* public void deleteStockElement(int id)
         {
             for (int i = 0; i < index; i++)
             {
                 if(stocksArray[i].id == id)
                 {

                 }
             }
         }*/

        public Menu getArrayElement(int id)
        {
            return menuArray[id];
        }

        public Menu[] getArray()
        {
            return menuArray;
        }

        public int getLenght()
        {
            return index;
        }

    }
}
