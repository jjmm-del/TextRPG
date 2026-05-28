namespace TextRPG;

public class GameManager
{
    private Player _player;
    private bool _isRunning = true;

    public void StartGame()
    {
        Console.WriteLine("무협 TextRPG에 오신 것을 환영합니다.");

        _player = new Player("청명", "화산파");

        GameLoop();
    }

    private void GameLoop()
    {
        while (_isRunning)
        {
            Console.Clear();
            _player.ShowStatus();
            
            Console.WriteLine("\n무엇을 하시겠습니까?");
            Console.WriteLine("1. 수련하기(운기조식)");
            Console.WriteLine("2. 강호로 나가기(전투)");
            Console.WriteLine("3. 게임 종료");
            Console.Write("선택:");

            string input = Console.ReadLine();

            switch (input)
            {
                case "1" : 
                    Console.WriteLine("\n가부좌를 틀고 운기조식을 합니다...(기혈/내공을 최대로 회복");
                    _player.Blood = 100;
                    _player.Qi = 0;
                    Console.ReadKey(); //아무 키나 누를 때까지 대기
                    break;
                case "2" :
                    Console.WriteLine("\n아직 비적들이 나타나지 않았습니다(개발 중).");
                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("\n강호를 떠납니다.");
                    _isRunning = false;
                    break;
                default:
                    Console.WriteLine("잘못된 선택입니다. 다시 입력하세요");
                    Console.ReadKey();
                    break;
            }
        }
    }
    
}
