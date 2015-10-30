using System;
using Xamarin.Forms.Platform.Android;
using RoyalTalentShared;
using RoyalTalentShared.Droid;
using Xamarin.Forms;
using Android.Widget;
using Android.Graphics;

[assembly: ExportRenderer(typeof(Xamarin.Forms.Button), typeof(MyButtonRender))]

namespace RoyalTalentShared.Droid
{
    class MyButtonRender: ButtonRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.Button> e)
        {
            base.OnElementChanged(e);

            Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "BTrafcBd.ttf");
            Control.Typeface = font;
        }
    }
}