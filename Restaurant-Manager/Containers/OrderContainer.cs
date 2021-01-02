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
            Console.WriteLine(string.Format("|{0,5}|{1,25}|{2,15}|", "ID", "Date", "Menu Items"));
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(orderArray[i].ToString());
            }
        }

        public void loadOrderElement(Order element)
        {
            orderArray[index++] = element;
            lastInserted = element.getID();
        }

        public void addOrderElement(Order element)
        {
            element.setID(lastInserted + 1);
            lastInserted++;
            orderArray[index++] = element;
            fileHandler.appendOrderData(element);
        }
    }
}
