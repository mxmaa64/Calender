using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace Calendar
{
    public class CalendarDataStruct
    {
        public int ID { get; set; }
        public int Day { get; set; }
        public int Month { get; set; }
        public string MonthName { get; set; }
        public int Year { get; set; }
        public int WeekDay { get; set; }
        public string WeekDayName { get; set; }
        public int WeekNo { get; set; }
        public string FullDate { get; set; }
        public string DayEvent { get; set; }
    }

    public class CalendarMenu
    {
        public List<CalendarDataStruct> CalendarDataList = new List<CalendarDataStruct>();
        public List<Grid> GridList = new List<Grid>();
        private void AddItem(int id, int day, int month, string monthName, int year, int weekday, string weekdayname, int weekno)
        {
            var cdt= new CalendarDataStruct();
            var adate = CalendarClass.FullDate(year, month, day);
            cdt.ID = id;
            cdt.Day = day;
            cdt.Month = month;
            cdt.MonthName = monthName;
            cdt.Year = year;
            cdt.WeekDay = weekday;
            cdt.WeekDayName = weekdayname;
            cdt.WeekNo = weekno;
            cdt.FullDate = adate;
            cdt.DayEvent = CalendarClass.Events(CalendarClass.DateToDateTime(adate));

            CalendarDataList.Add(cdt);
        }

        private StackLayout AddWeekDays(string dayname, string adate, string eventofday)
        {
            var lblDayName = new Label
            {
                TextColor = FixParams.AlterFontColor,
                BackgroundColor = FixParams.BackgroundColor,
                Text = " " + dayname,
                XAlign = TextAlignment.End,
                YAlign = TextAlignment.Start,
                FontSize = FixParams.MediumSize
            };

            var lblDate = new Label
            {
                TextColor = FixParams.FontColor,
                BackgroundColor = FixParams.BackgroundColor,
                Text = adate,
                XAlign = TextAlignment.Start,
                YAlign = TextAlignment.Start,
                FontSize = FixParams.StandardSize
            };

            var lblEvent = new Label
            {
                TextColor = FixParams.FontColor,
                BackgroundColor = FixParams.BackgroundColor,
                Text = eventofday,
                XAlign = TextAlignment.End,
                YAlign = TextAlignment.Start,
                FontSize = FixParams.VerySmallSize
            };

            var lblDay = new Label { Text = "", HorizontalOptions = LayoutOptions.FillAndExpand, VerticalOptions = LayoutOptions.FillAndExpand };

            lblDay.GestureRecognizers.
                Add(new TapGestureRecognizer
                {
                    Command = new Command(async () =>
                    {
                        FixParams.FromOut = true;
                        FixParams.ActiveDate = lblDate.Text;
                        await App.HomePage.Detail.Navigation.PushAsync(new CalendarDayView());
                    }),
                    NumberOfTapsRequired = 1
                });

            var DayStack = new StackLayout()
            {
                Children =
                            {
                                lblDayName,
                                lblDate,
                                lblEvent
                            },
                BackgroundColor = FixParams.BackgroundColor,
                VerticalOptions = LayoutOptions.FillAndExpand,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                Spacing = 2
            };

            return DayStack;
        }
        public void CreateWeekLayout(List<CalendarDataStruct> YearDays)
        {
            for (int i = 1; i<=53 ;i++)
            {
                var tmpgrd = new Grid();
                var thisweekdays = (from h in App.YearDays
                                    where h.WeekNo == i
                                    select new {h.WeekDay, h.WeekDayName, h.FullDate, h.DayEvent }).OrderBy(o => o.WeekDay); ;

                int j = 0;
                foreach (var weekdata in thisweekdays)
                {
                    if (weekdata.WeekDay % 2 != 0)
                    {
                        tmpgrd.Children.Add(AddWeekDays(weekdata.WeekDayName, weekdata.FullDate, weekdata.DayEvent), 0, j);
                        j++;
                    }
                    else
                        tmpgrd.Children.Add(AddWeekDays(weekdata.WeekDayName, weekdata.FullDate, weekdata.DayEvent), 1, j);
                }

                GridList.Add(tmpgrd);
            }
        }
        public void CreateYearDays()
        {
            try
            {
                var curyear = int.Parse(CalendarClass.YearName(CalendarClass.TodayDate()));
                var curday = 1;
                var curmonth = 1;
                var curweekno = 1;

                var curweekday = CalendarClass.WeekDay(curyear + "/01/01");
                var isleapyear = CalendarClass.IsLeapYear(curyear);
                int yeardays;
                if (isleapyear) yeardays = 366; else yeardays = 365;

                for (int i = 1; i <= yeardays; i++)
                {
                    AddItem(i, curday, curmonth, CalendarClass.MonthNameByCode(curmonth),
                                curyear, curweekday, CalendarClass.WeekDayName(curweekday), curweekno);
                    curday++;
                    curweekday++;

                    if (curmonth <= 6 && curday > 31)
                    {
                        curmonth++;
                        curday = 1;
                    }

                    if (curmonth > 6 && curday > 30)
                    {
                        curmonth++;
                        curday = 1;
                    }

                    if (curweekday > 6)
                    {
                        curweekday = 0;
                        curweekno++;
                    };
                }
            }
            catch (Exception ex)
            {
                var er = ex.Message;
            }
        }
    }
}

