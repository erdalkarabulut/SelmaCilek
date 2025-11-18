using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using DevExpress.Utils.Helpers;
using DevExpress.Web.Demos.DataModels.MVC.DataProviders;
using DevExpress.XtraBars;
using DevExpress.XtraEditors;
using DevExpress.XtraGrid.Views.WinExplorer;

namespace BPS.Windows.Forms
{
    public partial class FrmFileManager : XtraForm, IFileSystemNavigationSupports
    {
        public Global global;
        public string tableName;
        public int tableId;
        public string UploadDirectory = "";
        public string TempPath = "";

        public static IGnfileService _gnfileService;
        public FrmFileManager(Global _global, string _tableName, int? _tableId)
        {
            InitializeComponent();
            global = _global;
            tableName = _tableName;
            tableId = _tableId ?? 0;
            _gnfileService = InstanceFactory.GetInstance<IGnfileService>();
            UploadDirectory = AppDomain.CurrentDomain.BaseDirectory + "UploadFolder";
            TempPath = AppDomain.CurrentDomain.BaseDirectory + "UploadFolder\\Temp";
            DirectoryControl(UploadDirectory);
            DirectoryControl(TempPath);
            ReadFiles();
        }
        void DirectoryControl(string _FilePath)
        {
            if (!Directory.Exists(_FilePath))
            {

                Directory.CreateDirectory(_FilePath);

            }
        }
        void ReadFiles()
        {
            Cursor oldCursor = Cursor.Current;
            Cursor.Current = Cursors.WaitCursor;
            try
            {
                List<ArtsFileSystemItem> arts = new List<ArtsFileSystemItem>();
                var responseGnFile = _gnfileService.Cch_GetListByTableId_NLog(global, tableName, tableId);
                foreach (var item in responseGnFile.Items)
                {
                    if (item.FLTYPE == 0)
                    {
                        FileStream stream = File.OpenRead(UploadDirectory + "\\" + tableName + "\\" + item.FLNAME);
                        byte[] fileBytes = new byte[stream.Length];
                        stream.Read(fileBytes, 0, fileBytes.Length);
                        stream.Close();

                        if (true)
                        {
                            var model = new ArtsFileSystemItem()
                            {
                                ParentID = 1,
                                Name = item.FLNAME,
                                IsFolder = false,
                                Data = fileBytes,
                                LastWriteTime = item.ETARIH
                            };
                            arts.Add(model);
                        }
                    }
                    else
                    {
                        var byteArray = item.GNDOSY;
                        var model = new ArtsFileSystemItem()
                        {
                            ParentID = 1,
                            Name = item.FLNAME,
                            IsFolder = false,
                            Data = byteArray,
                            LastWriteTime = item.ETARIH
                        };
                        arts.Add(model);
                    }
                }

                DirectoryInfo directoryInfo = new DirectoryInfo(TempPath);
                foreach (var fileInfo in directoryInfo.GetFiles())
                    fileInfo.Delete();
                foreach (var art in arts)
                {
                    File.WriteAllBytes(TempPath + "\\" + art.Name, art.Data);
                }

                gridControl.DataSource =
                    FileSystemHelper.GetFileSystemEntries(TempPath, GetItemSizeType(ViewStyle), GetItemSize(ViewStyle));
            }
            finally
            {
                Cursor.Current = oldCursor;
            }
        }

        private void barButtonItem1_ItemClick(object sender, ItemClickEventArgs e)
        {
            AddFile();
        }

