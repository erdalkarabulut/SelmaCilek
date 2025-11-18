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
    public class GndpnoManager : IGndpnoService
    {
        private IGndpnoDal _gndpnoDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GndpnoManager(IGndpnoDal gndpnoDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gndpnoDal = gndpnoDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNDPNO> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPNO>();
            sonuc.Items = global.SirketId != null ? _gndpnoDal.GetList(x => x.SIRKID == global.SirketId) : _gndpnoDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNDPNO> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPNO>();
            sonuc.Items = global.SirketId != null ? _gndpnoDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gndpnoDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNDPNO> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPNO>();
            sonuc.Items = global.SirketId != null ? _gndpnoDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gndpnoDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNDPNO> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPNO>();
            sonuc.Items = global.SirketId != null ? _gndpnoDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gndpnoDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNDPNO> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNDPNO>();
            sonuc.Items = global.SirketId != null ? _gndpnoDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gndpnoDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNDPNO> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNDPNO>();
            sonuc.Nesne = _gndpnoDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNDPNO> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNDPNO", id, global);
            var sonuc = new StandardResponse<GNDPNO>();
            sonuc.Nesne = _gndpnoDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GndpnoValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNDPNO> Ncch_Add_NLog(GNDPNO gndpno, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNDPNO>();
            gndpno.SIRKID = global.SirketId.Value; 
            gndpno.EKKULL = global.UserKod;
            gndpno.ETARIH = DateTime.Now;
            gndpno.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gndpnoDal.Add(gndpno);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GndpnoValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNDPNO> Ncch_Update_Log(GNDPNO gndpno,GNDPNO oldGndpno, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNDPNO", gndpno.Id, global);
            var sonuc = new StandardResponse<GNDPNO>();
            gndpno.SIRKID = global.SirketId.Value; 
            gndpno.DEKULL = global.UserKod;
            gndpno.DTARIH = DateTime.Now;
            gndpno.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gndpnoDal.Update(gndpno);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GndpnoValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNDPNO> Ncch_UpdateAktifPasif_Log(GNDPNO gndpno, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNDPNO>();
            gndpno.SIRKID = global.SirketId.Value; 
            gndpno.ACTIVE = !gndpno.ACTIVE;
            gndpno.DEKULL = global.UserKod;
            gndpno.DTARIH = DateTime.Now;
            gndpno.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gndpnoDal.Update(gndpno);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GndpnoValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNDPNO> Ncch_Delete_Log(GNDPNO gndpno, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNDPNO", gndpno.Id, global);
            var sonuc = new StandardResponse<GNDPNO>();
            gndpno.SIRKID = global.SirketId.Value; 
            gndpno.ACTIVE = false;
            gndpno.SLINDI = true;
            gndpno.DEKULL = global.UserKod;
            gndpno.DTARIH = DateTime.Now;
            gndpno.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gndpnoDal.Update(gndpno);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public StandardResponse<GNDPNO> Ncch_GetByDepoKodUretimYeri_NLog(string uretimYer, string depoKod, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNDPNO>();
            sonuc.Nesne = _gndpnoDal.Get(x =>  x.SIRKID == global.SirketId && x.URYRKD == uretimYer && x.DPKODU == depoKod && x.ACTIVE);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
