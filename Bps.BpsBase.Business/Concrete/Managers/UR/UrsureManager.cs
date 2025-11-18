using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.UR;
using Bps.BpsBase.Business.Abstract.UR;
using Bps.BpsBase.DataAccess.Abstract.UR;
using Bps.BpsBase.Entities.Concrete.UR;


#region ClientUsing
using System.Linq;
#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.UR
{
    public class UrsureManager : IUrsureService
    {
        private IUrsureDal _ursureDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
		#region ClientDals

		#endregion ClientDals
		#region ClientServices

		#endregion ClientServices

        public UrsureManager(IUrsureDal ursureDal,IGnService gnservice,ILockedService lockedservice)
        {
            _ursureDal = ursureDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<URSURE> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<URSURE>();
            sonuc.Items = global.SirketId != null ? _ursureDal.GetList(x => x.SIRKID == global.SirketId) : _ursureDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<URSURE> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<URSURE>();
            sonuc.Items = global.SirketId != null ? _ursureDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _ursureDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<URSURE> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<URSURE>();
            sonuc.Items = global.SirketId != null ? _ursureDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _ursureDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<URSURE> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<URSURE>();
            sonuc.Items = global.SirketId != null ? _ursureDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _ursureDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<URSURE> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<URSURE>();
            sonuc.Items = global.SirketId != null ? _ursureDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _ursureDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<URSURE> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<URSURE>();
            sonuc.Nesne = _ursureDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<URSURE> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("URSURE", id, global);
            var sonuc = new StandardResponse<URSURE>();
            sonuc.Nesne = _ursureDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UrsureValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<URSURE> Ncch_Add_NLog(URSURE ursure, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<URSURE>();
            ursure.SIRKID = global.SirketId.Value; 
            ursure.EKKULL = global.UserKod;
            ursure.ETARIH = DateTime.Now;
            ursure.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _ursureDal.Add(ursure);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UrsureValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<URSURE> Ncch_Update_Log(URSURE ursure,URSURE oldUrsure, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("URSURE", ursure.Id, global);
            var sonuc = new StandardResponse<URSURE>();
            ursure.SIRKID = global.SirketId.Value; 
            ursure.DEKULL = global.UserKod;
            ursure.DTARIH = DateTime.Now;
            ursure.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _ursureDal.Update(ursure);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UrsureValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<URSURE> Ncch_UpdateAktifPasif_Log(URSURE ursure, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<URSURE>();
            ursure.SIRKID = global.SirketId.Value; 
            ursure.ACTIVE = !ursure.ACTIVE;
            ursure.DEKULL = global.UserKod;
            ursure.DTARIH = DateTime.Now;
            ursure.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _ursureDal.Update(ursure);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UrsureValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<URSURE> Ncch_Delete_Log(URSURE ursure, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("URSURE", ursure.Id, global);
            var sonuc = new StandardResponse<URSURE>();
            ursure.SIRKID = global.SirketId.Value; 
            ursure.ACTIVE = false;
            ursure.SLINDI = true;
            ursure.DEKULL = global.UserKod;
            ursure.DTARIH = DateTime.Now;
            ursure.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _ursureDal.Update(ursure);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

		#region ClientFunc

        public ListResponse<URSURE> Ncch_GetUretimSureListByIsplanId_NLog(Global global, int isplanId, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			var sonuc = new ListResponse<URSURE>();
			sonuc.Items = global.SirketId != null ? _ursureDal.GetList(x => x.SIRKID == global.SirketId && x.ISPLID == isplanId && x.ACTIVE).OrderBy(o => o.ISBASL).ToList() :
				_ursureDal.GetList(x => x.ISPLID == isplanId && x.ACTIVE).OrderBy(o => o.ISBASL).ToList();
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

        public ListResponse<URSURE> Ncch_GetUretimAcikSureList_NLog(Global global, bool yetkiKontrol = true)
        {
	        if (yetkiKontrol)
	        {
		        var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
		        if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
	        }

	        var sonuc = new ListResponse<URSURE>();
	        sonuc.Items = global.SirketId != null ? _ursureDal.GetList(x => x.SIRKID == global.SirketId && x.ISBASL != null && x.ISBITS == null && x.ACTIVE).OrderBy(o => o.ISBASL).ToList() :
		        _ursureDal.GetList(x => x.ISBASL != null && x.ISBITS == null && x.ACTIVE).OrderBy(o => o.ISBASL).ToList();
	        sonuc.Status = ResponseStatusEnum.OK;
	        return sonuc;
        }

        public ListResponse<URSURE> Ncch_GetUretimSureListByStokKodu_NLog(Global global, string ispkod, string stokKodu, string gnrezv, string urakod, string uryrkd, bool yetkiKontrol = true)
        {
	        if (yetkiKontrol)
	        {
		        var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
		        if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
	        }

	        var sonuc = new ListResponse<URSURE>();
	        sonuc.Items = global.SirketId != null ? _ursureDal.GetList(x => x.SIRKID == global.SirketId && x.ISPKOD == ispkod && x.STKODU == stokKodu && x.URAKOD == urakod && x.ACTIVE).OrderBy(o => o.ISBASL).ToList() :
		        _ursureDal.GetList(x => x.ISPKOD == ispkod && x.STKODU == stokKodu && x.URAKOD == urakod && x.ACTIVE).OrderBy(o => o.ISBASL).ToList();
	        sonuc.Status = ResponseStatusEnum.OK;
	        return sonuc;
        }

        [FluentValidationAspect(typeof(UrsureValidator))]
		[CacheRemoveAspect(typeof(MemoryCacheManager))]
		public StandardResponse<URSURE> Ncch_UretimSureKaydet_NLog(URSURE ursure, Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			var sonuc = new StandardResponse<URSURE>();

			if (ursure.Id == 0)
			{
				ursure.SIRKID = global.SirketId.Value;
				ursure.EKKULL = global.UserKod;
				ursure.ETARIH = DateTime.Now;
				ursure.KYNKKD = global.KaynakKod;
				sonuc.Nesne = _ursureDal.Add(ursure);
				sonuc.Status = ResponseStatusEnum.OK;
			}
			else
			{
				ursure.DEKULL = global.UserKod;
				ursure.DTARIH = DateTime.Now;
				sonuc.Nesne = _ursureDal.Update(ursure);
				sonuc.Status = ResponseStatusEnum.OK;
			}

			return sonuc;
		}

		#endregion ClientFunc
    }
}
