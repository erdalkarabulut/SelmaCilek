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
    public class StseriManager : IStseriService
    {
        private IStseriDal _stseriDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals

        #region ClientServices

        #endregion ClientServices


        public StseriManager(IStseriDal stseriDal,IGnService gnservice,ILockedService lockedservice)
        {
            _stseriDal = stseriDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STSERI> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STSERI>();
            sonuc.Items = global.SirketId != null ? _stseriDal.GetList(x => x.SIRKID == global.SirketId) : _stseriDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STSERI> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STSERI>();
            sonuc.Items = global.SirketId != null ? _stseriDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stseriDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STSERI> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STSERI>();
            sonuc.Items = global.SirketId != null ? _stseriDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stseriDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STSERI> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STSERI>();
            sonuc.Items = global.SirketId != null ? _stseriDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stseriDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STSERI> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STSERI>();
            sonuc.Items = global.SirketId != null ? _stseriDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stseriDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STSERI> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STSERI>();
            sonuc.Nesne = _stseriDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STSERI> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STSERI", id, global);
            var sonuc = new StandardResponse<STSERI>();
            sonuc.Nesne = _stseriDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StseriValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STSERI> Ncch_Add_NLog(STSERI stseri, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STSERI>();
            stseri.SIRKID = global.SirketId.Value; 
            stseri.EKKULL = global.UserKod;
            stseri.ETARIH = DateTime.Now;
            stseri.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stseriDal.Add(stseri);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StseriValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STSERI> Ncch_Update_Log(STSERI stseri,STSERI oldStseri, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STSERI", stseri.Id, global);
            var sonuc = new StandardResponse<STSERI>();
            stseri.SIRKID = global.SirketId.Value; 
            stseri.DEKULL = global.UserKod;
            stseri.DTARIH = DateTime.Now;
            stseri.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stseriDal.Update(stseri);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StseriValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STSERI> Ncch_UpdateAktifPasif_Log(STSERI stseri, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STSERI>();
            stseri.SIRKID = global.SirketId.Value; 
            stseri.ACTIVE = !stseri.ACTIVE;
            stseri.DEKULL = global.UserKod;
            stseri.DTARIH = DateTime.Now;
            stseri.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stseriDal.Update(stseri);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StseriValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STSERI> Ncch_Delete_Log(STSERI stseri, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STSERI", stseri.Id, global);
            var sonuc = new StandardResponse<STSERI>();
            stseri.SIRKID = global.SirketId.Value; 
            stseri.ACTIVE = false;
            stseri.SLINDI = true;
            stseri.DEKULL = global.UserKod;
            stseri.DTARIH = DateTime.Now;
            stseri.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stseriDal.Update(stseri);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
