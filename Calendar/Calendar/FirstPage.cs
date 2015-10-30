using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Calendar
{
    public class FirstPage : MyMasterDetailPage
    {
        public static MenuPage menuPage = new MenuPage();

        public FirstPage()
        {
            try
            {
                menuPage.Menu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuItem);
                menuPage.SpecialMenu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuItem);
                menuPage.ShortcutMenu.ItemSelected += (sender, e) => NavigateTo(e.SelectedItem as MenuItem);

                ShortCutMenu = menuPage.ShortcutLayout;
                Master = menuPage.layout;
                Detail = new NavigationPage(new CalendarDayView());
                Detail.Title = "MAINPAGE";

                var ss = Detail.Title;

                Orientation = OrientationType.Right;
                MasterPercent = 0.6f;


                ToolbarItems.Add(App.ToolbarBtn()[1]);
                ToolbarItems.Add(App.ToolbarBtn()[0]);
            }
            catch (Exception ex)
            {
                DisplayAlert("", ex.Message, "");
            }
        }


        public void sm()
        {
                       
        }

        protected override bool OnBackButtonPressed()
        {
            if (Detail.Title == "MAINPAGE")
            {
                Device.BeginInvokeOnMainThread(async () =>
                {
                    var result = await DisplayAlert("تایید", "آبا مایل به خروج از برنامه می باشید؟", "بله", "خیر");
                    if (result)
                    {
                        if (Device.OS == TargetPlatform.Android)
                        {
                            Android.OS.Process.KillProcess(Android.OS.Process.MyPid());
                        }
                    }
                });

            }
            else
            {
                if (App.HomePage.Detail.Navigation.NavigationStack.Count > 1)
                {
                    App.HomePage.Detail.Navigation.PopAsync();
                    if (App.HomePage.Detail.Navigation.NavigationStack.Count == 2)
                        Detail.Title = "MAINPAGE";
                }               
                else
                {
                    try
                    {
                        App.ClearToolbarItems();

                        Children.Clear();

                        Page displayPage = (Page)Activator.CreateInstance(typeof(CalendarDayView));
                        Detail = new NavigationPage(displayPage);

                        Detail.Title = "MAINPAGE";
                        Children.Add(Detail);
                        Detail.Layout(new Rectangle(0, 0, Width, Height));

                        Children.Remove(MasterPage);
                        Children.Add(MasterPage);

                        Children.Remove(ShortCutPage);
                        Children.Add(ShortCutPage);

                        doSmoothClose();
                        doShortcutSmoothClose();

                        ToolbarItems.Clear();

                        for (int i = 4; i >= 0; i--)
                        {
                            if (App.toolbarItems[i] != null)
                                ToolbarItems.Add(App.toolbarItems[i]);
                        }
                    }
                    catch (Exception ex)
                    {
                        DisplayAlert("", ex.Message, "");
                    }

                }

            }
            return true;
        }

        public void NavigateTo(MenuItem menu)
        {
            try
            {
                App.ClearToolbarItems();

                if (menu == null)
                    return;
              
                Children.Clear();

                Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);
                Detail = new NavigationPage(displayPage);

                if (menu.TargetType != typeof(CalendarDayView))
                    Detail.Title = "SUBPAGE";
                else
                    Detail.Title = "MAINPAGE";

                Children.Add(Detail);
                Detail.Layout(new Rectangle(0, 0, Width, Height));



                Children.Remove(MasterPage);                
                Children.Add(MasterPage);

                Children.Remove(ShortCutPage);
                Children.Add(ShortCutPage);

                doSmoothClose();
                doShortcutSmoothClose();

                ToolbarItems.Clear();

                for (int i = 4; i >= 0; i--)
                {
                    if (App.toolbarItems[i] != null)
                        ToolbarItems.Add(App.toolbarItems[i]);
                }
            }
            catch (Exception ex)
            {
                DisplayAlert("", ex.Message, "");
            }
        }
    }
}
