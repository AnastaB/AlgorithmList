using System;
using System.Diagnostics;

class Program
{
    static void Main(string[] args)
    {
        DoublyLinkedList<int> list1 = new DoublyLinkedList<int>();
        DoublyLinkedList<int> list2 = new DoublyLinkedList<int>();

        Random random = new Random();

        for (int i = 0; i < 10; i++)
        {
            list1.AddLast(random.Next(10));
        }
        for (int i = 0; i < 2; i++)
        {
            list2.AddLast(random.Next(10));
        }

        Console.WriteLine("List1:");
        list1.PrintList();

        Console.WriteLine("List2:");
        list2.PrintList();

        #region
        Console.WriteLine("Select a function:");
        Console.WriteLine("1. Add to the end of the list");
        Console.WriteLine("2. Add to the beginning of the list");
        Console.WriteLine("3. Remove the last element");
        Console.WriteLine("4. Remove the first element");
        Console.WriteLine("5. Add an element by index");
        Console.WriteLine("6. Get an element by index");
        Console.WriteLine("7. Remove an element by index");
        Console.WriteLine("8. Get list size");
        Console.WriteLine("9. Delete all list elements");
        Console.WriteLine("10. Replace an element by index with the element being transferred");
        Console.WriteLine("11. Check for empty list");
        Console.WriteLine("12. Reverse the order of elements in the list");
        Console.WriteLine("13. Insert another list into a list, starting at index");
        Console.WriteLine("14. Insert another list at the end");
        Console.WriteLine("15. Insert another list at the beginning");
        Console.WriteLine("16. Check for the content of another list in a list");
        Console.WriteLine("17. Finding the first occurrence of another list in a list");
        Console.WriteLine("18. Finding the last occurrence of another list in a list");
        Console.WriteLine("19. Exchange of two list elements by indexes");
        Console.WriteLine("20. Exit");
        #endregion

        while (true)
        {
            int option = int.Parse(Console.ReadLine());

            switch (option)
            {
                case 1:
                    Console.WriteLine("Enter the value to add:");
                    int value = int.Parse(Console.ReadLine());

                    var runningTime = MeasureRunningTime(() => list1.AddLast(value));
                    Console.WriteLine("\nRunning time: " + runningTime + " ms");
                    break;
                case 2:
                    Console.WriteLine("Enter the value to add:");
                    value = int.Parse(Console.ReadLine());

                    runningTime = MeasureRunningTime(() => list1.AddFirst(value));
                    Console.WriteLine("\nRunning time: " + runningTime + " ms");
                    break;
                case 3:
                    runningTime = MeasureRunningTime(() => list1.RemoveLast());
                    Console.WriteLine("\nRunning time: " + runningTime + " ms");
                    break;
                case 4:
                    runningTime = MeasureRunningTime(() => list1.RemoveFirst());
                    Console.WriteLine("\nRunning time: " + runningTime + " ms");
                    break;
                case 5:
                    Console.WriteLine("Enter the index to add at:");
                    int index = int.Parse(Console.ReadLine());
                    Console.WriteLine("Enter the value to add:");
                    value = int.Parse(Console.ReadLine());

                    runningTime = MeasureRunningTime(() => list1.AddAt(index, value));
                    Console.WriteLine("\nRunning time: " + runningTime + " ms");
                    break;
                case 6:
                    Console.WriteLine("Enter the index to get:");
                    index = int.Parse(Console.ReadLine());
                    value = list1.GetAt(index);
                    Console.WriteLine("Value at index " + index + ": " + value);

                    //runningTime = MeasureRunningTime(() => list.GetAt(index));
                    //Console.WriteLine("\nRunning time: " + runningTime + " ms");
                    break;
                case 7:
                    Console.WriteLine("Enter the index to remove:");
                    index = int.Parse(Console.ReadLine());

                    runningTime = MeasureRunningTime(() => list1.RemoveAt(index));
                    Console.WriteLine("\nRunning time: " + runningTime + " ms");
                    break;
                case 8:
                    Console.WriteLine("List size: " + list1.Count);

                    //runningTime = MeasureRunningTime(() => list.Count);
                    //Console.WriteLine("\nRunning time: " + runningTime + " ms");
                    break;
                case 9:
                    Console.WriteLine("List was deleted");

                    runningTime = MeasureRunningTime(() => list1.Clear());
                    Console.WriteLine("\nRunning time: " + runningTime + " ms");
                    break;
                case 10:
                    Console.WriteLine("Enter an index:");
                    index = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter an integer:");
                    int data10 = int.Parse(Console.ReadLine());

                    list1.ReplaceAt(index, data10);
                    Console.WriteLine("Element replaced at index " + index + ".");
                    break;
                case 11:
                    Console.WriteLine("List is empty: " + list1.IsEmpty());
                    break;
                case 12:
                    list1.Reverse();
                    Console.WriteLine("List elements reversed.");
                    break;
                case 13:
                    //если понадобится определенный список для проверки в любой из функций
                    //DoublyLinkedList<int> otherList = new DoublyLinkedList<int>();
                    //Console.WriteLine("Enter integers to add to the other list (separated by spaces):");
                    //string[] input = Console.ReadLine().Split(' ');
                    //foreach (string s in input)
                    //{
                    //    otherList.AddLast(int.Parse(s));
                    //}
                    //  list1.InsertListAt(index, otherList);

                    Console.WriteLine("Enter an index:");
                    index = int.Parse(Console.ReadLine());

                    list1.InsertListAt(index, list2);
                    Console.WriteLine("Other list inserted into main list at index " + index + ".");
                    break;
                case 14:
                    list1.InsertListAt(list1.Count, list2);
                    Console.WriteLine("Other list inserted at the end of the main list.");
                    break;
                case 15:
                    list1.InsertListAt(0, list2);
                    Console.WriteLine("Other list inserted at the beginning of the main list.");
                    break;
                case 16:
                    if(list1.ContainsList(list2) == true)
                        Console.WriteLine("Main list contains values: " + list2);
                    else 
                        Console.WriteLine("Main list not contains list2");
                    break;
                case 17:
                    if (list1.FindFirstList(list2) == -1)
                    {
                        Console.WriteLine("Other list not found in main list.");
                    }
                    else
                    {
                        Console.WriteLine("Other list found in main list at index " + list1.FindFirstList(list2) + ".");
                    }
                    break;
                case 18:
                    index = list1.FindLastList(list2);
                    if (index == -1)
                    {
                        Console.WriteLine("Other list not found in main list.");
                    }
                    else
                    {
                        Console.WriteLine("Last occurrence of other list found in main list at index " + index + ".");
                    }
                    break;
                case 19:
                    Console.WriteLine("Enter the first index:");
                    int index1 = int.Parse(Console.ReadLine());

                    Console.WriteLine("Enter the second index:");
                    int index2 = int.Parse(Console.ReadLine());

                    list1.ExchangeElements(index1, index2);
                    Console.WriteLine("Elements at indexes " + index1 + " and " + index2 + " swapped.");
                    break;
                case 20:
                    Environment.Exit(0);
                    break;
                default:
                    list1.Clear();
                    break;
            }
           
            list1.PrintList();
        }

        list1.Clear();
        list2.Clear();
    }

    public static double MeasureRunningTime(Action method)
    {
        var stopwatch = new Stopwatch();
        stopwatch.Start();
        method();
        stopwatch.Stop();
        return (double)stopwatch.ElapsedTicks / Stopwatch.Frequency;
    }
}