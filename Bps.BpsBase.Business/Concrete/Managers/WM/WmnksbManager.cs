using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.WM;
using Bps.BpsBase.Business.Abstract.WM;
using Bps.BpsBase.DataAccess.Abstract.WM;
using Bps.BpsBase.Entities.Concrete.WM;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.WM
{
    public class WmnksbManager : IWmnksbService
    {
        private IWmnksbDal _wmnksbDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public WmnksbManager(IWmnksbDal wmnksbDal,IGnService gnservice,ILockedService lockedservice)
        {
            _wmnksbDal = wmnksbDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<WMNKSB> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMNKSB>();
            sonuc.Items = global.SirketId != null ? _wmnksbDal.GetList(x => x.SIRKID == global.SirketId) : _wmnksbDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMNKSB> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMNKSB>();
            sonuc.Items = global.SirketId != null ? _wmnksbDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _wmnksbDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMNKSB> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMNKSB>();
            sonuc.Items = global.SirketId != null ? _wmnksbDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _wmnksbDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMNKSB> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMNKSB>();
            sonuc.Items = global.SirketId != null ? _wmnksbDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _wmnksbDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMNKSB> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMNKSB>();
            sonuc.Items = global.SirketId != null ? _wmnksbDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _wmnksbDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<WMNKSB> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<WMNKSB>();
            sonuc.Nesne = _wmnksbDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<WMNKSB> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("WMNKSB", id, global);
            var sonuc = new StandardResponse<WMNKSB>();
            sonuc.Nesne = _wmnksbDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmnksbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMNKSB> Ncch_Add_NLog(WMNKSB wmnksb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<WMNKSB>();
            wmnksb.SIRKID = global.SirketId.Value; 
            wmnksb.EKKULL = global.UserKod;
            wmnksb.ETARIH = DateTime.Now;
            wmnksb.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmnksbDal.Add(wmnksb);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmnksbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMNKSB> Ncch_Update_Log(WMNKSB wmnksb,WMNKSB oldWmnksb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("WMNKSB", wmnksb.Id, global);
            var sonuc = new StandardResponse<WMNKSB>();
            wmnksb.SIRKID = global.SirketId.Value; 
            wmnksb.DEKULL = global.UserKod;
            wmnksb.DTARIH = DateTime.Now;
            wmnksb.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmnksbDal.Update(wmnksb);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmnksbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMNKSB> Ncch_UpdateAktifPasif_Log(WMNKSB wmnksb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<WMNKSB>();
            wmnksb.SIRKID = global.SirketId.Value; 
            wmnksb.ACTIVE = !wmnksb.ACTIVE;
            wmnksb.DEKULL = global.UserKod;
            wmnksb.DTARIH = DateTime.Now;
            wmnksb.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmnksbDal.Update(wmnksb);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmnksbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMNKSB> Ncch_Delete_Log(WMNKSB wmnksb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("WMNKSB", wmnksb.Id, global);
            var sonuc = new StandardResponse<WMNKSB>();
            wmnksb.SIRKID = global.SirketId.Value; 
            wmnksb.ACTIVE = false;
            wmnksb.SLINDI = true;
            wmnksb.DEKULL = global.UserKod;
            wmnksb.DTARIH = DateTime.Now;
            wmnksb.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmnksbDal.Update(wmnksb);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
