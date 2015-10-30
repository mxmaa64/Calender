using System;
using System.Collections.Generic;
using System.Globalization;

namespace Calendar
{
    class CalendarClass
    {
        public static bool IsHolyDay(DateTime mydate)
        {
            PersianCalendar PersianCalEvents = new PersianCalendar();
            HijriCalendar HijriCalEvents = new HijriCalendar();

            var PerDay = PersianCalEvents.GetDayOfMonth(mydate);
            var HijDay = HijriCalEvents.GetDayOfMonth(CalendarClass.Yesterday(mydate));

            var PerMonth = PersianCalEvents.GetMonth(mydate);
            var HijMonth = HijriCalEvents.GetMonth(CalendarClass.Yesterday(mydate));

            switch (PerMonth)
            {
                case 1:
                    switch (PerDay)
                    {
                        case 1: return true;
                        case 2: return true;
                        case 3: return true;
                        case 4: return true;
                        case 12: return true;
                        case 13: return true;
                    }
                    break;
                case 3:
                    switch (PerDay)
                    {
                        case 14: return true;
                        case 15: return true;
                    }
                    break;
                case 11:
                    switch (PerDay)
                    {
                        case 22: return true;
                    }
                    break;
                case 12:
                    switch (PerDay)
                    {
                        case 29: return true;
                    }
                    break;
            }

            switch (HijMonth)
            {
                case 1:
                    switch (HijDay)
                    {
                        case 9: return true;
                        case 10: return true;
                    }
                    break;
                case 2:
                    switch (HijDay)
                    {
                        case 20: return true;
                        case 28: return true;
                        case 30: return true;
                    }
                    break;
                case 3:
                    switch (HijDay)
                    {
                        case 17: return true;
                    }
                    break;
                case 6:
                    switch (HijDay)
                    {
                        case 3: return true;
                    }
                    break;
                case 7:
                    switch (HijDay)
                    {
                        case 13: return true;
                        case 27: return true;
                    }
                    break;
                case 8:
                    switch (HijDay)
                    {
                        case 15: return true;
                    }
                    break;
                case 9:
                    switch (HijDay)
                    {
                        case 21: return true;
                    }
                    break;
                case 10:
                    switch (HijDay)
                    {
                        case 1: return true;
                        case 2: return true;
                        case 25: return true;
                    }
                    break;
                case 12:
                    switch (HijDay)
                    {
                        case 10: return true;
                        case 18: return true;
                    }
                    break;

            }

            return false;
        }
        public static string Events(DateTime mydate)
        {
            PersianCalendar PersianCalEvents = new PersianCalendar();
            HijriCalendar HijriCalEvents = new HijriCalendar();

            var PerDay = PersianCalEvents.GetDayOfMonth(mydate);
            var HijDay = HijriCalEvents.GetDayOfMonth(CalendarClass.Yesterday(mydate));

            var PerMonth = PersianCalEvents.GetMonth(mydate);
            var HijMonth = HijriCalEvents.GetMonth(CalendarClass.Yesterday(mydate));


            string PerisnEvents = "";
            string HijriEvents = "";
            string ReturnValue = "";

            switch (PerMonth)
            {
                case 1:
                    switch (PerDay)
                    {
                        case 1: PerisnEvents = "سال نو بر شما مبارک باد"; break;
                        case 2: PerisnEvents = "هجوم ماموران ستم شاهی به مدرسه ی فیضیه ی -- تعطیل"; break;
                        case 12: PerisnEvents = "روز جمهوری اسلامی ایران -- تعطیل"; break;
                        case 13: PerisnEvents = "روز طبیعت -- تعطیل"; break;
                        case 18: PerisnEvents = "روز سلامتی - روز جهانی بهداشت"; break;
                        case 19: PerisnEvents = "شهادت آیت اله سید محمد باقر صدر و خواهر ایشان بنت الهدی توسط رژیم بعث عراق"; break;
                        case 20: PerisnEvents = "روز ملی فناوری هسته ای"; break;
                        case 21: PerisnEvents = "شهادت امیر سپهبد علی صیاد شیرازی"; break;
                        case 25: PerisnEvents = "روز بزرگداشت عطار نیشابوری"; break;
                        case 29: PerisnEvents = "روز ارتش جمهوری اسلامی ایران"; break;
                    }
                    break;
                case 2:
                    switch (PerDay)
                    {
                        case 1: PerisnEvents = "روز بزرگداشت سعدی"; break;
                        case 2: PerisnEvents = "تاسیس سپاه پاسداران انتقلاب اسلامی - سالروز اعلام انقلاب فرهنگی - روز زمین پاک"; break;
                        case 3: PerisnEvents = "روز بزرگداشت شیخ بهایی - روز ملی کار آفرینی"; break;
                        case 5: PerisnEvents = "شکست حمله نظامی آمریکا به ایران در طبس"; break;
                        case 9: PerisnEvents = "روز شوراها"; break;
                        case 10: PerisnEvents = " روز ملی خلیج فارس - آغاز عملیات بیت المقدس"; break;
                        case 12: PerisnEvents = "شهادت استاد مرتضی مطهری - روز معلم - روز جهانی کار و کارگر"; break;
                        case 15: PerisnEvents = "روز بزرگداشت شیخ صدوق"; break;
                        case 17: PerisnEvents = "روز اسناد ملی"; break;
                        case 19: PerisnEvents = "روز جهانی صلیب سرخ و حلال احمر"; break;
                        case 24: PerisnEvents = "لغو امتیاز تنباکو به فتوای آیت الله میرزا حسن شیرازی"; break;
                        case 25: PerisnEvents = "روز بزرگداشت فردوسی"; break;
                        case 27: PerisnEvents = "روز جهانی ارتباطات و روابط عمومی"; break;
                        case 28: PerisnEvents = "روز بزرگداشت حکیم عمر خیام"; break;
                        case 29: PerisnEvents = "روز جهانی موزه و میراث فرهنگی"; break;
                    }
                    break;
                case 3:
                    switch (PerDay)
                    {
                        case 1: PerisnEvents = "روز بهره وری و بهینه سازی مصرف - روز بزرگداشت ملا صدرا"; break;
                        case 3: PerisnEvents = "فتح خرم شهر در عملیات بیت امقدس و روز مقاومت ، ایثار و پیروزی"; break;
                        case 14: PerisnEvents = "رحلت حضرت امام خمینی -- تعطیل"; break;
                        case 15: PerisnEvents = "قیام خونین 15 خرداد -- تعطیل"; break;
                        case 16: PerisnEvents = "روز جهانی محیط زیست"; break;
                        case 20: PerisnEvents = "شهادت آیت الله سعیدی به دست ماموران ستم شاهی پهلوی"; break;
                        case 24: PerisnEvents = "روز جهانی صنایع دستی"; break;
                        case 25: PerisnEvents = "روز گل و گیاه"; break;
                        case 26: PerisnEvents = "شهادت سربازان دلیر اسلام،بخارایی،امانی،صفار هرندی و نیک نژاد"; break;
                        case 27: PerisnEvents = "روز جهاد کشاورزی -- تشکیل جهاد سازندگی به فرمان امام"; break;
                        case 28: PerisnEvents = "روز جهانی بیابان زدایی"; break;
                        case 29: PerisnEvents = "درگذشت دکتر علی شریعتی"; break;
                        case 30: PerisnEvents = "انفجار در حرم حضرت امام رضا به دست منافقین کور دل"; break;
                        case 31: PerisnEvents = "شهادت دکتر مصطفی چمران"; break;
                    }
                    break;
                case 4:
                    switch (PerDay)
                    {
                        case 1: PerisnEvents = "روز تبلیغ و اطلاع رسانی دینی - روز اصناف"; break;
                        case 6: PerisnEvents = "روز جهانی مبارزه با مواد مخدر"; break;
                        case 7: PerisnEvents = "شهادت آیت الله دکتر بهشتی و 72 تن از یاران امام - روز قوه قضاییه"; break;
                        case 8: PerisnEvents = "روز مبارزه با صلاح های میکروبی و شیمیایی"; break;
                        case 10: PerisnEvents = "روز صنعت و معدن"; break;
                        case 11: PerisnEvents = "شهادت آیت الله صدوقی چهارمین شهید محراب به دست به دست منافقین"; break;
                        case 12: PerisnEvents = "سقوط هواپیمای مسافر بری جمهوری اسلامی ایران توسط آمریکا"; break;
                        case 14: PerisnEvents = "روز قلم"; break;
                        case 16: PerisnEvents = "روز مالیات"; break;
                        case 25: PerisnEvents = "روز بهزیستی و تامین اجتماعی"; break;
                        case 27: PerisnEvents = "اعلام پذیرش قطعنامه شورای امنیت از سوی ایران"; break;

                    }
                    break;
                case 5:
                    switch (PerDay)
                    {
                        case 5: PerisnEvents = "سالروز عملیات افتخار آفرین مرصاد"; break;
                        case 6: PerisnEvents = "روز ترویج آموزش های فنی و حرفه ای"; break;
                        case 8: PerisnEvents = "روز بزرگداشت شیخ شهاب الدین سهروردی شیخ اشراق"; break;
                        case 9: PerisnEvents = "روز اهدای خون"; break;
                        case 14: PerisnEvents = "صدور فرمان مشروطیت"; break;
                        case 16: PerisnEvents = "تشکیل جهاد دانشگاهی "; break;
                        case 17: PerisnEvents = "روز خبرنگار"; break;
                        case 26: PerisnEvents = "آغاز بازگشت آزادگان به میهن اسلامی"; break;
                        case 28: PerisnEvents = "کودتای آمریکا برای بازگرداندن شاه"; break;
                        case 30: PerisnEvents = "روز بزرگداشت علامه مجلسی"; break;
                        case 31: PerisnEvents = "روز جهانی مسجد"; break;
                    }
                    break;
                case 6:
                    switch (PerDay)
                    {
                        case 1: PerisnEvents = "روز پزشک - روز بزرگداشت ابوعلی سینا"; break;
                        case 2: PerisnEvents = "آغاز هفته دولت"; break;
                        case 4: PerisnEvents = "روز کارمند"; break;
                        case 5: PerisnEvents = "روز دارو سازی - روز بزرگداشت محمد بن زکریای رازی"; break;
                        case 8: PerisnEvents = "روز مبارزه با تروریسم - انفجار دفتر نخست وزیری"; break;
                        case 10: PerisnEvents = "روز بانکداری اسلامی - سالروز تصویب قانون عملیات بانکی بدون ربا"; break;
                        case 11: PerisnEvents = "روز صنعت چاپ"; break;
                        case 13: PerisnEvents = "روز تعاون - روز بزرگداش ابو ریحان بیرونی"; break;
                        case 14: PerisnEvents = "شهادت آیت الله قدوسی و سرتیپ وحید دستجردی"; break;
                        case 17: PerisnEvents = "قیام 17 شهریور و کشتار جمعی از مردم به دست ماموران پهلوی"; break;
                        case 19: PerisnEvents = "وفات آیت الله سید محمد طالقانی اولین امام جمعه تهران"; break;
                        case 20: PerisnEvents = "شهادت دوین شهید محراب آیت الله مدنی به دست منافقین"; break;
                        case 21: PerisnEvents = "روز سینما"; break;
                        case 27: PerisnEvents = "روز شعر و ادب فارسی - وز بزرگداشت استاد سید محمد حسین شهریار"; break;
                        case 31: PerisnEvents = "آغاز جنگ تحمیلی - آغاز هفته ی دفاع مقدس"; break;
                    }
                    break;
                case 7:
                    switch (PerDay)
                    {


                        case 5: PerisnEvents = "شکست حصر آبادان در عملیات ثامن الائمه"; break;
                        case 6: PerisnEvents = "روز جهانی جهانگردی"; break;
                        case 7: PerisnEvents = "روز آتشنشانی و ایمنی - شهادت سرداران اسلام"; break;
                        case 8: PerisnEvents = "روز بزرگداشت مولوی"; break;
                        case 9: PerisnEvents = "روز جهانی ناشنوایان و روز همبستگی کودکان و نوجوانان فلسطینی"; break;
                        case 13: PerisnEvents = "هجرت حضرت امام خمینی ره از عراق به پاریس - روز نیروی انتظامی"; break;
                        case 14: PerisnEvents = "روز دامپزشکی"; break;
                        case 17: PerisnEvents = "روز جهانی کودک "; break;
                        case 20: PerisnEvents = "روز بزگداشت حافظ - روز اسکان معلولان و سالمندان - روز ملی کاهش بلایای طبیعی"; break;
                        case 23: PerisnEvents = "شهادت پنجمین شهید معراب آیت الله اشرفی اصفهانی - روز جهانی استاندارد"; break;
                        case 24: PerisnEvents = "روز پیوند اولیا و مربیان - روز جهانی نابینایان عصای سفید"; break;
                        case 26: PerisnEvents = "روز تربیت بدنی و ورزش"; break;
                        case 29: PerisnEvents = "روز صادرات"; break;
                    }
                    break;
                case 8:
                    switch (PerDay)
                    {
                        case 1: PerisnEvents = "روز آمار  برنامه ریزی"; break;
                        case 4: PerisnEvents = "اعتراض افشاگری حضرت امام خمینی ره علیه پذیرش کاپیتولاسیون"; break;
                        case 8: PerisnEvents = "شهادت محمد حسین فهمیده - روز نوجوان - روز بسیج دانش آموزی"; break;
                        case 10: PerisnEvents = "شهادت آیت الله قاضی طباطبایی اولین شهید محراب"; break;
                        case 13: PerisnEvents = "روز ملی مبارزه با استکبار جهانی - روز دانش آموز - تسخیر لانه جاسوسی آمریکا به دست دانشجویان پیرو خط امام"; break;
                        case 14: PerisnEvents = "روز فرهنگ عمومی"; break;
                        case 18: PerisnEvents = "روز ملی کیفیت"; break;
                        case 24: PerisnEvents = "روز کتابخوانی - روز بزرگداشت علامه سید محمد حسین طباطبایی"; break;
                    }
                    break;
                case 9:
                    switch (PerDay)
                    {
                        case 5: PerisnEvents = "روز بسیج مستضعفان - تشکیل بسیج مستضعفین به فرمان حضرت امام خمینی ره"; break;
                        case 7: PerisnEvents = "روز نیروی دریایی"; break;
                        case 9: PerisnEvents = "روز بزرگداشت شیخ مفید"; break;
                        case 10: PerisnEvents = "شهادت آیت سید حسن مدرس و روز مجلس"; break;
                        case 12: PerisnEvents = "تصویب قانون اساسی جمهوری اسلامی ایران"; break;
                        case 13: PerisnEvents = "روز جهانی معلولان و روز بیمه"; break;
                        case 15: PerisnEvents = "شهادت مظلومانه زائران خانه ی خدا به دستور آمریکا"; break;
                        case 16: PerisnEvents = "روز داشجو"; break;
                        case 18: PerisnEvents = "معرفی عراق بعنوان مسئول و آغاز جنگ از سوی سازمان ملل"; break;
                        case 19: PerisnEvents = "تشکیل شورای انقلاب فرهنگی به فرمان حضرت امام خمینی ره "; break;
                        case 20: PerisnEvents = "شهادت آیت الله دست غیب سومین شهید محراب به دست منافقین"; break;
                        case 25: PerisnEvents = "روز پژوهش"; break;
                        case 26: PerisnEvents = "روز حمل ونقل"; break;
                        case 27: PerisnEvents = "شهادت آیت الله دکتر محمد مفتح - روز وحدت حوزه و دانشگاه"; break;
                    }
                    break;
                case 10:
                    switch (PerDay)
                    {
                        case 5: PerisnEvents = "روز ملی ایمنی در برابر زلزله"; break;
                        case 7: PerisnEvents = "سالروز تشکیل نهضت سوادآموزی به فرمان حضرت امام خمینی ره - شهادت آیت الله حسین غفاری به دست پهلوی"; break;
                        case 19: PerisnEvents = "قیام خونین مردم قم - روز تجلیل از اسرا و مفقودان"; break;
                        case 20: PerisnEvents = "شهادت میرزا تقی خان امیر کبیر"; break;
                        case 22: PerisnEvents = "تشکیل شورای انقلاب به فرمان حضرت امام خمینی ره"; break;
                        case 26: PerisnEvents = "فرار شاه معدوم"; break;
                        case 27: PerisnEvents = "شهادت نواب صفوی ، طهماسبی ، برادران واحدی و ذوالقدر از فداییان اسلام"; break;
                    }
                    break;
                case 11:
                    switch (PerDay)
                    {
                        case 6: PerisnEvents = "سالروز حماسه مردم آمل"; break;
                        case 12: PerisnEvents = "بازگشت حضرت امام خمینی ره به ایران و آغاز دهه ی مبارک فجر"; break;
                        case 14: PerisnEvents = " پرتاب موفقيت آميز ماهواره اميد به فضا و بازتاب آن در رسانه هاي جهان "; break;
                        case 19: PerisnEvents = "روز نیروی هوایی"; break;
                        case 22: PerisnEvents = "پیروزی انقلاب و سقوط شاهنشاهی -- تعطیل"; break;
                        case 29: PerisnEvents = "قیام مردم تبریز چهلمین روز شهادت شهدای قم"; break;
                    }
                    break;
                case 12:
                    switch (PerDay)
                    {
                        case 5: PerisnEvents = "روز بزرگداشت خواجه نصیرالدین طوسی - روز مهندسی - روز وقف"; break;
                        case 8: PerisnEvents = "روز امور تربیتی و تربیت اسلامی"; break;
                        case 9: PerisnEvents = "روز ملی حمایت از حقوق مصرف کنندگاه"; break;
                        case 14: PerisnEvents = "روز احسان و نیکوکاری"; break;
                        case 15: PerisnEvents = "روز درختکاری"; break;
                        case 22: PerisnEvents = "روز بزرگداشت شهدا"; break;
                        case 25: PerisnEvents = "روز اخلاق و مهرورزی -  بمباران شیمیایی حلبچه توسط عراق"; break;
                        case 29: PerisnEvents = "روز ملی شدن صنعت نفت ایران -- تعطیل"; break;
                    }
                    break;
            }

            switch (HijMonth)
            {
                case 1:
                    switch (HijDay)
                    {
                        case 1: HijriEvents = "آغاز سال جدید قمری"; break;
                        case 9: HijriEvents = "تاسوعای حسینی -- تعطیل"; break;
                        case 10: HijriEvents = "عاشورای حسینی -- تعطیل"; break;
                        case 12: HijriEvents = " شهادت حضرت زین العابدین ع"; break;
                        case 18: HijriEvents = "تغییر قبله مسلمین از بیت المقدس به مکه"; break;
                        case 25: HijriEvents = "شهادت امام زین العابدین علیه السلام به روایتی"; break;
                    }
                    break;
                case 2:
                    switch (HijDay)
                    {
                        case 3: HijriEvents = "ولادت حضرت امام محمد باقر ع"; break;
                        case 7: HijriEvents = "ولادت حضرت امام موسی کاظم ع"; break;
                        case 20: HijriEvents = "اربعین حسینی -- تعطیل"; break;
                        case 28: HijriEvents = "رحلت حضرت رسول اکرم ص - شهادت حضرت امام حسن مجتبی ع -- تعطیل"; break;
                        case 30: HijriEvents = "شهادت حضرت امام رضا ع - تعطیل"; break;
                    }
                    break;
                case 3:
                    switch (HijDay)
                    {
                        case 1: HijriEvents = "هجرت حضرت رسول ص از مکه به مدینه - مبداگاه شماری هجری قمری"; break;
                        case 8: HijriEvents = "شهادت حضرت امام حسن عسگری ع"; break;
                        case 12: HijriEvents = "میلاد حضرت رسول اکرم به روایت اهل سنت - آغاز هفته وحدت"; break;
                        case 17: HijriEvents = "میلاد حضرت رسول اکرم و روز اخلاق و مهرورزی -- میلاد امام جعفر صادق -- تعطیل"; break;
                    }
                    break;
                case 4:
                    switch (HijDay)
                    {
                        case 8: HijriEvents = "ولادت امام حسن عسکری علیه السلام"; break;
                        case 10: HijriEvents = "(وفات حضرت معصومه (س"; break;
                    }
                    break;
                case 5:
                    switch (HijDay)
                    {
                        case 5: HijriEvents = "ولادت حضرت زینب س - روز پرستار و بهورز"; break;
                    }
                    break;
                case 6:
                    switch (HijDay)
                    {
                        case 3: HijriEvents = "شهادت حضرت فاطمه زهرا س -- تعطیل"; break;
                        case 30: HijriEvents = "ولادت حضرت فاطمه زهرا - ولادت حضرت امام خمینی"; break;
                    }
                    break;
                case 7:
                    switch (HijDay)
                    {
                        case 1: HijriEvents = "ولادت حضرت امام محمد باقر"; break;
                        case 3: HijriEvents = "شهادت حضرت امام علی النقی الهادی "; break;
                        case 10: HijriEvents = "ولادت حضرت امام محمد تقی ع جواد الائمه"; break;
                        case 13: HijriEvents = "ولادت حضرت امام علی  علیه السلام - آغاز ایام اعتکاف -- تعطیل"; break;
                        case 15: HijriEvents = "وفات حضرت زینب"; break;
                        case 25: HijriEvents = "شهادت حضرت امام موسی کاظم ع"; break;
                        case 27: HijriEvents = "مبعث رسول اکرم ص -- تعطیل"; break;
                    }
                    break;
                case 8:
                    switch (HijDay)
                    {
                        case 3: HijriEvents = "ولادت حضرت امام حسین ع و روز پاسدار"; break;
                        case 4: HijriEvents = "ولادت حضرت ابوالفضل العباس و روز جانباز"; break;
                        case 5: HijriEvents = "ولادت حضرت امام زین العابدین ع"; break;
                        case 11: HijriEvents = "ولادت حضرت علی اکبر ع و روز جوان"; break;
                        case 15: HijriEvents = "ولادت حضرت قائم عج روز جهانی مستضعفان -- تعطیل"; break;
                    }
                    break;
                case 9:
                    switch (HijDay)
                    {
                        case 10: HijriEvents = "وفات حضرت خدیجه س"; break;
                        case 15: HijriEvents = "ولادت حضرت امام حسن مجتبی علیه السلام و روز اکرام"; break;
                        case 18: HijriEvents = "شب قدر"; break;
                        case 19: HijriEvents = " ضربت خوردن حضرت علی ع روز گفت و گوی تمدنها"; break;
                        case 20: HijriEvents = "شب قدر"; break;
                        case 21: HijriEvents = "شهادت حضرت علی علیه السلام -- تعطیل"; break;
                        case 22: HijriEvents = "شب قدر"; break;
                    }
                    break;
                case 10:
                    switch (HijDay)
                    {
                        case 1: HijriEvents = "عید سعید فطر -- تعطیل"; break;
                        case 2: HijriEvents = "به مناسبت عید سعید فطر -- تعطیل"; break;
                        case 3: HijriEvents = "سالروز شهادت حضرت سلطان علی بن امام محمد باقر"; break;
                        case 25: HijriEvents = "شهادت امام جعفر صادق ع -- تعطیل"; break;
                    }
                    break;
                case 11:
                    switch (HijDay)
                    {
                        case 1: HijriEvents = "ولادت حضرت معصومه س"; break;
                        case 11: HijriEvents = "ولادت حضرت امام رضا ع"; break;
                        case 29: HijriEvents = "شهادت امام محمد تقی ع جواد الائمه"; break;
                    }
                    break;
                case 12:
                    switch (HijDay)
                    {
                        case 1: HijriEvents = "سالروز ازدواج حضرت علی ع و حضرت فاطمه س"; break;
                        case 7: HijriEvents = "شهادت امام محمد باقر ع"; break;
                        case 9: HijriEvents = "روز عرفه - روز نیایش"; break;
                        case 10: HijriEvents = "عید سعید قربان -- تعطیل "; break;
                        case 15: HijriEvents = "ولادت حضرت امام علی النقی الهادی ع"; break;
                        case 18: HijriEvents = "روز غدیر خم -- تعطیل "; break;
                        case 24: HijriEvents = "روز مباهله پیامبر اسلام ص"; break;
                        case 25: HijriEvents = " روز خانواده وتکریم بازنشستگان "; break;
                    }
                    break;

            }

            if (mydate.Month == 1 && mydate.Day == 1)
                ReturnValue = PerisnEvents + " - " + HijriEvents + " - " + "آغاز سال جدید میلادی";
            else if (mydate.Month == 12 && mydate.Day == 25)
                ReturnValue = PerisnEvents + " - " + HijriEvents + " - " + "میلاد حضرت عیسی مسیح علیه السلام";

            if (PerisnEvents.Trim() == "" || HijriEvents.Trim() == "")
                return ReturnValue = PerisnEvents + HijriEvents;
            else
                return ReturnValue = PerisnEvents + "-" + HijriEvents;
        }

