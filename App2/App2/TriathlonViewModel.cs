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
        public TriathlonTraining CurrentItem {
            get { return currentItem; }
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
