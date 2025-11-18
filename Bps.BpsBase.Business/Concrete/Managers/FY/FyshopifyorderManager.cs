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
using System.Collections.Generic;
using System.Linq;
#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.FY
{
    public class FyshopifyorderManager : IFyshopifyorderService
    {
        private IFyshopifyorderDal _fyshopifyorderDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public FyshopifyorderManager(IFyshopifyorderDal fyshopifyorderDal,IGnService gnservice,ILockedService lockedservice)
        {
            _fyshopifyorderDal = fyshopifyorderDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<FYShopifyOrder> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyOrder>();
            sonuc.Items = global.SirketId != null ? _fyshopifyorderDal.GetList(x => x.SIRKID == global.SirketId) : _fyshopifyorderDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyOrder> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyOrder>();
            sonuc.Items = global.SirketId != null ? _fyshopifyorderDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _fyshopifyorderDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyOrder> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyOrder>();
            sonuc.Items = global.SirketId != null ? _fyshopifyorderDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _fyshopifyorderDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyOrder> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyOrder>();
            sonuc.Items = global.SirketId != null ? _fyshopifyorderDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _fyshopifyorderDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<FYShopifyOrder> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<FYShopifyOrder>();
            sonuc.Items = global.SirketId != null ? _fyshopifyorderDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _fyshopifyorderDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<FYShopifyOrder> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<FYShopifyOrder>();
            sonuc.Nesne = _fyshopifyorderDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<FYShopifyOrder> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("FYShopifyOrder", id, global);
            var sonuc = new StandardResponse<FYShopifyOrder>();
            sonuc.Nesne = _fyshopifyorderDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyorderValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyOrder> Ncch_Add_NLog(FYShopifyOrder fyshopifyorder, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<FYShopifyOrder>();
            fyshopifyorder.SIRKID = global.SirketId.Value; 
            fyshopifyorder.EKKULL = global.UserKod;
            fyshopifyorder.ETARIH = DateTime.Now;
            fyshopifyorder.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyorderDal.Add(fyshopifyorder);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyorderValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyOrder> Ncch_Update_Log(FYShopifyOrder fyshopifyorder,FYShopifyOrder oldFyshopifyorder, Global global)
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
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("FYShopifyOrder", fyshopifyorder.Id, global);
            var sonuc = new StandardResponse<FYShopifyOrder>();
            fyshopifyorder.SIRKID = global.SirketId.Value; 
            fyshopifyorder.DEKULL = global.UserKod;
            fyshopifyorder.DTARIH = DateTime.Now;
            fyshopifyorder.KYNKKD = global.KaynakKod;
            fyshopifyorder.CRKODU = crkodu;
            sonuc.Nesne = _fyshopifyorderDal.Update(fyshopifyorder);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyorderValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyOrder> Ncch_UpdateAktifPasif_Log(FYShopifyOrder fyshopifyorder, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<FYShopifyOrder>();
            fyshopifyorder.SIRKID = global.SirketId.Value; 
            fyshopifyorder.ACTIVE = !fyshopifyorder.ACTIVE;
            fyshopifyorder.DEKULL = global.UserKod;
            fyshopifyorder.DTARIH = DateTime.Now;
            fyshopifyorder.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyorderDal.Update(fyshopifyorder);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(FyshopifyorderValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<FYShopifyOrder> Ncch_Delete_Log(FYShopifyOrder fyshopifyorder, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("FYShopifyOrder", fyshopifyorder.Id, global);
            var sonuc = new StandardResponse<FYShopifyOrder>();
            fyshopifyorder.SIRKID = global.SirketId.Value; 
            fyshopifyorder.ACTIVE = false;
            fyshopifyorder.SLINDI = true;
            fyshopifyorder.DEKULL = global.UserKod;
            fyshopifyorder.DTARIH = DateTime.Now;
            fyshopifyorder.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _fyshopifyorderDal.Update(fyshopifyorder);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc
        public StandardResponse Ncch_MultiDelete_Log(List<FYShopifyOrder> fyshopifyorder, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            //if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            //_lockedService.LockControlWrite("GNYETB", gnyetb.Id, global);
            var sonuc = new StandardResponse();


            bool _ok = _fyshopifyorderDal.MultiDelete(fyshopifyorder);
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
        public StandardResponse Ncch_MultiAdd_Log(List<FYShopifyOrder> fyshopifyorder, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            //if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            //_lockedService.LockControlWrite("GNYETB", gnyetb.Id, global);
            var sonuc = new StandardResponse();
            foreach (var item in fyshopifyorder)
            {
                item.SIRKID = (int)global.SirketId;
                item.EKKULL = global.UserKod;
                item.ETARIH = DateTime.Now;
                item.KYNKKD = global.KaynakKod;
                item.ACTIVE = true;
            }

            bool _ok = _fyshopifyorderDal.MultiAdd(fyshopifyorder);
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
            var sonuc = new ListResponse<FYShopifyOrder>();
            sonuc.Items = global.SirketId != null ? _fyshopifyorderDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.CRKODU == crkodu) : _fyshopifyorderDal.GetList(x => x.SLINDI == false && x.CRKODU == crkodu);
            var sonuc1 = new StandardResponse<DateTime>();
            if (sonuc.Items.Count == 0)
            {
                sonuc1.Nesne = Convert.ToDateTime("10.03.2025");
            }
            else
            {
                sonuc1.Nesne = (DateTime)sonuc.Items.Max(x => x.Updated_at);
            }
            return sonuc1;
        }

        public StandardResponse<FYShopifyOrder> Cch_GetByCId_NLog(string cid, Global global, bool yetkiKontrol = true)
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
            var sonuc = new StandardResponse<FYShopifyOrder>();
            sonuc.Nesne = _fyshopifyorderDal.Get(x => x.Cid == cid && x.CRKODU == crkodu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        #endregion ClientFunc
    }
}
