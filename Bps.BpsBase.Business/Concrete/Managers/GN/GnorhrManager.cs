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
    public class GnorhrManager : IGnorhrService
    {
        private IGnorhrDal _gnorhrDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GnorhrManager(IGnorhrDal gnorhrDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnorhrDal = gnorhrDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNORHR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNORHR>();
            sonuc.Items = global.SirketId != null ? _gnorhrDal.GetList(x => x.SIRKID == global.SirketId) : _gnorhrDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNORHR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNORHR>();
            sonuc.Items = global.SirketId != null ? _gnorhrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnorhrDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNORHR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNORHR>();
            sonuc.Items = global.SirketId != null ? _gnorhrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnorhrDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNORHR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNORHR>();
            sonuc.Items = global.SirketId != null ? _gnorhrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnorhrDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNORHR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNORHR>();
            sonuc.Items = global.SirketId != null ? _gnorhrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnorhrDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNORHR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNORHR>();
            sonuc.Nesne = _gnorhrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNORHR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNORHR", id, global);
            var sonuc = new StandardResponse<GNORHR>();
            sonuc.Nesne = _gnorhrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnorhrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNORHR> Ncch_Add_NLog(GNORHR gnorhr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNORHR>();
            gnorhr.SIRKID = global.SirketId.Value; 
            gnorhr.EKKULL = global.UserKod;
            gnorhr.ETARIH = DateTime.Now;
            gnorhr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnorhrDal.Add(gnorhr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnorhrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNORHR> Ncch_Update_Log(GNORHR gnorhr,GNORHR oldGnorhr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNORHR", gnorhr.Id, global);
            var sonuc = new StandardResponse<GNORHR>();
            gnorhr.SIRKID = global.SirketId.Value; 
            gnorhr.DEKULL = global.UserKod;
            gnorhr.DTARIH = DateTime.Now;
            gnorhr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnorhrDal.Update(gnorhr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnorhrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNORHR> Ncch_UpdateAktifPasif_Log(GNORHR gnorhr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNORHR>();
            gnorhr.SIRKID = global.SirketId.Value; 
            gnorhr.ACTIVE = !gnorhr.ACTIVE;
            gnorhr.DEKULL = global.UserKod;
            gnorhr.DTARIH = DateTime.Now;
            gnorhr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnorhrDal.Update(gnorhr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnorhrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNORHR> Ncch_Delete_Log(GNORHR gnorhr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNORHR", gnorhr.Id, global);
            var sonuc = new StandardResponse<GNORHR>();
            gnorhr.SIRKID = global.SirketId.Value; 
            gnorhr.ACTIVE = false;
            gnorhr.SLINDI = true;
            gnorhr.DEKULL = global.UserKod;
            gnorhr.DTARIH = DateTime.Now;
            gnorhr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnorhrDal.Update(gnorhr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc
        public ListResponse<GNORHR> Cch_GetListOnay_NLog(string orgKod, string tablnm, int tabid, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNORHR>();
            sonuc.Items = global.SirketId != null ? _gnorhrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.ORGKOD == orgKod
            && x.TABLNM == tablnm && x.TABLID == tabid)
                : _gnorhrDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        public StandardResponse<GNORHR> Ncch_UpdateOnay_Log(GNORHR gnorhr, GNORHR oldGnorhr, Global global, bool _onay)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            _lockedService.LockControlWrite("GNORHR", gnorhr.Id, global);
            var sonuc = new StandardResponse<GNORHR>();
            gnorhr.SIRKID = global.SirketId.Value;
            gnorhr.GNONAY = _onay;
            if (_onay == true)
            {
                gnorhr.GNONTR = DateTime.Now;
            }
            else
            {
                gnorhr.GNONTR = null;
            }
            gnorhr.DEKULL = global.UserKod;
            gnorhr.DTARIH = DateTime.Now;
            gnorhr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnorhrDal.Update(gnorhr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        #endregion ClientFunc
    }
}
