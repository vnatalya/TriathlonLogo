using System;
using System.Collections.Generic;
using System.Text;
using static App2.TriathlonTraining;

namespace App2
{
    class TriathlonViewModel
    {
        private static TriathlonViewModel instance;
        public static TriathlonViewModel Instance
        {
            get
            {
                if (instance == null)
                {
                 
                    //lock (true)
                    //{
                    //    if (instance == null)
                            instance = new TriathlonViewModel();
                    //}
                }
                
                return instance;
            }
        }

        public static StringService StringService;

        private TriathlonTraining currentItem;
        public TriathlonTraining CurrentItem
        {
            get { return currentItem; }
        }

        public List<string> HeadersList;
        public Dictionary<string, List<string>> ChildrenList;

        public void Initialize()
        {
            SetTriathlonTypesLists();
        }

        void SetTriathlonTypesLists()
        {
            HeadersList.Add(StringService.Triathlon);
            HeadersList.Add(StringService.Swimming);
            HeadersList.Add(StringService.Running);
            HeadersList.Add(StringService.Cycling);

            var swimmingListView = new List<string>();
            swimmingListView.Add(StringService.Butterfly);
            swimmingListView.Add(StringService.Freestyle);
            swimmingListView.Add(StringService.Breaststroke);
            swimmingListView.Add(StringService.Backstroke);
            swimmingListView.Add(StringService.SwimmingExercices);

            ChildrenList.Add(StringService.Swimming, swimmingListView);

            var runningListView = new List<string>();
            swimmingListView.Add(StringService.Run);
            swimmingListView.Add(StringService.RunningExercises);

            ChildrenList.Add(StringService.Running, runningListView);

            var cyclingListView = new List<string>();
            swimmingListView.Add(StringService.Bike);
            swimmingListView.Add(StringService.Trainer);

            ChildrenList.Add(StringService.Cycling, cyclingListView);
        }

        public void SetCurrentItem(int id = -1) {
            if (id != -1)
            {
                currentItem = new TriathlonTraining();
            }
            else
            {
                currentItem = DataBaseService.Instance.GetTriathlonTrainingById(id);
            }
        }

        public Result SaveCurrentItem()
        {
            Result result = new Result(true, StringService.TrainingSaved, string.Empty);

            if (currentItem.Type == TriathlonType.Triathlon || currentItem.Type == TriathlonType.Swimming || currentItem.Type == TriathlonType.Running || currentItem.Type == TriathlonType.Cycling)
            {
                result.Status = false;
                result.Title = StringService.CouldntSave;
                result.ErrorMessage = StringService.IncorrectType;
                return result;
            }

            if (currentItem.Distance == 0 && currentItem.Type != TriathlonType.Trainer)
            {
                result.Status = false;
                result.Title = StringService.CouldntSave;
                result.ErrorMessage = StringService.IncorrectDistance;
                return result;
            }

            if (currentItem.Time == TimeSpan.Zero)
            {
                result.Status = false;
                result.Title = StringService.CouldntSave;
                result.ErrorMessage = StringService.IncorrectTime;
                return result;
            }

            DataBaseService.Instance.SaveTrinathlonTraining(currentItem);

            return result;
        }
    }   
}
