namespace Task2._3.Entities
{
    internal class Training : TrainingEntity
    {
        //Set of lectures;
        public TrainingEntity[] Lectures;

        internal Training(string description) : base(description)
        {
            Lectures = [];
        }

        // Method add new lesson to Lessons.
        public void Add(TrainingEntity lecture)
        {
            if (lecture == null)
            {
                throw new ArgumentNullException(nameof(lecture));
            }
            Array.Resize(ref Lectures, Lectures.Length + 1);
            Lectures[^1] = lecture;
        }

        // Method checks if the training contains only practical exercises.
        public bool IsPractical()
        {

            foreach (var lecture in Lectures)
            {
                if (lecture is not PracticalLesson)
                {
                    return false;
                }
            }

            return true;
        }

        // Method is cloning training.
        public override object Clone()
        {
            Training training = new Training(this.Description);

            foreach (TrainingEntity lecture in this.Lectures)
            {
                training.Add((TrainingEntity)lecture.Clone());
            }

            return training;
        }
    }
}
