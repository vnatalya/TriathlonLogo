using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App2.Droid
{
    class TimePickerWithSeconds : AlertDialog
    {
        public TimePickerWithSeconds(Context context, Action<int,int,int,int> callBack,
            int hourOfDay, int minute, int seconds, int miliseconds) : base(context)
        {
            LayoutInflater inflater =
                (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            View view = inflater.Inflate(Resource.Layout.TimePickerWithSecondsLayout, null);
            SetView(view);
        }
        //https://github.com/IvanKovac/TimePickerWithSeconds/blob/master/src/com/ikovac/timepickerwithseconds/view/MyTimePickerDialog.java


    }
}