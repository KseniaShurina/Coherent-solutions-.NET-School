namespace Task2._3.Entities
{
    internal class PracticalLesson : TrainingEntity
    {
        public string LinkToTheTaskCondition { get; set; }
        public string LinkToTheSolution { get; set; }

        internal PracticalLesson(string description, string linkToTheTaskCondition, string linkToTheSolution) : base(description)
        {
            LinkToTheTaskCondition = linkToTheTaskCondition;
            LinkToTheSolution = linkToTheSolution;
        }

        public override string? ToString()
        {
            return
                $"Description: {Description}, Link to the task condition: {LinkToTheTaskCondition}, Link to the solution: {LinkToTheSolution}";
        }
    }
}
