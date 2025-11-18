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
    public class StvmizManager : IStvmizService
    {
        private IStvmizDal _stvmizDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals

        #region ClientServices

        #endregion ClientServices


        public StvmizManager(IStvmizDal stvmizDal,IGnService gnservice,ILockedService lockedservice)
        {
            _stvmizDal = stvmizDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STVMIZ> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STVMIZ>();
            sonuc.Items = global.SirketId != null ? _stvmizDal.GetList(x => x.SIRKID == global.SirketId) : _stvmizDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STVMIZ> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STVMIZ>();
            sonuc.Items = global.SirketId != null ? _stvmizDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stvmizDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STVMIZ> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STVMIZ>();
            sonuc.Items = global.SirketId != null ? _stvmizDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stvmizDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STVMIZ> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STVMIZ>();
            sonuc.Items = global.SirketId != null ? _stvmizDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stvmizDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STVMIZ> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STVMIZ>();
            sonuc.Items = global.SirketId != null ? _stvmizDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stvmizDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STVMIZ> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STVMIZ>();
            sonuc.Nesne = _stvmizDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STVMIZ> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STVMIZ", id, global);
            var sonuc = new StandardResponse<STVMIZ>();
            sonuc.Nesne = _stvmizDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StvmizValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STVMIZ> Ncch_Add_NLog(STVMIZ stvmiz, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STVMIZ>();
            stvmiz.SIRKID = global.SirketId.Value; 
            stvmiz.EKKULL = global.UserKod;
            stvmiz.ETARIH = DateTime.Now;
            stvmiz.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stvmizDal.Add(stvmiz);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StvmizValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STVMIZ> Ncch_Update_Log(STVMIZ stvmiz,STVMIZ oldStvmiz, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STVMIZ", stvmiz.Id, global);
            var sonuc = new StandardResponse<STVMIZ>();
            stvmiz.SIRKID = global.SirketId.Value; 
            stvmiz.DEKULL = global.UserKod;
            stvmiz.DTARIH = DateTime.Now;
            stvmiz.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stvmizDal.Update(stvmiz);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StvmizValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STVMIZ> Ncch_UpdateAktifPasif_Log(STVMIZ stvmiz, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STVMIZ>();
            stvmiz.SIRKID = global.SirketId.Value; 
            stvmiz.ACTIVE = !stvmiz.ACTIVE;
            stvmiz.DEKULL = global.UserKod;
            stvmiz.DTARIH = DateTime.Now;
            stvmiz.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stvmizDal.Update(stvmiz);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StvmizValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STVMIZ> Ncch_Delete_Log(STVMIZ stvmiz, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STVMIZ", stvmiz.Id, global);
            var sonuc = new StandardResponse<STVMIZ>();
            stvmiz.SIRKID = global.SirketId.Value; 
            stvmiz.ACTIVE = false;
            stvmiz.SLINDI = true;
            stvmiz.DEKULL = global.UserKod;
            stvmiz.DTARIH = DateTime.Now;
            stvmiz.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stvmizDal.Update(stvmiz);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
