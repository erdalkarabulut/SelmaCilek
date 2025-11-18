using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.GN;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.DataAccess.Abstract.GN;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

using System.Linq;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GnkoslManager : IGnkoslService
    {
        private IGnkoslDal _gnkoslDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GnkoslManager(IGnkoslDal gnkoslDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnkoslDal = gnkoslDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNKOSL> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKOSL>();
            sonuc.Items = global.SirketId != null ? _gnkoslDal.GetList(x => x.SIRKID == global.SirketId) : _gnkoslDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKOSL> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKOSL>();
            sonuc.Items = global.SirketId != null ? _gnkoslDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnkoslDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKOSL> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKOSL>();
            sonuc.Items = global.SirketId != null ? _gnkoslDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnkoslDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKOSL> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKOSL>();
            sonuc.Items = global.SirketId != null ? _gnkoslDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnkoslDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKOSL> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKOSL>();
            sonuc.Items = global.SirketId != null ? _gnkoslDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnkoslDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNKOSL> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNKOSL>();
            sonuc.Nesne = _gnkoslDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNKOSL> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNKOSL", id, global);
            var sonuc = new StandardResponse<GNKOSL>();
            sonuc.Nesne = _gnkoslDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnkoslValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKOSL> Ncch_Add_NLog(GNKOSL gnkosl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNKOSL>();
            gnkosl.SIRKID = global.SirketId.Value; 
            gnkosl.EKKULL = global.UserKod;
            gnkosl.ETARIH = DateTime.Now;
            gnkosl.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnkoslDal.Add(gnkosl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnkoslValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKOSL> Ncch_Update_Log(GNKOSL gnkosl,GNKOSL oldGnkosl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNKOSL", gnkosl.Id, global);
            var sonuc = new StandardResponse<GNKOSL>();
            gnkosl.SIRKID = global.SirketId.Value; 
            gnkosl.DEKULL = global.UserKod;
            gnkosl.DTARIH = DateTime.Now;
            gnkosl.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnkoslDal.Update(gnkosl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnkoslValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKOSL> Ncch_UpdateAktifPasif_Log(GNKOSL gnkosl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNKOSL>();
            gnkosl.SIRKID = global.SirketId.Value; 
            gnkosl.ACTIVE = !gnkosl.ACTIVE;
            gnkosl.DEKULL = global.UserKod;
            gnkosl.DTARIH = DateTime.Now;
            gnkosl.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnkoslDal.Update(gnkosl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnkoslValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKOSL> Ncch_Delete_Log(GNKOSL gnkosl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNKOSL", gnkosl.Id, global);
            var sonuc = new StandardResponse<GNKOSL>();
            gnkosl.SIRKID = global.SirketId.Value; 
            gnkosl.ACTIVE = false;
            gnkosl.SLINDI = true;
            gnkosl.DEKULL = global.UserKod;
            gnkosl.DTARIH = DateTime.Now;
            gnkosl.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnkoslDal.Update(gnkosl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc
        public ListResponse<GNKOSL> Ncch_GetListByProjeKod_NLog(Global global, string projeKod, bool onlyDefaults = false)
        {
            var sonuc = new ListResponse<GNKOSL>();
            sonuc.Items = _gnkoslDal.GetList(x => x.SIRKID == global.SirketId && x.PROKOD == projeKod && x.ACTIVE && x.SLINDI == false);
            if (onlyDefaults) sonuc.Items = sonuc.Items.Where(s => s.DEFALT == true).ToList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKOSL> Ncch_GetListByProjeKodAndLanguage_NLog(Global global, string projeKod, string langkd, bool onlyDefaults = false)
        {
            var sonuc = new ListResponse<GNKOSL>();
            sonuc.Items = _gnkoslDal.GetList(x => x.SIRKID == global.SirketId && x.PROKOD == projeKod && x.LANGKD == langkd && x.ACTIVE && x.SLINDI == false);
            if (onlyDefaults) sonuc.Items = sonuc.Items.Where(s => s.DEFALT == true).ToList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        #endregion ClientFunc
    }
}
