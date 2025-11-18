using DevExpress.Web;

namespace Bps.BpsBase.WebUI.Helpers.Devexpress
{
    public class FileManagerHelper
    {
        static ArtsFileSystemProvider artsFileSystemProvider;

        public static readonly string[] AllowedFileExtensions = new string[] {
            ".jpg", ".jpeg", ".gif", ".rtf", ".txt", ".avi", ".png", ".mp3", ".xml", ".doc", ".pdf", ".xls", ".xlsx"
        };

        public static DevExpress.Web.Mvc.FileManagerSettings CreateFileManagerDownloadSettings()
        {
            var a = new FileManagerSettingsEditing(null)
            {
                AllowCreate = false,
                AllowMove = false,
                AllowDelete = true,
                AllowRename = false,
                AllowCopy = false,
                AllowDownload = true
            };
            return CreateFileManagerDownloadSettingsCore(a);
        }

        static DevExpress.Web.Mvc.FileManagerSettings CreateFileManagerDownloadSettingsCore(FileManagerSettingsEditing editingSettings)
        {
            var settings = new DevExpress.Web.Mvc.FileManagerSettings();
            settings.SettingsEditing.Assign(editingSettings);
            settings.Name = "fileManager";
            return settings;
        }

        public static ArtsFileSystemProvider ArtsFileSystemProvider(string tableName, int tableId)
        {
            //if (artsFileSystemProvider == null)
                artsFileSystemProvider = new ArtsFileSystemProvider(string.Empty, tableName, tableId);
            return artsFileSystemProvider;
        }
    }
}