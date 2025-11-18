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

using Bps.BpsBase.Entities.Models.GN.Listed;
using System.Collections.Generic;
using Bps.BpsBase.Entities.Models.GN.Single;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GnevrkManager : IGnevrkService
    {
        private IGnevrkDal _gnevrkDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GnevrkManager(IGnevrkDal gnevrkDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnevrkDal = gnevrkDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNEVRK> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNEVRK>();
            sonuc.Items = global.SirketId != null ? _gnevrkDal.GetList(x => x.SIRKID == global.SirketId) : _gnevrkDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNEVRK> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNEVRK>();
            sonuc.Items = global.SirketId != null ? _gnevrkDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnevrkDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNEVRK> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNEVRK>();
            sonuc.Items = global.SirketId != null ? _gnevrkDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnevrkDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNEVRK> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNEVRK>();
            sonuc.Items = global.SirketId != null ? _gnevrkDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnevrkDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNEVRK> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNEVRK>();
            sonuc.Items = global.SirketId != null ? _gnevrkDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnevrkDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNEVRK> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNEVRK>();
            sonuc.Nesne = _gnevrkDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNEVRK> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNEVRK", id, global);
            var sonuc = new StandardResponse<GNEVRK>();
            sonuc.Nesne = _gnevrkDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnevrkValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNEVRK> Ncch_Add_NLog(GNEVRK gnevrk, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNEVRK>();
            gnevrk.SIRKID = global.SirketId.Value; 
            gnevrk.EKKULL = global.UserKod;
            gnevrk.ETARIH = DateTime.Now;
            gnevrk.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnevrkDal.Add(gnevrk);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnevrkValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNEVRK> Ncch_Update_Log(GNEVRK gnevrk,GNEVRK oldGnevrk, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNEVRK", gnevrk.Id, global);
            var sonuc = new StandardResponse<GNEVRK>();
            gnevrk.SIRKID = global.SirketId.Value; 
            gnevrk.DEKULL = global.UserKod;
            gnevrk.DTARIH = DateTime.Now;
            gnevrk.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnevrkDal.Update(gnevrk);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnevrkValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNEVRK> Ncch_UpdateAktifPasif_Log(GNEVRK gnevrk, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNEVRK>();
            gnevrk.SIRKID = global.SirketId.Value; 
            gnevrk.ACTIVE = !gnevrk.ACTIVE;
            gnevrk.DEKULL = global.UserKod;
            gnevrk.DTARIH = DateTime.Now;
            gnevrk.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnevrkDal.Update(gnevrk);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnevrkValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNEVRK> Ncch_Delete_Log(GNEVRK gnevrk, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNEVRK", gnevrk.Id, global);
            var sonuc = new StandardResponse<GNEVRK>();
            gnevrk.SIRKID = global.SirketId.Value; 
            gnevrk.ACTIVE = false;
            gnevrk.SLINDI = true;
            gnevrk.DEKULL = global.UserKod;
            gnevrk.DTARIH = DateTime.Now;
            gnevrk.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnevrkDal.Update(gnevrk);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<DbTablesModel> GetDbTables()
        {
            var sonuc = new ListResponse<DbTablesModel> { Items = new List<DbTablesModel>() };
            var sql = @"SELECT  n.TABLE_NAME as TableName
                                FROM CILEKBASE.INFORMATION_SCHEMA.TABLES AS n 
                                WHERE n.TABLE_NAME != 'View_DbTables' AND n.TABLE_NAME != 'View_TablesPK' 
                                ORDER BY n.TABLE_NAME";

            sonuc.Items = _gnevrkDal.GetListSqlQuery<DbTablesModel>(sql);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        //public StandardResponse<GNEVRK> Ncch_GetByIndexParam_NLog(EvrakNoUretParamModel param, Global global, bool yetkiKontrol = true)
        //{
        //    if (yetkiKontrol)
        //    {
        //        var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
        //        if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
        //    }
        //    //_lockedService.LockControlRead("GNEVRK", id, global);
        //    var sonuc = new StandardResponse<GNEVRK>();
        //    sonuc.Nesne = _gnevrkDal.Get(x =>
        //        x.SIRKID == global.SirketId && x.TABLNM == param.TabloAdi && x.TEKNAD == param.TeknikAd &&
        //        x.ISLTUR == param.IslemTur && x.GNYEAR == DateTime.Today.Year);
        //    sonuc.Status = ResponseStatusEnum.OK;
        //    return sonuc;
        //}

        //[CacheRemoveAspect(typeof(MemoryCacheManager))]
        //public StandardResponse<string> EvrakNoUret(Global global, EvrakNoUretParamModel paramModel)
        //{
        //    var sonuc = new StandardResponse<string>();
        //    var evrakResponse = Ncch_GetByIndexParam_NLog(paramModel, global, false);
        //    if (evrakResponse.Status != ResponseStatusEnum.OK || evrakResponse.Nesne == null)
        //    {
        //        sonuc.Message = "Evrak numaras";
        //        sonuc.Status = ResponseStatusEnum.ERROR;
        //        return sonuc;
        //    }

        //    var model = evrakResponse.Nesne;

        //    if (model.GNYEAR != DateTime.Today.Year)
        //    {
        //        sonuc.Message = "Evrak numras
        //        sonuc.Status = ResponseStatusEnum.ERROR;
        //        return sonuc;
        //    }

        //    var karsay = model.KARSAY;
        //    var kaldeg = model.KALDEG;
        //    var sifir = "";

        //    string kalyeni = (kaldeg + 1).ToString();
        //    var lengkalnew = kalyeni.Length;
        //    var lengonek = string.IsNullOrEmpty(model.GNONEK) ? 0 : model.GNONEK.Length;
        //    var fark = karsay - lengkalnew - lengonek;

        //    if (karsay != 0)
        //    {
        //        if (fark > 0)
        //        {
        //            for (int i = 1; i <= fark; i++)
        //            {
        //                sifir += "0";
        //            }
        //        }
        //        sonuc.Nesne = model.GNONEK + sifir + kalyeni;
        //        model.DEKULL = global.UserKod;
        //        model.DTARIH = DateTime.Now;
        //        model.KALDEG = model.KALDEG + 1;
        //    }
        //    else
        //    {
        //        sonuc.Nesne = model.GNONEK + kalyeni;
        //        model.DEKULL = global.UserKod;
        //        model.DTARIH = DateTime.Now;
        //        model.KALDEG = model.KALDEG + 1;
        //    }

        //    if (!(model.KALDEG >= model.BASDEG && model.KALDEG <= model.BITDEG))
        //    {
        //        sonuc.Message = "Evrak numras";
        //        sonuc.Status = ResponseStatusEnum.ERROR;
        //        return sonuc;
        //    }

        //    _gnevrkDal.Update(model);
        //    sonuc.Status = ResponseStatusEnum.OK;
        //    return sonuc;
        //}

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<string> Ncch_EvrakNoUret_NLog(Global global, EvrakNoUretParamModel paramModel)
        {
            var sonuc = new StandardResponse<string>();
            
            var evrakResponse = _gnevrkDal.Get(x =>
                x.SIRKID == global.SirketId && x.TABLNM == paramModel.TabloAdi && x.TEKNAD == paramModel.TeknikAd &&
                x.ISLTUR == paramModel.IslemTur && x.GNYEAR == DateTime.Today.Year);
            //var evrakResponse = Ncch_GetByIndexParam_NLog(paramModel, global, false);
            if (evrakResponse == null)
            {
                sonuc.Message = "Evrak numras!";
                sonuc.Status = ResponseStatusEnum.ERROR;
                return sonuc;
            }

            var model = evrakResponse;

            if (model.GNYEAR != DateTime.Today.Year)
            {
                sonuc.Message = "Evrak numras!";
                sonuc.Status = ResponseStatusEnum.ERROR;
                return sonuc;
            }

            var karsay = model.KARSAY;
            var kaldeg = model.KALDEG;
            var sifir = "";

            string kalyeni = (kaldeg + 1).ToString();
            var lengkalnew = kalyeni.Length;
            var lengonek = string.IsNullOrEmpty(model.GNONEK) ? 0 : model.GNONEK.Length;
            var fark = karsay - lengkalnew - lengonek;

            if (karsay != 0)
            {
                if (fark > 0)
                {
                    for (int i = 1; i <= fark; i++)
                    {
                        sifir += "0";
                    }
                }
                sonuc.Nesne = model.GNONEK + sifir + kalyeni;
                model.DEKULL = global.UserKod;
                model.DTARIH = DateTime.Now;
                model.KALDEG = model.KALDEG + 1;
            }
            else
            {
                sonuc.Nesne = model.GNONEK + kalyeni;
                model.DEKULL = global.UserKod;
                model.DTARIH = DateTime.Now;
                model.KALDEG = model.KALDEG + 1;
            }

            if (!(model.KALDEG >= model.BASDEG && model.KALDEG <= model.BITDEG))
            {
                sonuc.Message = "Evrak numras!";
                sonuc.Status = ResponseStatusEnum.ERROR;
                return sonuc;
            }

            _gnevrkDal.Update(model);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNEVRK> Ncch_GetEvrak_NLog(Global global, EvrakNoUretParamModel paramModel, int? _year)
        {
            var sonuc = new StandardResponse<GNEVRK>();

            if (_year != 0)
            {
                _year = DateTime.Today.Year;
            }
            var evrakResponse = _gnevrkDal.Get(x =>
                x.SIRKID == global.SirketId && x.TABLNM == paramModel.TabloAdi && x.TEKNAD == paramModel.TeknikAd &&
                x.ISLTUR == paramModel.IslemTur && x.GNYEAR == _year);
            //var evrakResponse = Ncch_GetByIndexParam_NLog(paramModel, global, false);
            if (evrakResponse == null)
            {
                sonuc.Message = "Evrak numrasý üretim yýlý dolmuþtur, lütfen sistem yöneticinizle irtibata geçiniz!";
                sonuc.Status = ResponseStatusEnum.ERROR;
                return sonuc;
            }

            sonuc.Nesne = evrakResponse;
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
