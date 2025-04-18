using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class ShopItem
    {
        public Item Item { get; set; }
        public bool IsBought { get; set; }
        public int Price { get; set; }
        private static Random random = new Random();
        public ShopItem(Item item)   
        {
            Item = item;
            Price = item.BasePrice * random.Next(80, 121) / 100;
            IsBought = false;
        }
    }
}
