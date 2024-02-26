using System;
using System.Collections.Generic;

namespace TrainerTraineeApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Training training = new Training();
            Trainer trainer = new Trainer();
            training.TheTrainer = trainer;
            Organization org = new Organization();
            org.Name = "Pratian Technologies";
            trainer.Org = org;

            Console.WriteLine($"Org Name : {training.GetTrainingOrgName()}");


            Trainee t1 = new Trainee();
            Trainee t2 = new Trainee();
            Trainee t3 = new Trainee();
            Trainee t4 = new Trainee();
            Trainee t5 = new Trainee();

            training.Trainees.Add(t1);
            training.Trainees.Add(t2);
            training.Trainees.Add(t3);
            training.Trainees.Add(t4);
            training.Trainees.Add(t5);



            Console.WriteLine($"Trainees Count : {training.GetNumOfTrainees()}");



            Course course = new Course();
            training.TheCourse = course;
            Module m1 = new Module();
            Module m2 = new Module();
            course.Modules.Add(m1);
            course.Modules.Add(m2);

            Unit u1 = new Unit { Duration = 10 };
            m1.Units.Add(u1);
            Unit u2 = new Unit { Duration = 60 };
            m1.Units.Add(u2);
            Unit u3 = new Unit { Duration = 30 };
            m2.Units.Add(u3);
            Unit u4 = new Unit { Duration = 20 };
            m2.Units.Add(u4);


            Console.WriteLine($"Training Duration  : {training.GetTrainingDurationInHourse()}");

        }
    }

    class Organization
    {
        public string Name { get; set; }

        //private string name;
        //public GetName()
        //{
        //    return name;
        //}
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
            int traineesCount = Trainees.Count;
            // find the count
            return traineesCount;
        }

        public string GetTrainingOrgName()
        {
            return TheTrainer.Org.Name;
        }

        public int GetTrainingDurationInHourse()
        {
            int totalDuration = 0;
            // for each module in course
            foreach (Module m in TheCourse.Modules)
            {
                // for each unit in a module
                foreach (Unit unit in m.Units)
                {
                    totalDuration += unit.Duration;
                }
            }
            return totalDuration;
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
