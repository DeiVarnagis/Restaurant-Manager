using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_Manager.Containers;
using Restaurant_Manager.Models;
using System.IO;

namespace Restaurant_Manager.DataHandler
{
    class FileHandler
    {
        private const string STOCKS = "stocks.csv";
        private const string MENU = "menu.csv";
        private const string ORDERS = "order.csv";
        public FileHandler(){}

        public void readStockData(StockContainer container)
        {
            using (var reader = new StreamReader(STOCKS))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    Stock stock = new Stock(int.Parse(values[0]), values[1], int.Parse(values[2]), values[3], double.Parse(values[4]));
                    container.loadStockElement(stock);
                }
            }
        }

        public void appendStockData(Stock stock)
        {
            File.AppendAllText(STOCKS, stock.ToStringFile()+ Environment.NewLine);
        }

        public void appendMenuData(Menu menu)
        {
            
            File.AppendAllText(MENU, menu.ToStringFile() + Environment.NewLine);
        }

        /* public void appendOrderData(Order order)
         {
             File.AppendAllText(MENU, stock.ToStringFile()+ Environment.NewLine);
         }*/

        public void rewriteData(StockContainer stockContainer)
        {
            using (StreamWriter file = new StreamWriter(STOCKS))
            {
                for (int i = 0; i < stockContainer.getLenght(); i++)
                {
                    file.WriteLine(stockContainer.getArrayElement(i).ToStringFile());
                    
                }
            }
        }

        public void rewriteDataMenu(MenuContainer menuContainer)
        {
            using (StreamWriter file = new StreamWriter(MENU))
            {
                for (int i = 0; i < menuContainer.getLenght(); i++)
                {
                    file.WriteLine(menuContainer.getArrayElement(i).ToStringFile());

                }
            }
        }


        public void readMenuData(MenuContainer container)
        {
            using (var reader = new StreamReader(MENU))
            {
                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var values = line.Split(',');
                    var arrayElements = values[2].Split(' ');
                    int[] productsArray = new int[arrayElements.Length];
                    for (int i = 0; i < arrayElements.Length; i++)
                    {
                        productsArray[i] = int.Parse(arrayElements[i]);
                    }
                    Menu menu = new Menu(int.Parse(values[0]), values[1] ,productsArray);
                    container.loadStockElement(menu);
                }
            }
        }

         public void readOrderData(OrderContainer container)
         {
             using (var reader = new StreamReader(ORDERS))
             {
                 while (!reader.EndOfStream)
                 {
                     var line = reader.ReadLine();
                     var values = line.Split(',');
                     var arrayElements = values[2].Split(' ');
                     int[] productsArray = new int[arrayElements.Length];
                     for (int i = 0; i < arrayElements.Length; i++)
                     {
                         productsArray[i] = int.Parse(arrayElements[i]);
                     }
                     Order menu = new Order(int.Parse(values[0]), DateTime.Parse(values[1]) ,productsArray);
                     container.addOrderElement(menu);
                 }
             }
         }
    }
}
