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

        public void SaveCurrentItem() {
            Result result;
            if (currentItem.Type == TriathlonType.Triathlon || currentItem.Type == TriathlonType.Swimming || currentItem.Type == TriathlonType.Running || currentItem.Type == TriathlonType.Cycling)
            {

            }
                    }
    }   
}
