using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Helpers;
using System.Web.SessionState;
using System.Web.UI.WebControls;
using Bps.BpsBase.Entities.Models.GN.Single;
using Bps.Core.Web.Model;
using Bps.Core.Web.Model.Devexpress;
using Bps.Core.Web.Session;
using DevExpress.Export;
using DevExpress.Utils;
using DevExpress.Web;
using DevExpress.Web.Mvc;
using Newtonsoft.Json;

public static class GridViewHelper<T> where T : class, new()
{
    private static HttpSessionState Session => HttpContext.Current.Session;

    public static GridViewSettings<T> Settings(GridViewSettings<T> settings, T entity,
        List<string> excluldecoList = null)
    {
        settings.Width = Unit.Percentage(100);
        settings.Styles.Header.Wrap = DefaultBoolean.True;

        string ara;
        if (excluldecoList == null) excluldecoList = new List<string>();
        excluldecoList.Add("KYNKKD");
        excluldecoList.Add("ACTIVE");
        excluldecoList.Add("SIRKID");
        excluldecoList.Add("SLINDI");

        foreach (var propertyInfo in entity.GetType().GetProperties())
        {
            if (propertyInfo.DeclaringType != null)
            {
                var visible = true;
                ara = excluldecoList.Find(s => s == propertyInfo.Name);
                if (ara != null) continue;
                settings.Columns.Add(column =>
                {
                    column.FieldName = propertyInfo.Name;
                    if (propertyInfo.PropertyType.GenericTypeArguments.Length > 0)
                    {
                        if (propertyInfo.PropertyType.GenericTypeArguments[0].Name == "Boolean")
                        {
                            column.ColumnType = MVCxGridViewColumnType.CheckBox;
                            column.CellStyle.HorizontalAlign = HorizontalAlign.Center;
                        }
                        else if (propertyInfo.PropertyType.GenericTypeArguments[0].Name == "DateTime")
                        {
                            column.ColumnType = MVCxGridViewColumnType.DateEdit;
                            column.CellStyle.HorizontalAlign = HorizontalAlign.Center;
                            column.PropertiesEdit.DisplayFormatString = "dd/MM/yyyy";
                        }
                    }
                    else
                    {
                        if (propertyInfo.Name == "Id") visible = false;
                        else if (propertyInfo.PropertyType.Name == "Boolean")
                        {
                            column.ColumnType = MVCxGridViewColumnType.CheckBox;
                            column.CellStyle.HorizontalAlign = HorizontalAlign.Center;
                        }
                        else if (propertyInfo.PropertyType.Name == "DateTime")
                        {
                            column.ColumnType = MVCxGridViewColumnType.DateEdit;
                            column.CellStyle.HorizontalAlign = HorizontalAlign.Center;
                        }
                    }

                    column.Visible = visible;
                });
            }
        }

        settings.SettingsBehavior.AllowSelectSingleRowOnly = true;
        settings.SettingsBehavior.AllowSelectByRowClick = true;

        settings.SettingsResizing.ColumnResizeMode = ColumnResizeMode.Control;
        settings.SettingsResizing.Visualization = ResizingMode.Postponed;

        settings.CommandColumn.Visible = true;
        settings.CommandColumn.Name = "CommandColumn";
        settings.CommandColumn.ShowSelectCheckbox = true;
        settings.CommandColumn.Width = 30;
        settings.CommandColumn.MaxWidth = 30;
        settings.CommandColumn.MinWidth = 30;

        settings.Settings.VerticalScrollBarMode = ScrollBarMode.Auto;
        settings.Settings.VerticalScrollableHeight = 1000;
        settings.Settings.HorizontalScrollBarMode = ScrollBarMode.Auto;
        settings.Settings.ShowFilterRowMenu = true;
        settings.Settings.ShowFilterRow = true;

        settings.SettingsCustomizationDialog.Enabled = true;

        settings.SettingsCookies.Enabled = false;

        settings.SettingsPager.PageSize = 50;
        settings.SettingsPager.PageSizeItemSettings.Visible = true;
        settings.SettingsPager.PageSizeItemSettings.Items = new[] { "10", "50", "100" };
        settings.SettingsPager.Mode = GridViewPagerMode.ShowPager;

        settings.SettingsExport.EnableClientSideExportAPI = true;
        settings.SettingsExport.ExcelExportMode = ExportType.DataAware;

        settings.ClientSideEvents.ColumnResized = "function(s, e) { s.PerformCallback(); }";

        foreach (MVCxGridViewColumn column in settings.Columns)
        {
            column.MinWidth = 100;
            column.MaxWidth = 1500;
            column.Width = Unit.Percentage(100);
        }

        settings.ClientLayout = (s, e) =>
        {
            var datas = GetLayoutDatas(settings.Name);
            if (e.LayoutMode == ClientLayoutMode.Loading)
            {
                if (datas.LayoutData != null)
                    e.LayoutData = datas.LayoutData;
                else
                {
                    if (datas.DefaultLayoutData != null)
                    {
                        e.LayoutData = datas.DefaultLayoutData;
                    }
                }
            }
            else
            {
                Session[SessionHelper.UserKod + settings.Name] = e.LayoutData;
            }
        };

        return settings;
    }

