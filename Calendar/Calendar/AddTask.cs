using Xamarin.Forms;

namespace Calendar
{
	public class AddTask : ContentPage
	{
        public string title = "";
        public string type = "";
        public string field = "";        
        public string contact = "";
        public string date = "";
        public string stime = "";
        public string ftime = "";
        public string scad = "";
        public string desc = "";

        public int stimeH = 0;
        public int stimeM = 0;
        public int ftimeH = 0;
        public int ftimeM = 0;

        public double percentval = 0;

        public bool repeat = false;
        public bool remind = false;

        public Entry txtTitle = new Entry
        {
            Text = "",
            Placeholder = "عنوان",
            TextColor = FixParams.FontColor,
            BackgroundColor = FixParams.BackgroundColor
        };

        public Entry txtType = new Entry
        {
            Text = "",
            Placeholder = "نوع",
            IsEnabled = false,
            TextColor = FixParams.FontColor,
            BackgroundColor = FixParams.BackgroundColor
        };

        public Entry txtField = new Entry
        {
            Text = "",
            Placeholder = "رسته",
            IsEnabled = false,
            TextColor = FixParams.FontColor,
            BackgroundColor = FixParams.BackgroundColor
        };

        public Entry txtContact = new Entry
        {
            Text = "",
            Placeholder = "طرف قرارداد",
            TextColor = FixParams.FontColor,
            BackgroundColor = FixParams.BackgroundColor
        };

        public Entry txtDate = new Entry
        {
            Text = "",
            Placeholder = "تاریخ",
            TextColor = FixParams.FontColor,
            BackgroundColor = FixParams.BackgroundColor
        };

        public TimePicker txtsTime = new TimePicker
        {
            Time = new System.TimeSpan(0, 0, 0),
            BackgroundColor = FixParams.BackgroundColor
        };

        public TimePicker txtfTime = new TimePicker
        {
            Time = new System.TimeSpan(0, 0, 0),
            BackgroundColor = FixParams.BackgroundColor
        };


        public Entry txtScad = new Entry
        {
            Text = "",
            Placeholder = "زمانبندی",
            TextColor = FixParams.FontColor,
            BackgroundColor = FixParams.BackgroundColor
        };

        public Entry txtDesc = new Entry
        {
            Text = "",
            Placeholder = "توضیحات",
            TextColor = FixParams.FontColor,
            BackgroundColor = FixParams.BackgroundColor
        };

        public CustomSwitch swRepeat = new CustomSwitch
        {
            TextOn = "   ",
            TextOff = "   ",
            IsToggled = false
        };

        public CustomSwitch swRemind = new CustomSwitch
        {
            TextOn = "   ",
            TextOff = "   ",
            IsToggled = false
        };

        public Slider percent = new Slider(0, 100, 0);

        public void FillData()
        {
            if (stime != "")
            {
                stimeH = int.Parse(stime.Substring(0, 2));
                stimeM = int.Parse(stime.Substring(3, 2));
            }
            else
            {
                stimeH = 0;
                stimeM = 0;
            }

            if (ftime != "")
            {
                ftimeH = int.Parse(ftime.Substring(0, 2));
                ftimeM = int.Parse(ftime.Substring(3, 2));
            }
            else
            {
                ftimeH = 0;
                ftimeM = 0;
            }

            txtTitle.Text       = title;
            txtType.Text        = type;
            txtField.Text       = field;
            txtContact.Text     = contact;
            txtDate.Text        = date;
            txtScad.Text        = scad;
            txtDesc.Text        = desc;
            txtsTime.Time       = new System.TimeSpan(stimeH, stimeM, 0);
            txtfTime.Time       = new System.TimeSpan(ftimeH, ftimeM, 0);
            percent.Value       = percentval;
            swRepeat.IsToggled  = repeat;
            swRemind.IsToggled  = remind;
        }
        public AddTask ()
		{
            var scrollview = new ScrollView
            {
                Content = new StackLayout
                {
                    Children = {
                        new Label { Text = "یادداشت ها / قرار ملاقات", HeightRequest = 30, XAlign = TextAlignment.Center, YAlign = TextAlignment.Center , TextColor = FixParams.AlterFontColor},
                        new Label { Text = "عنوان", TextColor = FixParams.FontColor, XAlign = TextAlignment.End},
                        txtTitle,
                        new Label { Text = "نوع", TextColor = FixParams.FontColor, XAlign = TextAlignment.End},
                        txtType,
                        new Label { Text = "رسته", TextColor = FixParams.FontColor, XAlign = TextAlignment.End},
                        txtField,
                        new Label { Text = "درصد پیشرفت", TextColor = FixParams.FontColor, XAlign = TextAlignment.End},
                        percent,
                        new Label { Text = "طرف قرارداد", TextColor = FixParams.FontColor, XAlign = TextAlignment.End},
                        txtContact,
                        new Label { Text = "تاریخ", TextColor = FixParams.FontColor, XAlign = TextAlignment.End},
                        txtDate,
                        new Label { Text = "ساعت شروع", TextColor = FixParams.FontColor, XAlign = TextAlignment.End},
                        txtsTime,
                        new Label { Text = "ساعت پایان", TextColor = FixParams.FontColor, XAlign = TextAlignment.End},
                        txtfTime,
                        new Label { Text = "تکرار", TextColor = FixParams.FontColor, XAlign = TextAlignment.End},
                        swRepeat,
                        new Label { Text = "بازه تکرار", TextColor = FixParams.FontColor, XAlign = TextAlignment.End},
                        txtScad,
                        new Label { Text = "یادآوری", TextColor = FixParams.FontColor, XAlign = TextAlignment.End},
                        swRemind,
                        new Label { Text = "توضیحات", TextColor = FixParams.FontColor, XAlign = TextAlignment.End},
                        txtDesc
                        },
                    Padding = new Thickness(20, 30, 20, 30),
                    HorizontalOptions = LayoutOptions.Fill,
                    VerticalOptions = LayoutOptions.Fill,
                    BackgroundColor = FixParams.PanelColor,
                    Spacing = 15
                }
            };

            Content = scrollview;
		}
	}
}
