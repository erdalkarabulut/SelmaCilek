using System;
using System.Data.SqlClient;
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

using Bps.BpsBase.Entities.Models.GN.Listed;
using System.Collections.Generic;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GnbnhrManager : IGnbnhrService
    {
        private IGnbnhrDal _gnbnhrDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GnbnhrManager(IGnbnhrDal gnbnhrDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnbnhrDal = gnbnhrDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNBNHR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNBNHR>();
            sonuc.Items = global.SirketId != null ? _gnbnhrDal.GetList(x => x.SIRKID == global.SirketId) : _gnbnhrDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNBNHR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNBNHR>();
            sonuc.Items = global.SirketId != null ? _gnbnhrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnbnhrDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNBNHR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNBNHR>();
            sonuc.Items = global.SirketId != null ? _gnbnhrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnbnhrDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNBNHR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNBNHR>();
            sonuc.Items = global.SirketId != null ? _gnbnhrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnbnhrDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNBNHR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNBNHR>();
            sonuc.Items = global.SirketId != null ? _gnbnhrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnbnhrDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNBNHR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNBNHR>();
            sonuc.Nesne = _gnbnhrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNBNHR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNBNHR", id, global);
            var sonuc = new StandardResponse<GNBNHR>();
            sonuc.Nesne = _gnbnhrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnbnhrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNBNHR> Ncch_Add_NLog(GNBNHR gnbnhr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNBNHR>();
            gnbnhr.SIRKID = global.SirketId.Value; 
            gnbnhr.EKKULL = global.UserKod;
            gnbnhr.ETARIH = DateTime.Now;
            gnbnhr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnbnhrDal.Add(gnbnhr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnbnhrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNBNHR> Ncch_Update_Log(GNBNHR gnbnhr,GNBNHR oldGnbnhr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNBNHR", gnbnhr.Id, global);
            var sonuc = new StandardResponse<GNBNHR>();
            gnbnhr.SIRKID = global.SirketId.Value; 
            gnbnhr.DEKULL = global.UserKod;
            gnbnhr.DTARIH = DateTime.Now;
            gnbnhr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnbnhrDal.Update(gnbnhr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnbnhrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNBNHR> Ncch_UpdateAktifPasif_Log(GNBNHR gnbnhr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNBNHR>();
            gnbnhr.SIRKID = global.SirketId.Value; 
            gnbnhr.ACTIVE = !gnbnhr.ACTIVE;
            gnbnhr.DEKULL = global.UserKod;
            gnbnhr.DTARIH = DateTime.Now;
            gnbnhr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnbnhrDal.Update(gnbnhr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnbnhrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNBNHR> Ncch_Delete_Log(GNBNHR gnbnhr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNBNHR", gnbnhr.Id, global);
            var sonuc = new StandardResponse<GNBNHR>();
            gnbnhr.SIRKID = global.SirketId.Value; 
            gnbnhr.ACTIVE = false;
            gnbnhr.SLINDI = true;
            gnbnhr.DEKULL = global.UserKod;
            gnbnhr.DTARIH = DateTime.Now;
            gnbnhr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnbnhrDal.Update(gnbnhr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<GNBNHR> Cch_GetListByTipKod(Global global, string tipKod, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNBNHR>();
            sonuc.Items = global.SirketId != null ? _gnbnhrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE && x.TIPKOD == tipKod) : _gnbnhrDal.GetList(x => x.ACTIVE && x.TIPKOD == tipKod);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TipHareketListModel> Cch_TipHareketListGetir(Global global, string tipKod,
            bool yetkiKontrol = true)
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
	                        (select TANIMI from GNBNHR as th2 where th2.Id=th.PARENT) as ParentName,th.PARENT,t.TEKNAD
	                        from GNBNHR as th
	                        left join GNTIPI as t on t.TIPKOD=th.TIPKOD
                            where th.SIRKID=@sirketId and th.SLINDI=0 " + whereStr + " order by th.TIPKOD, th.SIRASI";

            sonuc.Items = _gnbnhrDal.GetListSqlQuery<TipHareketListModel>(sql, new SqlParameter("sirketId", global.SirketId));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<TipHareketListModel> Ncch_GetThrkByMultiTeknad_NLog(Global global, List<String> teknads,
            bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
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
                            from GNBNHR as th left join GNTIPI as t on th.TIPKOD = t.TIPKOD 
                            where  th.SIRKID=@sirketId and th.SLINDI=0 and th.ACTIVE=1 
                            and t.TEKNAD in(" + whereStr + ") order by th.TIPKOD, th.SIRASI";
                sonuc.Items = _gnbnhrDal.GetListSqlQuery<TipHareketListModel>(sql,
                    new SqlParameter("sirketId", global.SirketId));
                sonuc.Status = ResponseStatusEnum.OK;
            }

            return sonuc;
        }
        #endregion ClientFunc
    }
}
