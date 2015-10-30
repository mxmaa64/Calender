using Xamarin.Forms.Platform.Android;
using Xamarin.Forms;
using Calendar.Droid;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;

[assembly: ExportRenderer(typeof(Entry), typeof(MyEntryRenderer))]

namespace Calendar.Droid
{
    class MyEntryRenderer : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            if (e.OldElement == null)
            {
                var shape = new ShapeDrawable(new RectShape());
                shape.Paint.Color = Android.Graphics.Color.Transparent;
                shape.Paint.StrokeWidth = 2;
                shape.Paint.SetStyle(Paint.Style.Stroke);

                Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "BTrafcBd.ttf");
                Control.Typeface = font;
                Control.TextSize = 14;
                Control.SetBackgroundDrawable(shape);
            }
        }
    }
}
