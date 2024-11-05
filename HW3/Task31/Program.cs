using Task31;
using Task31.Extensions;

Task31.Queue<int> queue1 = new Task31.Queue<int>(1, 2, 3);

Console.WriteLine("\n Created queue:");
ForeachQueue(queue1); // 1 2 3

Console.WriteLine("\n Add new item queue:");
queue1.Enqueue(4);
ForeachQueue(queue1); // 1 2 3 4

Console.WriteLine("\n Remove first item from queue:");
int removedItem = queue1.Dequeue();
Console.WriteLine($"First item - {removedItem}"); // 1
ForeachQueue(queue1); // 2 3 4

Console.WriteLine("\n Method Tail:");
var queue2 = queue1.Tail();
ForeachQueue(queue2); // 3 4


void ForeachQueue(IQueue<int> queue)
{
    foreach (var item in queue)
    {
        Console.Write($"{item} ");
    }
}
