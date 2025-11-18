using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.SP;
using Bps.BpsBase.Business.Abstract.SP;
using Bps.BpsBase.DataAccess.Abstract.SP;
using Bps.BpsBase.Entities.Concrete.SP;

#region ClientUsing

using System.Linq;
using Bps.BpsBase.Entities.Models.SP.Listed;
using System.Data.SqlClient;
using Bps.BpsBase.Entities.Models.Firestore;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.SP
{
    public class SpfharManager : ISpfharService
    {
        private ISpfharDal _spfharDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public SpfharManager(ISpfharDal spfharDal,IGnService gnservice,ILockedService lockedservice)
        {
            _spfharDal = spfharDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<SPFHAR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFHAR>();
            sonuc.Items = global.SirketId != null ? _spfharDal.GetList(x => x.SIRKID == global.SirketId) : _spfharDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPFHAR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFHAR>();
            sonuc.Items = global.SirketId != null ? _spfharDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _spfharDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPFHAR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFHAR>();
            sonuc.Items = global.SirketId != null ? _spfharDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _spfharDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPFHAR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFHAR>();
            sonuc.Items = global.SirketId != null ? _spfharDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _spfharDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPFHAR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFHAR>();
            sonuc.Items = global.SirketId != null ? _spfharDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _spfharDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPFHAR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<SPFHAR>();
            sonuc.Nesne = _spfharDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPFHAR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("SPFHAR", id, global);
            var sonuc = new StandardResponse<SPFHAR>();
            sonuc.Nesne = _spfharDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpfharValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPFHAR> Ncch_Add_NLog(SPFHAR spfhar, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SPFHAR>();
            spfhar.SIRKID = global.SirketId.Value; 
            spfhar.EKKULL = global.UserKod;
            spfhar.ETARIH = DateTime.Now;
            spfhar.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spfharDal.Add(spfhar);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpfharValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPFHAR> Ncch_Update_Log(SPFHAR spfhar,SPFHAR oldSpfhar, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SPFHAR", spfhar.Id, global);
            var sonuc = new StandardResponse<SPFHAR>();
            spfhar.SIRKID = global.SirketId.Value; 
            spfhar.DEKULL = global.UserKod;
            spfhar.DTARIH = DateTime.Now;
            spfhar.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spfharDal.Update(spfhar);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpfharValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPFHAR> Ncch_UpdateAktifPasif_Log(SPFHAR spfhar, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SPFHAR>();
            spfhar.SIRKID = global.SirketId.Value; 
            spfhar.ACTIVE = !spfhar.ACTIVE;
            spfhar.DEKULL = global.UserKod;
            spfhar.DTARIH = DateTime.Now;
            spfhar.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spfharDal.Update(spfhar);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpfharValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPFHAR> Ncch_Delete_Log(SPFHAR spfhar, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SPFHAR", spfhar.Id, global);
            var sonuc = new StandardResponse<SPFHAR>();
            spfhar.SIRKID = global.SirketId.Value; 
            spfhar.ACTIVE = false;
            spfhar.SLINDI = true;
            spfhar.DEKULL = global.UserKod;
            spfhar.DTARIH = DateTime.Now;
            spfhar.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spfharDal.Update(spfhar);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<SPFHAR> Cch_GetListByBelge_NLog(string belgeNo, Global global)
        {
            var sonuc = new ListResponse<SPFHAR>();
            sonuc.Items = _spfharDal.GetList(x =>
                x.SIRKID == global.SirketId && x.SLINDI == false && x.ACTIVE && x.BELGEN == belgeNo).ToList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SaKalemFiyat> Ncch_GetSatinalmaSonFiyat_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SaKalemFiyat>();

            string sql = @"SELECT DISTINCT s.SIRKID, s.BELTRH, s.STKODU, s.STKNAM, s.PARTIN, s.DVCNKD, s.GNMKTR, s.OLCUKD, s.GRMKTR, s.GROLBR, s.GFIYAT, s.GNTUTR, dbo.STKART.SAOLKD,
                            CASE
                                WHEN s.PARTIN IS NOT NULL AND s.PARTIN <> '' THEN s.GFIYAT / CONVERT(DECIMAL(18,3), s.PARTIN)
                                ELSE NULL
                            END AS PRBRFY
                            FROM SPFHAR AS s
                            INNER JOIN (SELECT SIRKID, STKODU, MAX(BELTRH) AS BELTRH FROM SPFHAR GROUP BY SIRKID, STKODU, STKNAM, PARTIN, DVCNKD) AS j ON s.SIRKID = j.SIRKID AND s.STKODU = j.STKODU AND s.BELTRH = j.BELTRH
                            INNER JOIN dbo.STKART ON s.SIRKID = dbo.STKART.SIRKID AND s.STKODU = dbo.STKART.STKODU
                            WHERE s.SIRKID = @SirketId AND SPHRTP = 0 AND GRDEPO IS NOT NULL AND GFIYAT IS NOT NULL AND GFIYAT > 0 AND DVCNKD IS NOT NULL AND s.ACTIVE = 1
                            ORDER BY STKODU";

            sonuc.Items = _spfharDal.GetListSqlQuery<SaKalemFiyat>(sql, new SqlParameter("SirketId", global.SirketId));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SaAcikSiparisMiktar> Ncch_GetAcikSaSiparisAndTalepMiktar_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SaAcikSiparisMiktar>();

            string sql = @"SELECT ROW_NUMBER() OVER(ORDER BY STKODU) AS Id, STKODU, SUM(GNMKTR) AS GNMKTR, OLCUKD, SUM(GRMKTR) GRMKTR, GROLBR, SPHRTP FROM
                            (SELECT dbo.SPFBAS.BELGEN, dbo.SPFHAR.STKODU, dbo.SPFHAR.GNMKTR, dbo.SPFHAR.OLCUKD, 
                            dbo.SPFHAR.GRMKTR, dbo.SPFHAR.GROLBR, dbo.SPFBAS.SPHRTP, dbo.SPFBAS.FLGKPN, dbo.SPFBAS.SIPVER
                            FROM SPFBAS
                            INNER JOIN SPFHAR ON dbo.SPFBAS.BELGEN = dbo.SPFHAR.BELGEN AND dbo.SPFBAS.SIRKID = dbo.SPFHAR.SIRKID
                            WHERE (dbo.SPFBAS.SPHRTP = 0 OR dbo.SPFBAS.SPHRTP = 3) AND dbo.SPFBAS.FLGKPN = 0
                            AND (dbo.SPFBAS.SIPVER IS NULL OR dbo.SPFBAS.SIPVER = 0) AND dbo.SPFBAS.CKDEPO IS NULL 
                            AND dbo.SPFBAS.SIRKID = @SirketId AND dbo.SPFBAS.ACTIVE = 1 AND dbo.SPFBAS.SLINDI = 0
                            AND dbo.SPFHAR.ACTIVE = 1 AND dbo.SPFHAR.SLINDI = 0) AS S
                            GROUP BY STKODU, OLCUKD, GROLBR, SPHRTP";

            sonuc.Items = _spfharDal.GetListSqlQuery<SaAcikSiparisMiktar>(sql, new SqlParameter("SirketId", global.SirketId));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SiparisPaketIhtiyac> Ncch_GetSiparisPaketIhtiyacList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SiparisPaketIhtiyac>();

            string sql = @"SELECT T.SIRKID, SPHRTP, SPFTNO, TANIMI, T.BELGEN, BELTRH, TERTAR, CRKODU, CRUNV1, BSACIK, FLGKPN, MDKODU, MDLNAM, CKDEPO, DPTANM, HRACIK, T.GNREZV, T.URAKOD, T.SATIRN, T.PKKODU,
	                    T.PKTNAM, OLCUKD, SPMKTR, KLNMKTR, RZMKTR, RZKLMK, EKSIKK, SUM(ISNULL(PLNMKT, 0)) AS PLNMKT, EKSIKK - SUM(ISNULL(PLNMKT, 0)) AS IHTIYC, (USESTK - BLKSTK) AS USESTK
                    FROM
	                    (SELECT SPHR.SIRKID, SPHR.SPHRTP, SPHR.SPFTNO, SPTP.TANIMI, SPHR.BELGEN, SPHR.BELTRH, SPHR.CRKODU, SPHR.CRUNV1, SPHR.BSACIK, SPHR.TERTAR, SPHR.FLGKPN, 
	                    SPHR.MDKODU, SPHR.MDLNAM, SPHR.CKDEPO, DPTN.DPTANM, SPHR.HRACIK, SPHR.GNREZV, SPHR.URAKOD, SPHR.SATIRN, UAGC.STKODU AS PKKODU,
	                    SKRT.STKNAM AS PKTNAM, SPHR.OLCUKD, SPHR.SPMKTR, SPHR.KLNMKTR, SUM(SPRZ.RZMKTR) AS RZMKTR, SUM(SPRZ.KLMKTR) AS RZKLMK,
	                    (SPHR.KLNMKTR - SUM(ISNULL(RZMKTR, 0)) + SUM(ISNULL(KLMKTR, 0))) AS EKSIKK, SDPO.USESTK, SDPO.BLKSTK
	                    FROM
		                    (SELECT dbo.SPFBAS.SIRKID, dbo.SPFBAS.SPHRTP, dbo.SPFBAS.SPFTNO, dbo.SPFBAS.BELGEN, dbo.SPFBAS.BELTRH, dbo.SPFBAS.CRKODU, dbo.CRCARI.CRUNV1, dbo.SPFBAS.GNACIK AS BSACIK, 
		                    dbo.SPFBAS.TERTAR, dbo.SPFBAS.FLGKPN, dbo.SPFHAR.SATIRN, dbo.SPFHAR.STKODU AS MDKODU, dbo.SPFHAR.STKNAM AS MDLNAM, dbo.SPFHAR.CKDEPO, dbo.SPFHAR.GNMKTR AS SPMKTR, 
		                    dbo.SPFHAR.OLCUKD, dbo.SPFHAR.KLNMKTR, dbo.SPFHAR.GNACIK AS HRACIK, MAX(dbo.UASTBG.GNREZV) AS GNREZV, MAX(dbo.UASTBG.URAKOD) AS URAKOD
		                    FROM dbo.SPFBAS INNER JOIN
		                    dbo.SPFHAR ON dbo.SPFBAS.SIRKID = dbo.SPFHAR.SIRKID AND dbo.SPFBAS.BELGEN = dbo.SPFHAR.BELGEN LEFT OUTER JOIN
		                    dbo.ISREVZ INNER JOIN
		                    dbo.UASTBG ON dbo.ISREVZ.SIRKID = dbo.UASTBG.SIRKID AND dbo.ISREVZ.GNREZV = dbo.UASTBG.GNREZV ON dbo.SPFHAR.SIRKID = dbo.UASTBG.SIRKID AND 
		                    dbo.SPFHAR.STKODU = dbo.UASTBG.STKODU LEFT OUTER JOIN
		                    dbo.CRCARI ON dbo.SPFBAS.SIRKID = dbo.CRCARI.SIRKID AND dbo.SPFBAS.CRKODU = dbo.CRCARI.CRKODU
		                    WHERE (dbo.SPFBAS.FLGKPN = 0) AND (dbo.SPFBAS.SIRKID = @SirketId) AND (dbo.ISREVZ.URTONY = 1) AND (dbo.ISREVZ.ACTIVE = 1) AND (dbo.ISREVZ.SLINDI = 0) AND (dbo.SPFBAS.ACTIVE = 1)
		                    GROUP BY dbo.SPFBAS.SIRKID, dbo.SPFBAS.SPHRTP, dbo.SPFBAS.SPFTNO, dbo.SPFBAS.BELGEN, dbo.SPFBAS.BELTRH, dbo.SPFBAS.CRKODU, dbo.CRCARI.CRUNV1, dbo.SPFBAS.GNACIK, dbo.SPFBAS.TERTAR, 
		                    dbo.SPFBAS.FLGKPN, dbo.SPFHAR.SATIRN, dbo.SPFHAR.STKODU, dbo.SPFHAR.STKNAM, dbo.SPFHAR.CKDEPO, dbo.SPFHAR.GNMKTR, dbo.SPFHAR.OLCUKD, dbo.SPFHAR.KLNMKTR, dbo.SPFHAR.GNACIK) AS SPHR
	                    INNER JOIN URAGAC AS UAGC ON SPHR.SIRKID = UAGC.SIRKID AND SPHR.GNREZV = UAGC.GNREZV AND SPHR.URAKOD = UAGC.URAKOD
	                    INNER JOIN STKART AS SKRT ON UAGC.SIRKID = SKRT.SIRKID AND UAGC.STKODU = SKRT.STKODU
	                    INNER JOIN STDEPO AS SDPO ON UAGC.SIRKID = SDPO.SIRKID AND UAGC.STKODU = SDPO.STKODU AND UAGC.URYRKD = SDPO.URYRKD
	                    INNER JOIN GNDPTN AS DPTN ON SDPO.SIRKID = DPTN.SIRKID AND SDPO.URYRKD = DPTN.URYRKD AND CKDEPO = DPTN.DPKODU
	                    INNER JOIN SPFTIP AS SPTP ON SPHR.SIRKID = SPTP.SIRKID AND SPHR.SPHRTP = SPTP.SPHRTP AND SPHR.SPFTNO = SPTP.SPFTNO
	                    LEFT OUTER JOIN dbo.SPREZV AS SPRZ ON SPHR.SIRKID = SPRZ.SIRKID AND SPHR.BELGEN = SPRZ.SPBLNO AND UAGC.STKODU = SPRZ.STKODU
	                    WHERE UAGC.ACTIVE = 1 AND UAGC.FTNKLM = 0 AND SKRT.ACTIVE = 1 AND (SPRZ.ACTIVE = 1 OR SPRZ.ACTIVE IS NULL) AND SDPO.ACTIVE = 1 AND DPTN.ACTIVE = 1 AND SPTP.ACTIVE = 1 AND KLNMKTR > 0
	                    GROUP BY SPHR.SIRKID, SPHR.SPHRTP, SPHR.SPFTNO, SPTP.TANIMI, SPHR.BELGEN, SPHR.BELTRH, SPHR.CRKODU, SPHR.CRUNV1, SPHR.BSACIK, SPHR.TERTAR, SPHR.FLGKPN, 
	                    SPHR.MDKODU, SPHR.MDLNAM, SPHR.CKDEPO, DPTN.DPTANM, SPHR.HRACIK, SPHR.GNREZV, SPHR.URAKOD, SPHR.SATIRN, UAGC.STKODU, 
	                    SKRT.STKNAM, SPHR.OLCUKD, SPHR.SPMKTR, SPHR.KLNMKTR, SDPO.USESTK, SDPO.BLKSTK) AS T
					LEFT OUTER JOIN SPHRPL AS P ON T.BELGEN = P.BELGEN AND T.GNREZV = P.GNREZV AND T.URAKOD = P.URAKOD AND  T.SATIRN = P.SATIRN AND T.PKKODU = P.PKKODU
                    WHERE 1 = 1
					GROUP BY T.SIRKID, SPHRTP, SPFTNO, TANIMI, T.BELGEN, BELTRH, TERTAR, CRKODU, CRUNV1, BSACIK, FLGKPN, MDKODU, MDLNAM, CKDEPO, DPTANM, HRACIK, T.GNREZV, T.URAKOD, T.SATIRN, T.PKKODU,
	                    T.PKTNAM, OLCUKD, SPMKTR, KLNMKTR, RZMKTR, RZKLMK, EKSIKK, USESTK, BLKSTK
                    ORDER BY TERTAR, SATIRN";

            sonuc.Items = _spfharDal.GetListSqlQuery<SiparisPaketIhtiyac>(sql, new SqlParameter("@SirketId", global.SirketId));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<Product> Ncch_GetProformaProducts_NLog(string belgeNo, Global global, bool yetkiKontrol = false)
        {
	        if (yetkiKontrol)
	        {
		        var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
		        if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
	        }
	        var sonuc = new ListResponse<Product>();

	        string sql = @"SELECT Id, SIRKID, SATIRN, BELGEN, CAST ((CASE WHEN GNACIK IS NULL OR GNACIK = '' THEN 0 ELSE 1 END) AS BIT) AS CustomProduct, 
							STKODU AS ProductCode, STKNAM AS ProductName, GNACIK AS ProductDetails, STKNAM AS ProductNameEn, GNMKTR AS Quantity, OLCUKD AS Unit, 
							GFIYAT AS UnitPrice, GNTUTR AS TotalPrice, DVCNKD FROM SPFHAR
							WHERE BELGEN = @BelgeNo AND SIRKID = @SirketId AND ACTIVE = 1 AND SLINDI = 0
							ORDER BY SATIRN";

	        sonuc.Items = _spfharDal.GetListSqlQuery<Product>(sql, new SqlParameter("SirketId", global.SirketId), new SqlParameter("BelgeNo", belgeNo));
	        sonuc.Status = ResponseStatusEnum.OK;
	        return sonuc;
        }

        #endregion ClientFunc
    }
}