        public static Dictionary<int, string> MonthListName = 
            new Dictionary<int, string> {
                { 1, "فروردین"},
                { 2, "اردیبهشت"},
                { 3, "خرداد"},
                { 4, "تیر"},
                { 5, "مرداد"},
                { 6, "شهریور"},
                { 7, "مهر"},
                { 8, "آبان"},
                { 9, "آذر"},
                { 10, "دی"},
                { 11, "بهمن"},
                { 12, "اسفند"}};


        public static Dictionary<int, string> DayNames =
            new Dictionary<int, string> {
                { 0, "شنبه"},
                { 1, "یک شنبه"},
                { 2, "دو شنبه"},
                { 3, "سه شنبه"},
                { 4, "چهار شنبه"},
                { 5, "پنجشنبه"},
                { 6, "جمعه"},
                { 7, ""}};

        public static Dictionary<int, string> ArabicDayNames =
            new Dictionary<int, string> {
                { 0, "السبت"},
                { 1, "الاحد"},
                { 2, "الاثنین"},
                { 3, "الثلاثا"},
                { 4, "الاربعاء"},
                { 5, "الخمیس"},
                { 6, "الجمعه"}};

        public static Dictionary<int, string> GrigorianDayNames =
            new Dictionary<int, string> {
                { 0, "Saturday"},
                { 1, "Sunday"},
                { 2, "Monday"},
                { 3, "Tuesday"},
                { 4, "Wednesday"},
                { 5, "Thursday"},
                { 6, "Friday"}};

