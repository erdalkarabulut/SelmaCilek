using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.GN;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.DataAccess.Abstract.GN;
using Bps.BpsBase.Entities.Concrete.GN;

#region ClientUsing

using System.Data.SqlClient;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.GN.Params;
using Bps.Core.Web.Session;
using Bps.BpsBase.Entities.Models.GN.Single;
using Bps.BpsBase.DataAccess.Abstract;
using System.Web;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GnkullManager : IGnkullService
    {
        private IGnkullDal _gnkullDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
		#region ClientDals

		private ISirketDal _sirketDal;

		#endregion ClientDals
		#region ClientServices

		private IGnfileService _gnfileService;

		#endregion ClientServices

        public GnkullManager(IGnkullDal gnkullDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnkullDal = gnkullDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNKULL> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKULL>();
            sonuc.Items = global.SirketId != null ? _gnkullDal.GetList(x => x.SIRKID == global.SirketId) : _gnkullDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKULL> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKULL>();
            sonuc.Items = global.SirketId != null ? _gnkullDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnkullDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKULL> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKULL>();
            sonuc.Items = global.SirketId != null ? _gnkullDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnkullDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKULL> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKULL>();
            sonuc.Items = global.SirketId != null ? _gnkullDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnkullDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNKULL> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNKULL>();
            sonuc.Items = global.SirketId != null ? _gnkullDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnkullDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNKULL> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNKULL>();
            sonuc.Nesne = _gnkullDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNKULL> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNKULL", id, global);
            var sonuc = new StandardResponse<GNKULL>();
            sonuc.Nesne = _gnkullDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnkullValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKULL> Ncch_Add_NLog(GNKULL gnkull, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNKULL>();
            gnkull.SIRKID = global.SirketId.Value; 
            gnkull.EKKULL = global.UserKod;
            gnkull.ETARIH = DateTime.Now;
            gnkull.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnkullDal.Add(gnkull);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnkullValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKULL> Ncch_Update_Log(GNKULL gnkull,GNKULL oldGnkull, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNKULL", gnkull.Id, global);
            var sonuc = new StandardResponse<GNKULL>();
            gnkull.SIRKID = global.SirketId.Value; 
            gnkull.DEKULL = global.UserKod;
            gnkull.DTARIH = DateTime.Now;
            gnkull.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnkullDal.Update(gnkull);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnkullValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKULL> Ncch_UpdateAktifPasif_Log(GNKULL gnkull, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNKULL>();
            gnkull.SIRKID = global.SirketId.Value; 
            gnkull.ACTIVE = !gnkull.ACTIVE;
            gnkull.DEKULL = global.UserKod;
            gnkull.DTARIH = DateTime.Now;
            gnkull.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnkullDal.Update(gnkull);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnkullValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNKULL> Ncch_Delete_Log(GNKULL gnkull, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNKULL", gnkull.Id, global);
            var sonuc = new StandardResponse<GNKULL>();
            gnkull.SIRKID = global.SirketId.Value; 
            gnkull.ACTIVE = false;
            gnkull.SLINDI = true;
            gnkull.DEKULL = global.UserKod;
            gnkull.DTARIH = DateTime.Now;
            gnkull.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnkullDal.Update(gnkull);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

		#region ClientFunc

		public StandardResponse Ncch_UserLogin_Log(GirisParam param)
		{
			var sonuc = new StandardResponse();

			var _depertman = "Genel";
			var _pozisyon = "Genel";
			var response = Ncch_GetKulByLoginInfo_NLog(param.KULKOD, param.PASSWD, new Global() { SirketId = param.SIRKID });
			if (response.Status != ResponseStatusEnum.OK)
			{
				sonuc.Status = ResponseStatusEnum.ERROR;
				sonuc.Message = "Kullanici adi veya sifre hatali!";
			}
			else
			{
				var data = response.Nesne;
				var kullEntity = Cch_GetByUserKod_NLog(param.KULKOD, new Global() { SirketId = param.SIRKID }).Nesne;
				kullEntity.LANGKD = param.DilKod;
				kullEntity.LGNDAT = DateTime.Now;
				kullEntity.KYNKKD = param.KaynakKod;
				_gnkullDal.Update(kullEntity);
				if (data.PERSID != 0)
				{
					_depertman = data.Departman;
					_pozisyon = data.Pozisyon;
				}

				var resimVarMi = false;
				var imagePath = "";
				if (data.GNPATH != null)
				{
					resimVarMi = true;
					imagePath = data.GNPATH;
				}

				var ks = _sirketDal.Get(w => w.SRKTYP == false && w.KARSIS == param.SIRKID);
				SessionHelper.UserLogin(param.SIRKID, ks.Id, true, data.PERSID, data.Id, param.KULKOD, data.GNNAME, data.GNSNAM, data.DEFPRO, 0,
					data.GNMAIL, param.DilKod, data.KYNKKD, data.ROLEKD, _depertman, _pozisyon, data.GNTHEM, resimVarMi, imagePath);
				sonuc.Status = ResponseStatusEnum.OK;
			}
			return sonuc;
		}

		public StandardResponse<GNKULL> Ncch_UserLogin_Log(GirisParam param, string platform)
		{
			var sonuc = new StandardResponse<GNKULL>();
			var data = _gnkullDal.Get(x => x.KULKOD == param.KULKOD && x.PASSWD == param.PASSWD && x.SIRKID == param.SIRKID);

			if (data == null)
			{
				sonuc.Status = ResponseStatusEnum.ERROR;
				sonuc.Message = "Kullanici adi veya sifre hatali!";
				return sonuc;
			}
			sonuc.Nesne = data;
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		[FluentValidationAspect(typeof(GnkullValidator))]
		[CacheRemoveAspect(typeof(MemoryCacheManager))]
		public StandardResponse<GNKULL> UpdateOnlyForLanguage(GNKULL gnkull, Global global)
		{
			var sonuc = new StandardResponse<GNKULL>();
			gnkull.SIRKID = global.SirketId.Value;
			gnkull.KYNKKD = global.KaynakKod;
			sonuc.Nesne = _gnkullDal.Update(gnkull);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		[FluentValidationAspect(typeof(GnkullValidator))]
		public StandardResponse<GNKULL> Cch_GetByUserKod_NLog(string kullKod, Global global)
		{
			var sonuc = new StandardResponse<GNKULL>();
			sonuc.Nesne = _gnkullDal.Get(x => x.KULKOD == kullKod && x.SIRKID == global.SirketId.Value);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<GNKULL> Ncch_GetListByFilter_NLog(Global global, string prokod,
			bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<GNKULL>();
			var wherStr = "and k.DEFPRO=''";
			if (!string.IsNullOrEmpty(prokod)) wherStr = " and k.DEFPRO='" + prokod + "' ";
			var sql = @"select * from GNKULL as k where k.SIRKID=@sirketId and k.SLINDI=0 and k.ACTIVE=1 " + wherStr + "  order by k.GNNAME";
			sonuc.Items = _gnkullDal.GetListSqlQuery<GNKULL>(sql,
				new SqlParameter("sirketId", global.SirketId));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		[FluentValidationAspect(typeof(GnkullValidator))]
		[CacheRemoveAspect(typeof(MemoryCacheManager))]
		public StandardResponse<GNKULL> Ncch_AddWithImage_NLog(GNKULL gnkull, Global global, string imagePath)
		{
			var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
			if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			var sonuc = new StandardResponse<GNKULL>();

			gnkull.SIRKID = global.SirketId.Value;
			gnkull.EKKULL = global.UserKod;
			gnkull.ETARIH = DateTime.Now;
			gnkull.KYNKKD = global.KaynakKod;
			sonuc.Nesne = _gnkullDal.Add(gnkull);
			var imageResponse = _gnfileService.Ncch_SaveorUpdate_Log("GNKULL", gnkull.Id, 0, imagePath, "~/Assets/UploadFolder/GNKULL/", global);
			if (imageResponse.Status == ResponseStatusEnum.OK && imageResponse.Nesne != null)
			{
				HttpContext.Current.Session["ResimVarMi"] = true;
				HttpContext.Current.Session["UserImgPath"] = imageResponse.Nesne.GNPATH;
			}
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		[FluentValidationAspect(typeof(GnkullValidator))]
		[CacheRemoveAspect(typeof(MemoryCacheManager))]
		public StandardResponse<GNKULL> Ncch_UpdateWithImage_Log(GNKULL gnkull, GNKULL oldGnkull, Global global, string imagePath)
		{
			var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
			if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			_lockedService.LockControlWrite("GNKULL", gnkull.Id, global);
			var sonuc = new StandardResponse<GNKULL>();
			gnkull.SIRKID = global.SirketId.Value;
			gnkull.DEKULL = global.UserKod;
			gnkull.DTARIH = DateTime.Now;
			gnkull.KYNKKD = global.KaynakKod;
			sonuc.Nesne = _gnkullDal.Update(gnkull);

			global.IsCompare = false;
			var imageResponse = _gnfileService.Ncch_SaveorUpdate_Log("GNKULL", gnkull.Id, 0, imagePath, "~/Assets/UploadFolder/GNKULL/", global);

			if (imageResponse.Status == ResponseStatusEnum.OK && imageResponse.Nesne != null && global.UserKod == gnkull.KULKOD)
			{

				HttpContext.Current.Session["ResimVarMi"] = true;
				HttpContext.Current.Session["UserImgPath"] = imageResponse.Nesne.GNPATH;
			}
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<KullaniciModel> Ncch_GetListPersJoin_NLog(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<KullaniciModel>();
			var sql = @"select 
		                p.SICILN, p.DEPAKD, p.POZSKD, p.LOKAKD,
		                k.*
		                from GNKULL as k
		                left join IKPERS as p on p.Id=k.PERSID
		                where k.SIRKID=@sirketId and k.SLINDI=0";
			sonuc.Items = _gnkullDal.GetListSqlQuery<KullaniciModel>(sql,
				new SqlParameter("sirketId", global.SirketId));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		[FluentValidationAspect(typeof(GnkullValidator))]
		[CacheRemoveAspect(typeof(MemoryCacheManager))]
		public StandardResponse<GNKULL> SifreKaydet(HesapModel model, Global global)
		{
			var sonuc = new StandardResponse<GNKULL>();

			var kullResponse = Cch_GetByUserKod_NLog(global.UserKod, global);
			if (kullResponse.Status != ResponseStatusEnum.OK || kullResponse.Nesne == null)
			{
				sonuc.Message = "Kullanici bilgileri cekilemedi.";
				sonuc.Status = ResponseStatusEnum.ERROR;
				return sonuc;
			}

			if (string.IsNullOrEmpty(model.MevcutSifre) || string.IsNullOrEmpty(model.YeniSifre) || string.IsNullOrEmpty(model.YeniSifreTekrar))
			{
				sonuc.Message = "Lutfen tum zorunlu alanlari doldurunuz!";
				sonuc.Status = ResponseStatusEnum.ERROR;
				return sonuc;
			}
			if (model.MevcutSifre != kullResponse.Nesne.PASSWD)
			{
				sonuc.Message = "Mevcut sifre dogru degil!";
				sonuc.Status = ResponseStatusEnum.ERROR;
				return sonuc;
			}

			if (model.YeniSifre != model.YeniSifreTekrar)
			{
				sonuc.Message = "Yeni sifre tekrari dogru degil!";
				sonuc.Status = ResponseStatusEnum.ERROR;
				return sonuc;
			}

			if (model.YeniSifre.Length < 4)
			{
				sonuc.Message = "Yeni sifreniz en az 4 karakter olmalidir!";
				sonuc.Status = ResponseStatusEnum.ERROR;
				return sonuc;
			}

			kullResponse.Nesne.PASSWD = model.YeniSifre;
			kullResponse.Nesne.SIRKID = global.SirketId.Value;
			kullResponse.Nesne.DEKULL = global.UserKod;
			kullResponse.Nesne.DTARIH = DateTime.Now;
			kullResponse.Nesne.KYNKKD = global.KaynakKod;
			sonuc.Nesne = _gnkullDal.Update(kullResponse.Nesne);
			_gnkullDal.Update(kullResponse.Nesne);

			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public StandardResponse<KullaniciModel> Ncch_GetKulPersJoinByFilter_NLog(string filter, Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new StandardResponse<KullaniciModel>();
			var sql = @"select 
		                p.SICILN, p.POZSKD, p.LOKAKD,th.TANIMI as DEPAKD,
		                k.GNNAME, k.GNSNAM,k.DEFPRO
		                from GNKULL as k
		                left join IKPERS as p on p.Id=k.PERSID
						left join GNTHRK as th on p.DEPAKD = th.HARKOD
		                where k.SIRKID=@sirketId and k.SLINDI=0 and p.SICILN =@filter and th.TIPKOD = '005'";
			sonuc.Nesne = _gnkullDal.GetSqlQuery<KullaniciModel>(sql,
				new SqlParameter("sirketId", global.SirketId),
				new SqlParameter("filter", filter));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public StandardResponse<KullaniciModel> Ncch_GetKulByLoginInfo_NLog(string kulKod, string passWord, Global global)
		{
			var sonuc = new StandardResponse<KullaniciModel>();
			var sql = @"select 
		                k.*,
		                p.SICILN,
		                p.DEPAKD,
		                p.POZSKD,
		                d.TANIMI as Departman,
		                pz.TANIMI as Pozisyon,
		                f.GNPATH
		                from GNKULL as k
		                left join IKPERS as p on p.Id=k.PERSID and p.SIRKID=@sirketId
		                left join GNTHRK as d on d.TIPKOD='005' and d.HARKOD=p.DEPAKD and d.SIRKID=@sirketId
		                left join GNTHRK as pz on pz.TIPKOD='006' and pz.HARKOD=p.POZSKD and pz.PARENT=d.Id and pz.SIRKID=@sirketId
		                left join GNFILE as f on f.TABLNM='GNKULL' and f.TABLID=k.Id and f.SIRKID=@sirketId
		                where k.SIRKID=@sirketId and k.SLINDI=0 and k.ACTIVE=1
		                and k.KULKOD=@kulkod and k.PASSWD=@password";
			sonuc.Nesne = _gnkullDal.GetSqlQuery<KullaniciModel>(sql,
				new SqlParameter("sirketId", global.SirketId),
				new SqlParameter("kulkod", kulKod ?? ""),
				new SqlParameter("password", passWord ?? ""));

			sonuc.Status = sonuc.Nesne == null ? ResponseStatusEnum.ERROR : ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<GNKULL> Ncch_GetOnlyActiveUsers_NLog(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<GNKULL>();
			sonuc.Items = global.SirketId != null ? _gnkullDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE && !x.SLINDI) : _gnkullDal.GetList();
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<KullNameSurModel> Ncch_GetOnlyAdSoyad_NLog(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<KullNameSurModel>();
			var sql = @"SELECT KULKOD, GNNAME + ' ' + GNSNAM AS GNNAME FROM GNKULL WHERE SIRKID = @sirketId AND ACTIVE = 1";
			sonuc.Items = _gnkullDal.GetListSqlQuery<KullNameSurModel>(sql,
				new SqlParameter("sirketId", global.SirketId));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public StandardResponse<GNKULL> Ncch_GetByPersId_NLog(int id, Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			_lockedService.LockControlRead("GNKULL", id, global);
			var sonuc = new StandardResponse<GNKULL>();
			sonuc.Nesne = _gnkullDal.Get(x => x.PERSID != 0 && x.PERSID == id && x.ACTIVE && !x.SLINDI);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public StandardResponse<GNKULL> Ncch_ChangePassword_NLog(Global global, GNKULL gnkull)
		{
			_lockedService.LockControlWrite("GNKULL", gnkull.Id, global);

			var sonuc = new StandardResponse<GNKULL>();
			gnkull.SIRKID = global.SirketId.Value;
			gnkull.DEKULL = global.UserKod;
			gnkull.DTARIH = DateTime.Now;
			gnkull.KYNKKD = global.KaynakKod;
			sonuc.Nesne = _gnkullDal.Update(gnkull);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<KullaniciMinModel> Ncch_GetKullaniciMinData_NLog(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<KullaniciMinModel>();
			var sql = @"SELECT Id, SIRKID, KULKOD, GNNAME, GNSNAM, GNMAIL, GNTELF, PERSID FROM GNKULL WHERE SIRKID = @sirketId AND ACTIVE = 1";
			sonuc.Items = _gnkullDal.GetListSqlQuery<KullaniciMinModel>(sql,
				new SqlParameter("sirketId", global.SirketId));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		#endregion ClientFunc
    }
}
