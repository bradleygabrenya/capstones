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

        public virtual void CateringItem()
        {
            foreach(string item in inventory)
            {
                if (item.Substring(0, 1) == "A")
                {
                    item.Split("|");
                    Appetizers appList = new Appetizers(item[2].ToString(), item[3]);
                    items.Add(appList);
                }
                if (item.Substring(0, 1) == "B")
                {
                    item.Split("|");
                    Beverages appList = new Beverages(item[2].ToString(), item[3]);
                    items.Add(appList);
                }
                if (item.Substring(0, 1) == "D")
                {
                    item.Split("|");
                    Desserts appList = new Desserts(item[2].ToString(), item[3]);
                    items.Add(appList);
                }
                if (item.Substring(0, 1) == "E")
                {
                    item.Split("|");
                    Entrees appList = new Entrees(item[2].ToString(), item[3]);
                    items.Add(appList);
                }
            }
        }

        //UserInterface Method
        public virtual CateringItem[] GetCateringItems()
        {
            Catering catering = new Catering();
            catering.CateringItem();
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
