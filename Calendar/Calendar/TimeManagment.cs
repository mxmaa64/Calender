using System;
using Xamarin.Forms;
using System.Collections.Generic;

namespace Calendar
{
    public class TodoItems
    {
        public string Title { get; set; }
        public string Type { get; set; }
        public string Date { get; set; }
        public string sTimeStr { get; set; }
        public string sTime { get; set; }
        public string fTimeStr { get; set; }
        public string fTime { get; set; }
        public double Percent { get; set; }
        public string PercentStr { get; set; }
        public string Field { get; set; }
        public string IconSource { get; set; }
        public string Contact { get; set; }
        public string Desc { get; set; }
        public string Scad { get; set; }
        public bool Repeat { get; set; }
        public bool Remind { get; set; }
    }

    public class TodoListData : List<TodoItems>
    {

        public TodoListData()
        {
            Add(new TodoItems()
            {
                Title = "کلاس زبان",
                Date = "تاریخ : 1394/07/25",
                sTimeStr = "ساعت شروع: 08:00",
                fTimeStr = "ساعت پایان: 10:00",
                sTime = "08:00",
                fTime = "10:00",
                Percent = 100,
                PercentStr = "درصد پیشرفت: 100%",
                Field = "رسته: کاری",
                IconSource = "Logo.png"
            });

            Add(new TodoItems()
            {
                Title = "کلاس زبان",
                Date = "تاریخ : 1394/07/25",
                sTimeStr = "ساعت شروع: 08:00",
                fTimeStr = "ساعت پایان: 10:00",
                sTime = "08:00",
                fTime = "10:00",
                Percent = 100,
                PercentStr = "درصد پیشرفت: 100%",
                Field = "رسته: کاری",
                IconSource = "Logo.png"
            });

            Add(new TodoItems()
            {
                Title = "کلاس زبان",
                Date = "تاریخ : 1394/08/09",
                sTimeStr = "ساعت شروع: 08:00",
                fTimeStr = "ساعت پایان: 10:00",
                sTime = "08:00",
                fTime = "10:00",
                Percent = 10,
                PercentStr = "درصد پیشرفت: 10%",
                Field = "رسته: کاری",
                IconSource = "Logo.png"
            });
        }
    }

    public class TodoListView : ListView
    {
        public TodoListView()
        {
            List<TodoItems> data = new TodoListData();

            ItemsSource = data;
            HorizontalOptions = LayoutOptions.End;
            BackgroundColor = Color.Transparent;
            var cell = new DataTemplate(typeof(MenuCell));
            cell.SetBinding(TextCell.TextProperty, "Title");
            cell.SetBinding(TextCell.TextProperty, "Date");
            cell.SetBinding(TextCell.TextProperty, "sTimeStr");
            cell.SetBinding(TextCell.TextProperty, "fTimeStr");
            cell.SetBinding(TextCell.TextProperty, "PercentStr");
            cell.SetBinding(TextCell.TextProperty, "Field");
            cell.SetBinding(ImageCell.ImageSourceProperty, "IconSource");
            ItemTemplate = cell;
        }
    }

    public class TimeManagment : ContentPage
	{
        public StackLayout layout = new StackLayout
        {
            Spacing = 0,
            Orientation = StackOrientation.Vertical,
            HorizontalOptions = LayoutOptions.End,
        };

