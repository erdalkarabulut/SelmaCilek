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
using System.Data.SqlClient;
using Bps.BpsBase.Entities.Models.GN.Listed;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GnkukrManager : IGnkukrService
    {
        private IGnkukrDal _gnkukrDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GnkukrManager(IGnkukrDal gnkukrDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnkukrDal = gnkukrDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNKUKR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKUKR>();
            sonuc.Items = global.SirketId != null ? _gnkukrDal.GetList(x => x.SIRKID == global.SirketId) : _gnkukrDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKUKR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKUKR>();
            sonuc.Items = global.SirketId != null ? _gnkukrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnkukrDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKUKR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKUKR>();
            sonuc.Items = global.SirketId != null ? _gnkukrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnkukrDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKUKR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKUKR>();
            sonuc.Items = global.SirketId != null ? _gnkukrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnkukrDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKUKR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKUKR>();
            sonuc.Items = global.SirketId != null ? _gnkukrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnkukrDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNKUKR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNKUKR>();
            sonuc.Nesne = _gnkukrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNKUKR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNKUKR", id, global);
            var sonuc = new StandardResponse<GNKUKR>();
            sonuc.Nesne = _gnkukrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnkukrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKUKR> Ncch_Add_NLog(GNKUKR gnkukr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNKUKR>();
            gnkukr.SIRKID = global.SirketId.Value; 
            gnkukr.EKKULL = global.UserKod;
            gnkukr.ETARIH = DateTime.Now;
            gnkukr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnkukrDal.Add(gnkukr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnkukrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKUKR> Ncch_Update_Log(GNKUKR gnkukr,GNKUKR oldGnkukr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNKUKR", gnkukr.Id, global);
            var sonuc = new StandardResponse<GNKUKR>();
            gnkukr.SIRKID = global.SirketId.Value; 
            gnkukr.DEKULL = global.UserKod;
            gnkukr.DTARIH = DateTime.Now;
            gnkukr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnkukrDal.Update(gnkukr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnkukrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKUKR> Ncch_UpdateAktifPasif_Log(GNKUKR gnkukr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNKUKR>();
            gnkukr.SIRKID = global.SirketId.Value; 
            gnkukr.ACTIVE = !gnkukr.ACTIVE;
            gnkukr.DEKULL = global.UserKod;
            gnkukr.DTARIH = DateTime.Now;
            gnkukr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnkukrDal.Update(gnkukr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnkukrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKUKR> Ncch_Delete_Log(GNKUKR gnkukr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNKUKR", gnkukr.Id, global);
            var sonuc = new StandardResponse<GNKUKR>();
            gnkukr.SIRKID = global.SirketId.Value; 
            gnkukr.ACTIVE = false;
            gnkukr.SLINDI = true;
            gnkukr.DEKULL = global.UserKod;
            gnkukr.DTARIH = DateTime.Now;
            gnkukr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnkukrDal.Update(gnkukr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<KullaniciKartModel> Ncch_GetKulKartList_NLog(Global global, string kulKod, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }

            var sonuc = new ListResponse<KullaniciKartModel>();
            var sql = @"select 
		                a.*,
		                h.TANIMI
		                from GNKUKR as a
		                left join GNTHRK as h on h.HARKOD=a.KARTKD and h.TIPKOD='036'
		                where a.SIRKID=@sirketId and a.ACTIVE=1 and a.SLINDI=0 and a.KULKOD=@kulKod";
            sonuc.Items = _gnkukrDal.GetListSqlQuery<KullaniciKartModel>(sql,
                new SqlParameter("sirketId", global.SirketId),
                new SqlParameter("kulKod", kulKod)
            );
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse Ncch_DashboardGuncelle_Log(Global global, List<KullaniciKartModel> model)
        {
            var sonuc = new StandardResponse();
            if (model == null || model.Count < 1)
            {
                sonuc.Message = "Gerekli bilgiler okunamadi!";
                sonuc.Status = ResponseStatusEnum.ERROR;
                return sonuc;
            }

            var list = new List<GNKUKR>();
            foreach (var item in model)
            {
                var entity = _gnkukrDal.Get(g => g.Id == item.Id);
                if (entity != null)
                {
                    entity.GNPOSI = item.GNPOSI;
                    entity.SIRASI = item.SIRASI;
                    list.Add(entity);
                }
            }

            var response = _gnkukrDal.MultiUpdate(list);
            if (!response)
            {
                sonuc.Message = "Guncelleme sirasinda hata olustu!";
                sonuc.Status = ResponseStatusEnum.ERROR;
                return sonuc;
            }

            sonuc.Status = ResponseStatusEnum.OK;
            sonuc.Message = "Dashboard basarili bir sekilde guncellendi!";
            return sonuc;
        }
        #endregion ClientFunc
    }
}
