using Xamarin.Forms;

namespace Calendar
{
	public class UnderConstractionPage : ContentPage
	{
		public UnderConstractionPage ()
		{
            BackgroundColor = FixParams.BackgroundColor;
            Content = new StackLayout {
                Children = {
                    new Image { Source = ImageSource.FromFile("UnderDev.png")},
                    new Label { Text = "", HeightRequest = 30 * FixParams.AspectRate},
                    new Label { Text = "این صفحه درحال ساخت می باشد", XAlign = TextAlignment.Center, FontSize = FixParams.MediumSize, TextColor = FixParams.FontColor}
                },
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand,
                BackgroundColor = FixParams.BackgroundColor
            };
		}
	}
}
