using System.Xml;

public class game
{
    public static void Main()
    {
        Console.WriteLine("=== 카드 매칭 게임 ===");

        // 게임 초기화
        int[] cards = new int[16];
        bool[] revealed = new bool[16];  // true: 공개된 카드, false: 숨겨진 카드
        int score = 0;
        int attempts = 0;

        InitializeCards(cards);
        ShuffleCards(cards);

        // 게임 메인 루프
        while (score < 8)  // 8쌍을 모두 찾으면 게임 종료
        {
            DisplayBoard(cards, revealed);
            Console.WriteLine($"시도 횟수: {attempts}, 찾은 쌍: {score}");

            // 첫 번째 카드 선택
            Console.Write("첫 번째 카드 위치 선택 (0-15): ");
            int firstChoice = int.Parse(Console.ReadLine());

            DisplayBoard(cards, revealed);

            Console.Write("두 번째 카드 위치 선택 (0-15): ");
            int secondChoice = int.Parse(Console.ReadLine());
            attempts++;

            if (!IsValidMove(firstChoice, secondChoice, revealed))
            {
                Console.WriteLine("잘못된 선택입니다. 다시 시도하세요.");
                continue;
            }
            // ... 게임 진행 로직 ...

            if(CheckMatch(firstChoice, secondChoice, revealed))
            {
                score++;
            }
        }
        Console.WriteLine($"게임 클리어! 총 시도 횟수: {attempts}");
    }

    static void InitializeCards(int[] cards)
    {
        for (int i = 1; i <= cards.Length / 2; i++)
        {
            cards[i] = i;
            cards[cards.Length - i] = i;
        }
        Console.WriteLine();
    }

    static void ShuffleCards(int[] cards)
    {
        Random rand = new Random();
        for (int i = cards.Length - 1; i > 0; i--)
        {
            int index = rand.Next(i + 1);
            int temp = cards[i];
            cards[i] = cards[index];
            cards[index] = temp;
            Console.Write($"{cards[i]} ");
        }
    }

    static void DisplayBoard(int[] cards, bool[] revealed)
    {
        for (int i = 0; i < cards.Length; i++)
        {
            if (revealed[i])
            {
                Console.Write($"{cards[i]} ");
            }
            else
            {
                Console.Write("* ");
            }

            if ((i + 1) % 4 == 0)
            {
                Console.WriteLine();
            }
        }
    }
    static bool IsValidMove(int firstChoice, int secondChoice, bool[] revealed)
    {
        if (revealed[firstChoice]== revealed[secondChoice])
            return false;
        else return true;
    }

    static bool CheckMatch(int firstChoice, int secondChoice, bool[] revealed)
    {
        if (revealed[firstChoice] == revealed[secondChoice])
        return true;

        else return false;
    }
}