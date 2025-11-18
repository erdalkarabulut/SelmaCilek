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
    public class GnklopManager : IGnklopService
    {
        private IGnklopDal _gnklopDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GnklopManager(IGnklopDal gnklopDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnklopDal = gnklopDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNKLOP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKLOP>();
            sonuc.Items = global.SirketId != null ? _gnklopDal.GetList(x => x.SIRKID == global.SirketId) : _gnklopDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKLOP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKLOP>();
            sonuc.Items = global.SirketId != null ? _gnklopDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnklopDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKLOP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKLOP>();
            sonuc.Items = global.SirketId != null ? _gnklopDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnklopDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKLOP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKLOP>();
            sonuc.Items = global.SirketId != null ? _gnklopDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnklopDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKLOP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKLOP>();
            sonuc.Items = global.SirketId != null ? _gnklopDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnklopDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNKLOP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNKLOP>();
            sonuc.Nesne = _gnklopDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNKLOP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNKLOP", id, global);
            var sonuc = new StandardResponse<GNKLOP>();
            sonuc.Nesne = _gnklopDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnklopValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKLOP> Ncch_Add_NLog(GNKLOP gnklop, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNKLOP>();
            gnklop.SIRKID = global.SirketId.Value; 
            gnklop.EKKULL = global.UserKod;
            gnklop.ETARIH = DateTime.Now;
            gnklop.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnklopDal.Add(gnklop);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnklopValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKLOP> Ncch_Update_Log(GNKLOP gnklop,GNKLOP oldGnklop, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNKLOP", gnklop.Id, global);
            var sonuc = new StandardResponse<GNKLOP>();
            gnklop.SIRKID = global.SirketId.Value; 
            gnklop.DEKULL = global.UserKod;
            gnklop.DTARIH = DateTime.Now;
            gnklop.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnklopDal.Update(gnklop);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnklopValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKLOP> Ncch_UpdateAktifPasif_Log(GNKLOP gnklop, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNKLOP>();
            gnklop.SIRKID = global.SirketId.Value; 
            gnklop.ACTIVE = !gnklop.ACTIVE;
            gnklop.DEKULL = global.UserKod;
            gnklop.DTARIH = DateTime.Now;
            gnklop.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnklopDal.Update(gnklop);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnklopValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKLOP> Ncch_Delete_Log(GNKLOP gnklop, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNKLOP", gnklop.Id, global);
            var sonuc = new StandardResponse<GNKLOP>();
            gnklop.SIRKID = global.SirketId.Value; 
            gnklop.ACTIVE = false;
            gnklop.SLINDI = true;
            gnklop.DEKULL = global.UserKod;
            gnklop.DTARIH = DateTime.Now;
            gnklop.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnklopDal.Update(gnklop);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<GNKLOP> Ncch_GetListByPersonelId_NLog(int personelId, Global global, bool yetkiKontrol = true)
        {
	        if (yetkiKontrol)
	        {
		        var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
		        if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
	        }
	        var sonuc = new ListResponse<GNKLOP>();
	        sonuc.Items = global.SirketId != null ? _gnklopDal.GetList(x => x.PERSID == personelId && x.SIRKID == global.SirketId && x.ACTIVE && !x.SLINDI) 
		        : _gnklopDal.GetList(x => x.PERSID == personelId && x.ACTIVE == true && x.SLINDI == false);
	        sonuc.Status = ResponseStatusEnum.OK;
	        return sonuc;
        }

        #endregion ClientFunc
    }
}
