using System;
using System.Linq;
using Xamarin.Forms;
using System.Collections.ObjectModel;
using System.Threading.Tasks;

namespace Calendar
{
    public class CalnedarMonthView : CarouselPage
    {
        int ActiveMonthNumber = int.Parse(CalendarClass.MonthCode(CalendarClass.TodayDate()));
        StackLayout layout = new StackLayout();
        public string _ActiveDate = "";

        public CalnedarMonthView()
        {
            if (ActiveMonthNumber == 1)
            {
                ItemsSource = new ObservableCollection<int>() { ActiveMonthNumber, ActiveMonthNumber + 1 };
            }
            else if (ActiveMonthNumber + 1 == 12)
            {
                ItemsSource = new ObservableCollection<int>() { ActiveMonthNumber - 1, ActiveMonthNumber };
            }
            else
            {
                ItemsSource = new ObservableCollection<int>() { ActiveMonthNumber - 1, ActiveMonthNumber, ActiveMonthNumber + 1 };
            }

            if (ActiveMonthNumber != 1)
            {
                SelectedItem = ((ObservableCollection<int>)ItemsSource)[1];
            }

            CurrentPageChanged += HandleCurrentPageChanged;
        }

        async void HandleCurrentPageChanged(object sender, EventArgs e)
        {
            var thing = SelectedItem;
            if (SelectedItem.Equals(ItemsSource.Cast<int>().First()) && ActiveMonthNumber > 2)
            {
                ActiveMonthNumber--;
                await Task.Run(() =>
                {
                    ((ObservableCollection<int>)ItemsSource).RemoveAt(((ObservableCollection<int>)ItemsSource).Count() - 1);
                });
                await Task.Run(() =>
                {
                    ((ObservableCollection<int>)ItemsSource).Insert(0, ActiveMonthNumber - 1);
                });
            }
            else if (SelectedItem.Equals(ItemsSource.Cast<int>().Last()) && ActiveMonthNumber < 11)
            {
                ActiveMonthNumber++;
                await Task.Run(() =>
                {
                    ((ObservableCollection<int>)ItemsSource).RemoveAt(0);
                });
                await Task.Run(() =>
                {
                    ((ObservableCollection<int>)ItemsSource).Add(ActiveMonthNumber + 1);
                });
            }            
        }

