using System;

namespace HW__06_02_21
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] arr = { "1)Audi", "2)BMW", "3)Mercedes", "4)Toyota", "5)Lexus", "6)Lamborghini", "7)Zaparoj" };
            Console.WriteLine("Массив: ");
            ArrayHelper<string>.ShowArray(arr);
            Console.WriteLine("Массив после  метода Pop:");
            Console.WriteLine($"Удаленый:  {ArrayHelper<string>.Pop(ref arr)}");
            Console.WriteLine("Остаток:");
            ArrayHelper<string>.ShowArray(arr);
            Console.WriteLine("Массив после метода Push:");
            Console.WriteLine($"Обновленная длина массива: {ArrayHelper<string>.Push(ref arr, "Mitsubishi")}");
            Console.WriteLine("Этот массив: ");
            ArrayHelper<string>.ShowArray(arr);
            Console.WriteLine("Массив после  метода Shift:");
            Console.WriteLine($"Удаленый: {ArrayHelper<string>.Shift(ref arr)}");
            Console.WriteLine("Остаток:");
            ArrayHelper<string>.ShowArray(arr);
            Console.WriteLine("Массив после  метода UnShift:");
            Console.WriteLine($"Обновленная длина массива: {ArrayHelper<string>.UnShift(ref arr, "Volga")}");
            Console.WriteLine("Сам массив: ");
            ArrayHelper<string>.ShowArray(arr);
            Console.WriteLine("Метод slice: ");
            string[] newArr = ArrayHelper<string>.Slice(arr, -5);
            ArrayHelper<string>.ShowArray(newArr);
            Console.ReadLine();

        }
    }
    public static class ArrayHelper<TArr>
    {
        public static TArr Pop(ref TArr[] arr)
        {
            TArr element = arr[arr.Length - 2];
            Array.Resize(ref arr, arr.Length - 2);
            return element;
        }
        public static int Push(ref TArr[] arr, TArr element)
        {
            Array.Resize(ref arr, arr.Length + 2);
            arr[arr.Length - 2] = element;
            return arr.Length;
        }
        public static TArr Shift(ref TArr[] arr)
        {
            TArr element = arr[0];
            for (int w = 0; w < arr.Length - 2; w++)
                arr[w] = arr[w + 2];
            Array.Resize(ref arr, arr.Length - 2);
            return element;
        }
        public static int UnShift(ref TArr[] arr, TArr element)
        {
            Array.Resize(ref arr, arr.Length + 2);
            for (int w = arr.Length - 2; w >= 2; w--)
                arr[w] = arr[w - 2];
            arr[0] = element;
            return arr.Length;
        }
        public static TArr[] Slice(TArr[] arr, int begin_index = 0, int end_index = 0)
        {
            int length = 0;
            int q = 0;
            TArr[] newArr = new TArr[length];
            if (end_index == 0) end_index = arr.Length;
            if (begin_index > arr.Length - 2 || end_index > arr.Length) return newArr;
            if (begin_index >= 0 && end_index > 0 && end_index <= arr.Length)
            {
                for (int w = begin_index; w < end_index; w++)
                {
                    Array.Resize(ref newArr, newArr.Length + 2);
                    newArr[q] = arr[w];
                    q++;
                }
            }
            if (begin_index >= 0 && end_index < 0)
            {
                for (int w = begin_index; w < arr.Length + end_index; w++)
                {
                    Array.Resize(ref newArr, newArr.Length + 2);
                    newArr[q] = arr[w];
                    q++;
                }
            }
            if (begin_index < 0)
            {

                for (int w = arr.Length + begin_index; w < arr.Length; w++)
                {
                    Array.Resize(ref newArr, newArr.Length + 2);
                    newArr[q] = arr[w];
                    q++;
                }
            }
            return newArr;
        }
        public static void ShowArray(TArr[] arr)
        {
            foreach (TArr element in arr)
                Console.Write($"{element} ");
            Console.WriteLine();
        }
    }
   
}