        public static Dictionary<int, string> ShortDayNames =
            new Dictionary<int, string> {
                { 0, "ش"},
                { 1, "ی"},
                { 2, "د"},
                { 3, "س"},
                { 4, "چ"},
                { 5, "پ"},
                { 6, "ج"}};
        public static string TodayDate()
        {
            var date = DateTime.Now;
            var calendar = new PersianCalendar();
            var persianDate = new DateTime(calendar.GetYear(date), calendar.GetMonth(date), calendar.GetDayOfMonth(date));
            var result = persianDate.ToString("yyyy/MM/dd", CultureInfo.GetCultureInfo("fa-Ir"));
            return result;
        }

        public static int IntToday(string todaydate)
        {
            var peryear = int.Parse(todaydate.Substring(0, 4));
            var permonth = int.Parse(todaydate.Substring(5, 2));
            var perday = int.Parse(todaydate.Substring(8, 2));

            var calendar = new PersianCalendar();
            DateTime date = new DateTime(peryear, permonth, perday, calendar);
            
            return date.DayOfYear;
        }

        public static DateTime DateToDateTime(string todaydate)
        {
            var peryear = int.Parse(todaydate.Substring(0, 4));
            var permonth = int.Parse(todaydate.Substring(5, 2));
            var perday = int.Parse(todaydate.Substring(8, 2));

            var calendar = new PersianCalendar();
            DateTime date = new DateTime(peryear, permonth, perday, calendar);

            return date;
        }

