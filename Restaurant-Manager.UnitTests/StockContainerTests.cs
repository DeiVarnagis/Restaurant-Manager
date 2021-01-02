using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant_Manager.Containers;
using Restaurant_Manager.Models;

namespace Restaurant_Manager.UnitTests
{
    [TestClass]
    public class StockContainerTests
    {
        [TestMethod]
        public void deleteStockElement_IdExist_ReturnsTrue()
        {
            int SIZE = 50;
            StockContainer stockContainer = new StockContainer(SIZE);
            stockContainer.loadStockElement(new Stock(10, "Pigy", 10, "kg", 0.5));
            var result = stockContainer.deleteStockElement(10);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void deleteStockElement_IdNotFound_ReturnsFalse()
        {
            int SIZE = 50;
            StockContainer stockContainer = new StockContainer(SIZE);
            var result = stockContainer.deleteStockElement(8);
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void getArrayElementByID_IdExist_ReturnTheValue()
        {
            int SIZE = 50;
            StockContainer stockContainer = new StockContainer(SIZE);
            stockContainer.loadStockElement(new Stock(10, "Pigy", 10, "kg", 0.5));
            var result = stockContainer.getArrayElementByID(10);
            Assert.IsNotNull(result);

        }

        [TestMethod]
        public void getArrayElementByID_IdNotFound_ReturnNull()
        {
            int SIZE = 50;
            StockContainer stockContainer = new StockContainer(SIZE);
            var result = stockContainer.getArrayElementByID(8);
            Assert.IsNull(result);

        }

        [TestMethod]
        public void checkIfElementExist_IdExist_ReturnTrue()
        {
            int SIZE = 50;
            StockContainer stockContainer = new StockContainer(SIZE);
            stockContainer.loadStockElement(new Stock(10, "Pigy", 10, "kg", 0.5));
            var result = stockContainer.checkIfElementExist(10);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void checkIfElementExist_IdNotFound_ReturnFalse()
        {
            int SIZE = 50;
            StockContainer stockContainer = new StockContainer(SIZE);
            var result = stockContainer.checkIfElementExist(8);
            Assert.IsFalse(result);

        }

        [TestMethod]
        public void deductStocks_EnoughStocks_ReturnTrue()
        {
            int SIZE = 50;
            StockContainer stockContainer = new StockContainer(SIZE);
            stockContainer.loadStockElement(new Stock(10, "Pigy", 10, "kg", 0.5));
            MenuContainer menuContainer = new MenuContainer(SIZE);
            int[] products = { 10 };
            menuContainer.loadMenuElement(new Menu(1, "Smoked Pigy", products));
            int[] menuItems = { 1 };
            Order order = new Order(1, DateTime.Now, menuItems);
            var result = stockContainer.deductStocks(order, menuContainer);
            Assert.IsTrue(result);

        }

        [TestMethod]
        public void deductStocks_StockRunOut_ReturnFalse()
        {
            int SIZE = 50;
            StockContainer stockContainer = new StockContainer(SIZE);
            stockContainer.loadStockElement(new Stock(10, "Pigy", 0, "kg", 0.5));
            MenuContainer menuContainer = new MenuContainer(SIZE);
            int[] products = { 10 };
            menuContainer.loadMenuElement(new Menu(1, "Smoked Pigy", products));
            int[] menuItems = { 1 };
            Order order = new Order(1, DateTime.Now, menuItems);
            var result = stockContainer.deductStocks(order, menuContainer);
            Assert.IsFalse(result);

        }

    }
}
