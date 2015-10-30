using System.Collections.Generic;
using Xamarin.Forms;

namespace Calendar
{
    class FixParams
    {
        //Mixed Colors
        public static Color Green   = Color.FromHex("009f3c");
        public static Color Black   = Color.FromHex("000000");
        public static Color Maroon  = Color.FromHex("a90017");
        public static Color Orang   = Color.FromHex("ef9c00");
        public static Color Gray    = Color.FromHex("dedfde");
        public static Color White   = Color.FromHex("ffffff");


        //GeneralColors
        public static Color BackgroundColor = White;
        public static Color PanelColor      = Gray;
        public static Color FontColor       = Black;
        public static Color AlterFontColor  = Maroon;
        public static Color SpecFontColor   = Orang;
        public static Color SuperFontColor  = Green;

        //Public Var
        public static string ActiveDate = "";
        public static int   Index       = 0;
        public static bool  FromOut     = false;

        //FontSize and Aspect
        public static double AspectRate   = 1;
        public static double ScreenWidth  = 1;
        public static double ScreenHeight = 1;

        public static double VeryLargSize;
        public static double LargSize;
        public static double MediumSize;
        public static double StandardSize;
        public static double SmallSize;
        public static double VerySmallSize;

        public static double ShorcutMenuOffset;

        public static void ChangeAspectSize()
        {
            VeryLargSize    = 46 * AspectRate;
            LargSize        = 24 * AspectRate;
            MediumSize      = 16 * AspectRate;
            StandardSize    = 14 * AspectRate;
            SmallSize       = 12 * AspectRate;
            VerySmallSize   = 10 * AspectRate;

            ShorcutMenuOffset = 150 * AspectRate;
        }

        public static Dictionary<int, Image> PryingImages =
            new Dictionary<int, Image> {
                { 1, new Image {Source = ImageSource.FromFile("AzanSobh.png"), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center} },
                { 2, new Image {Source = ImageSource.FromFile("ToleAftab.png"), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center} },
                { 3, new Image {Source = ImageSource.FromFile("AzanZohr.png"), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center} },
                { 4, new Image {Source = ImageSource.FromFile("Ghorob.png"), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center} },
                { 5, new Image {Source = ImageSource.FromFile("AzanMaghreb.png"), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center} },
                { 6, new Image {Source = ImageSource.FromFile("NimeShab.png"), HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center} }
            };
    }
}
