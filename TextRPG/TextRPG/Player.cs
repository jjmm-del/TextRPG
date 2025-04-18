using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;
using System.Xml.Linq;

namespace TextRPG
{
    public class Player
    {
        public string Name { get; set; }
        public JobType Job { get; set; }
        public int BaseAttack { get; set; }
        public int BaseDefense { get; set; }
        public int BaseHealth { get; set; }
        public int BaseGold { get; set; }
        public Inventory Inventory { get; set; }
        public Player(string name, JobType job)
        {
            Name = name;
            Job = job;
            BaseAttack = 10;
            BaseDefense = 5;
            BaseHealth = 100;
            BaseGold = 1500;
            Inventory = new Inventory();
        }
        public int TotalAttack
        {
            get
            {
                return BaseAttack + Inventory.GetEquippedItems().Sum(i=>i.Attack);
            }
        }
        public int TotalDefense
        {
            get
            {
                return BaseDefense + Inventory.GetEquippedItems().Sum(i=>i.Defense);
            }
        }
        public int TotalHealth
        {
            get
            {
                return BaseHealth + Inventory.GetEquippedItems().Sum(i=>i.Health);
            }
        }

        public enum JobType
        {
            전사 = 1,
            도적,
            마법사

        }
        public static JobType SelectJob()
        {
            Console.WriteLine("직업을 선택하세요\n");
            Console.WriteLine("1.전사");
            Console.WriteLine("2.도적");
            Console.WriteLine("3.마법사\n");
            while (true)
            {
                Console.WriteLine("원하시는 행동을 선택하세요");
                string select = Console.ReadLine();

                if (int.TryParse(select, out int jobNumber))
                {
                    if (Enum.IsDefined(typeof(JobType), jobNumber))
                    {
                        return (JobType)jobNumber;
                    }
                }
                Console.WriteLine("잘못된 입력입니다. 1~3중에서 입력해주세요.");
            }

        }

        public void ShowStatus()
        {
            while (true)
            {

            
            Console.WriteLine("상태보기");
            Console.WriteLine("캐릭터의 정보가 표시됩니다.\n");
            Console.WriteLine($"Lv. 1");
            Console.WriteLine($"{Name} ({Job})");
            Console.WriteLine($"공격력 : {TotalAttack}({BaseAttack}+{TotalAttack-BaseAttack})");       //공격력 표시
            Console.WriteLine($"방어력 : {TotalDefense}({BaseDefense}+{TotalDefense-BaseDefense})");     //방어려 표시 
            Console.WriteLine($"체력 : {TotalHealth}({BaseHealth}+{TotalHealth-BaseHealth})");           //체력 표시
            Console.WriteLine($"Gold : {BaseGold}G\n");         //현재 gold표시
            Console.WriteLine("0.나가기\n");
            Console.WriteLine("원하시는 행동을 입력해 주세요.\n>>");
            string select = Console.ReadLine();
            switch (select)
            {
                case "0":
                    return;
                default:
                    Console.WriteLine("잘못된 입력입니다.\n");
                    break;
            }
            }
        }
    }
}
