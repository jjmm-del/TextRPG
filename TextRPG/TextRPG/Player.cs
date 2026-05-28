namespace TextRPG;

public class Player
{
    public string Name { get; set; }
    public string Order { get; set; } //문파
    public int Blood { get; set; } // 기혈 = HP
    public int Qi { get; set; } // 기 = MP = 마나

    public Player(string name, string order)
    {
        Name = name;
        Order = order;
        Blood = 100;
        Qi = 50;
    }

    public void ShowStatus()
    {
        Console.WriteLine($"\n==============================");
        Console.WriteLine($"[대협의 정보]");
        Console.WriteLine($"이름 : {Name}({Order})");
        Console.WriteLine($"체력:{Blood} / 내력:{Qi}");
        Console.WriteLine($"\n==============================");
    }

}