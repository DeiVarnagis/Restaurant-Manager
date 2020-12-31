using System;
using Restaurant_Manager.Models;
using Restaurant_Manager.DataHandler;

namespace Restaurant_Manager.Containers
{
    class OrderContainer
    {

        private Order[] orderArray;
        private int index = 0;
        private int lastInserted;
        FileHandler fileHandler;

        public OrderContainer(int size)
        {
            orderArray = new Order[size];
            fileHandler = new FileHandler();
        }

        public void displayData()
        {
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(orderArray[i].ToString());
            }
        }

        public void loadOrderElement(Order element)
        {
            orderArray[index++] = element;
            lastInserted = element.id;
        }

        public void addOrderElement(Order element)
        {
            element.id = lastInserted + 1;
            lastInserted++;
            orderArray[index++] = element;
            fileHandler.appendOrderData(element);
        }
    }
}
