using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
using Bps.BpsBase.DataAccess.Abstract.GN;
using Bps.BpsBase.Entities.Concrete.GN;
using Bps.Core.Response;
using Bps.Core.Web.Session;
using ChinhDo.Transactions;
using DevExpress.Web;
using DevExpress.Web.Demos.DataModels.MVC.DataProviders;

namespace Bps.BpsBase.WebUI.Helpers.Devexpress
{
    public static class ArtsDataProvider
    {
        public const string UploadDirectory = "~/Assets/UploadFolder/";
        private static readonly IGnfileDal _gnfileDal = InstanceFactory.GetInstance<IGnfileDal>();
        private static readonly IGnfileService _gnfileService = InstanceFactory.GetInstance<IGnfileService>();
        public static List<ArtsFileSystemItem> GetArts(string tableName, int tableId)
        {
            var key = SessionHelper.UserKod + "-" + tableName + "-" + tableId;
            List<ArtsFileSystemItem> arts =
                (List<ArtsFileSystemItem>)HttpContext.Current.Session[key];
            if (arts == null)
            {
                arts = new List<ArtsFileSystemItem>();
                var global = SessionHelper.ConvertSessiontoGlobal();
                //string tempPath =
                //    "C:\\Users\\ferdem\\Desktop\\Projects\\Cilek\\Cilek.CilekBase.WebUI\\Assets\\Images\\UploadControl\\Temp";
                //string[] images = Directory.GetFiles(tempPath, (/*key + */"*"))
                //    .Select(Path.GetFileName)
                //    .ToArray();


                //var i = 2;
                //var modelR = new ArtsFileSystemItem()
                //{
                //    ArtID = 1,
                //    ParentID = -1,
                //    Name = "FikirKart",
                //    Data = null,
                //    IsFolder = true,
                //    LastWriteTime = DateTime.Now
                //};
                //arts.Add(modelR);

                //if (images.Length > 0)
                //{
                //    foreach (var image in images)
                //    {
                //        if (File.Exists(tempPath + "\\" + image))
                //        {
                //            var byteArray = File.ReadAllBytes(tempPath + "\\" + image);

                //            var model = new ArtsFileSystemItem()
                //            {
                //                ArtID = i,
                //                ParentID = 1,
                //                Name = image,
                //                IsFolder = false,
                //                Data = byteArray,
                //                LastWriteTime = DateTime.Now
                //            };
                //            arts.Add(model);
                //            i++;
                //        }
                //    }
                //}

                var responseGnFile = _gnfileService.Cch_GetListByTableId_NLog(global, tableName, Convert.ToInt32(tableId));
                var i = 2;
                var root = new ArtsFileSystemItem()
                {
                    ArtID = 1,
                    ParentID = -1,
                    Name = tableName,
                    Data = null,
                    IsFolder = true,
                    LastWriteTime = DateTime.Now
                };
                arts.Add(root);

                if (responseGnFile.Status == ResponseStatusEnum.OK && responseGnFile.Items.Count > 0)
                {
                    foreach (var item in responseGnFile.Items)
                    {
                        if (item.FLTYPE == 0)
                        {
                            var path = HttpContext.Current.Request.MapPath(
                                UploadDirectory + "/" + tableName + "/" + item.FLNAME);
                            if (File.Exists(path))
                            {
                                var byteArray = File.ReadAllBytes(path);
                                var model = new ArtsFileSystemItem()
                                {
                                    ArtID = i,
                                    ParentID = 1,
                                    Name = item.FLNAME,
                                    IsFolder = false,
                                    Data = byteArray,
                                    LastWriteTime = item.ETARIH
                                };
                                arts.Add(model);
                                i++;
                            }
                        }
                        else
                        {
                            var byteArray = item.GNDOSY;
                            var model = new ArtsFileSystemItem()
                            {
                                ArtID = i,
                                ParentID = 1,
                                Name = item.FLNAME,
                                IsFolder = false,
                                Data = byteArray,
                                LastWriteTime = item.ETARIH
                            };
                            arts.Add(model);
                            i++;
                        }
                    }
                }

                HttpContext.Current.Session[key] = arts;
            }
            return arts;
        }

