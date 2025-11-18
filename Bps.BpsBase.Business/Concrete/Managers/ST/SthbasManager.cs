using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.ST;
using Bps.BpsBase.Business.Abstract.ST;
using Bps.BpsBase.DataAccess.Abstract.ST;
using Bps.BpsBase.Entities.Concrete.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.ST
{
    public class SthbasManager : ISthbasService
    {
        private ISthbasDal _sthbasDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public SthbasManager(ISthbasDal sthbasDal,IGnService gnservice,ILockedService lockedservice)
        {
            _sthbasDal = sthbasDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STHBAS> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STHBAS>();
            sonuc.Items = global.SirketId != null ? _sthbasDal.GetList(x => x.SIRKID == global.SirketId) : _sthbasDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STHBAS> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STHBAS>();
            sonuc.Items = global.SirketId != null ? _sthbasDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _sthbasDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STHBAS> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STHBAS>();
            sonuc.Items = global.SirketId != null ? _sthbasDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _sthbasDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STHBAS> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STHBAS>();
            sonuc.Items = global.SirketId != null ? _sthbasDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _sthbasDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STHBAS> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STHBAS>();
            sonuc.Items = global.SirketId != null ? _sthbasDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _sthbasDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STHBAS> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STHBAS>();
            sonuc.Nesne = _sthbasDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STHBAS> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STHBAS", id, global);
            var sonuc = new StandardResponse<STHBAS>();
            sonuc.Nesne = _sthbasDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SthbasValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STHBAS> Ncch_Add_NLog(STHBAS sthbas, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STHBAS>();
            sthbas.SIRKID = global.SirketId.Value; 
            sthbas.EKKULL = global.UserKod;
            sthbas.ETARIH = DateTime.Now;
            sthbas.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sthbasDal.Add(sthbas);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SthbasValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STHBAS> Ncch_Update_Log(STHBAS sthbas,STHBAS oldSthbas, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STHBAS", sthbas.Id, global);
            var sonuc = new StandardResponse<STHBAS>();
            sthbas.SIRKID = global.SirketId.Value; 
            sthbas.DEKULL = global.UserKod;
            sthbas.DTARIH = DateTime.Now;
            sthbas.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sthbasDal.Update(sthbas);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SthbasValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STHBAS> Ncch_UpdateAktifPasif_Log(STHBAS sthbas, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STHBAS>();
            sthbas.SIRKID = global.SirketId.Value; 
            sthbas.ACTIVE = !sthbas.ACTIVE;
            sthbas.DEKULL = global.UserKod;
            sthbas.DTARIH = DateTime.Now;
            sthbas.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sthbasDal.Update(sthbas);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SthbasValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STHBAS> Ncch_Delete_Log(STHBAS sthbas, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STHBAS", sthbas.Id, global);
            var sonuc = new StandardResponse<STHBAS>();
            sthbas.SIRKID = global.SirketId.Value; 
            sthbas.ACTIVE = false;
            sthbas.SLINDI = true;
            sthbas.DEKULL = global.UserKod;
            sthbas.DTARIH = DateTime.Now;
            sthbas.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sthbasDal.Update(sthbas);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc
        public StandardResponse<STHBAS> Ncch_GetByBelgeNo_NLog(string belgeNo, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STHBAS>();
            sonuc.Nesne = _sthbasDal.Get(x => x.BELGEN == belgeNo && x.SIRKID == global.SirketId && x.ACTIVE && !x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        #endregion ClientFunc
    }
}
