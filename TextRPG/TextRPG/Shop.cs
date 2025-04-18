using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Shop
    {
        private List<ShopItem> shopItems = new List<ShopItem>();
        private static Random random = new Random();

        public void GenerateRandomItems()
        {
            shopItems.Clear();
            var randomItems = Item.AllItems.OrderBy(x => random.Next()).Take(4).ToList();

            foreach (var item in randomItems)

            {
                shopItems.Add(new ShopItem(item));
            }
        }


        public void ShowShop(Player player)
        {
            if (shopItems.Count == 0)
            {
                GenerateRandomItems();
            }
            

            while (true)
            {
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.BaseGold}G\n");

                for (int i = 0; i < shopItems.Count; i++)
                {
                    var shopitem = shopItems[i];
                    string isBought = shopitem.IsBought ? "[구매완료]" : "";
                    Console.WriteLine($"{isBought}{shopitem.Item.Name} | {shopitem.Item.GetStatIncrease()} | {shopitem.Item.Decription}|{shopitem.Price}G");
                }
                Console.WriteLine("1.아이템구매");
                Console.WriteLine("0.나가기");
                string select = Console.ReadLine();
                if (select == "1")
                {
                    BuyItem(player);
                }
                else if (select == "0")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("잘못된 입력입니다.");
                    continue;
                }
            }
        }




        public void BuyItem(Player player)
        {
            while (true)
            {
                Console.WriteLine("상점");
                Console.WriteLine("필요한 아이템을 얻을 수 있는 상점입니다.");
                Console.WriteLine("[보유 골드]");
                Console.WriteLine($"{player.BaseGold}G\n");

                for (int i = 0; i < shopItems.Count; i++)
                {
                    var shopitem = shopItems[i];
                    string isBought = shopitem.IsBought ? "[구매완료]" : "";
                    Console.WriteLine($"{i + 1}.{isBought}{shopitem.Item.Name} | {shopitem.Item.GetStatIncrease()} | {shopitem.Item.Decription}|{shopitem.Price}G");
                }

                Console.WriteLine("\n구매할 아이템 번호를 입력하세요");
                Console.WriteLine("0.나가기");
                if (int.TryParse(Console.ReadLine(), out int select))
                {
                    if (select == 0)
                        return;
                    if (select > 0 && select <= shopItems.Count)
                    {
                        var shopItem = shopItems[select - 1];
                        if (shopItem.IsBought)
                        {
                            Console.WriteLine("이미 구매한 아이템입니다.");
                        }

                        else if (player.BaseGold >= shopItem.Price)
                        {
                            player.BaseGold -= shopItem.Price;
                            player.Inventory.AddItem(shopItem.Item);
                            shopItem.IsBought = true;
                            Console.WriteLine($"{shopItem.Item.Name}을(를) 구매 하였습니다.");
                        }


                        else
                        {
                            Console.WriteLine("골드가 부족합니다.");
                        }
                    }
                    else
                    {
                        Console.WriteLine("목록에 있는 번호를 입력하세요");
                    }
                    Console.WriteLine("잘못된 입력입니다.");
                }
            }
        }
    }
}





