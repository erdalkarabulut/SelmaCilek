using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.SA;
using Bps.BpsBase.Business.Abstract.SA;
using Bps.BpsBase.DataAccess.Abstract.SA;
using Bps.BpsBase.Entities.Concrete.SA;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.SA
{
    public class SadegaManager : ISadegaService
    {
        private ISadegaDal _sadegaDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public SadegaManager(ISadegaDal sadegaDal,IGnService gnservice,ILockedService lockedservice)
        {
            _sadegaDal = sadegaDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<SADEGA> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SADEGA>();
            sonuc.Items = global.SirketId != null ? _sadegaDal.GetList(x => x.SIRKID == global.SirketId) : _sadegaDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SADEGA> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SADEGA>();
            sonuc.Items = global.SirketId != null ? _sadegaDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _sadegaDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SADEGA> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SADEGA>();
            sonuc.Items = global.SirketId != null ? _sadegaDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _sadegaDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SADEGA> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SADEGA>();
            sonuc.Items = global.SirketId != null ? _sadegaDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _sadegaDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SADEGA> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SADEGA>();
            sonuc.Items = global.SirketId != null ? _sadegaDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _sadegaDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SADEGA> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<SADEGA>();
            sonuc.Nesne = _sadegaDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SADEGA> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("SADEGA", id, global);
            var sonuc = new StandardResponse<SADEGA>();
            sonuc.Nesne = _sadegaDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SadegaValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SADEGA> Ncch_Add_NLog(SADEGA sadega, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SADEGA>();
            sadega.SIRKID = global.SirketId.Value; 
            sadega.EKKULL = global.UserKod;
            sadega.ETARIH = DateTime.Now;
            sadega.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sadegaDal.Add(sadega);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SadegaValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SADEGA> Ncch_Update_Log(SADEGA sadega,SADEGA oldSadega, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SADEGA", sadega.Id, global);
            var sonuc = new StandardResponse<SADEGA>();
            sadega.SIRKID = global.SirketId.Value; 
            sadega.DEKULL = global.UserKod;
            sadega.DTARIH = DateTime.Now;
            sadega.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sadegaDal.Update(sadega);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SadegaValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SADEGA> Ncch_UpdateAktifPasif_Log(SADEGA sadega, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SADEGA>();
            sadega.SIRKID = global.SirketId.Value; 
            sadega.ACTIVE = !sadega.ACTIVE;
            sadega.DEKULL = global.UserKod;
            sadega.DTARIH = DateTime.Now;
            sadega.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sadegaDal.Update(sadega);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SadegaValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SADEGA> Ncch_Delete_Log(SADEGA sadega, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SADEGA", sadega.Id, global);
            var sonuc = new StandardResponse<SADEGA>();
            sadega.SIRKID = global.SirketId.Value; 
            sadega.ACTIVE = false;
            sadega.SLINDI = true;
            sadega.DEKULL = global.UserKod;
            sadega.DTARIH = DateTime.Now;
            sadega.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sadegaDal.Update(sadega);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
