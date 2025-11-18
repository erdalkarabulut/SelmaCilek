using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.IS;
using Bps.BpsBase.Business.Abstract.IS;
using Bps.BpsBase.DataAccess.Abstract.IS;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.IS
{
    public class IsyropManager : IIsyropService
    {
        private IIsyropDal _isyropDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public IsyropManager(IIsyropDal isyropDal,IGnService gnservice,ILockedService lockedservice)
        {
            _isyropDal = isyropDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<ISYROP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISYROP>();
            sonuc.Items = global.SirketId != null ? _isyropDal.GetList(x => x.SIRKID == global.SirketId) : _isyropDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISYROP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISYROP>();
            sonuc.Items = global.SirketId != null ? _isyropDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _isyropDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISYROP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISYROP>();
            sonuc.Items = global.SirketId != null ? _isyropDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _isyropDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISYROP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISYROP>();
            sonuc.Items = global.SirketId != null ? _isyropDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _isyropDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISYROP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISYROP>();
            sonuc.Items = global.SirketId != null ? _isyropDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _isyropDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<ISYROP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<ISYROP>();
            sonuc.Nesne = _isyropDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<ISYROP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("ISYROP", id, global);
            var sonuc = new StandardResponse<ISYROP>();
            sonuc.Nesne = _isyropDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsyropValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISYROP> Ncch_Add_NLog(ISYROP isyrop, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<ISYROP>();
            isyrop.SIRKID = global.SirketId.Value; 
            isyrop.EKKULL = global.UserKod;
            isyrop.ETARIH = DateTime.Now;
            isyrop.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isyropDal.Add(isyrop);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsyropValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISYROP> Ncch_Update_Log(ISYROP isyrop,ISYROP oldIsyrop, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("ISYROP", isyrop.Id, global);
            var sonuc = new StandardResponse<ISYROP>();
            isyrop.SIRKID = global.SirketId.Value; 
            isyrop.DEKULL = global.UserKod;
            isyrop.DTARIH = DateTime.Now;
            isyrop.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isyropDal.Update(isyrop);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsyropValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISYROP> Ncch_UpdateAktifPasif_Log(ISYROP isyrop, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<ISYROP>();
            isyrop.SIRKID = global.SirketId.Value; 
            isyrop.ACTIVE = !isyrop.ACTIVE;
            isyrop.DEKULL = global.UserKod;
            isyrop.DTARIH = DateTime.Now;
            isyrop.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isyropDal.Update(isyrop);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsyropValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISYROP> Ncch_Delete_Log(ISYROP isyrop, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("ISYROP", isyrop.Id, global);
            var sonuc = new StandardResponse<ISYROP>();
            isyrop.SIRKID = global.SirketId.Value; 
            isyrop.ACTIVE = false;
            isyrop.SLINDI = true;
            isyrop.DEKULL = global.UserKod;
            isyrop.DTARIH = DateTime.Now;
            isyrop.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isyropDal.Update(isyrop);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<ISYROP> Ncch_GetListByIsyeriId_NLog(int isyeriId, Global global, bool yetkiKontrol = true)
        {
	        if (yetkiKontrol)
	        {
		        var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
		        if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
	        }
	        var sonuc = new ListResponse<ISYROP>();
	        sonuc.Items = global.SirketId != null ? _isyropDal.GetList(x => x.ISYRID == isyeriId && x.SIRKID == global.SirketId && x.ACTIVE && !x.SLINDI) : _isyropDal.GetList(x => x.ISYRID == isyeriId && x.ACTIVE == true && x.SLINDI == false);
	        sonuc.Status = ResponseStatusEnum.OK;
	        return sonuc;
        }

        #endregion ClientFunc
    }
}
