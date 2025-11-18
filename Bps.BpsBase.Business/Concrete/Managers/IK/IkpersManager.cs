using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.IK;
using Bps.BpsBase.Business.Abstract.IK;
using Bps.BpsBase.DataAccess.Abstract.IK;
using Bps.BpsBase.Entities.Concrete.IK;

#region ClientUsing

using Bps.BpsBase.Entities.Concrete.GN;
using System.Collections.Generic;
using Bps.BpsBase.Entities.Models.IK.Listed;
using System.Linq;
using System.Data.SqlClient;
using Bps.BpsBase.DataAccess.Abstract.GN;
using Bps.Core.Utilities.WinForm;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.IK
{
	public class IkpersManager : IIkpersService
	{
		private IIkpersDal _ikpersDal;
		private IGnService _gnService;
		private ILockedService _lockedService;
		#region ClientDals

		private IGndpzmDal _gndpzmDal;
		private IGnklopDal _gnklopDal;

		#endregion ClientDals
		#region ClientServices

		private IGnfileService _gnfileService;

		#endregion ClientServices

		public IkpersManager(IIkpersDal ikpersDal, IGnService gnservice, ILockedService lockedservice, IGnklopDal gnklopDal, IGndpzmDal gndpzmDal, IGnfileService gnfileService)
		{
			_ikpersDal = ikpersDal;
			_gnService = gnservice;
			_gnklopDal = gnklopDal;
			_gndpzmDal = gndpzmDal;
			_gnfileService = gnfileService;
			_lockedService = lockedservice;
		}

		public ListResponse<IKPERS> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<IKPERS>();
			sonuc.Items = global.SirketId != null ? _ikpersDal.GetList(x => x.SIRKID == global.SirketId) : _ikpersDal.GetList();
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<IKPERS> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<IKPERS>();
			sonuc.Items = global.SirketId != null ? _ikpersDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _ikpersDal.GetList(x => x.SLINDI == false);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<IKPERS> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<IKPERS>();
			sonuc.Items = global.SirketId != null ? _ikpersDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _ikpersDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<IKPERS> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<IKPERS>();
			sonuc.Items = global.SirketId != null ? _ikpersDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _ikpersDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<IKPERS> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<IKPERS>();
			sonuc.Items = global.SirketId != null ? _ikpersDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _ikpersDal.GetList(x => x.SLINDI);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public StandardResponse<IKPERS> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new StandardResponse<IKPERS>();
			sonuc.Nesne = _ikpersDal.Get(x => x.Id == id);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public StandardResponse<IKPERS> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			_lockedService.LockControlRead("IKPERS", id, global);
			var sonuc = new StandardResponse<IKPERS>();
			sonuc.Nesne = _ikpersDal.Get(x => x.Id == id);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		[FluentValidationAspect(typeof(IkpersValidator))]
		[CacheRemoveAspect(typeof(MemoryCacheManager))]
		public StandardResponse<IKPERS> Ncch_Add_NLog(IKPERS ikpers, Global global)
		{
			var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
			if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			var sonuc = new StandardResponse<IKPERS>();
			ikpers.SIRKID = global.SirketId.Value;
			ikpers.EKKULL = global.UserKod;
			ikpers.ETARIH = DateTime.Now;
			ikpers.KYNKKD = global.KaynakKod;
			sonuc.Nesne = _ikpersDal.Add(ikpers);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		[FluentValidationAspect(typeof(IkpersValidator))]
		[CacheRemoveAspect(typeof(MemoryCacheManager))]
		public StandardResponse<IKPERS> Ncch_Update_Log(IKPERS ikpers, IKPERS oldIkpers, Global global)
		{
			var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
			if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			_lockedService.LockControlWrite("IKPERS", ikpers.Id, global);
			var sonuc = new StandardResponse<IKPERS>();
			ikpers.SIRKID = global.SirketId.Value;
			ikpers.DEKULL = global.UserKod;
			ikpers.DTARIH = DateTime.Now;
			ikpers.KYNKKD = global.KaynakKod;
			sonuc.Nesne = _ikpersDal.Update(ikpers);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		[FluentValidationAspect(typeof(IkpersValidator))]
		[CacheRemoveAspect(typeof(MemoryCacheManager))]
		public StandardResponse<IKPERS> Ncch_UpdateAktifPasif_Log(IKPERS ikpers, Global global)
		{
			var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
			if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			var sonuc = new StandardResponse<IKPERS>();
			ikpers.SIRKID = global.SirketId.Value;
			ikpers.ACTIVE = !ikpers.ACTIVE;
			ikpers.DEKULL = global.UserKod;
			ikpers.DTARIH = DateTime.Now;
			ikpers.KYNKKD = global.KaynakKod;
			sonuc.Nesne = _ikpersDal.Update(ikpers);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		[FluentValidationAspect(typeof(IkpersValidator))]
		[CacheRemoveAspect(typeof(MemoryCacheManager))]
		public StandardResponse<IKPERS> Ncch_Delete_Log(IKPERS ikpers, Global global)
		{
			var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
			if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			_lockedService.LockControlWrite("IKPERS", ikpers.Id, global);
			var sonuc = new StandardResponse<IKPERS>();
			ikpers.SIRKID = global.SirketId.Value;
			ikpers.ACTIVE = false;
			ikpers.SLINDI = true;
			ikpers.DEKULL = global.UserKod;
			ikpers.DTARIH = DateTime.Now;
			ikpers.KYNKKD = global.KaynakKod;
			sonuc.Nesne = _ikpersDal.Update(ikpers);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		#region ClientFunc
		[FluentValidationAspect(typeof(IkpersValidator))]
		[CacheRemoveAspect(typeof(MemoryCacheManager))]
		public StandardResponse<IKPERS> Ncch_AddWithImage_NLog(IKPERS ikpers, Global global, string imagePath)
		{
			var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
			if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			var sonuc = new StandardResponse<IKPERS>();

			ikpers.SIRKID = global.SirketId.Value;
			ikpers.EKKULL = global.UserKod;
			ikpers.ETARIH = DateTime.Now;
			ikpers.KYNKKD = global.KaynakKod;
			sonuc.Nesne = _ikpersDal.Add(ikpers);

			var imageResponse = _gnfileService.Ncch_SaveorUpdate_Log("IKPERS", ikpers.Id, 0, imagePath, "../../Assets/Images/UploadControl/UploadFolder/personnels/", global);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		[FluentValidationAspect(typeof(IkpersValidator))]
		[CacheRemoveAspect(typeof(MemoryCacheManager))]
		public StandardResponse<IKPERS> Ncch_UpdateWithImage_Log(IKPERS ikpers, IKPERS oldIkpers, Global global, string imagePath)
		{
			var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
			if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			_lockedService.LockControlWrite("IKPERS", ikpers.Id, global);
			var sonuc = new StandardResponse<IKPERS>();
			ikpers.SIRKID = global.SirketId.Value;
			ikpers.DEKULL = global.UserKod;
			ikpers.DTARIH = DateTime.Now;
			ikpers.KYNKKD = global.KaynakKod;
			sonuc.Nesne = _ikpersDal.Update(ikpers);

			var imageResponse = _gnfileService.Ncch_SaveorUpdate_Log("IKPERS", ikpers.Id, 0, imagePath, "../../Assets/Images/UploadControl/UploadFolder/personnels/", global);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<IKPERS> Ncch_GetListByOnlineDep_NLog(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<IKPERS>();
			sonuc.Items = global.SirketId != null ? _ikpersDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false && x.DEPAKD == "2") : _ikpersDal.GetList(x => x.ACTIVE == true && x.SLINDI == false && x.DEPAKD == "2");// Online Depakd yi cekip verebiliriz.
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<IKPERS> Ncch_GetList_NLog(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<IKPERS>();
			sonuc.Items = global.SirketId != null ? _ikpersDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _ikpersDal.GetList(x => x.SLINDI == false);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<IkpersSicilAdPozModel> Ncch_GetListPersonelSicilAdPoz_NLog(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			var sonuc = new ListResponse<IkpersSicilAdPozModel> { Items = new List<IkpersSicilAdPozModel>() };
			var sql = @"SELECT dbo.IKPERS.Id, dbo.IKPERS.SICILN, dbo.IKPERS.GNNAME + ' ' + dbo.IKPERS.GNSNAM AS GNNAME, dbo.GNTHRK.TANIMI AS POZSYN, dbo.IKPERS.ISYKOD, 
						dbo.ISYRTN.TANIMI AS ISYTNM, CINSKD FROM dbo.IKPERS
                        LEFT OUTER JOIN dbo.GNTHRK ON dbo.IKPERS.POZSKD = dbo.GNTHRK.HARKOD AND dbo.GNTHRK.TIPKOD = '006' AND dbo.IKPERS.SIRKID = dbo.GNTHRK.SIRKID
						LEFT OUTER JOIN dbo.ISYRTN ON dbo.IKPERS.ISYKOD = dbo.ISYRTN.ISYKOD AND dbo.IKPERS.SIRKID = dbo.ISYRTN.SIRKID
                        WHERE (dbo.IKPERS.ACTIVE = 1) AND (dbo.IKPERS.SLINDI = 0) AND (dbo.IKPERS.SIRKID = @SirketId)";

			sonuc.Items = _ikpersDal.GetListSqlQuery<IkpersSicilAdPozModel>(sql, new SqlParameter("SirketId", global.SirketId));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		[CacheRemoveAspect("Bps.BpsBase.Business.Concrete.Managers.ST.", typeof(MemoryCacheManager))]
		public StandardResponse Ncch_PersonelKaydet_Log(Global global, IKPERS model, List<GNDPZM> depos, List<GNKLOP> personelOperasyonList, List<Core.Utilities.WinForm.Grid> grids, string _action, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new StandardResponse();

			var fhGnDepos = grids.Where(f => f.View == "GNDPZM").ToList();

			#region Personel

			model.SIRKID = global.SirketId.Value;
			model.KYNKKD = global.KaynakKod;
			model.ACTIVE = true;
			model.SLINDI = false;

			if (_action == "insert")
			{
				model.EKKULL = global.UserKod;
				model.ETARIH = DateTime.Now;
				_ikpersDal.Add(model);
			}
			else if (model.Id > 0 && _action == "update")
			{
				model.DEKULL = global.UserKod;
				model.DTARIH = DateTime.Now;
				_ikpersDal.Update(model);
			}
			else if (_action == "delete")
			{
				model.DEKULL = global.UserKod;
				model.DTARIH = DateTime.Now;
				model.ACTIVE = false;
				model.SLINDI = true;
				_ikpersDal.Update(model);
			}

			#endregion

			#region Depo Zimmet

			if (depos != null)
			{
				var inserted = depos.Where(w => w.Id == 0).ToList();
				foreach (var data in inserted)
				{
					data.SIRKID = global.SirketId.Value;
					data.KYNKKD = global.KaynakKod;
					data.ACTIVE = true;
					data.SLINDI = false;
					data.EKKULL = global.UserKod;
					data.ETARIH = DateTime.Now;
					_gndpzmDal.Add(data);
				}

				foreach (Grid grid in fhGnDepos)
				{
					if (grid.Tipi == "update")
					{
						var data = depos.FirstOrDefault(f => f.Id == grid.Id);
						data.ACTIVE = true;
						data.SLINDI = false;
						data.DEKULL = global.UserKod;
						data.DTARIH = DateTime.Now;
						_gndpzmDal.Update(data);
					}
					else if (grid.Tipi == "delete")
					{
						GNDPZM gndpzm = _gndpzmDal.Get(g => g.Id == grid.Id);
						gndpzm.ACTIVE = false;
						gndpzm.SLINDI = true;
						gndpzm.DEKULL = global.UserKod;
						gndpzm.DTARIH = DateTime.Now;
						_gndpzmDal.Delete(gndpzm);
					}
				}

				if (_action == "delete")
				{
					foreach (var data in depos)
					{
						data.ACTIVE = false;
						data.SLINDI = true;
						data.DEKULL = global.UserKod;
						data.DTARIH = DateTime.Now;
						_gndpzmDal.Update(data);
					}
				}
			}

			#endregion

			#region Personel Operasyon

			if (model.Id > 0)
			{
				var sql = @"DELETE FROM GNKLOP WHERE PERSID = @PersId AND SIRKID = @SirketId";
				_gnklopDal.ExecuteSqlQuery(sql, new SqlParameter("@SirketId", global.SirketId), new SqlParameter("@PersId", model.Id));

				foreach (GNKLOP gnklop in personelOperasyonList) _gnklopDal.Add(gnklop);
			}

			#endregion

			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}
		#endregion ClientFunc
	}
}
