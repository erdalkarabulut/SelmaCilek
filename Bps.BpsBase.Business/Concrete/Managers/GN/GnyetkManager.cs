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

using System.Collections.Generic;
using System.Data.SqlClient;
using Bps.Core.Web.Model;
using Bps.BpsBase.Entities.Models.GN.Listed;
using Bps.BpsBase.Entities.Models.GN.Enums;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GnyetkManager : IGnyetkService
    {
        private IGnyetkDal _gnyetkDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GnyetkManager(IGnyetkDal gnyetkDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnyetkDal = gnyetkDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNYETK> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNYETK>();
            sonuc.Items = global.SirketId != null ? _gnyetkDal.GetList(x => x.SIRKID == global.SirketId) : _gnyetkDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNYETK> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNYETK>();
            sonuc.Items = global.SirketId != null ? _gnyetkDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnyetkDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNYETK> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNYETK>();
            sonuc.Items = global.SirketId != null ? _gnyetkDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnyetkDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNYETK> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNYETK>();
            sonuc.Items = global.SirketId != null ? _gnyetkDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnyetkDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNYETK> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNYETK>();
            sonuc.Items = global.SirketId != null ? _gnyetkDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnyetkDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNYETK> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNYETK>();
            sonuc.Nesne = _gnyetkDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNYETK> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNYETK", id, global);
            var sonuc = new StandardResponse<GNYETK>();
            sonuc.Nesne = _gnyetkDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnyetkValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNYETK> Ncch_Add_NLog(GNYETK gnyetk, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNYETK>();
            gnyetk.SIRKID = global.SirketId.Value; 
            gnyetk.EKKULL = global.UserKod;
            gnyetk.ETARIH = DateTime.Now;
            gnyetk.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnyetkDal.Add(gnyetk);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnyetkValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNYETK> Ncch_Update_Log(GNYETK gnyetk,GNYETK oldGnyetk, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNYETK", gnyetk.Id, global);
            var sonuc = new StandardResponse<GNYETK>();
            gnyetk.SIRKID = global.SirketId.Value; 
            gnyetk.DEKULL = global.UserKod;
            gnyetk.DTARIH = DateTime.Now;
            gnyetk.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnyetkDal.Update(gnyetk);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnyetkValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNYETK> Ncch_UpdateAktifPasif_Log(GNYETK gnyetk, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNYETK>();
            gnyetk.SIRKID = global.SirketId.Value; 
            gnyetk.ACTIVE = !gnyetk.ACTIVE;
            gnyetk.DEKULL = global.UserKod;
            gnyetk.DTARIH = DateTime.Now;
            gnyetk.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnyetkDal.Update(gnyetk);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnyetkValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNYETK> Ncch_Delete_Log(GNYETK gnyetk, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNYETK", gnyetk.Id, global);
            var sonuc = new StandardResponse<GNYETK>();
            gnyetk.SIRKID = global.SirketId.Value; 
            gnyetk.ACTIVE = false;
            gnyetk.SLINDI = true;
            gnyetk.DEKULL = global.UserKod;
            gnyetk.DTARIH = DateTime.Now;
            gnyetk.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnyetkDal.Update(gnyetk);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<ProjeMenuListed> Cch_GetProjeMenuYetkiList_NLog(Global global, string projeKod, string kulkod)
        {
            var sonuc = new ListResponse<ProjeMenuListed> { Items = new List<ProjeMenuListed>() };

            var sql = @"select  

                    y.Id,m.FUNCNM,m.CONTNM,m.GNAREA,
                    m.PROKOD,m.MNUNAM,m.MNUTAG,m.PARENT,m.GNICON,m.SIRASI,m.FORNM,
                    (select MNUNAM from GNMENU where MNUTAG=m.PARENT and PROKOD=@projeKod and SIRKID=@sirketId) as PARENTNAME,
                    y.CSVGOS,y.GRNTLM,y.EKLEME,y.DEGIST,y.KAYDET,y.SILMEK,
                    y.YAZDIR,y.CSVGOS,y.XMLGOS,y.DOCGOS,y.EXCGOS,y.PDFGOS,y.GNONAY,y.KOPYAL
                    from GNYETK as y 
                    left join GNMENU  as m on y.MNUTAG=m.MNUTAG and m.PROKOD=@projeKod
                    where y.PROKOD=@projeKod and y.KULKOD=@kulKod
                    and y.ACTIVE=1 and y.SLINDI=0 and y.SIRKID=@sirketId and m.SIRKID=@sirketId and m.ACTIVE=1 and m.SLINDI=0
                    order by m.SIRASI";
            sonuc.Items = _gnyetkDal.GetListSqlQuery<ProjeMenuListed>(sql,
                new SqlParameter("projeKod", projeKod),
                new SqlParameter("kulKod", kulkod),
                new SqlParameter("sirketId", global.SirketId));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<ProjeMenuListed> Cch_GetProjeMenuYetki_NLog(Global global, string kulkod)
        {
            var sonuc = new StandardResponse<ProjeMenuListed>();
            var sql = @"select  
                    y.Id,m.FUNCNM,m.CONTNM,m.GNAREA,
                    m.PROKOD,m.MNUNAM,m.MNUTAG,m.PARENT,m.GNICON,m.SIRASI,m.FORNM,
                    (select MNUNAM from GNMENU where MNUTAG=m.PARENT and PROKOD=@projeKod and SIRKID=@sirketId) as PARENTNAME,
                    y.CSVGOS,y.GRNTLM,y.EKLEME,y.DEGIST,y.KAYDET,y.SILMEK,
                    y.YAZDIR,y.CSVGOS,y.XMLGOS,y.DOCGOS,y.EXCGOS,y.PDFGOS,y.GNONAY,y.KOPYAL
                    from GNYETK as y 
                    left join GNMENU  as m on y.MNUTAG=m.MNUTAG and m.PROKOD=@projeKod
                    where y.PROKOD=@projeKod and y.KULKOD=@kulKod and y.MNUTAG=@menuTag
                    and y.ACTIVE=1 and y.SLINDI=0 and y.SIRKID=@sirketId and m.SIRKID=@sirketId and m.ACTIVE=1 and m.SLINDI=0
                    order by m.SIRASI";
            sonuc.Nesne = _gnyetkDal.GetSqlQuery<ProjeMenuListed>(sql,
                new SqlParameter("projeKod", global.ProjeKod),
                new SqlParameter("kulKod", global.UserKod),
                new SqlParameter("menuTag", global.MenuTag),
                new SqlParameter("sirketId", global.SirketId));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<ProjeMenuListed> Ncch_GetProjeMenuYetki_NLog(Global global, string kulkod)
        {
            var sonuc = new StandardResponse<ProjeMenuListed>();
            var sql = @"select  
                    y.Id,m.FUNCNM,m.CONTNM,m.GNAREA,
                    m.PROKOD,m.MNUNAM,m.MNUTAG,m.PARENT,m.GNICON,m.SIRASI,m.FORNM,
                    (select MNUNAM from GNMENU where MNUTAG=m.PARENT and PROKOD=@projeKod and SIRKID=@sirketId) as PARENTNAME,
                    y.CSVGOS,y.GRNTLM,y.EKLEME,y.DEGIST,y.KAYDET,y.SILMEK,
                    y.YAZDIR,y.CSVGOS,y.XMLGOS,y.DOCGOS,y.EXCGOS,y.PDFGOS,y.GNONAY,y.KOPYAL
                    from GNYETK as y 
                    left join GNMENU  as m on y.MNUTAG=m.MNUTAG and m.PROKOD=@projeKod
                    where y.PROKOD=@projeKod and y.KULKOD=@kulKod and y.MNUTAG=@menuTag
                    and y.ACTIVE=1 and y.SLINDI=0 and y.SIRKID=@sirketId and m.SIRKID=@sirketId and m.ACTIVE=1 and m.SLINDI=0
                    order by m.SIRASI";
            sonuc.Nesne = _gnyetkDal.GetSqlQuery<ProjeMenuListed>(sql,
                new SqlParameter("projeKod", global.ProjeKod),
                new SqlParameter("kulKod", global.UserKod),
                new SqlParameter("menuTag", global.MenuTag),
                new SqlParameter("sirketId", global.SirketId));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNYETK> Ncch_GetListByFilter_NLog(Global global, string kulkod, string prokod,
            bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNYETK>();
            var wherStr = "";
            if (!string.IsNullOrEmpty(prokod)) wherStr += " and y.PROKOD='" + prokod + "' ";
            //var sql = @"select * from GNYETK as y where y.SIRKID=@sirketId and y.SLINDI=0 and y.ACTIVE=1 and y.KULKOD=@kulKod " + wherStr + "  order by y.MNUTAG";

            var sql = @"select  y.Id, y.SIRKID, KULKOD, PROKOD, MNUNAM, MNUTAG, EKLEME, DEGIST, KAYDET, SILMEK, GRNTLM, KOPYAL,
                        PDFGOS, EXCGOS, YAZDIR, CSVGOS, XMLGOS, DOCGOS, GNONAY, y.ACTIVE, y.SLINDI, y.EKKULL, y.ETARIH, y.DEKULL, y.DTARIH, y.KYNKKD, y.CHKCTR, y.TIMSTM
                        from GNYETK as y INNER JOIN GNTHRK as g ON y.PROKOD = g.HARKOD INNER JOIN GNTIPI AS t on g.SIRKID = t.SIRKID and t.TIPKOD =g.TIPKOD
						where t.TIPKOD = '018' and  y.SIRKID=@sirketId and y.SLINDI=0 and y.ACTIVE=1 and g.ACTIVE = 1 and y.KULKOD=@kulKod " + wherStr + "   order by y.MNUTAG";
            sonuc.Items = _gnyetkDal.GetListSqlQuery<GNYETK>(sql,
                new SqlParameter("sirketId", global.SirketId),
                new SqlParameter("kulKod", kulkod));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse Cch_ProjeYetkiKontrol_NLog(Global global, string projeKod, string kulkod)
        {
            var sonuc = new StandardResponse();
            if (string.IsNullOrEmpty(kulkod) || global.SirketId == null || string.IsNullOrEmpty(projeKod))
            {
                sonuc.Message = "Gerekli bilgiler okunamadi!";
                sonuc.Status = ResponseStatusEnum.ERROR;
                return sonuc;
            }
            var sql = @"select (CASE WHEN count(*)>0 THEN 1 ELSE 0 END) as YetkiVar
		                from GNYETK as y
		                left join GNMENU as m on m.MNUTAG=y.MNUTAG and m.PROKOD=y.PROKOD
		                where y.KULKOD=@kulkod and y.GRNTLM=1 and m.PARENT=0 and y.PROKOD=@prokod 
                        and y.SIRKID=@sirketId and y.ACTIVE=1 and y.SLINDI=0 and m.ACTIVE=1 and y.SLINDI=0";

            var data = _gnyetkDal.GetSqlQuery<int>(sql,
                new SqlParameter("kulkod", kulkod),
                new SqlParameter("prokod", projeKod ?? ""),
                new SqlParameter("sirketId", global.SirketId));

            if (data == 1) sonuc.Status = ResponseStatusEnum.OK;
            else
            {
                sonuc.Message = "Yetkiniz yok!";
                sonuc.Status = ResponseStatusEnum.ERROR;
            }
            return sonuc;
        }

        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNYETK> Ncch_AddMulti_NLog(List<GNYETK> gnyetks, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNYETK>();
            _gnyetkDal.MultiAdd(gnyetks);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<ProjelerYetkiModel> Ncch_GetProjelerYetkiList_NLog(Global global)
        {
            var sonuc = new ListResponse<ProjelerYetkiModel>();
            var sql = @"SELECT MENU.SIRKID, MENU.KULKOD, MENU.PROKOD, MENU.MNUNAM, MENU.MNUTAG, GNYETK.Id FROM 
                        (SELECT dbo.GNKULL.SIRKID, dbo.GNKULL.KULKOD, dbo.GNMENU.PROKOD, dbo.GNMENU.MNUNAM, dbo.GNMENU.MNUTAG
                        FROM dbo.GNMENU CROSS JOIN dbo.GNKULL WHERE dbo.GNKULL.ACTIVE = 1 AND dbo.GNMENU.ACTIVE = 1) AS MENU 
                        LEFT OUTER JOIN GNYETK ON MENU.SIRKID = GNYETK.SIRKID AND MENU.KULKOD = GNYETK.KULKOD 
                        AND MENU.PROKOD = GNYETK.PROKOD AND MENU.MNUTAG = GNYETK.MNUTAG AND MENU.MNUNAM = GNYETK.MNUNAM 
                        WHERE GNYETK.Id IS NULL AND MENU.SIRKID = @SirketId";
            sonuc.Items = _gnyetkDal.GetListSqlQuery<ProjelerYetkiModel>(sql,
                new SqlParameter("SirketId", global.SirketId));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<KullaniciYetkiModel> Ncch_GetKullaniciYetkiList_NLog(Global global, string kulkod, MenuPlatform menuPlatform)
        {
            var sonuc = new ListResponse<KullaniciYetkiModel>();
            var sql = @"SELECT YT.Id, YT.SIRKID, YT.KULKOD, YT.PROKOD, PR.TANIMI, YT.MNUNAM, YT.MNUTAG, MN.PARENT, YT.EKLEME, YT.DEGIST, 
                        YT.KAYDET, YT.SILMEK, YT.GRNTLM, YT.PDFGOS, YT.EXCGOS, YT.YAZDIR, YT.CSVGOS, YT.XMLGOS, YT.DOCGOS, YT.GNONAY,YT.KOPYAL
                        FROM GNYETK AS YT INNER JOIN GNMENU AS MN ON YT.PROKOD = MN.PROKOD AND YT.MNUTAG = MN.MNUTAG AND YT.SIRKID = MN.SIRKID
                        INNER JOIN (SELECT SIRKID, HARKOD, TANIMI, SIRASI FROM GNTHRK WHERE TIPKOD = '018' AND ACTIVE = 1 AND SIRKID = @SirketId) AS PR ON YT.PROKOD = PR.HARKOD
                        WHERE YT.ACTIVE = 1 AND MN.ACTIVE = 1 AND YT.SIRKID = @SirketId AND YT.KULKOD = @Kulkod AND (MN.PLTFRM = 0 OR MN.PLTFRM = @MenuPlatform)
                        ORDER BY YT.KULKOD, PR.SIRASI, YT.MNUTAG";
            sonuc.Items = _gnyetkDal.GetListSqlQuery<KullaniciYetkiModel>(sql,
                new SqlParameter("SirketId", global.SirketId), new SqlParameter("Kulkod", kulkod), new SqlParameter("MenuPlatform", menuPlatform));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnyetbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse Ncch_MultiDelete_Log(List<GNYETK> gnyetk, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            //_lockedService.LockControlWrite("GNYETB", gnyetb.Id, global);
            var sonuc = new StandardResponse();


            bool _ok = _gnyetkDal.MultiDelete(gnyetk);
            if (_ok)
            {
                sonuc.Status = ResponseStatusEnum.OK;
            }
            else
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
            }

            return sonuc;
        }

        [FluentValidationAspect(typeof(GnyetbValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse Ncch_MultiAdd_Log(List<GNYETK> gnyetk, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            //_lockedService.LockControlWrite("GNYETB", gnyetb.Id, global);
            var sonuc = new StandardResponse();
            foreach (var item in gnyetk)
            {
                item.EKKULL = global.UserKod;
                item.ETARIH = DateTime.Now;
                item.KYNKKD = global.KaynakKod;
                item.ACTIVE = true;
            }

            bool _ok = _gnyetkDal.MultiAdd(gnyetk);
            if (_ok)
            {
                sonuc.Status = ResponseStatusEnum.OK;
            }
            else
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
            }

            return sonuc;
        }

        #endregion ClientFunc
    }
}