        public static bool IsLeapYear(int y)
        {
            int[] matches = { 1, 5, 9, 13, 17, 22, 26, 30 };
            int modulus = y - ((y / 33) * 33);
            bool K = false;
            for (int n = 0; n != 8; n++) if (matches[n] == modulus) K = true;
            return K;
        }

        public static int DayOfYearDay(int DayOfYear)
        {
            try
            {
                var year = DateTime.Now.Year;
                DateTime date = new DateTime(year, 1, 1).AddDays(DayOfYear - 1);
                var calendar = new PersianCalendar();

                int perDay = calendar.GetDayOfMonth(date);                

                return perDay;
            }
            catch (Exception ex)
            {
                var message = ex.Message;
                return 0;
            }            
        }

        public static string DayOfYearDate(int DayOfYear)
        {
            var year = DateTime.Now.Year;
            DateTime date = new DateTime(year, 1, 1).AddDays(DayOfYear - 1);
            var calendar = new PersianCalendar();
            var persiandate = calendar.GetYear(date) + "/" + FullMonthCode(calendar.GetMonth(date).ToString()) + "/" + FullDayCode(calendar.GetDayOfMonth(date).ToString());
            return persiandate;
        }

        public static string AddDayToDate(string adate, int adddays)
        {
            var peryear = int.Parse(adate.Substring(0, 4));
            var permonth = int.Parse(adate.Substring(5, 2));
            var perday = int.Parse(adate.Substring(8, 2));

            var calendar = new PersianCalendar();
            DateTime date = new DateTime(peryear, permonth, perday, calendar);
            TimeSpan t = (date - new DateTime(1, 1, 1));
            int days = (int)t.TotalDays;

            days += adddays;

            var newdate = new DateTime(1, 1, 1).AddDays(days);
            var persiandate = calendar.GetYear(newdate) + "/" + FullMonthCode(calendar.GetMonth(newdate).ToString()) + "/" + FullDayCode(calendar.GetDayOfMonth(newdate).ToString());
            return persiandate;
        }

