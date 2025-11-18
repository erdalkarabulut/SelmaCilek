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
using System.Linq;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.FY
{
    public class FyshopifyvariantManager : IFyshopifyvariantService
    {
        private IFyshopifyvariantDal _fyshopifyvariantDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public FyshopifyvariantManager(IFyshopifyvariantDal fyshopifyvariantDal,IGnService gnservice,ILockedService lockedservice)
        {
            _fyshopifyvariantDal = fyshopifyvariantDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<FYShopifyVariant> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyVariant>();
            sonuc.Items = global.SirketId != null ? _fyshopifyvariantDal.GetList(x => x.SIRKID == global.SirketId) : _fyshopifyvariantDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyVariant> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyVariant>();
            sonuc.Items = global.SirketId != null ? _fyshopifyvariantDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _fyshopifyvariantDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyVariant> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyVariant>();
            sonuc.Items = global.SirketId != null ? _fyshopifyvariantDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _fyshopifyvariantDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyVariant> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyVariant>();
            sonuc.Items = global.SirketId != null ? _fyshopifyvariantDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _fyshopifyvariantDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyVariant> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyVariant>();
            sonuc.Items = global.SirketId != null ? _fyshopifyvariantDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _fyshopifyvariantDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<FYShopifyVariant> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<FYShopifyVariant>();
            sonuc.Nesne = _fyshopifyvariantDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<FYShopifyVariant> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("FYShopifyVariant", id, global);
            var sonuc = new StandardResponse<FYShopifyVariant>();
            sonuc.Nesne = _fyshopifyvariantDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyvariantValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyVariant> Ncch_Add_NLog(FYShopifyVariant fyshopifyvariant, Global global)
        {
            //var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            //if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<FYShopifyVariant>();
            fyshopifyvariant.SIRKID = global.SirketId.Value; 
            fyshopifyvariant.EKKULL = global.UserKod;
            fyshopifyvariant.ETARIH = DateTime.Now;
            fyshopifyvariant.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyvariantDal.Add(fyshopifyvariant);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyvariantValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyVariant> Ncch_Update_Log(FYShopifyVariant fyshopifyvariant,FYShopifyVariant oldFyshopifyvariant, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            //if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            // _lockedService.LockControlWrite("FYShopifyVariant", fyshopifyvariant.Id, global);
            var sonuc = new StandardResponse<FYShopifyVariant>();
            fyshopifyvariant.SIRKID = global.SirketId.Value; 
            fyshopifyvariant.DEKULL = global.UserKod;
            fyshopifyvariant.DTARIH = DateTime.Now;
            fyshopifyvariant.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyvariantDal.Update(fyshopifyvariant);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyvariantValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyVariant> Ncch_UpdateAktifPasif_Log(FYShopifyVariant fyshopifyvariant, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<FYShopifyVariant>();
            fyshopifyvariant.SIRKID = global.SirketId.Value; 
            fyshopifyvariant.ACTIVE = !fyshopifyvariant.ACTIVE;
            fyshopifyvariant.DEKULL = global.UserKod;
            fyshopifyvariant.DTARIH = DateTime.Now;
            fyshopifyvariant.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyvariantDal.Update(fyshopifyvariant);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyvariantValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyVariant> Ncch_Delete_Log(FYShopifyVariant fyshopifyvariant, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("FYShopifyVariant", fyshopifyvariant.Id, global);
            var sonuc = new StandardResponse<FYShopifyVariant>();
            fyshopifyvariant.SIRKID = global.SirketId.Value; 
            fyshopifyvariant.ACTIVE = false;
            fyshopifyvariant.SLINDI = true;
            fyshopifyvariant.DEKULL = global.UserKod;
            fyshopifyvariant.DTARIH = DateTime.Now;
            fyshopifyvariant.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyvariantDal.Update(fyshopifyvariant);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc
        [FluentValidationAspect(typeof(FyshopifyvariantValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse Ncch_MultiDelete_Log(List<FYShopifyVariant> fyshopifyvariant, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            //if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            //_lockedService.LockControlWrite("GNYETB", gnyetb.Id, global);
            var sonuc = new StandardResponse();


            bool _ok = _fyshopifyvariantDal.MultiDelete(fyshopifyvariant);
            if (_ok)
            {
                sonuc.Status = ResponseStatusEnum.OK;
            }
            else
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
            }

            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyvariantValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse Ncch_MultiAdd_Log(List<FYShopifyVariant> fyshopifyvariant, Global global)
        {
            string crkodu = "";
            if (global.shopName == "selmacilek")
            {
                crkodu = "FY0000001";
            }
            else
            {
                crkodu = "FY0000002";

            }
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            //if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            //_lockedService.LockControlWrite("GNYETB", gnyetb.Id, global);
            var sonuc = new StandardResponse();
            foreach (var item in fyshopifyvariant)
            {
                item.SIRKID = (int)global.SirketId;
                item.EKKULL = global.UserKod;
                item.ETARIH = DateTime.Now;
                item.KYNKKD = global.KaynakKod;
                item.ACTIVE = true;
                item.CRKODU = crkodu;
            }

            bool _ok = _fyshopifyvariantDal.MultiAdd(fyshopifyvariant);
            if (_ok)
            {
                sonuc.Status = ResponseStatusEnum.OK;
            }
            else
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
            }

            return sonuc;
        }
        public StandardResponse<DateTime> Ncch_Get_Max_UpdateTime_NLog(Global global,string crkodu, bool yetkiKontrol = false)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyVariant>();
            sonuc.Items = global.SirketId != null ? _fyshopifyvariantDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.CRKODU == crkodu) : _fyshopifyvariantDal.GetList(x => x.SLINDI == false && x.CRKODU == crkodu);
            var sonuc1 = new StandardResponse<DateTime>();
            if (sonuc.Items.Count == 0)
            {
                sonuc1.Nesne = Convert.ToDateTime("01.01.1900");
            }
            else
            {
                sonuc1.Nesne = (DateTime)sonuc.Items.Max(x => x.updated_at);
            }
            return sonuc1;
        }
        public StandardResponse<FYShopifyVariant> Cch_GetByCId_NLog(string cid, Global global, bool yetkiKontrol = true)
        {
            string crkodu = "";
            if (global.shopName == "selmacilek")
            {
                crkodu = "FY0000001";
            }
            else
            {
                crkodu = "FY0000002";

            }
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<FYShopifyVariant>();
            sonuc.Nesne = _fyshopifyvariantDal.Get(x => x.Cid == cid && x.CRKODU == crkodu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        public ListResponse<FYShopifyVariant> NCch_GetList_CrKodu_NLog(Global global,string crkodu, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyVariant>();
            sonuc.Items = global.SirketId != null ? _fyshopifyvariantDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.CRKODU == crkodu) 
                : _fyshopifyvariantDal.GetList(x => x.SLINDI == false && x.CRKODU == crkodu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        public ListResponse<FYShopifyVariant> NCch_GetList_Product_NLog(Global global, string product,string crkodu, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyVariant>();
            sonuc.Items = global.SirketId != null ? _fyshopifyvariantDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.product_id == product && x.CRKODU == crkodu)
                : _fyshopifyvariantDal.GetList(x => x.SLINDI == false && x.product_id == product && x.CRKODU == crkodu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyVariant> Cch_GetListCid_NLog(string cid, Global global, bool yetkiKontrol = true)
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
            var sonuc = new ListResponse<FYShopifyVariant>();
            sonuc.Items = global.SirketId != null ? _fyshopifyvariantDal.GetList(x => x.product_id == cid && x.SIRKID == global.SirketId && x.SLINDI == false && x.CRKODU == crkodu) :
                _fyshopifyvariantDal.GetList(x => x.product_id == cid && x.SLINDI == false && x.CRKODU == crkodu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        #endregion ClientFunc
    }
}
