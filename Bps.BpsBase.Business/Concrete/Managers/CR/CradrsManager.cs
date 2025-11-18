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
    public class CradrsManager : ICradrsService
    {
        private ICradrsDal _cradrsDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        private ICrcariDal _crcariDal;

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public CradrsManager(ICradrsDal cradrsDal,IGnService gnservice,ILockedService lockedservice
        ,ICrcariDal crcaridal)
        {
            _cradrsDal = cradrsDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
            _crcariDal = crcaridal;

        }
        public ListResponse<CRADRS> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRADRS>();
            sonuc.Items = global.SirketId != null ? _cradrsDal.GetList(x => x.SIRKID == global.SirketId) : _cradrsDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRADRS> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRADRS>();
            sonuc.Items = global.SirketId != null ? _cradrsDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _cradrsDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRADRS> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRADRS>();
            sonuc.Items = global.SirketId != null ? _cradrsDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _cradrsDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRADRS> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRADRS>();
            sonuc.Items = global.SirketId != null ? _cradrsDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _cradrsDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRADRS> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRADRS>();
            sonuc.Items = global.SirketId != null ? _cradrsDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _cradrsDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<CRADRS> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<CRADRS>();
            sonuc.Nesne = _cradrsDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<CRADRS> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("CRADRS", id, global);
            var sonuc = new StandardResponse<CRADRS>();
            sonuc.Nesne = _cradrsDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CradrsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRADRS> Ncch_Add_NLog(CRADRS cradrs, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<CRADRS>();
            cradrs.SIRKID = global.SirketId.Value; 
            cradrs.EKKULL = global.UserKod;
            cradrs.ETARIH = DateTime.Now;
            cradrs.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _cradrsDal.Add(cradrs);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CradrsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRADRS> Ncch_Update_Log(CRADRS cradrs,CRADRS oldCradrs, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("CRADRS", cradrs.Id, global);
            var sonuc = new StandardResponse<CRADRS>();
            cradrs.SIRKID = global.SirketId.Value; 
            cradrs.DEKULL = global.UserKod;
            cradrs.DTARIH = DateTime.Now;
            cradrs.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _cradrsDal.Update(cradrs);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CradrsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRADRS> Ncch_UpdateAktifPasif_Log(CRADRS cradrs, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<CRADRS>();
            cradrs.SIRKID = global.SirketId.Value; 
            cradrs.ACTIVE = !cradrs.ACTIVE;
            cradrs.DEKULL = global.UserKod;
            cradrs.DTARIH = DateTime.Now;
            cradrs.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _cradrsDal.Update(cradrs);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CradrsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRADRS> Ncch_Delete_Log(CRADRS cradrs, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("CRADRS", cradrs.Id, global);
            var sonuc = new StandardResponse<CRADRS>();
            cradrs.SIRKID = global.SirketId.Value; 
            cradrs.ACTIVE = false;
            cradrs.SLINDI = true;
            cradrs.DEKULL = global.UserKod;
            cradrs.DTARIH = DateTime.Now;
            cradrs.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _cradrsDal.Update(cradrs);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<CRADRS> Cch_GetListByCariKod_NLog(Global global, string cariKod, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRADRS>();
            sonuc.Items = global.SirketId != null
                ? _cradrsDal.GetList(x =>
                    x.SIRKID == global.SirketId && x.SLINDI == false && x.ACTIVE && x.CRKODU == cariKod)
                : _cradrsDal.GetList(x => x.SLINDI == false && x.ACTIVE && x.CRKODU == cariKod);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<CRADRS> Ncch_AddWithDefaultAdres_NLog(CRADRS cradrs, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<CRADRS>();
            cradrs.SIRKID = global.SirketId.Value;
            cradrs.EKKULL = global.UserKod;
            cradrs.ETARIH = DateTime.Now;
            cradrs.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _cradrsDal.Add(cradrs);

            string cariKodu = cradrs.CRKODU;
            int adresId = sonuc.Nesne.Id;

            CRCARI cari = _crcariDal.Get(c => c.CRKODU == cariKodu && c.SIRKID == cradrs.SIRKID && c.ACTIVE && !c.SLINDI);
            cari.FTADNO = adresId;
            cari.SVADNO = adresId;
            _crcariDal.Update(cari);

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