        public static int ActiveWeekOfYear(string ActiveDate)
        {
            CultureInfo CI = new CultureInfo("fa-Ir");
            var Cal = CI.Calendar;
            CalendarWeekRule CWR = CI.DateTimeFormat.CalendarWeekRule;
            DayOfWeek FirstDOW = CI.DateTimeFormat.FirstDayOfWeek;
            int FirstWeek = Cal.GetWeekOfYear(DateToDateTime(CalendarClass.YearName(ActiveDate)+"/01/01"), CWR, FirstDOW);
            int week = Cal.GetWeekOfYear(DateToDateTime(ActiveDate), CWR, FirstDOW);
            return week - FirstWeek;
        }


        public static string WeekDayName(int WeekDayNumber)
        {
            return DayNames[WeekDayNumber];
        }

        public static int WeekDay(string todaydate)
        {
            var peryear = int.Parse(todaydate.Substring(0, 4));
            var permonth = int.Parse(todaydate.Substring(5, 2));
            var perday = int.Parse(todaydate.Substring(8, 2));

            var calendar = new PersianCalendar();
            DateTime date = new DateTime(peryear, permonth, perday, calendar);
            var ActiveWeekDay = (int)date.DayOfWeek;

            if (ActiveWeekDay <= 5) ActiveWeekDay += 1; else ActiveWeekDay -= 6;

            return ActiveWeekDay;
        }

