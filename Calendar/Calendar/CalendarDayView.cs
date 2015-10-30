using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calendar
{

	public class CalendarDayView : ContentPage
    {
        int _ActiveWeekDay = CalendarClass.WeekDay(CalendarClass.TodayDate());
        public static string _ActiveDate = CalendarClass.TodayDate();
        public bool showbtmbar = true;
        public CalendarWeekView wv;

        StackLayout _pnlDayNote = new StackLayout();
        StackLayout _pnlShortcut = new StackLayout();

        RelativeLayout ButtomLayout = new RelativeLayout { BackgroundColor = FixParams.PanelColor };

        Grid grdWeekDays = new Grid();
        Grid grdPryingTimes = new Grid();

        public RelativeLayout _layout = new RelativeLayout
        {
            BackgroundColor = FixParams.BackgroundColor,
            VerticalOptions = LayoutOptions.FillAndExpand,
            HorizontalOptions = LayoutOptions.FillAndExpand
        };    
       
        public static Label lblNote = new Label
        {
            Text = _ActiveDate,
            HorizontalOptions = LayoutOptions.FillAndExpand,
            VerticalOptions = LayoutOptions.FillAndExpand,
            XAlign = TextAlignment.Center,
            TextColor = FixParams.FontColor,
            BackgroundColor = FixParams.PanelColor,
            FontSize = FixParams.MediumSize
        };

        Label DayNumber = new Label
        {
            FontSize = FixParams.VeryLargSize,
            XAlign = TextAlignment.End,
            YAlign = TextAlignment.End,
            TextColor = FixParams.AlterFontColor
        };

        Label MonthName = new Label
        {
            FontSize = FixParams.MediumSize,
            XAlign = TextAlignment.End,
            YAlign = TextAlignment.End,
            TextColor = FixParams.FontColor
        };

        Label DayName = new Label
        {
            FontSize = FixParams.MediumSize,
            XAlign = TextAlignment.End,
            YAlign = TextAlignment.End,
            TextColor = FixParams.FontColor
        };

        public Grid CreateWeekGrid(string ActiveDate, int ActiveWeekDay)
        {
            
            int ActiveDay = int.Parse(CalendarClass.DayNumber(ActiveDate));

            var grdTemp = new Grid();

            grdTemp.RowDefinitions.Add(new RowDefinition { Height = 30 * FixParams.AspectRate });
            grdTemp.RowDefinitions.Add(new RowDefinition { Height = 40 * FixParams.AspectRate });

            grdTemp.RowSpacing = 0;
            grdTemp.ColumnSpacing = 2 * FixParams.AspectRate;
            grdTemp.Padding = 2 * FixParams.AspectRate;
            grdTemp.BackgroundColor = FixParams.PanelColor; 

            for (int i = 0; i < 7; i++)
            {
                grdTemp.Children.Add(new Label
                {
                    TextColor = FixParams.AlterFontColor,
                    BackgroundColor = FixParams.PanelColor,
                    Text = " " + CalendarClass.ShortDayNames[6 - i],
                    XAlign = TextAlignment.Center,
                    YAlign = TextAlignment.Center,
                    FontSize = FixParams.StandardSize
                }, i, 0);

                var clr = new Color();
                if (ActiveWeekDay == i)
                    clr = FixParams.SpecFontColor;
                else
                    clr = FixParams.FontColor;

                var lblDayNum = new MyLabel
                {
                    TextColor = clr,
                    BackgroundColor = FixParams.BackgroundColor,
                    Text = " " + CalendarClass.DayNumber(CalendarClass.AddDayToDate(ActiveDate, i - ActiveWeekDay).ToString()),
                    XAlign = TextAlignment.Center,
                    YAlign = TextAlignment.Center,
                    FontSize = FixParams.MediumSize,
                    Property1 = i.ToString(),
                    Property2 = CalendarClass.AddDayToDate(ActiveDate, i - ActiveWeekDay).ToString()
                };
                if (CalendarClass.IsHolyDay(CalendarClass.DateToDateTime(lblDayNum.Property2))) lblDayNum.TextColor = FixParams.AlterFontColor;
                if (i==6) lblDayNum.TextColor = FixParams.AlterFontColor;

                lblDayNum.GestureRecognizers.Add(new TapGestureRecognizer { Command = new Command(() => 
                    {
                        _ActiveDate = lblDayNum.Property2;
                        _ActiveWeekDay = int.Parse(lblDayNum.Property1);

                        DayNumber.Text = lblDayNum.Text;
                        DayName.Text = CalendarClass.WeekDayName(_ActiveWeekDay);
                        MonthName.Text = CalendarClass.MonthName(_ActiveDate) + " ماه " + CalendarClass.YearName(_ActiveDate);

                        grdWeekDays = CreateWeekGrid(_ActiveDate, _ActiveWeekDay);

                        Animateview(_pnlDayNote, 400);

                        _layout.Children.Remove(DayNumber);
                        _layout.Children.Remove(DayName);
                        _layout.Children.Remove(MonthName);
                        _layout.Children.Remove(grdWeekDays);

                        _layout.Children.Add(DayNumber,
                                            Constraint.RelativeToParent((p) => {
                                                return _layout.Width - (65 * FixParams.AspectRate);
                                            }),
                                            Constraint.RelativeToParent((p) => {
                                                return 5 * FixParams.AspectRate;
                                            }),
                                            Constraint.RelativeToParent((p) => {
                                                return 60 * FixParams.AspectRate;
                                            }),
                                            Constraint.RelativeToParent((p) => {
                                                return 55 * FixParams.AspectRate;
                                            })
                                        );

                        _layout.Children.Add(MonthName,
                                            Constraint.RelativeToParent((p) => {
                                                return _layout.Width - (180 * FixParams.AspectRate);
                                            }),
                                            Constraint.RelativeToParent((p) => {
                                                return 1 * FixParams.AspectRate;
                                            }),
                                            Constraint.RelativeToParent((p) => {
                                                return 120 * FixParams.AspectRate;
                                            }),
                                            Constraint.RelativeToParent((p) => {
                                                return 30 * FixParams.AspectRate;
                                            })
                                        );

                        _layout.Children.Add(DayName,
                                            Constraint.RelativeToParent((p) => {
                                                return _layout.Width - (180 * FixParams.AspectRate);
                                            }),
                                            Constraint.RelativeToParent((p) => {
                                                return 25 * FixParams.AspectRate;
                                            }),
                                            Constraint.RelativeToParent((p) => {
                                                return 120 * FixParams.AspectRate;
                                            }),
                                            Constraint.RelativeToParent((p) => {
                                                return 30 * FixParams.AspectRate;
                                            })
                                        );

                        _layout.Children.Add(grdWeekDays,
                                            Constraint.RelativeToParent((p) => {
                                                return 10 * FixParams.AspectRate;
                                            }),
                                            Constraint.RelativeToParent((p) => {
                                                return DayNumber.Height;
                                            }),
                                            Constraint.RelativeToParent((p) => {
                                                return _layout.Width - (20 * FixParams.AspectRate);
                                            }),
                                            Constraint.RelativeToParent((p) => {
                                                return 75 * FixParams.AspectRate;
                                            })
                                        );


                        for (int j = 11; j >= 6; j--)
                            grdPryingTimes.Children.RemoveAt(j);

                        prayer _prayer = new prayer();
                        _prayer.UpdatePryTimes(_ActiveDate);

                        grdPryingTimes.Children.Add(new Label { FontSize = FixParams.SmallSize, Text = prayer._MP, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center, TextColor = FixParams.FontColor, BackgroundColor = FixParams.BackgroundColor }, 5, 1);
                        grdPryingTimes.Children.Add(new Label { FontSize = FixParams.SmallSize, Text = prayer._SR, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center, TextColor = FixParams.FontColor, BackgroundColor = FixParams.BackgroundColor }, 4, 1);
                        grdPryingTimes.Children.Add(new Label { FontSize = FixParams.SmallSize, Text = prayer._MD, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center, TextColor = FixParams.FontColor, BackgroundColor = FixParams.BackgroundColor }, 3, 1);
                        grdPryingTimes.Children.Add(new Label { FontSize = FixParams.SmallSize, Text = prayer._SS, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center, TextColor = FixParams.FontColor, BackgroundColor = FixParams.BackgroundColor }, 2, 1);
                        grdPryingTimes.Children.Add(new Label { FontSize = FixParams.SmallSize, Text = prayer._NP, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center, TextColor = FixParams.FontColor, BackgroundColor = FixParams.BackgroundColor }, 1, 1);
                        grdPryingTimes.Children.Add(new Label { FontSize = FixParams.SmallSize, Text = prayer._MN, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center, TextColor = FixParams.FontColor, BackgroundColor = FixParams.BackgroundColor }, 0, 1);

                        _pnlDayNote.Children.Clear();
                        lblNote.Text = CalendarClass.Events(CalendarClass.DateToDateTime(_ActiveDate));
                        if (CalendarClass.IsHolyDay(CalendarClass.DateToDateTime(_ActiveDate))) lblNote.TextColor = FixParams.AlterFontColor;
                        _pnlDayNote.Children.Add(lblNote);

                    }), NumberOfTapsRequired = 1 });

                grdTemp.Children.Add(lblDayNum, 6 - i, 1);
            }
            return grdTemp;
        }

        public Grid CreatePryingTimeGrid(string ActiveDate)
        {

            var grdTemp = new Grid();

            grdTemp.RowSpacing = 0;
            grdTemp.ColumnSpacing = 2 * FixParams.AspectRate;
            grdTemp.Padding = 2 * FixParams.AspectRate;
            grdTemp.BackgroundColor = FixParams.PanelColor;


            for (int i = 0; i < 6; i++)
                grdTemp.Children.Add(FixParams.PryingImages[6 - i], i, 0);

            prayer _prayer = new prayer();
            _prayer.UpdatePryTimes(_ActiveDate);

            grdTemp.Children.Add(new Label { FontSize = FixParams.SmallSize, Text = prayer._MP, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center, TextColor = FixParams.FontColor, BackgroundColor = FixParams.BackgroundColor }, 5, 1);
            grdTemp.Children.Add(new Label { FontSize = FixParams.SmallSize, Text = prayer._SR, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center, TextColor = FixParams.FontColor, BackgroundColor = FixParams.BackgroundColor }, 4, 1);
            grdTemp.Children.Add(new Label { FontSize = FixParams.SmallSize, Text = prayer._MD, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center, TextColor = FixParams.FontColor, BackgroundColor = FixParams.BackgroundColor }, 3, 1);
            grdTemp.Children.Add(new Label { FontSize = FixParams.SmallSize, Text = prayer._SS, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center, TextColor = FixParams.FontColor, BackgroundColor = FixParams.BackgroundColor }, 2, 1);
            grdTemp.Children.Add(new Label { FontSize = FixParams.SmallSize, Text = prayer._NP, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center, TextColor = FixParams.FontColor, BackgroundColor = FixParams.BackgroundColor }, 1, 1);
            grdTemp.Children.Add(new Label { FontSize = FixParams.SmallSize, Text = prayer._MN, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center, TextColor = FixParams.FontColor, BackgroundColor = FixParams.BackgroundColor }, 0, 1);

            return grdTemp;
        }

        public void CreatePanel(RelativeLayout _layout, string _Note)
        {
            if (_pnlDayNote != null)
                _pnlDayNote = null;

            if (_pnlDayNote == null)
            {
                _pnlDayNote = new StackLayout
                {
                    Children = {
                        new StackLayout {
                            Children = {lblNote
                            },
                            Padding = 2 * FixParams.AspectRate,
                            BackgroundColor = FixParams.PanelColor,
                            VerticalOptions = LayoutOptions.FillAndExpand,
                            HorizontalOptions = LayoutOptions.FillAndExpand,
                        }
                    },
                    Padding = 5 * FixParams.AspectRate,
                    VerticalOptions = LayoutOptions.FillAndExpand,
                    HorizontalOptions = LayoutOptions.StartAndExpand,
                    BackgroundColor = FixParams.BackgroundColor
                };

                _layout.Children.Add(_pnlDayNote,
                    Constraint.RelativeToParent((p) => {
                        return 0;
                    }),
                    Constraint.RelativeToParent((p) => {
                        return grdWeekDays.Y + grdWeekDays.Height + (5 * FixParams.AspectRate);
                    }),
                    Constraint.RelativeToParent((p) => {                        
                        return _layout.Width;
                    }),
                    Constraint.RelativeToParent((p) => {                       
                        return grdPryingTimes.Y - DayNumber.Height - grdWeekDays.Height - (15 * FixParams.AspectRate);
                    })
                );
            }
        }

        public async void Animateview(View view, uint rate)
        {
            await view.ScaleTo(0, rate, Easing.CubicIn);
            await view.ScaleTo(1, rate, Easing.CubicInOut);
        }

        public void OnWeekClicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(wv);
            App.HomePage.Detail.Title = "NOTMAIN";
        }


        public CalendarDayView()
        {
            if (FixParams.FromOut && FixParams.ActiveDate != "")
            {
                _ActiveDate = FixParams.ActiveDate;
                _ActiveWeekDay = CalendarClass.WeekDay(FixParams.ActiveDate);
                FixParams.FromOut = false;
                FixParams.ActiveDate = "";
                showbtmbar = false;
            }
            else
            {
                _ActiveDate = CalendarClass.TodayDate();
                _ActiveWeekDay = CalendarClass.WeekDay(CalendarClass.TodayDate());
            }

            MonthName.Text = CalendarClass.MonthName(_ActiveDate) + " ماه " + CalendarClass.YearName(_ActiveDate);
            DayNumber.Text = CalendarClass.DayNumber(_ActiveDate);
            DayName.Text = CalendarClass.WeekDayName(CalendarClass.WeekDay(_ActiveDate));

            lblNote.Text = CalendarClass.Events(CalendarClass.DateToDateTime(_ActiveDate));

            grdWeekDays = CreateWeekGrid(_ActiveDate, _ActiveWeekDay);

            _layout.Children.Clear();           

            _layout.Children.Add(DayNumber,
                                Constraint.RelativeToParent((p) =>
                                {
                                    return _layout.Width - (65 * FixParams.AspectRate);
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return 5 * FixParams.AspectRate;
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return 60 * FixParams.AspectRate;
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return 55 * FixParams.AspectRate;
                                })
                            );

            _layout.Children.Add(MonthName,
                                Constraint.RelativeToParent((p) =>
                                {
                                    return _layout.Width - (180 * FixParams.AspectRate);
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return 1 * FixParams.AspectRate;
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return 120 * FixParams.AspectRate;
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return 30 * FixParams.AspectRate;
                                })
                            );

            _layout.Children.Add(DayName,
                                Constraint.RelativeToParent((p) =>
                                {
                                    return _layout.Width - (180 * FixParams.AspectRate);
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return 25 * FixParams.AspectRate;
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return 120 * FixParams.AspectRate;
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return 30 * FixParams.AspectRate;
                                })
                            );

            _layout.Children.Add(grdWeekDays,
                                Constraint.RelativeToParent((p) =>
                                {
                                    return 10 * FixParams.AspectRate;
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return DayNumber.Height;
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return _layout.Width - (20 * FixParams.AspectRate);
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return 75 * FixParams.AspectRate;
                                })
                            );

            grdPryingTimes = CreatePryingTimeGrid(_ActiveDate);

            _layout.Children.Add(grdPryingTimes,
                                Constraint.RelativeToParent((p) =>
                                {
                                    return 10 * FixParams.AspectRate;
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return _layout.Height - (100 * FixParams.AspectRate);
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return _layout.Width - (20 * FixParams.AspectRate);
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return 50 * FixParams.AspectRate;
                                })
                            );


            _layout.Children.Add(ButtomLayout,
                                Constraint.RelativeToParent((p) =>
                                {
                                    return 0;
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return _layout.Height - (40 * FixParams.AspectRate);
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return _layout.Width;
                                }),
                                Constraint.RelativeToParent((p) =>
                                {
                                    return 40 * FixParams.AspectRate;
                                })
                            );

            Button btnGotoWeekView = new Button()
            {
                BackgroundColor = FixParams.PanelColor,
                Text = "هفته",
                FontSize = FixParams.StandardSize,
                TextColor = FixParams.FontColor,
                HeightRequest = 40 * FixParams.AspectRate,                
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.StartAndExpand,
            };

            btnGotoWeekView.Clicked += OnWeekClicked;

            if (showbtmbar)
                ButtomLayout.Children.Insert(0, btnGotoWeekView);

            CreatePanel(_layout, _ActiveDate);

            Task.Run(() =>
            {
                CalendarMenu cm = new CalendarMenu();
                cm.CreateYearDays();
                App.YearDays = cm.CalendarDataList;

                cm.CreateWeekLayout(App.YearDays);
                App.GridOfWeeks = cm.GridList;

                wv = new CalendarWeekView();
            });
            
            Content = _layout;
        }
	}
}
