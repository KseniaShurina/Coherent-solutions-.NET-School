// Creating new training.
Training training1 = new Training(".NET");
training1.Add(new PracticalExercise(".NET Development Course with Coherent Solutions", "link1", "link2"));
training1.Add(new Lecture("After this lecture you will definitely become rich and successful", "How to become rich and successful"));

// Cloning training.
var clonedTraining = (Training)training1.Clone();
Console.WriteLine($"Set of lectures of {nameof(clonedTraining)}:");
foreach (var lesson in clonedTraining.Lessons)
{
    Console.WriteLine(lesson.ToString());
}

// Here is testing IsPractical() method.
Console.WriteLine();
Training training3 = new Training("Another one training");
training3.Add(new PracticalExercise("Practical", "link3", "link4"));

bool result2 = training3.IsPractical(); // True.
Console.WriteLine($"{nameof(training3)} contains only practical exercise? Answer: {result2}");

bool result1 = training1.IsPractical(); // False.
Console.WriteLine($"{nameof(training1)} contains only practical exercise? Answer: {result1}");

public class Lecture
{
    public string Topic { get; set; } = null!;
    public string TextDescription { get; set; } = null!;
    
    public Lecture(string textDescription, string topic)
    {
        TextDescription = textDescription;
        Topic = topic;
    }

    public override string? ToString()
    {
        return $"Topic: {Topic}, Description: {TextDescription}";
    }
}

public class Training : ICloneable
{
    public string TextDescription { get; set; } = null!;

    public List<object> Lessons = new List<object>();

    public Training(string textDescription)
    {
        TextDescription = textDescription;
        Lessons = new List<object>();
    }

    // Method add new lesson to Lessons.
    public void Add(object lesson)
    {
        if (lesson.GetType() == typeof(PracticalExercise) || lesson.GetType() == typeof(Lecture))
        {
            Lessons.Add(lesson);
        }
        else
        {
            Console.WriteLine("Error: lesson type not supported.");
        }
    }

    // Method checks if the training contains only practical exercises.
    public bool IsPractical()
    {
        foreach (var lesson in Lessons)
        {
            if (lesson.GetType() == typeof(Lecture))
            {
                return false;
            }
        }

        return true;
    }

    // Method is cloning training.
    public object Clone()
    {
        Training training = new Training(this.TextDescription);

        foreach (var lesson in Lessons)
        {
            if (lesson is PracticalExercise)
            {
                var practicalExercise = (PracticalExercise)lesson;
                training.Add(
                    new PracticalExercise(practicalExercise.TextDescription, 
                        practicalExercise.LinkToTheTaskCondition, 
                        practicalExercise.LinkToTheSolution));
            }
            else
            {
                var lecture = (Lecture)lesson;
                training.Add(new Lecture(lecture.TextDescription, lecture.Topic));
            }
        }

        return training;
    }
}

public class PracticalExercise
{
    public string TextDescription { get; set; }
    public string LinkToTheTaskCondition { get; set; }
    public string LinkToTheSolution { get; set; }

    public PracticalExercise(string textDescription, string linkToTheTaskCondition, string linkToTheSolution)
    {
        TextDescription = textDescription;
        LinkToTheTaskCondition = linkToTheTaskCondition;
        LinkToTheSolution = linkToTheSolution;
    }

    public override string? ToString()
    {
        return
            $"Description: {TextDescription}, Link to the task condition: {LinkToTheTaskCondition}, Link to the solution: {LinkToTheSolution}";
    }
}