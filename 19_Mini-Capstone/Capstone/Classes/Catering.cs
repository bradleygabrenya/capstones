using Capstone.Classes.CateringItemsSubclasses;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Capstone.Classes
{
    public class Catering
    {
        //This class should contain all the "work" for catering
        //UserInterface Method
        FileAccess fileAccess = new FileAccess();
        public CateringItem[] GetCateringItems()
        {
            List<CateringItem> items = fileAccess.GetCateringItemList();
            return items.ToArray();
        }

        //Add Money Method
        public decimal Balance { get; set; } = 0.00M;
        public decimal AddMoney(int deposit)
        {
            if (deposit == 1 || deposit == 5 || deposit == 10 || deposit == 20 || deposit == 50 || deposit == 100)
            {
                Balance += deposit;
                if (Balance > 1500.00M)
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

        public void SelectProducts(string productIdInput)
        {
            CateringItem[] results = GetCateringItems();
            foreach (CateringItem item in results)
            {
                if (Balance < item.Price)
                {
                    throw new Exception("Insufficient funds.");
                }
                else if (item.Quantity.ToString() == "SOLD OUT")
                {
                    throw new Exception("Item not available.");
                }
                else if (!fileAccess.inventory.Contains(productIdInput))
                {
                    throw new Exception("Product not found.");
                }
                else if (productIdInput == item.ProductId)
                {
                    item.Quantity -= 1;
                    Balance -= item.Price;
                }
            }

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
