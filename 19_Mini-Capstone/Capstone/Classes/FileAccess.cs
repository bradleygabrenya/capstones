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
        string destPath = @"C:\Users\Student\source\repos\pairs\c-sharp-mini-capstone-module-1-team-0\19_Mini-Capstone";
        
        //Items List
        //Inventory List
        
        public List<CateringItem> CateringInventory()
        {
            List<CateringItem> items = new List<CateringItem>();
            try
            {
                using (StreamReader sr = new StreamReader(fullPath))
                {
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
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
            return items;
        }
        //public void AuditLog()
        //{
        //    try
        //    {
        //        using (StreamWriter sw = new StreamWriter(destPath)
        //        {
        //            if ()
        //                    sw.WriteLine($"{DateTime.Now}" + );
        //        }

        //    }
        //    catch
        //    {
        //    }
        }
         


    }

