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
using System.Collections.Generic;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GnyetbManager : IGnyetbService
    {
        private IGnyetbDal _gnyetbDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals

        #region ClientServices

        #endregion ClientServices


        public GnyetbManager(IGnyetbDal gnyetbDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnyetbDal = gnyetbDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNYETB> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNYETB>();
            sonuc.Items = global.SirketId != null ? _gnyetbDal.GetList(x => x.SIRKID == global.SirketId) : _gnyetbDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNYETB> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNYETB>();
            sonuc.Items = global.SirketId != null ? _gnyetbDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnyetbDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNYETB> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNYETB>();
            sonuc.Items = global.SirketId != null ? _gnyetbDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnyetbDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNYETB> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNYETB>();
            sonuc.Items = global.SirketId != null ? _gnyetbDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnyetbDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNYETB> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNYETB>();
            sonuc.Items = global.SirketId != null ? _gnyetbDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnyetbDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNYETB> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNYETB>();
            sonuc.Nesne = _gnyetbDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNYETB> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNYETB", id, global);
            var sonuc = new StandardResponse<GNYETB>();
            sonuc.Nesne = _gnyetbDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnyetbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNYETB> Ncch_Add_NLog(GNYETB gnyetb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNYETB>();
            gnyetb.SIRKID = global.SirketId.Value; 
            gnyetb.EKKULL = global.UserKod;
            gnyetb.ETARIH = DateTime.Now;
            gnyetb.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnyetbDal.Add(gnyetb);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnyetbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNYETB> Ncch_Update_Log(GNYETB gnyetb,GNYETB oldGnyetb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNYETB", gnyetb.Id, global);
            var sonuc = new StandardResponse<GNYETB>();
            gnyetb.SIRKID = global.SirketId.Value; 
            gnyetb.DEKULL = global.UserKod;
            gnyetb.DTARIH = DateTime.Now;
            gnyetb.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnyetbDal.Update(gnyetb);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnyetbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNYETB> Ncch_UpdateAktifPasif_Log(GNYETB gnyetb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNYETB>();
            gnyetb.SIRKID = global.SirketId.Value; 
            gnyetb.ACTIVE = !gnyetb.ACTIVE;
            gnyetb.DEKULL = global.UserKod;
            gnyetb.DTARIH = DateTime.Now;
            gnyetb.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnyetbDal.Update(gnyetb);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnyetbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNYETB> Ncch_Delete_Log(GNYETB gnyetb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNYETB", gnyetb.Id, global);
            var sonuc = new StandardResponse<GNYETB>();
            gnyetb.SIRKID = global.SirketId.Value; 
            gnyetb.ACTIVE = false;
            gnyetb.SLINDI = true;
            gnyetb.DEKULL = global.UserKod;
            gnyetb.DTARIH = DateTime.Now;
            gnyetb.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnyetbDal.Update(gnyetb);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc


        [FluentValidationAspect(typeof(GnyetbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse Ncch_MultiDelete_Log(List<GNYETB> gnyetb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            //_lockedService.LockControlWrite("GNYETB", gnyetb.Id, global);
            var sonuc = new StandardResponse();


            bool _ok = _gnyetbDal.MultiDelete(gnyetb);
            if (_ok)
            {
                sonuc.Status = ResponseStatusEnum.OK;
            }
            else
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
            }

            return sonuc;
        }

        [FluentValidationAspect(typeof(GnyetbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse Ncch_MultiAdd_Log(List<GNYETB> gnyetb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            //_lockedService.LockControlWrite("GNYETB", gnyetb.Id, global);
            var sonuc = new StandardResponse();
            foreach (var item in gnyetb)
            {
                item.EKKULL = global.UserKod;
                item.ETARIH = DateTime.Now;
                item.KYNKKD = global.KaynakKod;
                item.ACTIVE = true;
            }

            bool _ok = _gnyetbDal.MultiAdd(gnyetb);
            if (_ok)
            {
                sonuc.Status = ResponseStatusEnum.OK;
            }
            else
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
            }

            return sonuc;
        }
        public ListResponse<GNYETB> Cch_GetListYetkiId_NLog(int yetkiid, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNYETB>();
            sonuc.Items = _gnyetbDal.GetList(x => x.YetkId == yetkiid);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
