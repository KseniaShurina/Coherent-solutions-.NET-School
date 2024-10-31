using Task31.Extensions;
Task31.Queue<int> queue1 = new Task31.Queue<int>();
Task31.Queue<int> queue = new Task31.Queue<int>(1, 2, 3);

Console.WriteLine("\n Created queue:");
queue.Foreach();

Console.WriteLine("\n Add new item queue:");
queue.Enqueue(4);
queue.Foreach();

Console.WriteLine("\n Remove first item from queue:");
int removedItem = queue.Dequeue();
Console.WriteLine($"First item - {removedItem}");
queue.Foreach();

Console.WriteLine("\n Return queue without first item:");
TailExtension<int>.Tail(queue);
queue.Foreach();
