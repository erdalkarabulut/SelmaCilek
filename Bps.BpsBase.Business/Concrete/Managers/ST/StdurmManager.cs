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
    public class StdurmManager : IStdurmService
    {
        private IStdurmDal _stdurmDal;
        private IGnService _gnService = InstanceFactory.GetInstance<IGnService>();
        private ILockedService _lockedService = InstanceFactory.GetInstance<ILockedService>();

        #region ClientDals

        #endregion ClientDals

        public StdurmManager(IStdurmDal stdurmDal)
        {
            _stdurmDal = stdurmDal;
        }

        public ListResponse<STDURM> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDURM>();
            sonuc.Items = global.SirketId != null ? _stdurmDal.GetList(x => x.SIRKID == global.SirketId) : _stdurmDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STDURM> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDURM>();
            sonuc.Items = global.SirketId != null ? _stdurmDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stdurmDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STDURM> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDURM>();
            sonuc.Items = global.SirketId != null ? _stdurmDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stdurmDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STDURM> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDURM>();
            sonuc.Items = global.SirketId != null ? _stdurmDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stdurmDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STDURM> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDURM>();
            sonuc.Items = global.SirketId != null ? _stdurmDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stdurmDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STDURM> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STDURM>();
            sonuc.Nesne = _stdurmDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STDURM> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
             _lockedService.LockControlRead("STDURM", id, global);
            var sonuc = new StandardResponse<STDURM>();
            sonuc.Nesne = _stdurmDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StdurmValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STDURM> Ncch_Add_NLog(STDURM stdurm, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STDURM>();
            stdurm.SIRKID = global.SirketId.Value; 
            stdurm.EKKULL = global.UserKod;
            stdurm.ETARIH = DateTime.Now;
            stdurm.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stdurmDal.Add(stdurm);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StdurmValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STDURM> Ncch_Update_Log(STDURM stdurm,STDURM oldStdurm, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STDURM", stdurm.Id, global);
            var sonuc = new StandardResponse<STDURM>();
            stdurm.SIRKID = global.SirketId.Value; 
            stdurm.DEKULL = global.UserKod;
            stdurm.DTARIH = DateTime.Now;
            stdurm.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stdurmDal.Update(stdurm);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StdurmValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STDURM> Ncch_UpdateAktifPasif_Log(STDURM stdurm, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STDURM>();
            stdurm.SIRKID = global.SirketId.Value; 
            stdurm.ACTIVE = !stdurm.ACTIVE;
            stdurm.DEKULL = global.UserKod;
            stdurm.DTARIH = DateTime.Now;
            stdurm.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stdurmDal.Update(stdurm);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StdurmValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STDURM> Ncch_Delete_Log(STDURM stdurm, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STDURM", stdurm.Id, global);
            var sonuc = new StandardResponse<STDURM>();
            stdurm.SIRKID = global.SirketId.Value; 
            stdurm.ACTIVE = false;
            stdurm.SLINDI = true;
            stdurm.DEKULL = global.UserKod;
            stdurm.DTARIH = DateTime.Now;
            stdurm.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stdurmDal.Update(stdurm);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
