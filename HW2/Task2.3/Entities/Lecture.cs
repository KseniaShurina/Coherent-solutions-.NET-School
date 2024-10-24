namespace Task2._3.Entities
{
    internal class Lecture : TrainingEntity
    {
        public string Topic { get; set; }

        internal Lecture(string description, string topic) : base(description)
        {
            Topic = topic;
        }

        public override string? ToString()
        {
            return $"Topic: {Topic}, Description: {Description}";
        }
    }
}