        public static string MonthName(string todaydate)
        {
            var monthkey = todaydate.Substring(5, 2);
            return MonthListName[int.Parse(monthkey)];
        }

        public static string MonthNameByCode(int MonthCode)
        {
            return MonthListName[MonthCode];
        }

        public static string YearName(string todaydate)
        {
            return todaydate.Substring(0, 4);
        }

        public static int EnYearName(string todaydate)
        {
            var peryear = int.Parse(todaydate.Substring(0, 4));
            var permonth = int.Parse(todaydate.Substring(5, 2));
            var perday = int.Parse(todaydate.Substring(8, 2));

            var calendar = new PersianCalendar();
            DateTime date = new DateTime(peryear, permonth, perday, calendar);

            return date.Year;
        }

        public static string MonthCode(string todaydate)
        {
            return todaydate.Substring(5, 2);
        }
        public static string FullMonthCode(string MonthCode)
        {
            if (int.Parse(MonthCode) < 10)
                return "0" + MonthCode;
            else
                return MonthCode;
        }

        public static string FullDayCode(string DayCode)
        {
            if (int.Parse(DayCode) < 10)
                return "0" + DayCode;
            else
                return DayCode;
        }

        public static string DayNumber(string todaydate)
        {
            return int.Parse(todaydate.Substring(8, 2)).ToString();
        }
        public static string FullDate(string todaydate)
        {
            return WeekDayName(WeekDay(todaydate)) + ", " + DayNumber(todaydate) + " " + MonthName(todaydate) + " " + YearName(todaydate);
        }

        public static string FullDate(int year, int month, int day)
        {
            return year.ToString() + "/" + FullMonthCode(month.ToString()) + "/" + FullDayCode(day.ToString());
        }

        public static DateTime Yesterday(DateTime todaydate)
        {
            var calendar = new PersianCalendar();

            var peryear = calendar.GetYear(todaydate);
            var permonth = calendar.GetMonth(todaydate);
            var perday = calendar.GetDayOfMonth(todaydate);

            DateTime date = new DateTime(peryear, permonth, perday, calendar);

            var today = calendar.GetYear(date) + "/" + FullMonthCode(calendar.GetMonth(date).ToString()) + "/" + FullDayCode(calendar.GetDayOfMonth(date).ToString());
            var yesterdaydate = AddDayToDate(today, -1);

            peryear = int.Parse(yesterdaydate.Substring(0, 4));
            permonth = int.Parse(yesterdaydate.Substring(5, 2));
            perday = int.Parse(yesterdaydate.Substring(8, 2));

            DateTime yesterdaydatetime = new DateTime(peryear, permonth, perday, calendar);

            return yesterdaydatetime;
        }

    }
}
