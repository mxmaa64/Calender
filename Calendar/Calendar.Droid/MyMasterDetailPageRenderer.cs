using Android.Views;
using Xamarin.Forms.Platform.Android;
using Android.Support.V4.View;
using Xamarin.Forms;
using Calendar.Droid;
using Calendar;
using Android.Graphics;
using Android.App;
using Android.Widget;

[assembly: ExportRenderer(typeof(MyMasterDetailPage), typeof(MyMasterDetailPageRenderer))]

namespace Calendar.Droid
{
    class MyMasterDetailPageRenderer : PageRenderer
    {
        //used for detecting flings
        private GestureDetectorCompat mDetector;

        public MyMasterDetailPageRenderer() : base()
        {
            this.mDetector = new GestureDetectorCompat(Context, new MyGestureListener(this));
        }

        public override bool OnTouchEvent(MotionEvent e)
        {

            //detect any flings
            this.mDetector.OnTouchEvent(e);

            //find the action, get the percent and send to the right master detail
            int action = MotionEventCompat.GetActionMasked(e);
            float percent = 1 - ((Width - e.GetX()) / Width);
            switch (e.Action)
            {
                case MotionEventActions.Down:
                    ((MyMasterDetailPage)Element).doDown(percent);
                    break;
                case MotionEventActions.Up:
                    ((MyMasterDetailPage)Element).doUp(percent);
                    break;
                case MotionEventActions.Move:
                    ((MyMasterDetailPage)Element).doMove(percent);
                    break;
                default:
                    break;
            }

            return base.OnTouchEvent(e);
        }

        //fire the touch for this page when any of its children are being touched too
        public override bool DispatchTouchEvent(MotionEvent e)
        {
            this.OnTouchEvent(e);
            return base.DispatchTouchEvent(e);
        }

        public override bool OnInterceptTouchEvent(MotionEvent ev)
        {
            this.OnTouchEvent(ev);
            return base.OnInterceptTouchEvent(ev);
        }

        //the class for handling the fling
        private class MyGestureListener : GestureDetector.SimpleOnGestureListener
        {

            private MyMasterDetailPageRenderer renderer;

            public MyGestureListener(MyMasterDetailPageRenderer renderer)
            {
                this.renderer = renderer;
            }

            public override bool OnFling(MotionEvent e1, MotionEvent e2, float velocityX, float velocityY)
            {
                float percent1 = 1 - ((renderer.Width - e1.GetX()) / renderer.Width);
                float percent2 = 1 - ((renderer.Width - e2.GetX()) / renderer.Width);
                ((MyMasterDetailPage)renderer.Element).doFling(percent1, percent2);

                return true;
            }
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Page> e)
        {
            base.OnElementChanged(e);

            var actionBar = ((Activity)Context).ActionBar;
            LinearLayout layout = new LinearLayout(Context);
            layout.Orientation = Orientation.Horizontal;
            layout.WeightSum = Width;
            layout.SetGravity(GravityFlags.Left);
            TextView title = new TextView(Context);
            title.Text = actionBar.Title;

            title.TextSize = 18;
            Typeface font = Typeface.CreateFromAsset(Forms.Context.Assets, "BTrafcBd.ttf");
            title.Typeface = font;

            LayoutParams textlp = new LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent);

            ImageView logo = new ImageView(Context);

            logo.Clickable = true;
            logo.Click += Logo_Click;

            logo.SetImageResource(Resource.Drawable.Logo);
            logo.SetScaleType(ImageView.ScaleType.FitStart);
            layout.AddView(logo);
            actionBar.SetCustomView(layout, new ActionBar.LayoutParams(LayoutParams.MatchParent, LayoutParams.MatchParent));
            actionBar.SetDisplayOptions(ActionBarDisplayOptions.ShowCustom, ActionBarDisplayOptions.ShowCustom);
        }

        private void Logo_Click(object sender, System.EventArgs e)
        {
            App.HomePage.Detail.Navigation.PushAsync(new NavigationPage(new MainMenu()));
            App.HomePage.Detail.Title = "NOMAINPAGE";
        }
    }
}