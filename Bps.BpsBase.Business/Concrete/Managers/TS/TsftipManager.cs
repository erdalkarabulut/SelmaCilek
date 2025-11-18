using System;
using System.Linq;
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

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.TS
{
    public class TsftipManager : ITsftipService
    {
        private ITsftipDal _tsftipDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public TsftipManager(ITsftipDal tsftipDal,IGnService gnservice,ILockedService lockedservice)
        {
            _tsftipDal = tsftipDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<TSFTIP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TSFTIP>();
            sonuc.Items = global.SirketId != null ? _tsftipDal.GetList(x => x.SIRKID == global.SirketId) : _tsftipDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TSFTIP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TSFTIP>();
            sonuc.Items = global.SirketId != null ? _tsftipDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _tsftipDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TSFTIP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TSFTIP>();
            sonuc.Items = global.SirketId != null ? _tsftipDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _tsftipDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TSFTIP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TSFTIP>();
            sonuc.Items = global.SirketId != null ? _tsftipDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _tsftipDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TSFTIP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TSFTIP>();
            sonuc.Items = global.SirketId != null ? _tsftipDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _tsftipDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<TSFTIP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<TSFTIP>();
            sonuc.Nesne = _tsftipDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<TSFTIP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("TSFTIP", id, global);
            var sonuc = new StandardResponse<TSFTIP>();
            sonuc.Nesne = _tsftipDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(TsftipValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<TSFTIP> Ncch_Add_NLog(TSFTIP tsftip, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<TSFTIP>();
            tsftip.SIRKID = global.SirketId.Value; 
            tsftip.EKKULL = global.UserKod;
            tsftip.ETARIH = DateTime.Now;
            tsftip.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _tsftipDal.Add(tsftip);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(TsftipValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<TSFTIP> Ncch_Update_Log(TSFTIP tsftip,TSFTIP oldTsftip, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("TSFTIP", tsftip.Id, global);
            var sonuc = new StandardResponse<TSFTIP>();
            tsftip.SIRKID = global.SirketId.Value; 
            tsftip.DEKULL = global.UserKod;
            tsftip.DTARIH = DateTime.Now;
            tsftip.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _tsftipDal.Update(tsftip);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(TsftipValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<TSFTIP> Ncch_UpdateAktifPasif_Log(TSFTIP tsftip, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<TSFTIP>();
            tsftip.SIRKID = global.SirketId.Value; 
            tsftip.ACTIVE = !tsftip.ACTIVE;
            tsftip.DEKULL = global.UserKod;
            tsftip.DTARIH = DateTime.Now;
            tsftip.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _tsftipDal.Update(tsftip);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(TsftipValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<TSFTIP> Ncch_Delete_Log(TSFTIP tsftip, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("TSFTIP", tsftip.Id, global);
            var sonuc = new StandardResponse<TSFTIP>();
            tsftip.SIRKID = global.SirketId.Value; 
            tsftip.ACTIVE = false;
            tsftip.SLINDI = true;
            tsftip.DEKULL = global.UserKod;
            tsftip.DTARIH = DateTime.Now;
            tsftip.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _tsftipDal.Update(tsftip);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<TSFTIP> Ncch_GetListBySira_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TSFTIP>();
            sonuc.Items = _tsftipDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE && x.TSHRTP == global.Sira)
                .ToList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        #endregion ClientFunc
    }
}