        public static void InsertArt(ArtsFileSystemItem newArt, string tableName, int tableId)
        {
            try
            {
                var global = SessionHelper.ConvertSessiontoGlobal();
                var fileName = tableId + "---" + newArt.Name;
                newArt.Name = fileName;
                var gnFileModel = new GNFILE()
                {
                    TABLNM = tableName,
                    TABLID = tableId,
                    FLNAME = fileName,
                    //GNDOSY = item.Data,
                    GNDOSY = null,
                    GNPATH = "~/Assets/UploadFolder/" + tableName + "/" + fileName,
                    FLTYPE = 0,
                    DEFAUL = false,
                    SIRKID = global.SirketId.Value,
                    EKKULL = global.UserKod,
                    ETARIH = DateTime.Now,
                    KYNKKD = global.KaynakKod,
                    ACTIVE = true,
                    SLINDI = false
                };
                var sonuc = _gnfileService.Ncch_Save_NLog(gnFileModel, global);
                if (sonuc.Status == ResponseStatusEnum.OK)
                {
                    var physicalPath = HttpContext.Current.Server.MapPath("~/Assets/UploadFolder/" + tableName + "/" + fileName);
                    FileStream objfilestream = new FileStream(physicalPath, FileMode.Create, FileAccess.ReadWrite);
                    objfilestream.Write(newArt.Data, 0, newArt.Data.Length);
                    objfilestream.Close();

                    newArt.ArtID = GetNewArtID(tableName, tableId);
                    GetArts(tableName, tableId).Add(newArt);
                }
            }
            catch (Exception e)
            {
                throw new Exception("Hataaaa!");
            }
        }
        public static void DeleteArt(ArtsFileSystemItem art, string tableName, int tableId)
        {
            try
            {
                var global = SessionHelper.ConvertSessiontoGlobal();
                var file = _gnfileDal.Get(g =>
                    g.SIRKID == global.SirketId && g.TABLNM == tableName && g.TABLID == tableId &&
                    g.FLNAME == art.Name);
                if (file != null)
                {
                    TxFileManager fileMgr = new TxFileManager();
                    fileMgr.Delete(HttpContext.Current.Server.MapPath("~/Assets/UploadFolder/" + tableName + "/" + art.Name));
                    _gnfileDal.Delete(file);
                    GetArts(tableName, tableId).Remove(art);
                }
            }
            catch (Exception a)
            {
                throw new Exception("Hataaaa!");
            }
        }

        static int GetNewArtID(string tableName, int tableId)
        {
            IEnumerable<ArtsFileSystemItem> arts = GetArts(tableName, tableId);
            return (arts.Count() > 0) ? arts.Last().ArtID + 1 : 0;
        }
    }

