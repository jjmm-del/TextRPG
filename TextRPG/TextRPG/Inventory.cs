using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Inventory
    {
        private List<Item> items = new List<Item>();
        public void AddItem(Item item)
        {
            items.Add(item);
        }

        public void ShowInventory()
        {
            Console.WriteLine("인벤토리");
            Console.WriteLine("보유 중인 아이템을 관리할 수 있습니다.\n");

            if (items.Count == 0)
            {
                while (true)
                {
                    Console.WriteLine("인벤토리가 비어있습니다.");
                    Console.WriteLine("0.나가기");
                    Console.Write(">>");
                    string select = Console.ReadLine();
                    if (select == "0")
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }
                
            }
            else
            {
                while (true)
                {
                    Console.WriteLine("[아이템 목록]\n");
                    for (int i = 0; i < items.Count; i++)
                    {
                        var item = items[i];
                        string isEquipped = item.IsEquipped ? "[E]" : "";
                        Console.WriteLine($"{isEquipped}{item.Name} | {item.GetStatIncrease()} | {item.Decription}");
                    }
                    Console.WriteLine("1.아이템 장착");
                    Console.WriteLine("0.나가기");
                    string select = Console.ReadLine();
                    if (select == "0")
                    {
                        break;
                    }
                    else if (select == "1")
                    {
                        ManageEquipment();
                    }
                    else
                    {
                        Console.WriteLine("잘못된 입력입니다.");
                    }
                }

            }
            

            
        }

        public void ManageEquipment()
        {
            while (true)
            {
                Console.WriteLine("인벤토리 - 장착관리");
                for (int i = 0; i < items.Count; i++)
                {
                    var item = items[i];
                    string isEquipped = item.IsEquipped ? "[E]" : "";
                    Console.WriteLine($"{i+1}.{isEquipped} {item.Name} | {item.GetStatIncrease()} | {item.Decription}");
                }
                Console.WriteLine("장착/해제 할 번호 입력:");
                Console.WriteLine("0.나가기");

                if (int.TryParse(Console.ReadLine(), out int select))
                {
                    if (select == 0)
                        break;
                if (select > 0 && select <= items.Count)
                {
                    var item = items[select - 1];
                    item.IsEquipped = !item.IsEquipped;
                    Console.WriteLine(item.IsEquipped ? $"{item.Name}을(를) 장착했습니다" : $"{item.Name}을(를) 해제했습니다.");
                }
               else
                {
                    Console.WriteLine("잘못된 번호입니다.");
                }
            }
            else
            {
                Console.WriteLine("잘못된 입력입니다.");
            }
            }
        }
        public List<Item> GetEquippedItems()
        {
            return items.Where(i => i.IsEquipped).ToList();
        }
    }
    

}
