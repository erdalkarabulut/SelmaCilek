using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.IS;
using Bps.BpsBase.Business.Abstract.IS;
using Bps.BpsBase.DataAccess.Abstract.IS;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.IS
{
    public class IsplstManager : IIsplstService
    {
        private IIsplstDal _isplstDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public IsplstManager(IIsplstDal isplstDal,IGnService gnservice,ILockedService lockedservice)
        {
            _isplstDal = isplstDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<ISPLST> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISPLST>();
            sonuc.Items = global.SirketId != null ? _isplstDal.GetList(x => x.SIRKID == global.SirketId) : _isplstDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISPLST> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISPLST>();
            sonuc.Items = global.SirketId != null ? _isplstDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _isplstDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISPLST> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISPLST>();
            sonuc.Items = global.SirketId != null ? _isplstDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _isplstDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISPLST> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISPLST>();
            sonuc.Items = global.SirketId != null ? _isplstDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _isplstDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISPLST> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISPLST>();
            sonuc.Items = global.SirketId != null ? _isplstDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _isplstDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<ISPLST> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<ISPLST>();
            sonuc.Nesne = _isplstDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<ISPLST> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("ISPLST", id, global);
            var sonuc = new StandardResponse<ISPLST>();
            sonuc.Nesne = _isplstDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsplstValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISPLST> Ncch_Add_NLog(ISPLST isplst, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<ISPLST>();
            isplst.SIRKID = global.SirketId.Value; 
            isplst.EKKULL = global.UserKod;
            isplst.ETARIH = DateTime.Now;
            isplst.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isplstDal.Add(isplst);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsplstValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISPLST> Ncch_Update_Log(ISPLST isplst,ISPLST oldIsplst, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("ISPLST", isplst.Id, global);
            var sonuc = new StandardResponse<ISPLST>();
            isplst.SIRKID = global.SirketId.Value; 
            isplst.DEKULL = global.UserKod;
            isplst.DTARIH = DateTime.Now;
            isplst.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isplstDal.Update(isplst);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsplstValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISPLST> Ncch_UpdateAktifPasif_Log(ISPLST isplst, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<ISPLST>();
            isplst.SIRKID = global.SirketId.Value; 
            isplst.ACTIVE = !isplst.ACTIVE;
            isplst.DEKULL = global.UserKod;
            isplst.DTARIH = DateTime.Now;
            isplst.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isplstDal.Update(isplst);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsplstValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISPLST> Ncch_Delete_Log(ISPLST isplst, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("ISPLST", isplst.Id, global);
            var sonuc = new StandardResponse<ISPLST>();
            isplst.SIRKID = global.SirketId.Value; 
            isplst.ACTIVE = false;
            isplst.SLINDI = true;
            isplst.DEKULL = global.UserKod;
            isplst.DTARIH = DateTime.Now;
            isplst.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isplstDal.Update(isplst);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
