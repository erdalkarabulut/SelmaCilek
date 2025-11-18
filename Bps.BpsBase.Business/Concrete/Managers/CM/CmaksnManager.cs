using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.CM;
using Bps.BpsBase.Business.Abstract.CM;
using Bps.BpsBase.DataAccess.Abstract.CM;
using Bps.BpsBase.Entities.Concrete.CM;

#region ClientUsing

using System.Linq;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.CM
{
    public class CmaksnManager : ICmaksnService
    {
        private ICmaksnDal _cmaksnDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public CmaksnManager(ICmaksnDal cmaksnDal,IGnService gnservice,ILockedService lockedservice)
        {
            _cmaksnDal = cmaksnDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<CMAKSN> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CMAKSN>();
            sonuc.Items = global.SirketId != null ? _cmaksnDal.GetList(x => x.SIRKID == global.SirketId) : _cmaksnDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CMAKSN> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CMAKSN>();
            sonuc.Items = global.SirketId != null ? _cmaksnDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _cmaksnDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CMAKSN> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CMAKSN>();
            sonuc.Items = global.SirketId != null ? _cmaksnDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _cmaksnDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CMAKSN> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CMAKSN>();
            sonuc.Items = global.SirketId != null ? _cmaksnDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _cmaksnDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CMAKSN> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CMAKSN>();
            sonuc.Items = global.SirketId != null ? _cmaksnDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _cmaksnDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<CMAKSN> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<CMAKSN>();
            sonuc.Nesne = _cmaksnDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<CMAKSN> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("CMAKSN", id, global);
            var sonuc = new StandardResponse<CMAKSN>();
            sonuc.Nesne = _cmaksnDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CmaksnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CMAKSN> Ncch_Add_NLog(CMAKSN cmaksn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<CMAKSN>();
            cmaksn.SIRKID = global.SirketId.Value; 
            cmaksn.EKKULL = global.UserKod;
            cmaksn.ETARIH = DateTime.Now;
            cmaksn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _cmaksnDal.Add(cmaksn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CmaksnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CMAKSN> Ncch_Update_Log(CMAKSN cmaksn,CMAKSN oldCmaksn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("CMAKSN", cmaksn.Id, global);
            var sonuc = new StandardResponse<CMAKSN>();
            cmaksn.SIRKID = global.SirketId.Value; 
            cmaksn.DEKULL = global.UserKod;
            cmaksn.DTARIH = DateTime.Now;
            cmaksn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _cmaksnDal.Update(cmaksn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CmaksnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CMAKSN> Ncch_UpdateAktifPasif_Log(CMAKSN cmaksn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<CMAKSN>();
            cmaksn.SIRKID = global.SirketId.Value; 
            cmaksn.ACTIVE = !cmaksn.ACTIVE;
            cmaksn.DEKULL = global.UserKod;
            cmaksn.DTARIH = DateTime.Now;
            cmaksn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _cmaksnDal.Update(cmaksn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CmaksnValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CMAKSN> Ncch_Delete_Log(CMAKSN cmaksn, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("CMAKSN", cmaksn.Id, global);
            var sonuc = new StandardResponse<CMAKSN>();
            cmaksn.SIRKID = global.SirketId.Value; 
            cmaksn.ACTIVE = false;
            cmaksn.SLINDI = true;
            cmaksn.DEKULL = global.UserKod;
            cmaksn.DTARIH = DateTime.Now;
            cmaksn.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _cmaksnDal.Update(cmaksn);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<CMAKSN> Ncch_GetListByBelge_NLog(string belgeNo, Global global)
        {
	        var sonuc = new ListResponse<CMAKSN>();
	        sonuc.Items = _cmaksnDal.GetList(x =>
		        x.SIRKID == global.SirketId && x.SLINDI == false && x.ACTIVE && x.BELGEN == belgeNo).ToList();
	        sonuc.Status = ResponseStatusEnum.OK;
	        return sonuc;
        }

        #endregion ClientFunc
    }
}
