using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Restaurant_Manager.Models
{
    public class Stock
    {

        private int id { get; set; }
        private string name { get; set; }
        private int portionCount { get; set; }
        private string unit { get; set; }
        private double portionSize { get; set; }

        public Stock(int id, string name, int portionCount,  string unit, double portionSize)
        {
            this.id = id;
            this.name = name;
            this.portionCount = portionCount;
            this.unit = unit;
            this.portionSize = portionSize;
        }

        public int getID()
        {
            return id;
        }

        public string getName()
        {
            return name;
        }

        public int getPortionCount()
        {
            return portionCount;
        }

        public string getUnit()
        {
            return unit;
        }

        public double getPortionSize()
        {
            return portionSize;
        }

        public void setID(int id)
        {
            this.id = id;
        }

        public void setName(string name)
        {
            this.name = name;
        }

        public void setPortionCount(int portionCount)
        {
            this.portionCount = portionCount;
        }

        public void setUnit(string unit)
        {
            this.unit = unit;
        }

        public void setPortionSize(double portionSize)
        {
            this.portionSize = portionSize;
        }


        public override string ToString()
        {
            return string.Format("|{0,5}|{1,15}|{2,15}|{3,5}|{4,15}|", id, name, portionCount, unit, portionSize);
        }

        public string ToStringFile()
        {
            return id + "," + name + "," + portionCount + "," + unit + "," + portionSize;
        }
    }
}
