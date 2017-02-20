using System;
using System.Collections.Generic;
using System.Text;

namespace App2
{
    class TriathlonTraining
    {
        public enum TriathlonType
        {
            Triathlon = 0,
            Swimming = 10,
            Running = 20,
            Cycling = 30,
            SwimmingExercises = 11,
            Butterfly = 12,
            Frrestyle = 13,
            Breaststroke = 14,
            Beakstroke = 15,
            RunningExercises = 21,
            Run = 22,
            Bike = 31,
            Trainer = 32
        };

        private TriathlonType type;
        public TriathlonType Type
        {
            get { return type; }
            set
            {
                type = value;
            }
        }

        private DateTime date;
        public DateTime Date
        {
            get { return date; }
            set
            {
                date = value;
            }
        }

        private TimeSpan time;
        public TimeSpan Time
        {
            get { return time; }
            set
            {
                time = value;
            }
        }

        private double distance;
        public double Distance
        {
            get { return distance; }
            set
            {
                distance = value;
            }
        }

        private int id;
        public int Id
        {
            get; set;
        }

        public TriathlonTraining()
        {
            id = -1;
            distance = 0;
            time = TimeSpan.Zero;
            date = DateTime.MinValue;
            type = TriathlonType.Triathlon;
        }
    }
}