    public class ArtsFileSystemProvider : FileSystemProviderBase
    {
        const int ArtsRootItemID = 1;
        string rootFolderDisplayName;
        string tableName;
        int tableId;
        Dictionary<int, ArtsFileSystemItem> folderCache;
        public ArtsFileSystemProvider(string rootFolder, string _tableName, int _tableId)
            : base(rootFolder)
        {
            tableName = _tableName;
            tableId = _tableId;
            RefreshFolderCache();
        }
        public override string RootFolderDisplayName { get { return rootFolderDisplayName; } }
        public Dictionary<int, ArtsFileSystemItem> FolderCache { get { return folderCache; } }
        public override IEnumerable<FileManagerFile> GetFiles(FileManagerFolder folder)
        {
            ArtsFileSystemItem artFolderItem = FindArtsFolderItem(folder);
            return from artItem in ArtsDataProvider.GetArts(tableName, tableId)
                   where !artItem.IsFolder && artItem.ParentID == artFolderItem.ArtID
                   select new FileManagerFile(this, folder, artItem.Name, artItem.ArtID.ToString());
        }
        public override IEnumerable<FileManagerFolder> GetFolders(FileManagerFolder parentFolder)
        {
            ArtsFileSystemItem artFolderItem = FindArtsFolderItem(parentFolder);
            return from artItem in FolderCache.Values
                   where artItem.IsFolder && artItem.ParentID == artFolderItem.ArtID
                   select new FileManagerFolder(this, parentFolder, artItem.Name, artItem.ArtID.ToString());
        }
        public override bool Exists(FileManagerFile file)
        {
            return FindArtsFileItem(file) != null;
        }
        public override bool Exists(FileManagerFolder folder)
        {
            return FindArtsFolderItem(folder) != null;
        }
        public override Stream ReadFile(FileManagerFile file)
        {
            return new MemoryStream(FindArtsFileItem(file).Data.ToArray());
        }
        public override DateTime GetLastWriteTime(FileManagerFile file)
        {
            var artsFileItem = FindArtsFileItem(file);
            return artsFileItem.LastWriteTime.GetValueOrDefault(DateTime.Now);
        }
        public override long GetLength(FileManagerFile file)
        {
            var artsFileItem = FindArtsFileItem(file);
            return artsFileItem.Data.Length;
        }
        public override void CreateFolder(FileManagerFolder parent, string name)
        {
            //ArtsDataProvider.InsertArt(new ArtsFileSystemItem
            //{
            //    IsFolder = true,
            //    LastWriteTime = DateTime.Now,
            //    Name = name,
            //    ParentID = FindArtsFolderItem(parent).ArtID
            //});
            RefreshFolderCache();
        }
        public override void RenameFile(FileManagerFile file, string name)
        {
            //ArtsDataProvider.UpdateArt(FindArtsFileItem(file), artItem => artItem.Name = name);
        }
        public override void RenameFolder(FileManagerFolder folder, string name)
        {
            //ArtsDataProvider.UpdateArt(FindArtsFolderItem(folder), artItem => artItem.Name = name);
            RefreshFolderCache();
        }
        public override void MoveFile(FileManagerFile file, FileManagerFolder newParentFolder)
        {
            //ArtsDataProvider.UpdateArt(FindArtsFileItem(file), artItem => artItem.ParentID = FindArtsFolderItem(newParentFolder).ArtID);
        }
        public override void MoveFolder(FileManagerFolder folder, FileManagerFolder newParentFolder)
        {
            //ArtsDataProvider.UpdateArt(FindArtsFolderItem(folder), artItem => artItem.ParentID = FindArtsFolderItem(newParentFolder).ArtID);
            RefreshFolderCache();
        }
        public override void UploadFile(FileManagerFolder folder, string fileName, Stream content)
        {
            ArtsDataProvider.InsertArt(new ArtsFileSystemItem
            {
                IsFolder = false,
                LastWriteTime = DateTime.Now,
                Name = fileName,
                ParentID = FindArtsFolderItem(folder).ArtID,
                Data = ReadAllBytes(content)
            }, tableName, tableId);
        }
        public override void DeleteFile(FileManagerFile file)
        {
            ArtsDataProvider.DeleteArt(FindArtsFileItem(file), tableName, tableId);
        }
        public override void DeleteFolder(FileManagerFolder folder)
        {
            //ArtsDataProvider.DeleteArt(FindArtsFolderItem(folder));
            RefreshFolderCache();
        }
        protected ArtsFileSystemItem FindArtsFileItem(FileManagerFile file)
        {
            ArtsFileSystemItem artsFolderItem = FindArtsFolderItem(file.Folder);
            if (artsFolderItem == null)
                return null;
            return ArtsDataProvider.GetArts(tableName, tableId).FindAll(item => (int)item.ParentID == artsFolderItem.ArtID && !item.IsFolder && item.Name == file.Name).FirstOrDefault();
        }
        protected ArtsFileSystemItem FindArtsFolderItem(FileManagerFolder folder)
        {
            return (from artFolderItem in FolderCache.Values
                    where artFolderItem.IsFolder && GetRelativeName(artFolderItem) == folder.RelativeName
                    select artFolderItem).FirstOrDefault();
        }
        protected string GetRelativeName(ArtsFileSystemItem artFolderItem)
        {
            if (artFolderItem.ArtID == ArtsRootItemID) return string.Empty;
            if (artFolderItem.ParentID == ArtsRootItemID) return artFolderItem.Name;
            if (!FolderCache.ContainsKey((int)artFolderItem.ParentID)) return null;
            string name = GetRelativeName(FolderCache[(int)artFolderItem.ParentID]);
            return name == null ? null : Path.Combine(name, artFolderItem.Name);
        }
        protected void RefreshFolderCache()
        {
            this.folderCache = ArtsDataProvider.GetArts(tableName, tableId).FindAll(artItem => artItem.IsFolder).ToDictionary(artItem => artItem.ArtID);
            this.rootFolderDisplayName = tableName;
        }
        protected static byte[] ReadAllBytes(Stream stream)
        {
            byte[] buffer = new byte[16 * 1024];
            int readCount;
            using (MemoryStream ms = new MemoryStream())
            {
                while ((readCount = stream.Read(buffer, 0, buffer.Length)) > 0)
                {
                    ms.Write(buffer, 0, readCount);
                }
                return ms.ToArray();
            }
        }
    }
}