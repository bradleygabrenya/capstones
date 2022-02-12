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

        //FilePaths
        string fullPath = @"C:\Catering\cateringsystem.csv";
        string destPathLog = @"C:\Catering";
        string destPathSalesRep = @"C:\Catering";
    
        //Inventory/Item List
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

        //Log Output Methods
        public void AddMoneyLog(decimal deposit, decimal currentBalance)
        {
            using (StreamWriter sw = new StreamWriter(@$"{destPathLog}\Log.txt",true))
            {            
                    sw.WriteLine($"{DateTime.Now} ADD MONEY: ${deposit}.00 ${currentBalance}");
            }
        }
        public void ChangeLog(decimal returnBalance)
        {
            using (StreamWriter sw = new StreamWriter(@$"{destPathLog}\Log.txt", true))
            {
                sw.WriteLine($"{DateTime.Now} GIVE CHANGE: ${returnBalance} $0.00");
            }
        }
        public void OrderLog(int quantity, string name, string prodId, decimal totalCost, decimal currentBalance)
        {
            using (StreamWriter sw = new StreamWriter(@$"{destPathLog}\Log.txt", true))
            {
                sw.WriteLine($"{DateTime.Now} {quantity} {name} {prodId} ${totalCost} ${currentBalance}");
            }
        }

        //Sales Report Output Methods
        public void SalesReportLines(int quantity, string name, string prodId, decimal totalCost, decimal currentBalance)
        {
            using (StreamWriter sw = new StreamWriter(@$"{destPathSalesRep}\TotalSales.rpt",true))
            {
                sw.WriteLine($"{name}|{quantity}|${totalCost}");
                
            }
        }
        public void SalesReportEnd(decimal totalCost)
        {
            using (StreamWriter sw = new StreamWriter(@$"{destPathSalesRep}\TotalSales.rpt", true))
            {
                sw.WriteLine($"**TOTAL SALES** ${totalCost}");
            }
        }

    }
}

