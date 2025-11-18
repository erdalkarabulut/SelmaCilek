using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.DependencyResolvers.Ninject;
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
    public class StcinsManager : IStcinsService
    {
        private IStcinsDal _stcinsDal;
        private IGnService _gnService = InstanceFactory.GetInstance<IGnService>();
        private ILockedService _lockedService = InstanceFactory.GetInstance<ILockedService>();

        #region ClientDals

        #endregion ClientDals

        public StcinsManager(IStcinsDal stcinsDal)
        {
            _stcinsDal = stcinsDal;
        }

        public ListResponse<STCINS> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STCINS>();
            sonuc.Items = global.SirketId != null ? _stcinsDal.GetList(x => x.SIRKID == global.SirketId) : _stcinsDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STCINS> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STCINS>();
            sonuc.Items = global.SirketId != null ? _stcinsDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stcinsDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STCINS> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STCINS>();
            sonuc.Items = global.SirketId != null ? _stcinsDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stcinsDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STCINS> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STCINS>();
            sonuc.Items = global.SirketId != null ? _stcinsDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stcinsDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STCINS> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STCINS>();
            sonuc.Items = global.SirketId != null ? _stcinsDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stcinsDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STCINS> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STCINS>();
            sonuc.Nesne = _stcinsDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STCINS> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
             _lockedService.LockControlRead("STCINS", id, global);
            var sonuc = new StandardResponse<STCINS>();
            sonuc.Nesne = _stcinsDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StcinsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STCINS> Ncch_Add_NLog(STCINS stcins, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STCINS>();
            stcins.SIRKID = global.SirketId.Value; 
            stcins.EKKULL = global.UserKod;
            stcins.ETARIH = DateTime.Now;
            stcins.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stcinsDal.Add(stcins);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StcinsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STCINS> Ncch_Update_Log(STCINS stcins,STCINS oldStcins, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STCINS", stcins.Id, global);
            var sonuc = new StandardResponse<STCINS>();
            stcins.SIRKID = global.SirketId.Value; 
            stcins.DEKULL = global.UserKod;
            stcins.DTARIH = DateTime.Now;
            stcins.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stcinsDal.Update(stcins);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StcinsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STCINS> Ncch_UpdateAktifPasif_Log(STCINS stcins, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STCINS>();
            stcins.SIRKID = global.SirketId.Value; 
            stcins.ACTIVE = !stcins.ACTIVE;
            stcins.DEKULL = global.UserKod;
            stcins.DTARIH = DateTime.Now;
            stcins.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stcinsDal.Update(stcins);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StcinsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STCINS> Ncch_Delete_Log(STCINS stcins, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STCINS", stcins.Id, global);
            var sonuc = new StandardResponse<STCINS>();
            stcins.SIRKID = global.SirketId.Value; 
            stcins.ACTIVE = false;
            stcins.SLINDI = true;
            stcins.DEKULL = global.UserKod;
            stcins.DTARIH = DateTime.Now;
            stcins.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stcinsDal.Update(stcins);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