        public Grid CreateCalendar(int ActiveYear, int ActiveMonth)
        {
            var today = CalendarClass.DayNumber(CalendarClass.TodayDate());

            var grdCalendar = new Grid();

            var fmDay = CalendarClass.WeekDay(ActiveYear.ToString() + "/" + CalendarClass.FullMonthCode(ActiveMonth.ToString()) + "/" + "01");
            var is6col = ((fmDay == 5 || fmDay == 6) && ActiveMonth <= 6) || (fmDay == 6 && ActiveMonth > 6);
            int maxcol = 0;

            grdCalendar.ColumnSpacing = 2 * FixParams.AspectRate;
            grdCalendar.RowSpacing = 2 * FixParams.AspectRate;
            grdCalendar.BackgroundColor = FixParams.PanelColor;

            grdCalendar.RowDefinitions.Add(new RowDefinition() { Height = 50 * FixParams.AspectRate});
            grdCalendar.RowDefinitions.Add(new RowDefinition() { Height = 50 * FixParams.AspectRate});
            grdCalendar.RowDefinitions.Add(new RowDefinition() { Height = 50 * FixParams.AspectRate});
            grdCalendar.RowDefinitions.Add(new RowDefinition() { Height = 50 * FixParams.AspectRate});
            grdCalendar.RowDefinitions.Add(new RowDefinition() { Height = 50 * FixParams.AspectRate});
            grdCalendar.RowDefinitions.Add(new RowDefinition() { Height = 50 * FixParams.AspectRate});
            grdCalendar.RowDefinitions.Add(new RowDefinition() { Height = 50 * FixParams.AspectRate});

            if (is6col)
            {
                maxcol = 6;
                grdCalendar.ColumnDefinitions.Add(new ColumnDefinition());
                grdCalendar.ColumnDefinitions.Add(new ColumnDefinition());
                grdCalendar.ColumnDefinitions.Add(new ColumnDefinition());
                grdCalendar.ColumnDefinitions.Add(new ColumnDefinition());
                grdCalendar.ColumnDefinitions.Add(new ColumnDefinition());
                grdCalendar.ColumnDefinitions.Add(new ColumnDefinition());
                grdCalendar.ColumnDefinitions.Add(new ColumnDefinition { Width = 60 * FixParams.AspectRate });
            }
            else
            {
                maxcol = 5;
                grdCalendar.ColumnDefinitions.Add(new ColumnDefinition());
                grdCalendar.ColumnDefinitions.Add(new ColumnDefinition());
                grdCalendar.ColumnDefinitions.Add(new ColumnDefinition());
                grdCalendar.ColumnDefinitions.Add(new ColumnDefinition());
                grdCalendar.ColumnDefinitions.Add(new ColumnDefinition());
                grdCalendar.ColumnDefinitions.Add(new ColumnDefinition { Width = 60 * FixParams.AspectRate });
            }

            for (int k = 0; k < 7; k++)
            {
                grdCalendar.Children.Add(new Label { Text = "", BackgroundColor = FixParams.SpecFontColor }, 0, k);
                grdCalendar.Children.Add(new Label { Text = "", BackgroundColor = FixParams.SpecFontColor }, maxcol - 1, k);
            }


            for (int j = fmDay; j <= fmDay + 30; j++)
            {
                var row = j % 7;
                int col = 0;

                if (is6col)
                {
                    if (j < 7 && j >= 0) col = 5;
                    if (j < 14 && j >= 7) col = 4;
                    if (j < 21 && j >= 14) col = 3;
                    if (j < 28 && j >= 21) col = 2;
                    if (j < 35 && j >= 28) col = 1;
                    if (j < 42 && j >= 35) col = 0;
                }
                else
                {
                    if (j < 7 && j >= 0) col = 4;
                    if (j < 14 && j >= 7) col = 3;
                    if (j < 21 && j >= 14) col = 2;
                    if (j < 28 && j >= 21) col = 1;
                    if (j < 35 && j >= 28) col = 0;
                }

                Color rc = new Color();

                if (row < 6) rc = FixParams.FontColor; else rc = FixParams.AlterFontColor;

                if (ActiveMonth < 7 && ActiveMonth > 0)
                    if (j - fmDay <= 30)
                    {
                        Label lblDay = new Label()
                        {
                            XAlign = TextAlignment.Center,
                            YAlign = TextAlignment.Center,
                            TextColor = rc,
                            BackgroundColor = FixParams.BackgroundColor,
                            Text = (j - fmDay + 1).ToString(),
                            FontSize = FixParams.SmallSize
                        };

                        var DayNumber = lblDay.Text;
                        if (int.Parse(lblDay.Text) < 10)
                            DayNumber = "0" + DayNumber;

                        var _Today = ActiveYear.ToString() + "/" + CalendarClass.FullMonthCode(ActiveMonth.ToString()) + "/" + DayNumber;
                        if (CalendarClass.IsHolyDay(CalendarClass.DateToDateTime(_Today))) lblDay.TextColor = FixParams.AlterFontColor;

                        lblDay.GestureRecognizers.
                            Add(new TapGestureRecognizer
                            {
                                Command = new Command(async () =>
                                {
                                    FixParams.FromOut = true;
                                    FixParams.ActiveDate = _Today;
                                    await Navigation.PushAsync(new CalendarDayView());
                                }),
                                NumberOfTapsRequired = 1
                            });
                        grdCalendar.Children.Add(lblDay, col, row);
                    }

                if (ActiveMonth < 12 && ActiveMonth >= 7)
                    if (j - fmDay <= 29)
                    {
                        Label lblDay = new Label()
                        {
                            XAlign = TextAlignment.Center,
                            YAlign = TextAlignment.Center,
                            TextColor = rc,
                            BackgroundColor = FixParams.BackgroundColor,
                            Text = (j - fmDay + 1).ToString(),
                            FontSize = FixParams.SmallSize
                        };
                        var DayNumber = lblDay.Text;
                        if (int.Parse(lblDay.Text) < 10)
                            DayNumber = "0" + DayNumber;

                        var _Today = ActiveYear.ToString() + "/" + CalendarClass.FullMonthCode(ActiveMonth.ToString()) + "/" + DayNumber;
                        if (CalendarClass.IsHolyDay(CalendarClass.DateToDateTime(_Today))) lblDay.TextColor = FixParams.AlterFontColor;
                        lblDay.GestureRecognizers.
                            Add(new TapGestureRecognizer
                            {
                                Command = new Command(async () =>
                                {
                                    FixParams.FromOut = true;
                                    FixParams.ActiveDate = _Today;
                                    await Navigation.PushAsync(new CalendarDayView());
                                }),
                                NumberOfTapsRequired = 1
                            });

                        grdCalendar.Children.Add(lblDay, col, row);
                    }

                if (ActiveMonth == 12)
                    if ((j - fmDay <= 29 && CalendarClass.IsLeapYear(ActiveYear)) || (j - fmDay <= 28 && !CalendarClass.IsLeapYear(ActiveYear)))
                    {
                        Label lblDay = new Label()
                        {
                            XAlign = TextAlignment.Center,
                            YAlign = TextAlignment.Center,
                            TextColor = rc,
                            BackgroundColor = FixParams.BackgroundColor,
                            Text = (j - fmDay + 1).ToString(),
                            FontSize = FixParams.SmallSize
                        };
                        var DayNumber = lblDay.Text;
                        if (int.Parse(lblDay.Text) < 10)
                            DayNumber = "0" + DayNumber;

                        var _Today = ActiveYear.ToString() + "/" + CalendarClass.FullMonthCode(ActiveMonth.ToString()) + "/" + DayNumber;
                        if (CalendarClass.IsHolyDay(CalendarClass.DateToDateTime(_Today))) lblDay.TextColor = FixParams.AlterFontColor;
                        lblDay.GestureRecognizers.
                            Add(new TapGestureRecognizer
                            {
                                Command = new Command(async () =>
                                {
                                    FixParams.FromOut = true;
                                    FixParams.ActiveDate = _Today;
                                    await Navigation.PushAsync(new CalendarDayView());
                                }),
                                NumberOfTapsRequired = 1
                            });

                        grdCalendar.Children.Add(lblDay, col, row);
                    }

            }

            for (int i = 0; i < 7; i++)
            {
                grdCalendar.Children.Add(new Label
                {
                    TextColor = FixParams.AlterFontColor,
                    BackgroundColor = FixParams.PanelColor,
                    Text = " " + CalendarClass.DayNames[i],
                    HeightRequest = 30 * FixParams.AspectRate,
                    FontSize = FixParams.StandardSize,
                    XAlign = TextAlignment.End,
                    YAlign = TextAlignment.Center
                }, maxcol, i);
            }

            return grdCalendar;
        }