    public static GridViewSettings<T> SettingsNew(GridViewSettings<T> settings)
    {
        settings.Width = Unit.Percentage(100);
        settings.Styles.Header.Wrap = DefaultBoolean.True;

        settings.SettingsBehavior.AllowSelectSingleRowOnly = true;
        settings.SettingsBehavior.AllowSelectByRowClick = true;

        //settings.SettingsResizing.ColumnResizeMode = ColumnResizeMode.NextColumn;
        //settings.SettingsResizing.Visualization = ResizingMode.Live;

        settings.CommandColumn.Visible = true;
        settings.CommandColumn.Name = "CommandColumn";
        settings.CommandColumn.ShowSelectCheckbox = true;
        settings.CommandColumn.Width = 30;
        settings.CommandColumn.MaxWidth = 30;
        settings.CommandColumn.MinWidth = 30;

        settings.Settings.VerticalScrollBarMode = ScrollBarMode.Auto;
        settings.Settings.VerticalScrollableHeight = 1000;
        settings.Settings.ShowFilterRowMenu = true;
        settings.Settings.ShowFilterRow = true;

        settings.SettingsCustomizationDialog.Enabled = true;
        settings.SettingsCookies.Enabled = false;

        settings.SettingsPager.PageSize = 50;
        settings.SettingsPager.PageSizeItemSettings.Visible = true;
        settings.SettingsPager.PageSizeItemSettings.Items = new[] { "10", "30", "50", "100" };
        settings.SettingsPager.Mode = GridViewPagerMode.ShowPager;

        settings.SettingsExport.EnableClientSideExportAPI = true;
        settings.SettingsExport.ExcelExportMode = ExportType.DataAware;

        settings.ClientSideEvents.ColumnResized = "function(s, e) { s.PerformCallback(); }";

        settings.ClientLayout = (s, e) =>
        {
            var datas = GetLayoutDatas(settings.Name);
            if (e.LayoutMode == ClientLayoutMode.Loading)
            {
                if (datas.LayoutData != null)
                    e.LayoutData = datas.LayoutData;
                else
                {
                    if (datas.DefaultLayoutData != null)
                    {
                        e.LayoutData = datas.DefaultLayoutData;
                    }
                }
            }
            else
            {
                Session[SessionHelper.UserKod + settings.Name] = e.LayoutData;
            }
        };

        settings.SettingsAdaptivity.AdaptiveDetailColumnCount = 2;
        settings.SettingsAdaptivity.AdaptivityMode = GridViewAdaptivityMode.HideDataCellsWindowLimit;
        settings.SettingsAdaptivity.HideDataCellsAtWindowInnerWidth = 780;
        settings.SettingsAdaptivity.AllowOnlyOneAdaptiveDetailExpanded = true;
        settings.EditFormLayoutProperties.SettingsAdaptivity.AdaptivityMode = FormLayoutAdaptivityMode.SingleColumnWindowLimit;
        settings.EditFormLayoutProperties.SettingsAdaptivity.SwitchToSingleColumnAtWindowInnerWidth = 600;

        foreach (MVCxGridViewColumn column in settings.Columns)
        {
            column.MinWidth = 100;
            column.MaxWidth = 250;
        }

        return settings;
    }

