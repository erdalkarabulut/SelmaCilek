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
    public class SnkrtyManager : ISnkrtyService
    {
        private ISnkrtyDal _snkrtyDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public SnkrtyManager(ISnkrtyDal snkrtyDal,IGnService gnservice,ILockedService lockedservice)
        {
            _snkrtyDal = snkrtyDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<SNKRTY> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNKRTY>();
            sonuc.Items = global.SirketId != null ? _snkrtyDal.GetList(x => x.SIRKID == global.SirketId) : _snkrtyDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SNKRTY> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNKRTY>();
            sonuc.Items = global.SirketId != null ? _snkrtyDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _snkrtyDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SNKRTY> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNKRTY>();
            sonuc.Items = global.SirketId != null ? _snkrtyDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _snkrtyDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SNKRTY> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNKRTY>();
            sonuc.Items = global.SirketId != null ? _snkrtyDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _snkrtyDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SNKRTY> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNKRTY>();
            sonuc.Items = global.SirketId != null ? _snkrtyDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _snkrtyDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SNKRTY> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<SNKRTY>();
            sonuc.Nesne = _snkrtyDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SNKRTY> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("SNKRTY", id, global);
            var sonuc = new StandardResponse<SNKRTY>();
            sonuc.Nesne = _snkrtyDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SnkrtyValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SNKRTY> Ncch_Add_NLog(SNKRTY snkrty, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SNKRTY>();
            snkrty.SIRKID = global.SirketId.Value; 
            snkrty.EKKULL = global.UserKod;
            snkrty.ETARIH = DateTime.Now;
            snkrty.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _snkrtyDal.Add(snkrty);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SnkrtyValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SNKRTY> Ncch_Update_Log(SNKRTY snkrty,SNKRTY oldSnkrty, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SNKRTY", snkrty.Id, global);
            var sonuc = new StandardResponse<SNKRTY>();
            snkrty.SIRKID = global.SirketId.Value; 
            snkrty.DEKULL = global.UserKod;
            snkrty.DTARIH = DateTime.Now;
            snkrty.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _snkrtyDal.Update(snkrty);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SnkrtyValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SNKRTY> Ncch_UpdateAktifPasif_Log(SNKRTY snkrty, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SNKRTY>();
            snkrty.SIRKID = global.SirketId.Value; 
            snkrty.ACTIVE = !snkrty.ACTIVE;
            snkrty.DEKULL = global.UserKod;
            snkrty.DTARIH = DateTime.Now;
            snkrty.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _snkrtyDal.Update(snkrty);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SnkrtyValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SNKRTY> Ncch_Delete_Log(SNKRTY snkrty, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SNKRTY", snkrty.Id, global);
            var sonuc = new StandardResponse<SNKRTY>();
            snkrty.SIRKID = global.SirketId.Value; 
            snkrty.ACTIVE = false;
            snkrty.SLINDI = true;
            snkrty.DEKULL = global.UserKod;
            snkrty.DTARIH = DateTime.Now;
            snkrty.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _snkrtyDal.Update(snkrty);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
