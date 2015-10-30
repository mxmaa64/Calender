using Android.App;
using Android.Content.PM;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.OS;
using System;
using Xamarin.Forms.Platform.Android;

namespace Calendar.Droid
{
	[Activity (Label = "Calendar", Icon = "@drawable/icon", MainLauncher = false, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
	public class MainActivity : FormsApplicationActivity
	{
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);
            ActionBar.SetIcon(new ColorDrawable(Color.Transparent));

            var metrics = Resources.DisplayMetrics;
            var widthInDp = ConvertPixelsToDp(metrics.WidthPixels);
            var heightInDp = ConvertPixelsToDp(metrics.HeightPixels);

            FixParams.ScreenHeight = widthInDp;
            FixParams.ScreenWidth = heightInDp;
            var Aspect = Math.Round(Math.Sqrt(Math.Pow(widthInDp, 2) + Math.Pow(heightInDp, 2))) / 611;

            if (Aspect < 1) Aspect = 1;
            FixParams.AspectRate = Aspect;


            Xamarin.Forms.Forms.Init(this, bundle);
            LoadApplication(new App());
        }

        private int ConvertPixelsToDp(float pixelValue)
        {
            var dp = (int)((pixelValue) / Resources.DisplayMetrics.Density);
            return dp;
        }
    }
}

