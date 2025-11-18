using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.SN;
using Bps.BpsBase.Business.Abstract.SN;
using Bps.BpsBase.DataAccess.Abstract.SN;
using Bps.BpsBase.Entities.Concrete.SN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.SN
{
    public class SnsnkrManager : ISnsnkrService
    {
        private ISnsnkrDal _snsnkrDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public SnsnkrManager(ISnsnkrDal snsnkrDal,IGnService gnservice,ILockedService lockedservice)
        {
            _snsnkrDal = snsnkrDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<SNSNKR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNSNKR>();
            sonuc.Items = global.SirketId != null ? _snsnkrDal.GetList(x => x.SIRKID == global.SirketId) : _snsnkrDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SNSNKR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNSNKR>();
            sonuc.Items = global.SirketId != null ? _snsnkrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _snsnkrDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SNSNKR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNSNKR>();
            sonuc.Items = global.SirketId != null ? _snsnkrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _snsnkrDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SNSNKR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNSNKR>();
            sonuc.Items = global.SirketId != null ? _snsnkrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _snsnkrDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SNSNKR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNSNKR>();
            sonuc.Items = global.SirketId != null ? _snsnkrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _snsnkrDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SNSNKR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<SNSNKR>();
            sonuc.Nesne = _snsnkrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SNSNKR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("SNSNKR", id, global);
            var sonuc = new StandardResponse<SNSNKR>();
            sonuc.Nesne = _snsnkrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SnsnkrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SNSNKR> Ncch_Add_NLog(SNSNKR snsnkr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SNSNKR>();
            snsnkr.SIRKID = global.SirketId.Value; 
            snsnkr.EKKULL = global.UserKod;
            snsnkr.ETARIH = DateTime.Now;
            snsnkr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _snsnkrDal.Add(snsnkr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SnsnkrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SNSNKR> Ncch_Update_Log(SNSNKR snsnkr,SNSNKR oldSnsnkr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SNSNKR", snsnkr.Id, global);
            var sonuc = new StandardResponse<SNSNKR>();
            snsnkr.SIRKID = global.SirketId.Value; 
            snsnkr.DEKULL = global.UserKod;
            snsnkr.DTARIH = DateTime.Now;
            snsnkr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _snsnkrDal.Update(snsnkr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SnsnkrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SNSNKR> Ncch_UpdateAktifPasif_Log(SNSNKR snsnkr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SNSNKR>();
            snsnkr.SIRKID = global.SirketId.Value; 
            snsnkr.ACTIVE = !snsnkr.ACTIVE;
            snsnkr.DEKULL = global.UserKod;
            snsnkr.DTARIH = DateTime.Now;
            snsnkr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _snsnkrDal.Update(snsnkr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SnsnkrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SNSNKR> Ncch_Delete_Log(SNSNKR snsnkr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SNSNKR", snsnkr.Id, global);
            var sonuc = new StandardResponse<SNSNKR>();
            snsnkr.SIRKID = global.SirketId.Value; 
            snsnkr.ACTIVE = false;
            snsnkr.SLINDI = true;
            snsnkr.DEKULL = global.UserKod;
            snsnkr.DTARIH = DateTime.Now;
            snsnkr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _snsnkrDal.Update(snsnkr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
