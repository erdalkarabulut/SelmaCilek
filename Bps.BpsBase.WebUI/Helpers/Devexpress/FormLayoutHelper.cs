using System;
using System.Web.UI.WebControls;
using DevExpress.Utils;
using DevExpress.Web;
using DevExpress.Web.Mvc;

public static class FormLayoutHelper<T> where T : class
{
    public static FormLayoutSettings<T> Settings(FormLayoutSettings<T> settings)
    {
        settings.Width = Unit.Percentage(100);
        settings.UseDefaultPaddings = false;

        settings.Styles.LayoutItem.Paddings.PaddingLeft = Unit.Pixel(10);
        settings.Styles.LayoutItem.Paddings.PaddingRight = Unit.Pixel(10);
        settings.Styles.Style.Paddings.Padding = Unit.Pixel(15);

        foreach (MVCxFormLayoutGroup layoutItem in settings.Items)
        {
            if (layoutItem.ClientVisible)
            {
                layoutItem.GroupBoxDecoration = GroupBoxDecoration.Box;
                layoutItem.GroupBoxStyle.Caption.Font.Bold = true;
                layoutItem.GroupBoxStyle.Caption.Font.Size = 15;
                layoutItem.GroupBoxStyle.Caption.CssClass = "groupCaption";
                layoutItem.GridSettings.StretchLastItem = DefaultBoolean.True;
                layoutItem.GridSettings.WrapCaptionAtWidth = 400;

                foreach (MVCxFormLayoutItem editor in layoutItem.Items)
                {
                    if (editor.ClientVisible && editor.NestedExtensionType != FormLayoutNestedExtensionItemType.Label && editor.NestedExtensionType != FormLayoutNestedExtensionItemType.Button)
                    {
                        //var attrType = typeof(T);
                        //var calcInstance = Activator.CreateInstance(attrType);
                        //var property = calcInstance.GetType().GetProperty(a.Name);
                        dynamic editorSettings = editor.NestedExtensionSettings;
                        editorSettings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None;
                        editorSettings.Properties.ValidationSettings.Display = Display.Dynamic;
                        editorSettings.ShowModelErrors = true;
                        editorSettings.Width = Unit.Percentage(100);
                    }
                }
            }
        }

        settings.SettingsAdaptivity.AdaptivityMode = FormLayoutAdaptivityMode.SingleColumnWindowLimit;
        settings.SettingsAdaptivity.SwitchToSingleColumnAtWindowInnerWidth = 700;
        return settings;
    }
}

public static class FormLayoutItemHelper
{
    static Action<MVCxFormLayoutItem> formLayoutItemSettingsMethod;
    public static Action<MVCxFormLayoutItem> FormLayoutItemSettingsMethod
    {
        get
        {
            if (formLayoutItemSettingsMethod == null)
                formLayoutItemSettingsMethod = CreateFormLayoutItemSettingsMethod();
            return formLayoutItemSettingsMethod;
        }
    }
    public static Action<MVCxFormLayoutItem> CreateFormLayoutItemSettingsMethod()
    {
        return itemSettings => {
            itemSettings.Width = Unit.Percentage(100);
            dynamic editorSettings = itemSettings.NestedExtensionSettings;
            editorSettings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;
            editorSettings.Properties.ValidationSettings.ErrorTextPosition = ErrorTextPosition.Bottom;
            //editorSettings.Properties.ValidationSettings.Display = Display.Dynamic;
            editorSettings.ShowModelErrors = true;
            editorSettings.Width = Unit.Percentage(100);
        };
    }

    public static MVCxFormLayoutItem CreateFormLayoutItemSettingsMethod2()
    {
        var mvCxFormLayoutItem = new MVCxFormLayoutItem();
        dynamic editorSettings = mvCxFormLayoutItem.NestedExtensionSettings;
        editorSettings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;
        editorSettings.Properties.ValidationSettings.ErrorTextPosition = ErrorTextPosition.Bottom;
        //editorSettings.Properties.ValidationSettings.Display = Display.Dynamic;
        editorSettings.ShowModelErrors = true;
        editorSettings.Width = Unit.Percentage(100);

        return mvCxFormLayoutItem;
        //return itemSettings => {
        //    itemSettings.Width = Unit.Percentage(100);
        //    dynamic editorSettings = itemSettings.NestedExtensionSettings;
        //    editorSettings.Properties.ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.ImageWithText;
        //    editorSettings.Properties.ValidationSettings.ErrorTextPosition = ErrorTextPosition.Bottom;
        //    editorSettings.Properties.ValidationSettings.Display = Display.Dynamic;
        //    editorSettings.ShowModelErrors = true;
        //    editorSettings.Width = Unit.Percentage(100);
        //};
    }
}