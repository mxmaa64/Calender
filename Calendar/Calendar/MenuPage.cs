using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Calendar
{
    public class MenuCell : ImageCell
    {
        public MenuCell() : base()
        {
            TextColor = FixParams.FontColor;
        }
    }
    public class MenuItem
    {
        public string Title { get; set; }

        public string IconSource { get; set; }

        public Type TargetType { get; set; }
    }

    public class ShortcutMenuListData : List<MenuItem>
    {

        public ShortcutMenuListData()
        {
            Add(new MenuItem()
            {
                Title = " یادداشت",
                IconSource = "Note.png",
                TargetType = typeof(UnderConstractionPage)
            });


            Add(new MenuItem()
            {
                Title = " دریافت",
                IconSource = "Recive.png",
                TargetType = typeof(UnderConstractionPage)
            });

            Add(new MenuItem()
            {
                Title = " پرداخت",
                IconSource = "Pay.png",
                TargetType = typeof(UnderConstractionPage)
            });

            Add(new MenuItem()
            {
                Title = " یاد آوری",
                IconSource = "Alarm.png",
                TargetType = typeof(UnderConstractionPage)
            });
        }
    }
    public class SpecialMenuListData : List<MenuItem>
    {

        public SpecialMenuListData()
        {
            Add(new MenuItem()
            {
                Title = " بانک مهراقتصاد",
                IconSource = "Icon.png",
                TargetType = typeof(MainMenu)
            });


            Add(new MenuItem()
            {
                Title = "تنظیمات",
                IconSource = "Setting.png",
                TargetType = typeof(UnderConstractionPage)
            });
        }
    }
    public class MenuListData : List<MenuItem>
    {
        public MenuListData()
        {
            Add(new MenuItem()
            {
                Title = " صفحه اصلی",
                IconSource = "Home.png",
                TargetType = typeof(CalendarDayView)
            });

            Add(new MenuItem()
            {
                Title = " مدیریت زمان",
                IconSource = "Clock.png",
                TargetType = typeof(UnderConstractionPage)
            });

            Add(new MenuItem()
            {
                Title = " مدیریت مالی",
                IconSource = "Finance.png",
                TargetType = typeof(UnderConstractionPage)
            });

            Add(new MenuItem()
            {
                Title = " مدیریت راهبردی",
                IconSource = "Plan.png",
                TargetType = typeof(UnderConstractionPage)
            });

            Add(new MenuItem()
            {
                Title = " مدیریت ارتباط",
                IconSource = "Relation.png",
                TargetType = typeof(UnderConstractionPage)
            });

            Add(new MenuItem()
            {
                Title = " مدیریت آرامش",
                IconSource = "HealthCare.png",
                TargetType = typeof(UnderConstractionPage)
            });

            Add(new MenuItem()
            {
                Title = " مدیریت آموزش",
                IconSource = "Learn.png",
                TargetType = typeof(UnderConstractionPage)
            });
        }
    }

    public class ShortcutMenuListView : ListView
    {
        public ShortcutMenuListView()
        {
            List<MenuItem> data = new ShortcutMenuListData();

            ItemsSource = data;
            HorizontalOptions = LayoutOptions.End;
            BackgroundColor = Color.Transparent;
            var cell = new DataTemplate(typeof(MenuCell));
            cell.SetBinding(TextCell.TextProperty, "Title");
            cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
            ItemTemplate = cell;
        }
    }

    public class SpecialMenuListView : ListView
    {
        public SpecialMenuListView()
        {
            List<MenuItem> data = new SpecialMenuListData();

            ItemsSource = data;
            HorizontalOptions = LayoutOptions.End;
            BackgroundColor = Color.Transparent;
            var cell = new DataTemplate(typeof(MenuCell));
            cell.SetBinding(TextCell.TextProperty, "Title");
            cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
            ItemTemplate = cell;
        }
    }

    public class MenuListView : ListView
    {
        public MenuListView()
        {
            List<MenuItem> data = new MenuListData();

            ItemsSource = data;
            HorizontalOptions = LayoutOptions.End;
            BackgroundColor = Color.Transparent;
            var cell = new DataTemplate(typeof(MenuCell));
            cell.SetBinding(TextCell.TextProperty, "Title");
            cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
            ItemTemplate = cell;
        }
    }
    public class MenuPage : ContentPage
    {
        public StackLayout layout = new StackLayout
        {
            Spacing = -5,
            Orientation = StackOrientation.Vertical,
            HorizontalOptions = LayoutOptions.End,            
        };

        public StackLayout ShortcutLayout = new StackLayout
        {
            Spacing = 0,
            Orientation = StackOrientation.Vertical,
            HorizontalOptions = LayoutOptions.End,
            BackgroundColor = FixParams.PanelColor,
            Padding = 2 * FixParams.AspectRate
        };

        public ListView Menu { get; set; }
        public ListView SpecialMenu { get; set; }
        public ListView ShortcutMenu { get; set; }

        public MenuPage()
        {
            Title = "نوار ابزار";
            BackgroundColor = FixParams.PanelColor;
            Icon = "Menu.png";

            ShortcutMenu = new ShortcutMenuListView
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(() =>
                {
                    var nameLabel = new Label
                    {
                        TextColor = FixParams.FontColor,
                        FontSize = FixParams.SmallSize,
                        HeightRequest = 24 * FixParams.AspectRate,
                    };

                    var IconSource = new Image();

                    var ShortcutStack = new StackLayout
                    {
                        BackgroundColor = FixParams.BackgroundColor,
                        Children =
                        {
                            new StackLayout
                             {
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions = LayoutOptions.End,
                                VerticalOptions = LayoutOptions.End,
                                Spacing = 0,
                                Padding = 5,
                                Children =
                                {
                                    nameLabel,
                                    IconSource,
                                }
                             }
                         }
                    };
                    nameLabel.SetBinding(Label.TextProperty, "Title");
                    IconSource.SetBinding(Image.SourceProperty, "IconSource");
                    IconSource.WidthRequest = 24 * FixParams.AspectRate;
                    IconSource.HeightRequest = 24 * FixParams.AspectRate;
                    return new ViewCell
                    {
                        View = ShortcutStack
                    };
                })
            };

            SpecialMenu = new SpecialMenuListView
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(() =>
                {
                    var nameLabel = new Label
                    {
                        TextColor = FixParams.FontColor,
                        FontSize = FixParams.StandardSize,
                        HeightRequest = 28 * FixParams.AspectRate
                    };

                    var IconSource = new Image();

                    var Specialstack = new StackLayout
                    {
                        BackgroundColor = Color.Transparent,
                        Children =
                        {
                            new StackLayout
                             {
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions = LayoutOptions.End,
                                VerticalOptions = LayoutOptions.End,
                                Spacing = 0,
                                Children =
                                {
                                    nameLabel,
                                    IconSource,
                                }
                             }
                         }
                    };
                    nameLabel.SetBinding(Label.TextProperty, "Title");
                    IconSource.SetBinding(Image.SourceProperty, "IconSource");
                    IconSource.WidthRequest = 24 * FixParams.AspectRate;
                    IconSource.HeightRequest = 24 * FixParams.AspectRate;
                    return new ViewCell
                    {
                        View = Specialstack
                    };
                })
            };

            Menu = new MenuListView
            {
                HasUnevenRows = true,
                ItemTemplate = new DataTemplate(() =>
                {
                    var nameLabel = new Label
                    {
                        TextColor = FixParams.FontColor,
                        FontSize = FixParams.StandardSize,
                        HeightRequest = 28 * FixParams.AspectRate
                    };

                    var IconSource = new Image();

                    var stack = new StackLayout
                    {
                        BackgroundColor = Color.Transparent,
                        Children =
                        {
                            new StackLayout
                             {
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions = LayoutOptions.End,
                                VerticalOptions = LayoutOptions.Start,
                                Spacing = 0,                                
                                Children =
                                {
                                    nameLabel,
                                    IconSource,
                                }
                             }
                         }
                    };
                    nameLabel.SetBinding(Label.TextProperty, "Title");
                    IconSource.SetBinding(Image.SourceProperty, "IconSource");
                    IconSource.WidthRequest = 24 * FixParams.AspectRate;
                    IconSource.HeightRequest = 24 * FixParams.AspectRate;
                    return new ViewCell
                    {
                        View = stack
                    };
                })
            };

            RelativeLayout MenuLayout = new RelativeLayout();

            ShortcutLayout.Children.Add(ShortcutMenu);

            MenuLayout.Children.Add(Menu,
                Constraint.RelativeToParent((p) => {
                    return 0;
                }),
                Constraint.RelativeToParent((p) => {
                    return 10 * FixParams.AspectRate;
                }),
                Constraint.RelativeToParent((p) => {
                    return MenuLayout.Width;
                }),
                Constraint.RelativeToParent((p) => {
                    return MenuLayout.Height - (100 * FixParams.AspectRate);
                }));

            MenuLayout.Children.Add(SpecialMenu,
                Constraint.RelativeToParent((p) => {
                    return 0;
                }),
                Constraint.RelativeToParent((p) => {
                    return MenuLayout.Height - (60 * FixParams.AspectRate);
                }),
                Constraint.RelativeToParent((p) => {
                    return MenuLayout.Width;
                }),
                Constraint.RelativeToParent((p) => {
                    return 60 * FixParams.AspectRate;
                }));

            layout.Children.Add(MenuLayout);
            Content = layout;
        }
    }
}
