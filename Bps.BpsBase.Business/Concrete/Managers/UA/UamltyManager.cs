using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.UA;
using Bps.BpsBase.Business.Abstract.UA;
using Bps.BpsBase.DataAccess.Abstract.UA;
using Bps.BpsBase.Entities.Concrete.UA;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.UA
{
    public class UamltyManager : IUamltyService
    {
        private IUamltyDal _uamltyDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public UamltyManager(IUamltyDal uamltyDal,IGnService gnservice,ILockedService lockedservice)
        {
            _uamltyDal = uamltyDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<UAMLTY> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UAMLTY>();
            sonuc.Items = global.SirketId != null ? _uamltyDal.GetList(x => x.SIRKID == global.SirketId) : _uamltyDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UAMLTY> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UAMLTY>();
            sonuc.Items = global.SirketId != null ? _uamltyDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _uamltyDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UAMLTY> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UAMLTY>();
            sonuc.Items = global.SirketId != null ? _uamltyDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _uamltyDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UAMLTY> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UAMLTY>();
            sonuc.Items = global.SirketId != null ? _uamltyDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _uamltyDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UAMLTY> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UAMLTY>();
            sonuc.Items = global.SirketId != null ? _uamltyDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _uamltyDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<UAMLTY> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<UAMLTY>();
            sonuc.Nesne = _uamltyDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<UAMLTY> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("UAMLTY", id, global);
            var sonuc = new StandardResponse<UAMLTY>();
            sonuc.Nesne = _uamltyDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UamltyValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UAMLTY> Ncch_Add_NLog(UAMLTY uamlty, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<UAMLTY>();
            uamlty.SIRKID = global.SirketId.Value; 
            uamlty.EKKULL = global.UserKod;
            uamlty.ETARIH = DateTime.Now;
            uamlty.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uamltyDal.Add(uamlty);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UamltyValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UAMLTY> Ncch_Update_Log(UAMLTY uamlty,UAMLTY oldUamlty, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("UAMLTY", uamlty.Id, global);
            var sonuc = new StandardResponse<UAMLTY>();
            uamlty.SIRKID = global.SirketId.Value; 
            uamlty.DEKULL = global.UserKod;
            uamlty.DTARIH = DateTime.Now;
            uamlty.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uamltyDal.Update(uamlty);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UamltyValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UAMLTY> Ncch_UpdateAktifPasif_Log(UAMLTY uamlty, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<UAMLTY>();
            uamlty.SIRKID = global.SirketId.Value; 
            uamlty.ACTIVE = !uamlty.ACTIVE;
            uamlty.DEKULL = global.UserKod;
            uamlty.DTARIH = DateTime.Now;
            uamlty.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uamltyDal.Update(uamlty);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UamltyValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UAMLTY> Ncch_Delete_Log(UAMLTY uamlty, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("UAMLTY", uamlty.Id, global);
            var sonuc = new StandardResponse<UAMLTY>();
            uamlty.SIRKID = global.SirketId.Value; 
            uamlty.ACTIVE = false;
            uamlty.SLINDI = true;
            uamlty.DEKULL = global.UserKod;
            uamlty.DTARIH = DateTime.Now;
            uamlty.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uamltyDal.Update(uamlty);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<UAMLTY> Cch_GetListByUaKodAndMaltr_NLog(Global global, string uAKodu, string malzTuru, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UAMLTY>();
            sonuc.Items = global.SirketId != null
                ? _uamltyDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.UAKLNT == uAKodu && x.STMLTR == malzTuru)
                : _uamltyDal.GetList(x => x.SLINDI == false && x.UAKLNT == uAKodu && x.STMLTR == malzTuru);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
