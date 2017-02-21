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

        NumberPicker hourPicker;
        NumberPicker minPicker;
        NumberPicker secPicker;
        NumberPicker milisecPicker;
        Action<int, int, int, int> DismissCallback;

        public TimePickerWithSeconds(Context context, Action<int,int,int,int> callBack,
            int hourOfDay, int minute, int seconds, int miliseconds) : base(context)
        {
            LayoutInflater inflater =
                (LayoutInflater)context.GetSystemService(Context.LayoutInflaterService);
            View view = inflater.Inflate(Resource.Layout.TimePickerWithSecondsLayout, null);
            SetView(view);

            hourPicker = view.FindViewById<NumberPicker>(Resource.Id.hour);
            minPicker = view.FindViewById<NumberPicker>(Resource.Id.minute);
            secPicker = view.FindViewById<NumberPicker>(Resource.Id.seconds);
            milisecPicker = view.FindViewById<NumberPicker>(Resource.Id.miliseconds);

            hourPicker.Value = hourOfDay;
            minPicker.Value = minute;
            secPicker.Value = seconds;
            milisecPicker.Value = miliseconds;

            DismissCallback = callBack;
        }

        public override void SetOnDismissListener(IDialogInterfaceOnDismissListener listener)
        {
            base.SetOnDismissListener(listener);
            DismissCallback.Invoke(hourPicker.Value, minPicker.Value, secPicker.Value, milisecPicker.Value);
        }
        //https://github.com/IvanKovac/TimePickerWithSeconds/blob/master/src/com/ikovac/timepickerwithseconds/view/MyTimePickerDialog.java


    }
}