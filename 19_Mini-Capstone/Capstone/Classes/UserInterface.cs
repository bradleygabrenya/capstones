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
                    //Column Names&Output

                    //Row Output
                    CateringItem[] items = catering.GetCateringItems();
                    foreach (CateringItem item in items)
                    {
                        Console.WriteLine(item.Name);
                    }
                }


                //Appetizers testObject = new Appetizers("Meatballs", 1.50);
                //Console.WriteLine(testObject.CateringInventory());
            }

        }
    }
}
