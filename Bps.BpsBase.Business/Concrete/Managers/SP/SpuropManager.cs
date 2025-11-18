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
    public class SpuropManager : ISpuropService
    {
        private ISpuropDal _spuropDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public SpuropManager(ISpuropDal spuropDal,IGnService gnservice,ILockedService lockedservice)
        {
            _spuropDal = spuropDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<SPUROP> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPUROP>();
            sonuc.Items = global.SirketId != null ? _spuropDal.GetList(x => x.SIRKID == global.SirketId) : _spuropDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPUROP> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPUROP>();
            sonuc.Items = global.SirketId != null ? _spuropDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _spuropDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPUROP> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPUROP>();
            sonuc.Items = global.SirketId != null ? _spuropDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _spuropDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPUROP> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPUROP>();
            sonuc.Items = global.SirketId != null ? _spuropDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _spuropDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPUROP> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPUROP>();
            sonuc.Items = global.SirketId != null ? _spuropDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _spuropDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPUROP> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<SPUROP>();
            sonuc.Nesne = _spuropDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPUROP> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("SPUROP", id, global);
            var sonuc = new StandardResponse<SPUROP>();
            sonuc.Nesne = _spuropDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpuropValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPUROP> Ncch_Add_NLog(SPUROP spurop, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SPUROP>();
            spurop.SIRKID = global.SirketId.Value; 
            spurop.EKKULL = global.UserKod;
            spurop.ETARIH = DateTime.Now;
            spurop.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spuropDal.Add(spurop);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpuropValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPUROP> Ncch_Update_Log(SPUROP spurop,SPUROP oldSpurop, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SPUROP", spurop.Id, global);
            var sonuc = new StandardResponse<SPUROP>();
            spurop.SIRKID = global.SirketId.Value; 
            spurop.DEKULL = global.UserKod;
            spurop.DTARIH = DateTime.Now;
            spurop.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spuropDal.Update(spurop);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpuropValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPUROP> Ncch_UpdateAktifPasif_Log(SPUROP spurop, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SPUROP>();
            spurop.SIRKID = global.SirketId.Value; 
            spurop.ACTIVE = !spurop.ACTIVE;
            spurop.DEKULL = global.UserKod;
            spurop.DTARIH = DateTime.Now;
            spurop.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spuropDal.Update(spurop);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpuropValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPUROP> Ncch_Delete_Log(SPUROP spurop, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SPUROP", spurop.Id, global);
            var sonuc = new StandardResponse<SPUROP>();
            spurop.SIRKID = global.SirketId.Value; 
            spurop.ACTIVE = false;
            spurop.SLINDI = true;
            spurop.DEKULL = global.UserKod;
            spurop.DTARIH = DateTime.Now;
            spurop.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spuropDal.Update(spurop);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc
        public ListResponse<SPUROP> Ncch_GetListByBelgeNo_NLog(string belgeNo, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPUROP>();
            sonuc.Items = global.SirketId != null ? _spuropDal.GetList(x => x.BELGEN == belgeNo && x.SIRKID == global.SirketId && x.ACTIVE && x.SLINDI == false) : _spuropDal.GetList(x => x.BELGEN == belgeNo && x.ACTIVE && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        #endregion ClientFunc
    }
}
