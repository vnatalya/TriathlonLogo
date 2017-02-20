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
    class EnterActivity : Activity
    {
        Button dateButton;
        Button typeButton;
        Button timeButton;
        EditText metersEditText;
        EditText kilometersEditText;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EnterLayout);

            dateButton = FindViewById<Button>(Resource.Id.dateButton);
            timeButton = FindViewById<Button>(Resource.Id.timeButton);
            typeButton = FindViewById<Button>(Resource.Id.typeButton);
            metersEditText = FindViewById<EditText>(Resource.Id.mEditView);
            kilometersEditText = FindViewById<EditText>(Resource.Id.kmEditView);
        }
    }
}