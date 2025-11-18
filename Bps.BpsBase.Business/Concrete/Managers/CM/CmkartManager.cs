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
using Bps.BpsBase.Entities.Models.CM.Single;
#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.CM
{
    public class CmkartManager : ICmkartService
    {
        private ICmkartDal _cmkartDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public CmkartManager(ICmkartDal cmkartDal,IGnService gnservice,ILockedService lockedservice)
        {
            _cmkartDal = cmkartDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<CMKART> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CMKART>();
            sonuc.Items = global.SirketId != null ? _cmkartDal.GetList(x => x.SIRKID == global.SirketId) : _cmkartDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CMKART> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CMKART>();
            sonuc.Items = global.SirketId != null ? _cmkartDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _cmkartDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CMKART> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CMKART>();
            sonuc.Items = global.SirketId != null ? _cmkartDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _cmkartDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CMKART> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CMKART>();
            sonuc.Items = global.SirketId != null ? _cmkartDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _cmkartDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CMKART> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CMKART>();
            sonuc.Items = global.SirketId != null ? _cmkartDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _cmkartDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<CMKART> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<CMKART>();
            sonuc.Nesne = _cmkartDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<CMKART> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("CMKART", id, global);
            var sonuc = new StandardResponse<CMKART>();
            sonuc.Nesne = _cmkartDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CmkartValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CMKART> Ncch_Add_NLog(CMKART cmkart, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<CMKART>();
            cmkart.SIRKID = global.SirketId.Value; 
            cmkart.EKKULL = global.UserKod;
            cmkart.ETARIH = DateTime.Now;
            cmkart.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _cmkartDal.Add(cmkart);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CmkartValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CMKART> Ncch_Update_Log(CMKART cmkart,CMKART oldCmkart, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("CMKART", cmkart.Id, global);
            var sonuc = new StandardResponse<CMKART>();
            cmkart.SIRKID = global.SirketId.Value; 
            cmkart.DEKULL = global.UserKod;
            cmkart.DTARIH = DateTime.Now;
            cmkart.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _cmkartDal.Update(cmkart);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CmkartValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CMKART> Ncch_UpdateAktifPasif_Log(CMKART cmkart, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<CMKART>();
            cmkart.SIRKID = global.SirketId.Value; 
            cmkart.ACTIVE = !cmkart.ACTIVE;
            cmkart.DEKULL = global.UserKod;
            cmkart.DTARIH = DateTime.Now;
            cmkart.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _cmkartDal.Update(cmkart);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CmkartValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CMKART> Ncch_Delete_Log(CMKART cmkart, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("CMKART", cmkart.Id, global);
            var sonuc = new StandardResponse<CMKART>();
            cmkart.SIRKID = global.SirketId.Value; 
            cmkart.ACTIVE = false;
            cmkart.SLINDI = true;
            cmkart.DEKULL = global.UserKod;
            cmkart.DTARIH = DateTime.Now;
            cmkart.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _cmkartDal.Update(cmkart);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<CMKART> Ncch_GetListByParam_NLog(CrmKartParamModel param, Global global, bool yetkiKontrol = true)
        {
	        if (yetkiKontrol)
	        {
		        var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
		        if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
	        }
	        var sonuc = new ListResponse<CMKART>();

	        if (!string.IsNullOrEmpty(param.BELGEN))
	        {
		        sonuc.Items = _cmkartDal.GetList(x => x.SIRKID == global.SirketId && x.BELGEN == param.BELGEN && x.ACTIVE);
	        }
	        else
	        {
		        if (param.DtBitis == null)
		        {
			        sonuc.Items = _cmkartDal.GetList(x => x.SIRKID == global.SirketId && x.BELTRH == param.DtBaslangic && x.ACTIVE);
		        }
		        else
		        {
			        sonuc.Items = _cmkartDal.GetList(x => x.SIRKID == global.SirketId && x.BELTRH >= param.DtBaslangic && x.BELTRH <= param.DtBitis && x.ACTIVE);
		        }
	        }

	        sonuc.Status = ResponseStatusEnum.OK;
	        return sonuc;
        }

        #endregion ClientFunc
    }
}
