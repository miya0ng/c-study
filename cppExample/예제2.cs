
namespace ConsoleApp2.cppExample
{
    internal class 예제2
    {
        public static void Main()
        {
            //1. 변수 선언과 초기화: 정수형 변수 age를 25로 초기화하고,
            //실수형 변수 weight를 65.8로 초기화한 후, 각각의 값을 출력하는 프로그램을 작성하세요
            int age = 25;
            float weight = 65.8f;

            Console.WriteLine($"나이: {age}, \n 몸무게: {weight:0.0}");

            //2. sizeof 연산자 활용: 다양한 자료형(char, short, int, long long, float, double)의
            //크기를 sizeof 연산자를 사용하여 출력하는 프로그램을 작성하세요.
            char a='1';
            short b;
            int c;
            //long long d;
            float d;
            double e;

            Console.WriteLine($"{sizeof(char)}, {sizeof(short)}, {sizeof(int)}, {sizeof(float)}, {sizeof(double)}");
        }
    }
}
