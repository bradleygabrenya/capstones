using Capstone.Classes.CateringItemsSubclasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class FileAccess 
    {
        // Read from inventory, write to log
        // all files for this application should in this directory
        // you will likley need to create it on your computer
        // private string filePath = @"C:\Catering";
        // This class should contain any and all details of access to files
        //FilePath
        string fullPath = @"C:\Users\Student\source\repos\pairs\c-sharp-mini-capstone-module-1-team-0\19_Mini-Capstone\cateringsystem.csv";

        //Inventory List
        public List<string> inventory = new List<string>();
        //Items List
        private List<CateringItem> items = new List<CateringItem>();
        public List<CateringItem> GetCateringItemList()
        {
            return items;
        }

        public void CateringInventory()
        {
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        inventory.Add(line);
                        string[] results = line.Split("|");
                        if (line.Substring(0, 1) == "A")
                        {
                            Appetizers appList = new Appetizers(results[2].ToString(), decimal.Parse(results[3]), results[1]);
                            items.Add(appList);
                        }
                        if (line.Substring(0, 1) == "B")
                        {                           
                            Beverages appList = new Beverages(results[2].ToString(), decimal.Parse(results[3]), results[1]);
                            items.Add(appList);
                        }
                        if (line.Substring(0, 1) == "D")
                        {
                            Desserts appList = new Desserts(results[2].ToString(), decimal.Parse(results[3]), results[1]);
                            items.Add(appList);
                        }
                        if (line.Substring(0, 1) == "E")
                        {
                            Entrees appList = new Entrees(results[2].ToString(), decimal.Parse(results[3]), results[1]);
                            items.Add(appList);
                        }
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
