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
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Linq;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.FY
{
    public class FyshopifyproductManager : IFyshopifyproductService
    {
        private IFyshopifyproductDal _fyshopifyproductDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public FyshopifyproductManager(IFyshopifyproductDal fyshopifyproductDal,IGnService gnservice,ILockedService lockedservice)
        {
            _fyshopifyproductDal = fyshopifyproductDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<FYShopifyProduct> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyProduct>();
            sonuc.Items = global.SirketId != null ? _fyshopifyproductDal.GetList(x => x.SIRKID == global.SirketId) : _fyshopifyproductDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyProduct> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyProduct>();
            sonuc.Items = global.SirketId != null ? _fyshopifyproductDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _fyshopifyproductDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyProduct> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyProduct>();
            sonuc.Items = global.SirketId != null ? _fyshopifyproductDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _fyshopifyproductDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyProduct> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyProduct>();
            sonuc.Items = global.SirketId != null ? _fyshopifyproductDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _fyshopifyproductDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyProduct> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyProduct>();
            sonuc.Items = global.SirketId != null ? _fyshopifyproductDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _fyshopifyproductDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<FYShopifyProduct> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<FYShopifyProduct>();
            sonuc.Nesne = _fyshopifyproductDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<FYShopifyProduct> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("FYShopifyProduct", id, global);
            var sonuc = new StandardResponse<FYShopifyProduct>();
            sonuc.Nesne = _fyshopifyproductDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyproductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyProduct> Ncch_Add_NLog(FYShopifyProduct fyshopifyproduct, Global global)
        {
            //var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            //if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            try
            {
                var sonuc = new StandardResponse<FYShopifyProduct>();
                fyshopifyproduct.SIRKID = global.SirketId.Value;
                fyshopifyproduct.EKKULL = global.UserKod;
                fyshopifyproduct.ETARIH = DateTime.Now;
                fyshopifyproduct.KYNKKD = global.KaynakKod;
                sonuc.Nesne = _fyshopifyproductDal.Add(fyshopifyproduct);
                sonuc.Status = ResponseStatusEnum.OK;
                return sonuc;
            }
            catch ( Exception ex)
            {

                return null;
            }
            
        }

        [FluentValidationAspect(typeof(FyshopifyproductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyProduct> Ncch_Update_Log(FYShopifyProduct fyshopifyproduct,FYShopifyProduct oldFyshopifyproduct, Global global)
        {
            //var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            //if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            // _lockedService.LockControlWrite("FYShopifyProduct", fyshopifyproduct.Id, global);
            var sonuc = new StandardResponse<FYShopifyProduct>();
            fyshopifyproduct.SIRKID = global.SirketId.Value; 
            fyshopifyproduct.DEKULL = global.UserKod;
            fyshopifyproduct.DTARIH = DateTime.Now;
            fyshopifyproduct.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyproductDal.Update(fyshopifyproduct);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyproductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyProduct> Ncch_UpdateAktifPasif_Log(FYShopifyProduct fyshopifyproduct, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<FYShopifyProduct>();
            fyshopifyproduct.SIRKID = global.SirketId.Value; 
            fyshopifyproduct.ACTIVE = !fyshopifyproduct.ACTIVE;
            fyshopifyproduct.DEKULL = global.UserKod;
            fyshopifyproduct.DTARIH = DateTime.Now;
            fyshopifyproduct.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyproductDal.Update(fyshopifyproduct);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyproductValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyProduct> Ncch_Delete_Log(FYShopifyProduct fyshopifyproduct, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("FYShopifyProduct", fyshopifyproduct.Id, global);
            var sonuc = new StandardResponse<FYShopifyProduct>();
            fyshopifyproduct.SIRKID = global.SirketId.Value; 
            fyshopifyproduct.ACTIVE = false;
            fyshopifyproduct.SLINDI = true;
            fyshopifyproduct.DEKULL = global.UserKod;
            fyshopifyproduct.DTARIH = DateTime.Now;
            fyshopifyproduct.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyproductDal.Update(fyshopifyproduct);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public StandardResponse<DateTime> Ncch_Get_Max_UpdateTime_NLog(Global global,string crkodu, bool yetkiKontrol = false)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyProduct>();
            sonuc.Items = global.SirketId != null ? _fyshopifyproductDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.CRKODU == crkodu) : 
                _fyshopifyproductDal.GetList(x => x.SLINDI == false && x.CRKODU == crkodu);
            var sonuc1 = new StandardResponse<DateTime>();
            if (sonuc.Items.Count == 0)
            {
                sonuc1.Nesne = Convert.ToDateTime("10.01.1980"); 
            }
            else
            {
                sonuc1.Nesne = (DateTime)sonuc.Items.Max(x => x.updated_at);
            }
            return sonuc1;
        }

        public StandardResponse<FYShopifyProduct> Cch_GetByCId_NLog(string cid, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            string crkodu = "";
            if (global.shopName == "selmacilek")
            {
                crkodu = "FY0000001";
            }
            else
            {
                crkodu = "FY0000002";

            }
            var sonuc = new StandardResponse<FYShopifyProduct>();
            sonuc.Nesne = _fyshopifyproductDal.Get(x => x.Cid == cid && x.CRKODU == crkodu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        public ListResponse<FYShopifyProduct> NCch_GetList_CrKodu_NLog(Global global,string crkodu, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyProduct>();
            sonuc.Items = global.SirketId != null ? _fyshopifyproductDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.CRKODU == crkodu && x.status == "active") 
                : _fyshopifyproductDal.GetList(x => x.SLINDI == false && x.CRKODU == crkodu && x.status == "active");
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
