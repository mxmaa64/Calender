using Xamarin.Forms.Platform.Android;
using RoyalTalentShared.Droid;
using Xamarin.Forms;
using Android.Widget;
using Android.Graphics;
using Android.App;
using Calendar;
using Calendar.Droid;

[assembly: ExportRenderer(typeof(MyMasterDetailPage), typeof(MyContentPageRenderer))]

namespace RoyalTalentShared.Droid
{
    class MyContentPageRenderer : PageRenderer
    {
        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            var actionBar = ((Activity)Context).ActionBar;
            LinearLayout layout = new LinearLayout(Context);
            layout.Orientation = Orientation.Horizontal;
            layout.WeightSum = 100;
            TextView title = new TextView(Context);
            title.Text = actionBar.Title;

            title.TextSize = 18;
            Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "BTrafcBd.ttf");
            title.Typeface = font;

            LayoutParams textlp = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

            ImageView logo = new ImageView(Context);
            logo.SetImageResource(Resource.Drawable.Logo);
            LayoutParams imglp = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

            layout.AddView(title, textlp);
            layout.AddView(logo, imglp);
            actionBar.SetCustomView(layout, new ActionBar.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent));
            actionBar.SetDisplayOptions(ActionBarDisplayOptions.ShowCustom, ActionBarDisplayOptions.ShowCustom);
        }
    }
}