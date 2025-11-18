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
    public class StdepvManager : IStdepvService
    {
        private IStdepvDal _stdepvDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals

        #region ClientServices

        #endregion ClientServices


        public StdepvManager(IStdepvDal stdepvDal,IGnService gnservice,ILockedService lockedservice)
        {
            _stdepvDal = stdepvDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STDEPV> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDEPV>();
            sonuc.Items = global.SirketId != null ? _stdepvDal.GetList(x => x.SIRKID == global.SirketId) : _stdepvDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STDEPV> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDEPV>();
            sonuc.Items = global.SirketId != null ? _stdepvDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stdepvDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STDEPV> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDEPV>();
            sonuc.Items = global.SirketId != null ? _stdepvDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stdepvDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STDEPV> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDEPV>();
            sonuc.Items = global.SirketId != null ? _stdepvDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stdepvDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STDEPV> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDEPV>();
            sonuc.Items = global.SirketId != null ? _stdepvDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stdepvDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STDEPV> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STDEPV>();
            sonuc.Nesne = _stdepvDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STDEPV> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STDEPV", id, global);
            var sonuc = new StandardResponse<STDEPV>();
            sonuc.Nesne = _stdepvDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StdepvValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STDEPV> Ncch_Add_NLog(STDEPV stdepv, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STDEPV>();
            stdepv.SIRKID = global.SirketId.Value; 
            stdepv.EKKULL = global.UserKod;
            stdepv.ETARIH = DateTime.Now;
            stdepv.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stdepvDal.Add(stdepv);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StdepvValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STDEPV> Ncch_Update_Log(STDEPV stdepv,STDEPV oldStdepv, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STDEPV", stdepv.Id, global);
            var sonuc = new StandardResponse<STDEPV>();
            stdepv.SIRKID = global.SirketId.Value; 
            stdepv.DEKULL = global.UserKod;
            stdepv.DTARIH = DateTime.Now;
            stdepv.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stdepvDal.Update(stdepv);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StdepvValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STDEPV> Ncch_UpdateAktifPasif_Log(STDEPV stdepv, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STDEPV>();
            stdepv.SIRKID = global.SirketId.Value; 
            stdepv.ACTIVE = !stdepv.ACTIVE;
            stdepv.DEKULL = global.UserKod;
            stdepv.DTARIH = DateTime.Now;
            stdepv.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stdepvDal.Update(stdepv);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StdepvValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STDEPV> Ncch_Delete_Log(STDEPV stdepv, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STDEPV", stdepv.Id, global);
            var sonuc = new StandardResponse<STDEPV>();
            stdepv.SIRKID = global.SirketId.Value; 
            stdepv.ACTIVE = false;
            stdepv.SLINDI = true;
            stdepv.DEKULL = global.UserKod;
            stdepv.DTARIH = DateTime.Now;
            stdepv.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stdepvDal.Update(stdepv);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
