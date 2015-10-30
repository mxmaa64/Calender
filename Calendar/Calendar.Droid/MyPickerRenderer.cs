using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Calendar.Droid;
using Android.Graphics;

[assembly: ExportRenderer(typeof(TimePicker), typeof(MyPickerRenderer))]


namespace Calendar.Droid
{
    class MyPickerRenderer : TimePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<TimePicker> e)
        {
            base.OnElementChanged(e);

            Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "BTrafcBd.ttf");
            Control.SetTextColor(Android.Graphics.Color.Black);
            Control.Typeface = font;
        }
    }
}