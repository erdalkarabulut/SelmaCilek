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

using System.Collections.Generic;
using System.Data.SqlClient;
using Bps.BpsBase.Entities.Models.ST.Listed;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.ST
{
    public class SthrktManager : ISthrktService
    {
        private ISthrktDal _sthrktDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public SthrktManager(ISthrktDal sthrktDal,IGnService gnservice,ILockedService lockedservice)
        {
            _sthrktDal = sthrktDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<STHRKT> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STHRKT>();
            sonuc.Items = global.SirketId != null ? _sthrktDal.GetList(x => x.SIRKID == global.SirketId) : _sthrktDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STHRKT> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STHRKT>();
            sonuc.Items = global.SirketId != null ? _sthrktDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _sthrktDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STHRKT> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STHRKT>();
            sonuc.Items = global.SirketId != null ? _sthrktDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _sthrktDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STHRKT> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STHRKT>();
            sonuc.Items = global.SirketId != null ? _sthrktDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _sthrktDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STHRKT> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STHRKT>();
            sonuc.Items = global.SirketId != null ? _sthrktDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _sthrktDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STHRKT> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<STHRKT>();
            sonuc.Nesne = _sthrktDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<STHRKT> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("STHRKT", id, global);
            var sonuc = new StandardResponse<STHRKT>();
            sonuc.Nesne = _sthrktDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SthrktValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STHRKT> Ncch_Add_NLog(STHRKT sthrkt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STHRKT>();
            sthrkt.SIRKID = global.SirketId.Value; 
            sthrkt.EKKULL = global.UserKod;
            sthrkt.ETARIH = DateTime.Now;
            sthrkt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sthrktDal.Add(sthrkt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SthrktValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STHRKT> Ncch_Update_Log(STHRKT sthrkt,STHRKT oldSthrkt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STHRKT", sthrkt.Id, global);
            var sonuc = new StandardResponse<STHRKT>();
            sthrkt.SIRKID = global.SirketId.Value; 
            sthrkt.DEKULL = global.UserKod;
            sthrkt.DTARIH = DateTime.Now;
            sthrkt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sthrktDal.Update(sthrkt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SthrktValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STHRKT> Ncch_UpdateAktifPasif_Log(STHRKT sthrkt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<STHRKT>();
            sthrkt.SIRKID = global.SirketId.Value; 
            sthrkt.ACTIVE = !sthrkt.ACTIVE;
            sthrkt.DEKULL = global.UserKod;
            sthrkt.DTARIH = DateTime.Now;
            sthrkt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sthrktDal.Update(sthrkt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SthrktValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<STHRKT> Ncch_Delete_Log(STHRKT sthrkt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("STHRKT", sthrkt.Id, global);
            var sonuc = new StandardResponse<STHRKT>();
            sthrkt.SIRKID = global.SirketId.Value; 
            sthrkt.ACTIVE = false;
            sthrkt.SLINDI = true;
            sthrkt.DEKULL = global.UserKod;
            sthrkt.DTARIH = DateTime.Now;
            sthrkt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _sthrktDal.Update(sthrkt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<STHRKT> Cch_GetListBaslikByFisTip_NLog(Global global, int? fisTip, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STHRKT>();
            sonuc.Items = global.SirketId != null
                ? _sthrktDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.STFTNO == fisTip)
                : _sthrktDal.GetList(x => x.SLINDI == false && x.STFTNO == fisTip);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STHRKT> Ncch_GetListKalemByFisTip_NLog(Global global, int? fisTip, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STHRKT>();
            sonuc.Items = global.SirketId != null
                ? _sthrktDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.STFTNO == fisTip)
                : _sthrktDal.GetList(x => x.SLINDI == false && x.STFTNO == fisTip);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STHRKT> Ncch_GetListKalemByBelgeNo_NLog(Global global, string belgeNo, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<STHRKT>();
            sonuc.Items = global.SirketId != null
                ? _sthrktDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.BELGEN == belgeNo)
                : _sthrktDal.GetList(x => x.SLINDI == false && x.BELGEN == belgeNo);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SthrktStokHareketModel> GetStokHareketRapor(DateTime date1, DateTime date2, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }

            string dateStr1 = date1.ToString("yyyy-MM-dd 00:00:00.000");
            string dateStr2 = date2.ToString("yyyy-MM-dd 23:59:59.999");

            var sonuc = new ListResponse<SthrktStokHareketModel> { Items = new List<SthrktStokHareketModel>() };
            var sql =
                @"SELECT DISTINCT dbo.STHRKT.Id, dbo.STHRKT.SIRKID, dbo.STHRKT.STFTNO, dbo.STHBAS.EVRAKN, CONVERT(date, dbo.STHRKT.BELTRH) AS BELTRH,
                        dbo.STFTIP.TANIMI, dbo.STHRKT.STKODU, dbo.STHRKT.STKNAM, dbo.STHRKT.GNMKTR, dbo.STHRKT.OLCUKD,
                        dbo.STHRKT.PARTIN, dbo.STHBAS.GNACIK, dbo.STHBAS.OPTMZS, dbo.IKPERS.GNNAME + ' ' + dbo.IKPERS.GNSNAM AS TSALAN,
                        dbo.STHRKT.CRKODU, dbo.STHRKT.TSTARH, dbo.GNKULL.GNNAME + ' ' + dbo.GNKULL.GNSNAM AS GNKULL, dbo.STHRKT.ETARIH, 
						dbo.STHRKT.BELGEN, dbo.STHRKT.USTBLG, CKADRS, GRADRS,dbo.STHRKT.VRKODU
                        FROM dbo.STHRKT LEFT OUTER JOIN
                        dbo.STFTIP ON dbo.STHRKT.STFTNO = dbo.STFTIP.STFTNO AND dbo.STHRKT.SIRKID = dbo.STFTIP.SIRKID LEFT OUTER JOIN
                        dbo.GNKULL ON dbo.STHRKT.EKKULL = dbo.GNKULL.KULKOD AND dbo.STHRKT.SIRKID = dbo.GNKULL.SIRKID LEFT OUTER JOIN
						dbo.STHBAS ON dbo.STHRKT.STFTNO = dbo.STHBAS.STFTNO AND dbo.STHRKT.BELGEN = dbo.STHBAS.BELGEN AND dbo.STHRKT.SIRKID = dbo.STHBAS.SIRKID LEFT OUTER JOIN
						dbo.IKPERS ON dbo.STHRKT.TSALAN = dbo.IKPERS.SICILN AND dbo.STHRKT.SIRKID = dbo.IKPERS.SIRKID
                        WHERE dbo.STHRKT.ETARIH >= '" + dateStr1 + "' AND dbo.STHRKT.ETARIH <= '" + dateStr2 + "' AND (dbo.STHRKT.ACTIVE = 1) AND (dbo.STHRKT.SLINDI = 0) AND (dbo.STHRKT.SIRKID = @SirketId) " +
                        "ORDER BY dbo.STHRKT.ETARIH DESC";

            sonuc.Items = _sthrktDal.GetListSqlQuery<SthrktStokHareketModel>(sql, new SqlParameter("SirketId", global.SirketId));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SthrktMiktarByPartiModel> GetStokMiktarFromHareketByParti(Global global, string whereFilter = "", bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }

            if (whereFilter != "") whereFilter = "AND " + whereFilter;

            var sonuc = new ListResponse<SthrktMiktarByPartiModel> { Items = new List<SthrktMiktarByPartiModel>() };
            //      var sql = @"SELECT * FROM(
            //SELECT STKODU, STKNAM, SUM(GNMKTR) AS GNMKTR, OLCUKD, PARTIN, DPKODU, DPTANM, MIPGOS FROM(
            //SELECT dbo.STHRKT.STKODU, dbo.STHRKT.STKNAM, CASE WHEN dbo.STHRKT.STHRTP = 0 THEN dbo.STHRKT.GNMKTR 
            //WHEN dbo.STHRKT.STHRTP = 1 THEN dbo.STHRKT.GNMKTR * (-1) END AS GNMKTR, dbo.STHRKT.OLCUKD, dbo.STHRKT.PARTIN, 
            //CASE WHEN dbo.STHRKT.STHRTP = 0 THEN DP1.DPKODU WHEN dbo.STHRKT.STHRTP = 1 THEN DP2.DPKODU END AS DPKODU,
            //CASE WHEN dbo.STHRKT.STHRTP = 0 THEN DP1.DPTANM WHEN dbo.STHRKT.STHRTP = 1 THEN DP2.DPTANM END AS DPTANM,
            //CASE WHEN dbo.STHRKT.STHRTP = 0 THEN DP1.MIPGOS WHEN dbo.STHRKT.STHRTP = 1 THEN DP2.MIPGOS END AS MIPGOS
            //                  FROM dbo.STHRKT LEFT OUTER JOIN
            //dbo.GNDPTN AS DP1 ON dbo.STHRKT.GRDEPO = DP1.DPKODU LEFT OUTER JOIN
            //dbo.GNDPTN AS DP2 ON dbo.STHRKT.CKDEPO = DP2.DPKODU LEFT OUTER JOIN
            //                  dbo.STFTIP ON dbo.STHRKT.STFTNO = dbo.STFTIP.STFTNO AND dbo.STHRKT.SIRKID = dbo.STFTIP.SIRKID LEFT OUTER JOIN
            //                  dbo.GNKULL ON dbo.STHRKT.SIRKID = dbo.GNKULL.SIRKID AND dbo.STHRKT.EKKULL = dbo.GNKULL.KULKOD LEFT OUTER JOIN
            //dbo.STHBAS ON dbo.STHRKT.SIRKID = dbo.STHBAS.SIRKID AND dbo.STHRKT.BELGEN = dbo.STHBAS.BELGEN
            //                  WHERE (dbo.STHRKT.ACTIVE = 1) AND (dbo.STHRKT.SLINDI = 0) AND (dbo.STHRKT.SIRKID = @SirketId) AND (dbo.STHRKT.PARTIT = 1)) AS T WHERE 1=1
            //GROUP BY T.STKODU, T.STKNAM, T.OLCUKD, T.PARTIN, T.DPKODU, T.DPTANM, T.MIPGOS) AS G
            //WHERE G.GNMKTR > 0 " + whereFilter + " ORDER BY G.PARTIN DESC";

            var sql = @"SELECT * FROM(
			    SELECT STMLTR, STKODU, STKNAM, SUM(GRMKTR) AS GRMKTR, OLCUKD, PARTIN, DPKODU, DPTANM, MIPGOS FROM(
			    SELECT dbo.STKART.STMLTR, dbo.STHRKT.STKODU, dbo.STHRKT.STKNAM, CASE WHEN dbo.STHRKT.STHRTP = 0 THEN dbo.STHRKT.GRMKTR 
			    WHEN dbo.STHRKT.STHRTP = 1 THEN dbo.STHRKT.GRMKTR * (-1) END AS GRMKTR, dbo.STHRKT.OLCUKD, dbo.STHRKT.PARTIN, 
			    CASE WHEN dbo.STHRKT.STHRTP = 0 THEN DP1.DPKODU WHEN dbo.STHRKT.STHRTP = 1 THEN DP2.DPKODU END AS DPKODU,
			    CASE WHEN dbo.STHRKT.STHRTP = 0 THEN DP1.DPTANM WHEN dbo.STHRKT.STHRTP = 1 THEN DP2.DPTANM END AS DPTANM,
			    CASE WHEN dbo.STHRKT.STHRTP = 0 THEN DP1.MIPGOS WHEN dbo.STHRKT.STHRTP = 1 THEN DP2.MIPGOS END AS MIPGOS,VRKODU
                FROM dbo.STHRKT LEFT OUTER JOIN
			    dbo.GNDPTN AS DP1 ON dbo.STHRKT.GRDEPO = DP1.DPKODU AND dbo.STHRKT.SIRKID = DP1.SIRKID LEFT OUTER JOIN
			    dbo.GNDPTN AS DP2 ON dbo.STHRKT.CKDEPO = DP2.DPKODU AND dbo.STHRKT.SIRKID = DP2.SIRKID LEFT OUTER JOIN
			    dbo.STKART ON dbo.STHRKT.STKODU = dbo.STKART.STKODU AND dbo.STHRKT.SIRKID = dbo.STKART.SIRKID LEFT OUTER JOIN
                dbo.STFTIP ON dbo.STHRKT.STFTNO = dbo.STFTIP.STFTNO AND dbo.STHRKT.SIRKID = dbo.STFTIP.SIRKID LEFT OUTER JOIN
                dbo.GNKULL ON dbo.STHRKT.SIRKID = dbo.GNKULL.SIRKID AND dbo.STHRKT.EKKULL = dbo.GNKULL.KULKOD LEFT OUTER JOIN
			    dbo.STHBAS ON dbo.STHRKT.SIRKID = dbo.STHBAS.SIRKID AND dbo.STHRKT.BELGEN = dbo.STHBAS.BELGEN
                WHERE (dbo.STKART.ACTIVE = 1) AND (dbo.STHRKT.ACTIVE = 1) AND (dbo.STHRKT.SLINDI = 0) AND (dbo.STHRKT.SIRKID = @SirketId) AND (dbo.STHRKT.PARTIT = 1)) AS T WHERE 1=1
			    GROUP BY T.STMLTR, T.STKODU, T.STKNAM, T.OLCUKD, T.PARTIN, T.DPKODU, T.DPTANM, T.MIPGOS) AS G
			    WHERE 1 = 1 " + whereFilter + " ORDER BY G.PARTIN DESC";
	            //WHERE G.GRMKTR > 0 " + whereFilter + " ORDER BY G.PARTIN DESC";

            sonuc.Items = _sthrktDal.GetListSqlQuery<SthrktMiktarByPartiModel>(sql, new SqlParameter("SirketId", global.SirketId));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<STHRKT> Ncch_GetListKalemByUstBelgeNo_NLog(Global global, string ustBelgeNo, bool yetkiKontrol = true)
        {
	        if (yetkiKontrol)
	        {
		        var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
		        if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
	        }
	        var sonuc = new ListResponse<STHRKT>();
	        sonuc.Items = global.SirketId != null
		        ? _sthrktDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.USTBLG == ustBelgeNo)
		        : _sthrktDal.GetList(x => x.SLINDI == false && x.USTBLG == ustBelgeNo);
	        sonuc.Status = ResponseStatusEnum.OK;
	        return sonuc;
        }

        #endregion ClientFunc
    }
}
