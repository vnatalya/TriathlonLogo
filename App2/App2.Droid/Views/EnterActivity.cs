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
        Button saveButton;
        EditText metersEditText;
        EditText kilometersEditText;

        TriathlonViewModel viewModel { get { return TriathlonViewModel.Instance; } }
        TriathlonTraining currentItem { get { return TriathlonViewModel.Instance.CurrentItem; } }

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.EnterLayout);

            dateButton = FindViewById<Button>(Resource.Id.dateButton);
            timeButton = FindViewById<Button>(Resource.Id.timeButton);
            typeButton = FindViewById<Button>(Resource.Id.typeButton);
            saveButton = FindViewById<Button>(Resource.Id.saveButton);
            metersEditText = FindViewById<EditText>(Resource.Id.mEditView);
            kilometersEditText = FindViewById<EditText>(Resource.Id.kmEditView);
        }

        void Initialize()
        {
            kilometersEditText.Text = (currentItem.Distance % 1000).ToString();
            metersEditText.Text = (currentItem.Distance - (currentItem.Distance % 1000) * 1000).ToString();
            var date = currentItem.Date != DateTime.MinValue ? currentItem.Date.Date : DateTime.Today.Date;
            currentItem.Date = date;
            dateButton.Text = date.Date.ToString();
        }

        void AssignEvents()
        {
            dateButton.Click += DateButton_Click;
            timeButton.Click += TimeButton_Click;
            typeButton.Click += TypeButton_Click;
            saveButton.Click += SaveButton_Click;
        }

        void UnassignEvents()
        {
            dateButton.Click -= DateButton_Click;
            timeButton.Click -= TimeButton_Click;
            saveButton.Click -= SaveButton_Click;
            typeButton.Click -= TypeButton_Click;
        }

        private void DateButton_Click(object sender, EventArgs e)
        {
            DatePickerDialog datePicker = new DatePickerDialog(this, DateSelectedEvent, currentItem.Date.Year, currentItem.Date.Month, currentItem.Date.Day);
            
        }

        private void TimeButton_Click(object sender, EventArgs e)
        {
            TimePickerWithSeconds timePickerDialog = new TimePickerWithSeconds(this, TimeSelectedEvent, 0, 0, 0, 0);
            timePickerDialog.Show();
        }

        private void TimeSelectedEvent(int h, int min, int sec, int milisec)
        {
            //currentItem.Time = new TimeSpan(e.HourOfDay, e.Minute, 0);
            //timeButton.Text = currentItem.Time.ToString();
        }

        private void DateSelectedEvent(object sender, DatePickerDialog.DateSetEventArgs e)
        {
            currentItem.Date = e.Date;
            timeButton.Text = currentItem.Date.ToString();
        }

        private void TypeButton_Click(object sender, EventArgs e)
        {

        }
        

        private void SaveButton_Click(object sender, EventArgs e)
        {
            currentItem.Distance = int.Parse(kilometersEditText.Text) * 1000 + int.Parse(metersEditText.Text);
            var result = viewModel.SaveCurrentItem();
        }
    }
}