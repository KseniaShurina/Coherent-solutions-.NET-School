using Task31.Extensions;

Task31.Queue<int> queue1 = new Task31.Queue<int>(1, 2, 3);

Console.Write("Created queue: ");
queue1.ForeachQueue(); // 1 2 3
Console.WriteLine();

Console.Write("Add new item queue: ");
queue1.Enqueue(4);
queue1.ForeachQueue(); // 1 2 3 4
Console.WriteLine();

Console.Write("Remove first item from queue: ");
int removedItem = queue1.Dequeue();
queue1.ForeachQueue(); // 2 3 4
Console.WriteLine($"First item - {removedItem}"); // 1

Console.Write("Method Tail: ");
var queue2 = (Task31.Queue<int>)queue1.Tail();
queue2.ForeachQueue(); // 3 4
Console.WriteLine();