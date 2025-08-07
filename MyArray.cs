using System.Diagnostics.Contracts;

public class MyArray
{
    public static void Reverse(int[] array)
    {
        for (int i = 0; i <= array.Length/2; i++)
        {
            int length = array.Length - 1;
            int temp = array[i];
            array[i] = array[length - i];
            array[length - i] = temp;
        }
    }
    public static void Reverse(int[] array, int first, int count)
    {
        for (int i = first; i < first + count/2; i++)
        {
            int head = first;
            int tail = first + count - 1;
            while (head < tail)
            {
                int temp = array[head];
                array[head] = array[tail];
                array[tail] = temp;

                head++;
                tail--;
            }
        }
    }
    public static void Fill(int[] array, int fill, int first, int last)
    {
        for (int i = first; i <= first + last; i++)
        {
            array[i] = fill;
        }
    }

    public static void Copy(int[] array, int[] newArray, int Length)
    {
       for(int i = 0; i<Length; i++)
        {
            newArray[i] = array[i];
        }
    }

    public static void Resize(ref int[] array, int a)
    {
        for(int i = 0; i<a; i++)
        {
            var newArray = new int[a];
            int count = Math.Min(a, array.Length);
            Copy(array, newArray, count);
        }
    }
    public static void Clear(int[] array)
    {
        for(int i =0; i<array.Length; i++)
        {
            array[i] = 0;   
        }
    }

    public static void Clear(int[] array, int first, int count)
    {
        for (int i = first; i < first+count; i++)
        {
            array[i] = 0;
        }  
    }

}