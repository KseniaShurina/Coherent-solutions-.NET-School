using Task2._3.Entities;

Training training1 = new Training(".NET");
training1.Add(new PracticalLesson(".NET Development Course with Coherent Solutions", "link1", "link2"));
training1.Add(new Lecture("After this lecture you will definitely become rich and successful", "How to become rich and successful"));

// Cloning training.
var clonedTraining = (Training)training1.Clone();
Console.WriteLine($"Set of lectures of {nameof(clonedTraining)}:");
foreach (var lesson in clonedTraining.Lectures)
{
    Console.WriteLine(lesson.ToString());
}

// Check for deep copy
var description = clonedTraining.Lectures[0].Description = "111";
Console.WriteLine(description);
Console.WriteLine(training1.Lectures[0].Description);


// Here is testing IsPractical() method.
Console.WriteLine();

Training training3 = new Training("Another one training");
training3.Add(new PracticalLesson("Practical", "link3", "link4"));

bool result2 = training3.IsPractical(); // True.
Console.WriteLine($"{nameof(training3)} contains only practical exercise? Answer: {result2}");

bool result1 = training1.IsPractical(); // False.
Console.WriteLine($"{nameof(training1)} contains only practical exercise? Answer: {result1}");