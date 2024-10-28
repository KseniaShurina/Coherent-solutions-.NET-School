using Task31.Extensions;
using Task31;

Task31.Queue<int> queue = new Task31.Queue<int>(1, 2, 3);

Console.WriteLine("\n Created queue:");
ForeachQueue();

Console.WriteLine("\n Add new item queue:");
queue.Enqueue(4);
ForeachQueue();

Console.WriteLine("\n Remove first item from queue:");
int removedItem = queue.Dequeue();
Console.WriteLine($"First item - {removedItem}");
ForeachQueue();

Console.WriteLine("\n Return queue without first item:");
IQueue<int> result = TailExtension<int>.Tail(queue);
ForeachQueue();

void ForeachQueue()
{
    foreach (var number in queue)
    {
        Console.Write($"{number} ");
    }
}
