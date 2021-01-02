using System;
using Restaurant_Manager.Models;
using Restaurant_Manager.DataHandler;

namespace Restaurant_Manager.Containers
{
   public class MenuContainer
    {

        private Menu[] menuArray;
        private int index = 0;
        private int lastInserted;
        FileHandler fileHandler;

        public MenuContainer(int size)
        {
            menuArray = new Menu[size];
            fileHandler = new FileHandler();
        }

        public void displayData()
        {
            Console.WriteLine(string.Format("|{0,5}|{1,25}|{2,10}|", "ID", "Name", "Products"));
            for (int i = 0; i < index; i++)
            {
                Console.WriteLine(menuArray[i].ToString());
            }
        }

        public void loadMenuElement(Menu element)
        {
            menuArray[index++] = element;
            lastInserted = element.getID();
        }

        public void addMenuElement(Menu element)
        {
            element.setID(lastInserted + 1);
            lastInserted++;
            menuArray[index++] = element;
            fileHandler.appendMenuData(element);
        }

        public bool deleteMenuElement(int id)
        {
            for (int i = 0; i < index; i++)
            {
                if (menuArray[i].getID() == id)
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

        public bool checkIfElementExist(int id)
        {
            for (int i = 0; i < index; i++)
            {
                if (menuArray[i].getID() == id)
                {
                    return true;
                }
            }
            return false;
        }

        public void updateMenu(Menu element)
        {
            for (int i = 0; i < index; i++)
            {
                if (menuArray[i].getID() == element.getID())
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
                if (menuArray[i].getID() == id)
                {
                    return menuArray[i];
                }
            }
            return null;
        }

        public int getLenght()
        {
            return index;
        }

    }
}
