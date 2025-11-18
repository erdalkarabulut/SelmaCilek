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

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.FY
{
    public class FyshopifyimageManager : IFyshopifyimageService
    {
        private IFyshopifyimageDal _fyshopifyimageDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public FyshopifyimageManager(IFyshopifyimageDal fyshopifyimageDal,IGnService gnservice,ILockedService lockedservice)
        {
            _fyshopifyimageDal = fyshopifyimageDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<FYShopifyImage> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyImage>();
            sonuc.Items = global.SirketId != null ? _fyshopifyimageDal.GetList(x => x.SIRKID == global.SirketId) : _fyshopifyimageDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyImage> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyImage>();
            sonuc.Items = global.SirketId != null ? _fyshopifyimageDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _fyshopifyimageDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyImage> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyImage>();
            sonuc.Items = global.SirketId != null ? _fyshopifyimageDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _fyshopifyimageDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyImage> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyImage>();
            sonuc.Items = global.SirketId != null ? _fyshopifyimageDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _fyshopifyimageDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyImage> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyImage>();
            sonuc.Items = global.SirketId != null ? _fyshopifyimageDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _fyshopifyimageDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<FYShopifyImage> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<FYShopifyImage>();
            sonuc.Nesne = _fyshopifyimageDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<FYShopifyImage> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("FYShopifyImage", id, global);
            var sonuc = new StandardResponse<FYShopifyImage>();
            sonuc.Nesne = _fyshopifyimageDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyimageValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyImage> Ncch_Add_NLog(FYShopifyImage fyshopifyimage, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<FYShopifyImage>();
            fyshopifyimage.SIRKID = global.SirketId.Value; 
            fyshopifyimage.EKKULL = global.UserKod;
            fyshopifyimage.ETARIH = DateTime.Now;
            fyshopifyimage.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyimageDal.Add(fyshopifyimage);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyimageValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyImage> Ncch_Update_Log(FYShopifyImage fyshopifyimage,FYShopifyImage oldFyshopifyimage, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("FYShopifyImage", fyshopifyimage.Id, global);
            var sonuc = new StandardResponse<FYShopifyImage>();
            fyshopifyimage.SIRKID = global.SirketId.Value; 
            fyshopifyimage.DEKULL = global.UserKod;
            fyshopifyimage.DTARIH = DateTime.Now;
            fyshopifyimage.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyimageDal.Update(fyshopifyimage);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyimageValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyImage> Ncch_UpdateAktifPasif_Log(FYShopifyImage fyshopifyimage, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<FYShopifyImage>();
            fyshopifyimage.SIRKID = global.SirketId.Value; 
            fyshopifyimage.ACTIVE = !fyshopifyimage.ACTIVE;
            fyshopifyimage.DEKULL = global.UserKod;
            fyshopifyimage.DTARIH = DateTime.Now;
            fyshopifyimage.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyimageDal.Update(fyshopifyimage);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyimageValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyImage> Ncch_Delete_Log(FYShopifyImage fyshopifyimage, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("FYShopifyImage", fyshopifyimage.Id, global);
            var sonuc = new StandardResponse<FYShopifyImage>();
            fyshopifyimage.SIRKID = global.SirketId.Value; 
            fyshopifyimage.ACTIVE = false;
            fyshopifyimage.SLINDI = true;
            fyshopifyimage.DEKULL = global.UserKod;
            fyshopifyimage.DTARIH = DateTime.Now;
            fyshopifyimage.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyimageDal.Update(fyshopifyimage);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc
        [FluentValidationAspect(typeof(FyshopifyvariantValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse Ncch_MultiDelete_Log(List<FYShopifyImage> fyshopifyimage, Global global)
        {
            //var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            //if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            //_lockedService.LockControlWrite("GNYETB", gnyetb.Id, global);
            var sonuc = new StandardResponse();


            bool _ok = _fyshopifyimageDal.MultiDelete(fyshopifyimage);
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
        public StandardResponse Ncch_MultiAdd_Log(List<FYShopifyImage> fyshopifyimage, Global global)
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
            foreach (var item in fyshopifyimage)
            {
                item.SIRKID = (int)global.SirketId; 
                item.EKKULL = global.UserKod;
                item.ETARIH = DateTime.Now;
                item.KYNKKD = global.KaynakKod;
                item.CRKODU = crkodu;
                item.ACTIVE = true;
            }

            bool _ok = _fyshopifyimageDal.MultiAdd(fyshopifyimage);
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

        public ListResponse<FYShopifyImage> Cch_GetListCid_NLog(string cid,Global global, bool yetkiKontrol = true)
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
            var sonuc = new ListResponse<FYShopifyImage>();
            sonuc.Items = global.SirketId != null ? _fyshopifyimageDal.GetList(x => x.product_id == cid && x.SIRKID == global.SirketId && x.SLINDI == false && x.CRKODU ==crkodu) : 
                _fyshopifyimageDal.GetList(x => x.product_id == cid && x.SLINDI == false && x.CRKODU == crkodu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        #endregion ClientFunc
    }
}
