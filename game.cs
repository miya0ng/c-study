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

            if (!IsValidMove(firstChoice, revealed))
            {
                Console.WriteLine("잘못된 선택입니다. 다시 시도하세요.");
                continue;
            }
            else
            {
                revealed[firstChoice] = true;
                DisplayBoard(cards, revealed);
            }

            Console.Write("두 번째 카드 위치 선택 (0-15): ");
            int secondChoice = int.Parse(Console.ReadLine());

            if (!IsValidMove(secondChoice, revealed))
            {
                Console.WriteLine("잘못된 선택입니다. 다시 시도하세요.");
                revealed[firstChoice] = false;
                continue;
            }
            else
            {
                revealed[secondChoice] = true;
                DisplayBoard(cards, revealed);
            }
            if(CheckMatch(firstChoice, secondChoice, cards))
            {
                Console.WriteLine("\n\n매칭 성공!");
                score++;
            }
            else
            {
                Console.WriteLine("\n\n매칭 실패!");
                revealed[firstChoice] = false;
                revealed[secondChoice] = false;
            }
                attempts++;
            System.Threading.Thread.Sleep(1500); // 대기
            Console.Clear(); // 화면 클리어
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
            //Console.Write($"{cards[i]} ");
        }
        //Console.WriteLine();
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
    static bool IsValidMove(int position, bool[] revealed)
    {
        return position >= 0 && position < revealed.Length && !revealed[position];
    }

    static bool CheckMatch(int firstChoice, int secondChoice, int[] cards)
    {
         return cards[firstChoice] == cards[secondChoice];
    }
}