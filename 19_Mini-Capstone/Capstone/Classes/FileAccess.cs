using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class FileAccess
    {
        //Read from inventory, write to log
        // all files for this application should in this directory
        // you will likley need to create it on your computer
        //private string filePath = @"C:\Catering";

        //FilePath
        private string fullPath = @"C:\Users\Student\source\repos\pairs\c-sharp-mini-capstone-module-1-team-0\19_Mini-Capstone\cateringsystem.csv";

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


        // This class should contain any and all details of access to files
    }
}
