using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_Manager.Models;

namespace Restaurant_Manager.Containers
{
    class OrderContainer
    {

        private Order[] orderArray;
        private int size;
        private int index = 0;

        public OrderContainer(int size)
        {
            this.size = size;
            orderArray = new Order[size];
        }

        public void addOrderElement(Order element)
        {
            orderArray[index++] = element;
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

        public Order getArrayElement(int id)
        {
            return orderArray[id];
        }

        public int getLenght()
        {
            return index;
        }

        public Order[] getArray()
        {
            return orderArray;
        }

    }
}
