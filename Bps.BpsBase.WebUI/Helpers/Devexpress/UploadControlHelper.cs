using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.Core.Response;
using Bps.Core.Web.Session;
using DevExpress.Web;
using DevExpress.Web.Demos.Common;
using DevExpress.Web.Internal;
using Exception = System.Exception;

namespace Bps.BpsBase.WebUI.Helpers.Devexpress
{
    public class UploadControlHelper
    {
        private static readonly IGnfileService _gnfileService = InstanceFactory.GetInstance<IGnfileService>();

        public const string TempDirectory = "~/Assets/UploadFolder/Temp/";
        public const string UploadedDirectory = "~/Assets/UploadFolder/";

        public static readonly UploadControlValidationSettings UploadValidationSettings = new UploadControlValidationSettings
        {
            AllowedFileExtensions = new string[] { ".jpg", ".jpeg", ".gif", ".png" },
            MaxFileSize = 4194304
        };

        public static void ucTopluAktarim_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            var type = HttpContext.Current.Request.Params["type"];
            IUrlResolutionService urlResolver = sender as IUrlResolutionService;
            if (urlResolver != null)
            {
                var response = TopluAktar(sender, e, type);
                e.CallbackData = ((int)response.Status) + "/" + response.Message;
            }
        }
        public static void ucDragAndDrop_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            if (e.UploadedFile.IsValid)
            {
                var width = HttpContext.Current.Request.Params["width"] ?? "300";
                var height = HttpContext.Current.Request.Params["height"] ?? "300";
                string fileName = Path.ChangeExtension(Path.GetRandomFileName(), ".jpg");
                string resultFilePath = TempDirectory + fileName;
                using (Image original = Image.FromStream(e.UploadedFile.FileContent))
                using (Image thumbnail = new ImageThumbnailCreator(original).CreateImageThumbnail(new Size(Convert.ToInt32(width), Convert.ToInt32(height))))
                    ImageUtils.SaveToJpeg(thumbnail, HttpContext.Current.Request.MapPath(resultFilePath));
                UploadingUtils.RemoveFileWithDelay(fileName, HttpContext.Current.Request.MapPath(resultFilePath), 5);
                IUrlResolutionService urlResolver = sender as IUrlResolutionService;
                if (urlResolver != null)
                    e.CallbackData = "../" + urlResolver.ResolveClientUrl(resultFilePath);
            }
        }

        public static void ucMultiSelection_FileUploadComplete(object sender, FileUploadCompleteEventArgs e)
        {
            if (e.UploadedFile.IsValid)
            {
                var width = HttpContext.Current.Request.Params["width"] ?? "300";
                var height = HttpContext.Current.Request.Params["height"] ?? "300";
                var key = HttpContext.Current.Request.Params["Key"] ?? "";
                string resultFileName = key + "---" + e.UploadedFile.FileName;
                string resultFilePath = TempDirectory + resultFileName;

                using (Image original = Image.FromStream(e.UploadedFile.FileContent))
                using (Image thumbnail = new ImageThumbnailCreator(original).CreateImageThumbnail(new Size(350, 350)))
                    ImageUtils.SaveToJpeg(thumbnail, HttpContext.Current.Request.MapPath(resultFilePath));
                UploadingUtils.RemoveFileWithDelay(resultFileName, HttpContext.Current.Request.MapPath(resultFilePath), 5);

                IUrlResolutionService urlResolver = sender as IUrlResolutionService;
                if (urlResolver != null)
                {
                    string url = urlResolver.ResolveClientUrl(resultFilePath);
                    e.CallbackData = GetCallbackData(e.UploadedFile, url);
                }
            }
        }

        static string GetCallbackData(UploadedFile uploadedFile, string fileUrl)
        {
            string name = uploadedFile.FileName;
            long sizeInKilobytes = uploadedFile.ContentLength / 1024;
            string sizeText = sizeInKilobytes.ToString() + " KB";

            return name + "|" + "../" + fileUrl + "|" + sizeText;
        }

        static StandardResponse TopluAktar(object sender, FileUploadCompleteEventArgs e, string type)
        {
            var response = new StandardResponse();
            string fileName = e.UploadedFile.FileName;
            var strFileName = string.Concat(fileName.Split(' '));
            string name = SessionHelper.UserKod + "-" + Guid.NewGuid().ToString("N") + "-" + strFileName;
            //string path = HttpContext.Current.Request.MapPath("~/Assets/ExcelTopluAktarim/") + name;
            byte[] fileData = e.UploadedFile.FileBytes;
            response = _gnfileService.GridTopluAktar(fileData, name, type, SessionHelper.ConvertSessiontoGlobal());
            return response;
        }

        public static StandardResponse DeleteTempFile(string key, string fileName)
        {
            var sonuc = new StandardResponse();
            if (string.IsNullOrEmpty(key) || string.IsNullOrEmpty(fileName))
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
                sonuc.Message = "Gerekli bilgiler okunamadi!";
                return sonuc;
            }
            try
            {
                string tempPath = HttpContext.Current.Request.MapPath(fileName);
                var fileExist = File.Exists(tempPath);
                if (fileExist)
                {
                    File.Delete(HttpContext.Current.Server.MapPath(fileName));
                }
                else
                {
                    sonuc.Status = ResponseStatusEnum.ERROR;
                    sonuc.Message = "Dosya bulunamadı!";
                    return sonuc;
                }

                sonuc.Status = ResponseStatusEnum.OK;
            }
            catch (Exception e)
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
                sonuc.Message = e.Message;
            }

            return sonuc;
        }

        public static List<ImageGaleryModel> GetImagesTemp(string key, bool firstAdd)
        {

            var list = new List<ImageGaleryModel>();

            string tempPath = HttpContext.Current.Request.MapPath(TempDirectory);
            string[] images = Directory.GetFiles(tempPath, (key + "*"))
                .Select(Path.GetFileName)
                .ToArray();

            if (images.Length > 0)
            {
                foreach (var image in images)
                {
                    if (File.Exists(tempPath + "\\" + image))
                    {
                        var byteArray = File.ReadAllBytes(tempPath + "\\" + image);
                        long sizeInKilobytes = byteArray.Length / 1024;
                        string sizeText = sizeInKilobytes.ToString() + " KB";
                        var model = new ImageGaleryModel();
                        model.GNDOSY = byteArray;
                        model.FLNAME = image;
                        model.GNSIZE = sizeText;
                        model.GNPATH = "~/Assets/UploadFolder/Temp/" + image;
                        list.Add(model);
                    }
                }
            }

            return list;
        }

        public static List<ImageGaleryModel> GetImages(string key)
        {
            var list = new List<ImageGaleryModel>();
            if (string.IsNullOrEmpty(key))
            {
                return list;
            }
            var global = SessionHelper.ConvertSessiontoGlobal();
            var splitedKey = key.Split(new string[] { "---" }, StringSplitOptions.None);
            var tableName = splitedKey[0];
            var tableId = splitedKey[1];
            var intTableId = Convert.ToInt32(tableId);
            try
            {
                var responseGnFile = _gnfileService.Cch_GetListByTableId_NLog(global, tableName, intTableId);
                if (responseGnFile.Status == ResponseStatusEnum.OK && responseGnFile.Items.Count > 0)
                {
                    foreach (var item in responseGnFile.Items)
                    {
                        var resimMi = false;
                        var allowedFileExtensions = UploadControlHelper.UploadValidationSettings.AllowedFileExtensions;
                        foreach (string ext in allowedFileExtensions)
                        {
                            if (item.FLNAME.Contains(ext))
                            {
                                resimMi = true;
                                break;
                            }
                        }

                        if (resimMi == false)
                        {
                            continue;
                        }
                        if (item.FLTYPE == 0)
                        {
                            string path = HttpContext.Current.Server.MapPath(item.GNPATH);
                            if (File.Exists(path))
                            {
                                var byteArray = File.ReadAllBytes(path);
                                long sizeInKilobytes = byteArray.Length / 1024;
                                string sizeText = sizeInKilobytes.ToString() + " KB";
                                var model = new ImageGaleryModel();
                                model.GNDOSY = byteArray;
                                model.FLNAME = item.FLNAME;
                                model.GNSIZE = sizeText;
                                model.GNPATH = "~/Assets/UploadFolder/" + tableName + "/" + item.FLNAME;
                                list.Add(model);
                            }
                        }
                        else
                        {
                            var model = new ImageGaleryModel();
                            var byteArray = item.GNDOSY;
                            long sizeInKilobytes = byteArray.Length / 1024;
                            string sizeText = sizeInKilobytes.ToString() + " KB";
                            model.GNDOSY = item.GNDOSY;
                            model.FLNAME = item.FLNAME;
                            model.GNSIZE = sizeText;
                            model.GNPATH = "";
                            list.Add(model);
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            return list;
        }
    }
}