        public void OnWeekClicked(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
        public void OnYearClicked(object sender, EventArgs e)
        {
        }
        protected override ContentPage CreateDefault(object item)
        {
            var currentInt = (int)item;
            Label MonthName = new Label
            {
                TextColor = FixParams.FontColor,
                Text = CalendarClass.MonthNameByCode(currentInt) + " ماه " + CalendarClass.YearName("1394/01/01"),
                XAlign = TextAlignment.Center,
                YAlign = TextAlignment.Center,
                FontSize = FixParams.MediumSize
            };

            Grid grdCalendar = new Grid();

            StackLayout layout = new StackLayout()
            {
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                BackgroundColor = FixParams.PanelColor,
                Padding = 2 * FixParams.AspectRate
            };

            grdCalendar = CreateCalendar(1394, currentInt);
            layout.Children.Add(MonthName);
            layout.Children.Add(grdCalendar);

            _ActiveDate = "1394/" + CalendarClass.FullMonthCode((currentInt - 1).ToString()) + "/05";

            Button btnGotoWeekView = new Button()
            {
                BackgroundColor = FixParams.PanelColor,
                Text = "هفته",
                FontSize = FixParams.StandardSize,
                TextColor = FixParams.FontColor,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };

            Button btnGotoYearView = new Button()
            {
                BackgroundColor = FixParams.PanelColor,
                Text = "سال",
                FontSize = FixParams.StandardSize,
                TextColor = FixParams.FontColor,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.EndAndExpand,
            };

            btnGotoWeekView.Clicked += OnWeekClicked;

            StackLayout ButtomLayout = new StackLayout
            {
                Children =
                {
                    btnGotoWeekView,
                    btnGotoYearView
                },
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = FixParams.PanelColor,
                VerticalOptions = LayoutOptions.EndAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            Entry PerisianDate = new Entry
            {
                Text = _ActiveDate,
                TextColor = FixParams.FontColor,
                BackgroundColor = FixParams.BackgroundColor
            };

            Image btnCalendar = new Image
            {
                Source = ImageSource.FromFile("Calendar.png"),
                HeightRequest = 40,
                WidthRequest = 40,
            };

            Label lblPersianDate = new Label
            {
                Text = "تاریخ جلالی",
                FontSize = FixParams.SmallSize,
                TextColor = FixParams.FontColor     
            };

            var grdPersianDate = new Grid();
            grdPersianDate.RowDefinitions.Add(new RowDefinition());
            grdPersianDate.ColumnDefinitions.Add(new ColumnDefinition { Width = 40 });
            grdPersianDate.ColumnDefinitions.Add(new ColumnDefinition());
            grdPersianDate.ColumnDefinitions.Add(new ColumnDefinition() { Width = 50});

            grdPersianDate.Children.Add(lblPersianDate, 2, 0);
            grdPersianDate.Children.Add(PerisianDate, 1, 0);
            grdPersianDate.Children.Add(btnCalendar, 0, 0);

            StackLayout ConvertLayout = new StackLayout
            {
                Children =
                {
                    new StackLayout
                    {
                        Children =
                        {
                            new BoxView() { Color = FixParams.AlterFontColor, HeightRequest = 1},
                            grdPersianDate,
                            new BoxView() { Color = FixParams.AlterFontColor, HeightRequest = 1},
                        },
                        VerticalOptions = LayoutOptions.FillAndExpand,
                        HorizontalOptions = LayoutOptions.FillAndExpand,
                    },                    
                },
                Orientation = StackOrientation.Horizontal,
                BackgroundColor = FixParams.PanelColor,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
            };

            layout.Children.Add(ButtomLayout);
            return new ContentPage
            {
                Content = layout
            };
        }
    }
}
