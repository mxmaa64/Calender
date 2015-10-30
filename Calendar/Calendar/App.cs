using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calendar
{
    public class App : Application
    {
        public static ToolbarItem[] toolbarItems = new ToolbarItem[5];
        public static List<CalendarDataStruct> YearDays = new List<CalendarDataStruct>(); 
        public static List<Grid> GridOfWeeks = new List<Grid>();

        public static FirstPage HomePage;
        public App()
        {
            FixParams.ChangeAspectSize();
            HomePage = new FirstPage();

            MainPage = new NavigationPage(HomePage);
            MainPage.SetValue(NavigationPage.BarBackgroundColorProperty, FixParams.PanelColor);
            MainPage.SetValue(NavigationPage.BarTextColorProperty, FixParams.FontColor);
        }

        public static void ClearToolbarItems()
        {
            toolbarItems[2] = null;
            toolbarItems[3] = null;
            toolbarItems[4] = null;
        }

        public static ToolbarItem[] ToolbarBtn()
        {
            var MenuBtn = new ToolbarItem("منوی اصلی", "Menu.png", () =>
            {
                if (!HomePage.MasterPage.IsVisible)
                {
                    HomePage.MasterPage.IsVisible = true;
                    FirstPage.menuPage.Menu.SelectedItem = null;
                    FirstPage.menuPage.SpecialMenu.SelectedItem = null;
                    HomePage.doSmoothOpen();
                }

                else
                    HomePage.doSmoothClose();
            });

            toolbarItems[0] = MenuBtn;

            var ShortCut = new ToolbarItem("میانبر", "Shortcut.png", () =>
            {
                if (!HomePage.ShortCutPage.IsVisible)
                {
                    HomePage.doShortcutSmoothOpen();
                    HomePage.ShortCutPage.IsVisible = true;
                    FirstPage.menuPage.ShortcutMenu.SelectedItem = null;
                }

                else
                    HomePage.doShortcutSmoothClose();
            });

            toolbarItems[1] = ShortCut;


            return toolbarItems;        
        }
    }
}
