using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.DataAccess.Abstract.GN;
using Bps.Core.GlobalStaticsVariables;
using Bps.Core.Response;
using Bps.Core.Web.Model.Devexpress;
using Newtonsoft.Json;

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GnManager : IGnService
    {
        private IGnyetkDal _gnyetkDal;

        public GnManager(IGnyetkDal gnyetkDal)
        {
            _gnyetkDal = gnyetkDal;
        }

        public StandardResponse Ncch_GetListYetki_NLog(Global global, string[] roles)
        {
            var sonuc = new StandardResponse { Status = ResponseStatusEnum.ERROR };
            //var entity = _gnyetkDal.Get(x =>
            //    x.SIRKID == global.SirketId && x.PROKOD == global.ProjeKod && x.MNUTAG == global.MenuTag && x.KULKOD == global.UserKod);
            //var isAuthorized = false;

            var entity = _gnyetkDal.Get(x =>
                x.SIRKID == (global.SirketType == true ? global.SirketId : global.KarsiSirketId) && x.PROKOD == global.ProjeKod && x.MNUTAG == global.MenuTag && x.KULKOD == global.UserKod);
            var isAuthorized = false;

            if (entity == null)
            {
                return sonuc;
            }

            foreach (var role in roles)
            {
                if (global.Role == "Admin")
                {
                    sonuc.Status = ResponseStatusEnum.OK;
                    return sonuc;
                }
                switch (role)
                {
                    case "View":
                        if (entity.GRNTLM)
                        {
                            isAuthorized = true;
                        }
                        break;
                    case "Add":
                        if (entity.EKLEME)
                        {
                            isAuthorized = true;
                        }

                        break;
                    case "Edit":
                        if (entity.DEGIST)
                        {
                            isAuthorized = true;
                        }
                        break;
                    case "Delete":
                        if (entity.SILMEK)
                        {
                            isAuthorized = true;
                        }
                        break;
                    case "Save":
                        if (entity.KAYDET)
                        {
                            isAuthorized = true;
                        }
                        break;
                }
            }

            if (isAuthorized)
            {
                sonuc.Status = ResponseStatusEnum.OK;
            }
            return sonuc;
        }

        public StandardResponse DevexpressSaveGridLayout(string gridName, string layoutData, string name, Global global)
        {
            var sonuc = new StandardResponse();
            List<GridLayoutModel> list = null;
            var path = name != "_Default"
                 ? HttpContext.Current.Server.MapPath("~\\KulGridLayout\\" + global.UserKod + ".json")
                 : HttpContext.Current.Server.MapPath("~\\DefGridLayout\\" + "_Default" + gridName + ".json");

            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                list = JsonConvert.DeserializeObject<List<GridLayoutModel>>(json);
                if (list.Count > 0)
                {
                    var grid = list.FirstOrDefault(w => w.Grid == gridName && w.Name == name);
                    if (grid != null) grid.LayoutData = layoutData;
                    else
                    {
                        var model = new GridLayoutModel()
                        {
                            Name = name,
                            Grid = gridName,
                            LayoutData = layoutData,
                            Active = false
                        };
                        list.Add(model);
                    }
                }
                else
                {
                    list = new List<GridLayoutModel>()
                    {
                        new GridLayoutModel()
                        {
                            Name = name,
                            Grid = gridName,
                            LayoutData = layoutData,
                            Active = true
                        }
                    };
                }
            }
            else
            {
                list = new List<GridLayoutModel>()
                {
                    new GridLayoutModel()
                    {
                        Name = name,
                        Grid = gridName,
                        LayoutData = layoutData,
                        Active = true
                    }
                };
            }

            if (list.Count > 0)
            {
                if (File.Exists(path)) File.Delete(path);
                using (StreamWriter sw = new StreamWriter(path, true))
                {
                    using (JsonWriter jw = new JsonTextWriter(sw))
                    {
                        jw.Formatting = Formatting.Indented;
                        JsonSerializer serializer = new JsonSerializer();
                        serializer.Serialize(jw, list);
                    }
                }

                if (name == "_Default")
                {
                    sonuc.Message = "Başarılı, default yerlesim kaydedildi!";
                }
                sonuc.Status = ResponseStatusEnum.OK;
            }
            else
            {
                sonuc.Status = ResponseStatusEnum.OK;
                sonuc.Message = "İşlem tamamlanamadı! Yerleşim bilgisi okunamadı!";
                return sonuc;
            }

            return sonuc;
        }

        public StandardResponse<string> DevexpressProcessGridLayout(string gridName, string layoutData, string name, int type, Global global)
        {
            var sonuc = new StandardResponse<string>();
            List<GridLayoutModel> list = null;
            List<GridLayoutModel> allOtherDatas = new List<GridLayoutModel>();
            string path = HttpContext.Current.Server.MapPath("~\\KulGridLayout\\" + global.UserKod + ".json");
            if (File.Exists(path))
            {
                var json = File.ReadAllText(path);
                list = JsonConvert.DeserializeObject<List<GridLayoutModel>>(json);
                allOtherDatas = list.Where(w => w.Grid != gridName).ToList();
                if (list.Count > 0)
                {
                    if (type == 0)
                    {
                        var data = list.FirstOrDefault(w => w.Grid == gridName && w.Name == name);
                        if (data != null)
                        {
                            list.Remove(data);
                        }

                        if (list.Count == 0)
                        {
                            sonuc.Nesne = "Count:0";
                        }
                    }
                    else
                    {
                        var data = list.FirstOrDefault(w => w.Grid == gridName && w.Name == name);
                        var dataOther = list.Where(w => w.Grid == gridName && w.Name != name).ToList();
                        if (data != null)
                        {
                            data.Active = true;
                            if (dataOther.Count > 0)
                            {
                                foreach (var dt in dataOther)
                                {
                                    dt.Active = false;
                                }
                            }
                            sonuc.Nesne = data.LayoutData;
                        }
                    }
                }
                else
                {
                    sonuc.Status = ResponseStatusEnum.ERROR;
                    sonuc.Message = "İşlem tamamlanamadı! Layout dosyası okunamadı!";
                    return sonuc;
                }
            }

            if (File.Exists(path)) File.Delete(path);
            if (list != null)
            {
                var data = list.Where(w => w.Grid == gridName);
                allOtherDatas.AddRange(data);
            }
            else
                allOtherDatas = new List<GridLayoutModel>();
            using (StreamWriter sw = new StreamWriter(path, true))
            {
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    jw.Formatting = Formatting.Indented;
                    JsonSerializer serializer = new JsonSerializer();
                    serializer.Serialize(jw, allOtherDatas);
                }
            }
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

    }
}