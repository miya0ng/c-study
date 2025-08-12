// 장비 초기화
using System.Collections.Concurrent;
using System.Threading;
using System.Transactions;
using static System.Net.Mime.MediaTypeNames;

List<Monster> monsters = new List<Monster>
{
    new Monster("슬라임", 1, 50, 10, 100),
    new Monster("고블린", 2, 80, 15, 200),
    new Monster("오우거", 5, 200, 30, 500)
};

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

    Console.WriteLine("=== 캐릭터 상태 관리 시스템 ===");
    CharacterStatus currentStatus = CharacterStatus.Normal;

    // 게임 메인 루프
    while (true)
    {
        DisplayStatus(currentStatus);
        Console.WriteLine("\n1. 상태 추가");
        Console.WriteLine("2. 상태 제거");
        Console.WriteLine("3. 상태 확인");
        Console.WriteLine("4. 종료");

        Console.Write("선택: ");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                DisplayStatus(currentStatus);
                break;

            case "2":
                Console.WriteLine("상태가 제거되었습니다");
                currentStatus = CharacterStatus.Normal;
                break;

            case "3":
                Console.WriteLine("상태가 제거되었습니다");
                break;
        }
                Console.Clear();
        Console.WriteLine("=== RPG 캐릭터 시스템 ===");
        Console.WriteLine($"이름: {player} ({player.GetType().Name})");
        Console.WriteLine("\n1. 경험치 획득");
        Console.WriteLine("2. 장비 장착");
        Console.WriteLine("3. 장비 해제");
        Console.WriteLine("4. 전투 시작");
        Console.WriteLine("5. 특수 능력");
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
                Console.WriteLine("\n=== 전투 가능한 몬스터 목록 ===");
                for (int i = 0; i < monsters.Count; i++)
                    Console.WriteLine($"{i + 1}. {monsters[i]}");

                Console.Write("\n전투할 몬스터 선택: ");
                if (int.TryParse(Console.ReadLine(), out int monsterNum) &&
                    monsterNum >= 1 && monsterNum <= monsters.Count)
                {
                    Battle(player, monsters[monsterNum - 1]);
                    if (player.IsDead)
                    {
                        Console.WriteLine("게임 오버!");
                        return;
                    }
                }
                break;
            case "5":
                Console.WriteLine("\n1. 일반 공격 \n2. 특수 능력");
                int num = int.Parse(Console.ReadLine());
                switch (num)
                {
                    case 1:
                        player.Attack(player);
                        break;
                    case 2:
                        player.UseSpecialAbility(player);
                        break;
                }

                break;
            case "6":
                return;
        }

        Console.WriteLine("\n계속하려면 아무 키나 누르세요...");
        Console.ReadKey(true);
    }
}
void Battle(Character player, Monster monster)
{
    player.Attack(monster);
    monster.Attack(player);
}

void DisplayStatus(CharacterStatus currentStatus)
{
    Console.WriteLine("\n1. Poison");
    Console.WriteLine("2. Paralyzed");
    Console.WriteLine("3. Confused");
    Console.WriteLine("4. Invisible");

    switch (Console.ReadLine())
    {
        case "1":
            currentStatus = CharacterStatus.Poison;
            Console.WriteLine("상태가 추가되었습니다");
            Console.WriteLine($"현재 상태: {currentStatus}");
            break;
        case "2":
            currentStatus = CharacterStatus.Paralyzed;
            Console.WriteLine("상태가 추가되었습니다");
            Console.WriteLine($"현재 상태: {currentStatus}");
            break;
        case "3":
            currentStatus = CharacterStatus.Confused;
            AddStatus(currentStatus);
            Console.WriteLine("상태가 추가되었습니다");
            Console.WriteLine($"현재 상태: {currentStatus}");
            break;
        case "4":
            currentStatus = CharacterStatus.Invisible;
            Console.WriteLine("상태가 추가되었습니다");
            Console.WriteLine($"현재 상태: {currentStatus}");
            break;
    }

    Console.WriteLine("\n상태 확인 메뉴:");
    Console.WriteLine("1. 단일 상태 확인");
    Console.WriteLine("2. 복합 상태 확인");
    Console.WriteLine("3. 상태 효과 개수 확인");

    switch (Console.ReadLine())
    {
        case "1":
            Console.WriteLine("현재 캐릭터는:");
            Console.WriteLine($"{currentStatus}");
            break;
        case "2":
            Console.WriteLine("현재 캐릭터는:");
            Console.WriteLine($"{currentStatus}");
            break;
        case "3":
            Console.WriteLine("현재 캐릭터는:");
            Console.WriteLine($"{currentStatus}");
            break;
    }
}
void InitializeStatus(CharacterStatus c)
{
    c = CharacterStatus.Normal;
}
void AddStatus(CharacterStatus c)
{
    
}
void RemoveStatus()
{

}

void HasStatus()
{

}
public enum EquipmentType
{
    Sword,
    Staff,
    Bow
}

[Flags]
public enum CharacterStatus
{
    Normal = 0,
    Poison = 1,
    Paralyzed = 1 << 1,
    Confused = 1 << 2,
    Invisible = 1 << 3,
    All = Poison | Paralyzed | Confused | Invisible
}