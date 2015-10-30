using Xamarin.Forms.Platform.Android;
using Calendar.Droid;
using Xamarin.Forms;
using Android.Widget;
using Android.Graphics;
using System;

[assembly: ExportRenderer(typeof(Label), typeof(MyLabelRenderer))]

namespace Calendar.Droid
{
    class MyLabelRenderer : LabelRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Label> e)
        {
            base.OnElementChanged(e);


            var label = Control; 
            Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "BTrafcBd.ttf");
            label.Typeface = font;
        }
    }
}