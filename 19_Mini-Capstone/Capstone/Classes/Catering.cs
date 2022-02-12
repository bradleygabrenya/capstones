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
        public List<CateringItem> GetCateringItems()
        {
            List<CateringItem> items = fileAccess.GetCateringItemList();
            return items;
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

        //SelectProducts & Subtract from Balance Method
        public Dictionary<string, int> shoppingCart = new Dictionary<string, int>();
        public decimal SelectProducts(string productIdInput, int quantity)
        {
            Catering catering = new Catering();
            fileAccess.CateringInventory();
            List<CateringItem> results = GetCateringItems();

            foreach (CateringItem item in results)
            {
                if (item.ProductId == productIdInput)
                {
                    if (CurrentBalance < (item.Price * quantity))
                    {
                        throw new Exception("Insufficient funds.");
                    }
                    else if (item.Quantity.ToString() == "SOLD OUT")
                    {
                        throw new Exception("Item not available.");
                    }
                    //else if (!results.Contains(base.productIdInput))
                    //{
                    //    throw new Exception("Product not found.");
                    //}
                    shoppingCart.Add(item.ProductId, quantity);
                    CurrentBalance -= (item.Price * quantity);
                }
            }
            return CurrentBalance;
        }

        public List<CateringItem> CompleteTransaction()
        {
            List<CateringItem> results = fileAccess.GetCateringItemList();

            foreach (KeyValuePair<string, int> kvp in shoppingCart)
            {
                foreach (CateringItem item in results)
                {
                    if (item.ProductId == kvp.Key)
                    {
                        item.Quantity -= kvp.Value;

                    }
                }
            }
            return results;
            
        }

        public string PrintScreen()
        {
            foreach(KeyValuePair<string, int> kvp in shoppingCart)
            {
                string typeOfFood;
                if (kvp.Key.Substring(0,1) == "A")
                {
                     typeOfFood = "Appetizer";
                }
                else if (kvp.Key.Substring(0, 1) == "B")
                {
                     typeOfFood = "Beverage";
                }
                else if (kvp.Key.Substring(0, 1) == "D")
                {
                     typeOfFood = "Dessert";
                }
                else if (kvp.Key.Substring(0, 1) == "E")
                {
                     typeOfFood = "Entree";
                }
                //string shoppingCartOutput = kvp.Value + " " + typeOfFood + kvp.
            }

            int nickels = 0;
            int dimes = 0;
            int quarters = 0;
            int ones = 0;
            int fives = 0;
            int tens = 0;
            int twenties = 0;
            int fifties = 0;

            if (CurrentBalance >= 50.00M)
            {
                fifties = (int)(CurrentBalance % 50.00M);
                CurrentBalance -= (fifties * 50.00M);
            }
            if (CurrentBalance >= 20.00M)
            {
                twenties = (int)(CurrentBalance % 20.00M);
                CurrentBalance -= (twenties * 20.00M);
            }
            if (CurrentBalance >= 10.00M)
            {
                tens = (int)(CurrentBalance % 10.00M);
                CurrentBalance -= (tens * 10.00M);
            }
            if (CurrentBalance >= 5.00M)
            {
                fives = (int)(CurrentBalance % 5.00M);
                CurrentBalance -= (fives * 5.00M);
            }
            if (CurrentBalance >= 1.00M)
            {
                ones = (int)(CurrentBalance % 1.00M);
                CurrentBalance -= (ones * 1.00M);
            }
            if (CurrentBalance >= 0.25M)
            {
                quarters = (int)(CurrentBalance % 0.25M);
                CurrentBalance -= (quarters * 0.25M);
            }
            if (CurrentBalance >= 0.10M)
            {
                dimes = (int)(CurrentBalance % 0.10M);
                CurrentBalance -= (dimes * 0.10M);
            }
            if (CurrentBalance >= 0.05M)
            {
                nickels = (int)(CurrentBalance % 0.05M);
                CurrentBalance -= (nickels * 0.05M);
            }

            string change = "You received";

            if (fifties != 0)
            {
                change += " ,(" + fifties + ") Fifties";
            }
            if (twenties != 0)
            {
                change += " ,(" + twenties + ") Twenties";
            }
            if (tens != 0)
            {
                change += " ,(" + tens + ") Tens";
            }
            if (fives != 0)
            {
                change += " ,(" + fives + ") Fives";
            }
            if (ones != 0)
            {
                change += " ,(" + ones + ") Ones";
            }
            if (quarters != 0)
            {
                change += " ,(" + quarters + ") Quarters";
            }
            if (dimes != 0)
            {
                change += " ,(" + dimes + ") Dimes";
            }
            if (nickels != 0)
            {
                change += " ,(" + nickels + ") Nickels ";
            }
            change += "in change.";
            return change;
        }
    }
}
