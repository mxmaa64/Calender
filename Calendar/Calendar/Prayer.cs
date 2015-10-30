using System;
using System.Collections.Generic;

namespace Calendar
{
    public class prayer
    {

        public static double[] tol = new double[30] { 49.7, 48.3, 45.07, 51.64, 48.68, 46.42, 57.33, 56.29, 50.84, 59.21, 46.28, 51.41, 48.34, 49.59, 60.86, 48.5, 53.06, 53.39, 47, 50.86, 52.52, 50, 50.88, 57.06, 47.09, 54.44, 59.58, 48.52, 51.59, 54.35 };
        public static double[] arz = new double[30] { 34.09, 38.25, 37.55, 32.68, 31.32, 33.64, 37.47, 27.19, 28.97, 32.86, 38.08, 35.7, 33.46, 37.28, 29.5, 36.68, 36.57, 35.58, 35.31, 32.33, 29.62, 36.28, 34.64, 30.29, 34.34, 36.84, 36.31, 34.8, 30.67, 31.89 };

        //Longitude=طول
        //Latitude=عرض

        public static int _ActiveCityIndex = 11;
        public double _Longitude = tol[_ActiveCityIndex];
        public double _Latitude = arz[_ActiveCityIndex];

        public static string _MP;
        public static string _SR;
        public static string _MD;
        public static string _SS;
        public static string _NP;
        public static string _MN;

        public void UpdatePryTimes(string ActiveDate)
        {
            _MP = MorningPrayerByDate(ActiveDate);
            _SR = SunriseByDate(ActiveDate);
            _MD = MiddayPrayerByDate(ActiveDate);
            _SS = SunsetByDate(ActiveDate);
            _NP = SunsetPrayerByDate(ActiveDate);
            _MN = MidnightByDate(ActiveDate);
        }
        public string MorningPrayerByDate(string ActiveDate)
        {
            var Day = CalendarClass.DayNumber(ActiveDate);
            var Month = CalendarClass.MonthCode(ActiveDate);
            return MorningPrayer(byte.Parse(Month), byte.Parse(Day), _Longitude, _Latitude).ToString().Substring(0,5);
        }

        public string SunriseByDate(string ActiveDate)
        {
            var Day = CalendarClass.DayNumber(ActiveDate);
            var Month = CalendarClass.MonthCode(ActiveDate);
            return Sunrise(byte.Parse(Month), byte.Parse(Day), _Longitude, _Latitude).ToString().Substring(0, 5);
        }

        public string MiddayPrayerByDate(string ActiveDate)
        {
            var Day = CalendarClass.DayNumber(ActiveDate);
            var Month = CalendarClass.MonthCode(ActiveDate);
            return MiddayPrayer(byte.Parse(Month), byte.Parse(Day), _Longitude).ToString().Substring(0, 5);
        }

        public string SunsetByDate(string ActiveDate)
        {
            var Day = CalendarClass.DayNumber(ActiveDate);
            var Month = CalendarClass.MonthCode(ActiveDate);
            return Sunset(byte.Parse(Month), byte.Parse(Day), _Longitude, _Latitude).ToString().Substring(0, 5);
        }
        public string SunsetPrayerByDate(string ActiveDate)
        {
            var Day = CalendarClass.DayNumber(ActiveDate);
            var Month = CalendarClass.MonthCode(ActiveDate);
            return SunsetPrayer(byte.Parse(Month), byte.Parse(Day), _Longitude, _Latitude).ToString().Substring(0, 5);
        }

        public string MidnightByDate(string ActiveDate)
        {
            var Day = CalendarClass.DayNumber(ActiveDate);
            var Month = CalendarClass.MonthCode(ActiveDate);
            var tmpmidday = MiddayPrayer(byte.Parse(Month), byte.Parse(Day), _Longitude).ToString().Substring(0, 5);

            var hrs = int.Parse(tmpmidday.Substring(0, 2)) + 11;
            var min = int.Parse(tmpmidday.Substring(3, 2)) + 17;

            if (min > 60)
            {
                min -= 60;
                hrs += 1;
            }

            if (hrs > 24)
                hrs = 0;

            var strmin = min.ToString();
            if (min < 10) strmin = "0" + strmin;

            return (hrs).ToString() + ":"+ strmin;
        }

        public Dictionary<int, string> CityListName =
            new Dictionary<int, string>
            {
                {1,"اراک"},
                {2,"اردبيل"},
                {3,"اروميه"},
                {4,"اصفهان"},
                {5,"اهواز"},
                {6,"ايلام"},
                {7,"بجنورد"},
                {8,"بندرعباس"},
                {9,"بوشهر"},
                {10,"بيرجند"},
                {11,"تبريز"},
                {12,"تهران"},
                {13,"خرم آباد"},
                {14,"رشت"},
                {15,"زاهدان"},
                {16,"زنجان"},
                {17,"ساري"},
                {18,"سمنان"},
                {19,"سنندج"},
                {20,"شهرکرد"},
                {21,"شيراز"},
                {22,"قزوين"},
                {23,"قم"},
                {24,"کرمان"},
                {25,"کرمانشاه"},
                {26,"گرگان"},
                {27,"مشهد"},
                {28,"همدان"},
                {29,"ياسوج"},
                {30,"يزد"}
            };

