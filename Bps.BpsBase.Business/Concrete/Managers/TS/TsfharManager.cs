using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.TS;
using Bps.BpsBase.Business.Abstract.TS;
using Bps.BpsBase.DataAccess.Abstract.TS;
using Bps.BpsBase.Entities.Concrete.TS;

#region ClientUsing

using System.Linq;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.TS
{
    public class TsfharManager : ITsfharService
    {
        private ITsfharDal _tsfharDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public TsfharManager(ITsfharDal tsfharDal,IGnService gnservice,ILockedService lockedservice)
        {
            _tsfharDal = tsfharDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<TSFHAR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TSFHAR>();
            sonuc.Items = global.SirketId != null ? _tsfharDal.GetList(x => x.SIRKID == global.SirketId) : _tsfharDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TSFHAR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TSFHAR>();
            sonuc.Items = global.SirketId != null ? _tsfharDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _tsfharDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TSFHAR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TSFHAR>();
            sonuc.Items = global.SirketId != null ? _tsfharDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _tsfharDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TSFHAR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TSFHAR>();
            sonuc.Items = global.SirketId != null ? _tsfharDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _tsfharDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TSFHAR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TSFHAR>();
            sonuc.Items = global.SirketId != null ? _tsfharDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _tsfharDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<TSFHAR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<TSFHAR>();
            sonuc.Nesne = _tsfharDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<TSFHAR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("TSFHAR", id, global);
            var sonuc = new StandardResponse<TSFHAR>();
            sonuc.Nesne = _tsfharDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(TsfharValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<TSFHAR> Ncch_Add_NLog(TSFHAR tsfhar, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<TSFHAR>();
            tsfhar.SIRKID = global.SirketId.Value; 
            tsfhar.EKKULL = global.UserKod;
            tsfhar.ETARIH = DateTime.Now;
            tsfhar.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _tsfharDal.Add(tsfhar);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(TsfharValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<TSFHAR> Ncch_Update_Log(TSFHAR tsfhar,TSFHAR oldTsfhar, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("TSFHAR", tsfhar.Id, global);
            var sonuc = new StandardResponse<TSFHAR>();
            tsfhar.SIRKID = global.SirketId.Value; 
            tsfhar.DEKULL = global.UserKod;
            tsfhar.DTARIH = DateTime.Now;
            tsfhar.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _tsfharDal.Update(tsfhar);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(TsfharValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<TSFHAR> Ncch_UpdateAktifPasif_Log(TSFHAR tsfhar, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<TSFHAR>();
            tsfhar.SIRKID = global.SirketId.Value; 
            tsfhar.ACTIVE = !tsfhar.ACTIVE;
            tsfhar.DEKULL = global.UserKod;
            tsfhar.DTARIH = DateTime.Now;
            tsfhar.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _tsfharDal.Update(tsfhar);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(TsfharValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<TSFHAR> Ncch_Delete_Log(TSFHAR tsfhar, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("TSFHAR", tsfhar.Id, global);
            var sonuc = new StandardResponse<TSFHAR>();
            tsfhar.SIRKID = global.SirketId.Value; 
            tsfhar.ACTIVE = false;
            tsfhar.SLINDI = true;
            tsfhar.DEKULL = global.UserKod;
            tsfhar.DTARIH = DateTime.Now;
            tsfhar.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _tsfharDal.Update(tsfhar);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<TSFHAR> Cch_GetListByBelge_NLog(string belgeNo, Global global)
        {
            var sonuc = new ListResponse<TSFHAR>();
            sonuc.Items = _tsfharDal.GetList(x =>
                x.SIRKID == global.SirketId && x.SLINDI == false && x.BELGEN == belgeNo).ToList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
