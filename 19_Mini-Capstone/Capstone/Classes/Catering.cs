using Capstone.Classes.CateringItemsSubclasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        // This class should contain all the "work" for catering

        //FilePath
        string fullPath = @"C:\Users\Student\source\repos\pairs\c-sharp-mini-capstone-module-1-team-0\19_Mini-Capstone\cateringsystem.csv";

        //Inventory List
        public List<string> inventory = new List<string>();
        public List<string> CateringInventory()
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
            inventory.Sort();
            return inventory;
        }

        //Items List
        private List<CateringItem> items = new List<CateringItem>();

        public List<CateringItem> CateringItems()
        {
            Catering testobject = new Catering();
            List<string> inventory = testobject.CateringInventory();

            foreach(string item in inventory)
            {
                if (item.Substring(0, 1) == "A")
                {
                    string[] results = item.Split("|");
                    Appetizers appList = new Appetizers(results[2].ToString(), decimal.Parse(results[3]), results[1]);
                    items.Add(appList);
                }
                if (item.Substring(0, 1) == "B")
                {
                    string[] results = item.Split("|");
                    Beverages appList = new Beverages(results[2].ToString(), decimal.Parse(results[3]), results[1]);
                    items.Add(appList);
                }
                if (item.Substring(0, 1) == "D")
                {
                    string[] results = item.Split("|");
                    Desserts appList = new Desserts(results[2].ToString(), decimal.Parse(results[3]), results[1]);
                    items.Add(appList);
                }
                if (item.Substring(0, 1) == "E")
                {
                    string[] results = item.Split("|");
                    Entrees appList = new Entrees(results[2].ToString(), decimal.Parse(results[3]), results[1]);
                    items.Add(appList);
                }
            }
            return items;
        }

        //UserInterface Method
        public CateringItem[] GetCateringItems(List<CateringItem> input)
        {
            CateringItem[] results = input.ToArray();
            return results;
        }

        //Add Money Method
        public decimal Balance { get; set; } = 0.00M;
        public decimal AddMoney(int deposit)
        {
            if (deposit==1 || deposit == 5 || deposit == 10 || deposit == 20 || deposit == 50 || deposit == 100 )
            {
                Balance += deposit;
                if(Balance>1500.00M)
                {
                    throw new IndexOutOfRangeException("Balance cannot exceed $1500.");
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Not a valid bill.");
            }

            return Balance;
        }











        //string fullPath = @"C:\Users\Student\source\repos\pairs\c-sharp-mini-capstone-module-1-team-0\19_Mini-Capstone\cateringsystem.csv";

        //foreach(string item in inventory)
        //public virtual void CateringInventory()
        //{
        //    try
        //    {
        //        using (StreamReader sr = new StreamReader(fullPath))
        //        {
        //            while (!sr.EndOfStream)
        //            {
        //                string line = sr.ReadLine();
        //                items.Add(line);
        //            }
        //        }
        //    }
        //    catch (IOException ex)
        //    {
        //        Console.WriteLine("An error occurred: " + ex.Message);
        //    }
        //}

    }
}
