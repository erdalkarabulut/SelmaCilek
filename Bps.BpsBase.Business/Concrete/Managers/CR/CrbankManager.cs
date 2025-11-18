using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.CR;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.DataAccess.Abstract.CR;
using Bps.BpsBase.Entities.Concrete.CR;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.CR
{
    public class CrbankManager : ICrbankService
    {
        private ICrbankDal _crbankDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public CrbankManager(ICrbankDal crbankDal,IGnService gnservice,ILockedService lockedservice)
        {
            _crbankDal = crbankDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<CRBANK> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRBANK>();
            sonuc.Items = global.SirketId != null ? _crbankDal.GetList(x => x.SIRKID == global.SirketId) : _crbankDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRBANK> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRBANK>();
            sonuc.Items = global.SirketId != null ? _crbankDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _crbankDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRBANK> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRBANK>();
            sonuc.Items = global.SirketId != null ? _crbankDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _crbankDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRBANK> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRBANK>();
            sonuc.Items = global.SirketId != null ? _crbankDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _crbankDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRBANK> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRBANK>();
            sonuc.Items = global.SirketId != null ? _crbankDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _crbankDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<CRBANK> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<CRBANK>();
            sonuc.Nesne = _crbankDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<CRBANK> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("CRBANK", id, global);
            var sonuc = new StandardResponse<CRBANK>();
            sonuc.Nesne = _crbankDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CrbankValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRBANK> Ncch_Add_NLog(CRBANK crbank, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<CRBANK>();
            crbank.SIRKID = global.SirketId.Value; 
            crbank.EKKULL = global.UserKod;
            crbank.ETARIH = DateTime.Now;
            crbank.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _crbankDal.Add(crbank);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CrbankValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRBANK> Ncch_Update_Log(CRBANK crbank,CRBANK oldCrbank, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("CRBANK", crbank.Id, global);
            var sonuc = new StandardResponse<CRBANK>();
            crbank.SIRKID = global.SirketId.Value; 
            crbank.DEKULL = global.UserKod;
            crbank.DTARIH = DateTime.Now;
            crbank.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _crbankDal.Update(crbank);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CrbankValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRBANK> Ncch_UpdateAktifPasif_Log(CRBANK crbank, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<CRBANK>();
            crbank.SIRKID = global.SirketId.Value; 
            crbank.ACTIVE = !crbank.ACTIVE;
            crbank.DEKULL = global.UserKod;
            crbank.DTARIH = DateTime.Now;
            crbank.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _crbankDal.Update(crbank);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CrbankValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRBANK> Ncch_Delete_Log(CRBANK crbank, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("CRBANK", crbank.Id, global);
            var sonuc = new StandardResponse<CRBANK>();
            crbank.SIRKID = global.SirketId.Value; 
            crbank.ACTIVE = false;
            crbank.SLINDI = true;
            crbank.DEKULL = global.UserKod;
            crbank.DTARIH = DateTime.Now;
            crbank.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _crbankDal.Update(crbank);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<CRBANK> Cch_GetListByCariKod_NLog(string cariKod, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }

            var sonuc = new ListResponse<CRBANK>();
            sonuc.Items = _crbankDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.CRKODU == cariKod);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
