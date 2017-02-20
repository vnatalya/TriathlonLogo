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

        public string TrainingSaved { get { return trainingSaved; } }
        public string CouldntSave { get { return couldntSave; } }
        public string IncorrectDistance { get { return incorrectDistance; } }
        public string IncorrectTime { get { return incorrectTime; } }
    }
}
