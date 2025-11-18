using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.UA;
using Bps.BpsBase.Business.Abstract.UA;
using Bps.BpsBase.DataAccess.Abstract.UA;
using Bps.BpsBase.Entities.Concrete.UA;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.UA
{
    public class UakltnManager : IUakltnService
    {
        private IUakltnDal _uakltnDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public UakltnManager(IUakltnDal uakltnDal,IGnService gnservice,ILockedService lockedservice)
        {
            _uakltnDal = uakltnDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<UAKLTN> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UAKLTN>();
            sonuc.Items = global.SirketId != null ? _uakltnDal.GetList(x => x.SIRKID == global.SirketId) : _uakltnDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UAKLTN> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UAKLTN>();
            sonuc.Items = global.SirketId != null ? _uakltnDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _uakltnDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UAKLTN> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UAKLTN>();
            sonuc.Items = global.SirketId != null ? _uakltnDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _uakltnDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UAKLTN> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UAKLTN>();
            sonuc.Items = global.SirketId != null ? _uakltnDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _uakltnDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UAKLTN> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UAKLTN>();
            sonuc.Items = global.SirketId != null ? _uakltnDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _uakltnDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<UAKLTN> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<UAKLTN>();
            sonuc.Nesne = _uakltnDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<UAKLTN> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("UAKLTN", id, global);
            var sonuc = new StandardResponse<UAKLTN>();
            sonuc.Nesne = _uakltnDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UakltnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UAKLTN> Ncch_Add_NLog(UAKLTN uakltn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<UAKLTN>();
            uakltn.SIRKID = global.SirketId.Value; 
            uakltn.EKKULL = global.UserKod;
            uakltn.ETARIH = DateTime.Now;
            uakltn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uakltnDal.Add(uakltn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UakltnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UAKLTN> Ncch_Update_Log(UAKLTN uakltn,UAKLTN oldUakltn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("UAKLTN", uakltn.Id, global);
            var sonuc = new StandardResponse<UAKLTN>();
            uakltn.SIRKID = global.SirketId.Value; 
            uakltn.DEKULL = global.UserKod;
            uakltn.DTARIH = DateTime.Now;
            uakltn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uakltnDal.Update(uakltn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UakltnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UAKLTN> Ncch_UpdateAktifPasif_Log(UAKLTN uakltn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<UAKLTN>();
            uakltn.SIRKID = global.SirketId.Value; 
            uakltn.ACTIVE = !uakltn.ACTIVE;
            uakltn.DEKULL = global.UserKod;
            uakltn.DTARIH = DateTime.Now;
            uakltn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uakltnDal.Update(uakltn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UakltnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UAKLTN> Ncch_Delete_Log(UAKLTN uakltn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("UAKLTN", uakltn.Id, global);
            var sonuc = new StandardResponse<UAKLTN>();
            uakltn.SIRKID = global.SirketId.Value; 
            uakltn.ACTIVE = false;
            uakltn.SLINDI = true;
            uakltn.DEKULL = global.UserKod;
            uakltn.DTARIH = DateTime.Now;
            uakltn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uakltnDal.Update(uakltn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
