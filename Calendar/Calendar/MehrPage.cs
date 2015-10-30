using Xamarin.Forms;

namespace Calendar
{
	public class MainMenu : ContentPage
	{
		public MainMenu()
		{
            BackgroundColor = FixParams.BackgroundColor;

            CascadeMenu cm = new CascadeMenu();
            cm.AddItem(1, "بانک مهر اقتصاد"    , 0, typeof(About));
            cm.AddItem(2, "اینترنت بانک و تلفن بانک");
            cm.AddItem(3, "گالری"    , 0, typeof(Gallary));
            cm.AddItem(4, "آخرین اخبار");
            cm.AddItem(6, "نظر سنجی");
            cm.AddItem(7, "عضویت در خبرنامه");
            cm.AddItem(8, "آخرین اخبار");

            CreateCascadeMenu ccm = new CreateCascadeMenu(cm);

            StackLayout Dashboard = new StackLayout()
            {
                Children =
                {
                    new Image { Source = ImageSource.FromFile("BigLogo.png"), BackgroundColor = FixParams.PanelColor},
                    ccm.menu
                },
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Padding = 5 * FixParams.AspectRate               
            };

            Content = Dashboard;
		}
	}

    public class Gallary : ContentPage
    {
        public Gallary()
        {
            BackgroundColor = FixParams.BackgroundColor;

            CascadeMenu cm = new CascadeMenu();
            cm.AddItem(1, "گالری", 1, typeof(MainMenu), FixParams.SmallSize, 20, true, FixParams.AlterFontColor);
            cm.AddItem(2, "تصاویر", 0, typeof(Picuters));
            cm.AddItem(3, "فیلم ها");

            CreateCascadeMenu ccm = new CreateCascadeMenu(cm);
            StackLayout Dashboard = new StackLayout()
            {
                Children =
                {
                    new Image { Source = ImageSource.FromFile("BigLogo.png"), BackgroundColor = FixParams.PanelColor},
                    ccm.menu
                },
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Padding = 5 * FixParams.AspectRate
            };

            Content = Dashboard;
        }
    }

    public class About : ContentPage
    {
        public About()
        {
            BackgroundColor = FixParams.BackgroundColor;

            CascadeMenu cm = new CascadeMenu();
            cm.AddItem(1, "بانک مهر اقتصاد", 1, typeof(MainMenu), FixParams.SmallSize, 20, true, FixParams.AlterFontColor);
            cm.AddItem(2, "معرفی بانک");
            cm.AddItem(3, "اطلاعات تماس دفتر مرکزی");
            cm.AddItem(4, "LBS");

            CreateCascadeMenu ccm = new CreateCascadeMenu(cm);
            StackLayout Dashboard = new StackLayout()
            {
                Children =
                {
                    new Image { Source = ImageSource.FromFile("BigLogo.png"), BackgroundColor = FixParams.PanelColor},
                    ccm.menu
                },
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Padding = 5 * FixParams.AspectRate
            };

            Content = Dashboard;
        }
    }

    public class Picuters : ContentPage
    {
        public Picuters()
        {
            BackgroundColor = FixParams.BackgroundColor;

            CascadeMenu cm = new CascadeMenu();
            cm.AddItem(1, "گالری", 2, typeof(MainMenu), FixParams.SmallSize, 20, true, FixParams.AlterFontColor);
            cm.AddItem(2, "تصاویر", 1, typeof(Picuters), FixParams.SmallSize, 20, true, FixParams.AlterFontColor);
            cm.AddItem(3, "تصاویر مهر");
            cm.AddItem(3, "تصاویر کاربر");

            CreateCascadeMenu ccm = new CreateCascadeMenu(cm);
            StackLayout Dashboard = new StackLayout()
            {
                Children =
                {
                    new Image { Source = ImageSource.FromFile("BigLogo.png"), BackgroundColor = FixParams.PanelColor},
                    ccm.menu
                },
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                Padding = 5 * FixParams.AspectRate
            };

            Content = Dashboard;
        }
    }
}
