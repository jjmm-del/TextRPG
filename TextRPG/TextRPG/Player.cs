using System;

namespace TextRPG;
public class Player
{
    public string Name { get; set; }
    public string Order { get; set; } //문파
    public int MaxHealth { get; set; }//최대 체력
    public int Health { get; set; } //체력 = HP
    public int MaxQi { get; set; } //최대 기력
    public int Qi { get; set; } // 기 = MP = 마나
    public int Silver { get; set; } //은자
    
    public Player() { }
    public Player(string name, int orderChoice)
    {
        Name = name;
        Silver = 100;

        switch (orderChoice)
        {
            case 1:
                Order = "소림사";
                MaxHealth = 120;
                MaxQi = 30;
                break;
            case 2:
                Order = "화산파";
                MaxHealth = 100;
                MaxQi = 50;
                break;
            case 3:
                Order = "당문";
                MaxHealth = 80;
                MaxQi = 50;
                break;
            default:
                Order = "무명";
                MaxHealth = 70;
                MaxQi = 30;
                break;
        }

        Health = MaxHealth;
        Qi = MaxQi;
    }

    public void ShowStatus()
    {
        Console.WriteLine($"\n==============================");
        Console.WriteLine($"[대협의 정보]");
        Console.WriteLine($"이름 : {Name}|문파: {Order})");
        Console.WriteLine($"체력:{Health} / 내력:{Qi}");
        Console.WriteLine($"보유 재화:{Silver}냥");
        Console.WriteLine($"\n==============================");
    }

}