using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.GN;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.DataAccess.Abstract.GN;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GnoptpManager : IGnoptpService
    {
        private IGnoptpDal _gnoptpDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GnoptpManager(IGnoptpDal gnoptpDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnoptpDal = gnoptpDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNOPTP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNOPTP>();
            sonuc.Items = global.SirketId != null ? _gnoptpDal.GetList(x => x.SIRKID == global.SirketId) : _gnoptpDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNOPTP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNOPTP>();
            sonuc.Items = global.SirketId != null ? _gnoptpDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnoptpDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNOPTP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNOPTP>();
            sonuc.Items = global.SirketId != null ? _gnoptpDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnoptpDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNOPTP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNOPTP>();
            sonuc.Items = global.SirketId != null ? _gnoptpDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnoptpDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNOPTP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNOPTP>();
            sonuc.Items = global.SirketId != null ? _gnoptpDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnoptpDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNOPTP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNOPTP>();
            sonuc.Nesne = _gnoptpDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNOPTP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNOPTP", id, global);
            var sonuc = new StandardResponse<GNOPTP>();
            sonuc.Nesne = _gnoptpDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnoptpValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNOPTP> Ncch_Add_NLog(GNOPTP gnoptp, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNOPTP>();
            gnoptp.SIRKID = global.SirketId.Value; 
            gnoptp.EKKULL = global.UserKod;
            gnoptp.ETARIH = DateTime.Now;
            gnoptp.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnoptpDal.Add(gnoptp);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnoptpValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNOPTP> Ncch_Update_Log(GNOPTP gnoptp,GNOPTP oldGnoptp, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNOPTP", gnoptp.Id, global);
            var sonuc = new StandardResponse<GNOPTP>();
            gnoptp.SIRKID = global.SirketId.Value; 
            gnoptp.DEKULL = global.UserKod;
            gnoptp.DTARIH = DateTime.Now;
            gnoptp.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnoptpDal.Update(gnoptp);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnoptpValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNOPTP> Ncch_UpdateAktifPasif_Log(GNOPTP gnoptp, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNOPTP>();
            gnoptp.SIRKID = global.SirketId.Value; 
            gnoptp.ACTIVE = !gnoptp.ACTIVE;
            gnoptp.DEKULL = global.UserKod;
            gnoptp.DTARIH = DateTime.Now;
            gnoptp.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnoptpDal.Update(gnoptp);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnoptpValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNOPTP> Ncch_Delete_Log(GNOPTP gnoptp, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNOPTP", gnoptp.Id, global);
            var sonuc = new StandardResponse<GNOPTP>();
            gnoptp.SIRKID = global.SirketId.Value; 
            gnoptp.ACTIVE = false;
            gnoptp.SLINDI = true;
            gnoptp.DEKULL = global.UserKod;
            gnoptp.DTARIH = DateTime.Now;
            gnoptp.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnoptpDal.Update(gnoptp);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<GNOPTP> Ncch_GetListByUstTipKod_NLog(Global global, string utpkod, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }

            var sonuc = new ListResponse<GNOPTP>();
            sonuc.Items = _gnoptpDal.GetList(x => x.UTPKOD == utpkod && x.ACTIVE && !x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNOPTP> Ncch_GetByTeknikAd_NLog(Global global, string teknad, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }

            var sonuc = new StandardResponse<GNOPTP>();
            sonuc.Nesne = _gnoptpDal.Get(x => x.TEKNAD == teknad && x.ACTIVE && !x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        #endregion ClientFunc
    }
}
