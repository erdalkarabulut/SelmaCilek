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
    public class WmsthrManager : IWmsthrService
    {
        private IWmsthrDal _wmsthrDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals

        #region ClientServices

        #endregion ClientServices


        public WmsthrManager(IWmsthrDal wmsthrDal,IGnService gnservice,ILockedService lockedservice)
        {
            _wmsthrDal = wmsthrDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<WMSTHR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMSTHR>();
            sonuc.Items = global.SirketId != null ? _wmsthrDal.GetList(x => x.SIRKID == global.SirketId) : _wmsthrDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMSTHR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMSTHR>();
            sonuc.Items = global.SirketId != null ? _wmsthrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _wmsthrDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMSTHR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMSTHR>();
            sonuc.Items = global.SirketId != null ? _wmsthrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _wmsthrDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMSTHR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMSTHR>();
            sonuc.Items = global.SirketId != null ? _wmsthrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _wmsthrDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMSTHR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMSTHR>();
            sonuc.Items = global.SirketId != null ? _wmsthrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _wmsthrDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<WMSTHR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<WMSTHR>();
            sonuc.Nesne = _wmsthrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<WMSTHR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("WMSTHR", id, global);
            var sonuc = new StandardResponse<WMSTHR>();
            sonuc.Nesne = _wmsthrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmsthrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMSTHR> Ncch_Add_NLog(WMSTHR wmsthr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<WMSTHR>();
            wmsthr.SIRKID = global.SirketId.Value; 
            wmsthr.EKKULL = global.UserKod;
            wmsthr.ETARIH = DateTime.Now;
            wmsthr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmsthrDal.Add(wmsthr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmsthrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMSTHR> Ncch_Update_Log(WMSTHR wmsthr,WMSTHR oldWmsthr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("WMSTHR", wmsthr.Id, global);
            var sonuc = new StandardResponse<WMSTHR>();
            wmsthr.SIRKID = global.SirketId.Value; 
            wmsthr.DEKULL = global.UserKod;
            wmsthr.DTARIH = DateTime.Now;
            wmsthr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmsthrDal.Update(wmsthr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmsthrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMSTHR> Ncch_UpdateAktifPasif_Log(WMSTHR wmsthr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<WMSTHR>();
            wmsthr.SIRKID = global.SirketId.Value; 
            wmsthr.ACTIVE = !wmsthr.ACTIVE;
            wmsthr.DEKULL = global.UserKod;
            wmsthr.DTARIH = DateTime.Now;
            wmsthr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmsthrDal.Update(wmsthr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmsthrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMSTHR> Ncch_Delete_Log(WMSTHR wmsthr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("WMSTHR", wmsthr.Id, global);
            var sonuc = new StandardResponse<WMSTHR>();
            wmsthr.SIRKID = global.SirketId.Value; 
            wmsthr.ACTIVE = false;
            wmsthr.SLINDI = true;
            wmsthr.DEKULL = global.UserKod;
            wmsthr.DTARIH = DateTime.Now;
            wmsthr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmsthrDal.Update(wmsthr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
