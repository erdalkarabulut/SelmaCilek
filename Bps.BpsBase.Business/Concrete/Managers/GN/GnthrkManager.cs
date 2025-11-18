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
using Bps.BpsBase.Entities.Models.GN.Listed;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GnthrkManager : IGnthrkService
    {
        private IGnthrkDal _gnthrkDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GnthrkManager(IGnthrkDal gnthrkDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnthrkDal = gnthrkDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNTHRK> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNTHRK>();
            sonuc.Items = global.SirketId != null ? _gnthrkDal.GetList(x => x.SIRKID == global.SirketId) : _gnthrkDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNTHRK> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNTHRK>();
            sonuc.Items = global.SirketId != null ? _gnthrkDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnthrkDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNTHRK> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNTHRK>();
            sonuc.Items = global.SirketId != null ? _gnthrkDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnthrkDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNTHRK> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNTHRK>();
            sonuc.Items = global.SirketId != null ? _gnthrkDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnthrkDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNTHRK> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNTHRK>();
            sonuc.Items = global.SirketId != null ? _gnthrkDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnthrkDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNTHRK> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNTHRK>();
            sonuc.Nesne = _gnthrkDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNTHRK> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNTHRK", id, global);
            var sonuc = new StandardResponse<GNTHRK>();
            sonuc.Nesne = _gnthrkDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnthrkValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNTHRK> Ncch_Add_NLog(GNTHRK gnthrk, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNTHRK>();
            gnthrk.SIRKID = global.SirketId.Value; 
            gnthrk.EKKULL = global.UserKod;
            gnthrk.ETARIH = DateTime.Now;
            gnthrk.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnthrkDal.Add(gnthrk);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnthrkValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNTHRK> Ncch_Update_Log(GNTHRK gnthrk,GNTHRK oldGnthrk, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNTHRK", gnthrk.Id, global);
            var sonuc = new StandardResponse<GNTHRK>();
            gnthrk.SIRKID = global.SirketId.Value; 
            gnthrk.DEKULL = global.UserKod;
            gnthrk.DTARIH = DateTime.Now;
            gnthrk.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnthrkDal.Update(gnthrk);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnthrkValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNTHRK> Ncch_UpdateAktifPasif_Log(GNTHRK gnthrk, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNTHRK>();
            gnthrk.SIRKID = global.SirketId.Value; 
            gnthrk.ACTIVE = !gnthrk.ACTIVE;
            gnthrk.DEKULL = global.UserKod;
            gnthrk.DTARIH = DateTime.Now;
            gnthrk.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnthrkDal.Update(gnthrk);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnthrkValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNTHRK> Ncch_Delete_Log(GNTHRK gnthrk, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNTHRK", gnthrk.Id, global);
            var sonuc = new StandardResponse<GNTHRK>();
            gnthrk.SIRKID = global.SirketId.Value; 
            gnthrk.ACTIVE = false;
            gnthrk.SLINDI = true;
            gnthrk.DEKULL = global.UserKod;
            gnthrk.DTARIH = DateTime.Now;
            gnthrk.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnthrkDal.Update(gnthrk);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public StandardResponse<GNTHRK> Cch_GetByTipAndHarKod(Global global, string tipKod, string harKod, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNTHRK>();
            sonuc.Nesne = _gnthrkDal.Get(x =>
                x.SIRKID == global.SirketId && x.ACTIVE && x.TIPKOD == tipKod && x.HARKOD == harKod && x.LANGKD == global.DilKod);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNTHRK> Cch_GetListByTipKod(Global global, string tipKod, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNTHRK>();
            sonuc.Items = global.SirketId != null ? _gnthrkDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE && x.TIPKOD == tipKod && x.LANGKD == global.DilKod) : _gnthrkDal.GetList(x => x.ACTIVE && x.TIPKOD == tipKod && x.LANGKD == global.DilKod);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNTHRK> Cch_GetListByTeknad(Global global, string teknad, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNTHRK>();
            var sql = @"select 
	                     th.*, t.TIPADI, t.TEKNAD
		                 from GNTHRK as th
		                 left join GNTIPI as t on t.TIPKOD=th.TIPKOD
		                 where th.SIRKID=@sirketId and t.SIRKID=@sirketId 
                         and th.ACTIVE=1 and th.SLINDI=0 
                         and t.ACTIVE=1 and t.SLINDI=0
		                 and t.TEKNAD=@teknad and th.LANGKD = @dilkod";

            sonuc.Items = _gnthrkDal.GetListSqlQuery<GNTHRK>(sql,
                new SqlParameter("sirketId", global.SirketId),
                new SqlParameter("dilkod", global.DilKod),
                new SqlParameter("teknad", teknad));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNTHRK> Cch_GetAltTipByTipKodAndHarKod(Global global, string tipKod, string harKod, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNTHRK>();
            sonuc.Nesne = _gnthrkDal.Get(x =>
                x.SIRKID == global.SirketId && x.ACTIVE && x.TIPKOD == tipKod && x.HARKOD == harKod && x.LANGKD == global.DilKod);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TipHareketListModel> Cch_TipHareketListGetir(Global global, string tipKod, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }

            var sonuc = new ListResponse<TipHareketListModel> { Items = new List<TipHareketListModel>() };
            var whereStr = "and th.TIPKOD=''";
            if (!string.IsNullOrEmpty(tipKod))
            {
                whereStr = " and th.TIPKOD='" + tipKod + "'";
            }
            var sql = @"select 
	                        th.Id,th.SIRKID,th.TIPKOD,t.TIPADI, th.HARKOD,th.SIRASI,th.TANIMI,th.ACTIVE,th.EKKULL,th.ETARIH,th.DEKULL,th.DTARIH,t.UTPKOD,th.EXTRA1,
	                        (select TANIMI from GNTHRK as th2 where th2.Id=th.PARENT) as ParentName,th.PARENT,t.TEKNAD
	                        from GNTHRK as th
	                        left join GNTIPI as t on t.TIPKOD=th.TIPKOD
                            where th.SIRKID=@sirketId and th.LANGKD =@dilkod and th.ACTIVE=1 and th.SLINDI=0 and t.SIRKID=@sirketId and t.ACTIVE=1 and t.SLINDI=0 " + whereStr + " order by th.TIPKOD, th.SIRASI";

            sonuc.Items = _gnthrkDal.GetListSqlQuery<TipHareketListModel>(sql, new SqlParameter("sirketId", global.SirketId), new SqlParameter("dilkod", global.DilKod));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TipHareketListModel> Cch_TipHareketListByUstTip(Global global, string ustTipKod, int? parentId, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TipHareketListModel> { Items = new List<TipHareketListModel>() };
            var sql = @"select 
	                        th.Id,th.SIRKID,th.TIPKOD,t.TIPADI, th.HARKOD,th.SIRASI,th.TANIMI,th.ACTIVE,th.EKKULL,th.ETARIH,th.DEKULL,th.DTARIH,t.UTPKOD,th.EXTRA1,
	                        (select TANIMI from GNTHRK as th2 where th2.Id=th.PARENT) as ParentName,th.PARENT
	                        from GNTHRK as th
	                        left join GNTIPI as t on t.TIPKOD=th.TIPKOD
                            where th.SIRKID=@sirketId and th.LANGKD =@dilkod and th.ACTIVE=1 and th.SLINDI=0 and t.UTPKOD=@ustTipKod and th.PARENT=@parentId  order by th.TIPKOD, th.SIRASI";

            sonuc.Items = _gnthrkDal.GetListSqlQuery<TipHareketListModel>(sql,
                new SqlParameter("ustTipKod", ustTipKod),
                new SqlParameter("parentId", parentId ?? 0),
                new SqlParameter("dilkod", global.DilKod),
                new SqlParameter("sirketId", global.SirketId)
                );
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        public ListResponse<TipHareketListModel> Cch_TipHareketListByUstTipAltTip(Global global, string ustTipKod, string tipkod, int? parentId, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<TipHareketListModel> { Items = new List<TipHareketListModel>() };
            var sql = @"select 
	                        th.Id,th.SIRKID,th.TIPKOD,t.TIPADI, th.HARKOD,th.SIRASI,th.TANIMI,th.ACTIVE,th.EKKULL,th.ETARIH,th.DEKULL,th.DTARIH,t.UTPKOD,th.EXTRA1,
	                        (select TANIMI from GNTHRK as th2 where th2.Id=th.PARENT) as ParentName,th.PARENT
	                        from GNTHRK as th
	                        left join GNTIPI as t on t.TIPKOD=th.TIPKOD
                            where th.SIRKID=@sirketId and th.LANGKD =@dilkod and th.ACTIVE=1 and th.SLINDI=0 and t.UTPKOD=@ustTipKod and th.PARENT=@parentId and th.TIPKOD =@tipKod order by th.TIPKOD, th.SIRASI";

            sonuc.Items = _gnthrkDal.GetListSqlQuery<TipHareketListModel>(sql,
                new SqlParameter("ustTipKod", ustTipKod),
                new SqlParameter("tipKod", tipkod),
                new SqlParameter("parentId", parentId ?? 0),
                new SqlParameter("dilkod", global.DilKod),
                new SqlParameter("sirketId", global.SirketId)
            );
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TipHareketListModel> Ncch_GetThrkByMultiTeknad_NLog(Global global, List<string> teknads, 
            bool yetkiKontrol = true, string dilKod = "")
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }

            if (dilKod == "") dilKod = global.DilKod;

            var sonuc = new ListResponse<TipHareketListModel>();

            if (teknads.Count > 0)
            {
                var whereStr = "";
                foreach (var teknad in teknads)
                {
                    whereStr += "'" + teknad + "',";
                }
                whereStr = whereStr.Remove(whereStr.Length - 1);
                var sql = @"select * 
                            from GNTHRK as th left join GNTIPI as t on th.TIPKOD = t.TIPKOD 
                            where  th.SIRKID=@sirketId and t.SIRKID=@sirketId and th.LANGKD =@dilkod and th.SLINDI=0 and th.ACTIVE=1 and t.SLINDI=0 and t.ACTIVE=1 
                            and t.TEKNAD in(" + whereStr + ") order by th.TIPKOD, th.SIRASI";
                sonuc.Items = _gnthrkDal.GetListSqlQuery<TipHareketListModel>(sql,
                    new SqlParameter("sirketId", global.SirketId), new SqlParameter("dilkod", dilKod));
                sonuc.Status = ResponseStatusEnum.OK;
            }

            return sonuc;
        }

        #endregion ClientFunc
    }
}
