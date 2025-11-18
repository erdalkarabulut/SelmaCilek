using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.CR;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.DataAccess.Abstract.CR;
using Bps.BpsBase.Entities.Concrete.CR;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.CR
{
    public class CrcafyManager : ICrcafyService
    {
        private ICrcafyDal _crcafyDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals

        #region ClientServices

        #endregion ClientServices


        public CrcafyManager(ICrcafyDal crcafyDal,IGnService gnservice,ILockedService lockedservice)
        {
            _crcafyDal = crcafyDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<CRCAFY> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRCAFY>();
            sonuc.Items = global.SirketId != null ? _crcafyDal.GetList(x => x.SIRKID == global.SirketId) : _crcafyDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRCAFY> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRCAFY>();
            sonuc.Items = global.SirketId != null ? _crcafyDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _crcafyDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRCAFY> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRCAFY>();
            sonuc.Items = global.SirketId != null ? _crcafyDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _crcafyDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRCAFY> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRCAFY>();
            sonuc.Items = global.SirketId != null ? _crcafyDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _crcafyDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRCAFY> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRCAFY>();
            sonuc.Items = global.SirketId != null ? _crcafyDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _crcafyDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<CRCAFY> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<CRCAFY>();
            sonuc.Nesne = _crcafyDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<CRCAFY> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("CRCAFY", id, global);
            var sonuc = new StandardResponse<CRCAFY>();
            sonuc.Nesne = _crcafyDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CrcafyValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRCAFY> Ncch_Add_NLog(CRCAFY crcafy, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<CRCAFY>();
            crcafy.SIRKID = global.SirketId.Value; 
            crcafy.EKKULL = global.UserKod;
            crcafy.ETARIH = DateTime.Now;
            crcafy.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _crcafyDal.Add(crcafy);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CrcafyValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRCAFY> Ncch_Update_Log(CRCAFY crcafy,CRCAFY oldCrcafy, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("CRCAFY", crcafy.Id, global);
            var sonuc = new StandardResponse<CRCAFY>();
            crcafy.SIRKID = global.SirketId.Value; 
            crcafy.DEKULL = global.UserKod;
            crcafy.DTARIH = DateTime.Now;
            crcafy.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _crcafyDal.Update(crcafy);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CrcafyValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRCAFY> Ncch_UpdateAktifPasif_Log(CRCAFY crcafy, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<CRCAFY>();
            crcafy.SIRKID = global.SirketId.Value; 
            crcafy.ACTIVE = !crcafy.ACTIVE;
            crcafy.DEKULL = global.UserKod;
            crcafy.DTARIH = DateTime.Now;
            crcafy.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _crcafyDal.Update(crcafy);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CrcafyValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRCAFY> Ncch_Delete_Log(CRCAFY crcafy, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("CRCAFY", crcafy.Id, global);
            var sonuc = new StandardResponse<CRCAFY>();
            crcafy.SIRKID = global.SirketId.Value; 
            crcafy.ACTIVE = false;
            crcafy.SLINDI = true;
            crcafy.DEKULL = global.UserKod;
            crcafy.DTARIH = DateTime.Now;
            crcafy.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _crcafyDal.Update(crcafy);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
