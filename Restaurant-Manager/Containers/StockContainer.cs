using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_Manager.Models;
using Restaurant_Manager.DataHandler;


namespace Restaurant_Manager.Containers
{
    class StockContainer
    {

        private Stock[] stocksArray;
        private int index = 0;
        private int lastInserted;
        FileHandler fileHandler;

        public StockContainer(int size)
        {
            stocksArray = new Stock[size];
            fileHandler = new FileHandler();
        }

        public void displayData()
        {
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(stocksArray[i].ToString());
            }
        }

        public void loadStockElement(Stock element)
        {
            stocksArray[index++] = element;
            lastInserted = element.id;
        }

        public void addStockElement(Stock element)
        {
            element.id = lastInserted +1;
            lastInserted++;
            stocksArray[index++] = element;
            fileHandler.appendStockData(element);
        }

        public bool deleteStockElement(int id)
        {
            for (int i = 0; i < index; i++)
            {
                if(stocksArray[i].id == id)
                {
                    for (int j = i; j < index - 1; j++)
                    {
                        stocksArray[i] = stocksArray[j+1];
                    }
                    index--;
                    fileHandler.rewriteData(this);
                    return true;
                }
            }

            return false;
        }

        public void updateStock(Stock element)
        {
            for (int i = 0; i < index; i++)
            {
                if (stocksArray[i].id == element.id)
                {
                    stocksArray[i] = element;
                    fileHandler.rewriteData(this);
                }
            }
        }

        public Stock getArrayElement(int id)
        {
            return stocksArray[id];
        }

        public Stock getArrayElementByID(int id)
        {
            for (int i = 0; i < index; i++)
            {
                if(stocksArray[i].id == id)
                {
                    return stocksArray[i];
                }
            }
            return null;
        }

        public bool checkIfElementExist(int id)
        {
            for (int i = 0; i < index; i++)
            {
                if (stocksArray[i].id == id)
                {
                    return true;
                }
            }
            return false;
        }

        public int getLenght()
        {
            return index;
        }

    }
}
