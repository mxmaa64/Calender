using Xamarin.Forms;

namespace Calendar
{
    public class CustomSwitch : Switch
    {
        public static BindableProperty TextProperty = BindableProperty.Create<CustomSwitch, string>(p => p.Text, "");
        public static readonly BindableProperty TextOnProperty = BindableProperty.Create<CustomSwitch, string>(p => p.TextOn, "");
        public static readonly BindableProperty TextOffProperty = BindableProperty.Create<CustomSwitch, string>(p => p.TextOff, "");

        public string Text
        {
            get { return (string)GetValue(TextProperty); }
            set { SetValue(TextProperty, value); }
        }
        public string TextOn
        {
            get { return (string)GetValue(TextOnProperty); }
            set { SetValue(TextOnProperty, value); }
        }

        public string TextOff
        {
            get { return (string)GetValue(TextOffProperty); }
            set { SetValue(TextOffProperty, value); }
        }
    }
}
