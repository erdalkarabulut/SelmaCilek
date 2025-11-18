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
    public class IsrvhrManager : IIsrvhrService
    {
        private IIsrvhrDal _isrvhrDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public IsrvhrManager(IIsrvhrDal isrvhrDal,IGnService gnservice,ILockedService lockedservice)
        {
            _isrvhrDal = isrvhrDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<ISRVHR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISRVHR>();
            sonuc.Items = global.SirketId != null ? _isrvhrDal.GetList(x => x.SIRKID == global.SirketId) : _isrvhrDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISRVHR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISRVHR>();
            sonuc.Items = global.SirketId != null ? _isrvhrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _isrvhrDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISRVHR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISRVHR>();
            sonuc.Items = global.SirketId != null ? _isrvhrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _isrvhrDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISRVHR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISRVHR>();
            sonuc.Items = global.SirketId != null ? _isrvhrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _isrvhrDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISRVHR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISRVHR>();
            sonuc.Items = global.SirketId != null ? _isrvhrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _isrvhrDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<ISRVHR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<ISRVHR>();
            sonuc.Nesne = _isrvhrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<ISRVHR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("ISRVHR", id, global);
            var sonuc = new StandardResponse<ISRVHR>();
            sonuc.Nesne = _isrvhrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsrvhrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISRVHR> Ncch_Add_NLog(ISRVHR isrvhr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<ISRVHR>();
            isrvhr.SIRKID = global.SirketId.Value; 
            isrvhr.EKKULL = global.UserKod;
            isrvhr.ETARIH = DateTime.Now;
            isrvhr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isrvhrDal.Add(isrvhr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsrvhrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISRVHR> Ncch_Update_Log(ISRVHR isrvhr,ISRVHR oldIsrvhr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("ISRVHR", isrvhr.Id, global);
            var sonuc = new StandardResponse<ISRVHR>();
            isrvhr.SIRKID = global.SirketId.Value; 
            isrvhr.DEKULL = global.UserKod;
            isrvhr.DTARIH = DateTime.Now;
            isrvhr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isrvhrDal.Update(isrvhr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsrvhrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISRVHR> Ncch_UpdateAktifPasif_Log(ISRVHR isrvhr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<ISRVHR>();
            isrvhr.SIRKID = global.SirketId.Value; 
            isrvhr.ACTIVE = !isrvhr.ACTIVE;
            isrvhr.DEKULL = global.UserKod;
            isrvhr.DTARIH = DateTime.Now;
            isrvhr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isrvhrDal.Update(isrvhr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsrvhrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISRVHR> Ncch_Delete_Log(ISRVHR isrvhr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("ISRVHR", isrvhr.Id, global);
            var sonuc = new StandardResponse<ISRVHR>();
            isrvhr.SIRKID = global.SirketId.Value; 
            isrvhr.ACTIVE = false;
            isrvhr.SLINDI = true;
            isrvhr.DEKULL = global.UserKod;
            isrvhr.DTARIH = DateTime.Now;
            isrvhr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isrvhrDal.Update(isrvhr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
