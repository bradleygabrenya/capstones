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

        //Items List
        private List<CateringItem> items = new List<CateringItem>();

        public virtual List<CateringItem> CateringItems()
        {
            foreach(string item in inventory)
            {
                if (item.Substring(0, 0) == "A")
                {
                    string[] results = item.Split("|");
                    Appetizers appList = new Appetizers(results[2].ToString(), double.Parse(results[3]));
                    items.Add(appList);
                }
                if (item.Substring(0, 1) == "B")
                {
                    string[] results = item.Split("|");
                    Beverages appList = new Beverages(results[2].ToString(), double.Parse(results[3]));
                    items.Add(appList);
                }
                if (item.Substring(0, 1) == "D")
                {
                    string[] results = item.Split("|");
                    Desserts appList = new Desserts(results[2].ToString(), double.Parse(results[3]));
                    items.Add(appList);
                }
                if (item.Substring(0, 1) == "E")
                {
                    string[] results = item.Split("|");
                    Entrees appList = new Entrees(results[2].ToString(), double.Parse(results[3]));
                    items.Add(appList);
                }
            }
            return items;
        }

        //UserInterface Method
        public virtual CateringItem[] GetCateringItems()
        {
            Catering catering = new Catering();
            catering.CateringItems();
            CateringItem[] results = items.ToArray();
            return results;
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
