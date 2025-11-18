using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.FY;
using Bps.BpsBase.Business.Abstract.FY;
using Bps.BpsBase.DataAccess.Abstract.FY;
using Bps.BpsBase.Entities.Concrete.FY;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.FY
{
    public class FyshopifyoptionManager : IFyshopifyoptionService
    {
        private IFyshopifyoptionDal _fyshopifyoptionDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public FyshopifyoptionManager(IFyshopifyoptionDal fyshopifyoptionDal,IGnService gnservice,ILockedService lockedservice)
        {
            _fyshopifyoptionDal = fyshopifyoptionDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<FYShopifyOption> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyOption>();
            sonuc.Items = global.SirketId != null ? _fyshopifyoptionDal.GetList(x => x.SIRKID == global.SirketId) : _fyshopifyoptionDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyOption> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyOption>();
            sonuc.Items = global.SirketId != null ? _fyshopifyoptionDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _fyshopifyoptionDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyOption> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyOption>();
            sonuc.Items = global.SirketId != null ? _fyshopifyoptionDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _fyshopifyoptionDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyOption> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyOption>();
            sonuc.Items = global.SirketId != null ? _fyshopifyoptionDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _fyshopifyoptionDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyOption> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyOption>();
            sonuc.Items = global.SirketId != null ? _fyshopifyoptionDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _fyshopifyoptionDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<FYShopifyOption> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<FYShopifyOption>();
            sonuc.Nesne = _fyshopifyoptionDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<FYShopifyOption> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("FYShopifyOption", id, global);
            var sonuc = new StandardResponse<FYShopifyOption>();
            sonuc.Nesne = _fyshopifyoptionDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyoptionValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyOption> Ncch_Add_NLog(FYShopifyOption fyshopifyoption, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<FYShopifyOption>();
            fyshopifyoption.SIRKID = global.SirketId.Value; 
            fyshopifyoption.EKKULL = global.UserKod;
            fyshopifyoption.ETARIH = DateTime.Now;
            fyshopifyoption.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyoptionDal.Add(fyshopifyoption);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyoptionValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyOption> Ncch_Update_Log(FYShopifyOption fyshopifyoption,FYShopifyOption oldFyshopifyoption, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("FYShopifyOption", fyshopifyoption.Id, global);
            var sonuc = new StandardResponse<FYShopifyOption>();
            fyshopifyoption.SIRKID = global.SirketId.Value; 
            fyshopifyoption.DEKULL = global.UserKod;
            fyshopifyoption.DTARIH = DateTime.Now;
            fyshopifyoption.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyoptionDal.Update(fyshopifyoption);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyoptionValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyOption> Ncch_UpdateAktifPasif_Log(FYShopifyOption fyshopifyoption, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<FYShopifyOption>();
            fyshopifyoption.SIRKID = global.SirketId.Value; 
            fyshopifyoption.ACTIVE = !fyshopifyoption.ACTIVE;
            fyshopifyoption.DEKULL = global.UserKod;
            fyshopifyoption.DTARIH = DateTime.Now;
            fyshopifyoption.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyoptionDal.Update(fyshopifyoption);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyoptionValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyOption> Ncch_Delete_Log(FYShopifyOption fyshopifyoption, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("FYShopifyOption", fyshopifyoption.Id, global);
            var sonuc = new StandardResponse<FYShopifyOption>();
            fyshopifyoption.SIRKID = global.SirketId.Value; 
            fyshopifyoption.ACTIVE = false;
            fyshopifyoption.SLINDI = true;
            fyshopifyoption.DEKULL = global.UserKod;
            fyshopifyoption.DTARIH = DateTime.Now;
            fyshopifyoption.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyoptionDal.Update(fyshopifyoption);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
