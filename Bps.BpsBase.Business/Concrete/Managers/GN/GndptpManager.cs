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

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GndptpManager : IGndptpService
    {
        private IGndptpDal _gndptpDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GndptpManager(IGndptpDal gndptpDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gndptpDal = gndptpDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNDPTP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPTP>();
            sonuc.Items = global.SirketId != null ? _gndptpDal.GetList(x => x.SIRKID == global.SirketId) : _gndptpDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNDPTP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPTP>();
            sonuc.Items = global.SirketId != null ? _gndptpDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gndptpDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNDPTP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPTP>();
            sonuc.Items = global.SirketId != null ? _gndptpDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gndptpDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNDPTP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPTP>();
            sonuc.Items = global.SirketId != null ? _gndptpDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gndptpDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNDPTP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPTP>();
            sonuc.Items = global.SirketId != null ? _gndptpDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gndptpDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNDPTP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNDPTP>();
            sonuc.Nesne = _gndptpDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNDPTP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNDPTP", id, global);
            var sonuc = new StandardResponse<GNDPTP>();
            sonuc.Nesne = _gndptpDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GndptpValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNDPTP> Ncch_Add_NLog(GNDPTP gndptp, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNDPTP>();
            gndptp.SIRKID = global.SirketId.Value; 
            gndptp.EKKULL = global.UserKod;
            gndptp.ETARIH = DateTime.Now;
            gndptp.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gndptpDal.Add(gndptp);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GndptpValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNDPTP> Ncch_Update_Log(GNDPTP gndptp,GNDPTP oldGndptp, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNDPTP", gndptp.Id, global);
            var sonuc = new StandardResponse<GNDPTP>();
            gndptp.SIRKID = global.SirketId.Value; 
            gndptp.DEKULL = global.UserKod;
            gndptp.DTARIH = DateTime.Now;
            gndptp.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gndptpDal.Update(gndptp);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GndptpValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNDPTP> Ncch_UpdateAktifPasif_Log(GNDPTP gndptp, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNDPTP>();
            gndptp.SIRKID = global.SirketId.Value; 
            gndptp.ACTIVE = !gndptp.ACTIVE;
            gndptp.DEKULL = global.UserKod;
            gndptp.DTARIH = DateTime.Now;
            gndptp.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gndptpDal.Update(gndptp);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GndptpValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNDPTP> Ncch_Delete_Log(GNDPTP gndptp, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNDPTP", gndptp.Id, global);
            var sonuc = new StandardResponse<GNDPTP>();
            gndptp.SIRKID = global.SirketId.Value; 
            gndptp.ACTIVE = false;
            gndptp.SLINDI = true;
            gndptp.DEKULL = global.UserKod;
            gndptp.DTARIH = DateTime.Now;
            gndptp.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gndptpDal.Update(gndptp);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<GNDPTP> Cch_GetListByDepoKd_NLog(string depoKd, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPTP>();
            sonuc.Items =
                _gndptpDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.DEPOKD == depoKd);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
