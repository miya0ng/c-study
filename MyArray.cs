using System.Diagnostics.Contracts;

public class MyArray
{
    public static void Reverse(int[] array, int index, int length)
    {
        for(int i = index; i < length+index/2; i++)
        {
            int temp = array[index];
            array[index] = array[index + length - i];
            array[index + length - i] = temp;
        }
    }
}