        struct Values
        {
            public double Val0, Val1;
        }
        public int month;
        public TimeSpan MorningPrayer(byte Month, byte Day, double Longitude, double Latitude)
        {
            Values ep = sun(Month, Day, 4, Longitude);
            double zr = ep.Val0,
                delta = ep.Val1,
                ha = loc2hor(108.0, delta, Latitude),
                t = Round(zr - ha, 24);
            ep = sun(Month, Day, t, Longitude);
            zr = ep.Val0;
            delta = ep.Val1;
            ha = loc2hor(108.0, delta, Latitude);
            t = Round(zr - ha, 24);
            return TimeSpan.Parse(hms(t));
        }
        public TimeSpan Sunrise(byte Month, byte Day, double Longitude, double Latitude)
        {
            Values ep = sun(Month, Day, 6, Longitude);
            double zr = ep.Val0,
            delta = ep.Val1,
            ha = loc2hor(90.833, delta, Latitude),
            t = Round(zr - ha, 24);
            ep = sun(Month, Day, t, Longitude);
            zr = ep.Val0;
            delta = ep.Val1;
            ha = loc2hor(90.833, delta, Latitude);
            t = Round(zr - ha, 24);
            return TimeSpan.Parse(hms(t));
        }
        public TimeSpan MiddayPrayer(byte Month, byte Day, double Longitude)
        {
            Values ep = sun(Month, Day, 12, Longitude);
            ep = sun(Month, Day, ep.Val0, Longitude);
            double zr = ep.Val0;
            return TimeSpan.Parse(hms(zr));
        }
        public TimeSpan Sunset(byte Month, byte Day, double Longitude, double Latitude)
        {
            Values ep = sun(Month, Day, 18, Longitude);
            double zr = ep.Val0,
            delta = ep.Val1,
            ha = loc2hor(90.833, delta, Latitude),
            t = Round(zr + ha, 24);
            ep = sun(Month, Day, t, Longitude);
            zr = ep.Val0;
            delta = ep.Val1;
            ha = loc2hor(90.833, delta, Latitude);
            t = Round(zr + ha, 24);
            return TimeSpan.Parse(hms(t));
        }
        public TimeSpan SunsetPrayer(byte Month, byte Day, double Longitude, double Latitude)
        {
            Values ep = sun(Month, Day, 18.5, Longitude);
            double zr = ep.Val0,
            delta = ep.Val1,
            ha = loc2hor(94.3, delta, Latitude),
            t = Round(zr + ha, 24);
            ep = sun(Month, Day, t, Longitude);
            zr = ep.Val0;
            delta = ep.Val1;
            ha = loc2hor(94.3, delta, Latitude);
            t = Round(zr + ha, 24);
            return TimeSpan.Parse(hms(t));
        }

        Values sun(byte m, double d, double h, double lg)
        {
            if (m < 7)
                d = 31 * (m - 1) + d + h / 24;
            else
                d = 6 + 30 * (m - 1) + d + h / 24;
            double M = 74.2023 + 0.98560026 * d,
                L = -2.75043 + 0.98564735 * d,
                lst = 8.3162159 + 0.065709824 * Math.Floor(d) + 1.00273791 * 24 * (d % 1) + lg / 15,
                e = 0.0167065,
                omega = 4.85131 - 0.052954 * d,
                ep = 23.4384717 + 0.00256 * cosd(omega),
                ed = 180.0 / Math.PI * e, u = M;
            for (byte i = 1; i < 5; i++)
                u = u - (u - ed * sind(u) - M) / (1 - e * cosd(u));
            double v = 2 * atand(tand(u / 2) * Math.Sqrt((1 + e) / (1 - e))),
                theta = L + v - M - 0.00569 - 0.00479 * sind(omega),
                delta = asind(sind(ep) * sind(theta)),
                alpha = 180.0 / Math.PI * Math.Atan2(cosd(ep) * sind(theta), cosd(theta));
            if (alpha >= 360)
                alpha -= 360;
            double ha = lst - alpha / 15;
            double zr = Round(h - ha, 24);
            Values vlu;
            vlu.Val1 = delta;
            vlu.Val0 = zr;
            return vlu;
        }
        double sind(double x) { return Math.Sin(Math.PI / 180.0 * x); }
        double cosd(double x) { return Math.Cos(Math.PI / 180.0 * x); }
        double tand(double x) { return Math.Tan(Math.PI / 180.0 * x); }
        double atand(double x) { return Math.Atan(x) * 180.0 / Math.PI; }
        double asind(double x) { return Math.Asin(x) * 180.0 / Math.PI; }
        double acosd(double x) { return Math.Acos(x) * 180.0 / Math.PI; }
        double loc2hor(double z, double d, double p) { return acosd((cosd(z) - sind(d) * sind(p)) / cosd(d) / cosd(p)) / 15; }
        double Round(double x, byte a)
        {
            double tmp = x % a;
            if (tmp < 0)
                tmp += a;
            return tmp;
        }
        string hms(double x)
        {
            x = Math.Floor(3600 * x);
            double
            h = Math.Floor(x / 3600),
            mp = x - 3600 * h,
            m = Math.Floor(mp / 60),
            s = Math.Floor(mp - 60 * m);
            //چون ساعت جدید میشود
            if (month >= 7)
                h--;
            //
            return h.ToString() + ":" + m.ToString() + ":" + s.ToString();
        }


    }
}
