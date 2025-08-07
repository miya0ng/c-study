
//Console.WriteLine("=== 기본 배열 연산 테스트 ===");
//int[] array = { 10, 1, 2, 5, 3, -10 };
//PrintArray(array);  // [10, 1, 2, 5, 3, -10]

//Console.WriteLine("\\n=== Reverse 테스트 ===");
//MyArray.Reverse(array);
//PrintArray(array);  // [-10, 3, 5, 2, 1, 10]
//MyArray.Reverse(array, 1, 3);  // index 1부터 3개 요소만 뒤집기
//PrintArray(array);  // [-10, 2, 5, 3, 1, 10]

//Console.WriteLine("\\n=== Fill 테스트 ===");
//MyArray.Fill(array, 100, 1, 2);  // index 1부터 2개를 100으로 채움
//PrintArray(array);  // [-10, 100, 100, 2, 1, 10]

//Console.WriteLine("\\n=== Copy & Resize 테스트 ===");
//int[] newArray = new int[array.Length];
//MyArray.Copy(array, newArray, array.Length);
//PrintArray(newArray);  // [-10, 100, 100, 2, 1, 10]
//MyArray.Resize(ref newArray, 8);  // 크기를 8로 늘림
//PrintArray(newArray);  // [-10, 100, 100, 2, 1, 10, 0, 0]

//Console.WriteLine("\\n=== Clear 테스트 ===");
//MyArray.Clear(newArray);  // 모든 요소를 0으로
//PrintArray(newArray);  // [0, 0, 0, 0, 0, 0, 0, 0]

//array = new int[] { 10, 1, 2, 5, 3, -10 };
//MyArray.Clear(array, 1, 3);  // index 1부터 3개 요소를 0으로
//PrintArray(array);  // [10, 0, 0, 0, 3, -10]

//Console.WriteLine("\\n=== Sort & Search 테스트 ===");
//MyArray.Sort(array);
//PrintArray(array);  // [-10, 0, 0, 0, 3, 10]

////int findIndex = MyArray.IndexOf(array, -10);
////Console.WriteLine($"IndexOf(-10): {findIndex}");  // 0

////findIndex = MyArray.BinarySearch(array, 3);
////Console.WriteLine($"BinarySearch(3): {findIndex}");  // 4

//static void PrintArray(int[] array)
//{
//    Console.Write("[");
//    for (int i = 0; i < array.Length; i++)
//    {
//        Console.Write(array[i]);
//        if (i < array.Length - 1)
//            Console.Write(", ");
//    }
//    Console.WriteLine("]");
//}