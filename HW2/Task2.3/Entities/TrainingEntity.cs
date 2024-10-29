namespace Task2._3.Entities
{
    internal class TrainingEntity
    {
        internal string Description { get; set; }

        internal TrainingEntity(string description)
        {
            Description = description;
        }

        public virtual object Clone()
        {
            return new TrainingEntity(this.Description);
        }
    }
}