        public ListView Todo { get; set; }
        public TimeManagment ()
		{
            var tiAdd       = new ToolbarItem("درج"  , "Plus.png", () => { Navigation.PushAsync(new NavigationPage(new AddTask())); });
            var tiDelete    = new ToolbarItem("حذف"  , "Delete.png", () => {});
            var tiSearch    = new ToolbarItem("جستجو", "Search.png", () => {});

            App.toolbarItems[4] = tiSearch;
            App.toolbarItems[3] = tiDelete;
            App.toolbarItems[2] = tiAdd;

            Title = "نوار ابزار";
            BackgroundColor = FixParams.PanelColor;
            Icon = "Menu.png";

            Todo = new TodoListView
            {
                RowHeight = 180 * (int)Math.Round(FixParams.AspectRate),
                ItemTemplate = new DataTemplate(() =>
                {
                    var lblTitle = new Label
                    {
                        TextColor = FixParams.FontColor,
                        FontSize = FixParams.MediumSize,
                        HeightRequest = 28 * FixParams.AspectRate
                    };

                    var lblDate = new Label
                    {
                        TextColor = FixParams.FontColor,
                        FontSize = FixParams.SmallSize,
                        HeightRequest = 28 * FixParams.AspectRate,
                        XAlign = TextAlignment.End
                    };

                    var lblsTime = new Label
                    {
                        TextColor = FixParams.FontColor,
                        FontSize = FixParams.SmallSize,
                        HeightRequest = 28 * FixParams.AspectRate,
                        XAlign = TextAlignment.End
                    };

                    var lblfTime = new Label
                    {
                        TextColor = FixParams.FontColor,
                        FontSize = FixParams.SmallSize,
                        HeightRequest = 28 * FixParams.AspectRate,
                        XAlign = TextAlignment.End
                    };

                    var lblPercent = new Label
                    {
                        TextColor = FixParams.FontColor,
                        FontSize = FixParams.SmallSize,
                        HeightRequest = 28 * FixParams.AspectRate,
                        XAlign = TextAlignment.End
                    };

                    var lblField = new Label
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
                        WidthRequest = 100 *FixParams.AspectRate,
                    };

                    var TodoStack = new StackLayout
                    {
                        BackgroundColor = FixParams.BackgroundColor,
                        Children =
                        {
                            new StackLayout
                             {
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions = LayoutOptions.End,
                                VerticalOptions = LayoutOptions.End,
                                Spacing = 25 * FixParams.AspectRate,
                                Padding = 10 * FixParams.AspectRate,
                                Children =
                                {
                                    lblTitle
                                }
                             },
                            new StackLayout
                            {
                                Children =
                                {
                                    new StackLayout
                                     {
                                        HorizontalOptions = LayoutOptions.FillAndExpand,
                                        VerticalOptions = LayoutOptions.FillAndExpand,
                                        Spacing = 0,
                                        Children =
                                        {
                                            IconSource,
                                        }
                                     },
                                    new StackLayout
                                     {
                                        HorizontalOptions = LayoutOptions.End,
                                        VerticalOptions = LayoutOptions.End,
                                        Spacing = 0,
                                        Padding = new Thickness(0, 0, 30 * FixParams.AspectRate, 0),
                                        Children =
                                        {
                                            lblDate,
                                            lblsTime,
                                            lblfTime,
                                            lblPercent,
                                            lblField,
                                        }
                                     },
   
                                },
                                Orientation = StackOrientation.Horizontal,
                                HorizontalOptions = LayoutOptions.FillAndExpand,
                                VerticalOptions = LayoutOptions.FillAndExpand,                                
                            },
                         }
                    };
                    lblTitle.SetBinding(Label.TextProperty, "Title");
                    lblDate.SetBinding(Label.TextProperty, "Date");
                    lblsTime.SetBinding(Label.TextProperty, "sTimeStr");
                    lblfTime.SetBinding(Label.TextProperty, "fTimeStr");
                    lblPercent.SetBinding(Label.TextProperty, "PercentStr");
                    lblField.SetBinding(Label.TextProperty, "Field");
                    IconSource.SetBinding(Image.SourceProperty, "IconSource");
                    return new ViewCell
                    {
                        View = TodoStack
                    };
                })
            };

            Todo.ItemSelected += (sender, e) => 
                {
                    if (Todo.SelectedItem != null)
                    {
                        AddTask newTask = new AddTask();
                        var thisItem = (TodoItems)e.SelectedItem;

                        newTask.title       = thisItem.Title;
                        newTask.type        = thisItem.Type;
                        newTask.field       = thisItem.Field;
                        newTask.contact     = thisItem.Contact;
                        newTask.date        = thisItem.Date;
                        newTask.stime       = thisItem.sTime;
                        newTask.ftime       = thisItem.fTime;
                        newTask.scad        = thisItem.Scad;
                        newTask.desc        = thisItem.Desc;
                        newTask.percentval  = thisItem.Percent;
                        newTask.repeat      = thisItem.Repeat;
                        newTask.remind      = thisItem.Remind;

                        newTask.FillData();
                        Navigation.PushAsync(new NavigationPage(newTask));
                        Todo.SelectedItem = null;
                    }
                };
            Content = Todo;
        }
	}
}
