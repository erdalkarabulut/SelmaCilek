using System;
using System.Data.SqlClient;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.CR;
using Bps.BpsBase.Business.Abstract.CR;
using Bps.BpsBase.DataAccess.Abstract.CR;
using Bps.BpsBase.Entities.Concrete.CR;
using Bps.BpsBase.Entities.Models.CR.Listed;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.CR
{
    public class CrytklManager : ICrytklService
    {
        private ICrytklDal _crytklDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
		#region ClientDals

		#endregion ClientDals
		#region ClientServices

		#endregion ClientServices

        public CrytklManager(ICrytklDal crytklDal,IGnService gnservice,ILockedService lockedservice)
        {
            _crytklDal = crytklDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<CRYTKL> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRYTKL>();
            sonuc.Items = global.SirketId != null ? _crytklDal.GetList(x => x.SIRKID == global.SirketId) : _crytklDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRYTKL> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRYTKL>();
            sonuc.Items = global.SirketId != null ? _crytklDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _crytklDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRYTKL> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRYTKL>();
            sonuc.Items = global.SirketId != null ? _crytklDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _crytklDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRYTKL> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRYTKL>();
            sonuc.Items = global.SirketId != null ? _crytklDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _crytklDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<CRYTKL> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<CRYTKL>();
            sonuc.Items = global.SirketId != null ? _crytklDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _crytklDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<CRYTKL> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<CRYTKL>();
            sonuc.Nesne = _crytklDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<CRYTKL> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("CRYTKL", id, global);
            var sonuc = new StandardResponse<CRYTKL>();
            sonuc.Nesne = _crytklDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CrytklValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRYTKL> Ncch_Add_NLog(CRYTKL crytkl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<CRYTKL>();
            crytkl.SIRKID = global.SirketId.Value; 
            crytkl.EKKULL = global.UserKod;
            crytkl.ETARIH = DateTime.Now;
            crytkl.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _crytklDal.Add(crytkl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CrytklValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRYTKL> Ncch_Update_Log(CRYTKL crytkl,CRYTKL oldCrytkl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("CRYTKL", crytkl.Id, global);
            var sonuc = new StandardResponse<CRYTKL>();
            crytkl.SIRKID = global.SirketId.Value; 
            crytkl.DEKULL = global.UserKod;
            crytkl.DTARIH = DateTime.Now;
            crytkl.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _crytklDal.Update(crytkl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CrytklValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRYTKL> Ncch_UpdateAktifPasif_Log(CRYTKL crytkl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<CRYTKL>();
            crytkl.SIRKID = global.SirketId.Value; 
            crytkl.ACTIVE = !crytkl.ACTIVE;
            crytkl.DEKULL = global.UserKod;
            crytkl.DTARIH = DateTime.Now;
            crytkl.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _crytklDal.Update(crytkl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(CrytklValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<CRYTKL> Ncch_Delete_Log(CRYTKL crytkl, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("CRYTKL", crytkl.Id, global);
            var sonuc = new StandardResponse<CRYTKL>();
            crytkl.SIRKID = global.SirketId.Value; 
            crytkl.ACTIVE = false;
            crytkl.SLINDI = true;
            crytkl.DEKULL = global.UserKod;
            crytkl.DTARIH = DateTime.Now;
            crytkl.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _crytklDal.Update(crytkl);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

		#region ClientFunc

		public ListResponse<CRYTKL> Cch_GetListByCariKod_NLog(string cariKod, Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			var sonuc = new ListResponse<CRYTKL>();
			sonuc.Items = _crytklDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.CRKODU == cariKod);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<CariYetkiliModel> Ncch_GetCariYetkiliList_NLog(Global global, string crkodu = "", bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			string cariFilter = "";
			if (crkodu != "") cariFilter = " AND CRKODU = @crkodu";

			var sonuc = new ListResponse<CariYetkiliModel>();
			var sql = @"SELECT Id, CRKODU, YETADI, YETSOY, YETUNV, ISYTEL FROM CRYTKL WHERE SIRKID = @sirketId AND ACTIVE = 1" + cariFilter;
			sonuc.Items = _crytklDal.GetListSqlQuery<CariYetkiliModel>(sql, new SqlParameter("sirketId", global.SirketId), new SqlParameter("crkodu", crkodu));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		#endregion ClientFunc
    }
}
