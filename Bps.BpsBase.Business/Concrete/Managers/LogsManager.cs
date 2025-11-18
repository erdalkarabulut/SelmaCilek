using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.DataAccess.Abstract;
using Bps.BpsBase.Entities.Concrete;

#region ClientUsing

using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.Core.CrossCuttingConcerns.Logging;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers
{
    public class LogsManager : ILogsService
    {
        private ILogsDal _logsDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public LogsManager(ILogsDal logsDal,IGnService gnservice,ILockedService lockedservice)
        {
            _logsDal = logsDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<Logs> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<Logs>();
            sonuc.Items = _logsDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<Logs> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<Logs>();
            sonuc.Nesne = _logsDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<Logs> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("Logs", id, global);
            var sonuc = new StandardResponse<Logs>();
            sonuc.Nesne = _logsDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(LogsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<Logs> Ncch_Add_NLog(Logs logs, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<Logs>();
            sonuc.Nesne = _logsDal.Add(logs);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(LogsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<Logs> Ncch_Update_Log(Logs logs,Logs oldLogs, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("Logs", logs.Id, global);
            var sonuc = new StandardResponse<Logs>();
            sonuc.Nesne = _logsDal.Update(logs);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(LogsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<Logs> Ncch_Delete_Log(Logs logs, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("Logs", logs.Id, global);
            var sonuc = new StandardResponse<Logs>();
            sonuc.Nesne = _logsDal.Delete(logs);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<BelgeAkisModel> Ncch_GetLogsByType_NLog(int? id, string type, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<BelgeAkisModel>();
            sonuc.Items = new List<BelgeAkisModel>();
            var items = _logsDal.GetList(x => x.IsCompare == "1" && x.TEKNAD == type && x.TableId == id.ToString() && x.Audit != "ERROR").OrderBy(o => o.Date).ToList();
            foreach (var log in items)
            {
                var detail = JsonConvert.DeserializeObject<List<LogParameter>>(JObject.Parse(log.Detail)
                    .SelectToken("MessageObject").Last.Last.ToString());
                var globalLog = JsonConvert.DeserializeObject<Global>(detail[2].Value.ToString());
                dynamic dynJson = JsonConvert.DeserializeObject(detail[0].Value.ToString());
                var dataNew = "";
                var dataOld = "";
                BelgeAkisModel model = null;
                foreach (var item in dynJson)
                {
                    model = new BelgeAkisModel();
                    var name = item.Name;
                    if (name == "EKKULL" || name == "ETARIH" || name == "KYNKKD")
                    {
                        continue;
                    }
                    var valueNew = "";
                    if (item.First.Value != null)
                    {
                        valueNew = item.First.Value.ToString();
                    }
                    var dt = JObject.Parse(detail[1].Value.ToString())[name];
                    var valueOld = "";
                    if (dt != null)
                    {
                        var value = ((JValue) dt).Value;
                        if (value != null)
                            valueOld = value.ToString();
                    }

                    if (valueNew.Equals(valueOld)) continue;
                    dataNew += name + ": " + valueNew + (global.KaynakKod == "4" ?  "</br>" : "\n");
                    dataOld += name + ": " + valueOld + (global.KaynakKod == "4" ?  "</br>" : "\n");
                }

                if (!string.IsNullOrEmpty(dataOld) || !string.IsNullOrEmpty(dataNew))
                {
                    model.Old = dataOld;
                    model.New = dataNew;
                    model.UserKod = log.UserKod;
                    model.Date = log.Date.Value;
                    model.GNNAME = globalLog.FirstName;
                    model.GNSNAM = globalLog.LastName;
                    sonuc.Items.Add(model);
                }
            }

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
