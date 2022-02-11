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
        public decimal CurrentBalance { get; set; } = 0.00M;
        public decimal AddMoney(decimal deposit)
        {
            if (deposit == 1 || deposit == 5 || deposit == 10 || deposit == 20 || deposit == 50 || deposit == 100)
            {
                CurrentBalance += deposit;

                if (CurrentBalance > 1500.00M)
                {
                    throw new IndexOutOfRangeException("Balance cannot exceed $1500.");
                }
            }
            else
            {
                throw new IndexOutOfRangeException("Not a valid bill.");
            }
            return CurrentBalance;
        }
        public List<CateringItem> SelectProducts(string productIdInput, decimal CurrentBalance)
        {
            Catering catering = new Catering();
            List<CateringItem> results = fileAccess.GetCateringItemList();
            foreach (CateringItem item in results)
            {
                if (CurrentBalance < item.Price)
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
                else if (item.ProductId.Contains(productIdInput))
                {
                    item.Quantity -= 1;
                    CurrentBalance -= item.Price;
                }
            }
            catering.CurrentBalance = CurrentBalance;
            return results;
        }


        

    }
}
