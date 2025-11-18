using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.IS;
using Bps.BpsBase.Business.Abstract.IS;
using Bps.BpsBase.DataAccess.Abstract.IS;
using Bps.BpsBase.Entities.Concrete.IS;

#region ClientUsing

using Bps.BpsBase.Entities.Models.IS.Listed;
using Bps.BpsBase.Entities.Models.IS.Single;
using System.Data.SqlClient;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.IS
{
    public class IsplanManager : IIsplanService
    {
        private IIsplanDal _isplanDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
		#region ClientDals

		#endregion ClientDals
		#region ClientServices

		#endregion ClientServices

        public IsplanManager(IIsplanDal isplanDal,IGnService gnservice,ILockedService lockedservice)
        {
            _isplanDal = isplanDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<ISPLAN> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISPLAN>();
            sonuc.Items = global.SirketId != null ? _isplanDal.GetList(x => x.SIRKID == global.SirketId) : _isplanDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISPLAN> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISPLAN>();
            sonuc.Items = global.SirketId != null ? _isplanDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _isplanDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISPLAN> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISPLAN>();
            sonuc.Items = global.SirketId != null ? _isplanDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _isplanDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISPLAN> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISPLAN>();
            sonuc.Items = global.SirketId != null ? _isplanDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _isplanDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ISPLAN> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<ISPLAN>();
            sonuc.Items = global.SirketId != null ? _isplanDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _isplanDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<ISPLAN> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<ISPLAN>();
            sonuc.Nesne = _isplanDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<ISPLAN> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("ISPLAN", id, global);
            var sonuc = new StandardResponse<ISPLAN>();
            sonuc.Nesne = _isplanDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsplanValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISPLAN> Ncch_Add_NLog(ISPLAN isplan, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<ISPLAN>();
            isplan.SIRKID = global.SirketId.Value; 
            isplan.EKKULL = global.UserKod;
            isplan.ETARIH = DateTime.Now;
            isplan.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isplanDal.Add(isplan);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsplanValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISPLAN> Ncch_Update_Log(ISPLAN isplan,ISPLAN oldIsplan, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("ISPLAN", isplan.Id, global);
            var sonuc = new StandardResponse<ISPLAN>();
            isplan.SIRKID = global.SirketId.Value; 
            isplan.DEKULL = global.UserKod;
            isplan.DTARIH = DateTime.Now;
            isplan.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isplanDal.Update(isplan);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsplanValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISPLAN> Ncch_UpdateAktifPasif_Log(ISPLAN isplan, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<ISPLAN>();
            isplan.SIRKID = global.SirketId.Value; 
            isplan.ACTIVE = !isplan.ACTIVE;
            isplan.DEKULL = global.UserKod;
            isplan.DTARIH = DateTime.Now;
            isplan.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isplanDal.Update(isplan);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(IsplanValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<ISPLAN> Ncch_Delete_Log(ISPLAN isplan, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("ISPLAN", isplan.Id, global);
            var sonuc = new StandardResponse<ISPLAN>();
            isplan.SIRKID = global.SirketId.Value; 
            isplan.ACTIVE = false;
            isplan.SLINDI = true;
            isplan.DEKULL = global.UserKod;
            isplan.DTARIH = DateTime.Now;
            isplan.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _isplanDal.Update(isplan);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

		#region ClientFunc

		public ListResponse<ISPLAN> Cch_GetListByParam_NLog(IsPlaniParamModel param, Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<ISPLAN>();

			if (!string.IsNullOrEmpty(param.PlanNo))
			{
				sonuc.Items = _isplanDal.GetList(x => x.SIRKID == global.SirketId && x.ISPKOD == param.PlanNo && x.ACTIVE);
			}
			else
			{
				if (param.DtBitis == null)
				{
					sonuc.Items = _isplanDal.GetList(x => x.SIRKID == global.SirketId && x.GNTARH == param.DtBaslangic && x.ACTIVE);
				}
				else
				{
					sonuc.Items = _isplanDal.GetList(x => x.SIRKID == global.SirketId && x.GNTARH >= param.DtBaslangic && x.GNTARH <= param.DtBitis && x.ACTIVE);
				}
			}

			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<IsplanUrunParcaModel> Ncch_GetIsplanUrunParcaList_NLog(Global global, string planNo = "", bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			var sonuc = new ListResponse<IsplanUrunParcaModel>();

			string filter = "";
			if (planNo != "") filter = " AND ISPKOD = '" + planNo + "' ";

			var sql = @"SELECT dbo.ISPLAN.SIRKID, dbo.ISPLAN.URYRKD, dbo.ISPLAN.ISPKOD, dbo.ISPLAN.SIRASI, dbo.ISPLAN.GNTARH, dbo.ISPLAN.ISMETN, dbo.CRCARI.CRKODU, dbo.CRCARI.CRUNV1,
						dbo.ISPLAN.GNREZV, dbo.ISPLAN.URAKOD, dbo.ISPLAN.PURKOD, dbo.ISPLAN.SPSRNO, dbo.ISPLAN.SPSTKD, STKART_2.STKNAM AS SPSTNM, 
						dbo.SPFHAR.GNACIK AS SPSTAC, dbo.ISPLAN.MXPRKD, dbo.STKART.STKNAM AS MXPRNM, 
						dbo.ISPLAN.STKODU, STKART_1.STKNAM, dbo.ISPLAN.PLMKTR, SUM(dbo.ISPLAN.GRMKTR) AS GRMKTR, dbo.ISPLAN.GROLBR
						FROM dbo.ISPLAN INNER JOIN
						dbo.SPFBAS ON dbo.ISPLAN.SIRKID = dbo.SPFBAS.SIRKID AND dbo.ISPLAN.ISMETN = dbo.SPFBAS.BELGEN AND dbo.ISPLAN.ACTIVE = 1 AND dbo.SPFBAS.ACTIVE = 1 INNER JOIN
						dbo.CRCARI ON dbo.SPFBAS.SIRKID = dbo.CRCARI.SIRKID AND dbo.SPFBAS.CRKODU = dbo.CRCARI.CRKODU AND dbo.CRCARI.ACTIVE = 1 INNER JOIN
						dbo.STKART ON dbo.ISPLAN.SIRKID = dbo.STKART.SIRKID AND dbo.ISPLAN.MXPRKD = dbo.STKART.STKODU AND dbo.STKART.ACTIVE = 1 INNER JOIN
						dbo.STKART AS STKART_1 ON dbo.ISPLAN.SIRKID = STKART_1.SIRKID AND dbo.ISPLAN.STKODU = STKART_1.STKODU AND STKART_1.ACTIVE = 1 INNER JOIN
						dbo.STKART AS STKART_2 ON dbo.ISPLAN.SIRKID = STKART_2.SIRKID AND dbo.ISPLAN.SPSTKD = STKART_2.STKODU AND STKART_2.ACTIVE = 1 INNER JOIN
						dbo.SPFHAR ON dbo.ISPLAN.SIRKID = dbo.SPFHAR.SIRKID AND dbo.ISPLAN.ISMETN = dbo.SPFHAR.BELGEN AND dbo.ISPLAN.SPSTKD = dbo.SPFHAR.STKODU AND dbo.ISPLAN.SPSRNO = dbo.SPFHAR.SATIRN AND dbo.SPFHAR.ACTIVE = 1
						WHERE dbo.ISPLAN.SIRKID = @SirketId" + filter +
						@" GROUP BY dbo.ISPLAN.SIRKID, dbo.ISPLAN.URYRKD, dbo.ISPLAN.ISPKOD, dbo.ISPLAN.SIRASI, dbo.ISPLAN.GNTARH, dbo.ISPLAN.ISMETN, 
						dbo.CRCARI.CRKODU, dbo.CRCARI.CRUNV1, dbo.ISPLAN.GNREZV, dbo.ISPLAN.URAKOD, dbo.ISPLAN.MXPRKD, dbo.ISPLAN.PURKOD, dbo.ISPLAN.SPSTKD, dbo.STKART.STKNAM, STKART_2.STKNAM,
						dbo.ISPLAN.STKODU, STKART_1.STKNAM, dbo.ISPLAN.PLMKTR, dbo.ISPLAN.GROLBR, dbo.ISPLAN.SPSRNO, dbo.SPFHAR.GNACIK
						HAVING COUNT(dbo.ISPLAN.ISPKOD) - COUNT(CASE WHEN dbo.ISPLAN.FLGKPN = 1 THEN 1 END) > 0
						ORDER BY dbo.ISPLAN.GNTARH, dbo.ISPLAN.SIRASI, dbo.ISPLAN.SPSTKD, PURKOD";

			sonuc.Items = _isplanDal.GetListSqlQuery<IsplanUrunParcaModel>(sql, new SqlParameter("SirketId", global.SirketId));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<IsplanOperasyonModel> Ncch_GetIsplanOperasyonList_NLog(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			var sonuc = new ListResponse<IsplanOperasyonModel>();

			var sql = @"SELECT dbo.ISPLAN.Id, dbo.ISPLAN.SIRKID, dbo.ISPLAN.URYRKD, dbo.ISPLAN.ISPKOD, dbo.ISPLAN.SIRASI, dbo.ISPLAN.GNTARH, dbo.ISPLAN.ISMETN, dbo.CRCARI.CRKODU , dbo.CRCARI.CRUNV1, 
						dbo.ISPLAN.GNREZV, dbo.ISPLAN.URAKOD, dbo.ISPLAN.MXPRKD, dbo.STKART.STKNAM AS MXPRNM, dbo.ISPLAN.STKODU, STKART_1.STKNAM, dbo.ISPLAN.PLMKTR, dbo.ISPLAN.GRMKTR, 
						dbo.ISPLAN.GROLBR, dbo.ISPLAN.ISYKOD, dbo.ISYRTN.TANIMI AS ISYTNM, dbo.ISPLAN.ISOPKD, dbo.GNTHRK.TANIMI AS ISOPTN, dbo.ISPLAN.ISLMNO, dbo.ISPLAN.BASTAR, dbo.ISPLAN.GNHZSR, 
						dbo.ISPLAN.GNHZOB, dbo.ISPLAN.ISLMSR, dbo.ISPLAN.ISLMSB, dbo.ISPLAN.FLGKPN
						FROM dbo.ISPLAN INNER JOIN
						dbo.SPFBAS ON dbo.ISPLAN.SIRKID = dbo.SPFBAS.SIRKID AND dbo.ISPLAN.ISMETN = dbo.SPFBAS.BELGEN AND dbo.ISPLAN.ACTIVE = 1 AND dbo.SPFBAS.ACTIVE = 1 INNER JOIN
						dbo.CRCARI ON dbo.SPFBAS.SIRKID = dbo.CRCARI.SIRKID AND dbo.SPFBAS.CRKODU = dbo.CRCARI.CRKODU AND dbo.CRCARI.ACTIVE = 1 INNER JOIN
						dbo.STKART ON dbo.ISPLAN.SIRKID = dbo.STKART.SIRKID AND dbo.ISPLAN.MXPRKD = dbo.STKART.STKODU AND dbo.STKART.ACTIVE = 1 INNER JOIN
						dbo.STKART AS STKART_1 ON dbo.ISPLAN.SIRKID = STKART_1.SIRKID AND dbo.ISPLAN.STKODU = STKART_1.STKODU AND STKART_1.ACTIVE = 1 INNER JOIN
						dbo.GNTHRK ON dbo.ISPLAN.SIRKID = dbo.GNTHRK.SIRKID AND dbo.ISPLAN.ISOPKD = dbo.GNTHRK.HARKOD AND dbo.GNTHRK.ACTIVE = 1 INNER JOIN
						dbo.GNTIPI ON dbo.GNTHRK.SIRKID = dbo.GNTIPI.SIRKID AND dbo.GNTHRK.TIPKOD = dbo.GNTIPI.TIPKOD AND dbo.GNTIPI.TEKNAD = 'ISOPKD' AND dbo.GNTIPI.ACTIVE = 1 LEFT OUTER JOIN
						dbo.ISYRTN ON dbo.ISPLAN.SIRKID = dbo.ISYRTN.SIRKID AND dbo.ISPLAN.ISYKOD = dbo.ISYRTN.ISYKOD AND dbo.ISPLAN.URYRKD = dbo.ISYRTN.URYRKD AND dbo.ISYRTN.ACTIVE = 1
						WHERE dbo.ISPLAN.SIRKID = @SirketId
						ORDER BY dbo.ISPLAN.GNTARH, dbo.ISPLAN.SIRASI, dbo.ISPLAN.STKODU, dbo.ISPLAN.ISLMNO";
			sonuc.Items = _isplanDal.GetListSqlQuery<IsplanOperasyonModel>(sql, new SqlParameter("SirketId", global.SirketId));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<IsplanOperasyonModel> Ncch_GetIsplanOperasyonDurumList_NLog(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			var sonuc = new ListResponse<IsplanOperasyonModel>();

			var sql = @"SELECT dbo.ISPLAN.SIRKID, dbo.ISPLAN.URYRKD, dbo.ISPLAN.ISPKOD, dbo.ISPLAN.SIRASI, dbo.ISPLAN.GNREZV, dbo.ISPLAN.URAKOD, 
						dbo.ISPLAN.MXPRKD, dbo.ISPLAN.STKODU, dbo.ISPLAN.GRMKTR, dbo.ISPLAN.GROLBR, dbo.ISPLAN.ISOPKD, dbo.ISPLAN.ISLMNO, dbo.ISPLAN.FLGKPN
						FROM dbo.ISPLAN INNER JOIN
						(SELECT  dbo.ISPLAN.ISPKOD, SUM(dbo.ISPLAN.GRMKTR) AS GRMKTR FROM dbo.ISPLAN WHERE dbo.ISPLAN.SIRKID = 1
						GROUP BY dbo.ISPLAN.SIRKID, dbo.ISPLAN.URYRKD, dbo.ISPLAN.ISPKOD, dbo.ISPLAN.SIRASI, dbo.ISPLAN.GNTARH, dbo.ISPLAN.ISMETN, 
						dbo.ISPLAN.GNREZV, dbo.ISPLAN.URAKOD, dbo.ISPLAN.MXPRKD, dbo.ISPLAN.STKODU, dbo.ISPLAN.PLMKTR, dbo.ISPLAN.GROLBR
						HAVING COUNT(dbo.ISPLAN.ISPKOD) - COUNT(CASE WHEN dbo.ISPLAN.FLGKPN = 1 THEN 1 END) > 0) AS ACPL ON ACPL.ISPKOD = dbo.ISPLAN.ISPKOD INNER JOIN
						dbo.GNTHRK ON dbo.ISPLAN.SIRKID = dbo.GNTHRK.SIRKID AND dbo.ISPLAN.ISOPKD = dbo.GNTHRK.HARKOD AND dbo.GNTHRK.ACTIVE = 1 INNER JOIN
						dbo.GNTIPI ON dbo.GNTHRK.SIRKID = dbo.GNTIPI.SIRKID AND dbo.GNTHRK.TIPKOD = dbo.GNTIPI.TIPKOD AND dbo.GNTIPI.TEKNAD = 'ISOPKD' AND dbo.GNTIPI.ACTIVE = 1 INNER JOIN
						dbo.STKART ON dbo.ISPLAN.SIRKID = dbo.STKART.SIRKID AND dbo.ISPLAN.STKODU = dbo.STKART.STKODU LEFT OUTER JOIN
						dbo.ISYRTN ON dbo.ISPLAN.SIRKID = dbo.ISYRTN.SIRKID AND dbo.ISPLAN.ISYKOD = dbo.ISYRTN.ISYKOD AND dbo.ISPLAN.URYRKD = dbo.ISYRTN.URYRKD AND dbo.ISYRTN.ACTIVE = 1 AND dbo.STKART.ACTIVE = 1
						WHERE dbo.ISPLAN.SIRKID = @SirketId
						ORDER BY dbo.ISPLAN.GNTARH, dbo.ISPLAN.SIRASI, dbo.ISPLAN.STKODU, dbo.ISPLAN.ISLMNO";
			sonuc.Items = _isplanDal.GetListSqlQuery<IsplanOperasyonModel>(sql, new SqlParameter("SirketId", global.SirketId));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<IsplanParcaOperasyonModel> Ncch_GetIsplanParcaOperasyonList_NLog(Global global, string uryrkd, string ispkod, string gnrezv, string urakod, string stkodu, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			var sonuc = new ListResponse<IsplanParcaOperasyonModel>();

			var sql = @"SELECT dbo.ISPLAN.Id, dbo.ISPLAN.SIRKID, dbo.ISPLAN.URYRKD, dbo.ISPLAN.ISPKOD, dbo.ISPLAN.SIRASI, dbo.ISPLAN.GNREZV, dbo.ISPLAN.URAKOD, 
						dbo.ISPLAN.STKODU, dbo.STKART.STKNAM, dbo.ISPLAN.GRMKTR, dbo.ISPLAN.GROLBR, dbo.ISPLAN.ISYKOD, dbo.ISYRTN.TANIMI AS ISYTNM, dbo.ISPLAN.ISOPKD, 
						dbo.GNTHRK.TANIMI AS ISOPTN, dbo.ISPLAN.ISLMNO, dbo.ISPLAN.BASTAR, dbo.ISPLAN.GNHZSR, dbo.ISPLAN.GNHZOB, dbo.ISPLAN.ISLMSR, dbo.ISPLAN.ISLMSB, dbo.ISPLAN.FLGKPN
						FROM dbo.ISPLAN INNER JOIN
						dbo.GNTHRK ON dbo.ISPLAN.SIRKID = dbo.GNTHRK.SIRKID AND dbo.ISPLAN.ISOPKD = dbo.GNTHRK.HARKOD AND dbo.GNTHRK.ACTIVE = 1 INNER JOIN
						dbo.GNTIPI ON dbo.GNTHRK.SIRKID = dbo.GNTIPI.SIRKID AND dbo.GNTHRK.TIPKOD = dbo.GNTIPI.TIPKOD AND dbo.GNTIPI.TEKNAD = 'ISOPKD' AND dbo.GNTIPI.ACTIVE = 1 INNER JOIN
						dbo.STKART ON dbo.ISPLAN.SIRKID = dbo.STKART.SIRKID AND dbo.ISPLAN.STKODU = dbo.STKART.STKODU LEFT OUTER JOIN
						dbo.ISYRTN ON dbo.ISPLAN.SIRKID = dbo.ISYRTN.SIRKID AND dbo.ISPLAN.ISYKOD = dbo.ISYRTN.ISYKOD AND dbo.ISPLAN.URYRKD = dbo.ISYRTN.URYRKD AND dbo.ISYRTN.ACTIVE = 1 AND dbo.STKART.ACTIVE = 1
						WHERE dbo.ISPLAN.SIRKID = @SirketId AND dbo.ISPLAN.URYRKD = @Uryrkd AND dbo.ISPLAN.ISPKOD = @Ispkod AND dbo.ISPLAN.GNREZV = @Gnrezv AND dbo.ISPLAN.URAKOD = @Urakod AND dbo.ISPLAN.STKODU = @Stkodu
						ORDER BY dbo.ISPLAN.GNTARH, dbo.ISPLAN.SIRASI, dbo.ISPLAN.STKODU, dbo.ISPLAN.ISLMNO";
			sonuc.Items = _isplanDal.GetListSqlQuery<IsplanParcaOperasyonModel>(sql, new SqlParameter("SirketId", global.SirketId), new SqlParameter("Uryrkd", uryrkd),
				new SqlParameter("Ispkod", ispkod), new SqlParameter("Gnrezv", gnrezv), new SqlParameter("Urakod", urakod), new SqlParameter("Stkodu", stkodu));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<IsyeriOperasyonModel> Ncch_GetIsyeriOperasyonList_NLog(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<IsyeriOperasyonModel>();

			var sql = @"SELECT dbo.ISYRTN.Id, dbo.ISYRTN.SIRKID, dbo.ISYRTN.URYRKD, dbo.ISYRTN.ISBLKD, dbo.ISYRTN.ISYKOD, dbo.ISYRTN.TANIMI AS ISYTNM, dbo.ISYROP.ISOPKD, dbo.GNTHRK.TANIMI AS ISOPTN
						FROM dbo.ISYROP INNER JOIN
						dbo.GNTHRK ON dbo.ISYROP.ISOPKD = dbo.GNTHRK.HARKOD AND dbo.ISYROP.SIRKID = dbo.GNTHRK.SIRKID INNER JOIN
						dbo.GNTIPI ON dbo.GNTHRK.SIRKID = dbo.GNTIPI.SIRKID AND dbo.GNTHRK.TIPKOD = dbo.GNTIPI.TIPKOD AND dbo.GNTIPI.TEKNAD = 'ISOPKD' LEFT OUTER JOIN
						dbo.ISYRTN ON dbo.ISYROP.SIRKID = dbo.ISYRTN.SIRKID AND dbo.ISYROP.ISYRID = dbo.ISYRTN.Id
						AND dbo.ISYRTN.ACTIVE = 1 AND dbo.ISYROP.ACTIVE = 1 AND dbo.GNTHRK.ACTIVE = 1 AND dbo.GNTIPI.ACTIVE = 1
						WHERE dbo.ISYRTN.SIRKID = @SirketId";

			sonuc.Items = _isplanDal.GetListSqlQuery<IsyeriOperasyonModel>(sql, new SqlParameter("SirketId", global.SirketId));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<IsplanBaslikModel> Ncch_GetIsplanBaslikList_NLog(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<IsplanBaslikModel>();

			var sql = @"SELECT DISTINCT ISPKOD, ISMETN AS SIPKOD, GNTARH, SPFBAS.CRKODU, CRCARI.CRUNV1 AS CRNAME FROM ISPLAN
						INNER JOIN SPFBAS ON ISPLAN.SIRKID = SPFBAS.SIRKID AND ISPLAN.ISMETN = SPFBAS.BELGEN
						INNER JOIN CRCARI ON ISPLAN.SIRKID = CRCARI.SIRKID AND SPFBAS.CRKODU = CRCARI.CRKODU
						WHERE ISPLAN.SIRKID = @SirketId";

			sonuc.Items = _isplanDal.GetListSqlQuery<IsplanBaslikModel>(sql, new SqlParameter("SirketId", global.SirketId));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		[FluentValidationAspect(typeof(IsplanValidator))]
		[CacheRemoveAspect(typeof(MemoryCacheManager))]
		public StandardResponse<ISPLAN> Ncch_UpdatePlan_Log(ISPLAN isplan, Global global)
		{
			var sonuc = new StandardResponse<ISPLAN>();
			isplan.SIRKID = global.SirketId.Value;
			isplan.DEKULL = global.UserKod;
			isplan.DTARIH = DateTime.Now;
			isplan.KYNKKD = global.KaynakKod;
			sonuc.Nesne = _isplanDal.Update(isplan);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		#endregion ClientFunc
    }
}
