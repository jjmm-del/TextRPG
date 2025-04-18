using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TextRPG
{
    public class Item
    {
        public string Name { get; }
        public string Decription { get; }
        public int Attack { get; }
        public int Defense { get; }
        public int Health { get; }
        public int BasePrice { get; }
        public bool IsEquipped { get; set; } = false;

        public Item(string name, string decription, int attack, int defense, int health, int basePrice)
        {
            Name = name;
            Decription = decription;
            Attack = attack;
            Defense = defense;
            Health = health;
            BasePrice = basePrice;

        }

        public string GetStatIncrease()
        {
            List<string> statIncreases = new List<string>();
            if (Attack != 0) statIncreases.Add($"공격력+{Attack}");
            if (Defense != 0) statIncreases.Add($"방어력+{Defense}");
            if (Health != 0) statIncreases.Add($"체력{Health}");

            return string.Join(",", statIncreases);
        }

        static public List<Item> AllItems = new List<Item>
                    {
                        new Item("수련자의 갑옷", "튼튼한 천으로 만들어진 갑옷", 0, 5, 0, 100),
                        new Item("무쇠갑옷", "무쇠로 제작된 튼튼한 갑옷", 0, 10, 0, 200),
                        new Item("스파르타의 갑옷", "전설적인 전사들의 갑옷", 0, 15, 0, 300),
                        new Item("낡은 검", "시간이 지난 오래된 검", 5, 0, 0, 150),
                        new Item("청동 도끼", "무게감 있는 도끼", 10, 0, 0, 250),
                        new Item("스파르타의 창", "스파르타 전사의 상징", 15, 0, 0, 350),
                    };

    }
}
