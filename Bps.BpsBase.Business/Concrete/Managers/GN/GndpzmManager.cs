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
    public class GndpzmManager : IGndpzmService
    {
        private IGndpzmDal _gndpzmDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GndpzmManager(IGndpzmDal gndpzmDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gndpzmDal = gndpzmDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNDPZM> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPZM>();
            sonuc.Items = global.SirketId != null ? _gndpzmDal.GetList(x => x.SIRKID == global.SirketId) : _gndpzmDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNDPZM> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPZM>();
            sonuc.Items = global.SirketId != null ? _gndpzmDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gndpzmDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNDPZM> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPZM>();
            sonuc.Items = global.SirketId != null ? _gndpzmDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gndpzmDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNDPZM> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPZM>();
            sonuc.Items = global.SirketId != null ? _gndpzmDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gndpzmDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNDPZM> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPZM>();
            sonuc.Items = global.SirketId != null ? _gndpzmDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gndpzmDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNDPZM> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNDPZM>();
            sonuc.Nesne = _gndpzmDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNDPZM> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNDPZM", id, global);
            var sonuc = new StandardResponse<GNDPZM>();
            sonuc.Nesne = _gndpzmDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GndpzmValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNDPZM> Ncch_Add_NLog(GNDPZM gndpzm, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNDPZM>();
            gndpzm.SIRKID = global.SirketId.Value; 
            gndpzm.EKKULL = global.UserKod;
            gndpzm.ETARIH = DateTime.Now;
            gndpzm.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gndpzmDal.Add(gndpzm);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GndpzmValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNDPZM> Ncch_Update_Log(GNDPZM gndpzm,GNDPZM oldGndpzm, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNDPZM", gndpzm.Id, global);
            var sonuc = new StandardResponse<GNDPZM>();
            gndpzm.SIRKID = global.SirketId.Value; 
            gndpzm.DEKULL = global.UserKod;
            gndpzm.DTARIH = DateTime.Now;
            gndpzm.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gndpzmDal.Update(gndpzm);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GndpzmValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNDPZM> Ncch_UpdateAktifPasif_Log(GNDPZM gndpzm, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNDPZM>();
            gndpzm.SIRKID = global.SirketId.Value; 
            gndpzm.ACTIVE = !gndpzm.ACTIVE;
            gndpzm.DEKULL = global.UserKod;
            gndpzm.DTARIH = DateTime.Now;
            gndpzm.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gndpzmDal.Update(gndpzm);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GndpzmValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNDPZM> Ncch_Delete_Log(GNDPZM gndpzm, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNDPZM", gndpzm.Id, global);
            var sonuc = new StandardResponse<GNDPZM>();
            gndpzm.SIRKID = global.SirketId.Value; 
            gndpzm.ACTIVE = false;
            gndpzm.SLINDI = true;
            gndpzm.DEKULL = global.UserKod;
            gndpzm.DTARIH = DateTime.Now;
            gndpzm.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gndpzmDal.Update(gndpzm);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<GNDPZM> Ncch_GetPersonelMobilDepoList_NLog(Global global, int personelId, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPZM>();
            sonuc.Items = global.SirketId != null ? _gndpzmDal.GetList(x => x.SIRKID == global.SirketId && x.PERSID == personelId && x.MOBILE && !x.SLINDI) :
                _gndpzmDal.GetList(x => x.PERSID == personelId && x.MOBILE && !x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNDPZM> Ncch_GetByPersonelId_NLog(int personelId, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPZM>();
            sonuc.Items = global.SirketId != null ? _gndpzmDal.GetList(x => x.SIRKID == global.SirketId && x.PERSID == personelId && !x.SLINDI) :
                _gndpzmDal.GetList(x => x.PERSID == personelId && !x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        #endregion ClientFunc
    }
}
