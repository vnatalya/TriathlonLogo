using System;
using System.Collections.Generic;
using System.Text;

namespace App2
{
    public abstract class StringService
    {
        public virtual void Init()
        { }

        public StringService()
        {
            Init();
        }
        protected string trainingSaved;
        public string couldntSave;
        protected string incorrectDistance;
        protected string incorrectTime;
        protected string incorrectType;
        protected string swimming;
        protected string backstroke;
        protected string breaststroke;
        protected string butterfly;
        protected string swimmingExercices;
        protected string running;
        protected string run;
        protected string runningExercises;
        protected string cycling;
        protected string bike;
        protected string trainer; 
        protected string triathlon;
        protected string freestyle;

        public string TrainingSaved { get { return trainingSaved; } }
        public string CouldntSave { get { return couldntSave; } }
        public string IncorrectDistance { get { return incorrectDistance; } }
        public string IncorrectTime { get { return incorrectTime; } }
        public string Breaststroke { get { return breaststroke; } }
        public string Backstroke { get { return backstroke; } }
        public string Butterfly { get { return butterfly; } }
        public string SwimmingExercices { get { return swimmingExercices; } }
        public string Running { get { return running; } }
        public string RunningExercises { get { return runningExercises; } }
        public string Run { get { return run; } }
        public string Cycling { get { return cycling; } }
        public string Bike { get { return bike; } }
        public string Trainer { get { return trainer; } }
        public string Triathlon { get { return triathlon; } }
        public string Swimming { get { return swimming; } }
        public string Freestyle { get { return freestyle; } }
        public string IncorrectType { get { return incorrectType; } }
    }
}
