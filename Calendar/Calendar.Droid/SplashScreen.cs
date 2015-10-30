using Android.App;
using Android.Content.PM;
using Android.OS;
using Java.Lang;

namespace Calendar.Droid
{
    [Activity(Icon = "@drawable/icon", Theme = "@style/Theme.Splash", MainLauncher = true, NoHistory = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation, ScreenOrientation = ScreenOrientation.Portrait)]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            Thread.Sleep(500);
            StartActivity(typeof(MainActivity));
        }
    }
}