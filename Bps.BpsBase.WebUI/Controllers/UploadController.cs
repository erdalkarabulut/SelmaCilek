using System;
using System.Collections.Generic;
using System.Drawing;
using System.Web.Mvc;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.BpsBase.WebUI.Helpers.Devexpress;
using Bps.Core.Response;
using Bps.Core.Web.Controller;
using Bps.Core.Web.Session;
using DevExpress.Web;
using DevExpress.Web.Mvc;

namespace Bps.BpsBase.WebUI.Controllers
{
    public class MultiFileSelectionDemoBinder : DevExpressEditorsBinder
    {
        public MultiFileSelectionDemoBinder()
        {
            UploadControlBinderSettings.FileUploadCompleteHandler = UploadControlHelper.ucTopluAktarim_FileUploadComplete;
        }
    }

    public class MultiFileSelectionBinder : DevExpressEditorsBinder
    {
        public MultiFileSelectionBinder()
        {
            UploadControlBinderSettings.ValidationSettings.Assign(UploadControlHelper.UploadValidationSettings);
            UploadControlBinderSettings.FileUploadCompleteHandler = UploadControlHelper.ucMultiSelection_FileUploadComplete;
        }
    }

    public class DragAndDropSupportDemoBinder : DevExpressEditorsBinder
    {
        public DragAndDropSupportDemoBinder()
        {
            UploadControlBinderSettings.ValidationSettings.Assign(UploadControlHelper.UploadValidationSettings);
            UploadControlBinderSettings.FileUploadCompleteHandler = UploadControlHelper.ucDragAndDrop_FileUploadComplete;
        }
    }


    public class UploadController : SecureController
    {
        private readonly IGnfileService _gnfileService = InstanceFactory.GetInstance<IGnfileService>();

        public ActionResult UploadPartial(string tableName, int? tableId, Size size, bool isUpEnable = true)
        {
            var global = SessionHelper.ConvertSessiontoGlobal();
            var sonuc = _gnfileService.Cch_GetDefaultFile_NLog(global, tableName, tableId.Value);
            ViewData["UploadSize"] = size;
            ViewData["isUpEnable"] = isUpEnable;
            return PartialView("Templates/UploadPartial", sonuc.Nesne ?? new GNFILE());
        }

        public ActionResult UploadMultiFilesPartial(string key, Size size, bool useExtendedPopup, bool firstAdd = false)
        {
            ViewData["UseExtendedPopup"] = useExtendedPopup;
            ViewData["Key"] = key;
            ViewData["FirstAdd"] = firstAdd;
            var global = SessionHelper.ConvertSessiontoGlobal();
            var sonuc = new StandardResponse<GNFILE>();
            if (firstAdd == false)
            {
                var keySplited = key.Split(new string[] { "---" }, StringSplitOptions.None);
                var tableName = keySplited[0];
                var tableId = keySplited[1];
                sonuc = _gnfileService.Cch_GetDefaultFile_NLog(global, tableName, Convert.ToInt32(tableId));
            }
            ViewData["UploadSize"] = size;
            return PartialView("Templates/UploadMultiFilesPartial", sonuc.Nesne ?? new GNFILE());
        }

        public ActionResult UploadFilesContainerPartial(string key)
        {
            ViewData["Key"] = key ?? "";
            var files = UploadControlHelper.GetImagesTemp(key, true);
            return PartialView("Templates/UploadFilesContainerPartial", files);
        }

        public ActionResult DeleteTempFile(string key, string fileName)
        {
            ViewData["Key"] = key ?? "";
            var sonuc = UploadControlHelper.DeleteTempFile(key, fileName);
            return Json(sonuc);
        }

        public ActionResult ImageGaleryPartial(string key, bool firstAdd)

        {
            ViewData["Key"] = key;
            ViewData["FirstAdd"] = firstAdd;
            var images = UploadControlHelper.GetImages(key);
            return PartialView("ImageGaleryPartial", images);
        }

        public ActionResult FileManagerPartial(string tableName, int? tableId, bool enable = true)
        {
            ViewData["TableName"] = tableName ?? "";
            ViewData["TableId"] = tableId ?? 0;
            ViewData["Enable"] = enable;
            return PartialView("FileManagerPartial", FileManagerHelper.ArtsFileSystemProvider(tableName, tableId ?? 0));
        }

        public FileStreamResult DownloadFiles(string tableName)
        {
            try
            {
                var settings = FileManagerHelper.CreateFileManagerDownloadSettings();
                return FileManagerExtension.DownloadFiles(settings, "~/Assets/UploadFolder/" + tableName);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public ActionResult FileManagerKaydet(string tableName, int? tableId)
        {
            var sonuc = _gnfileService.Ncch_SaveFileManager_Log(tableName, tableId,
                SessionHelper.ConvertSessiontoGlobal());
            return Json(sonuc);
        }

        public ActionResult TopluAktarWindow(string type, string gridId)
        {
            ViewData["gridId"] = gridId;
            return PartialView("TopluAktarWindow", type);
        }

        public ActionResult TopluAktar([ModelBinder(typeof(MultiFileSelectionDemoBinder))]IEnumerable<UploadedFile> ucTopluAktarim, string type)
        {
            //ModelBinders.Binders.Add(typeof(IEnumerable<UploadedFile>) , new MultiFileSelectionDemoBinder());
            return null;
        }

        public ActionResult DragAndDropImageUpload([ModelBinder(typeof(DragAndDropSupportDemoBinder))]IEnumerable<UploadedFile> ucDragAndDrop)
        {
            return null;
        }

        public ActionResult MultiSelectionUpload([ModelBinder(typeof(MultiFileSelectionBinder))]IEnumerable<UploadedFile> ucMultiSelection, string tableName, int? tableId)
        {
            return null;
        }

        public ActionResult UploadedFilesContainer(bool useExtendedPopup)
        {
            ViewData["UseExtendedPopup"] = true;
            return PartialView("UploadedFilesContainer");
        }
    }
}