    public static GridViewSettings<T> SettingsBatch(GridViewSettings<T> settings, BatchEditParamModel param = null)
    {
        settings.Width = Unit.Percentage(100);
        settings.Styles.Header.Wrap = DefaultBoolean.False;

        settings.Settings.ShowTitlePanel = true;
        settings.Width = Unit.Percentage(100);
        settings.Height = Unit.Percentage(100);

        settings.Settings.GridLines = GridLines.Both;
        settings.SettingsResizing.ColumnResizeMode = ColumnResizeMode.Disabled;
        settings.Settings.ShowFilterRow = false;
        settings.Settings.ShowHeaderFilterButton = false;
        //settings.SettingsBehavior.AllowDragDrop = false;
        settings.SettingsBehavior.AllowGroup = false;
        settings.SettingsBehavior.AllowSort = false;
        settings.SettingsBehavior.AllowAutoFilter = false;
        settings.SettingsBehavior.AllowSelectSingleRowOnly = true;
        settings.SettingsBehavior.AllowFocusedRow = false;
        settings.SettingsBehavior.AllowSelectByRowClick = true;


        settings.SettingsAdaptivity.AdaptivityMode = GridViewAdaptivityMode.Off;
        settings.SettingsEditing.Mode = GridViewEditingMode.Batch;
        settings.SettingsEditing.BatchEditSettings.StartEditAction = GridViewBatchStartEditAction.Click;
        //settings.SettingsEditing.BatchEditSettings.EditMode = GridViewBatchEditMode.Cell;
        //settings.SettingsEditing.BatchEditSettings.StartEditAction = GridViewBatchStartEditAction.DblClick;
        settings.SettingsEditing.BatchEditSettings.HighlightDeletedRows = false;
        settings.SettingsEditing.BatchEditSettings.KeepChangesOnCallbacks = DefaultBoolean.False;

        settings.SettingsResizing.ColumnResizeMode = ColumnResizeMode.Control;

        settings.Settings.VerticalScrollBarMode = ScrollBarMode.Auto;
        settings.Settings.HorizontalScrollBarMode = ScrollBarMode.Auto;
        settings.Settings.VerticalScrollableHeight = 300;

        settings.CommandColumn.Visible = false;
        settings.CommandColumn.Width = Unit.Pixel(100);
        settings.CommandColumn.ShowSelectCheckbox = false;
        settings.CommandColumn.ShowCancelButton = false;
        settings.CommandColumn.ShowDeleteButton = false;
        settings.CommandColumn.ShowNewButtonInHeader = false;
        settings.CommandButtonInitialize = (sender, e) =>
        {
            if (e.ButtonType == ColumnCommandButtonType.Update)
                e.Visible = false;
        };

        settings.SettingsEditing.NewItemRowPosition = GridViewNewItemRowPosition.Bottom;
        
        settings.ClientSideEvents.Init = "function(s, e){scriptToolbarBatch.OnInit(s, e, " + Json.Encode(param) + "); }";
        settings.ClientSideEvents.BatchEditStartEditing = "function(s, e){scriptToolbarBatch.OnStartEditCell(s,e);}";
        settings.ClientSideEvents.BatchEditEndEditing = "function(s, e){scriptToolbarBatch.OnEndEditCell(s,e);}";
        settings.ClientSideEvents.SelectionChanged = "function(s, e){scriptToolbarBatch.OnSelectionChanged(s,e);}";

        settings.SettingsPager.Mode = GridViewPagerMode.ShowAllRecords;
        settings.CellEditorInitialize = (s, e) =>
        {
            ((ASPxEdit)e.Editor).ValidationSettings.Display = Display.Dynamic;
            ((ASPxEdit)e.Editor).ValidationSettings.ErrorDisplayMode = ErrorDisplayMode.None;
            ((ASPxEdit)e.Editor).ValidationSettings.ErrorTextPosition = ErrorTextPosition.Right;
            ((ASPxEdit)e.Editor).ValidationSettings.CausesValidation = true;
        };

        return settings;
    }

    public static UserLayoutDatas GetLayoutDatas(string gridName)
    {
        var model = new UserLayoutDatas();
        string pathDefault = HttpContext.Current.Server.MapPath("~\\DefGridLayout\\" + "_Default" + gridName + ".json");
        string pathGridLayout = HttpContext.Current.Server.MapPath("~\\KulGridLayout\\" + SessionHelper.UserKod + ".json");

        if (File.Exists(pathDefault))
        {
            var json = File.ReadAllText(pathDefault);
            List<GridLayoutModel> list = JsonConvert.DeserializeObject<List<GridLayoutModel>>(json);

            if (list != null && list.Count > 0)
            {
                var layoutData = list.FirstOrDefault(f => f.Active && f.Grid == gridName);
                if (layoutData != null)
                {
                    model.DefaultLayoutData = layoutData.LayoutData;
                }
                else
                    model.DefaultLayoutData = null;
            }
            else
            {
                model.DefaultLayoutData = null;
            }
        }
        else
        {
            model.DefaultLayoutData = null;
        }

        if (File.Exists(pathGridLayout))
        {
            var json = File.ReadAllText(pathGridLayout);
            List<GridLayoutModel> listLayout = JsonConvert.DeserializeObject<List<GridLayoutModel>>(json);

            if (listLayout != null && listLayout.Count > 0)
            {
                var layoutData = listLayout.FirstOrDefault(f => f.Active && f.Grid == gridName);
                if (layoutData != null)
                {
                    model.LayoutData = layoutData.LayoutData;
                }
                else
                    model.LayoutData = null;
            }
            else
            {
                model.LayoutData = null;
            }
        }
        else
        {
            model.LayoutData = null;
        }

        return model;
    }

}