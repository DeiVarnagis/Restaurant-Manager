using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant_Manager.Containers;
using Restaurant_Manager.Models;

namespace Restaurant_Manager.UnitTests
{
    [TestClass]
    public class MenuContainerTests
    {
        [TestMethod]
        public void deleteMenuElement_IdExist_ReturnsTrue()
        {
            int SIZE = 50;
            MenuContainer menuContainer = new MenuContainer(SIZE);
            int[] products = { 10 };
            menuContainer.loadMenuElement(new Menu(10,"Smoked Pork", products));
            var result = menuContainer.deleteMenuElement(10);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void deleteMenuElement_IdNotFound_ReturnsFalse()
        {
            int SIZE = 50;
            MenuContainer menuContainer = new MenuContainer(SIZE);     
            var result = menuContainer.deleteMenuElement(10);
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void checkIfElementExist_IdExist_ReturnTrue()
        {
            int SIZE = 50;
            MenuContainer menuContainer = new MenuContainer(SIZE);
            int[] products = { 10 };
            menuContainer.loadMenuElement(new Menu(10, "Smoked Pork", products));
            var result = menuContainer.checkIfElementExist(10);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void checkIfElementExist_IdNotFound_ReturnFalse()
        {
            int SIZE = 50;
            MenuContainer menuContainer = new MenuContainer(SIZE);
            var result = menuContainer.checkIfElementExist(10);
            Assert.IsFalse(result);
        }
    }
}
