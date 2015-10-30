using System;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Calendar
{
    public class CalendarWeekView : ContentPage
    {
        public int ActiveWeekNumber;
        public Grid grdWeekDays = new Grid();

        public void OnDayClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        /*public async void OnMonthClicked(object sender, EventArgs e)
        {
            FixParams.FromOut = true;
            FixParams.ActiveDate = _ActiveDate;
            await Navigation.PushAsync(new CalnedarMonthView());
        }*/

        public CalendarWeekView ()
        {
            StackLayout layout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = FixParams.PanelColor,
                Padding = 2 * FixParams.AspectRate
            };

            layout.Children.Add(App.GridOfWeeks[ActiveWeekNumber + 1]);

            Button btnGotoDayView = new Button()
            {
                BackgroundColor = FixParams.PanelColor,
                Text = "روز",
                FontSize = FixParams.StandardSize,
                TextColor = FixParams.FontColor,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };

            Button btnGotoMonthView = new Button()
            {
                BackgroundColor = FixParams.PanelColor,
                Text = "ماه",
                FontSize = FixParams.StandardSize,
                TextColor = FixParams.FontColor,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };

            btnGotoDayView.Clicked += OnDayClicked;
            //btnGotoMonthView.Clicked += OnMonthClicked;

            StackLayout ButtomLayout = new StackLayout
            {
                Children =
                {
                    btnGotoDayView,
                    btnGotoMonthView
                },
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = FixParams.PanelColor,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            layout.Children.Add(ButtomLayout);
            Content = layout;
        }
    }
}
       