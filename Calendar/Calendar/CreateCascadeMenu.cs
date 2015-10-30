using System;
using System.Linq;
using Xamarin.Forms;

namespace Calendar
{
	public class CreateCascadeMenu : ContentPage
	{
        public ListView menu { get; set; }

        public void NavigateTo(CasecadeItems menu)
        {
            try
            {
                if (menu == null)
                    return;

                if (menu.TargetType == null)
                    menu.TargetType = typeof(UnderConstractionPage);
                Page displayPage = (Page)Activator.CreateInstance(menu.TargetType);                
                App.HomePage.Detail.Navigation.PushAsync(new NavigationPage(displayPage));                
            }
            catch (Exception ex)
            {
                DisplayAlert("", ex.Message, "");
            }
        }
        public CreateCascadeMenu (CascadeMenu cm, int rowheight = 0)
        {
            int rh = 0;

            if (rowheight == 0)
                rh = 40 * (int)Math.Round(FixParams.AspectRate);
            else
                rh = rowheight * (int)Math.Round(FixParams.AspectRate);

            menu = new CascadeListView(cm.CascadeListData)
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(() =>
                {

                    var lblTitle = new Label
                    {
                        TextColor = FixParams.FontColor,
                        FontSize = FixParams.StandardSize,
                        XAlign = TextAlignment.Center,
                        YAlign = TextAlignment.Center,
                    };


                    var MenuStack = new StackLayout
                    {
                        BackgroundColor = FixParams.PanelColor,
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                        Children =
                        {
                            lblTitle
                        }
                    };
                    lblTitle.SetBinding(Label.TextProperty, "Title");
                    lblTitle.SetBinding(Label.TextColorProperty, "TextColor");
                    lblTitle.SetBinding(Label.FontSizeProperty, "FontSize");
                    lblTitle.SetBinding(Label.HeightRequestProperty, "RowHeight");
                    return new ViewCell
                    {
                        View = MenuStack
                    };
                })
            };

            menu.ItemSelected += async (sender, e) =>
            {
                var item = e.SelectedItem as CasecadeItems;
                if (menu.SelectedItem != null)
                {
                    if (item.IsSpecial)
                    {
                        for (int i = 0; i < item.Level - 1; i++)
                            await App.HomePage.Detail.Navigation.PopAsync(false);
                        await App.HomePage.Detail.Navigation.PopAsync();
                        menu.SelectedItem = null;
                    }
                    else
                    {
                        NavigateTo(item);
                        menu.SelectedItem = null;
                    }
                }
            };


            Content = menu;
        }
	}
}
