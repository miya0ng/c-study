// 장비 초기화
using System.Threading;
using static System.Net.Mime.MediaTypeNames;

List<Equipment> equipments = new List<Equipment>
{
    new Equipment {
        Name = "초보자의 검",
        AttackBonus = 10,
        RequiredLevel = 1,
        Type = EquipmentType.Sword
    },
    new Equipment {
        Name = "초보자의 지팡이",
        AttackBonus = 15,
        RequiredLevel = 1,
        Type = EquipmentType.Staff
    },
    new Equipment {
        Name = "초보자의 활",
        AttackBonus = 12,
        RequiredLevel = 1,
        Type = EquipmentType.Bow
    }
};

// 캐릭터 생성 및 직업 선택
Console.Write("캐릭터 이름을 입력하세요:");
string name = Console.ReadLine();

Character player = null;
while (player == null)
{
    Console.WriteLine("\n직업을 선택하세요:");
    Console.WriteLine("1. 전사");
    Console.WriteLine("2. 마법사");
    Console.WriteLine("3. 궁수");

    switch (Console.ReadLine())
    {
        case "1":
            player = new Warrior(name);
            break;
        case "2":
            player = new Mage(name);
            break;
        case "3":
            player = new Archer(name);
            break;
        default:
            Console.WriteLine("잘못된 선택입니다.");
            break;
    }
}

// 게임 메인 루프
while (true)
{
    Console.Clear();
    Console.WriteLine("=== RPG 캐릭터 시스템 ===");
    Console.WriteLine($"이름: {player} ({player.GetType().Name})");
    Console.WriteLine("\n1. 경험치 획득");
    Console.WriteLine("2. 장비 장착");
    Console.WriteLine("3. 장비 해제");
    Console.WriteLine("4. 특수 능력 사용");
    Console.WriteLine("5. 종료");
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
            player.UseSpecialAbility();
            break;

        case "5":
            return;
    }

    Console.WriteLine("\n계속하려면 아무 키나 누르세요...");
    Console.ReadKey(true);
}
public enum EquipmentType
{
    Sword,
    Staff,
    Bow
}
