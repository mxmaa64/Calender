using System;
using Xamarin.Forms;


namespace Calendar
{
    public class CircularProgress : View
    {
        public CircularProgress()
        {

        }

        public static readonly BindableProperty IndeterminateProperty =
            BindableProperty.Create<CircularProgress, bool>(
                p => p.Indeterminate, default(bool));

        public bool Indeterminate
        {
            get { return (bool)GetValue(IndeterminateProperty); }
            set { SetValue(IndeterminateProperty, value); }
        }


        public static readonly BindableProperty ProgressProperty =
            BindableProperty.Create<CircularProgress, float>(
                p => p.Progress, 0);

        public float Progress
        {
            get { return (float)GetValue(ProgressProperty); }
            set { SetValue(ProgressProperty, value); }
        }


        public static readonly BindableProperty MaxProperty =
            BindableProperty.Create<CircularProgress, float>(
                p => p.Max, 100);

        public float Max
        {
            get { return (float)GetValue(MaxProperty); }
            set { SetValue(MaxProperty, value); }
        }

        public static readonly BindableProperty ProgressBackgroundColorProperty =
            BindableProperty.Create<CircularProgress, Color>(
                p => p.ProgressBackgroundColor, Color.White);

        public Color ProgressBackgroundColor
        {
            get { return (Color)GetValue(ProgressBackgroundColorProperty); }
            set { SetValue(ProgressBackgroundColorProperty, value); }
        }


        public static readonly BindableProperty ProgressColorProperty =
            BindableProperty.Create<CircularProgress, Color>(
                p => p.ProgressColor, Color.Red);

        public Color ProgressColor
        {
            get { return (Color)GetValue(ProgressColorProperty); }
            set { SetValue(ProgressColorProperty, value); }
        }

        public static readonly BindableProperty IndeterminateSpeedProperty =
            BindableProperty.Create<CircularProgress, int>(
                p => p.IndeterminateSpeed, 100);

        public int IndeterminateSpeed
        {
            get { return (int)GetValue(IndeterminateSpeedProperty); }
            set { SetValue(IndeterminateSpeedProperty, value); }
        }
    }
}
