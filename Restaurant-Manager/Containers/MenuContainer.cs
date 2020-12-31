﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Restaurant_Manager.Models;
using Restaurant_Manager.DataHandler;

namespace Restaurant_Manager.Containers
{
    class MenuContainer
    {

        private Menu[] menuArray;
        private int size;
        private int index = 0;
        private int lastInserted;
        FileHandler fileHandler;

        public MenuContainer(int size)
        {
            this.size = size;
            menuArray = new Menu[size];
            fileHandler = new FileHandler();
        }

        public void displayData()
        {
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(menuArray[i].ToString());
            }
        }

        public void loadStockElement(Menu element)
        {
            menuArray[index++] = element;
            lastInserted = element.id;
        }

        public void addMenuElement(Menu element)
        {
            element.id = lastInserted + 1;
            lastInserted++;
            menuArray[index++] = element;
            fileHandler.appendMenuData(element);
        }

        public bool deleteStockElement(int id)
        {
            for (int i = 0; i < index; i++)
            {
                if (menuArray[i].id == id)
                {
                    for (int j = i; j < index - 1; j++)
                    {
                        menuArray[i] = menuArray[j + 1];
                    }
                    index--;
                    fileHandler.rewriteDataMenu(this);
                    return true;
                }
            }

            return false;
        }

        public void updateMenu(Menu element)
        {
            for (int i = 0; i < index; i++)
            {
                if (menuArray[i].id == element.id)
                {
                    menuArray[i] = element;
                    fileHandler.rewriteDataMenu(this);
                }
            }
        }

        public Menu getArrayElement(int id)
        {
            return menuArray[id];
        }

        public Menu getArrayElementByID(int id)
        {
            for (int i = 0; i < index; i++)
            {
                if (menuArray[i].id == id)
                {
                    return menuArray[i];
                }
            }
            return null;
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
