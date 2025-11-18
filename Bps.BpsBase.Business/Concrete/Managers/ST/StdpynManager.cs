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
    public class StdpynManager : IStdpynService
    {
        private IStdpynDal _stdpynDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public StdpynManager(IStdpynDal stdpynDal,IGnService gnservice,ILockedService lockedservice)
        {
            _stdpynDal = stdpynDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STDPYN> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDPYN>();
            sonuc.Items = global.SirketId != null ? _stdpynDal.GetList(x => x.SIRKID == global.SirketId) : _stdpynDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STDPYN> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDPYN>();
            sonuc.Items = global.SirketId != null ? _stdpynDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stdpynDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STDPYN> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDPYN>();
            sonuc.Items = global.SirketId != null ? _stdpynDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stdpynDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STDPYN> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDPYN>();
            sonuc.Items = global.SirketId != null ? _stdpynDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stdpynDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STDPYN> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDPYN>();
            sonuc.Items = global.SirketId != null ? _stdpynDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stdpynDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STDPYN> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STDPYN>();
            sonuc.Nesne = _stdpynDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STDPYN> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STDPYN", id, global);
            var sonuc = new StandardResponse<STDPYN>();
            sonuc.Nesne = _stdpynDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StdpynValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STDPYN> Ncch_Add_NLog(STDPYN stdpyn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STDPYN>();
            stdpyn.SIRKID = global.SirketId.Value; 
            stdpyn.EKKULL = global.UserKod;
            stdpyn.ETARIH = DateTime.Now;
            stdpyn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stdpynDal.Add(stdpyn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StdpynValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STDPYN> Ncch_Update_Log(STDPYN stdpyn,STDPYN oldStdpyn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STDPYN", stdpyn.Id, global);
            var sonuc = new StandardResponse<STDPYN>();
            stdpyn.SIRKID = global.SirketId.Value; 
            stdpyn.DEKULL = global.UserKod;
            stdpyn.DTARIH = DateTime.Now;
            stdpyn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stdpynDal.Update(stdpyn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StdpynValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STDPYN> Ncch_UpdateAktifPasif_Log(STDPYN stdpyn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STDPYN>();
            stdpyn.SIRKID = global.SirketId.Value; 
            stdpyn.ACTIVE = !stdpyn.ACTIVE;
            stdpyn.DEKULL = global.UserKod;
            stdpyn.DTARIH = DateTime.Now;
            stdpyn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stdpynDal.Update(stdpyn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StdpynValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STDPYN> Ncch_Delete_Log(STDPYN stdpyn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STDPYN", stdpyn.Id, global);
            var sonuc = new StandardResponse<STDPYN>();
            stdpyn.SIRKID = global.SirketId.Value; 
            stdpyn.ACTIVE = false;
            stdpyn.SLINDI = true;
            stdpyn.DEKULL = global.UserKod;
            stdpyn.DTARIH = DateTime.Now;
            stdpyn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stdpynDal.Update(stdpyn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<STDPYN> Cch_GetListByStokKodu_NLog(string stokKodu, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDPYN>();
            sonuc.Items = global.SirketId != null ? _stdpynDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.ACTIVE && x.STKODU == stokKodu) : _stdpynDal.GetList(x => x.SLINDI == false && x.ACTIVE && x.STKODU == stokKodu);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
