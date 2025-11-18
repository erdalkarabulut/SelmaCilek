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
    public class IsyrtnManager : IIsyrtnService
    {
        private IIsyrtnDal _isyrtnDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public IsyrtnManager(IIsyrtnDal isyrtnDal,IGnService gnservice,ILockedService lockedservice)
        {
            _isyrtnDal = isyrtnDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<ISYRTN> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISYRTN>();
            sonuc.Items = global.SirketId != null ? _isyrtnDal.GetList(x => x.SIRKID == global.SirketId) : _isyrtnDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISYRTN> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISYRTN>();
            sonuc.Items = global.SirketId != null ? _isyrtnDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _isyrtnDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISYRTN> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISYRTN>();
            sonuc.Items = global.SirketId != null ? _isyrtnDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _isyrtnDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISYRTN> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISYRTN>();
            sonuc.Items = global.SirketId != null ? _isyrtnDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _isyrtnDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISYRTN> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISYRTN>();
            sonuc.Items = global.SirketId != null ? _isyrtnDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _isyrtnDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<ISYRTN> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<ISYRTN>();
            sonuc.Nesne = _isyrtnDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<ISYRTN> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("ISYRTN", id, global);
            var sonuc = new StandardResponse<ISYRTN>();
            sonuc.Nesne = _isyrtnDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsyrtnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISYRTN> Ncch_Add_NLog(ISYRTN isyrtn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<ISYRTN>();
            isyrtn.SIRKID = global.SirketId.Value; 
            isyrtn.EKKULL = global.UserKod;
            isyrtn.ETARIH = DateTime.Now;
            isyrtn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isyrtnDal.Add(isyrtn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsyrtnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISYRTN> Ncch_Update_Log(ISYRTN isyrtn,ISYRTN oldIsyrtn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("ISYRTN", isyrtn.Id, global);
            var sonuc = new StandardResponse<ISYRTN>();
            isyrtn.SIRKID = global.SirketId.Value; 
            isyrtn.DEKULL = global.UserKod;
            isyrtn.DTARIH = DateTime.Now;
            isyrtn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isyrtnDal.Update(isyrtn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsyrtnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISYRTN> Ncch_UpdateAktifPasif_Log(ISYRTN isyrtn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<ISYRTN>();
            isyrtn.SIRKID = global.SirketId.Value; 
            isyrtn.ACTIVE = !isyrtn.ACTIVE;
            isyrtn.DEKULL = global.UserKod;
            isyrtn.DTARIH = DateTime.Now;
            isyrtn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isyrtnDal.Update(isyrtn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsyrtnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISYRTN> Ncch_Delete_Log(ISYRTN isyrtn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("ISYRTN", isyrtn.Id, global);
            var sonuc = new StandardResponse<ISYRTN>();
            isyrtn.SIRKID = global.SirketId.Value; 
            isyrtn.ACTIVE = false;
            isyrtn.SLINDI = true;
            isyrtn.DEKULL = global.UserKod;
            isyrtn.DTARIH = DateTime.Now;
            isyrtn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isyrtnDal.Update(isyrtn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
