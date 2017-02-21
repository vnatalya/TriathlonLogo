using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Support.V4.App;

namespace App2.Droid
{
	[Activity (Label = "App2.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : FragmentActivity
    {
        Button filterButton;
        ActionBar actionBar;
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
			SetContentView (Resource.Layout.Main);

            filterButton = FindViewById<Button>(Resource.Id.filterButton);
		}

        protected override void OnResume()
        {
            base.OnResume();

            filterButton.Click += FilterButton_Click;

            global::Android.Support.V4.App.FragmentTransaction fragmentTx = this.SupportFragmentManager.BeginTransaction();
            global::Android.Support.V4.App.Fragment fragment = new ChartFragment();
            
            fragmentTx.Replace(Resource.Id.contentFrame, fragment);
            fragmentTx.Commit();
        }

        private void FilterButton_Click(object sender, EventArgs e)
        {
            TriathlonViewModel.Instance.SetCurrentItem();
            var intent = new Intent(this, typeof(EnterActivity));
            StartActivity(intent);
        }
    }
}


