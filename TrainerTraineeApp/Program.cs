using System.Collections.Generic;

namespace TrainerTraineeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
        }
    }

    class Organization
    {
        public string Name { get; set; }
    }
    class Trainer
    {
        public Organization Org { get; set; }
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
        public List<Training> Trainings { get; set; } = new List<Training>();
    }
    class Trainee
    {
        public Trainer TheTrainer { get; set; }
        public List<Training> Trinings { get; set; } = new List<Training>();
    }
    class Training
    {
        public Trainer TheTrainer { get; set; }
        public List<Trainee> Trainees { get; set; } = new List<Trainee>();
        public Course TheCourse { get; set; }

        public int GetNumOfTrainees()
        {
            //throw new System.NotImplementedException();
            int traineesCount = 0;
            // find the count
            return traineesCount;
        }

        public string GetTrainingOrgName()
        {
            return null;
        }

        public int GetTrainingDurationInHourse()
        {
            return 0;
        }
    }
    class Course
    {
        public List<Training> Trainings { get; set; } = new List<Training>();
        public List<Module> Modules { get; set; } = new List<Module>();
    }
    class Module
    {
        public List<Unit> Units { get; set; } = new List<Unit>();
    }
    class Unit
    {
        public int Duration { get; set; }
        public List<Topic> Topics { get; set; } = new List<Topic>();
    }
    class Topic
    {
        public string Name { get; set; }

    }
}
