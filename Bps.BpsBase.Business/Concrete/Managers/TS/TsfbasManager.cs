using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.TS;
using Bps.BpsBase.Business.Abstract.TS;
using Bps.BpsBase.DataAccess.Abstract.TS;
using Bps.BpsBase.Entities.Concrete.TS;

#region ClientUsing

using Bps.BpsBase.Entities.Models.TS;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.TS
{
    public class TsfbasManager : ITsfbasService
    {
        private ITsfbasDal _tsfbasDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public TsfbasManager(ITsfbasDal tsfbasDal,IGnService gnservice,ILockedService lockedservice)
        {
            _tsfbasDal = tsfbasDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<TSFBAS> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TSFBAS>();
            sonuc.Items = global.SirketId != null ? _tsfbasDal.GetList(x => x.SIRKID == global.SirketId) : _tsfbasDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TSFBAS> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TSFBAS>();
            sonuc.Items = global.SirketId != null ? _tsfbasDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _tsfbasDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TSFBAS> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TSFBAS>();
            sonuc.Items = global.SirketId != null ? _tsfbasDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _tsfbasDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TSFBAS> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TSFBAS>();
            sonuc.Items = global.SirketId != null ? _tsfbasDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _tsfbasDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TSFBAS> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TSFBAS>();
            sonuc.Items = global.SirketId != null ? _tsfbasDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _tsfbasDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<TSFBAS> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<TSFBAS>();
            sonuc.Nesne = _tsfbasDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<TSFBAS> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("TSFBAS", id, global);
            var sonuc = new StandardResponse<TSFBAS>();
            sonuc.Nesne = _tsfbasDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(TsfbasValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<TSFBAS> Ncch_Add_NLog(TSFBAS tsfbas, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<TSFBAS>();
            tsfbas.SIRKID = global.SirketId.Value; 
            tsfbas.EKKULL = global.UserKod;
            tsfbas.ETARIH = DateTime.Now;
            tsfbas.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _tsfbasDal.Add(tsfbas);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(TsfbasValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<TSFBAS> Ncch_Update_Log(TSFBAS tsfbas,TSFBAS oldTsfbas, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("TSFBAS", tsfbas.Id, global);
            var sonuc = new StandardResponse<TSFBAS>();
            tsfbas.SIRKID = global.SirketId.Value; 
            tsfbas.DEKULL = global.UserKod;
            tsfbas.DTARIH = DateTime.Now;
            tsfbas.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _tsfbasDal.Update(tsfbas);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(TsfbasValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<TSFBAS> Ncch_UpdateAktifPasif_Log(TSFBAS tsfbas, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<TSFBAS>();
            tsfbas.SIRKID = global.SirketId.Value; 
            tsfbas.ACTIVE = !tsfbas.ACTIVE;
            tsfbas.DEKULL = global.UserKod;
            tsfbas.DTARIH = DateTime.Now;
            tsfbas.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _tsfbasDal.Update(tsfbas);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(TsfbasValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<TSFBAS> Ncch_Delete_Log(TSFBAS tsfbas, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("TSFBAS", tsfbas.Id, global);
            var sonuc = new StandardResponse<TSFBAS>();
            tsfbas.SIRKID = global.SirketId.Value; 
            tsfbas.ACTIVE = false;
            tsfbas.SLINDI = true;
            tsfbas.DEKULL = global.UserKod;
            tsfbas.DTARIH = DateTime.Now;
            tsfbas.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _tsfbasDal.Update(tsfbas);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<TSFBAS> Cch_GetListByParam_NLog(TeslimatParamModel param, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TSFBAS>();

            if (!string.IsNullOrEmpty(param.BELGEN))
            {
                sonuc.Items = _tsfbasDal.GetList(x => x.SIRKID == global.SirketId && x.BELGEN == param.BELGEN && x.ACTIVE);
            }
            else
            {
                if (param.DtBitis == null)
                {
                    sonuc.Items = _tsfbasDal.GetList(x => x.SIRKID == global.SirketId && x.BELTRH == param.DtBaslangic && x.TSFTNO == param.TSFTNO.Value && x.ACTIVE);
                }
                else
                {
                    sonuc.Items = _tsfbasDal.GetList(x => x.SIRKID == global.SirketId && x.BELTRH >= param.DtBaslangic && x.BELTRH <= param.DtBitis && x.TSFTNO == param.TSFTNO.Value && x.ACTIVE);
                }
            }

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
