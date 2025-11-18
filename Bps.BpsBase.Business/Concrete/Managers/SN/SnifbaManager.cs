using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.SN;
using Bps.BpsBase.Business.Abstract.SN;
using Bps.BpsBase.DataAccess.Abstract.SN;
using Bps.BpsBase.Entities.Concrete.SN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.SN
{
    public class SnifbaManager : ISnifbaService
    {
        private ISnifbaDal _snifbaDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public SnifbaManager(ISnifbaDal snifbaDal,IGnService gnservice,ILockedService lockedservice)
        {
            _snifbaDal = snifbaDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<SNIFBA> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNIFBA>();
            sonuc.Items = global.SirketId != null ? _snifbaDal.GetList(x => x.SIRKID == global.SirketId) : _snifbaDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SNIFBA> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNIFBA>();
            sonuc.Items = global.SirketId != null ? _snifbaDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _snifbaDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SNIFBA> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNIFBA>();
            sonuc.Items = global.SirketId != null ? _snifbaDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _snifbaDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SNIFBA> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNIFBA>();
            sonuc.Items = global.SirketId != null ? _snifbaDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _snifbaDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SNIFBA> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SNIFBA>();
            sonuc.Items = global.SirketId != null ? _snifbaDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _snifbaDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SNIFBA> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<SNIFBA>();
            sonuc.Nesne = _snifbaDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SNIFBA> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("SNIFBA", id, global);
            var sonuc = new StandardResponse<SNIFBA>();
            sonuc.Nesne = _snifbaDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SnifbaValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SNIFBA> Ncch_Add_NLog(SNIFBA snifba, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SNIFBA>();
            snifba.SIRKID = global.SirketId.Value; 
            snifba.EKKULL = global.UserKod;
            snifba.ETARIH = DateTime.Now;
            snifba.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _snifbaDal.Add(snifba);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SnifbaValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SNIFBA> Ncch_Update_Log(SNIFBA snifba,SNIFBA oldSnifba, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SNIFBA", snifba.Id, global);
            var sonuc = new StandardResponse<SNIFBA>();
            snifba.SIRKID = global.SirketId.Value; 
            snifba.DEKULL = global.UserKod;
            snifba.DTARIH = DateTime.Now;
            snifba.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _snifbaDal.Update(snifba);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SnifbaValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SNIFBA> Ncch_UpdateAktifPasif_Log(SNIFBA snifba, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SNIFBA>();
            snifba.SIRKID = global.SirketId.Value; 
            snifba.ACTIVE = !snifba.ACTIVE;
            snifba.DEKULL = global.UserKod;
            snifba.DTARIH = DateTime.Now;
            snifba.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _snifbaDal.Update(snifba);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SnifbaValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SNIFBA> Ncch_Delete_Log(SNIFBA snifba, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SNIFBA", snifba.Id, global);
            var sonuc = new StandardResponse<SNIFBA>();
            snifba.SIRKID = global.SirketId.Value; 
            snifba.ACTIVE = false;
            snifba.SLINDI = true;
            snifba.DEKULL = global.UserKod;
            snifba.DTARIH = DateTime.Now;
            snifba.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _snifbaDal.Update(snifba);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
