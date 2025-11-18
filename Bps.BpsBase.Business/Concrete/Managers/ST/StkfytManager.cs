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

using System.Linq;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.ST
{
    public class StkfytManager : IStkfytService
    {
        private IStkfytDal _stkfytDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public StkfytManager(IStkfytDal stkfytDal,IGnService gnservice,ILockedService lockedservice)
        {
            _stkfytDal = stkfytDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STKFYT> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKFYT>();
            sonuc.Items = global.SirketId != null ? _stkfytDal.GetList(x => x.SIRKID == global.SirketId) : _stkfytDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKFYT> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKFYT>();
            sonuc.Items = global.SirketId != null ? _stkfytDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stkfytDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKFYT> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKFYT>();
            sonuc.Items = global.SirketId != null ? _stkfytDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stkfytDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKFYT> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKFYT>();
            sonuc.Items = global.SirketId != null ? _stkfytDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stkfytDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKFYT> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKFYT>();
            sonuc.Items = global.SirketId != null ? _stkfytDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stkfytDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STKFYT> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STKFYT>();
            sonuc.Nesne = _stkfytDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STKFYT> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STKFYT", id, global);
            var sonuc = new StandardResponse<STKFYT>();
            sonuc.Nesne = _stkfytDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StkfytValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STKFYT> Ncch_Add_NLog(STKFYT stkfyt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STKFYT>();
            stkfyt.SIRKID = global.SirketId.Value; 
            stkfyt.EKKULL = global.UserKod;
            stkfyt.ETARIH = DateTime.Now;
            stkfyt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stkfytDal.Add(stkfyt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StkfytValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STKFYT> Ncch_Update_Log(STKFYT stkfyt,STKFYT oldStkfyt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STKFYT", stkfyt.Id, global);
            var sonuc = new StandardResponse<STKFYT>();
            stkfyt.SIRKID = global.SirketId.Value; 
            stkfyt.DEKULL = global.UserKod;
            stkfyt.DTARIH = DateTime.Now;
            stkfyt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stkfytDal.Update(stkfyt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StkfytValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STKFYT> Ncch_UpdateAktifPasif_Log(STKFYT stkfyt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STKFYT>();
            stkfyt.SIRKID = global.SirketId.Value; 
            stkfyt.ACTIVE = !stkfyt.ACTIVE;
            stkfyt.DEKULL = global.UserKod;
            stkfyt.DTARIH = DateTime.Now;
            stkfyt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stkfytDal.Update(stkfyt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StkfytValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STKFYT> Ncch_Delete_Log(STKFYT stkfyt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STKFYT", stkfyt.Id, global);
            var sonuc = new StandardResponse<STKFYT>();
            stkfyt.SIRKID = global.SirketId.Value; 
            stkfyt.ACTIVE = false;
            stkfyt.SLINDI = true;
            stkfyt.DEKULL = global.UserKod;
            stkfyt.DTARIH = DateTime.Now;
            stkfyt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stkfytDal.Update(stkfyt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public StandardResponse<STKFYT> Ncch_GetByFiyatNo_NLog(string fiyatNo, Global global, bool yetkiKontrol = true)
        {
	        if (yetkiKontrol)
	        {
		        var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
		        if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
	        }
	        var sonuc = new StandardResponse<STKFYT>();
	        sonuc.Nesne = _stkfytDal.Get(x => x.STFYNO == fiyatNo);
	        sonuc.Status = ResponseStatusEnum.OK;
	        return sonuc;
        }

        public ListResponse<STKFYT> Cch_GetListByKdvFlag_NLog(bool kdvFlag, Global global,bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKFYT>();
            sonuc.Items = _stkfytDal.GetList(x =>
                x.SIRKID == global.SirketId && x.SLINDI == false && x.ACTIVE && x.KDVFLG == kdvFlag).ToList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKFYT> Ncch_GetListByStokHareketTip_NLog(int sthrtp, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKFYT>();
            sonuc.Items = _stkfytDal.GetList(x =>
                x.SIRKID == global.SirketId && x.SLINDI == false && x.ACTIVE && x.STHRTP == sthrtp).ToList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
