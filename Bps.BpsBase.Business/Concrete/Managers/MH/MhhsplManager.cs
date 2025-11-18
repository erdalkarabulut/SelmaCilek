using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.MH;
using Bps.BpsBase.Business.Abstract.MH;
using Bps.BpsBase.DataAccess.Abstract.MH;
using Bps.BpsBase.Entities.Concrete.MH;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.MH
{
    public class MhhsplManager : IMhhsplService
    {
        private IMhhsplDal _mhhsplDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public MhhsplManager(IMhhsplDal mhhsplDal,IGnService gnservice,ILockedService lockedservice)
        {
            _mhhsplDal = mhhsplDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<MHHSPL> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<MHHSPL>();
            sonuc.Items = global.SirketId != null ? _mhhsplDal.GetList(x => x.SIRKID == global.SirketId) : _mhhsplDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<MHHSPL> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<MHHSPL>();
            sonuc.Items = global.SirketId != null ? _mhhsplDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _mhhsplDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<MHHSPL> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<MHHSPL>();
            sonuc.Items = global.SirketId != null ? _mhhsplDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _mhhsplDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<MHHSPL> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<MHHSPL>();
            sonuc.Items = global.SirketId != null ? _mhhsplDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _mhhsplDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<MHHSPL> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<MHHSPL>();
            sonuc.Items = global.SirketId != null ? _mhhsplDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _mhhsplDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<MHHSPL> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<MHHSPL>();
            sonuc.Nesne = _mhhsplDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<MHHSPL> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("MHHSPL", id, global);
            var sonuc = new StandardResponse<MHHSPL>();
            sonuc.Nesne = _mhhsplDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(MhhsplValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<MHHSPL> Ncch_Add_NLog(MHHSPL mhhspl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<MHHSPL>();
            mhhspl.SIRKID = global.SirketId.Value; 
            mhhspl.EKKULL = global.UserKod;
            mhhspl.ETARIH = DateTime.Now;
            mhhspl.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _mhhsplDal.Add(mhhspl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(MhhsplValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<MHHSPL> Ncch_Update_Log(MHHSPL mhhspl,MHHSPL oldMhhspl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("MHHSPL", mhhspl.Id, global);
            var sonuc = new StandardResponse<MHHSPL>();
            mhhspl.SIRKID = global.SirketId.Value; 
            mhhspl.DEKULL = global.UserKod;
            mhhspl.DTARIH = DateTime.Now;
            mhhspl.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _mhhsplDal.Update(mhhspl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(MhhsplValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<MHHSPL> Ncch_UpdateAktifPasif_Log(MHHSPL mhhspl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<MHHSPL>();
            mhhspl.SIRKID = global.SirketId.Value; 
            mhhspl.ACTIVE = !mhhspl.ACTIVE;
            mhhspl.DEKULL = global.UserKod;
            mhhspl.DTARIH = DateTime.Now;
            mhhspl.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _mhhsplDal.Update(mhhspl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(MhhsplValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<MHHSPL> Ncch_Delete_Log(MHHSPL mhhspl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("MHHSPL", mhhspl.Id, global);
            var sonuc = new StandardResponse<MHHSPL>();
            mhhspl.SIRKID = global.SirketId.Value; 
            mhhspl.ACTIVE = false;
            mhhspl.SLINDI = true;
            mhhspl.DEKULL = global.UserKod;
            mhhspl.DTARIH = DateTime.Now;
            mhhspl.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _mhhsplDal.Update(mhhspl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        #endregion ClientFunc
    }
}
