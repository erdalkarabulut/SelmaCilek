using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.UA;
using Bps.BpsBase.Business.Abstract.UA;
using Bps.BpsBase.DataAccess.Abstract.UA;
using Bps.BpsBase.Entities.Concrete.UA;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.UA
{
    public class UakltpManager : IUakltpService
    {
        private IUakltpDal _uakltpDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public UakltpManager(IUakltpDal uakltpDal,IGnService gnservice,ILockedService lockedservice)
        {
            _uakltpDal = uakltpDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<UAKLTP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UAKLTP>();
            sonuc.Items = global.SirketId != null ? _uakltpDal.GetList(x => x.SIRKID == global.SirketId) : _uakltpDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UAKLTP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UAKLTP>();
            sonuc.Items = global.SirketId != null ? _uakltpDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _uakltpDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UAKLTP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UAKLTP>();
            sonuc.Items = global.SirketId != null ? _uakltpDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _uakltpDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UAKLTP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UAKLTP>();
            sonuc.Items = global.SirketId != null ? _uakltpDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _uakltpDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UAKLTP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UAKLTP>();
            sonuc.Items = global.SirketId != null ? _uakltpDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _uakltpDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<UAKLTP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<UAKLTP>();
            sonuc.Nesne = _uakltpDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<UAKLTP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("UAKLTP", id, global);
            var sonuc = new StandardResponse<UAKLTP>();
            sonuc.Nesne = _uakltpDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UakltpValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UAKLTP> Ncch_Add_NLog(UAKLTP uakltp, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<UAKLTP>();
            uakltp.SIRKID = global.SirketId.Value; 
            uakltp.EKKULL = global.UserKod;
            uakltp.ETARIH = DateTime.Now;
            uakltp.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uakltpDal.Add(uakltp);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UakltpValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UAKLTP> Ncch_Update_Log(UAKLTP uakltp,UAKLTP oldUakltp, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("UAKLTP", uakltp.Id, global);
            var sonuc = new StandardResponse<UAKLTP>();
            uakltp.SIRKID = global.SirketId.Value; 
            uakltp.DEKULL = global.UserKod;
            uakltp.DTARIH = DateTime.Now;
            uakltp.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uakltpDal.Update(uakltp);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UakltpValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UAKLTP> Ncch_UpdateAktifPasif_Log(UAKLTP uakltp, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<UAKLTP>();
            uakltp.SIRKID = global.SirketId.Value; 
            uakltp.ACTIVE = !uakltp.ACTIVE;
            uakltp.DEKULL = global.UserKod;
            uakltp.DTARIH = DateTime.Now;
            uakltp.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uakltpDal.Update(uakltp);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UakltpValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UAKLTP> Ncch_Delete_Log(UAKLTP uakltp, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("UAKLTP", uakltp.Id, global);
            var sonuc = new StandardResponse<UAKLTP>();
            uakltp.SIRKID = global.SirketId.Value; 
            uakltp.ACTIVE = false;
            uakltp.SLINDI = true;
            uakltp.DEKULL = global.UserKod;
            uakltp.DTARIH = DateTime.Now;
            uakltp.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uakltpDal.Update(uakltp);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
