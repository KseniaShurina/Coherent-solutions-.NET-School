namespace Task2._3.Entities
{
    internal class Training : TrainingEntity, ICloneable
    {
        //Set of lectures;
        public object[] lectures;

        internal Training(string description) : base(description)
        {
            lectures = [];
        }

        // Method add new lesson to Lessons.
        public void Add(object lecture)
        {
            if (lecture.GetType() == typeof(PracticalLesson) || lecture.GetType() == typeof(Lecture))
            {
                Array.Resize(ref lectures, lectures.Length + 1);
                lectures[^1] = lecture;
            }
            else
            {
                Console.WriteLine("Error: lecture type not supported.");
            }
        }

        // Method checks if the training contains only practical exercises.
        public bool IsPractical()
        {
            foreach (var lecture in lectures)
            {
                if (lecture.GetType() == typeof(Lecture))
                {
                    return false;
                }
            }

            return true;
        }

        // Method is cloning training.
        public object Clone()
        {
            Training training = new Training(this.Description);

            foreach (var lecture in lectures)
            {
                if (lecture is PracticalLesson)
                {
                    var clonedPracticalLesson = (PracticalLesson)lecture;
                    training.Add(
                        new PracticalLesson(clonedPracticalLesson.Description,
                            clonedPracticalLesson.LinkToTheTaskCondition,
                            clonedPracticalLesson.LinkToTheSolution));
                }
                else
                {
                    var clonedLecture = (Lecture)lecture;
                    training.Add(new Lecture(clonedLecture.Description, clonedLecture.Topic));
                }
            }

            return training;
        }
    }
}
