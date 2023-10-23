namespace HeapSort;

public static class HeapSort
{

    public static void SortArr(int[] arr)
    {
        BuildMaxHeap(arr);
        
        for (int i = arr.Length - 1; i > 0; i--)
        {
            Swap(0, i, arr);
            MaxHeapify(arr, 0, i);
        }


    }

    private static void BuildMaxHeap(int[] arr)
    {
        for (int i = (arr.Length / 2) - 1; i >= 0; i--)
        {
            MaxHeapify(arr, i, arr.Length);
        }
    }

    private static void MaxHeapify(int[] arr, int i, int size)
    {
        int maxElementIndex = i;
        int left = 2 * i + 1;
        int right = 2 * i + 2;

        if (left < size && arr[left] > arr[i])
            maxElementIndex = left;
        
        if (right < size && arr[right] > arr[maxElementIndex])
            maxElementIndex = right;
        
        if (maxElementIndex != i)
        {
            
            Swap(maxElementIndex, i, arr);
            MaxHeapify(arr, maxElementIndex, size);
        }

    }

    private static void Swap(int num1, int num2, int[] arr)
    {
        (arr[num1], arr[num2]) = (arr[num2], arr[num1]);
    }
}