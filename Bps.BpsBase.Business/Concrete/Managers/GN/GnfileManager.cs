using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.GN;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.DataAccess.Abstract.GN;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

using System.Collections.Generic;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Web;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities;
using DevExpress.Web.Internal;
using System.Drawing;
using ChinhDo.Transactions;
using DevExpress.Web.Demos.DataModels.MVC.DataProviders;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GnfileManager : IGnfileService
    {
        private IGnfileDal _gnfileDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals
        
        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GnfileManager(IGnfileDal gnfileDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnfileDal = gnfileDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNFILE> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNFILE>();
            sonuc.Items = global.SirketId != null ? _gnfileDal.GetList(x => x.SIRKID == global.SirketId) : _gnfileDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNFILE> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNFILE>();
            sonuc.Items = global.SirketId != null ? _gnfileDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnfileDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNFILE> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNFILE>();
            sonuc.Items = global.SirketId != null ? _gnfileDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnfileDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNFILE> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNFILE>();
            sonuc.Items = global.SirketId != null ? _gnfileDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnfileDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNFILE> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNFILE>();
            sonuc.Items = global.SirketId != null ? _gnfileDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnfileDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNFILE> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNFILE>();
            sonuc.Nesne = _gnfileDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNFILE> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNFILE", id, global);
            var sonuc = new StandardResponse<GNFILE>();
            sonuc.Nesne = _gnfileDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnfileValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNFILE> Ncch_Add_NLog(GNFILE gnfile, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNFILE>();
            gnfile.SIRKID = global.SirketId.Value; 
            gnfile.EKKULL = global.UserKod;
            gnfile.ETARIH = DateTime.Now;
            gnfile.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnfileDal.Add(gnfile);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnfileValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNFILE> Ncch_Update_Log(GNFILE gnfile,GNFILE oldGnfile, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNFILE", gnfile.Id, global);
            var sonuc = new StandardResponse<GNFILE>();
            gnfile.SIRKID = global.SirketId.Value; 
            gnfile.DEKULL = global.UserKod;
            gnfile.DTARIH = DateTime.Now;
            gnfile.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnfileDal.Update(gnfile);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnfileValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNFILE> Ncch_UpdateAktifPasif_Log(GNFILE gnfile, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNFILE>();
            gnfile.SIRKID = global.SirketId.Value; 
            gnfile.ACTIVE = !gnfile.ACTIVE;
            gnfile.DEKULL = global.UserKod;
            gnfile.DTARIH = DateTime.Now;
            gnfile.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnfileDal.Update(gnfile);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnfileValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNFILE> Ncch_Delete_Log(GNFILE gnfile, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNFILE", gnfile.Id, global);
            var sonuc = new StandardResponse<GNFILE>();
            gnfile.SIRKID = global.SirketId.Value; 
            gnfile.ACTIVE = false;
            gnfile.SLINDI = true;
            gnfile.DEKULL = global.UserKod;
            gnfile.DTARIH = DateTime.Now;
            gnfile.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnfileDal.Update(gnfile);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public StandardResponse GridTopluAktar(byte[] fileData, string fileName, string type, Global global)
        {
            var sonuc = new StandardResponse();
            OleDbConnection conn = null;
            var dosya = fileData;
            try
            {
                var physicalPath = Path.Combine(HttpContext.Current.Server.MapPath("~/Assets/ExcelTopluAktarim"),
                    fileName);
                FileStream objfilestream = new FileStream(physicalPath, FileMode.Create, FileAccess.ReadWrite);
                objfilestream.Write(dosya, 0, dosya.Length);
                objfilestream.Close();

                var connection =
                    @"Provider=Microsoft.ACE.OLEDB.12.0; OLE DB Services=-4;;Data Source=" + physicalPath + ";" +
                    @"Extended Properties='Excel 12.0 Xml;HDR=YES;'";
                conn = new OleDbConnection(connection);
                conn.Open();
                var cmd = new OleDbCommand("SELECT * FROM [Sheet$]", conn)
                {
                    CommandType = CommandType.Text
                };

                var da = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string[] columnNames = dt.Columns.Cast<DataColumn>().Where(w => w.ColumnName != "Id")
                    .Select(x => x.ColumnName)
                    .ToArray();


                var sql = @"SELECT 
			            n.TABLE_NAME, n.COLUMN_NAME, n.DATA_TYPE ,n.CHARACTER_MAXIMUM_LENGTH,v.value AS ACIKLAMA
                        FROM CILEKBASE.INFORMATION_SCHEMA.COLUMNS AS n
						LEFT OUTER JOIN View_DbTables AS v ON n.TABLE_NAME = v.name3 AND n.COLUMN_NAME = v.name2
                        WHERE n.TABLE_NAME=@tableName and n.COLUMN_NAME!='Id'
			            ORDER BY n.TABLE_NAME, n.ORDINAL_POSITION";

                var tableInfos = _gnfileDal.GetListSqlQuery<DbTablesModel>(sql,
                    new SqlParameter("tableName", type ?? ""));


                var insertValues = "";
                var baseEntity = new BaseEntity().GetType().GetProperties();
                foreach (var clm in columnNames)
                {

                    var info = tableInfos.FirstOrDefault(f => f.ACIKLAMA == clm);
                    if (info != null && baseEntity.FirstOrDefault(w => w.Name == info.COLUMN_NAME) == null)
                    {
                        insertValues += info.COLUMN_NAME + ",";
                    }
                }
                insertValues = insertValues.Substring(0, insertValues.Length - 1);

                var types = new List<Type>();

                insertValues = insertValues + ",SIRKID,ACTIVE,SLINDI,EKKULL,ETARIH,DEKULL,DTARIH,KYNKKD";
                var queryInsert =
                    "INSERT INTO  " + type + " (" + insertValues + ") VALUES ";

                var value = "";
                string datas;
                string data;
                var now = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.fff");
                foreach (DataRow row in dt.Rows)
                {
                    datas = "";
                    foreach (var column in columnNames)
                    {
                        data = row[column].ToString();
                        var info = tableInfos.FirstOrDefault(f => f.ACIKLAMA == column);
                        if (info != null && info.COLUMN_NAME != "EKKULL" && info.COLUMN_NAME != "ETARIH"
                            && info.COLUMN_NAME != "DEKULL" && info.COLUMN_NAME != "DTARIH"
                            && info.COLUMN_NAME != "ACTIVE" && info.COLUMN_NAME != "SLINDI" && info.COLUMN_NAME != "KYNKKD")
                        {
                            switch (info.DATA_TYPE)
                            {
                                case "int":
                                    if (string.IsNullOrEmpty(data)) data = "NULL";
                                    types.Add(typeof(int));
                                    break;
                                case "nvarchar":
                                    if (string.IsNullOrEmpty(data)) data = "NULL";
                                    else data = "'" + data + "'";
                                    types.Add(typeof(string));
                                    break;
                                case "varchar":
                                    if (string.IsNullOrEmpty(data)) data = "NULL";
                                    else data = "'" + data + "'";
                                    types.Add(typeof(string));
                                    break;
                                case "datetime":
                                    if (string.IsNullOrEmpty(data)) data = "NULL";
                                    else data = "'" + data + "'";
                                    types.Add(typeof(int));
                                    break;
                                case "bit":
                                    data = (data == "true" ? "1" : "0");
                                    break;
                            }

                            datas += data + ",";
                        }
                    }

                    if (!string.IsNullOrEmpty(datas))
                    {
                        datas = datas.Substring(0, datas.Length - 1);
                        datas = datas + "," + global.SirketId + ", 1, 0, '" + global.UserKod + "', '" + now +
                                "', NULL,NULL, '" + global.KaynakKod + "'";
                        value += "(" + datas + "),";
                    }
                }

                if (!string.IsNullOrEmpty(value))
                {
                    value = value.Substring(0, value.Length - 1);
                    _gnfileDal.ExecuteSqlQuery(queryInsert + value);
                }

                sonuc.Status = ResponseStatusEnum.OK;
            }
            catch (SqlException ex)
            {
                if (ex.Number == 2601)
                {
                    sonuc.Message = "Birden fazla ayn kayittan girilemez!";
                    sonuc.Status = ResponseStatusEnum.OK;
                }
                else
                {
                    sonuc.Message = ex.Message;
                }
                sonuc.Status = ResponseStatusEnum.ERROR;
            }
            catch (Exception ex)
            {
                SqlException innerException = null;
                Exception tmp = ex;
                while (innerException == null && tmp != null)
                {
                    if (tmp != null)
                    {
                        innerException = tmp.InnerException as SqlException;
                        tmp = tmp.InnerException;
                    }

                }
                if (innerException != null && innerException.Number == 2601)
                {
                    sonuc.Message = "Birden fazla ayn kayittan girilemez!";
                    sonuc.Status = ResponseStatusEnum.OK;
                }
                else
                {
                    sonuc.Message = ex.Message;
                }
                sonuc.Status = ResponseStatusEnum.ERROR;
            }

            conn.Close();
            return sonuc;
        }

        public StandardResponse<GNFILE> Cch_GetDefaultFile_NLog(Global global, string tableName, int tableId)
        {
            var sonuc = new StandardResponse<GNFILE>();
            sonuc.Nesne = _gnfileDal.Get(x =>
                x.SIRKID == global.SirketId && x.ACTIVE && x.SLINDI == false && x.DEFAUL && x.TABLNM == tableName &&
                x.TABLID == tableId);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNFILE> Ncch_GetUserFiles_NLog(Global global, string tableName, int id)
        {
            var sonuc = new ListResponse<GNFILE>();
            sonuc.Items = _gnfileDal.GetList(x => x.SIRKID == global.SirketId && x.TABLID == id && x.TABLNM == tableName).ToList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNFILE> Ncch_SaveorUpdate_Log(string tableName, int? tableId, int? fileType, string tempPath, string destPath, Global global)
        {
            var sonuc = new StandardResponse<GNFILE>();
            var files = _gnfileDal.GetList(w =>
                w.SIRKID == global.SirketId && w.TABLNM == tableName && w.TABLID == tableId).ToList();

            var sourceFullPath = HttpContext.Current.Server.MapPath(tempPath);
            FileInfo fi = new FileInfo(sourceFullPath);
            if (fi.Exists && sourceFullPath.Contains("UploadFolder\\Temp"))
            {
                var model = new GNFILE();
                model.TABLNM = tableName;
                model.TABLID = tableId.Value;
                model.DEFAUL = true;
                model.FLNAME = model.TABLID + "---" + global.UserKod + "-" + fi.Name;
                if (fileType == 0)
                {
                    using (Image original = Image.FromFile(sourceFullPath))
                    {
                        ImageUtils.SaveToJpeg(original, HttpContext.Current.Request.MapPath(destPath + model.FLNAME));
                    }
                    model.GNPATH = destPath + model.FLNAME;
                    model.FLTYPE = 0;
                }
                else if (fileType == 1)
                {
                    using (Image original = Image.FromFile(sourceFullPath))
                    {
                        byte[] arr;
                        using (MemoryStream ms = new MemoryStream())
                        {
                            original.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);
                            arr = ms.ToArray();
                        }

                        model.GNPATH = "";
                        model.GNDOSY = arr;
                        model.FLTYPE = 1;
                    }
                }

                var sameFileExist = files.FirstOrDefault(w => w.FLNAME == model.FLNAME);
                if (sameFileExist == null)
                {
                    model.SIRKID = global.SirketId.Value;
                    model.DEFAUL = true;
                    model.EKKULL = global.UserKod;
                    model.ETARIH = DateTime.Now;
                    model.ACTIVE = true;
                    model.SLINDI = false;
                    model.KYNKKD = global.KaynakKod;
                    sonuc.Nesne = _gnfileDal.Add(model);
                }
                else
                {
                    model.SIRKID = global.SirketId.Value;
                    model.DEFAUL = true;
                    model.DEKULL = global.UserKod;
                    model.DTARIH = DateTime.Now;
                    model.ACTIVE = true;
                    model.KYNKKD = global.KaynakKod;
                    sonuc.Nesne = _gnfileDal.Update(model);
                }

                foreach (var file in files.Where(w => w.FLNAME != model.FLNAME).ToList())
                {
                    file.DEFAUL = false;
                    sonuc.Nesne = _gnfileDal.Update(file);
                }
                sonuc.Nesne = model;
                sonuc.Status = ResponseStatusEnum.OK;
            }
            else
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
                sonuc.Message = "Resim mevcut degil!";
            }

            return sonuc;
        }

        public ListResponse<GNFILE> Cch_GetListByTableId_NLog(Global global, string tableName, int tableId)
        {
            var sonuc = new ListResponse<GNFILE>();
            sonuc.Items = global.SirketId != null
                ? _gnfileDal.GetList(x =>
                    x.SIRKID == global.SirketId && x.SLINDI == false && x.ACTIVE && x.TABLID == tableId && x.TABLNM == tableName)
                : _gnfileDal.GetList(x => x.SLINDI == false && x.ACTIVE && x.TABLID == tableId && x.TABLNM == tableName && x.FLTYPE == 0);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNFILE> Ncch_SaveTemp_Log(string key, string tableName, int? tableId, Global global)
        {
            var sonuc = new StandardResponse<GNFILE>();
            sonuc.Status = ResponseStatusEnum.ERROR;
            var fileList = new List<ImageGaleryModel>();
            var listGnfile = new List<GNFILE>();

            var path = "~/Assets/UploadFolder/Temp";
            var tempPath = HttpContext.Current.Request.MapPath(path);

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

                        var keySplited = image.Split(new string[] { "---" }, StringSplitOptions.None);
                        var fileName = keySplited[2];
                        var newName = tableId + "---" + fileName;


                        var model = new ImageGaleryModel();
                        model.GNDOSY = byteArray;
                        model.FLNAME = newName;
                        model.GNSIZE = sizeText;
                        model.GNPATH = "~/Assets/UploadFolder/" + tableName + "/" + newName;
                        fileList.Add(model);

                        var gnFileModel = new GNFILE()
                        {
                            TABLNM = tableName,
                            TABLID = tableId.Value,
                            FLNAME = model.FLNAME,
                            GNDOSY = null,
                            GNPATH = model.GNPATH,
                            FLTYPE = 0,
                            DEFAUL = false,
                            SIRKID = global.SirketId.Value,
                            EKKULL = global.UserKod,
                            ETARIH = DateTime.Now,
                            KYNKKD = global.KaynakKod,
                            ACTIVE = true,
                            SLINDI = false
                        };
                        listGnfile.Add(gnFileModel);
                    }
                }
            }

            if (listGnfile.Count > 0)
            {
                _gnfileDal.MultiAdd(listGnfile);

                foreach (var file in fileList)
                {
                    var physicalPath = HttpContext.Current.Server.MapPath(file.GNPATH);
                    FileStream objfilestream = new FileStream(physicalPath, FileMode.Create, FileAccess.ReadWrite);
                    objfilestream.Write(file.GNDOSY, 0, file.GNDOSY.Length);
                    objfilestream.Close();
                }
            }

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNFILE> Ncch_SaveFileManager_Log(string tableName, int? tableId, Global global)
        {
            var sonuc = new StandardResponse<GNFILE>();
            sonuc.Status = ResponseStatusEnum.ERROR;

            if (string.IsNullOrEmpty(tableName) || tableId == null)
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
                sonuc.Message = "Gerekli bilgiler okunamadi!";
                return sonuc;
            }

            var key = global.UserKod + "-" + tableName + "-" + tableId;

            List<ArtsFileSystemItem> newFiles = (List<ArtsFileSystemItem>)HttpContext.Current.Session[key];

            if (newFiles == null)
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
                sonuc.Message = "Hic dosya okunamadi!";
                return sonuc;
            }

            newFiles = newFiles.Where(w => w.ParentID != -1).ToList();

            var oldFiles = Cch_GetListByTableId_NLog(global, tableName, tableId.Value);

            if (oldFiles.Status != ResponseStatusEnum.OK)
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
                sonuc.Message = "Mevcut eski dosyalar okunamadi!";
                return sonuc;
            }

            foreach (var item in oldFiles.Items)
            {
                _gnfileDal.Delete(item);
            }

            var newList = new List<GNFILE>();
            foreach (var item in newFiles)
            {
                var keySplited = item.Name.Split(new string[] { "---" }, StringSplitOptions.None);
                if (keySplited.Length != 3)
                {
                    item.Name = tableName + "---" + tableId + "---" + item.Name;
                }

                var gnFileModel = new GNFILE()
                {
                    TABLNM = tableName,
                    TABLID = tableId.Value,
                    FLNAME = item.Name,
                    //GNDOSY = item.Data,
                    GNDOSY = null,
                    GNPATH = "~/Assets/UploadFolder/" + tableName + "/" + item.Name,
                    FLTYPE = 0,
                    DEFAUL = false,
                    SIRKID = global.SirketId.Value,
                    EKKULL = global.UserKod,
                    ETARIH = DateTime.Now,
                    KYNKKD = global.KaynakKod,
                    ACTIVE = true,
                    SLINDI = false
                };
                newList.Add(gnFileModel);
            }

            if (newList.Count > 0)
            {
                _gnfileDal.MultiAdd(newList);
            }

            TxFileManager fileMgr = new TxFileManager();
            foreach (var item in oldFiles.Items)
            {
                //string tempPath = HttpContext.Current.Request.MapPath("~/Assets/UploadFolder/" + tableName + "/ " + item.FLNAME);
                //var fileExist = File.Exists(tempPath);
                //if (fileExist)
                //{
                //    File.Delete(HttpContext.Current.Server.MapPath("~/Assets/UploadFolder/" + tableName + "/ " + item.FLNAME));
                //}

                fileMgr.Delete(HttpContext.Current.Server.MapPath("~/Assets/UploadFolder/" + tableName + "/" + item.FLNAME));
            }
            foreach (var file in newFiles)
            {
                var physicalPath = HttpContext.Current.Server.MapPath("~/Assets/UploadFolder/" + tableName + "/" + file.Name);
                FileStream objfilestream = new FileStream(physicalPath, FileMode.Create, FileAccess.ReadWrite);
                objfilestream.Write(file.Data, 0, file.Data.Length);
                objfilestream.Close();
            }

            sonuc.Status = ResponseStatusEnum.OK;
            sonuc.Message = "Kayit basariyla tamamlandi!";
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnfileValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNFILE> Ncch_Save_NLog(GNFILE gnfile, Global global)
        {
            var sonuc = new StandardResponse<GNFILE>();
            var response = Ncch_GetByFileName_NLog(gnfile.TABLNM, gnfile.TABLID, gnfile.FLNAME, global);
            if (response.Status == ResponseStatusEnum.OK && response.Nesne != null)
            {
                sonuc.Message = "(" + gnfile.FLNAME + ") Ayni isimde dosya kaydedilemez!";
                sonuc.Status = ResponseStatusEnum.ERROR;
                return sonuc;
            }
            gnfile.SIRKID = global.SirketId.Value;
            gnfile.EKKULL = global.UserKod;
            gnfile.ETARIH = DateTime.Now;
            gnfile.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnfileDal.Add(gnfile);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNFILE> Ncch_GetByFileName_NLog(string tableName, int? tableId, string fileName, Global global)
        {
            var sonuc = new StandardResponse<GNFILE>();
            sonuc.Nesne = _gnfileDal.Get(x => x.SIRKID == global.SirketId && x.TABLNM == tableName && x.TABLID == tableId && x.FLNAME == fileName);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnfileValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNFILE> Ncch_DeleteFull_Log(GNFILE gnfile, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNFILE>();
            sonuc.Nesne = _gnfileDal.Delete(gnfile);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
