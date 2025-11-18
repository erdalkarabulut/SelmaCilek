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

using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Bps.BpsBase.Entities.Models.UA;
using System.Collections.Generic;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.UR
{
    public class UragacManager : IUragacService
    {
        private IUragacDal _uragacDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
		#region ClientDals

		#endregion ClientDals
		#region ClientServices
		private IGnthrkService _gnthrkService;
		#endregion ClientServices

		public UragacManager(IUragacDal uragacDal,IGnService gnservice,ILockedService lockedservice
		#region ClientConts
		, IGnthrkService gnthrkService
		#endregion ClientConts
			)
		{
			_uragacDal = uragacDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
			#region ClientContsitems
			_gnthrkService = gnthrkService;
			#endregion ClientContsitems
		}

		public ListResponse<URAGAC> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<URAGAC>();
            sonuc.Items = global.SirketId != null ? _uragacDal.GetList(x => x.SIRKID == global.SirketId) : _uragacDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<URAGAC> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<URAGAC>();
            sonuc.Items = global.SirketId != null ? _uragacDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _uragacDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<URAGAC> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<URAGAC>();
            sonuc.Items = global.SirketId != null ? _uragacDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _uragacDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<URAGAC> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<URAGAC>();
            sonuc.Items = global.SirketId != null ? _uragacDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _uragacDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<URAGAC> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<URAGAC>();
            sonuc.Items = global.SirketId != null ? _uragacDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _uragacDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<URAGAC> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<URAGAC>();
            sonuc.Nesne = _uragacDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<URAGAC> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("URAGAC", id, global);
            var sonuc = new StandardResponse<URAGAC>();
            sonuc.Nesne = _uragacDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UragacValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<URAGAC> Ncch_Add_NLog(URAGAC uragac, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<URAGAC>();
            uragac.SIRKID = global.SirketId.Value; 
            uragac.EKKULL = global.UserKod;
            uragac.ETARIH = DateTime.Now;
            uragac.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uragacDal.Add(uragac);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UragacValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<URAGAC> Ncch_Update_Log(URAGAC uragac,URAGAC oldUragac, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("URAGAC", uragac.Id, global);
            var sonuc = new StandardResponse<URAGAC>();
            uragac.SIRKID = global.SirketId.Value; 
            uragac.DEKULL = global.UserKod;
            uragac.DTARIH = DateTime.Now;
            uragac.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uragacDal.Update(uragac);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UragacValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<URAGAC> Ncch_UpdateAktifPasif_Log(URAGAC uragac, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<URAGAC>();
            uragac.SIRKID = global.SirketId.Value; 
            uragac.ACTIVE = !uragac.ACTIVE;
            uragac.DEKULL = global.UserKod;
            uragac.DTARIH = DateTime.Now;
            uragac.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uragacDal.Update(uragac);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UragacValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<URAGAC> Ncch_Delete_Log(URAGAC uragac, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("URAGAC", uragac.Id, global);
            var sonuc = new StandardResponse<URAGAC>();
            uragac.SIRKID = global.SirketId.Value; 
            uragac.ACTIVE = false;
            uragac.SLINDI = true;
            uragac.DEKULL = global.UserKod;
            uragac.DTARIH = DateTime.Now;
            uragac.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uragacDal.Update(uragac);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

		#region ClientFunc

		public ListResponse<UrunAgaciRevizyonList> Ncch_GetMaxRevizyonNo_NLog(string stokKodu, string kullanimKodu, Global global,string _vrkodu = null)
		{

			var sonuc = new ListResponse<UrunAgaciRevizyonList>();
            if (_vrkodu == null)
            {
                var sql = @"select a.GNREZV  as RevizyonNo,b.TANIMI as RevizyonText
                from dbo.UASTBG as a 
                inner join ISREVZ as b on a.GNREZV = b.GNREZV
                       and a.SIRKID = b.SIRKID 
                where a.SIRKID=@sirketId and a.STKODU = @StokKodu and a.KLNKOD=@KullanimKodu
				group by a.GNREZV ,b.TANIMI	";

                //Thread.Sleep(3000);
                sonuc.Items = _uragacDal.GetListSqlQuery<UrunAgaciRevizyonList>(sql,
                    new SqlParameter("@StokKodu", stokKodu),
                    new SqlParameter("@sirketId", global.SirketId),
                    new SqlParameter("@KullanimKodu", kullanimKodu));
            }
            else
            {
                var sql = @"Select a.GNREZV  as RevizyonNo,b.TANIMI as RevizyonText
                from dbo.UASTBG as a 
                inner join ISREVZ as b on a.GNREZV = b.GNREZV
                       and a.SIRKID= b.SIRKID 
                where a.SIRKID=@sirketId and a.STKODU = @StokKodu and a.KLNKOD=@KullanimKodu
                and a.VRKODU = @vrkodu
				group by a.GNREZV ,b.TANIMI	";

			//Thread.Sleep(3000);
			sonuc.Items = _uragacDal.GetListSqlQuery<UrunAgaciRevizyonList>(sql,
				new SqlParameter("@StokKodu", stokKodu),
				new SqlParameter("@sirketId", global.SirketId),
				new SqlParameter("@KullanimKodu", kullanimKodu),
				new SqlParameter("@vrkodu", _vrkodu));
            }
            sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public StandardResponse Ncch_DeleteList_Log(string urunAgaciKodu, Global global)
		{
			var sonuc = new StandardResponse();

			var list = _uragacDal.GetList(g => g.SIRKID == global.SirketId && g.URAKOD == urunAgaciKodu).ToList();
			foreach (var uragac in list)
			{
				_uragacDal.Delete(uragac);
			}

			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<URAGAC> Ncch_GetListByUrakod_Log(string urunAgaciKodu, Global global)
		{
			var sonuc = new ListResponse<URAGAC>();
			sonuc.Items = _uragacDal.GetList(x => x.SIRKID == global.SirketId && x.URAKOD == urunAgaciKodu).ToList();
			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<UrunAgaciRevizyonList> Ncch_GetUrunAgaciRevizyonList_Log(string revizyonNo, string stokKodu, Global global)
		{

			var sonuc = new ListResponse<UrunAgaciRevizyonList>();
			var sql = @"SELECT 
                a.GNREZV as RevizyonNo, b.TANIMI as RevizyonText, a.URAKOD as UrunAgaciKodu
                FROM dbo.URAGAC AS a 
                INNER JOIN dbo.ISREVZ AS b ON a.GNREZV = b.GNREZV 
                INNER JOIN dbo.UASTBG AS c ON a.URAKOD = c.URAKOD
                WHERE a.GNREZV = @RevizyonNo and c.STKODU = @StokKodu and a.SIRKID = @SirketId
                group by a.GNREZV,b.TANIMI,a.URAKOD";

			//Thread.Sleep(3000);
			sonuc.Items = _uragacDal.GetListSqlQuery<UrunAgaciRevizyonList>(sql,
				new SqlParameter("@StokKodu", stokKodu),
				new SqlParameter("@SirketId", global.SirketId),
				new SqlParameter("@RevizyonNo", revizyonNo));

			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}
		public ListResponse<UrunAgaciRevizyonList> Ncch_GetUrunAgaciRevizyonList_Log(string revizyonNo, string stokKodu, Global global,string vrkodu)
		{

			var sonuc = new ListResponse<UrunAgaciRevizyonList>();
			var sql = @"SELECT 
                a.GNREZV as RevizyonNo, b.TANIMI as RevizyonText, a.URAKOD as UrunAgaciKodu
                FROM dbo.URAGAC AS a 
                INNER JOIN dbo.ISREVZ AS b ON a.GNREZV = b.GNREZV 
                INNER JOIN dbo.UASTBG AS c ON a.URAKOD = c.URAKOD
                WHERE a.GNREZV = @RevizyonNo and c.STKODU = @StokKodu and a.SIRKID = @SirketId and c.VRKODU = @vrkodu";

			//Thread.Sleep(3000);
			sonuc.Items = _uragacDal.GetListSqlQuery<UrunAgaciRevizyonList>(sql,
				new SqlParameter("@StokKodu", stokKodu),
				new SqlParameter("@SirketId", global.SirketId),
				new SqlParameter("@RevizyonNo", revizyonNo),
				new SqlParameter("@vrkodu", vrkodu));

			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<UrunAgaciKalemMalzemeJoin> Ncch_GetUAKalemMalzemeJoin_NLog(string uaKodu, Global global)
		{

			var sonuc = new ListResponse<UrunAgaciKalemMalzemeJoin>();
			var sql = @"SELECT 
				URAGAC.URAKOD as UrunAgaciKodu, URAGAC.STKODU as StokKodu, 
				STKART.STKNAM as StokAdi, UAKLTN.TANIMI as KalemText, 
				URAGAC.OLCUKD as OlcuBirimiKodu, 
                URAGAC.GNMKTR as Miktar, URAGAC.SBTMIK as SabitMiktar, STMALT.STMLNM as MalzemeTuruText
                FROM URAGAC 
				LEFT OUTER JOIN UAKLTN ON UAKLTN.KLMTIP = URAGAC.URKLTP and UAKLTN.SIRKID=@sirketId
				LEFT OUTER JOIN STMALT ON STMALT.STMLTR = URAGAC.STMLTR and STMALT.SIRKID=@sirketId
				LEFT OUTER JOIN STKART On STKART.STKODU = URAGAC.STKODU and STKART.SIRKID=@sirketId
                WHERE URAGAC.SIRKID=@sirketId and URAGAC.ACTIVE=1 and  URAGAC.URAKOD = @UAKodu";

			//Thread.Sleep(3000);
			sonuc.Items = _uragacDal.GetListSqlQuery<UrunAgaciKalemMalzemeJoin>(sql,
				new SqlParameter("@sirketId", global.SirketId),
				new SqlParameter("@UAKodu", uaKodu));

			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public ListResponse<UrunAgaciTreeList> Ncch_GetUrunAgaci_NLog(string urunagaciKodu, Global global)
		{
			var sonuc = new ListResponse<UrunAgaciTreeList>();
			var sql = @"Select 
				a.Id, a.PARENT as ParentId, a.CHILDD as AltId, a.GNREZV as RevizyonNo, 
                a.URAKOD as UrunAgaciKodu, a.SEVIYE as Seviye, a.SLINDI as Silme,
                a.STKODU as StokKodu, a.URYRKD as UretimYeriKodu,
                a.URKLTP as KalemTipi, a.SIRALM as Siralama, a.OLCUKD as OlcuBirimiKodu,
                a.GNMKTR as Miktar, a.SBTMIK as SabitMiktar, a.STMLTR as MalzemeTuru, 
			    a.AURKOD as AltUrunAgaciKodu,
                a.FTNKLM as FantomKalemi,a.VRKODU as VryKodu

				from dbo.URAGAC as a Where a.SIRKID=@sirketId and a.URAKOD = @UrunAgaciKodu and a.ACTIVE = 1 AND a.SLINDI = 0
               
                order by a.CHILDD";

			//Thread.Sleep(3000);
			sonuc.Items = _uragacDal.GetListSqlQuery<UrunAgaciTreeList>(sql,
				new SqlParameter("@sirketId", global.SirketId),
				new SqlParameter("@UrunAgaciKodu", urunagaciKodu)
				);

			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;
		}

		public StandardResponse<string> GetMaxUrunAgaciKodu(string stokKodu, string uaKullanim, Global global)
		{
			var sonuc = new StandardResponse<string>();
			var sql = @"SELECT MAX(UASTBG.URAKOD) AS UrunAgaciKodu FROM UASTBG WHERE UASTBG.STKODU = @StokKodu AND 
                        UASTBG.KLNKOD = @UAKullanim AND UASTBG.SIRKID = @SirketId AND UASTBG.ACTIVE = 1";

			sonuc.Nesne = _uragacDal.GetSqlQuery<string>(sql,
				new SqlParameter("@StokKodu", stokKodu),
				new SqlParameter("@UAKullanim", uaKullanim),
				new SqlParameter("@SirketId", global.SirketId)
				);

			sonuc.Status = ResponseStatusEnum.OK;
			return sonuc;

			//try
			//{
			//    command.Connection = connection;
			//    command.CommandText = @"SELECT MAX(UASTBG.URAKOD) AS UrunAgaciKodu FROM UASTBG
			//                            WHERE UASTBG.STKODU = @StokKodu AND UASTBG.KLNKOD = @UAKullanim";
			//    command.Parameters.AddWithValue("@StokKodu", stokKodu);
			//    command.Parameters.AddWithValue("@UAKullanim", uaKullanim);
			//    connection.Open();
			//    sonuc.Nesne = command.ExecuteScalar().ToString();
			//    command.Parameters.Clear();
			//    connection.Close();
			//}
			//catch (Exception ex)
			//{
			//    command.Parameters.Clear();
			//    connection.Close();
			//    sonuc.Status = ResponseStatusEnum.ERROR;
			//    sonuc.Message = ex.Message;
			//}
			//sonuc.Status = ResponseStatusEnum.OK;
			//return sonuc;
		}

		public DataTable GetAltUrunAgaci(string conStr, string uaKodu, string uaKoduField, string uaKullanim, Global global,
			bool onlyParts = true, string tableName = "vwRefakatKarti")
		{
			DataTable table = new DataTable();
			SqlConnection Connection;
			SqlDataAdapter Adapter = new SqlDataAdapter();
			SqlCommand Command = new SqlCommand();

			try
			{
				Connection = new SqlConnection(conStr);
				Command.Connection = Connection;
				Command.CommandText = "SELECT * FROM " + tableName + " WHERE " + uaKoduField + " = @uaKodu";
				if (uaKullanim == "2" && onlyParts) Command.CommandText = "SELECT * FROM " + tableName + " WHERE " + uaKoduField + " = @uaKodu AND MalzemeTuru = '103'";
				else if (uaKullanim == "2" && !onlyParts) Command.CommandText = "SELECT * FROM " + tableName + " WHERE " + uaKoduField + " = @uaKodu";
				Command.Parameters.AddWithValue("@uaKoduField", uaKoduField);
				Command.Parameters.AddWithValue("@uaKodu", uaKodu);
				Adapter.SelectCommand = Command;
				Adapter.Fill(table);
				Command.Parameters.Clear();
				return table;
			}
			catch (Exception ex)
			{
				Command.Parameters.Clear();
				return null;
			}
		}
		public DataTable GetUrunAgaciUpperLevels(string conStr, string stokKodu, string revizyonNo, string malzemeTuru, Global global)
		{
			DataTable table = new DataTable();
			SqlConnection Connection;
			SqlDataAdapter Adapter = new SqlDataAdapter();
			SqlCommand Command = new SqlCommand();

			try
			{
				Connection = new SqlConnection(conStr);
				Command.Connection = Connection;
				Command.CommandText = "SELECT TOP(1) * FROM vwRefakatKarti WHERE AltStokKodu = @StokKodu AND RevizyonNo = @RevizyonNo";
				if (malzemeTuru != "103") Command.CommandText = "SELECT TOP(1) * FROM vwRefakatKarti WHERE AltStokKodu = @StokKodu ORDER BY UrunAgaciKodu DESC";
				Command.Parameters.AddWithValue("@StokKodu", stokKodu);
				Command.Parameters.AddWithValue("@RevizyonNo", revizyonNo);
				Adapter.SelectCommand = Command;
				Adapter.Fill(table);
				Command.Parameters.Clear();
				return table;
			}
			catch (Exception ex)
			{
				Command.Parameters.Clear();
				return null;
			}
		}

		public ListResponse<UrunAgaciModulPaket> Ncch_GetUrunAgaciModulPaketList_NLog(Global global)
		{
			var sonuc = new ListResponse<UrunAgaciModulPaket>();
			try
			{
				var sql = @"SELECT        dbo.URAGAC.Id, dbo.STKART.SIRKID, dbo.UAKLTP.KLNKOD, dbo.UAKLTP.TANIMI, dbo.UASTBG.URYRKD, dbo.UASTBG.URAKOD, dbo.UASTBG.GNREZV, dbo.UASTBG.STKODU AS MDKODU, dbo.STKART.STKNAM AS MDLNAM, 
                         STNAME_1.STKNAM AS MDNMEN, dbo.URAGAC.CHILDD, STKART_1.STKODU AS PKKODU, STKART_1.STKNAM AS PKTNAM, dbo.URAGAC.GNMKTR, dbo.URAGAC.OLCUKD, ISNULL(STKART_1.BRTAGR, 0) AS BRTAGR, 
                         ISNULL(STKART_1.AGOLKD, N'') AS AGOLKD, ISNULL(STKART_1.UZUNLK, 0) AS UZUNLK, ISNULL(STKART_1.GENSLK, 0) AS GENSLK, ISNULL(STKART_1.YUKSLK, 0) AS YUKSLK, ISNULL(STKART_1.UGYBKD, N'') AS UGYBKD, 
                         ISNULL(dbo.STDEPO.USESTK, 0) AS USESTK, CASE WHEN dbo.URAGAC.CHILDD = 0 THEN ISNULL(STKART.STKIMG, '') ELSE '' END AS STKIMG, dbo.STNAME.STKNAM AS PKNMEN
                         FROM dbo.STDEPO INNER JOIN
                         dbo.URAGAC ON dbo.STDEPO.SIRKID = dbo.URAGAC.SIRKID AND dbo.STDEPO.STKODU = dbo.URAGAC.STKODU AND dbo.STDEPO.URYRKD = dbo.URAGAC.URYRKD AND dbo.STDEPO.ACTIVE = dbo.URAGAC.ACTIVE AND 
                         dbo.STDEPO.SLINDI = dbo.URAGAC.SLINDI LEFT OUTER JOIN
                         dbo.STKART AS STKART_1 LEFT OUTER JOIN
                         dbo.STNAME ON STKART_1.SIRKID = dbo.STNAME.SIRKID AND STKART_1.STKODU = dbo.STNAME.STKODU AND STKART_1.ACTIVE = dbo.STNAME.ACTIVE AND STKART_1.SLINDI = dbo.STNAME.SLINDI ON 
                         dbo.URAGAC.SIRKID = STKART_1.SIRKID AND dbo.URAGAC.STKODU = STKART_1.STKODU AND dbo.URAGAC.ACTIVE = STKART_1.ACTIVE AND dbo.URAGAC.SLINDI = STKART_1.SLINDI RIGHT OUTER JOIN
                         dbo.UAKLTP RIGHT OUTER JOIN
                         dbo.UASTBG ON dbo.UAKLTP.SIRKID = dbo.UASTBG.SIRKID AND dbo.UAKLTP.KLNKOD = dbo.UASTBG.KLNKOD LEFT OUTER JOIN
                         dbo.STKART LEFT OUTER JOIN
                         dbo.STNAME AS STNAME_1 ON dbo.STKART.SIRKID = STNAME_1.SIRKID AND dbo.STKART.STKODU = STNAME_1.STKODU AND dbo.STKART.ACTIVE = STNAME_1.ACTIVE AND dbo.STKART.SLINDI = STNAME_1.SLINDI ON 
                         dbo.UASTBG.SIRKID = dbo.STKART.SIRKID AND dbo.UASTBG.STKODU = dbo.STKART.STKODU AND dbo.UASTBG.ACTIVE = dbo.STKART.ACTIVE AND dbo.UASTBG.SLINDI = dbo.STKART.SLINDI ON 
                         dbo.URAGAC.SLINDI = dbo.UASTBG.SLINDI AND dbo.URAGAC.ACTIVE = dbo.UASTBG.ACTIVE AND dbo.URAGAC.GNREZV = dbo.UASTBG.GNREZV AND dbo.URAGAC.SIRKID = dbo.UASTBG.SIRKID AND 
                         dbo.URAGAC.URAKOD = dbo.UASTBG.URAKOD AND dbo.URAGAC.URYRKD = dbo.UASTBG.URYRKD
                         WHERE (dbo.URAGAC.Id IS NOT NULL) AND (dbo.STKART.STMLTR = '" + Param.MAMUL_KODU + "') AND (dbo.UASTBG.ACTIVE = 1) AND (dbo.UASTBG.SLINDI = 0) AND (dbo.STKART.SIRKID = @SirketId) AND (STNAME_1.LANGKD = 'EN' OR " +
						 "STNAME_1.LANGKD IS NULL) AND (dbo.STNAME.LANGKD = 'EN' OR dbo.STNAME.LANGKD IS NULL)";

				if (!Param.PAKET)
				{
					sql = @"SELECT ST.Id, ST.SIRKID, '1' AS KLNKOD, 'Üretim' AS TANIMI, '1000' AS URYRKD, '00000' AS URAKOD, '00001' AS GNREZV, ST.STKODU AS MDKODU, STKNAM AS MDLNAM, NULL AS MDNMEN, 0 AS CHILDD,
							ST.STKODU AS PKKODU, STKNAM AS PKTNAM, ISNULL(USESTK, 0) AS GNMKTR, OLCUKD, ISNULL(BRTAGR, 0) AS BRTAGR, ISNULL(AGOLKD, 0) AS AGOLKD, ISNULL(UZUNLK, 0) AS UZUNLK, ISNULL(GENSLK, 0) AS GENSLK, ISNULL(YUKSLK, 0) AS YUKSLK, UGYBKD, ISNULL(USESTK, 0) AS USESTK, STKIMG, NULL AS PKNMEN FROM STKART AS ST
							LEFT OUTER JOIN STDEPO AS DP ON ST.STKODU = DP.STKODU AND ST.SIRKID = DP.SIRKID AND DP.ACTIVE = 1
							WHERE STMLTR = '" + Param.MAMUL_KODU + "' AND ST.SIRKID = @SirketId AND ST.ACTIVE = 1 AND ST.SLINDI = 0";
				}

				sonuc.Items = _uragacDal.GetListSqlQuery<UrunAgaciModulPaket>(sql,
					new SqlParameter("@SirketId", global.SirketId));

				sonuc.Status = ResponseStatusEnum.OK;
				return sonuc;
			}
			catch (Exception e)
			{
				sonuc.Status = ResponseStatusEnum.ERROR;
				sonuc.ErrorMessage = e.Message;
				return null;
			}

		}

		public ListResponse<UrunAgaciModulPaketParca> Ncch_GetUrunAgaciModulPaketParcaList_NLog(Global global, string modulPrefix = "", string paketKodu = "", string langKd = "EN")
		{
			string modulPrefixFilter = "";
			if (modulPrefix != "") modulPrefixFilter = " AND dbo.UASTBG.STKODU LIKE '" + modulPrefix + "%'";

			string paketFilter = "";
			if (paketKodu != "") paketFilter = " AND STKART_2.STKODU = '" + paketKodu + "'";

			var sonuc = new ListResponse<UrunAgaciModulPaketParca>();
			try
			{
				var sql = @"SELECT dbo.URAGAC.Id, dbo.UASTBG.SIRKID, dbo.UASTBG.URYRKD, dbo.UASTBG.GNREZV, dbo.UASTBG.URAKOD, dbo.UASTBG.STKODU AS MDKODU, STKART_1.STKNAM AS MDNAME, STNAME_1.STKNAM AS MDYBNM, 
                         URAGAC_1.STKODU AS PKKODU, STKART_2.STKNAM AS PKNAME, STNAME_2.STKNAM AS PKYBNM, dbo.URAGAC.STKODU AS PRKODU, TRIM(REPLACE(REPLACE(dbo.STKART.STKNAM, STKART_1.STKNAM, ''), '-', '')) 
                         AS PRNAME, dbo.STNAME.STKNAM AS PRYBNM, dbo.URAGAC.GNMKTR, STKART_2.UZUNLK, STKART_2.GENSLK, STKART_2.YUKSLK, STKART_2.UGYBKD, STKART_2.BRTAGR, STKART_2.NETAGR, STKART_2.AGOLKD
                         FROM dbo.URAGAC INNER JOIN
                         dbo.UASTBG AS UASTBG_1 ON dbo.URAGAC.SIRKID = UASTBG_1.SIRKID AND dbo.URAGAC.URYRKD = UASTBG_1.URYRKD AND dbo.URAGAC.URAKOD = UASTBG_1.URAKOD AND 
                         dbo.URAGAC.GNREZV = UASTBG_1.GNREZV AND dbo.URAGAC.ACTIVE = UASTBG_1.ACTIVE AND dbo.URAGAC.SLINDI = UASTBG_1.SLINDI INNER JOIN
                         dbo.STKART ON dbo.URAGAC.SIRKID = dbo.STKART.SIRKID AND dbo.URAGAC.STKODU = dbo.STKART.STKODU AND dbo.URAGAC.ACTIVE = dbo.STKART.ACTIVE AND dbo.URAGAC.SLINDI = dbo.STKART.SLINDI LEFT OUTER JOIN
                         dbo.STNAME ON dbo.STKART.SIRKID = dbo.STNAME.SIRKID AND dbo.STKART.STKODU = dbo.STNAME.STKODU AND dbo.STKART.ACTIVE = dbo.STNAME.ACTIVE AND 
                         dbo.STKART.SLINDI = dbo.STNAME.SLINDI LEFT OUTER JOIN
                         dbo.STNAME AS STNAME_2 RIGHT OUTER JOIN
                         dbo.STKART AS STKART_2 ON STNAME_2.SIRKID = STKART_2.SIRKID AND STNAME_2.STKODU = STKART_2.STKODU AND STNAME_2.ACTIVE = STKART_2.ACTIVE AND STNAME_2.SLINDI = STKART_2.SLINDI ON 
                         UASTBG_1.SIRKID = STKART_2.SIRKID AND UASTBG_1.STKODU = STKART_2.STKODU AND UASTBG_1.ACTIVE = STKART_2.ACTIVE AND UASTBG_1.SLINDI = STKART_2.SLINDI RIGHT OUTER JOIN
                         dbo.URAGAC AS URAGAC_1 RIGHT OUTER JOIN
                         dbo.UASTBG LEFT OUTER JOIN
                         dbo.STNAME AS STNAME_1 RIGHT OUTER JOIN
                         dbo.STKART AS STKART_1 ON STNAME_1.SIRKID = STKART_1.SIRKID AND STNAME_1.STKODU = STKART_1.STKODU AND STNAME_1.ACTIVE = STKART_1.ACTIVE AND STNAME_1.SLINDI = STKART_1.SLINDI ON 
                         dbo.UASTBG.SIRKID = STKART_1.SIRKID AND dbo.UASTBG.STKODU = STKART_1.STKODU AND dbo.UASTBG.ACTIVE = STKART_1.ACTIVE AND dbo.UASTBG.SLINDI = STKART_1.SLINDI ON 
                         URAGAC_1.URAKOD = dbo.UASTBG.URAKOD AND URAGAC_1.URYRKD = dbo.UASTBG.URYRKD AND URAGAC_1.SIRKID = dbo.UASTBG.SIRKID AND URAGAC_1.GNREZV = dbo.UASTBG.GNREZV AND 
                         URAGAC_1.ACTIVE = dbo.UASTBG.ACTIVE AND URAGAC_1.SLINDI = dbo.UASTBG.SLINDI ON UASTBG_1.SIRKID = URAGAC_1.SIRKID AND UASTBG_1.STKODU = URAGAC_1.STKODU AND 
                         UASTBG_1.URYRKD = URAGAC_1.URYRKD AND UASTBG_1.GNREZV = URAGAC_1.GNREZV AND UASTBG_1.ACTIVE = URAGAC_1.ACTIVE AND UASTBG_1.SLINDI = URAGAC_1.SLINDI" +
						 " WHERE STKART_2.ACTIVE = 1 AND dbo.UASTBG.SIRKID = @SirketId " + modulPrefixFilter + paketFilter + " " +
						 "AND (STNAME.LANGKD IS NULL OR STNAME.LANGKD = @LangKd) " +
						 //"AND (STNAME_1.LANGKD IS NULL OR STNAME_1.LANGKD = @LangKd) " +
						 //"AND (STNAME_2.LANGKD IS NULL OR STNAME_2.LANGKD = @LangKd) " +
						 "AND (STKART.STMLTR = '" + Param.MAMUL_KODU + "' OR STKART.STMLTR = '002' OR STKART.STMLTR = '003')" +
						 "ORDER BY dbo.UASTBG.STKODU, URAGAC_1.STKODU, dbo.URAGAC.STKODU";

				sonuc.Items = _uragacDal.GetListSqlQuery<UrunAgaciModulPaketParca>(sql,
					new SqlParameter("@SirketId", global.SirketId), new SqlParameter("@LangKd", langKd));

				sonuc.Status = ResponseStatusEnum.OK;
				return sonuc;
			}
			catch (Exception e)
			{
				sonuc.Status = ResponseStatusEnum.ERROR;
				sonuc.ErrorMessage = e.Message;
				return null;
			}

		}

		public ListResponse<UrunAgaciUst> Ncch_GetUrunAgaciUst_NLog(Global global, string stkodu, string langKd = "EN")
		{
			var sonuc = new ListResponse<UrunAgaciUst>();
			try
			{
				var sql = @"SELECT dbo.UASTBG.Id, dbo.UASTBG.SIRKID, dbo.URAGAC.STKODU, dbo.UASTBG.STKODU AS USKODU, dbo.STKART.STKNAM AS USNAME, dbo.STNAME.STKNAM AS USYBNM, dbo.STNAME.LANGKD, dbo.UASTBG.URYRKD, 
                         dbo.UASTBG.KLNKOD, dbo.UASTBG.URAKOD, dbo.UASTBG.ALTERN, dbo.UASTBG.GNREZV, dbo.ISREVZ.TANIMI, dbo.ISREVZ.BASTAR, dbo.ISREVZ.BITTAR, dbo.ISREVZ.URTONY
                         FROM dbo.STNAME RIGHT OUTER JOIN
                         dbo.STKART ON dbo.STNAME.SIRKID = dbo.STKART.SIRKID AND dbo.STNAME.STKODU = dbo.STKART.STKODU AND dbo.STNAME.ACTIVE = dbo.STKART.ACTIVE AND 
                         dbo.STNAME.SLINDI = dbo.STKART.SLINDI RIGHT OUTER JOIN
                         dbo.URAGAC INNER JOIN
                         dbo.UASTBG ON dbo.URAGAC.SIRKID = dbo.UASTBG.SIRKID AND dbo.URAGAC.GNREZV = dbo.UASTBG.GNREZV AND dbo.URAGAC.URAKOD = dbo.UASTBG.URAKOD AND dbo.URAGAC.URYRKD = dbo.UASTBG.URYRKD AND 
                         dbo.URAGAC.ACTIVE = dbo.UASTBG.ACTIVE AND dbo.URAGAC.SLINDI = dbo.UASTBG.SLINDI INNER JOIN
                         dbo.ISREVZ ON dbo.UASTBG.SIRKID = dbo.ISREVZ.SIRKID AND dbo.UASTBG.GNREZV = dbo.ISREVZ.GNREZV AND dbo.UASTBG.ACTIVE = dbo.ISREVZ.ACTIVE AND dbo.UASTBG.SLINDI = dbo.ISREVZ.SLINDI ON 
                         dbo.STKART.SIRKID = dbo.UASTBG.SIRKID AND dbo.STKART.STKODU = dbo.UASTBG.STKODU AND dbo.STKART.ACTIVE = dbo.UASTBG.ACTIVE AND dbo.STKART.SLINDI = dbo.UASTBG.SLINDI" +
								" WHERE URAGAC.ACTIVE = 1 AND dbo.URAGAC.SIRKID = @SirketId AND dbo.URAGAC.STKODU = @StokKodu AND (STNAME.LANGKD IS NULL OR STNAME.LANGKD = @LangKd) ORDER BY dbo.ISREVZ.BASTAR DESC";

				sonuc.Items = _uragacDal.GetListSqlQuery<UrunAgaciUst>(sql,
					new SqlParameter("@SirketId", global.SirketId), new SqlParameter("@StokKodu", stkodu), new SqlParameter("@LangKd", langKd));

				sonuc.Status = ResponseStatusEnum.OK;
				return sonuc;
			}
			catch (Exception e)
			{
				sonuc.Status = ResponseStatusEnum.ERROR;
				sonuc.ErrorMessage = e.Message;
				return null;
			}

		}

		public ListResponse<UrunAgaciRota> Ncch_GetUrunAgaciRota_NLog(Global global, List<string> stokList = null)
		{
			var sonuc = new ListResponse<UrunAgaciRota>();
			try
			{
				string whereFilter = "";
				if (stokList != null && stokList.Count > 0)
				{
					whereFilter = "WHERE ";
					for (int i = 0; i < stokList.Count; i++)
					{
						string end = "' OR ";
						if (i == stokList.Count - 1) end = "' ";
						whereFilter += ("dbo.UASTBG.STKODU = '" + stokList[i] + end);
					}
				}

				var sql = @"SELECT dbo.URAGAC.Id, dbo.UASTBG.SIRKID, dbo.UASTBG.URYRKD, dbo.UASTBG.KLNKOD, dbo.UASTBG.URAKOD, dbo.UASTBG.GNREZV, 
						dbo.ISREVZ.TANIMI AS RVZTNM, dbo.UASTBG.STKODU, dbo.STKART.STKNAM, dbo.URAGAC.SEVIYE, dbo.URAGAC.URKLTP, 
						dbo.URAGAC.AURKOD, dbo.URAGAC.STKKLM, dbo.URAGAC.MTNKLM, dbo.URAGAC.FTNKLM, dbo.URAGAC.STMLTR, dbo.URAGAC.STKODU AS PRKODU, 
						STKART_1.STKNAM AS PRCNAM, dbo.URAGAC.GNMKTR, dbo.URAGAC.OLCUKD, dbo.UASTRT.SIRANO, dbo.UASTRT.ISOPKD, dbo.GNTHRK.TANIMI
						FROM dbo.URAGAC INNER JOIN
						dbo.UASTBG ON dbo.URAGAC.SIRKID = dbo.UASTBG.SIRKID AND dbo.URAGAC.URYRKD = dbo.UASTBG.URYRKD AND dbo.URAGAC.URAKOD = dbo.UASTBG.URAKOD AND 
						dbo.URAGAC.GNREZV = dbo.UASTBG.GNREZV INNER JOIN
						dbo.UASTRT ON dbo.URAGAC.Id = dbo.UASTRT.URAGID AND dbo.URAGAC.SIRKID = dbo.UASTRT.SIRKID INNER JOIN
						dbo.STKART ON dbo.UASTBG.STKODU = dbo.STKART.STKODU AND dbo.UASTBG.SIRKID = dbo.STKART.SIRKID INNER JOIN
						dbo.STKART AS STKART_1 ON dbo.URAGAC.SIRKID = STKART_1.SIRKID AND dbo.URAGAC.STKODU = STKART_1.STKODU INNER JOIN
						dbo.GNTHRK ON dbo.UASTRT.ISOPKD = dbo.GNTHRK.HARKOD AND dbo.UASTRT.SIRKID = dbo.GNTHRK.SIRKID INNER JOIN
						dbo.GNTIPI ON dbo.GNTHRK.SIRKID = dbo.GNTIPI.SIRKID AND dbo.GNTHRK.TIPKOD = dbo.GNTIPI.TIPKOD AND dbo.GNTIPI.TEKNAD = 'ISOPKD' INNER JOIN
						dbo.ISREVZ ON dbo.UASTBG.SIRKID = dbo.ISREVZ.SIRKID AND dbo.UASTBG.GNREZV = dbo.ISREVZ.GNREZV
						AND dbo.UASTBG.SIRKID = @SirketId AND dbo.STKART.ACTIVE = 1 AND dbo.UASTBG.ACTIVE = 1 AND 
						dbo.URAGAC.ACTIVE = 1 AND dbo.UASTRT.ACTIVE = 1 AND dbo.ISREVZ.URTONY = 1 AND dbo.ISREVZ.ACTIVE = 1 " 
				          + whereFilter +
						"ORDER BY dbo.UASTBG.URAKOD, PRKODU, dbo.UASTRT.SIRANO";

				sonuc.Items = _uragacDal.GetListSqlQuery<UrunAgaciRota>(sql, new SqlParameter("@SirketId", global.SirketId));
				sonuc.Status = ResponseStatusEnum.OK;
				return sonuc;
			}
			catch (Exception e)
			{
				sonuc.Status = ResponseStatusEnum.ERROR;
				sonuc.ErrorMessage = e.Message;
				return null;
			}

		}



		public ListResponse<UrunAgaciList> Ncch_GetUrunAgaciList_NLog(Global global)
		{
			var sonuc = new ListResponse<UrunAgaciList>();
			try
			{
				var sql = @"WITH EnGuncelUrunAgaciBasligi AS (
    SELECT
        SIRKID,
        STKODU,
        VRKODU,
        URAKOD,
        GNREZV,
        ACTIVE,
        -- Her bir STKODU (ana ürün) grubu içinde, GNREZV'yi büyükten küçüğe sırala
        -- ve en üsttekine 1 numarasını ver.
        ROW_NUMBER() OVER(PARTITION BY STKODU ORDER BY GNREZV DESC) AS RevizyonSiraNo
    FROM
        [dbo].[UASTBG]
),

-- 2. ADIM: En güncel revizyonları kullanarak ürün ağacı hiyerarşisini hesapla.
UrunAgaciHiyerarsisi AS (
    -- Anchor Member: Rekürsiyonun başlangıç noktası
    SELECT
        H.SIRKID,       -- SIRKID eklendi
        H.STKODU        AS AnaUrunKodu,
        H.VRKODU        AS AnaUrunVaryanti,
        H.URAKOD        AS UrunAgaciKodu,
        H.GNREZV        AS RevizyonNo,
        1               AS Seviye,
        D.Id            AS ChildId,
        D.STKODU        AS MalzemeKodu,
        D.VRKODU        AS MalzemeVaryanti,
        D.GNMKTR        AS BilesenMiktari,
        CAST(D.GNMKTR AS DECIMAL(38, 6)) AS KümülatifMiktar,
        D.OLCUKD        AS Birim
    FROM
        -- KAYNAK OLARAK UASTBG YERİNE, FİLTRELENMİŞ CTE'Yİ KULLANIYORUZ
        EnGuncelUrunAgaciBasligi AS H
    INNER JOIN
        [dbo].[URAGAC] AS D ON H.SIRKID = D.SIRKID AND H.URAKOD = D.URAKOD
    WHERE
      
      
        H.ACTIVE = 1 AND D.ACTIVE = 1

    UNION ALL

    -- Recursive Member: Kendini tekrar eden kısım
    SELECT
        R.SIRKID,       -- SIRKID eklendi
        R.AnaUrunKodu,
        R.AnaUrunVaryanti,
        R.UrunAgaciKodu,
        R.RevizyonNo,
        R.Seviye + 1    AS Seviye,
        D.Id            AS ChildId,
        D.STKODU        AS MalzemeKodu,
        D.VRKODU        AS MalzemeVaryanti,
        D.GNMKTR        AS BilesenMiktari,
        (R.KümülatifMiktar * D.GNMKTR) AS KümülatifMiktar,
        D.OLCUKD        AS Birim
    FROM
        [dbo].[URAGAC] AS D
    INNER JOIN
        UrunAgaciHiyerarsisi AS R ON D.PARENT = R.ChildId AND D.URAKOD = R.UrunAgaciKodu
    WHERE
        D.ACTIVE = 1
)
-- 3. ADIM: Nihai sonuçları CTE'den seçerek göster.
SELECT
    SIRKID,             -- SIRKID eklendi
    AnaUrunKodu,
    RevizyonNo,
    AnaUrunVaryanti,
    MalzemeKodu,
    MalzemeVaryanti,
    Birim,
    Seviye,
    BilesenMiktari,
    KümülatifMiktar
FROM
    UrunAgaciHiyerarsisi
	WHERE SIRKID =@SirketId
-- Belirli bir ana ürüne ait malzeme listesini görmek için aşağıdaki WHERE satırını aktifleştirin
-- WHERE AnaUrunKodu = 'İLGİLİ_ÜRÜNÜN_KODUNU_BURAYA_YAZIN'

ORDER BY
    SIRKID,             -- SIRKID eklendi
    AnaUrunKodu,
    Seviye,
    MalzemeKodu
OPTION (MAXRECURSION 0);";

				sonuc.Items = _uragacDal.GetListSqlQuery<UrunAgaciList>(sql,
					new SqlParameter("@SirketId", global.SirketId));

				sonuc.Status = ResponseStatusEnum.OK;
				return sonuc;
			}
			catch (Exception e)
			{
				sonuc.Status = ResponseStatusEnum.ERROR;
				sonuc.ErrorMessage = e.Message;
				return null;
			}

		}

		#endregion ClientFunc
	}
}
