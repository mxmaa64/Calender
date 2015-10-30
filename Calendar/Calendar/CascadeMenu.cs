using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Calendar
{
    public class CasecadeItems
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public int Level { get; set; }
        public Type TargetType { get; set; }
        public bool IsSpecial { get; set; }
        public Color TextColor { get; set; }
        public double FontSize { get; set; }
        public int RowHeight { get; set; }
    }

    public class CascadeListView : ListView
    {
        public CascadeListView(List<CasecadeItems> data)
        {
            ItemsSource = data;
            HorizontalOptions = LayoutOptions.End;
            BackgroundColor = Color.Transparent;
            var cell = new DataTemplate(typeof(MenuCell));
            cell.SetBinding(TextCell.TextProperty, "ID");
            cell.SetBinding(TextCell.TextProperty, "Title");
            cell.SetBinding(TextCell.TextProperty, "Level");
            ItemTemplate = cell;
        }
    }

    public class CascadeMenu
    {
        public List<CasecadeItems> CascadeListData = new List<CasecadeItems>();
        public void AddItem(int id, string title, int level = 0, Type targettype = null, double? fontsize = null, 
                                    int? rowheight = null,  bool isspecial = false, Color? textcolor = null)
        {
            CasecadeItems item = new CasecadeItems();
            item.ID = id;
            item.Title = title;
            item.Level = level;
            item.TargetType = targettype;
            item.IsSpecial = isspecial;
            item.TextColor = textcolor ?? FixParams.FontColor;
            item.FontSize  = fontsize  ?? FixParams.StandardSize;
            item.RowHeight = rowheight * (int)Math.Round(FixParams.AspectRate) ?? 40 * (int)Math.Round(FixParams.AspectRate);

            CascadeListData.Add(item);
        }
    }
}
