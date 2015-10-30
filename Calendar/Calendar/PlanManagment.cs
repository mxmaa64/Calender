using Xamarin.Forms;

namespace Calendar
{
	public class PlanManagment : ContentPage
	{
		public PlanManagment ()
		{
            Label Titlelbl = new Label
            {
                Text = "مدیریت راهبردی",
                BackgroundColor = FixParams.BackgroundColor,
                FontSize = 16,
                TextColor = FixParams.AlterFontColor,
                YAlign = TextAlignment.Center,
                XAlign = TextAlignment.Center,
                HeightRequest = 50
            };

            Label lblMainGoal = new Label
            {
                Text = "اهداف کلی",
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Start,
                TextColor = FixParams.FontColor
            };

            lblMainGoal.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new MainGoal());
                }),
                NumberOfTapsRequired = 1
            });

            Label lblSubGoal = new Label
            {
                Text = "اهداف فرعی",
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Start,
                TextColor = FixParams.FontColor
            };

            lblSubGoal.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new AddTask());
                }),
                NumberOfTapsRequired = 1
            });

            Label lblPlaning = new Label
            {
                Text = "برنامه ریزی",
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Start,
                TextColor = FixParams.FontColor
            };

            lblPlaning.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new AddTask());
                }),
                NumberOfTapsRequired = 1
            });

            Label lblProgress = new Label
            {
                Text = "کنترل پيشرفت برنامه",
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Start,
                TextColor = FixParams.FontColor
            };

            lblProgress.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new AddTask());
                }),
                NumberOfTapsRequired = 1
            });

            var imgMainGoal = new Image { Source = ImageSource.FromFile("MainGoal.png") };
            imgMainGoal.GestureRecognizers.Add(new TapGestureRecognizer
            {
                Command = new Command(() =>
                {
                    Navigation.PushAsync(new MainGoal());
                }),
                NumberOfTapsRequired = 1
            });

            var imgSubGoal  = new Image { Source = ImageSource.FromFile("SubGoal.png") };
            var imgPlaning = new Image { Source = ImageSource.FromFile("Planing.png") };
            var imgProgress = new Image { Source = ImageSource.FromFile("Progress.png") };

            var grid = new Grid();

            grid.Children.Add(imgMainGoal, 0, 0);
            grid.Children.Add(lblMainGoal, 0, 1);
            grid.Children.Add(imgSubGoal , 1, 0);
            grid.Children.Add(lblSubGoal , 1, 1);
            grid.Children.Add(imgPlaning , 0, 2);
            grid.Children.Add(lblPlaning , 0, 3);
            grid.Children.Add(imgProgress, 1, 2);
            grid.Children.Add(lblProgress, 1, 3);

            Content = new StackLayout {
				Children =
                {
                    Titlelbl,
                    grid
				},
                BackgroundColor = FixParams.BackgroundColor
			};
		}
	}
}
