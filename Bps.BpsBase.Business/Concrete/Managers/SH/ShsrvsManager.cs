using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.SH;
using Bps.BpsBase.Business.Abstract.SH;
using Bps.BpsBase.DataAccess.Abstract.SH;
using Bps.BpsBase.Entities.Concrete.SH;
using Bps.BpsBase.Entities.Models.SP.Single;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.SH
{
    public class ShsrvsManager : IShsrvsService
    {
        private IShsrvsDal _shsrvsDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
		#region ClientDals

		#endregion ClientDals
		#region ClientServices

		#endregion ClientServices

        public ShsrvsManager(IShsrvsDal shsrvsDal,IGnService gnservice,ILockedService lockedservice)
        {
            _shsrvsDal = shsrvsDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<SHSRVS> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SHSRVS>();
            sonuc.Items = global.SirketId != null ? _shsrvsDal.GetList(x => x.SIRKID == global.SirketId) : _shsrvsDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SHSRVS> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SHSRVS>();
            sonuc.Items = global.SirketId != null ? _shsrvsDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _shsrvsDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SHSRVS> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SHSRVS>();
            sonuc.Items = global.SirketId != null ? _shsrvsDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _shsrvsDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SHSRVS> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SHSRVS>();
            sonuc.Items = global.SirketId != null ? _shsrvsDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _shsrvsDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SHSRVS> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SHSRVS>();
            sonuc.Items = global.SirketId != null ? _shsrvsDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _shsrvsDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SHSRVS> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<SHSRVS>();
            sonuc.Nesne = _shsrvsDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SHSRVS> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("SHSRVS", id, global);
            var sonuc = new StandardResponse<SHSRVS>();
            sonuc.Nesne = _shsrvsDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(ShsrvsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SHSRVS> Ncch_Add_NLog(SHSRVS shsrvs, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SHSRVS>();
            shsrvs.SIRKID = global.SirketId.Value; 
            shsrvs.EKKULL = global.UserKod;
            shsrvs.ETARIH = DateTime.Now;
            shsrvs.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _shsrvsDal.Add(shsrvs);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(ShsrvsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SHSRVS> Ncch_Update_Log(SHSRVS shsrvs,SHSRVS oldShsrvs, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SHSRVS", shsrvs.Id, global);
            var sonuc = new StandardResponse<SHSRVS>();
            shsrvs.SIRKID = global.SirketId.Value; 
            shsrvs.DEKULL = global.UserKod;
            shsrvs.DTARIH = DateTime.Now;
            shsrvs.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _shsrvsDal.Update(shsrvs);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(ShsrvsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SHSRVS> Ncch_UpdateAktifPasif_Log(SHSRVS shsrvs, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SHSRVS>();
            shsrvs.SIRKID = global.SirketId.Value; 
            shsrvs.ACTIVE = !shsrvs.ACTIVE;
            shsrvs.DEKULL = global.UserKod;
            shsrvs.DTARIH = DateTime.Now;
            shsrvs.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _shsrvsDal.Update(shsrvs);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(ShsrvsValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SHSRVS> Ncch_Delete_Log(SHSRVS shsrvs, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SHSRVS", shsrvs.Id, global);
            var sonuc = new StandardResponse<SHSRVS>();
            shsrvs.SIRKID = global.SirketId.Value; 
            shsrvs.ACTIVE = false;
            shsrvs.SLINDI = true;
            shsrvs.DEKULL = global.UserKod;
            shsrvs.DTARIH = DateTime.Now;
            shsrvs.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _shsrvsDal.Update(shsrvs);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

		#region ClientFunc

		public StandardResponse<SHSRVS> Ncch_GetByBelgeNo_NLog(string belgeNo, Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new StandardResponse<SHSRVS>();
			sonuc.Nesne = _shsrvsDal.Get(x => x.BELGEN == belgeNo);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<SHSRVS> Ncch_GetList_NLog(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<SHSRVS>();
			sonuc.Items = global.SirketId != null ? _shsrvsDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _shsrvsDal.GetList(x => x.SLINDI == false);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public StandardResponse<SHSRVS> Ncch_UpdateFromApi_Log(SHSRVS shsrvs, SHSRVS oldShsrvs, Global global)
		{
			_lockedService.LockControlWrite("SHSRVS", shsrvs.Id, global);
			var sonuc = new StandardResponse<SHSRVS>();
			shsrvs.SIRKID = global.SirketId.Value;
			shsrvs.DEKULL = global.UserKod;
			shsrvs.DTARIH = DateTime.Now;
			shsrvs.KYNKKD = global.KaynakKod;
			sonuc.Nesne = _shsrvsDal.Update(shsrvs);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<SHSRVS> Cch_GetListByParam_NLog(SshParamModel param, Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<SHSRVS>();

			if (!string.IsNullOrEmpty(param.BELGEN))
			{
				sonuc.Items = _shsrvsDal.GetList(x => x.SIRKID == global.SirketId && x.BELGEN == param.BELGEN && x.ACTIVE);
			}
			else
			{
				if (param.All)
				{
					sonuc.Items = _shsrvsDal.GetList(x =>
						x.SIRKID == global.SirketId && x.SRTLTR >= param.DtBaslangic && x.SRTLTR <= param.DtBitis && x.ACTIVE);
				}
				else
				{
					if (param.DtBitis == null)
					{
						if (param.DtBaslangic == null) //Mobil'e giden liste
						{
							sonuc.Items = _shsrvsDal.GetList(x => x.SIRKID == global.SirketId && x.SRVDRM != "03" && x.ACTIVE);
						}
						else if (param.Tamamlanan)
						{
							sonuc.Items = _shsrvsDal.GetList(x => x.SIRKID == global.SirketId && x.SRTLTR == param.DtBaslangic && x.SRVDRM == "03" && x.ACTIVE);
						}
						else
						{
							sonuc.Items = _shsrvsDal.GetList(x => x.SIRKID == global.SirketId && x.SRTLTR > param.DtBaslangic && x.SRVDRM != "03" && x.ACTIVE);
						}
					}
					else
					{
						if (param.Tamamlanan)
						{
							sonuc.Items = _shsrvsDal.GetList(x => x.SIRKID == global.SirketId && x.SRTLTR >= param.DtBaslangic && x.BELTRH <= param.DtBitis && x.SRVDRM == "03" && x.ACTIVE);
						}
						else
						{
							sonuc.Items = _shsrvsDal.GetList(x => x.SIRKID == global.SirketId && x.SRTLTR >= param.DtBaslangic && x.BELTRH <= param.DtBitis && x.SRVDRM != "03" && x.ACTIVE);
						}
					}
				}
			}

			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		#endregion ClientFunc
    }
}
