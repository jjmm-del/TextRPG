using System;
using System.IO;
using System.Text.Json; //JSON 라이브러리를 이용해 플레이어 정보 저장

namespace TextRPG;

public class GameManager
{
    private Player _player;
    private bool _isRunning = true;
    private readonly string _saveFilePath = "savedata.json"; //파일 저장 경로

    public void StartGame()
    {
        Console.WriteLine("==============================");
        Console.WriteLine("무협 TextRPG - 강호의 서막");
        Console.WriteLine("==============================");
        Console.WriteLine("\n아무 키나 입력하여 무림에 참여하기...");
        Console.ReadKey();
        //게임 시작 시 기존 저장 데이터 있는 지 확인
        if (File.Exists(_saveFilePath))
        {
            Console.WriteLine("기존 저장 데이터가 존재합니다.");
            Console.WriteLine("1. 이어하기 | 2. 새로 시작하기");
            Console.WriteLine("선택: ");
            string choice = Console.ReadLine();

            if (choice == "1")
            {
                LoadGame();
            }
            else
            {
                CreateCharacter();
            }
        }
        else
        {
            CreateCharacter();
        } 
        GameLoop();
    }

    private void CreateCharacter()
    {
        Console.Clear();
        Console.WriteLine("=== 새로운 대협의 탄생 ===");

        string name = string.Empty;
        while (string.IsNullOrWhiteSpace(name))
        {
            Console.WriteLine("대협의 함자를 입력하시오: ");
            name = Console.ReadLine()?.Trim();
        }
        Console.WriteLine("\n출신 문파를 입력하시오:");
        Console.WriteLine("1. 소림사");
        Console.WriteLine("2. 화산파");
        Console.WriteLine("3. 당문");
        Console.Write("선택: ");

        int orderChoice;
        int.TryParse(Console.ReadLine(), out orderChoice);
        
        //플레이어 객체 생성
        _player = new Player(name, orderChoice);
        Console.WriteLine($"\n{_player.Order}의{_player.Name}대협, 강호에 첫 발을 내딛다.");
        SaveGame(); //즉시 저장
        Console.ReadKey();
        
    }

    private void SaveGame()
    {
        try
        {
            var options = new JsonSerializerOptions { WriteIndented = true };
            string jsonString = JsonSerializer.Serialize(_player, options);

            File.WriteAllText(_saveFilePath, jsonString);
            Console.WriteLine("\n[시스템] 강호의 기록이 저장되었습니다.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[시스템] 저장 중 오류 발생: {ex.Message}");
        }
    }

    private void LoadGame()
    {
        try
        {
            string jsonString = File.ReadAllText(_saveFilePath);
            _player = JsonSerializer.Deserialize<Player>(jsonString);
            Console.WriteLine($"\n[시스템]{_player.Name} 대협의 기록을 성공적으로 불러왔습니다.");
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"\n[시스템] 불러오기 중 오류 발생: {ex.Message}");
            Console.WriteLine("새로운 캐릭터를 생성합니다.");
            CreateCharacter();
        }
        
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
                    _player.Health = _player.MaxHealth;
                    _player.Qi = _player.MaxQi;
                    SaveGame();
                    Console.ReadKey(); //아무 키나 누를 때까지 대기
                    break;
                case "2" :
                    Console.WriteLine("\n아직 비적들이 나타나지 않았습니다(개발 중).");
                    Console.ReadKey();
                    break;
                case "3":
                    Console.WriteLine("\n강호의 기록을 저장하고 잠시 현세로 돌아갑니다..");
                    SaveGame();
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
