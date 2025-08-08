
using System.Xml.Linq;

Character player = new Character("모험가");
var equipments = new List<Equipment>
{
    new Equipment { Name = "초보자의 검", AttackBonus = 10, RequiredLevel = 1 },
    new Equipment { Name = "강철 검", AttackBonus = 20, RequiredLevel = 2 },
    new Equipment { Name = "미스릴 검", AttackBonus = 50, RequiredLevel = 5 }
};

while (true)
{
    Console.Clear();
    Console.WriteLine("=== RPG 캐릭터 시스템 ===");
    Console.WriteLine(player);
    Console.WriteLine("\n1. 경험치 획득");
    Console.WriteLine("2. 장비 장착");
    Console.WriteLine("3. 장비 해제");
    Console.WriteLine("4. 종료");
    Console.Write("\n선택: ");

    switch (Console.ReadLine())
    {
        case "1":
            Console.Write("획득할 경험치 입력: ");
            if (int.TryParse(Console.ReadLine(), out int exp))
                player.AddExp(exp);
            break;

        case "2":
            Console.WriteLine("\n=== 장착 가능 장비 목록 ===");
            for (int i = 0; i < equipments.Count; i++)
                Console.WriteLine($"{i + 1}. {equipments[i]}");

            Console.Write("\n장착할 장비 번호 선택: ");
            if (int.TryParse(Console.ReadLine(), out int equipNum) &&
                equipNum >= 1 && equipNum <= equipments.Count)
            {
                player.EquipItem(equipments[equipNum - 1]);
            }
            break;

        case "3":
            player.UnequipItem();
            break;

        case "4":
            return;
    }

Console.WriteLine("\\n계속하려면 아무 키나 누르세요...");
Console.ReadKey(true);
}


public class Character
{
    public string Id;
    public Character(string id)
    {
        Id = id;
    }

    public int Hp { get; set; } = 100;
    public int Mp { get; set; } = 50;

    public int level=1;
    public int Exp;
    public Equipment equip;
    public void AddExp(int amount)
    {
        if (amount >= 0 && amount <= 999)
            Exp += amount;
        else
        {
            Console.Write("\n 입력 경험치 범위: 0 ~ 99 ");
            return;
        }

        if(Exp >= 1000)
        {
            int temp = Exp - 1000;
            level++;
            Exp = temp;

            
        }
    }
    public void EquipItem(Equipment item)
    {
        if (level <= item.RequiredLevel)
        {
            Console.Write("\n 레벨 부족");
            return;
        }
        equip = item;
    }
    public void UnequipItem()
    {
        equip = null;
        Console.Write("\n 장비 해제");
    }

    public override string ToString()
    {
        return $"\n 캐릭터: {Id} (레벨: {level}, 경험치: {Exp}/1000) \n HP: {Hp}/100, MP:{Mp}/50 \n 장착 장비: {equip}";
    }
}

public class Equipment
{
    public string Name { get; init; }
    public int AttackBonus { get; init; }
    public int RequiredLevel { get; init; }
    public override string ToString()
    {
        return $"{Name} (공격력 + {AttackBonus}, 필요 레벨: {RequiredLevel})";
    }
}