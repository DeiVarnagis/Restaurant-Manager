using System;
using System.Collections.Generic;
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
            Console.WriteLine(string.Format("|{0,5}|{1,15}|{2,15}|{3,5}|{4,15}|", "id", "Name", "Portion Count", "Unit", "Portion Size")); 
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(stocksArray[i].ToString());
            }
        }

        public void loadStockElement(Stock element)
        {
            stocksArray[index++] = element;
            lastInserted = element.getID();
        }

        public void addStockElement(Stock element)
        {
            element.setID(lastInserted + 1);
            lastInserted++;
            stocksArray[index++] = element;
            fileHandler.appendStockData(element);
        }

        public bool deleteStockElement(int id)
        {
            for (int i = 0; i < index; i++)
            {
                if(stocksArray[i].getID() == id)
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
                if (stocksArray[i].getID() == element.getID())
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
                if(stocksArray[i].getID() == id)
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
                if (stocksArray[i].getID() == id)
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

        public List<int> getAllStocksUsed(Order order, MenuContainer menuContainer)
        {
            List<int> usedProducts = new List<int>();
            int[] menuItems = order.getMenuItems();
            for (int i = 0; i < menuItems.Length; i++)
            {
                Menu menuItem = menuContainer.getArrayElementByID(menuItems[i]);
                int[] products = menuItem.getProducts();
                if (menuItem != null)
                {
                    for (int j = 0; j < products.Length; j++)
                    {
                        usedProducts.Add(products[j]);
                    }              
                }
            }
            return usedProducts;
        }


        public bool deductStocks(Order order, MenuContainer menuContainer)
        {
            List<int> stocksUsed = getAllStocksUsed(order, menuContainer);
            foreach (var stock in stocksUsed)
            {
                for (int i = 0; i < index; i++)
                {
                    if(stocksArray[i].getID() == stock)
                    {
                        stocksArray[i].setPortionCount(stocksArray[i].getPortionCount() - 1);
                        if (stocksArray[i].getPortionCount() < 1)
                        {
                            return false;
                        }
                    }
                }
            }
            fileHandler.rewriteData(this);
            return true;
        }




    }
}
