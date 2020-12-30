using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Restaurant_Manager.Containers;
using Restaurant_Manager.Models;
using Restaurant_Manager.DataHandler;
using System.Text.RegularExpressions;

namespace Restaurant_Manager
{
    class Program
    {
        private const int SIZE = 50; 

        static void Main(string[] args)
        {
            FileHandler fileHandler = new FileHandler();
            StockContainer stockContainer = new StockContainer(SIZE);
            MenuContainer menuContainer = new MenuContainer(SIZE);
            OrderContainer orderContainer = new OrderContainer(SIZE);
            fileHandler.readStockData(stockContainer);
            fileHandler.readMenuData(menuContainer);
            fileHandler.readOrderData(orderContainer);

            while(true)
            {
                Console.WriteLine("Choose an option from the following list:");
                Console.WriteLine("\tds - Display Stock");
                Console.WriteLine("\tdm - Display Menu");
                Console.WriteLine("\tdo - Display Orders");
                Console.WriteLine("\tas - Add new stock element");
                Console.WriteLine("\tam - Add new menu element");
                Console.WriteLine("\tao - Add new order element");
                Console.WriteLine("\trs - Remove stock element");
                Console.WriteLine("\trm - Remove menu element");
                Console.WriteLine("\tro - Remove order element");
                Console.WriteLine("\tus - Update stock element");
                Console.WriteLine("\tum - Update menu element");
                Console.WriteLine("\tuo - Update order element");

                switch (Console.ReadLine())
                {
                    case "ds":
                        for (int i = 0; i < stockContainer.getLenght(); i++)
                        {
                            Console.WriteLine(stockContainer.getArrayElement(i).ToString());
                        }
                        break;
                    case "dm":
                        for (int i = 0; i < menuContainer.getLenght(); i++)
                        {
                            Console.WriteLine(menuContainer.getArrayElement(i).ToString());
                        }
                        break;
                    case "do":
                        for (int i = 0; i < orderContainer.getLenght(); i++)
                        {
                            Console.WriteLine(orderContainer.getArrayElement(i).ToString());
                        }
                        break;
                    case "as":
                        {
                            int portionCount;
                            string unit;
                            double portionSize;
                            Console.WriteLine("Write the Name of the Stock");
                            string name = Console.ReadLine();
                            Console.WriteLine("Write the Portion Count of the Stock");
                            while(true)
                            {
                                string line = Console.ReadLine();
                                if (Regex.IsMatch(line, @"^\d+$"))
                                {
                                    portionCount = int.Parse(line);
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Portion count must be a number");
                                }
                            }
                            while(true)
                            {
                                Console.WriteLine("What kind of unit type? kg/lb");
                                string line = Console.ReadLine();
                                if(line == "kg" || line == "lb")
                                {
                                    unit = line;
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please Select between kg/lb");
                                }
                            }
                            while (true)
                            {
                                Console.WriteLine("How much is one portion Size?");
                                string line = Console.ReadLine();
                                if (Regex.IsMatch(line, @"^\d*\.?\d*$"))
                                {
                                    portionSize = double.Parse(line);
                                    Console.WriteLine("New stock element was successfully added");
                                    break;
                                }
                                else
                                {
                                    Console.WriteLine("Please write a number");
                                }
                            }
                            Stock stock = new Stock(0, name, portionCount, unit, portionSize);
                            stockContainer.addStockElement(stock);
                            break;

                        }
                    case "rs":
                        {
                            for (int i = 0; i < stockContainer.getLenght(); i++)
                            {
                                Console.WriteLine(stockContainer.getArrayElement(i).ToString());
                            }
                            Console.WriteLine();
                            Console.WriteLine("Please write the id of the row in order to delete it");
                            while (true)
                            {
                                string line = Console.ReadLine();
                                if (Regex.IsMatch(line, @"^\d+$"))
                                {
                                    if (stockContainer.deleteStockElement(int.Parse(line)))
                                    {
                                        Console.WriteLine("Row was deleted");
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("Ups, can't find the id. Try again");
                                    }

                                }
                                else
                                {
                                    Console.WriteLine("ID is a number");


                                }
                            }
                            break;
                        }                    
                    case "us":
                        {
                            for (int i = 0; i < stockContainer.getLenght(); i++)
                            {
                                Console.WriteLine(stockContainer.getArrayElement(i).ToString());
                            }
                            Console.WriteLine();
                            Console.WriteLine("Please write the id of the row in order to update it");
                            string id = Console.ReadLine();
                            if (Regex.IsMatch(id, @"^\d+$"))
                            {
                                Stock selectedElement = stockContainer.getArrayElementByID(int.Parse(id));
                                if (selectedElement != null)
                                {
                                    int portionCount = selectedElement.portionCount;
                                    string unit = selectedElement.unit;
                                    double portionSize = selectedElement.portionSize;
                                    string name = selectedElement.name;
                                    Console.WriteLine(selectedElement.ToString());
                                    Console.WriteLine();
                                    while (true)
                                    {
                                        Console.WriteLine("Choose an option from the following list:");
                                        Console.WriteLine();
                                        Console.WriteLine("\tname - Update name current->" + name);
                                        Console.WriteLine("\tcount - Update Portion Count - current ->" + portionCount);
                                        Console.WriteLine("\tunit - Update Unit - current ->" + unit);
                                        Console.WriteLine("\tsize - Update Portion size - current ->" + portionSize);
                                        Console.WriteLine("\tdone - to submit");
                                        string value = Console.ReadLine();
                                        switch (value)
                                        {
                                            case "name":
                                                {
                                                    Console.WriteLine("Write new name of the stock element");
                                                    name = Console.ReadLine();
                                                    break;
                                                }
                                            case "count":
                                                {
                                                    Console.WriteLine("Write new Portion Count of the stock element");                                                
                                                    while (true)
                                                    {
                                                        string line = Console.ReadLine();
                                                        if (Regex.IsMatch(line, @"^\d+$"))
                                                        {
                                                            portionCount = int.Parse(line);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Portion count must be a number");
                                                        }
                                                    }
                                                    break;
                                                }
                                            case "unit":
                                                {
                                                    Console.WriteLine("Write new Unit of the stock element");                                                
                                                    while(true)
                                                    {
                                                        string value1 = Console.ReadLine();
                                                        if (value1 == "kg" || value1 == "lb")
                                                        {
                                                            unit = value1;
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Please Select between kg/lb");
                                                        }
                                                    }
                                                  
                                                    break;
                                                }
                                            case "size":
                                                {
                                                    Console.WriteLine("Write new Portion Size of the stock element");
                                                    while (true)
                                                    {                                                
                                                        string value2 = Console.ReadLine();
                                                        if (Regex.IsMatch(value2, @"^\d*\.?\d*$"))
                                                        {
                                                            portionSize = double.Parse(value2);
                                                            break;
                                                        }
                                                        else
                                                        {
                                                            Console.WriteLine("Size must be a number");
                                                        }
                                                    }
                                                    break;
                                                }                                                                                    
                                        }
                                        if(value == "done")
                                        {
                                            Console.WriteLine("Stock element was updated");
                                            Stock stock = new Stock(selectedElement.id, name, portionCount, unit, portionSize);
                                            stockContainer.updateStock(stock);
                                            break;
                                        }
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("Ups, can't find the id. Try again");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Ups, can't find the id. Try again");
                            }
                            break;
                        }                      
                }             
            }        
        }
    }
}
