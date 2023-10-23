
using System.Xml;
using HeapSort;



int[] array = new int[] {6,8,2,9,3};

HeapNodeSort<int>.HeapSort(array);

foreach (var num in array)
{
    Console.Write(num);
}

