using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.SN;
using Bps.BpsBase.Business.Abstract.SN;
using Bps.BpsBase.DataAccess.Abstract.SN;
using Bps.BpsBase.Entities.Concrete.SN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.SN
{
    public class SntynnManager : ISntynnService
    {
        private ISntynnDal _sntynnDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public SntynnManager(ISntynnDal sntynnDal,IGnService gnservice,ILockedService lockedservice)
        {
            _sntynnDal = sntynnDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<SNTYNN> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNTYNN>();
            sonuc.Items = global.SirketId != null ? _sntynnDal.GetList(x => x.SIRKID == global.SirketId) : _sntynnDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SNTYNN> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNTYNN>();
            sonuc.Items = global.SirketId != null ? _sntynnDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _sntynnDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SNTYNN> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNTYNN>();
            sonuc.Items = global.SirketId != null ? _sntynnDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _sntynnDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SNTYNN> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNTYNN>();
            sonuc.Items = global.SirketId != null ? _sntynnDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _sntynnDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SNTYNN> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNTYNN>();
            sonuc.Items = global.SirketId != null ? _sntynnDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _sntynnDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SNTYNN> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<SNTYNN>();
            sonuc.Nesne = _sntynnDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SNTYNN> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("SNTYNN", id, global);
            var sonuc = new StandardResponse<SNTYNN>();
            sonuc.Nesne = _sntynnDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SntynnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SNTYNN> Ncch_Add_NLog(SNTYNN sntynn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SNTYNN>();
            sntynn.SIRKID = global.SirketId.Value; 
            sntynn.EKKULL = global.UserKod;
            sntynn.ETARIH = DateTime.Now;
            sntynn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sntynnDal.Add(sntynn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SntynnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SNTYNN> Ncch_Update_Log(SNTYNN sntynn,SNTYNN oldSntynn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SNTYNN", sntynn.Id, global);
            var sonuc = new StandardResponse<SNTYNN>();
            sntynn.SIRKID = global.SirketId.Value; 
            sntynn.DEKULL = global.UserKod;
            sntynn.DTARIH = DateTime.Now;
            sntynn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sntynnDal.Update(sntynn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SntynnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SNTYNN> Ncch_UpdateAktifPasif_Log(SNTYNN sntynn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SNTYNN>();
            sntynn.SIRKID = global.SirketId.Value; 
            sntynn.ACTIVE = !sntynn.ACTIVE;
            sntynn.DEKULL = global.UserKod;
            sntynn.DTARIH = DateTime.Now;
            sntynn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sntynnDal.Update(sntynn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SntynnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SNTYNN> Ncch_Delete_Log(SNTYNN sntynn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SNTYNN", sntynn.Id, global);
            var sonuc = new StandardResponse<SNTYNN>();
            sntynn.SIRKID = global.SirketId.Value; 
            sntynn.ACTIVE = false;
            sntynn.SLINDI = true;
            sntynn.DEKULL = global.UserKod;
            sntynn.DTARIH = DateTime.Now;
            sntynn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sntynnDal.Update(sntynn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
