using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
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
    public class StkmizManager : IStkmizService
    {
        private IStkmizDal _stkmizDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public StkmizManager(IStkmizDal stkmizDal,IGnService gnservice,ILockedService lockedservice)
        {
            _stkmizDal = stkmizDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STKMIZ> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKMIZ>();
            sonuc.Items = global.SirketId != null ? _stkmizDal.GetList(x => x.SIRKID == global.SirketId) : _stkmizDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKMIZ> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKMIZ>();
            sonuc.Items = global.SirketId != null ? _stkmizDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stkmizDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKMIZ> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKMIZ>();
            sonuc.Items = global.SirketId != null ? _stkmizDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stkmizDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKMIZ> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKMIZ>();
            sonuc.Items = global.SirketId != null ? _stkmizDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stkmizDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STKMIZ> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STKMIZ>();
            sonuc.Items = global.SirketId != null ? _stkmizDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stkmizDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STKMIZ> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STKMIZ>();
            sonuc.Nesne = _stkmizDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STKMIZ> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STKMIZ", id, global);
            var sonuc = new StandardResponse<STKMIZ>();
            sonuc.Nesne = _stkmizDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StkmizValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STKMIZ> Ncch_Add_NLog(STKMIZ stkmiz, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STKMIZ>();
            stkmiz.SIRKID = global.SirketId.Value; 
            stkmiz.EKKULL = global.UserKod;
            stkmiz.ETARIH = DateTime.Now;
            stkmiz.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stkmizDal.Add(stkmiz);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StkmizValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STKMIZ> Ncch_Update_Log(STKMIZ stkmiz,STKMIZ oldStkmiz, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STKMIZ", stkmiz.Id, global);
            var sonuc = new StandardResponse<STKMIZ>();
            stkmiz.SIRKID = global.SirketId.Value; 
            stkmiz.DEKULL = global.UserKod;
            stkmiz.DTARIH = DateTime.Now;
            stkmiz.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stkmizDal.Update(stkmiz);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StkmizValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STKMIZ> Ncch_UpdateAktifPasif_Log(STKMIZ stkmiz, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STKMIZ>();
            stkmiz.SIRKID = global.SirketId.Value; 
            stkmiz.ACTIVE = !stkmiz.ACTIVE;
            stkmiz.DEKULL = global.UserKod;
            stkmiz.DTARIH = DateTime.Now;
            stkmiz.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stkmizDal.Update(stkmiz);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StkmizValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STKMIZ> Ncch_Delete_Log(STKMIZ stkmiz, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STKMIZ", stkmiz.Id, global);
            var sonuc = new StandardResponse<STKMIZ>();
            stkmiz.SIRKID = global.SirketId.Value; 
            stkmiz.ACTIVE = false;
            stkmiz.SLINDI = true;
            stkmiz.DEKULL = global.UserKod;
            stkmiz.DTARIH = DateTime.Now;
            stkmiz.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stkmizDal.Update(stkmiz);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public StandardResponse<STKMIZ> Ncch_GetByStokKod_NLog(string stokKod, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }

            var sonuc = new StandardResponse<STKMIZ>();
            sonuc.Nesne = _stkmizDal.Get(x => x.STKODU == stokKod && x.MALIYL == DateTime.Now.Year && x.MALIAY == DateTime.Now.Month  );
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
