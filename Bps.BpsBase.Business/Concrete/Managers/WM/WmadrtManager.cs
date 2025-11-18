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
    public class WmadrtManager : IWmadrtService
    {
        private IWmadrtDal _wmadrtDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public WmadrtManager(IWmadrtDal wmadrtDal,IGnService gnservice,ILockedService lockedservice)
        {
            _wmadrtDal = wmadrtDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<WMADRT> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMADRT>();
            sonuc.Items = global.SirketId != null ? _wmadrtDal.GetList(x => x.SIRKID == global.SirketId) : _wmadrtDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMADRT> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMADRT>();
            sonuc.Items = global.SirketId != null ? _wmadrtDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _wmadrtDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMADRT> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMADRT>();
            sonuc.Items = global.SirketId != null ? _wmadrtDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _wmadrtDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMADRT> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMADRT>();
            sonuc.Items = global.SirketId != null ? _wmadrtDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _wmadrtDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMADRT> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMADRT>();
            sonuc.Items = global.SirketId != null ? _wmadrtDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _wmadrtDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<WMADRT> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<WMADRT>();
            sonuc.Nesne = _wmadrtDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<WMADRT> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("WMADRT", id, global);
            var sonuc = new StandardResponse<WMADRT>();
            sonuc.Nesne = _wmadrtDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmadrtValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMADRT> Ncch_Add_NLog(WMADRT wmadrt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<WMADRT>();
            wmadrt.SIRKID = global.SirketId.Value; 
            wmadrt.EKKULL = global.UserKod;
            wmadrt.ETARIH = DateTime.Now;
            wmadrt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmadrtDal.Add(wmadrt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmadrtValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMADRT> Ncch_Update_Log(WMADRT wmadrt,WMADRT oldWmadrt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("WMADRT", wmadrt.Id, global);
            var sonuc = new StandardResponse<WMADRT>();
            wmadrt.SIRKID = global.SirketId.Value; 
            wmadrt.DEKULL = global.UserKod;
            wmadrt.DTARIH = DateTime.Now;
            wmadrt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmadrtDal.Update(wmadrt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmadrtValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMADRT> Ncch_UpdateAktifPasif_Log(WMADRT wmadrt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<WMADRT>();
            wmadrt.SIRKID = global.SirketId.Value; 
            wmadrt.ACTIVE = !wmadrt.ACTIVE;
            wmadrt.DEKULL = global.UserKod;
            wmadrt.DTARIH = DateTime.Now;
            wmadrt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmadrtDal.Update(wmadrt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmadrtValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMADRT> Ncch_Delete_Log(WMADRT wmadrt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("WMADRT", wmadrt.Id, global);
            var sonuc = new StandardResponse<WMADRT>();
            wmadrt.SIRKID = global.SirketId.Value; 
            wmadrt.ACTIVE = false;
            wmadrt.SLINDI = true;
            wmadrt.DEKULL = global.UserKod;
            wmadrt.DTARIH = DateTime.Now;
            wmadrt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmadrtDal.Update(wmadrt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<WMADRT> Cch_GetListByDepoKd_NLog(string depoKd, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMADRT>();
            sonuc.Items =
                _wmadrtDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.DEPOKD == depoKd);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<WMADRT> Cch_GetListByDepoKdDpAdrs_NLog(string depoKd, string dpAdrs, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<WMADRT>();
            sonuc.Nesne = _wmadrtDal.Get(x => x.SIRKID == global.SirketId && x.DEPOKD == depoKd && x.DPADRS == dpAdrs && x.ACTIVE);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
