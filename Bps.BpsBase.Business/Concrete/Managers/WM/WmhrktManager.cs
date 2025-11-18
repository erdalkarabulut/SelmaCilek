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
    public class WmhrktManager : IWmhrktService
    {
        private IWmhrktDal _wmhrktDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public WmhrktManager(IWmhrktDal wmhrktDal,IGnService gnservice,ILockedService lockedservice)
        {
            _wmhrktDal = wmhrktDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<WMHRKT> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMHRKT>();
            sonuc.Items = global.SirketId != null ? _wmhrktDal.GetList(x => x.SIRKID == global.SirketId) : _wmhrktDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMHRKT> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMHRKT>();
            sonuc.Items = global.SirketId != null ? _wmhrktDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _wmhrktDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMHRKT> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMHRKT>();
            sonuc.Items = global.SirketId != null ? _wmhrktDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _wmhrktDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMHRKT> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMHRKT>();
            sonuc.Items = global.SirketId != null ? _wmhrktDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _wmhrktDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<WMHRKT> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<WMHRKT>();
            sonuc.Items = global.SirketId != null ? _wmhrktDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _wmhrktDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<WMHRKT> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<WMHRKT>();
            sonuc.Nesne = _wmhrktDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<WMHRKT> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("WMHRKT", id, global);
            var sonuc = new StandardResponse<WMHRKT>();
            sonuc.Nesne = _wmhrktDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmhrktValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMHRKT> Ncch_Add_NLog(WMHRKT wmhrkt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<WMHRKT>();
            wmhrkt.SIRKID = global.SirketId.Value; 
            wmhrkt.EKKULL = global.UserKod;
            wmhrkt.ETARIH = DateTime.Now;
            wmhrkt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmhrktDal.Add(wmhrkt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmhrktValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMHRKT> Ncch_Update_Log(WMHRKT wmhrkt,WMHRKT oldWmhrkt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("WMHRKT", wmhrkt.Id, global);
            var sonuc = new StandardResponse<WMHRKT>();
            wmhrkt.SIRKID = global.SirketId.Value; 
            wmhrkt.DEKULL = global.UserKod;
            wmhrkt.DTARIH = DateTime.Now;
            wmhrkt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmhrktDal.Update(wmhrkt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmhrktValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMHRKT> Ncch_UpdateAktifPasif_Log(WMHRKT wmhrkt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<WMHRKT>();
            wmhrkt.SIRKID = global.SirketId.Value; 
            wmhrkt.ACTIVE = !wmhrkt.ACTIVE;
            wmhrkt.DEKULL = global.UserKod;
            wmhrkt.DTARIH = DateTime.Now;
            wmhrkt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmhrktDal.Update(wmhrkt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(WmhrktValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<WMHRKT> Ncch_Delete_Log(WMHRKT wmhrkt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("WMHRKT", wmhrkt.Id, global);
            var sonuc = new StandardResponse<WMHRKT>();
            wmhrkt.SIRKID = global.SirketId.Value; 
            wmhrkt.ACTIVE = false;
            wmhrkt.SLINDI = true;
            wmhrkt.DEKULL = global.UserKod;
            wmhrkt.DTARIH = DateTime.Now;
            wmhrkt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _wmhrktDal.Update(wmhrkt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
