using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.KS;
using Bps.BpsBase.Business.Abstract.KS;
using Bps.BpsBase.DataAccess.Abstract.KS;
using Bps.BpsBase.Entities.Concrete.KS;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.KS
{
    public class KskasaManager : IKskasaService
    {
        private IKskasaDal _kskasaDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public KskasaManager(IKskasaDal kskasaDal,IGnService gnservice,ILockedService lockedservice)
        {
            _kskasaDal = kskasaDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<KSKASA> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<KSKASA>();
            sonuc.Items = global.SirketId != null ? _kskasaDal.GetList(x => x.SIRKID == global.SirketId) : _kskasaDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<KSKASA> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<KSKASA>();
            sonuc.Items = global.SirketId != null ? _kskasaDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _kskasaDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<KSKASA> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<KSKASA>();
            sonuc.Items = global.SirketId != null ? _kskasaDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _kskasaDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<KSKASA> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<KSKASA>();
            sonuc.Items = global.SirketId != null ? _kskasaDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _kskasaDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<KSKASA> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<KSKASA>();
            sonuc.Items = global.SirketId != null ? _kskasaDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _kskasaDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<KSKASA> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<KSKASA>();
            sonuc.Nesne = _kskasaDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<KSKASA> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("KSKASA", id, global);
            var sonuc = new StandardResponse<KSKASA>();
            sonuc.Nesne = _kskasaDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(KskasaValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<KSKASA> Ncch_Add_NLog(KSKASA kskasa, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<KSKASA>();
            kskasa.SIRKID = global.SirketId.Value; 
            kskasa.EKKULL = global.UserKod;
            kskasa.ETARIH = DateTime.Now;
            kskasa.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _kskasaDal.Add(kskasa);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(KskasaValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<KSKASA> Ncch_Update_Log(KSKASA kskasa,KSKASA oldKskasa, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("KSKASA", kskasa.Id, global);
            var sonuc = new StandardResponse<KSKASA>();
            kskasa.SIRKID = global.SirketId.Value; 
            kskasa.DEKULL = global.UserKod;
            kskasa.DTARIH = DateTime.Now;
            kskasa.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _kskasaDal.Update(kskasa);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(KskasaValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<KSKASA> Ncch_UpdateAktifPasif_Log(KSKASA kskasa, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<KSKASA>();
            kskasa.SIRKID = global.SirketId.Value; 
            kskasa.ACTIVE = !kskasa.ACTIVE;
            kskasa.DEKULL = global.UserKod;
            kskasa.DTARIH = DateTime.Now;
            kskasa.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _kskasaDal.Update(kskasa);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(KskasaValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<KSKASA> Ncch_Delete_Log(KSKASA kskasa, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("KSKASA", kskasa.Id, global);
            var sonuc = new StandardResponse<KSKASA>();
            kskasa.SIRKID = global.SirketId.Value; 
            kskasa.ACTIVE = false;
            kskasa.SLINDI = true;
            kskasa.DEKULL = global.UserKod;
            kskasa.DTARIH = DateTime.Now;
            kskasa.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _kskasaDal.Update(kskasa);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
