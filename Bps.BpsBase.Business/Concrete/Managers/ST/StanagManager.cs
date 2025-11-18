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
    public class StanagManager : IStanagService
    {
        private IStanagDal _stanagDal;
        private IGnService _gnService = InstanceFactory.GetInstance<IGnService>();
        private ILockedService _lockedService = InstanceFactory.GetInstance<ILockedService>();

        #region ClientDals

        #endregion ClientDals

        public StanagManager(IStanagDal stanagDal)
        {
            _stanagDal = stanagDal;
        }

        public ListResponse<STANAG> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STANAG>();
            sonuc.Items = global.SirketId != null ? _stanagDal.GetList(x => x.SIRKID == global.SirketId) : _stanagDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STANAG> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STANAG>();
            sonuc.Items = global.SirketId != null ? _stanagDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stanagDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STANAG> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STANAG>();
            sonuc.Items = global.SirketId != null ? _stanagDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stanagDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STANAG> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STANAG>();
            sonuc.Items = global.SirketId != null ? _stanagDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stanagDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STANAG> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STANAG>();
            sonuc.Items = global.SirketId != null ? _stanagDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stanagDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STANAG> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STANAG>();
            sonuc.Nesne = _stanagDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STANAG> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
             _lockedService.LockControlRead("STANAG", id, global);
            var sonuc = new StandardResponse<STANAG>();
            sonuc.Nesne = _stanagDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StanagValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STANAG> Ncch_Add_NLog(STANAG stanag, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STANAG>();
            stanag.SIRKID = global.SirketId.Value; 
            stanag.EKKULL = global.UserKod;
            stanag.ETARIH = DateTime.Now;
            stanag.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stanagDal.Add(stanag);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StanagValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STANAG> Ncch_Update_Log(STANAG stanag,STANAG oldStanag, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STANAG", stanag.Id, global);
            var sonuc = new StandardResponse<STANAG>();
            stanag.SIRKID = global.SirketId.Value; 
            stanag.DEKULL = global.UserKod;
            stanag.DTARIH = DateTime.Now;
            stanag.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stanagDal.Update(stanag);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StanagValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STANAG> Ncch_UpdateAktifPasif_Log(STANAG stanag, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STANAG>();
            stanag.SIRKID = global.SirketId.Value; 
            stanag.ACTIVE = !stanag.ACTIVE;
            stanag.DEKULL = global.UserKod;
            stanag.DTARIH = DateTime.Now;
            stanag.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stanagDal.Update(stanag);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StanagValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STANAG> Ncch_Delete_Log(STANAG stanag, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STANAG", stanag.Id, global);
            var sonuc = new StandardResponse<STANAG>();
            stanag.SIRKID = global.SirketId.Value; 
            stanag.ACTIVE = false;
            stanag.SLINDI = true;
            stanag.DEKULL = global.UserKod;
            stanag.DTARIH = DateTime.Now;
            stanag.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stanagDal.Update(stanag);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
