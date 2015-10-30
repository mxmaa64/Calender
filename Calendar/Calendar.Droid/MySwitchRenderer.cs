using Calendar;
using Calendar.Droid;
using Xamarin.Forms;
using Android.Graphics;

[assembly: ExportRenderer(typeof(CustomSwitch), typeof(MySwitchRenderer))]

namespace Calendar.Droid
{
    using Xamarin.Forms.Platform.Android;

    using Switch = Android.Widget.Switch;
    class MySwitchRenderer: ViewRenderer<CustomSwitch, Switch>
    {
        protected override void OnElementChanged(ElementChangedEventArgs<CustomSwitch> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement != null || this.Element == null)
            {
                return;
            }

            var switchControl = new Switch(Forms.Context)
            {
                TextOn = this.Element.TextOn,
                TextOff = this.Element.TextOff,
                Text = this.Element.Text               
            };

            this.SetNativeControl(switchControl);

            Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "BTrafcBd.ttf");
            Control.Typeface = font;
        }
    }
}