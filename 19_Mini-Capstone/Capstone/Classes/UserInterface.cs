using Capstone.Classes.CateringItemsSubclasses;
using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes
{
    public class UserInterface : Catering
    {
        // This class provides all user communications, but not much else.
        // All the "work" of the application should be done elsewhere

        // ALL instances of Console.ReadLine and Console.WriteLine should 
        // be in this class.
        // NO instances of Console.ReadLine or Console.WriteLIne should be
        // in any other class.

        private Catering catering = new Catering();

        public void RunInterface()
        {
            bool done = false;
            while (!done)
            {
                Console.WriteLine("(1) Display Catering Items");
                Console.WriteLine("(2) Order");
                Console.WriteLine("(3) Quit");
                string userInput = Console.ReadLine();
                Console.WriteLine();
                
                if(userInput=="1")
                {

                    Console.WriteLine("Product Code" + "Description".PadLeft(24) + "Qty".PadLeft(24) + "Price".PadLeft(24));
                    //Column Names&Output

                    //Row Output
                    List<CateringItem> input = catering.CateringItems();
                    CateringItem[] items = catering.GetCateringItems(input);

                    foreach (CateringItem item in items)
                    {
                        
                        Console.WriteLine(" "+item.ProductId.PadRight(24) + item.Name + item.Quantity.ToString().PadLeft(34-item.Name.Length) + "$".PadLeft(23-item.Quantity.ToString().Length) + item.Price.ToString());
                    }
                }
                else if(userInput=="2")
                {
                    decimal balance = 0.00M;
                   

                    Console.WriteLine("(1) Add Money");
                    Console.WriteLine("(2) Select Products");
                    Console.WriteLine("(3) Complete Transaction");
                    Console.WriteLine("Current Account Balance: $" + Balance);
                    string userInput2 = Console.ReadLine();

                    if(userInput2=="1")
                    {
                        try
                        {
                            Console.WriteLine("Please enter a $1, $5, $10, $20, $50 or $100 bill.");
                            int deposit = int.Parse(Console.ReadLine());
                            balance = catering.AddMoney(deposit);
                            Balance = balance;
                            Console.WriteLine("$" + Balance);
                        }
                        catch(IndexOutOfRangeException ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.WriteLine();
                        }
                        
                        
                    }


                }


                //Appetizers testObject = new Appetizers("Meatballs", 1.50);
                //Console.WriteLine(testObject.CateringInventory());
            }

        }
    }
}
