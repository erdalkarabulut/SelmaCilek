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

using System.Data.SqlClient;
using System.Collections.Generic;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GnmenuManager : IGnmenuService
    {
        private IGnmenuDal _gnmenuDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GnmenuManager(IGnmenuDal gnmenuDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnmenuDal = gnmenuDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNMENU> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNMENU>();
            sonuc.Items = global.SirketId != null ? _gnmenuDal.GetList(x => x.SIRKID == global.SirketId) : _gnmenuDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNMENU> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNMENU>();
            sonuc.Items = global.SirketId != null ? _gnmenuDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnmenuDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNMENU> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNMENU>();
            sonuc.Items = global.SirketId != null ? _gnmenuDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnmenuDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNMENU> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNMENU>();
            sonuc.Items = global.SirketId != null ? _gnmenuDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnmenuDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNMENU> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNMENU>();
            sonuc.Items = global.SirketId != null ? _gnmenuDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnmenuDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNMENU> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNMENU>();
            sonuc.Nesne = _gnmenuDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNMENU> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNMENU", id, global);
            var sonuc = new StandardResponse<GNMENU>();
            sonuc.Nesne = _gnmenuDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnmenuValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNMENU> Ncch_Add_NLog(GNMENU gnmenu, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNMENU>();
            gnmenu.SIRKID = global.SirketId.Value; 
            gnmenu.EKKULL = global.UserKod;
            gnmenu.ETARIH = DateTime.Now;
            gnmenu.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnmenuDal.Add(gnmenu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnmenuValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNMENU> Ncch_Update_Log(GNMENU gnmenu,GNMENU oldGnmenu, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNMENU", gnmenu.Id, global);
            var sonuc = new StandardResponse<GNMENU>();
            gnmenu.SIRKID = global.SirketId.Value; 
            gnmenu.DEKULL = global.UserKod;
            gnmenu.DTARIH = DateTime.Now;
            gnmenu.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnmenuDal.Update(gnmenu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnmenuValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNMENU> Ncch_UpdateAktifPasif_Log(GNMENU gnmenu, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNMENU>();
            gnmenu.SIRKID = global.SirketId.Value; 
            gnmenu.ACTIVE = !gnmenu.ACTIVE;
            gnmenu.DEKULL = global.UserKod;
            gnmenu.DTARIH = DateTime.Now;
            gnmenu.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnmenuDal.Update(gnmenu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnmenuValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNMENU> Ncch_Delete_Log(GNMENU gnmenu, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNMENU", gnmenu.Id, global);
            var sonuc = new StandardResponse<GNMENU>();
            gnmenu.SIRKID = global.SirketId.Value; 
            gnmenu.ACTIVE = false;
            gnmenu.SLINDI = true;
            gnmenu.DEKULL = global.UserKod;
            gnmenu.DTARIH = DateTime.Now;
            gnmenu.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnmenuDal.Update(gnmenu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        //[CacheRemoveAspect(typeof(MemoryCacheManager))]
        //public StandardResponse DegisiklikKaydet(ChangeRecords<GNMENU> records, Global global)
        //{
        //    //var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
        //    //if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
        //    var sonuc = new StandardResponse();

        //    foreach (var data in records.Created)
        //    {
        //        data.EKKULL = global.UserKod;
        //        data.ETARIH=DateTime.Now;
        //        _gnmenuDal.Add(data);
        //    }

        //    foreach (var data in records.Updated)
        //    {
        //        data.DEKULL = global.UserKod;
        //        data.DTARIH = DateTime.Now;
        //        _gnmenuDal.Update(data);
        //    }

        //    foreach (var data in records.Deleted)
        //    {
        //        data.ACTIVE = false;
        //        data.SLINDI = true;
        //        _gnmenuDal.Update(data);
        //    }
        //    sonuc.Status = ResponseStatusEnum.OK;
        //    return sonuc;
        //}
        public ListResponse<GNMENU> Ncch_MenuProListGetir_NLog(Global global, string prokod, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNMENU> { Items = new List<GNMENU>() };
            var whereStr = "";
            if (!string.IsNullOrEmpty(prokod))
            {
                whereStr = " and mn.PROKOD='" + prokod + "'";
            }
            var sql = @"select * from GNMENU as mn where mn.SIRKID=@sirketId and mn.SLINDI=0 " + whereStr + " order by MN.PROKOD";

            sonuc.Items = _gnmenuDal.GetListSqlQuery<GNMENU>(sql, new SqlParameter("sirketId", global.SirketId));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNMENU> Ncch_GetListParentByProkod_NLog(Global global, string prokod, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNMENU>();
            sonuc.Items = global.SirketId != null ? _gnmenuDal.GetList(x => x.SIRKID == global.SirketId && x.PARENT == 0 && x.SLINDI == false && x.PROKOD == prokod) : _gnmenuDal.GetList(x => x.PARENT == 0 && x.SLINDI == false && x.PROKOD == prokod);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
