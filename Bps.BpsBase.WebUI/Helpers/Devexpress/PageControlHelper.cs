using System.Web.UI.WebControls;
using DevExpress.Web;
using DevExpress.Web.Mvc;

public static class PageControlHelper
{
    public static PageControlSettings Settings(PageControlSettings settings, bool showTabs =true)
    {
        settings.Width = Unit.Percentage(100);
        settings.EnableTabScrolling = true;
        settings.TabAlign = TabAlign.Justify;
        settings.ShowTabs = showTabs;
        settings.ControlStyle.Paddings.Padding = 0;
        settings.ControlStyle.CssClass = "dxtcFixed";
        settings.Styles.Content.Paddings.Padding = 0;
        return settings;
    }
}