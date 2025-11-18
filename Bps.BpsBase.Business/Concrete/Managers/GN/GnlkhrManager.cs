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

using Bps.BpsBase.Entities.Models.GN.Listed;
using System.Data.SqlClient;
using System.Collections.Generic;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GnlkhrManager : IGnlkhrService
    {
        private IGnlkhrDal _gnlkhrDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GnlkhrManager(IGnlkhrDal gnlkhrDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnlkhrDal = gnlkhrDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNLKHR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNLKHR>();
            sonuc.Items = global.SirketId != null ? _gnlkhrDal.GetList(x => x.SIRKID == global.SirketId) : _gnlkhrDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNLKHR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNLKHR>();
            sonuc.Items = global.SirketId != null ? _gnlkhrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnlkhrDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNLKHR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNLKHR>();
            sonuc.Items = global.SirketId != null ? _gnlkhrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnlkhrDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNLKHR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNLKHR>();
            sonuc.Items = global.SirketId != null ? _gnlkhrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnlkhrDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNLKHR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNLKHR>();
            sonuc.Items = global.SirketId != null ? _gnlkhrDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnlkhrDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNLKHR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNLKHR>();
            sonuc.Nesne = _gnlkhrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNLKHR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNLKHR", id, global);
            var sonuc = new StandardResponse<GNLKHR>();
            sonuc.Nesne = _gnlkhrDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnlkhrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNLKHR> Ncch_Add_NLog(GNLKHR gnlkhr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNLKHR>();
            gnlkhr.SIRKID = global.SirketId.Value; 
            gnlkhr.EKKULL = global.UserKod;
            gnlkhr.ETARIH = DateTime.Now;
            gnlkhr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnlkhrDal.Add(gnlkhr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnlkhrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNLKHR> Ncch_Update_Log(GNLKHR gnlkhr,GNLKHR oldGnlkhr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNLKHR", gnlkhr.Id, global);
            var sonuc = new StandardResponse<GNLKHR>();
            gnlkhr.SIRKID = global.SirketId.Value; 
            gnlkhr.DEKULL = global.UserKod;
            gnlkhr.DTARIH = DateTime.Now;
            gnlkhr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnlkhrDal.Update(gnlkhr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnlkhrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNLKHR> Ncch_UpdateAktifPasif_Log(GNLKHR gnlkhr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNLKHR>();
            gnlkhr.SIRKID = global.SirketId.Value; 
            gnlkhr.ACTIVE = !gnlkhr.ACTIVE;
            gnlkhr.DEKULL = global.UserKod;
            gnlkhr.DTARIH = DateTime.Now;
            gnlkhr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnlkhrDal.Update(gnlkhr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnlkhrValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNLKHR> Ncch_Delete_Log(GNLKHR gnlkhr, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNLKHR", gnlkhr.Id, global);
            var sonuc = new StandardResponse<GNLKHR>();
            gnlkhr.SIRKID = global.SirketId.Value; 
            gnlkhr.ACTIVE = false;
            gnlkhr.SLINDI = true;
            gnlkhr.DEKULL = global.UserKod;
            gnlkhr.DTARIH = DateTime.Now;
            gnlkhr.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnlkhrDal.Update(gnlkhr);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public StandardResponse<GNLKHR> Ncch_GetByTipKodAndHarKod_NLog(Global global, string tipKod, string harKod,
            bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNLKHR>();
            sonuc.Nesne = _gnlkhrDal.Get(x => x.TIPKOD == tipKod && x.HARKOD == harKod);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNLKHR> Cch_GetListByTipKod(Global global, string tipKod, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNLKHR>();
            sonuc.Items = global.SirketId != null ? _gnlkhrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE && x.TIPKOD == tipKod) : _gnlkhrDal.GetList(x => x.ACTIVE && x.TIPKOD == tipKod);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNLKHR> Cch_GetListByTipKodAndParent(Global global, string tipKod, int parent, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNLKHR>();
            sonuc.Items = global.SirketId != null ? _gnlkhrDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE && x.TIPKOD == tipKod && x.PARENT == parent) : _gnlkhrDal.GetList(x => x.ACTIVE && x.TIPKOD == tipKod);
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
	                        (select TANIMI from GNLKHR as th2 where th2.Id=th.PARENT) as ParentName,th.PARENT,t.TEKNAD
	                        from GNLKHR as th
	                        left join GNTIPI as t on t.TIPKOD=th.TIPKOD
                            where th.SIRKID=@sirketId and th.SLINDI=0 " + whereStr + " order by th.TIPKOD, th.SIRASI";

            sonuc.Items = _gnlkhrDal.GetListSqlQuery<TipHareketListModel>(sql, new SqlParameter("sirketId", global.SirketId));
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
                            from GNLKHR as th left join GNTIPI as t on th.TIPKOD = t.TIPKOD 
                            where  th.SIRKID=@sirketId and th.SLINDI=0 and th.ACTIVE=1 
                            and t.TEKNAD in(" + whereStr + ") order by th.TIPKOD, th.SIRASI";
                sonuc.Items = _gnlkhrDal.GetListSqlQuery<TipHareketListModel>(sql,
                    new SqlParameter("sirketId", global.SirketId));
                sonuc.Status = ResponseStatusEnum.OK;
            }

            return sonuc;
        }
        #endregion ClientFunc
    }
}
