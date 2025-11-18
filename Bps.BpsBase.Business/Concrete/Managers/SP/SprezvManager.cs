using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.SP;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.DataAccess.Abstract.SP;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

using System.Linq;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.SP
{
    public class SprezvManager : ISprezvService
    {
        private ISprezvDal _sprezvDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public SprezvManager(ISprezvDal sprezvDal,IGnService gnservice,ILockedService lockedservice)
        {
            _sprezvDal = sprezvDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<SPREZV> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPREZV>();
            sonuc.Items = global.SirketId != null ? _sprezvDal.GetList(x => x.SIRKID == global.SirketId) : _sprezvDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPREZV> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPREZV>();
            sonuc.Items = global.SirketId != null ? _sprezvDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _sprezvDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPREZV> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPREZV>();
            sonuc.Items = global.SirketId != null ? _sprezvDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _sprezvDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPREZV> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPREZV>();
            sonuc.Items = global.SirketId != null ? _sprezvDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _sprezvDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPREZV> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPREZV>();
            sonuc.Items = global.SirketId != null ? _sprezvDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _sprezvDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPREZV> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<SPREZV>();
            sonuc.Nesne = _sprezvDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPREZV> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("SPREZV", id, global);
            var sonuc = new StandardResponse<SPREZV>();
            sonuc.Nesne = _sprezvDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SprezvValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPREZV> Ncch_Add_NLog(SPREZV sprezv, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SPREZV>();
            sprezv.SIRKID = global.SirketId.Value; 
            sprezv.EKKULL = global.UserKod;
            sprezv.ETARIH = DateTime.Now;
            sprezv.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sprezvDal.Add(sprezv);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SprezvValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPREZV> Ncch_Update_Log(SPREZV sprezv,SPREZV oldSprezv, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SPREZV", sprezv.Id, global);
            var sonuc = new StandardResponse<SPREZV>();
            sprezv.SIRKID = global.SirketId.Value; 
            sprezv.DEKULL = global.UserKod;
            sprezv.DTARIH = DateTime.Now;
            sprezv.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sprezvDal.Update(sprezv);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SprezvValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPREZV> Ncch_UpdateAktifPasif_Log(SPREZV sprezv, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SPREZV>();
            sprezv.SIRKID = global.SirketId.Value; 
            sprezv.ACTIVE = !sprezv.ACTIVE;
            sprezv.DEKULL = global.UserKod;
            sprezv.DTARIH = DateTime.Now;
            sprezv.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sprezvDal.Update(sprezv);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SprezvValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPREZV> Ncch_Delete_Log(SPREZV sprezv, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SPREZV", sprezv.Id, global);
            var sonuc = new StandardResponse<SPREZV>();
            sprezv.SIRKID = global.SirketId.Value; 
            sprezv.ACTIVE = false;
            sprezv.SLINDI = true;
            sprezv.DEKULL = global.UserKod;
            sprezv.DTARIH = DateTime.Now;
            sprezv.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sprezvDal.Update(sprezv);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<SPREZV> Ncch_GetAcikList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPREZV>();
            //sonuc.Items = global.SirketId != null ? _sprezvDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.KLMKTR != null && x.KLMKTR > 0).OrderBy(x => x.ETARIH).ToList() : _sprezvDal.GetList(x => x.SLINDI == false);
            sonuc.Items = global.SirketId != null ? _sprezvDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE).OrderBy(x => x.ETARIH).ToList() : _sprezvDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }


        public ListResponse<SPREZV> Ncch_GetListBySiparisBelgeNo_NLog(Global global, string siparisBelgeNo, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPREZV>();
            //sonuc.Items = global.SirketId != null ? _sprezvDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.KLMKTR != null && x.KLMKTR > 0).OrderBy(x => x.ETARIH).ToList() : _sprezvDal.GetList(x => x.SLINDI == false);
            sonuc.Items = global.SirketId != null ? _sprezvDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE && x.SPBLNO == siparisBelgeNo).OrderBy(x => x.ETARIH).ToList() : _sprezvDal.GetList(x => x.SLINDI == false && x.SPBLNO == siparisBelgeNo);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        #endregion ClientFunc
    }
}
