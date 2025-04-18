//startScene
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using TextRPG;

internal class Program
{
    static string SetName()
    {
        while (true)
        {
            Console.WriteLine("원하시는 이름을 설정해주세요.\n");

            string name = Console.ReadLine();


            Console.WriteLine($"입력하신 이름은 {name}입니다.\n");

            while (true)
            {
                Console.WriteLine("1.저장 \n2.취소\n");

                string select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        Console.WriteLine("저장되었습니다.");
                        return name;

                    case "2":
                        Console.WriteLine("취소합니다.\n");
                        break;

                    default:
                        Console.WriteLine("잘못된 입력입니다.\n");
                        continue;

                }
                break;
            }
        }
    }

   

    private static void Main(string[] args)
    {


        
        Console.WriteLine("스파르타 던전에 오신 것을 환영합니다.");

        string name =  SetName();
       



            

                Player.JobType selectedJob = Player.SelectJob();
        Player player = new Player(name, selectedJob);
            bool playing = true;
                Shop shop = new Shop();
        while (playing)
        {
            Console.Clear();
            Console.WriteLine("스파르타 마을에 오신 여러분 환영합니다.");
            Console.WriteLine("이곳에서 던전으로 들어가기전 활동을 할 수 있습니다.\n");
            Console.WriteLine("1.상태 보기");
            Console.WriteLine("2.인벤토리");
            Console.WriteLine("3.상점");

            Console.WriteLine("\n원하시는 행동을 입력해주세요\n>>");
            string select = Console.ReadLine();
                switch (select)
                {
                    case "1":
                        player.ShowStatus();
                        break;

                    case "2":
                        player.Inventory.ShowInventory();

                        break;
                    case "3":
                        shop.ShowShop(player);
                        break;
                    default:
                        Console.WriteLine("잘못된 입력입니다.");
                        break;
                }

            }

        }

    }