        private void barButtonItem2_ItemClick(object sender, ItemClickEventArgs e)
        {
            int[] rows = winExplorerView.GetSelectedRows();
            if (rows.Length < 1)
            {
                MessageBox.Show("lütfen dosya seçiniz!", "Uyarı", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            string fileName = "";
            for (int i = 0; i < rows.Length; i++)
            {
                var fileSystemEntry = (FileSystemEntry) winExplorerView.GetRow(rows[i]);
                if (fileSystemEntry != null)
                {
                    var aranan = fileSystemEntry.Name;
                    var _fileName = fileSystemEntry.Path;
                   
                    int index = _fileName.IndexOf(aranan);
                    if (index != -1) // Eğer kelime bulunduysa
                    {
                        fileName = _fileName.Substring(index);
                        
                    }
                    var response = _gnfileService.Ncch_GetByFileName_NLog(tableName, tableId, fileName, global);
                    if (response.Status != ResponseStatusEnum.OK || response.Nesne == null)
                    {
                        MessageBox.Show(fileName + " " + " dosya bilgisi okunamadı!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    var responseDelete = _gnfileService.Ncch_DeleteFull_Log(response.Nesne, global);
                    if (responseDelete.Status != ResponseStatusEnum.OK)
                    {
                        MessageBox.Show(responseDelete.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }
            }

            ReadFiles();
        }

        public void AddFile()
        {
            string fileName = "";
            OpenFileDialog fdlg = new OpenFileDialog();
            fdlg.Title = "Dosya seç";
            fdlg.Filter = "Tüm Dosyalar(*.*)|*.*";
            fdlg.FilterIndex = 1;
            fdlg.RestoreDirectory = false;
            if (fdlg.ShowDialog() == DialogResult.OK) fileName = fdlg.FileName;

            if (fileName != "")
            {
                try
                {
                    FileStream fs = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                    byte[] fileBytes = new byte[fs.Length];

                    fs.Read(fileBytes, 0, fileBytes.Length);
                    fs.Close();

                    var model = new GNFILE();
                    model.GNDOSY = fileBytes;
                    model.FLNAME = tableId + "---" + Path.GetFileName(fdlg.FileName);
                    model.TABLNM = tableName;
                    model.TABLID = tableId;
                    model.FLTYPE = 1;
                    model.DEFAUL = false;
                    model.ACTIVE = true;
                    var response = _gnfileService.Ncch_Save_NLog(model, global);

                    if (response.Status != ResponseStatusEnum.OK)
                    {
                        MessageBox.Show(response.Message, "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    ReadFiles();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }

        Size GetItemSize(WinExplorerViewStyle viewStyle)
        {
            switch (viewStyle)
            {
                case WinExplorerViewStyle.ExtraLarge: return new Size(256, 256);
                case WinExplorerViewStyle.Large: return new Size(96, 96);
                case WinExplorerViewStyle.Content: return new Size(32, 32);
                case WinExplorerViewStyle.Small: return new Size(16, 16);
                default: return new Size(96, 96);
            }
        }
        IconSizeType GetItemSizeType(WinExplorerViewStyle viewStyle)
        {
            switch (viewStyle)
            {
                case WinExplorerViewStyle.Large:
                case WinExplorerViewStyle.ExtraLarge: return IconSizeType.ExtraLarge;
                case WinExplorerViewStyle.List:
                case WinExplorerViewStyle.Small: return IconSizeType.Small;
                case WinExplorerViewStyle.Tiles:
                case WinExplorerViewStyle.Medium:
                case WinExplorerViewStyle.Content: return IconSizeType.Large;
                default: return IconSizeType.ExtraLarge;
            }
        }
        public WinExplorerViewStyle ViewStyle { get { return this.winExplorerView.OptionsView.Style; } }

        void OnWinExplorerViewItemClick(object sender, WinExplorerViewItemClickEventArgs e)
        {
            if (e.MouseInfo.Button == MouseButtons.Right) itemPopupMenu.ShowPopup(Cursor.Position);
        }

        void OnWinExplorerViewItemDoubleClick(object sender, WinExplorerViewItemDoubleClickEventArgs e)
        {
            if (e.MouseInfo.Button != MouseButtons.Left) return;
            winExplorerView.ClearSelection();
            ((FileSystemEntry)e.ItemInfo.Row.RowKey).DoAction(this);
        }

        void OnWinExplorerViewKeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) return;
            FileSystemEntry entry = GetSelectedEntries().LastOrDefault();
            if (entry != null) entry.DoAction(this);
        }

        List<FileSystemEntry> GetSelectedEntries() { return GetSelectedEntries(false); }

        List<FileSystemEntry> GetSelectedEntries(bool sort)
        {
            List<FileSystemEntry> list = new List<FileSystemEntry>();
            int[] rows = winExplorerView.GetSelectedRows();
            for (int i = 0; i < rows.Length; i++)
            {
                list.Add((FileSystemEntry)winExplorerView.GetRow(rows[i]));
            }
            if (sort) list.Sort(new FileSytemEntryComparer());
            return list;
        }

        public void UpdatePath(string path)
        {
            throw new NotImplementedException();
        }

        public string CurrentPath { get; }
    }
}