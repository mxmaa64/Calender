using Xamarin.Forms;

namespace Calendar
{
	public class AddMainGoal : ContentPage
	{
        public string overview = "";
        public string title = "";
        public string priority = "";
        public string desc = "";

        public Entry txtOverview = new Entry
        {
            Text = "",
            Placeholder = "چشم انداز کلی",
            TextColor = FixParams.FontColor,
            BackgroundColor = FixParams.BackgroundColor
        };

        public Entry txtTitle = new Entry
        {
            Text = "",
            Placeholder = "عنوان",
            TextColor = FixParams.FontColor,
            BackgroundColor = FixParams.BackgroundColor
        };

        public Entry txtPriority = new Entry
        {
            Text = "",
            Placeholder = "اولویت",
            IsEnabled = false,
            TextColor = FixParams.FontColor,
            BackgroundColor = FixParams.BackgroundColor
        };

        public Entry txtDesc = new Entry
        {
            Text = "",
            Placeholder = "توضیحات",
            IsEnabled = false,
            TextColor = FixParams.FontColor,
            BackgroundColor = FixParams.BackgroundColor
        };

        public Image imgGoal = new Image
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            HeightRequest = 100 * FixParams.AspectRate,
            WidthRequest = 100 * FixParams.AspectRate,
        };

        public Image imgCamera = new Image
        {
            HorizontalOptions = LayoutOptions.Center,
            VerticalOptions = LayoutOptions.Center,
            HeightRequest = 32 * FixParams.AspectRate,
            WidthRequest = 32 * FixParams.AspectRate,
        };
        public void FillData()
        {
            txtTitle.Text = title;
            txtOverview.Text = overview;
            txtPriority.Text = priority;
            txtDesc.Text = desc;
            imgGoal.Source = ImageSource.FromFile("MainGoal.png");
        }
        public AddMainGoal ()
		{
            var scrollview = new ScrollView
            {
                Content = new StackLayout
                {
                    Children = {
                        new Label { Text = "هدف کلی", HeightRequest = 30, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center , TextColor = FixParams.AlterFontColor},
                        new Label { Text = "چشم انداز کلی", TextColor = FixParams.FontColor, XAlign = TextAlignment.End},
                        txtOverview,
                        new Label { Text = "عنوان", TextColor = FixParams.FontColor, XAlign = TextAlignment.End},
                        txtTitle,
                        new Label { Text = "اولویت", TextColor = FixParams.FontColor, XAlign = TextAlignment.End},
                        txtPriority,
                        new Label { Text = "شرح هدف", TextColor = FixParams.FontColor, XAlign = TextAlignment.End},
                        txtDesc,
                        new Label { Text = "تصویر", TextColor = FixParams.FontColor, XAlign = TextAlignment.End},
                        imgGoal,
                        imgCamera
                        },
                    Padding = new Thickness(20, 30, 20, 30),
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill,
                    BackgroundColor = FixParams.PanelColor,
                    Spacing = 15
                }
            };

            Content = scrollview;
        }
	}
}
