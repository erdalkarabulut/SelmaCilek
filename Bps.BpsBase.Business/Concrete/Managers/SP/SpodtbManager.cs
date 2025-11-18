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

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.SP
{
    public class SpodtbManager : ISpodtbService
    {
        private ISpodtbDal _spodtbDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public SpodtbManager(ISpodtbDal spodtbDal,IGnService gnservice,ILockedService lockedservice)
        {
            _spodtbDal = spodtbDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<SPODTB> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPODTB>();
            sonuc.Items = global.SirketId != null ? _spodtbDal.GetList(x => x.SIRKID == global.SirketId) : _spodtbDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPODTB> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPODTB>();
            sonuc.Items = global.SirketId != null ? _spodtbDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _spodtbDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPODTB> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPODTB>();
            sonuc.Items = global.SirketId != null ? _spodtbDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _spodtbDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPODTB> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPODTB>();
            sonuc.Items = global.SirketId != null ? _spodtbDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _spodtbDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPODTB> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPODTB>();
            sonuc.Items = global.SirketId != null ? _spodtbDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _spodtbDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPODTB> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<SPODTB>();
            sonuc.Nesne = _spodtbDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPODTB> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("SPODTB", id, global);
            var sonuc = new StandardResponse<SPODTB>();
            sonuc.Nesne = _spodtbDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpodtbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPODTB> Ncch_Add_NLog(SPODTB spodtb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SPODTB>();
            spodtb.SIRKID = global.SirketId.Value; 
            spodtb.EKKULL = global.UserKod;
            spodtb.ETARIH = DateTime.Now;
            spodtb.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spodtbDal.Add(spodtb);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpodtbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPODTB> Ncch_Update_Log(SPODTB spodtb,SPODTB oldSpodtb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SPODTB", spodtb.Id, global);
            var sonuc = new StandardResponse<SPODTB>();
            spodtb.SIRKID = global.SirketId.Value; 
            spodtb.DEKULL = global.UserKod;
            spodtb.DTARIH = DateTime.Now;
            spodtb.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spodtbDal.Update(spodtb);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpodtbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPODTB> Ncch_UpdateAktifPasif_Log(SPODTB spodtb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SPODTB>();
            spodtb.SIRKID = global.SirketId.Value; 
            spodtb.ACTIVE = !spodtb.ACTIVE;
            spodtb.DEKULL = global.UserKod;
            spodtb.DTARIH = DateTime.Now;
            spodtb.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spodtbDal.Update(spodtb);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpodtbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPODTB> Ncch_Delete_Log(SPODTB spodtb, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SPODTB", spodtb.Id, global);
            var sonuc = new StandardResponse<SPODTB>();
            spodtb.SIRKID = global.SirketId.Value; 
            spodtb.ACTIVE = false;
            spodtb.SLINDI = true;
            spodtb.DEKULL = global.UserKod;
            spodtb.DTARIH = DateTime.Now;
            spodtb.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spodtbDal.Update(spodtb);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc
        public ListResponse<SPODTB> Ncch_GetListByBelgeNo_NLog(Global global, string belgeNo)
        {
            var sonuc = new ListResponse<SPODTB>();
            sonuc.Items = _spodtbDal.GetList(x => x.SIRKID == global.SirketId && x.BELGEN == belgeNo &&  x.ACTIVE && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPODTB> Ncch_DeleteKosul_Log(SPODTB spkosl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SPODTB>();
            sonuc.Nesne = _spodtbDal.Delete(spkosl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        #endregion ClientFunc
    }
}
