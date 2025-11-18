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
    public class StoptmManager : IStoptmService
    {
        private IStoptmDal _stoptmDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public StoptmManager(IStoptmDal stoptmDal,IGnService gnservice,ILockedService lockedservice)
        {
            _stoptmDal = stoptmDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STOPTM> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STOPTM>();
            sonuc.Items = global.SirketId != null ? _stoptmDal.GetList(x => x.SIRKID == global.SirketId) : _stoptmDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STOPTM> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STOPTM>();
            sonuc.Items = global.SirketId != null ? _stoptmDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stoptmDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STOPTM> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STOPTM>();
            sonuc.Items = global.SirketId != null ? _stoptmDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stoptmDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STOPTM> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STOPTM>();
            sonuc.Items = global.SirketId != null ? _stoptmDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stoptmDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STOPTM> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STOPTM>();
            sonuc.Items = global.SirketId != null ? _stoptmDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stoptmDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STOPTM> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STOPTM>();
            sonuc.Nesne = _stoptmDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STOPTM> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STOPTM", id, global);
            var sonuc = new StandardResponse<STOPTM>();
            sonuc.Nesne = _stoptmDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StoptmValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STOPTM> Ncch_Add_NLog(STOPTM stoptm, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STOPTM>();
            stoptm.SIRKID = global.SirketId.Value; 
            stoptm.EKKULL = global.UserKod;
            stoptm.ETARIH = DateTime.Now;
            stoptm.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stoptmDal.Add(stoptm);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StoptmValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STOPTM> Ncch_Update_Log(STOPTM stoptm,STOPTM oldStoptm, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STOPTM", stoptm.Id, global);
            var sonuc = new StandardResponse<STOPTM>();
            stoptm.SIRKID = global.SirketId.Value; 
            stoptm.DEKULL = global.UserKod;
            stoptm.DTARIH = DateTime.Now;
            stoptm.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stoptmDal.Update(stoptm);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StoptmValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STOPTM> Ncch_UpdateAktifPasif_Log(STOPTM stoptm, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STOPTM>();
            stoptm.SIRKID = global.SirketId.Value; 
            stoptm.ACTIVE = !stoptm.ACTIVE;
            stoptm.DEKULL = global.UserKod;
            stoptm.DTARIH = DateTime.Now;
            stoptm.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stoptmDal.Update(stoptm);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StoptmValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STOPTM> Ncch_Delete_Log(STOPTM stoptm, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STOPTM", stoptm.Id, global);
            var sonuc = new StandardResponse<STOPTM>();
            stoptm.SIRKID = global.SirketId.Value; 
            stoptm.ACTIVE = false;
            stoptm.SLINDI = true;
            stoptm.DEKULL = global.UserKod;
            stoptm.DTARIH = DateTime.Now;
            stoptm.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stoptmDal.Update(stoptm);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STOPTM> Ncch_GetByBelgeNo_NLog(string belgeNo, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STOPTM>();
            sonuc.Nesne = _stoptmDal.Get(x => x.MCBELG == belgeNo || x.MGBELG == belgeNo);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
