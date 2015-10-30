using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Calendar
{
    public class MyMasterDetailPage : MultiPage<Page>
    {
        protected override Page CreateDefault(object item)
        {
            return new ContentPage();
        }
        public StackLayout Master { set; get; }
        public StackLayout ShortCutMenu { set; get; }

        public ContentPage MasterPage = new ContentPage();

        public ContentPage ShortCutPage = new ContentPage();
        public Page Detail { set; get; }
        public enum OrientationType { Left, Right, Undefined };
        public OrientationType Orientation { get; set; }
        public float MasterPercent { get; set; }
        bool masterMoving;
        bool masterExtended;
        bool flingOpen;
        bool flingClosed;

        float masterOffSet;

        public MyMasterDetailPage()
        {
            masterMoving = masterExtended = flingOpen = flingClosed  = false;

            masterOffSet = 0;

            SizeChanged += (s, e) =>
            {
                doAppear();
            };
        }

        public async void doAppear()
        {
            while (Width == -1) { await Task.Delay(1); }

            Master.BackgroundColor = FixParams.PanelColor;
            Master.Opacity = 1;

            ShortCutMenu.BackgroundColor = FixParams.PanelColor;
            ShortCutMenu.Opacity = 1;

            MasterPage.Content = Master;
            ShortCutPage.Content = ShortCutMenu;

            Children.Add(Detail);
            Children.Add(ShortCutPage);
            Children.Add(MasterPage);

            MasterPage.IsVisible = false;
            ShortCutPage.IsVisible = false;

            Detail.Layout(new Rectangle(0, 0, Width, Height));
            Master.Layout(getMasterClosedRectangle());
            ShortCutMenu.Layout(getShortcutClosedRectangle());
        }

        private bool left()
        {
            return Orientation == OrientationType.Left;
        }
        private bool right()
        {
            return Orientation == OrientationType.Right;
        }

        private Rectangle getMasterClosedRectangle()
        {
            if (right())
            {
                return new Rectangle(Width, 0, Width * MasterPercent, Height);
            }
            else if (left())
            {
                return new Rectangle(0 - Width, 0, Width * MasterPercent, Height);
            }
            return new Rectangle();
        }

        public Rectangle getShortcutClosedRectangle()
        {
            return new Rectangle(Width - 70 - FixParams.ShorcutMenuOffset, 0, FixParams.ShorcutMenuOffset, 0);
        }

        public Rectangle getShortcutOpenedRectangle()
        {
            return new Rectangle(Width - 70 - FixParams.ShorcutMenuOffset, 0, FixParams.ShorcutMenuOffset, 185 * FixParams.AspectRate);
        }
        private Rectangle getMasterOpenedRectangle()
        {
            if (right())
            {
                return new Rectangle(Width * (1 - MasterPercent), 0, Width * MasterPercent, Height);
            }
            else if (left())
            {
                return new Rectangle(0, 0, Width * MasterPercent, Height);
            }
            return new Rectangle();
        }

        public void doMove(float percent)
        {
            if (masterMoving && !outsideMasterWidth(percent + masterOffSet))
            {
                setMasterPosition(percent + masterOffSet);
            }
        }

        private async void setMasterPosition(float percent)
        {
            if (right())
            {
                await Master.LayoutTo(new Rectangle(Width * percent, 0, Width * MasterPercent, Height), 1);
            }
            else if (left())
            {
                await Master.LayoutTo(new Rectangle((Width * percent) - (Width * MasterPercent), 0, Width * MasterPercent, Height), 1);
            }
        }

        public void doUp(float percent)
        {
            doShortcutSmoothClose();
            if (masterMoving)
            {
                if (flingOpen)
                {
                    doSmoothOpen();
                    flingOpen = false;
                }
                else if (flingClosed)
                {
                    doSmoothClose();
                    flingClosed = false;
                }
                else if (beyondMasterHalfWay(percent + masterOffSet))
                {
                    doSmoothOpen();
                }
                else if (!beyondMasterHalfWay(percent + masterOffSet))
                {
                    doSmoothClose();
                }
                masterMoving = false;
            }
        }

        private bool beyondMasterHalfWay(float percent)
        {
            if (right())
            {
                if (percent <= 1 - (MasterPercent / 2))
                {
                    return true;
                }
                return false;
            }
            else if (left())
            {
                if (percent > MasterPercent / 2)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        public void doDown(float percent)
        {
            if (!masterExtended)
            {
                if (withinScreenEdge(percent))
                {
                    masterMoving = true;
                    Detail.IsEnabled = false;
                }
            }
            else
            {
                if (outsideMasterWidth(percent))
                {
                    doSmoothClose();
                }
                else
                {
                    setOffSet(percent);
                    masterMoving = true;
                }
            }
        }

        private void setOffSet(float percent)
        {
            if (right())
            {
                masterOffSet = 0 - (percent - (1 - MasterPercent));
            }
            else if (left())
            {
                masterOffSet = MasterPercent - percent;
            }
        }

        private bool withinScreenEdge(float percent)
        {
            if (right())
            {
                if (percent >= 0.98)
                {
                    MasterPage.IsVisible = true;
                    FirstPage.menuPage.Menu.SelectedItem = null;
                    return true;
                }
                return false;
            }
            else if (left())
            {
                if (percent <= 0.02)
                {
                    return true;
                }
                return false;
            }
            return false;
        }

        private bool outsideMasterWidth(float percent)
        {
            if (right())
            {
                if (percent < (1 - MasterPercent))
                {
                    return true;
                }
                return false;
            }
            else if (left())
            {
                if (percent > MasterPercent)
                {
                    return true;
                }
                return false;
            }
            return false;
        }
        public void doFling(float percent1, float percent2)
        {
            if (!masterExtended)
            {
                if (withinScreenEdge(percent1) && isOpenFling(percent1, percent2))
                {
                    flingOpen = true;
                    flingClosed = false;
                }
            }
            else
            {
                if (!isOpenFling(percent1, percent2))
                {
                    flingClosed = true;
                    flingOpen = false;
                }
            }
        }

        private bool isOpenFling(float percent1, float percent2)
        {
            if (right())
            {
                return percent1 > percent2;
            }
            else if (left())
            {
                return percent1 < percent2;
            }
            return false;
        }

        public void doSmoothOpen()
        {            
            fadeOutDetail();
            Master.LayoutTo(getMasterOpenedRectangle(), 250, Easing.SinOut);
            masterExtended = true;
            masterOffSet = 0;
        }

        public void doShortcutSmoothOpen()
        {
            ShortCutMenu.Layout(getShortcutOpenedRectangle());
        }
        public async void fadeOutDetail()
        {
            await Detail.FadeTo(0.4);
        }

        public void doShortcutSmoothClose()
        {
            ShortCutMenu.Layout(getShortcutClosedRectangle());
            ShortCutPage.IsVisible = false;
        }
        public void doSmoothClose()
        {
            fadeInDetail();
            Master.LayoutTo(getMasterClosedRectangle(), 250, Easing.SinOut);
            masterExtended = false;
            Detail.IsEnabled = true;
            masterOffSet = 0;

            MasterPage.IsVisible = false;            
        }
        public async void fadeInDetail()
        {
            await Detail.FadeTo(1);
        }


    }
}
