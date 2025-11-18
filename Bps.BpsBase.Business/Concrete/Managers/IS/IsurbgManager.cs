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
    public class IsurbgManager : IIsurbgService
    {
        private IIsurbgDal _isurbgDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public IsurbgManager(IIsurbgDal isurbgDal,IGnService gnservice,ILockedService lockedservice)
        {
            _isurbgDal = isurbgDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<ISURBG> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISURBG>();
            sonuc.Items = global.SirketId != null ? _isurbgDal.GetList(x => x.SIRKID == global.SirketId) : _isurbgDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISURBG> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISURBG>();
            sonuc.Items = global.SirketId != null ? _isurbgDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _isurbgDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISURBG> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISURBG>();
            sonuc.Items = global.SirketId != null ? _isurbgDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _isurbgDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISURBG> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISURBG>();
            sonuc.Items = global.SirketId != null ? _isurbgDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _isurbgDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISURBG> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISURBG>();
            sonuc.Items = global.SirketId != null ? _isurbgDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _isurbgDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<ISURBG> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<ISURBG>();
            sonuc.Nesne = _isurbgDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<ISURBG> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("ISURBG", id, global);
            var sonuc = new StandardResponse<ISURBG>();
            sonuc.Nesne = _isurbgDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsurbgValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISURBG> Ncch_Add_NLog(ISURBG isurbg, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<ISURBG>();
            isurbg.SIRKID = global.SirketId.Value; 
            isurbg.EKKULL = global.UserKod;
            isurbg.ETARIH = DateTime.Now;
            isurbg.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isurbgDal.Add(isurbg);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsurbgValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISURBG> Ncch_Update_Log(ISURBG isurbg,ISURBG oldIsurbg, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("ISURBG", isurbg.Id, global);
            var sonuc = new StandardResponse<ISURBG>();
            isurbg.SIRKID = global.SirketId.Value; 
            isurbg.DEKULL = global.UserKod;
            isurbg.DTARIH = DateTime.Now;
            isurbg.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isurbgDal.Update(isurbg);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsurbgValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISURBG> Ncch_UpdateAktifPasif_Log(ISURBG isurbg, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<ISURBG>();
            isurbg.SIRKID = global.SirketId.Value; 
            isurbg.ACTIVE = !isurbg.ACTIVE;
            isurbg.DEKULL = global.UserKod;
            isurbg.DTARIH = DateTime.Now;
            isurbg.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isurbgDal.Update(isurbg);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsurbgValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISURBG> Ncch_Delete_Log(ISURBG isurbg, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("ISURBG", isurbg.Id, global);
            var sonuc = new StandardResponse<ISURBG>();
            isurbg.SIRKID = global.SirketId.Value; 
            isurbg.ACTIVE = false;
            isurbg.SLINDI = true;
            isurbg.DEKULL = global.UserKod;
            isurbg.DTARIH = DateTime.Now;
            isurbg.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isurbgDal.Update(isurbg);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
