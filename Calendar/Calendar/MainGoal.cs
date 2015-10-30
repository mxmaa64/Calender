using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Calendar
{
    public class MainGoalItems
    {
        public string OverView { get; set; }
        public string Title { get; set; }
        public string Priority { get; set; }
        public string Desc { get; set; }
        public string IconSource { get; set; }
    }

    public class MainGoalListData : List<MainGoalItems>
    {
        public MainGoalListData()
        {
            Add(new MainGoalItems()
            {
                OverView = "چشم انداز کلی",
                Title = "معنوی",
                Priority = "اولویت: A",
                Desc = "توضیحات: سفر به مکه",
                IconSource = "MainGoal.png"
            });

            Add(new MainGoalItems()
            {
                OverView = "چشم انداز کلی",
                Title = "ورزشی",
                Priority = "اولویت: C",
                Desc = "توضیحات: لاغری و تناسب اندام",
                IconSource = "MainGoal.png"
            });

            Add(new MainGoalItems()
            {
                OverView = "چشم انداز کلی",
                Title = "خانه",
                Priority = "اولویت: D",
                Desc = "توضیحات: خنه من و محیط خانه ای که می توانم داشته باشم",
                IconSource = "MainGoal.png"
            });

            Add(new MainGoalItems()
            {
                OverView = "چشم انداز کلی",
                Title = "خانوادگی",
                Priority = "اولویت: B",
                Desc = "توضیحات: خانواده و بچه های من",
                IconSource = "MainGoal.png"
            });

            Add(new MainGoalItems()
            {
                OverView = "چشم انداز کلی",
                Title = "فرهنگی",
                Priority = "اولویت: D",
                Desc = "توضیحات: هنر های مورد علاقه من",
                IconSource = "MainGoal.png"
            });

            Add(new MainGoalItems()
            {
                OverView = "چشم انداز کلی",
                Title = "آرامش",
                Priority = "اولویت: A",
                Desc = "توضیحات: آرامش و استراحات شخصی",
                IconSource = "MainGoal.png"
            });

            Add(new MainGoalItems()
            {
                OverView = "چشم انداز کلی",
                Title = "دوستان",
                Priority = "اولویت: C",
                Desc = "توضیحات: دوستان صمیمی و آشنایان عمومی",
                IconSource = "MainGoal.png"
            });

            Add(new MainGoalItems()
            {
                OverView = "چشم انداز کلی",
                Title = "شغلی",
                Priority = "اولویت: D",
                Desc = "توضیحات: شغل و درآمد مورد علاقه من",
                IconSource = "MainGoal.png"
            });
        }
    }

    public class MainGoalListView : ListView
    {
        public MainGoalListView()
        {
            List<MainGoalItems> data = new MainGoalListData();

            ItemsSource = data;
            HorizontalOptions = LayoutOptions.End;
            BackgroundColor = Color.Transparent;
            var cell = new DataTemplate(typeof(MenuCell));
            cell.SetBinding(TextCell.TextProperty, "OverView");
            cell.SetBinding(TextCell.TextProperty, "Title");
            cell.SetBinding(TextCell.TextProperty, "Priority");
            cell.SetBinding(TextCell.TextProperty, "Desc");
            cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
            ItemTemplate = cell;
        }
    }
    public class MainGoal : ContentPage
	{
        public StackLayout layout = new StackLayout
        {
            Spacing = 0,
            Orientation = StackOrientation.Vertical,
            HorizontalOptions = LayoutOptions.End,
        };

        public ListView maingoal { get; set; }
        public MainGoal ()
		{
            var tiAdd = new ToolbarItem("درج", "Plus.png", () => { Navigation.PushAsync(new NavigationPage(new AddMainGoal())); });
            var tiDelete = new ToolbarItem("حذف", "Delete.png", () => { });
            var tiSearch = new ToolbarItem("جستجو", "Search.png", () => { });

            App.toolbarItems[4] = tiSearch;
            App.toolbarItems[3] = tiDelete;
            App.toolbarItems[2] = tiAdd;

            Title = "نوار ابزار";
            BackgroundColor = FixParams.PanelColor;
            Icon = "Menu.png";

            maingoal = new MainGoalListView
            {
                RowHeight = 130 * (int)Math.Round(FixParams.AspectRate),
                ItemTemplate = new DataTemplate(() =>
                {
                    var lblTitle = new Label
                    {
                        TextColor = FixParams.FontColor,
                        FontSize = FixParams.MediumSize,
                        HeightRequest = 28 * FixParams.AspectRate
                    };

                    var lblDesc = new Label
                    {
                        TextColor = FixParams.FontColor,
                        FontSize = FixParams.SmallSize,
                        HeightRequest = 50 * FixParams.AspectRate,
                        XAlign = TextAlignment.End
                    };

                    var lblPriority = new Label
                    {
                        TextColor = FixParams.FontColor,
                        FontSize = FixParams.SmallSize,
                        HeightRequest = 28 * FixParams.AspectRate,
                        XAlign = TextAlignment.End
                    };

                    var IconSource = new Image()
                    {
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        HeightRequest = 100 * FixParams.AspectRate,
                        WidthRequest = 100 * FixParams.AspectRate,
                    };

                    var MainGoalStack = new StackLayout
                    {
                        Orientation = StackOrientation.Horizontal,
                        BackgroundColor = FixParams.BackgroundColor,
                        Children =
                        {
                            new StackLayout
                            {
                                Children =
                                {
                                    new StackLayout
                                     {
                                        HorizontalOptions = LayoutOptions.StartAndExpand,
                                        VerticalOptions = LayoutOptions.Center,
                                        Spacing = 0,
                                        Children =
                                        {
                                            IconSource,
                                        }
                                     },                                   
                                },
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                VerticalOptions = LayoutOptions.FillAndExpand,
                            },
                            new StackLayout
                            {
                                Children =
                                {
                                    new StackLayout
                                     {
                                        Orientation = StackOrientation.Horizontal,
                                        HorizontalOptions = LayoutOptions.End,
                                        VerticalOptions = LayoutOptions.Start,
                                        Spacing = 25 * FixParams.AspectRate,
                                        Padding = 10 * FixParams.AspectRate,
                                        Children =
                                        {
                                            lblTitle
                                        }
                                     },
                                    new StackLayout
                                    {
                                        HorizontalOptions = LayoutOptions.EndAndExpand,
                                        VerticalOptions = LayoutOptions.StartAndExpand,
                                        Spacing = 0,
                                        Padding = new Thickness(0, 0, 30 * FixParams.AspectRate, 0),
                                        Children =
                                        {
                                            lblPriority,
                                            lblDesc
                                        }
                                    },
                                },
                                Orientation = StackOrientation.Vertical
                            }                            
                         }
                    };
                    lblTitle.SetBinding(Label.TextProperty, "Title");
                    lblDesc.SetBinding(Label.TextProperty, "Desc");
                    lblPriority.SetBinding(Label.TextProperty, "Priority");
                    IconSource.SetBinding(Image.SourceProperty, "IconSource");
                    return new ViewCell
                    {
                        View = MainGoalStack
                    };
                })
            };

            maingoal.ItemSelected += (sender, e) =>
            {
                if (maingoal.SelectedItem != null)
                {
                    AddMainGoal newTask = new AddMainGoal();
                    var thisItem = (MainGoalItems)e.SelectedItem;

                    newTask.title = thisItem.Title;
                    newTask.desc = thisItem.Desc;
                    newTask.priority = thisItem.Priority;
                    newTask.overview = thisItem.OverView;

                    newTask.FillData();
                    Navigation.PushAsync(new NavigationPage(newTask));
                    maingoal.SelectedItem = null;
                }
            };

            Content = maingoal;
        }
	}
}
