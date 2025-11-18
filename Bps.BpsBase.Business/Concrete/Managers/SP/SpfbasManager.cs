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

using Bps.BpsBase.Entities.Models.SP.Single;
using Bps.BpsBase.Entities.Models.SP.Listed;
using System.Linq;
using System.Data.SqlClient;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.SP
{
    public class SpfbasManager : ISpfbasService
    {
        private ISpfbasDal _spfbasDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public SpfbasManager(ISpfbasDal spfbasDal,IGnService gnservice,ILockedService lockedservice)
        {
            _spfbasDal = spfbasDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<SPFBAS> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFBAS>();
            sonuc.Items = global.SirketId != null ? _spfbasDal.GetList(x => x.SIRKID == global.SirketId) : _spfbasDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPFBAS> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFBAS>();
            sonuc.Items = global.SirketId != null ? _spfbasDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _spfbasDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPFBAS> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFBAS>();
            sonuc.Items = global.SirketId != null ? _spfbasDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _spfbasDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPFBAS> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFBAS>();
            sonuc.Items = global.SirketId != null ? _spfbasDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _spfbasDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPFBAS> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFBAS>();
            sonuc.Items = global.SirketId != null ? _spfbasDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _spfbasDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPFBAS> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<SPFBAS>();
            sonuc.Nesne = _spfbasDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPFBAS> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("SPFBAS", id, global);
            var sonuc = new StandardResponse<SPFBAS>();
            sonuc.Nesne = _spfbasDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpfbasValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPFBAS> Ncch_Add_NLog(SPFBAS spfbas, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SPFBAS>();
            spfbas.SIRKID = global.SirketId.Value; 
            spfbas.EKKULL = global.UserKod;
            spfbas.ETARIH = DateTime.Now;
            spfbas.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spfbasDal.Add(spfbas);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpfbasValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPFBAS> Ncch_Update_Log(SPFBAS spfbas,SPFBAS oldSpfbas, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SPFBAS", spfbas.Id, global);
            var sonuc = new StandardResponse<SPFBAS>();
            spfbas.SIRKID = global.SirketId.Value; 
            spfbas.DEKULL = global.UserKod;
            spfbas.DTARIH = DateTime.Now;
            spfbas.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spfbasDal.Update(spfbas);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpfbasValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPFBAS> Ncch_UpdateAktifPasif_Log(SPFBAS spfbas, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<SPFBAS>();
            spfbas.SIRKID = global.SirketId.Value; 
            spfbas.ACTIVE = !spfbas.ACTIVE;
            spfbas.DEKULL = global.UserKod;
            spfbas.DTARIH = DateTime.Now;
            spfbas.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spfbasDal.Update(spfbas);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(SpfbasValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<SPFBAS> Ncch_Delete_Log(SPFBAS spfbas, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("SPFBAS", spfbas.Id, global);
            var sonuc = new StandardResponse<SPFBAS>();
            spfbas.SIRKID = global.SirketId.Value; 
            spfbas.ACTIVE = false;
            spfbas.SLINDI = true;
            spfbas.DEKULL = global.UserKod;
            spfbas.DTARIH = DateTime.Now;
            spfbas.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _spfbasDal.Update(spfbas);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc


        public ListResponse<SPFBAS> Cch_GetListByParam_NLog(SiparisParamModel param, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFBAS>();

            if (!string.IsNullOrEmpty(param.BELGEN))
            {
                sonuc.Items = _spfbasDal.GetList(x => x.SIRKID == global.SirketId && x.BELGEN == param.BELGEN && x.ACTIVE);
            }
            else
            {
                if (param.DtBitis == null)
                {
                    sonuc.Items = _spfbasDal.GetList(x => x.SIRKID == global.SirketId && x.BELTRH == param.DtBaslangic && x.SPFTNO == param.SPFTNO.Value && x.ACTIVE);
                }
                else
                {
                    sonuc.Items = _spfbasDal.GetList(x => x.SIRKID == global.SirketId && x.BELTRH >= param.DtBaslangic && x.BELTRH <= param.DtBitis && x.SPFTNO == param.SPFTNO.Value && x.ACTIVE);
                }
            }

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPFBAS> Ncch_GetListByCariByFlag_NLog(string cariKod, int sthrtp, bool flagKapandi, Global global)
        {
            var sonuc = new ListResponse<SPFBAS>();
            sonuc.Items = _spfbasDal.GetList(x =>
                x.SIRKID == global.SirketId && x.SLINDI == false && x.ACTIVE && x.CRKODU == cariKod && x.SPHRTP == sthrtp && x.FLGKPN == flagKapandi).ToList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SPFBAS> Ncch_GetActiveTalepList_NLog(int spftno, Global global, bool yetkiKontrol = true)
        {
            var sonuc = new ListResponse<SPFBAS>();
            sonuc.Items = _spfbasDal.GetList(x =>
                x.SPFTNO == spftno && x.SIRKID == global.SirketId && x.SIPVER != true && x.SLINDI == false && x.ACTIVE).ToList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<SPFBAS> Ncch_GetByBelgeNo_NLog(string belgeNo, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<SPFBAS>();
            sonuc.Nesne = _spfbasDal.Get(x => x.SIRKID == global.SirketId && x.BELGEN == belgeNo && x.ACTIVE);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }


        public ListResponse<SPFBAS> Ncch_GetListByTesFisTip_NLog(int tesFistip, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SPFBAS>();

            var sql = @"select 
	                        *
	                        from
	                        SPFBAS as sipb
	                        left join SPFTIP as fi on fi.SPFTNO=sipb.SPFTNO and fi.SIRKID=sipb.SIRKID
	                        where sipb.SIRKID=@SirketId and sipb.ACTIVE=1 and fi.TSFTNO=1
	                        order by fi.ETARIH desc";

            sonuc.Items = _spfbasDal.GetListSqlQuery<SPFBAS>(sql, new SqlParameter("SirketId", global.SirketId));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<T> Ncch_GetSaRaporMasterDetail_NLog<T>(Global global, string basTarih, string bitTarih, bool yetkiKontrol = true)
        {
            var tType = typeof(T);

            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<T>();

            //string sql = @"SELECT dbo.SPFBAS.SIRKID, dbo.SPFBAS.CRKODU, dbo.CRCARI.CRUNV1, dbo.SPFBAS.DVCNKD, ISNULL(SUM(dbo.SPFBAS.TOPKDT), 0) AS TOPKDT
            //            FROM dbo.SPFBAS 
            //            LEFT OUTER JOIN dbo.CRCARI ON dbo.SPFBAS.SIRKID = dbo.CRCARI.SIRKID AND dbo.SPFBAS.CRKODU = dbo.CRCARI.CRKODU 
            //            WHERE dbo.SPFBAS.SIRKID = @SirketId AND dbo.SPFBAS.ACTIVE = 1 AND dbo.SPFBAS.SPHRTP = 0 AND BELTRH >= @BasTarih AND BELTRH <= @BitTarih
            //            GROUP BY dbo.SPFBAS.SIRKID, dbo.SPFBAS.CRKODU, dbo.CRCARI.CRUNV1, dbo.SPFBAS.DVCNKD";

            string sql = @"SELECT SIRKID, CRKODU, CRUNV1, DVCNKD, SUM(TOPKDT) AS TOPKDT, SUM(TLFIYT) AS TLFIYT FROM
						(SELECT dbo.SPFBAS.SIRKID, dbo.SPFBAS.CRKODU, dbo.CRCARI.CRUNV1, dbo.SPFBAS.DVCNKD, CASE WHEN dbo.SPFBAS.DVCNKD = 'USD' THEN dbo.SPFBAS.USDFYT WHEN dbo.SPFBAS.DVCNKD = 'EUR' THEN dbo.SPFBAS.EURFYT ELSE 1 END AS DVBRFY,
                        ISNULL(SUM(dbo.SPFBAS.TOPKDT), 0) AS TOPKDT,
						CASE WHEN dbo.SPFBAS.DVCNKD = 'USD' THEN ISNULL(SUM(dbo.SPFBAS.TOPKDT), 0) * dbo.SPFBAS.USDFYT WHEN dbo.SPFBAS.DVCNKD = 'EUR' THEN ISNULL(SUM(dbo.SPFBAS.TOPKDT), 0) * dbo.SPFBAS.EURFYT ELSE ISNULL(SUM(dbo.SPFBAS.TOPKDT), 0) END AS TLFIYT
                        FROM dbo.SPFBAS 
                        LEFT OUTER JOIN dbo.CRCARI ON dbo.SPFBAS.SIRKID = dbo.CRCARI.SIRKID AND dbo.SPFBAS.CRKODU = dbo.CRCARI.CRKODU 
						WHERE dbo.SPFBAS.SIRKID = @SirketId AND dbo.SPFBAS.ACTIVE = 1 AND dbo.SPFBAS.SPHRTP = 0 AND BELTRH >= @BasTarih AND BELTRH <= @BitTarih
                        GROUP BY dbo.SPFBAS.SIRKID, dbo.SPFBAS.CRKODU, dbo.CRCARI.CRUNV1, dbo.SPFBAS.DVCNKD, dbo.SPFBAS.USDFYT, dbo.SPFBAS.EURFYT) AS T
						GROUP BY SIRKID, CRKODU, CRUNV1, DVCNKD";

            if (tType == typeof(SaRaporBaslikAyrinti))
            {
                sql = @"SELECT DISTINCT dbo.SPFBAS.SIRKID, dbo.SPFBAS.CRKODU, dbo.SPFTIP.TANIMI, dbo.SPFBAS.BELGEN, dbo.SPFBAS.BELTRH, ISNULL(dbo.SPFBAS.TOPBRT, 0) AS TOPBRT, ISNULL(dbo.SPFBAS.TOPISK, 0) AS TOPISK, ISNULL(dbo.SPFBAS.TOPTUT, 0 ) AS TOPTUT, ISNULL(dbo.SPFBAS.TOPKDV, 0) AS TOPKDV,
						ISNULL(dbo.SPFBAS.TOPKDT, 0) AS TOPKDT, dbo.SPFBAS.DVCNKD, CASE WHEN dbo.SPFBAS.DVCNKD = 'USD' THEN dbo.SPFBAS.USDFYT WHEN dbo.SPFBAS.DVCNKD = 'EUR' THEN dbo.SPFBAS.EURFYT ELSE 1 END AS DVBRFY,
						CASE WHEN dbo.SPFBAS.DVCNKD = 'USD' THEN ISNULL(dbo.SPFBAS.TOPKDT, 0) * dbo.SPFBAS.USDFYT WHEN dbo.SPFBAS.DVCNKD = 'EUR' THEN ISNULL(dbo.SPFBAS.TOPKDT, 0) * dbo.SPFBAS.EURFYT ELSE ISNULL(dbo.SPFBAS.TOPKDT, 0) END AS TLFIYT,
						dbo.SPFBAS.TERTAR, dbo.SPFBAS.FLGKPN, dbo.GNKULL.GNNAME + ' ' + dbo.GNKULL.GNSNAM AS GNNAME
						FROM dbo.SPFBAS INNER JOIN
                        dbo.SPFHAR ON dbo.SPFBAS.SIRKID = dbo.SPFHAR.SIRKID AND dbo.SPFBAS.BELGEN = dbo.SPFHAR.BELGEN LEFT OUTER JOIN
                        dbo.GNKULL ON dbo.SPFBAS.SIRKID = dbo.GNKULL.SIRKID AND dbo.SPFBAS.EKKULL = dbo.GNKULL.KULKOD LEFT OUTER JOIN
                        dbo.SPFTIP ON dbo.SPFBAS.SIRKID = dbo.SPFTIP.SIRKID AND dbo.SPFBAS.SPFTNO = dbo.SPFTIP.SPFTNO
						WHERE dbo.SPFBAS.SIRKID = @SirketId AND dbo.SPFBAS.ACTIVE = 1 AND dbo.SPFBAS.SPHRTP = 0 AND dbo.SPFBAS.BELTRH >= @BasTarih AND dbo.SPFBAS.BELTRH <= @BitTarih
                        ORDER BY dbo.SPFBAS.BELTRH DESC";
            }
            else if (tType == typeof(SaRaporKalem))
            {
                sql = @"SELECT DISTINCT dbo.SPFHAR.SIRKID, dbo.SPFHAR.BELGEN, dbo.SPFHAR.SATIRN, dbo.SPFHAR.STKODU, dbo.STKART.STKNAM, dbo.SPFHAR.PARTIN, dbo.SPFHAR.GRMKTR, dbo.SPFHAR.GROLBR, dbo.SPFHAR.GRDEPO, dbo.GNDPTN.DPTANM, dbo.SPFHAR.DVCNKD,
                        ISNULL(dbo.SPFHAR.GFIYAT, 0) AS GFIYAT, ISNULL(dbo.SPFHAR.GNTUTR, 0) AS GNTUTR, dbo.SPFHAR.DVZFYT, ISNULL(dbo.SPFHAR.GISKNT, 0) AS GISKNT, ISNULL(dbo.SPFHAR.VRGORN, 0) AS VRGORN, dbo.SPFBAS.TERTAR, dbo.SPFHAR.FLGKPN
						FROM dbo.SPFHAR INNER JOIN
                        dbo.STKART ON dbo.SPFHAR.SIRKID = dbo.STKART.SIRKID AND dbo.SPFHAR.STKODU = dbo.STKART.STKODU INNER JOIN
                        dbo.GNDPTN ON dbo.SPFHAR.SIRKID = dbo.GNDPTN.SIRKID AND dbo.SPFHAR.GRDEPO = dbo.GNDPTN.DPKODU INNER JOIN
                        dbo.SPFBAS ON dbo.SPFHAR.SIRKID = dbo.SPFBAS.SIRKID AND dbo.SPFHAR.BELGEN = dbo.SPFBAS.BELGEN
						WHERE dbo.SPFBAS.SIRKID = @SirketId AND dbo.SPFBAS.ACTIVE = 1 AND dbo.SPFBAS.SPHRTP = 0 AND dbo.SPFBAS.BELTRH >= @BasTarih AND dbo.SPFBAS.BELTRH <= @BitTarih
						ORDER BY dbo.SPFHAR.BELGEN, dbo.SPFHAR.SATIRN";
            }

            sonuc.Items = _spfbasDal.GetListSqlQuery<T>(sql, new SqlParameter("SirketId", global.SirketId),
                        new SqlParameter("BasTarih", basTarih),
                        new SqlParameter("BitTarih", bitTarih));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<T> Ncch_GetTeklifRaporMasterDetail_NLog<T>(Global global, string basTarih, string bitTarih, bool yetkiKontrol = true)
        {
            var tType = typeof(T);

            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<T>();

            string sql = @"SELECT dbo.SPFBAS.SIRKID, dbo.SPFBAS.BELGEN, dbo.SPFBAS.BELTRH, dbo.SPFBAS.SPFTNO, dbo.SPFBAS.CRKODU, dbo.CRCARI.CRUNV1, dbo.SPFBAS.DVCNKD, dbo.SPFBAS.TOPKDT, dbo.SPFBAS.TKTRKD, dbo.SPFBAS.KAYNAK, dbo.SPFBAS.SPUTKD, 
                        dbo.GNKULL.GNNAME + ' ' + dbo.GNKULL.GNSNAM AS YETKLI, dbo.SPFBAS.SPDRKD, dbo.SPFBAS.GNACIK, GNKULL_1.GNNAME + ' ' + GNKULL_1.GNSNAM AS KAYDEN, dbo.SPFBAS.DTARIH
                        FROM dbo.SPFBAS LEFT OUTER JOIN
                        dbo.GNKULL AS GNKULL_1 ON dbo.SPFBAS.DEKULL = GNKULL_1.KULKOD AND dbo.SPFBAS.SIRKID = GNKULL_1.SIRKID LEFT OUTER JOIN
                        dbo.GNKULL ON dbo.SPFBAS.SIRKID = dbo.GNKULL.SIRKID AND dbo.SPFBAS.EKKULL = dbo.GNKULL.KULKOD LEFT OUTER JOIN
                        dbo.CRCARI ON dbo.SPFBAS.CRKODU = dbo.CRCARI.CRKODU AND dbo.SPFBAS.SIRKID = dbo.CRCARI.SIRKID
                        WHERE dbo.SPFBAS.SIRKID = @SirketId AND dbo.SPFBAS.ACTIVE = 1 AND (dbo.SPFBAS.SPHRTP = 4 OR dbo.SPFBAS.SPHRTP = 5) AND dbo.SPFBAS.BELTRH >= @BasTarih AND dbo.SPFBAS.BELTRH <= @BitTarih
                        ORDER BY dbo.SPFBAS.BELTRH DESC, dbo.SPFBAS.BELGEN DESC";

      //      if (tType == typeof(SaRaporBaslikAyrinti))
      //      {
      //          sql = @"SELECT DISTINCT dbo.SPFBAS.SIRKID, dbo.SPFBAS.CRKODU, dbo.SPFTIP.TANIMI, dbo.SPFBAS.BELGEN, dbo.SPFBAS.BELTRH, ISNULL(dbo.SPFBAS.TOPBRT, 0) AS TOPBRT, ISNULL(dbo.SPFBAS.TOPISK, 0) AS TOPISK, ISNULL(dbo.SPFBAS.TOPTUT, 0 ) AS TOPTUT, ISNULL(dbo.SPFBAS.TOPKDV, 0) AS TOPKDV,
      //ISNULL(dbo.SPFBAS.TOPKDT, 0) AS TOPKDT, dbo.SPFBAS.DVCNKD, dbo.SPFBAS.TERTAR, dbo.SPFBAS.FLGKPN, dbo.GNKULL.GNNAME + ' ' + dbo.GNKULL.GNSNAM AS GNNAME
      //FROM dbo.SPFBAS INNER JOIN
      //                  dbo.SPFHAR ON dbo.SPFBAS.SIRKID = dbo.SPFHAR.SIRKID AND dbo.SPFBAS.BELGEN = dbo.SPFHAR.BELGEN LEFT OUTER JOIN
      //                  dbo.GNKULL ON dbo.SPFBAS.SIRKID = dbo.GNKULL.SIRKID AND dbo.SPFBAS.EKKULL = dbo.GNKULL.KULKOD LEFT OUTER JOIN
      //                  dbo.SPFTIP ON dbo.SPFBAS.SIRKID = dbo.SPFTIP.SIRKID AND dbo.SPFBAS.SPFTNO = dbo.SPFTIP.SPFTNO
      //WHERE dbo.SPFBAS.SIRKID = @SirketId AND dbo.SPFBAS.ACTIVE = 1 AND dbo.SPFBAS.SPHRTP = 0 AND dbo.SPFBAS.BELTRH >= @BasTarih AND dbo.SPFBAS.BELTRH <= @BitTarih
      //                  ORDER BY dbo.SPFBAS.BELTRH";
      //      }
            if (tType == typeof(SaRaporKalem))
            {
                sql = @"SELECT DISTINCT dbo.SPFHAR.SIRKID, dbo.SPFHAR.BELGEN, dbo.SPFHAR.SATIRN, dbo.SPFHAR.STKODU, dbo.STKART.STKNAM, dbo.SPFHAR.PARTIN, dbo.SPFHAR.GRMKTR, dbo.SPFHAR.GROLBR, dbo.SPFHAR.CKDEPO, dbo.GNDPTN.DPTANM, dbo.SPFBAS.DVCNKD,
                        ISNULL(dbo.SPFHAR.GFIYAT, 0) AS GFIYAT, ISNULL(dbo.SPFHAR.GNTUTR, 0) AS GNTUTR, ISNULL(dbo.SPFHAR.GISKNT, 0) AS GISKNT, ISNULL(dbo.SPFHAR.VRGORN, 0) AS VRGORN, dbo.SPFBAS.TERTAR, dbo.SPFBAS.FLGKPN
						FROM dbo.SPFHAR INNER JOIN
                        dbo.STKART ON dbo.SPFHAR.SIRKID = dbo.STKART.SIRKID AND dbo.SPFHAR.STKODU = dbo.STKART.STKODU INNER JOIN
                        dbo.GNDPTN ON dbo.SPFHAR.SIRKID = dbo.GNDPTN.SIRKID AND dbo.SPFHAR.CKDEPO = dbo.GNDPTN.DPKODU INNER JOIN
                        dbo.SPFBAS ON dbo.SPFHAR.SIRKID = dbo.SPFBAS.SIRKID AND dbo.SPFHAR.BELGEN = dbo.SPFBAS.BELGEN
						WHERE dbo.SPFBAS.SIRKID = @SirketId AND dbo.SPFBAS.ACTIVE = 1 AND (dbo.SPFBAS.SPHRTP = 4 OR dbo.SPFBAS.SPHRTP = 5) AND dbo.SPFBAS.BELTRH >= @BasTarih AND dbo.SPFBAS.BELTRH <= @BitTarih
						ORDER BY dbo.SPFHAR.BELGEN, dbo.SPFHAR.SATIRN";
            }

            sonuc.Items = _spfbasDal.GetListSqlQuery<T>(sql, new SqlParameter("SirketId", global.SirketId),
                        new SqlParameter("BasTarih", basTarih),
                        new SqlParameter("BitTarih", bitTarih));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SpBaslikAcikModel> Ncch_GetAcikSiparisList_NLog(Global global, int sphrtp, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SpBaslikAcikModel>();

            var sql = @"SELECT sp.Id, sp.SIRKID, sp.SPHRTP, sp.SPFTNO, sp.EVRAKN, sp.BELGEN, sp.BELTRH, sp.TERTAR, sp.CRKODU, cr.CRUNV1, sp.MALTES, sp.CKDEPO, sp.GRDEPO, dp.DPTANM AS GRDPTN,
						CASE WHEN dn.DEPOKD IS NULL THEN '' ELSE 'WM' END AS GRDPWM, sp.GNACIK, sp.FLGKPN, sp.EKKULL, sp.ETARIH
                        FROM SPFBAS AS sp 
                        INNER JOIN CRCARI AS cr ON sp.CRKODU = cr.CRKODU AND sp.SIRKID = cr.SIRKID
						LEFT OUTER JOIN GNDPTN AS dp ON sp.GRDEPO = dp.DPKODU AND sp.SIRKID = dp.SIRKID
						LEFT OUTER JOIN GNDPNO AS dn ON sp.GRDEPO = dn.DPKODU AND sp.SIRKID = dn.SIRKID
						WHERE sp.SIRKID = @SirketId AND SPHRTP = @Sphrtp AND (sp.FLGKPN IS NULL OR sp.FLGKPN = 0) AND sp.ACTIVE = 1 AND sp.SLINDI = 0 ORDER BY TERTAR";

            sonuc.Items = _spfbasDal.GetListSqlQuery<SpBaslikAcikModel>(sql, new SqlParameter("SirketId", global.SirketId), new SqlParameter("Sphrtp", sphrtp));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<SpRezervasyonPaket> Ncch_GetRezervasyonPaketList_NLog(string spBelgeNo, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<SpRezervasyonPaket>();

            var sql = @"SELECT dbo.SPFHAR.SIRKID, dbo.SPFHAR.SATIRN, dbo.SPFHAR.STKODU, dbo.SPFHAR.STKNAM, dbo.SPFHAR.CKDEPO, 
                        dbo.SPFHAR.GNMKTR, dbo.SPFHAR.KLNMKTR, dbo.SPFHAR.OLCUKD, dbo.SPREZV.BELGEN AS SRBLNO, dbo.SPREZV.ETARIH AS SRTARH, 
                        dbo.SPREZV.STKODU AS PKKODU, dbo.SPREZV.STKNAM AS PKTNAM, dbo.SPREZV.SPMKTR, dbo.SPREZV.RZMKTR, dbo.SPREZV.KLMKTR
                        FROM dbo.SPFHAR LEFT OUTER JOIN
                        dbo.SPREZV ON dbo.SPFHAR.SIRKID = dbo.SPREZV.SIRKID AND dbo.SPFHAR.BELGEN = dbo.SPREZV.SPBLNO COLLATE SQL_Latin1_General_CP1_CI_AS AND dbo.SPFHAR.SATIRN = dbo.SPREZV.SATIRN
                        WHERE dbo.SPFHAR.SIRKID = @SirketId AND dbo.SPFHAR.BELGEN = @SpBelgeNo AND dbo.SPFHAR.ACTIVE = 1 AND dbo.SPFHAR.SLINDI = 0";

            sonuc.Items = _spfbasDal.GetListSqlQuery<SpRezervasyonPaket>(sql, new SqlParameter("SirketId", global.SirketId), new SqlParameter("SpBelgeNo", spBelgeNo));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
