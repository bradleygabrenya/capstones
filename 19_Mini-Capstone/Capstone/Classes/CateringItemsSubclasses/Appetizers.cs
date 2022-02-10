using System;
using System.Collections.Generic;
using System.Text;

namespace Capstone.Classes.CateringItemsSubclasses
{
    class Appetizers : CateringItem
    {
        public Appetizers(string name, double price) : base(name, price)
        {

        }

        //public override void CateringInventory()
        //{
        //    base.CateringInventory();
        //    foreach (string item in inventory)
        //    {
        //        if (item.Substring(0, 1) == "A")
        //        {
        //            item.Split("|");
        //            new Appetizers(item[2].ToString(), item[3]);
        //        }
        //    }
        //}

    }
}
