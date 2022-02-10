using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class CateringItem
    {
        public CateringItem(string name, double price)
        {
            Name = name;
            Price = price;
            Quantity = 25;
        }

        public double Price { get; set; }
        public string Name { get; private set; }
        public int Quantity { get; }

        string fullPath = @"C:\Users\Student\source\repos\pairs\c-sharp-mini-capstone-module-1-team-0\19_Mini-Capstone\cateringsystem.csv";

        public List<string> inventory = new List<string>();
        public virtual void CateringInventory()
        {
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        inventory.Add(line);
                    }
                }
            }
            catch (IOException ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

    }
}
