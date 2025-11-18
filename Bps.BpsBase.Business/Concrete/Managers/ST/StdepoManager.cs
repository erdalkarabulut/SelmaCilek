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

using Bps.BpsBase.Entities.Models.ST.Listed;
using System.Data.SqlClient;
using System.Collections.Generic;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.ST
{
    public class StdepoManager : IStdepoService
    {
        private IStdepoDal _stdepoDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
		#region ClientDals

		#endregion ClientDals
		#region ClientServices

		#endregion ClientServices

        public StdepoManager(IStdepoDal stdepoDal,IGnService gnservice,ILockedService lockedservice)
        {
            _stdepoDal = stdepoDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STDEPO> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDEPO>();
            sonuc.Items = global.SirketId != null ? _stdepoDal.GetList(x => x.SIRKID == global.SirketId) : _stdepoDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STDEPO> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDEPO>();
            sonuc.Items = global.SirketId != null ? _stdepoDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _stdepoDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STDEPO> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDEPO>();
            sonuc.Items = global.SirketId != null ? _stdepoDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _stdepoDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STDEPO> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDEPO>();
            sonuc.Items = global.SirketId != null ? _stdepoDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _stdepoDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STDEPO> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STDEPO>();
            sonuc.Items = global.SirketId != null ? _stdepoDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _stdepoDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STDEPO> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STDEPO>();
            sonuc.Nesne = _stdepoDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STDEPO> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STDEPO", id, global);
            var sonuc = new StandardResponse<STDEPO>();
            sonuc.Nesne = _stdepoDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StdepoValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STDEPO> Ncch_Add_NLog(STDEPO stdepo, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STDEPO>();
            stdepo.SIRKID = global.SirketId.Value; 
            stdepo.EKKULL = global.UserKod;
            stdepo.ETARIH = DateTime.Now;
            stdepo.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stdepoDal.Add(stdepo);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StdepoValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STDEPO> Ncch_Update_Log(STDEPO stdepo,STDEPO oldStdepo, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STDEPO", stdepo.Id, global);
            var sonuc = new StandardResponse<STDEPO>();
            stdepo.SIRKID = global.SirketId.Value; 
            stdepo.DEKULL = global.UserKod;
            stdepo.DTARIH = DateTime.Now;
            stdepo.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stdepoDal.Update(stdepo);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StdepoValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STDEPO> Ncch_UpdateAktifPasif_Log(STDEPO stdepo, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STDEPO>();
            stdepo.SIRKID = global.SirketId.Value; 
            stdepo.ACTIVE = !stdepo.ACTIVE;
            stdepo.DEKULL = global.UserKod;
            stdepo.DTARIH = DateTime.Now;
            stdepo.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stdepoDal.Update(stdepo);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(StdepoValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STDEPO> Ncch_Delete_Log(STDEPO stdepo, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STDEPO", stdepo.Id, global);
            var sonuc = new StandardResponse<STDEPO>();
            stdepo.SIRKID = global.SirketId.Value; 
            stdepo.ACTIVE = false;
            stdepo.SLINDI = true;
            stdepo.DEKULL = global.UserKod;
            stdepo.DTARIH = DateTime.Now;
            stdepo.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _stdepoDal.Update(stdepo);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

		#region ClientFunc

		public ListResponse<STDEPO> Cch_GetByStokKodu_NLog(Global global, string stokKodu, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}
			var sonuc = new ListResponse<STDEPO>();
			sonuc.Items = _stdepoDal.GetList(x =>
				x.STKODU == stokKodu && x.SIRKID == global.SirketId && x.ACTIVE && x.SLINDI == false);
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}


		public ListResponse<StdepoStokMiktarModel>
			GetYenidenSiparisSvy(Global global, string stokKodu = null, string depoKodu = null, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			var whereStr = "";
			if (!string.IsNullOrEmpty(stokKodu))
			{
				whereStr += " AND stu.STKODU='" + stokKodu + "' ";
			}

			if (!string.IsNullOrEmpty(depoKodu))
			{
				whereStr += " AND stu.URDEPO='" + depoKodu + "' ";
			}

			var sonuc = new ListResponse<StdepoStokMiktarModel> { Items = new List<StdepoStokMiktarModel>() };

			var sql = @"SELECT 
                        coalesce(stu.YNSPSV,0) as YNSPSV, coalesce(stu.EMNSTK,0) as EMNSTK, coalesce(stu.SAPRTB,0) as SAPRTB, coalesce(stu.MPPRTB,0) as MPPRTB,
                        t.*
                        from STURYR as stu
                        inner join  (SELECT dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, 
                        dbo.STKART.STALKD, dbo.UASTBG.STKODU, dbo.STKART.STKNAM, 
                        MIN(dbo.STDEPO.USESTK) AS USESTK, STKART_AGAC.OLCUKD, 
                        dbo.GNDPTN.DPKODU, dbo.GNDPTN.DPTANM, dbo.UASTBG.URAKOD, dbo.STDEPO.URYRKD
						FROM dbo.STKART AS STKART_AGAC INNER JOIN
                        dbo.STDEPO ON STKART_AGAC.STKODU = dbo.STDEPO.STKODU AND STKART_AGAC.SIRKID = dbo.STDEPO.SIRKID INNER JOIN
                        dbo.GNDPTN ON dbo.STDEPO.DPKODU = dbo.GNDPTN.DPKODU AND dbo.STDEPO.SIRKID = dbo.GNDPTN.SIRKID INNER JOIN
                        dbo.STMALT INNER JOIN
                        dbo.UASTBG INNER JOIN
                        dbo.URAGAC ON dbo.UASTBG.URAKOD = dbo.URAGAC.URAKOD AND dbo.UASTBG.SIRKID = dbo.URAGAC.SIRKID INNER JOIN
                        dbo.STKART ON dbo.UASTBG.STKODU = dbo.STKART.STKODU AND dbo.UASTBG.SIRKID = dbo.STKART.SIRKID ON dbo.STMALT.STMLTR = dbo.STKART.STMLTR AND dbo.STMALT.SIRKID = dbo.STKART.SIRKID INNER JOIN
                        dbo.URAGAC AS URAGAC_1 INNER JOIN
                        dbo.UASTBG AS UASTBG_1 ON URAGAC_1.SIRKID = UASTBG_1.SIRKID AND URAGAC_1.URAKOD = UASTBG_1.URAKOD ON dbo.URAGAC.SIRKID = UASTBG_1.SIRKID AND dbo.URAGAC.STKODU = UASTBG_1.STKODU ON 
                        dbo.STDEPO.SIRKID = URAGAC_1.SIRKID AND dbo.STDEPO.STKODU = URAGAC_1.STKODU
						WHERE (dbo.STKART.STMLTR = '000') AND (dbo.UASTBG.ACTIVE = 1) AND (dbo.UASTBG.SLINDI = 0) AND (dbo.UASTBG.SIRKID = @SirketId)
						GROUP BY dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, 
						dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.UASTBG.STKODU, dbo.STKART.STKNAM,dbo.STDEPO.URYRKD,
						STKART_AGAC.OLCUKD, dbo.GNDPTN.DPKODU, dbo.GNDPTN.DPTANM, dbo.UASTBG.URAKOD
						UNION ALL
						SELECT dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, 
						dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.UASTBG.STKODU, dbo.STKART.STKNAM, 
						MIN(dbo.STDEPO.USESTK) AS USESTK, STKART_AGAC.OLCUKD, dbo.GNDPTN.DPKODU,dbo.GNDPTN.DPTANM, dbo.UASTBG.URAKOD, dbo.STDEPO.URYRKD
                        FROM dbo.UASTBG INNER JOIN
                        dbo.URAGAC ON dbo.UASTBG.URAKOD = dbo.URAGAC.URAKOD AND dbo.UASTBG.SIRKID = dbo.URAGAC.SIRKID INNER JOIN
                        dbo.STKART ON dbo.UASTBG.STKODU = dbo.STKART.STKODU AND dbo.UASTBG.SIRKID = dbo.STKART.SIRKID INNER JOIN
                        dbo.STDEPO ON dbo.URAGAC.STKODU = dbo.STDEPO.STKODU AND dbo.URAGAC.SIRKID = dbo.STDEPO.SIRKID INNER JOIN
                        dbo.STKART AS STKART_AGAC ON dbo.STDEPO.STKODU = STKART_AGAC.STKODU AND dbo.STDEPO.SIRKID = STKART_AGAC.SIRKID INNER JOIN
                        dbo.GNDPTN ON dbo.STDEPO.DPKODU = dbo.GNDPTN.DPKODU AND dbo.STDEPO.SIRKID = dbo.GNDPTN.SIRKID INNER JOIN
                        dbo.STMALT ON dbo.STKART.STMLTR = dbo.STMALT.STMLTR AND dbo.STKART.SIRKID = dbo.STMALT.SIRKID
                        WHERE (dbo.STKART.STMLTR = '" + Param.MAMUL_KODU + "') AND (dbo.UASTBG.ACTIVE = 1) AND (dbo.UASTBG.SLINDI = 0) AND (dbo.UASTBG.SIRKID = @SirketId) AND (dbo.STKART.ACTIVE = 1) " +
						@"GROUP BY dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, 
						dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.UASTBG.STKODU, dbo.STKART.STKNAM, dbo.STDEPO.URYRKD,
						STKART_AGAC.OLCUKD, dbo.GNDPTN.DPKODU, dbo.GNDPTN.DPTANM, dbo.UASTBG.URAKOD
                        UNION ALL
                        SELECT dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.STDEPO.STKODU, 
						dbo.STKART.STKNAM, dbo.STDEPO.USESTK, dbo.STKART.OLCUKD, dbo.GNDPTN.DPKODU, dbo.GNDPTN.DPTANM, '' AS URAKOD, dbo.STDEPO.URYRKD
                        FROM dbo.STDEPO 
						INNER JOIN
                        dbo.GNDPTN ON dbo.STDEPO.DPKODU = dbo.GNDPTN.DPKODU AND dbo.STDEPO.SIRKID = dbo.GNDPTN.SIRKID INNER JOIN
                        dbo.STKART ON dbo.STDEPO.STKODU = dbo.STKART.STKODU AND dbo.STDEPO.SIRKID = dbo.STKART.SIRKID INNER JOIN
                        dbo.STMALT ON dbo.STKART.STMLTR = dbo.STMALT.STMLTR AND dbo.STKART.SIRKID = dbo.STMALT.SIRKID
                        WHERE (dbo.STKART.STMLTR <> '" + Param.MAMUL_KODU + "') AND (dbo.STDEPO.ACTIVE = 1) AND (dbo.STDEPO.SLINDI = 0) AND (dbo.STDEPO.SIRKID = @SirketId) AND (dbo.STKART.ACTIVE = 1))  AS T " +
						@"on t.STKODU=stu.STKODU and t.URYRKD=stu.URYRKD and t.DPKODU=stu.URDEPO
						where stu.YNSPSV >=  t.USESTK " + whereStr + " ORDER BY stu.STKODU";

			sonuc.Items = _stdepoDal.GetListSqlQuery<StdepoStokMiktarModel>(sql, new SqlParameter("SirketId", global.SirketId));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<StdepoStokMiktarModel>
			GetStokMiktarRapor(Global global, string stokKodu = null, string depoKodu = null, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			var whereStr = "";
			if (!string.IsNullOrEmpty(stokKodu))
			{
				whereStr += " AND T.STKODU='" + stokKodu + "' ";
			}

			if (!string.IsNullOrEmpty(depoKodu))
			{
				whereStr += " AND DPKODU='" + depoKodu + "' ";
			}

			var sonuc = new ListResponse<StdepoStokMiktarModel> { Items = new List<StdepoStokMiktarModel>() };

			string sql = "";
            
			if (Param.PAKET)
			{
				//Paketli Sistem
				sql = @"SELECT * FROM (SELECT dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.UASTBG.STKODU, dbo.STKART.STKNAM, 
            MIN(dbo.STDEPO.USESTK) AS USESTK, STKART_AGAC.OLCUKD, dbo.GNDPTN.DPKODU, dbo.GNDPTN.DPTANM, MAX(dbo.UASTBG.GNREZV) AS GNREZV
            FROM dbo.STKART AS STKART_AGAC INNER JOIN
                              dbo.STDEPO ON STKART_AGAC.STKODU = dbo.STDEPO.STKODU AND STKART_AGAC.SIRKID = dbo.STDEPO.SIRKID INNER JOIN
                              dbo.GNDPTN ON dbo.STDEPO.DPKODU = dbo.GNDPTN.DPKODU AND dbo.STDEPO.SIRKID = dbo.GNDPTN.SIRKID INNER JOIN
                              dbo.STMALT INNER JOIN
                              dbo.UASTBG INNER JOIN
                              dbo.URAGAC ON dbo.UASTBG.URAKOD = dbo.URAGAC.URAKOD AND dbo.UASTBG.SIRKID = dbo.URAGAC.SIRKID INNER JOIN
                              dbo.STKART ON dbo.UASTBG.STKODU = dbo.STKART.STKODU AND dbo.UASTBG.SIRKID = dbo.STKART.SIRKID ON dbo.STMALT.STMLTR = dbo.STKART.STMLTR AND dbo.STMALT.SIRKID = dbo.STKART.SIRKID INNER JOIN
                              dbo.URAGAC AS URAGAC_1 INNER JOIN
                              dbo.UASTBG AS UASTBG_1 ON URAGAC_1.SIRKID = UASTBG_1.SIRKID AND URAGAC_1.URAKOD = UASTBG_1.URAKOD ON dbo.URAGAC.SIRKID = UASTBG_1.SIRKID AND dbo.URAGAC.STKODU = UASTBG_1.STKODU ON 
                              dbo.STDEPO.SIRKID = URAGAC_1.SIRKID AND dbo.STDEPO.STKODU = URAGAC_1.STKODU
            INNER JOIN dbo.ISREVZ ON UASTBG_1.SIRKID = dbo.ISREVZ.SIRKID AND UASTBG_1.GNREZV = dbo.ISREVZ.GNREZV
            WHERE (dbo.STKART.STMLTR = '000') AND (dbo.UASTBG.ACTIVE = 1) AND (dbo.UASTBG.SLINDI = 0) AND (dbo.UASTBG.SIRKID = @SirketId)
            AND dbo.ISREVZ.URTONY = 1 AND dbo.ISREVZ.ACTIVE = 1 AND dbo.ISREVZ.SLINDI = 0
            GROUP BY dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.UASTBG.STKODU, 
            dbo.STKART.STKNAM, STKART_AGAC.OLCUKD, dbo.GNDPTN.DPKODU, dbo.GNDPTN.DPTANM
            UNION ALL
            SELECT dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.UASTBG.STKODU, dbo.STKART.STKNAM, 
            MIN(dbo.STDEPO.USESTK) AS USESTK, STKART_AGAC.OLCUKD, dbo.GNDPTN.DPKODU, dbo.GNDPTN.DPTANM, MAX(dbo.UASTBG.GNREZV) AS GNREZV
                              FROM dbo.UASTBG INNER JOIN
                              dbo.URAGAC ON dbo.UASTBG.URAKOD = dbo.URAGAC.URAKOD AND dbo.UASTBG.SIRKID = dbo.URAGAC.SIRKID INNER JOIN
                              dbo.STKART ON dbo.UASTBG.STKODU = dbo.STKART.STKODU AND dbo.UASTBG.SIRKID = dbo.STKART.SIRKID INNER JOIN
                              dbo.STDEPO ON dbo.URAGAC.STKODU = dbo.STDEPO.STKODU AND dbo.URAGAC.SIRKID = dbo.STDEPO.SIRKID INNER JOIN
                              dbo.STKART AS STKART_AGAC ON dbo.STDEPO.STKODU = STKART_AGAC.STKODU AND dbo.STDEPO.SIRKID = STKART_AGAC.SIRKID INNER JOIN
                              dbo.GNDPTN ON dbo.STDEPO.DPKODU = dbo.GNDPTN.DPKODU AND dbo.STDEPO.SIRKID = dbo.GNDPTN.SIRKID INNER JOIN
                              dbo.STMALT ON dbo.STKART.STMLTR = dbo.STMALT.STMLTR AND dbo.STKART.SIRKID = dbo.STMALT.SIRKID
            INNER JOIN dbo.ISREVZ AS ISREVZ_1 ON dbo.UASTBG.SIRKID = ISREVZ_1.SIRKID AND dbo.UASTBG.GNREZV = ISREVZ_1.GNREZV
                              WHERE (dbo.STKART.STMLTR = '" + Param.MAMUL_KODU + "') AND (dbo.UASTBG.ACTIVE = 1) AND (dbo.UASTBG.SLINDI = 0) AND (dbo.UASTBG.SIRKID = @SirketId) AND (dbo.STKART.ACTIVE = 1) " +
							@"AND ISREVZ_1.URTONY = 1 AND ISREVZ_1.ACTIVE = 1 AND ISREVZ_1.SLINDI = 0
                              GROUP BY dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.UASTBG.STKODU, dbo.STKART.STKNAM, 
            STKART_AGAC.OLCUKD, dbo.GNDPTN.DPKODU, dbo.GNDPTN.DPTANM
                              UNION ALL
                              SELECT dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.STDEPO.STKODU, 
            dbo.STKART.STKNAM, dbo.STDEPO.USESTK, dbo.STKART.OLCUKD, dbo.GNDPTN.DPKODU, dbo.GNDPTN.DPTANM, '' AS GNREZV
                              FROM dbo.STDEPO INNER JOIN
                              dbo.GNDPTN ON dbo.STDEPO.DPKODU = dbo.GNDPTN.DPKODU AND dbo.STDEPO.SIRKID = dbo.GNDPTN.SIRKID INNER JOIN
                              dbo.STKART ON dbo.STDEPO.STKODU = dbo.STKART.STKODU AND dbo.STDEPO.SIRKID = dbo.STKART.SIRKID INNER JOIN
                              dbo.STMALT ON dbo.STKART.STMLTR = dbo.STMALT.STMLTR AND dbo.STKART.SIRKID = dbo.STMALT.SIRKID
                              WHERE (dbo.STKART.STMLTR <> '" + Param.MAMUL_KODU + "') AND (dbo.STDEPO.ACTIVE = 1) AND (dbo.STDEPO.SLINDI = 0) AND (dbo.STDEPO.SIRKID = @SirketId))  AS T where 1=1 " + whereStr + " ORDER BY T.STKODU";

			}
			else
			{
				//Paketsiz Sistem
				sql = @"SELECT * FROM (SELECT dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.STKART.STKODU, dbo.STKART.STKNAM, dbo.STDEPO.USESTK, STKART_AGAC.OLCUKD, dbo.GNDPTN.DPKODU, dbo.GNDPTN.DPTANM
                                FROM dbo.STKART INNER JOIN
                                dbo.STDEPO ON dbo.STKART.STKODU = dbo.STDEPO.STKODU AND dbo.STKART.SIRKID = dbo.STDEPO.SIRKID INNER JOIN
                                dbo.STKART AS STKART_AGAC ON dbo.STDEPO.STKODU = STKART_AGAC.STKODU AND dbo.STDEPO.SIRKID = STKART_AGAC.SIRKID INNER JOIN
                                dbo.GNDPTN ON dbo.STDEPO.DPKODU = dbo.GNDPTN.DPKODU AND dbo.STDEPO.SIRKID = dbo.GNDPTN.SIRKID INNER JOIN
                                dbo.STMALT ON dbo.STKART.STMLTR = dbo.STMALT.STMLTR AND dbo.STKART.SIRKID = dbo.STMALT.SIRKID
                                WHERE(dbo.STKART.STMLTR = '" + Param.MAMUL_KODU + "') AND(dbo.STKART.ACTIVE = 1) AND(dbo.STKART.SLINDI = 0) AND(dbo.STKART.SIRKID = @SirketId) " +
									@"UNION ALL
                                SELECT dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.STDEPO.STKODU, dbo.STKART.STKNAM, dbo.STDEPO.USESTK, dbo.STKART.OLCUKD, dbo.GNDPTN.DPKODU, dbo.GNDPTN.DPTANM
                                    FROM dbo.STDEPO INNER JOIN
                                dbo.GNDPTN ON dbo.STDEPO.DPKODU = dbo.GNDPTN.DPKODU AND dbo.STDEPO.SIRKID = dbo.GNDPTN.SIRKID INNER JOIN
                                dbo.STKART ON dbo.STDEPO.STKODU = dbo.STKART.STKODU AND dbo.STDEPO.SIRKID = dbo.STKART.SIRKID INNER JOIN
                                dbo.STMALT ON dbo.STKART.STMLTR = dbo.STMALT.STMLTR AND dbo.STKART.SIRKID = dbo.STMALT.SIRKID
                                WHERE (dbo.STKART.STMLTR <> '" + Param.MAMUL_KODU + "') AND (dbo.STKART.ACTIVE = 1) AND (dbo.STDEPO.ACTIVE = 1) AND (dbo.STDEPO.SLINDI = 0) AND (dbo.STDEPO.SIRKID = @SirketId)) AS T where 1 = 1 " + whereStr + " ORDER BY T.STKODU; ";

			}
            if (global.RenkBeden == null) global.RenkBeden = false;
            if ((bool)global.RenkBeden)
            {
                //                sql = @"SELECT        dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.STKART.STKODU, dbo.STKART.STKNAM,CASE WHEN dbo.STDEPV.USESTK IS NULL THEN 0 ELSE dbo.STDEPV.USESTK END AS USESTK, dbo.STKART.OLCUKD, 
                //                         dbo.GNDPTN.DPKODU, dbo.GNDPTN.DPTANM, dbo.STBDRN.VRKODU
                //FROM            dbo.GNDPTN LEFT OUTER JOIN
                //                         dbo.STMALT INNER JOIN
                //                         dbo.STKART ON dbo.STMALT.STMLTR = dbo.STKART.STMLTR AND dbo.STMALT.SIRKID = dbo.STKART.SIRKID ON dbo.GNDPTN.SIRKID = dbo.STKART.SIRKID LEFT OUTER JOIN
                //                         dbo.STBDRN LEFT OUTER JOIN
                //                         dbo.STDEPV ON dbo.STBDRN.SIRKID = dbo.STDEPV.SIRKID AND dbo.STBDRN.STKODU = dbo.STDEPV.STKODU AND dbo.STBDRN.VRKODU = dbo.STDEPV.VRKODU ON dbo.STKART.SIRKID = dbo.STBDRN.SIRKID AND 
                //                         dbo.STKART.STKODU = dbo.STBDRN.STKODU
                //WHERE         (dbo.STKART.ACTIVE = 1) AND (dbo.STKART.SLINDI = 0) AND (dbo.STKART.SIRKID = 1 AND (dbo.GNDPTN.ACTIVE =1))" + whereStr + " ORDER BY dbo.STKART.STKODU; ";
                sql = @"SELECT        dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.STKART.STKODU, dbo.STKART.STKNAM, dbo.STDEPV.USESTK, dbo.STKART.OLCUKD, 
                         dbo.GNDPTN.DPTANM, dbo.STBDRN.VRKODU, dbo.GNDPTN.SIRKID,dbo.STDEPV.DPKODU

FROM            dbo.GNDPTN INNER JOIN
                         dbo.STDEPV INNER JOIN
                         dbo.STBDRN INNER JOIN
                         dbo.STMALT INNER JOIN
                         dbo.STKART ON dbo.STMALT.STMLTR = dbo.STKART.STMLTR AND dbo.STMALT.SIRKID = dbo.STKART.SIRKID ON dbo.STBDRN.SIRKID = dbo.STKART.SIRKID AND dbo.STBDRN.STKODU = dbo.STKART.STKODU ON 
                         dbo.STDEPV.SIRKID = dbo.STBDRN.SIRKID AND dbo.STDEPV.STKODU = dbo.STBDRN.STKODU AND dbo.STDEPV.VRKODU = dbo.STBDRN.VRKODU ON dbo.GNDPTN.SIRKID = dbo.STDEPV.SIRKID AND 
                         dbo.GNDPTN.DPKODU = dbo.STDEPV.DPKODU
WHERE        (dbo.STKART.ACTIVE = 1) AND (dbo.STKART.SLINDI = 0) AND (dbo.STKART.SIRKID = 1) AND (dbo.GNDPTN.ACTIVE =1)" + whereStr + " ORDER BY dbo.STKART.STKODU; ";
            }


            sonuc.Items = _stdepoDal.GetListSqlQuery<StdepoStokMiktarModel>(sql, new SqlParameter("SirketId", global.SirketId));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<StdepoStokMiktarModel>
			GetStokMiktarRaporWithMipgos(Global global, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			var sonuc = new ListResponse<StdepoStokMiktarModel> { Items = new List<StdepoStokMiktarModel>() };

			//      var sql = @"SELECT dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.STDEPO.STKODU, 
			//dbo.STKART.STKNAM, dbo.STDEPO.USESTK, dbo.STKART.OLCUKD, dbo.GNDPTN.DPKODU, dbo.GNDPTN.DPTANM, dbo.GNDPTN.MIPGOS
			//                  FROM dbo.STDEPO INNER JOIN
			//                  dbo.GNDPTN ON dbo.STDEPO.DPKODU = dbo.GNDPTN.DPKODU AND dbo.STDEPO.SIRKID = dbo.GNDPTN.SIRKID INNER JOIN
			//                  dbo.STKART ON dbo.STDEPO.STKODU = dbo.STKART.STKODU AND dbo.STDEPO.SIRKID = dbo.STKART.SIRKID INNER JOIN
			//                  dbo.STMALT ON dbo.STKART.STMLTR = dbo.STMALT.STMLTR AND dbo.STKART.SIRKID = dbo.STMALT.SIRKID
			//                  WHERE dbo.STDEPO.ACTIVE = 1 AND dbo.STDEPO.SLINDI = 0 AND dbo.STDEPO.SIRKID = @SirketId AND dbo.GNDPTN.MIPGOS = 1";

			var sql = @"SELECT dbo.STDEPO.STKODU, dbo.STKART.STKNAM, SUM(dbo.STDEPO.USESTK) - SUM(dbo.STDEPO.BLKSTK) AS USESTK, dbo.STKART.OLCUKD
                        FROM dbo.STDEPO INNER JOIN
                        dbo.GNDPTN ON dbo.STDEPO.DPKODU = dbo.GNDPTN.DPKODU AND dbo.STDEPO.SIRKID = dbo.GNDPTN.SIRKID INNER JOIN
                        dbo.STKART ON dbo.STDEPO.STKODU = dbo.STKART.STKODU AND dbo.STDEPO.SIRKID = dbo.STKART.SIRKID INNER JOIN
                        dbo.STMALT ON dbo.STKART.STMLTR = dbo.STMALT.STMLTR AND dbo.STKART.SIRKID = dbo.STMALT.SIRKID
                        WHERE dbo.STDEPO.ACTIVE = 1 AND dbo.STDEPO.SLINDI = 0 AND dbo.STDEPO.SIRKID = @SirketId AND dbo.GNDPTN.MIPGOS = 1
						GROUP BY dbo.STKART.STMLTR, dbo.STDEPO.STKODU, dbo.STKART.STKNAM, dbo.STKART.OLCUKD
						ORDER BY dbo.STDEPO.STKODU";

			sonuc.Items = _stdepoDal.GetListSqlQuery<StdepoStokMiktarModel>(sql, new SqlParameter("SirketId", global.SirketId));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<StdepoStokMiktarModel>
			GetStokListWithAnaAltGrup(Global global, string stokKodu = null, string depoKodu = null, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			var whereStr = "";
			if (!string.IsNullOrEmpty(stokKodu))
			{
				whereStr += " AND T.STKODU='" + stokKodu + "' ";
			}

			if (!string.IsNullOrEmpty(depoKodu))
			{
				whereStr += " AND DPKODU='" + depoKodu + "' ";
			}

			var sonuc = new ListResponse<StdepoStokMiktarModel> { Items = new List<StdepoStokMiktarModel>() };

			var sql = @"SELECT * FROM (SELECT dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.UASTBG.STKODU, dbo.STKART.STKNAM, STKART_AGAC.OLCUKD, STKART_AGAC.SADEGK, STKART_AGAC.SAOLKD
	                            FROM dbo.STKART AS STKART_AGAC INNER JOIN
                                dbo.STMALT INNER JOIN
                                dbo.UASTBG INNER JOIN
                                dbo.URAGAC ON dbo.UASTBG.URAKOD = dbo.URAGAC.URAKOD AND dbo.UASTBG.SIRKID = dbo.URAGAC.SIRKID INNER JOIN
                                dbo.STKART ON dbo.UASTBG.STKODU = dbo.STKART.STKODU AND dbo.UASTBG.SIRKID = dbo.STKART.SIRKID ON dbo.STMALT.STMLTR = dbo.STKART.STMLTR AND dbo.STMALT.SIRKID = dbo.STKART.SIRKID INNER JOIN
                                dbo.URAGAC AS URAGAC_1 INNER JOIN
                                dbo.UASTBG AS UASTBG_1 ON URAGAC_1.SIRKID = UASTBG_1.SIRKID AND URAGAC_1.URAKOD = UASTBG_1.URAKOD ON dbo.URAGAC.SIRKID = UASTBG_1.SIRKID AND dbo.URAGAC.STKODU = UASTBG_1.STKODU ON 
                                STKART_AGAC.SIRKID = URAGAC_1.SIRKID
	                            WHERE (dbo.STKART.STMLTR = '000') AND (dbo.UASTBG.ACTIVE = 1) AND (dbo.UASTBG.SLINDI = 0) AND (dbo.UASTBG.SIRKID = @SirketId)
	                            GROUP BY dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.UASTBG.STKODU, dbo.STKART.STKNAM, STKART_AGAC.OLCUKD, dbo.UASTBG.URAKOD, STKART_AGAC.SADEGK, STKART_AGAC.SAOLKD

	                            UNION ALL	SELECT dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.UASTBG.STKODU, dbo.STKART.STKNAM, dbo.STKART.OLCUKD, dbo.STKART.SADEGK, dbo.STKART.SAOLKD
                                FROM dbo.UASTBG INNER JOIN
                                dbo.URAGAC ON dbo.UASTBG.URAKOD = dbo.URAGAC.URAKOD AND dbo.UASTBG.SIRKID = dbo.URAGAC.SIRKID INNER JOIN
                                dbo.STKART ON dbo.UASTBG.STKODU = dbo.STKART.STKODU AND dbo.UASTBG.SIRKID = dbo.STKART.SIRKID INNER JOIN
                                dbo.STMALT ON dbo.STKART.STMLTR = dbo.STMALT.STMLTR AND dbo.STKART.SIRKID = dbo.STMALT.SIRKID
                                WHERE (dbo.STKART.STMLTR = '" + Param.MAMUL_KODU + "') AND (dbo.UASTBG.ACTIVE = 1) AND (dbo.UASTBG.SLINDI = 0) AND (dbo.UASTBG.SIRKID = @SirketId) AND (dbo.STKART.ACTIVE = 1) " +

								@"GROUP BY dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.UASTBG.STKODU, dbo.STKART.STKNAM, dbo.STKART.OLCUKD, dbo.UASTBG.URAKOD, dbo.STKART.SADEGK, dbo.STKART.SAOLKD
	                            UNION ALL
	                                SELECT dbo.STKART.Id, dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.STDEPO.STKODU, dbo.STKART.STKNAM, dbo.STKART.OLCUKD, dbo.STKART.SADEGK, dbo.STKART.SAOLKD
                                FROM dbo.STDEPO INNER JOIN
                                dbo.STKART ON dbo.STDEPO.STKODU = dbo.STKART.STKODU AND dbo.STDEPO.SIRKID = dbo.STKART.SIRKID INNER JOIN
                                dbo.STMALT ON dbo.STKART.STMLTR = dbo.STMALT.STMLTR AND dbo.STKART.SIRKID = dbo.STMALT.SIRKID
                                WHERE (dbo.STKART.STMLTR <> '" + Param.MAMUL_KODU + "') AND (dbo.STDEPO.ACTIVE = 1) AND (dbo.STDEPO.SLINDI = 0) AND (dbo.STDEPO.SIRKID = @SirketId)) AS T where 1=1 " + whereStr + " ORDER BY T.STKODU";

			sonuc.Items = _stdepoDal.GetListSqlQuery<StdepoStokMiktarModel>(sql, new SqlParameter("SirketId", global.SirketId));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<StdepoStokAdresModel> GetStokAdresRapor(Global global, string adres = null, string stokKodu = null, bool yetkiKontrol = true)
		{
			if (yetkiKontrol)
			{
				var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
				if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
			}

			var whereStrAdres = "";
			var whereStrStokKodu = "";


			if (!string.IsNullOrEmpty(adres))
			{
				whereStrAdres += " AND dbo.WMADRS.DPADRS='" + adres + "' ";
			}

			if (!string.IsNullOrEmpty(stokKodu))
			{
				whereStrStokKodu += " AND dbo.WMADRS.STKODU='" + stokKodu + "' ";
			}

			var sonuc = new ListResponse<StdepoStokAdresModel> { Items = new List<StdepoStokAdresModel>() };
			var sql = @"SELECT dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.WMADRS.STKODU, dbo.STKART.STKNAM, 
						SUM(dbo.WMADRS.USESTK) AS USESTK, dbo.STKART.OLCUKD, ISNULL(dbo.WMADRS.PARTIT,0) AS PARTIT, ISNULL(dbo.WMADRS.PARTIN, '') AS PARTIN, 
						dbo.WMADRS.DPADRS, dbo.GNDPTP.DPTIPT, dbo.WMADRS.URYRKD, dbo.WMADRS.DEPOKD, dbo.GNDPNO.DPKODU, dbo.GNDPTN.DPTANM
                        FROM dbo.WMADRS INNER JOIN
                        dbo.STKART ON dbo.WMADRS.STKODU = dbo.STKART.STKODU AND dbo.WMADRS.SIRKID = dbo.STKART.SIRKID AND dbo.WMADRS.ACTIVE = dbo.STKART.ACTIVE INNER JOIN
                        dbo.STMALT ON dbo.STKART.STMLTR = dbo.STMALT.STMLTR AND dbo.STKART.SIRKID = dbo.STMALT.SIRKID AND dbo.STKART.ACTIVE = dbo.STMALT.ACTIVE INNER JOIN
                        dbo.GNDPTP ON dbo.WMADRS.DEPOKD = dbo.GNDPTP.DEPOKD AND dbo.WMADRS.DPTIPI = dbo.GNDPTP.DPTIPI AND dbo.WMADRS.SIRKID = dbo.GNDPTP.SIRKID AND dbo.WMADRS.ACTIVE = dbo.GNDPTP.ACTIVE INNER JOIN
						dbo.GNDPNO ON dbo.WMADRS.URYRKD = dbo.GNDPNO.URYRKD AND dbo.WMADRS.DEPOKD = dbo.GNDPNO.DEPOKD AND dbo.WMADRS.SIRKID = dbo.GNDPNO.SIRKID AND dbo.WMADRS.ACTIVE = dbo.GNDPNO.ACTIVE INNER JOIN
						dbo.GNDPTN ON dbo.GNDPNO.DPKODU = dbo.GNDPTN.DPKODU AND dbo.GNDPTN.SIRKID = dbo.GNDPNO.SIRKID AND dbo.GNDPTN.ACTIVE = dbo.GNDPNO.ACTIVE
                        WHERE (dbo.WMADRS.ACTIVE = 1) AND (dbo.WMADRS.SLINDI = 0) AND (dbo.WMADRS.USESTK > 0) AND (dbo.WMADRS.SIRKID = @SirketId)" + whereStrAdres + whereStrStokKodu +
						@" GROUP BY dbo.STKART.STMLTR, dbo.STMALT.STMLNM, dbo.STKART.MALGKD, dbo.STKART.STANKD, dbo.STKART.STALKD, dbo.WMADRS.STKODU, 
						dbo.STKART.STKNAM, dbo.STKART.OLCUKD, dbo.WMADRS.DPADRS, dbo.GNDPTP.DPTIPT, ISNULL(dbo.WMADRS.PARTIT, 0), ISNULL(dbo.WMADRS.PARTIN, ''),
						dbo.WMADRS.URYRKD, dbo.WMADRS.DEPOKD, dbo.GNDPNO.DPKODU, dbo.GNDPTN.DPTANM";

			sonuc.Items = _stdepoDal.GetListSqlQuery<StdepoStokAdresModel>(sql, new SqlParameter("SirketId", global.SirketId));
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		#endregion ClientFunc
    }
}
