using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
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
using Bps.BpsBase.Entities.Models.GN;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.GN
{
    public class GnorgaManager : IGnorgaService
    {
        private IGnorgaDal _gnorgaDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public GnorgaManager(IGnorgaDal gnorgaDal,IGnService gnservice,ILockedService lockedservice)
        {
            _gnorgaDal = gnorgaDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<GNORGA> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNORGA>();
            sonuc.Items = global.SirketId != null ? _gnorgaDal.GetList(x => x.SIRKID == global.SirketId) : _gnorgaDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNORGA> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNORGA>();
            sonuc.Items = global.SirketId != null ? _gnorgaDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _gnorgaDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNORGA> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNORGA>();
            sonuc.Items = global.SirketId != null ? _gnorgaDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _gnorgaDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNORGA> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNORGA>();
            sonuc.Items = global.SirketId != null ? _gnorgaDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _gnorgaDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<GNORGA> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<GNORGA>();
            sonuc.Items = global.SirketId != null ? _gnorgaDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _gnorgaDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNORGA> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<GNORGA>();
            sonuc.Nesne = _gnorgaDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<GNORGA> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("GNORGA", id, global);
            var sonuc = new StandardResponse<GNORGA>();
            sonuc.Nesne = _gnorgaDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnorgaValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNORGA> Ncch_Add_NLog(GNORGA gnorga, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNORGA>();
            gnorga.SIRKID = global.SirketId.Value; 
            gnorga.EKKULL = global.UserKod;
            gnorga.ETARIH = DateTime.Now;
            gnorga.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnorgaDal.Add(gnorga);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnorgaValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNORGA> Ncch_Update_Log(GNORGA gnorga,GNORGA oldGnorga, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNORGA", gnorga.Id, global);
            var sonuc = new StandardResponse<GNORGA>();
            gnorga.SIRKID = global.SirketId.Value; 
            gnorga.DEKULL = global.UserKod;
            gnorga.DTARIH = DateTime.Now;
            gnorga.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnorgaDal.Update(gnorga);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnorgaValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNORGA> Ncch_UpdateAktifPasif_Log(GNORGA gnorga, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<GNORGA>();
            gnorga.SIRKID = global.SirketId.Value; 
            gnorga.ACTIVE = !gnorga.ACTIVE;
            gnorga.DEKULL = global.UserKod;
            gnorga.DTARIH = DateTime.Now;
            gnorga.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnorgaDal.Update(gnorga);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(GnorgaValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<GNORGA> Ncch_Delete_Log(GNORGA gnorga, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("GNORGA", gnorga.Id, global);
            var sonuc = new StandardResponse<GNORGA>();
            gnorga.SIRKID = global.SirketId.Value; 
            gnorga.ACTIVE = false;
            gnorga.SLINDI = true;
            gnorga.DEKULL = global.UserKod;
            gnorga.DTARIH = DateTime.Now;
            gnorga.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _gnorgaDal.Update(gnorga);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc
        public ListResponse<OnayOrganizasyonTreeList> Ncch_GetOnayOrganizasyon_NLog(string orgtkd, Global global)
        {

            var sonuc = new ListResponse<OnayOrganizasyonTreeList>();
            var sql = @"Select 
			    a.PARENT as ParentId, a.CHILDD as AltId ,a.ORGTKD as Orgtkd ,a.TANIMI as Tanimi,
                a.SEVIYE as Seviye,a.KULKOD as Kulkod,a.GNNAME as Gnname, a.GNSNAM as Gnsnam,
                a.ONYSVY as Onysvy, a.GNONAY as Gnonay, a.GNLONY as Gnlony, a.GNDFON as Gndfon,
                a.SIRASI as Sirasi
                         
                from dbo.GNORGA  as a Where a.SIRKID=@sirketId and a.ORGTKD = @ORGTKD
                order by a.CHILDD";

            //Thread.Sleep(3000);
            sonuc.Items = _gnorgaDal.GetListSqlQuery<OnayOrganizasyonTreeList>(sql,
                new SqlParameter("@sirketId", global.SirketId),
                new SqlParameter("@ORGTKD", orgtkd));

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        public StandardResponse Ncch_DeleteOrganizasyon_NLog(string orgtkd, Global global)
        {

            var sonuc = new StandardResponse();
            var sql = @"delete from dbo.GNORGA   Where SIRKID = @sirketId and ORGTKD = @ORGTKD ";

            //Thread.Sleep(3000);
            _gnorgaDal.ExecuteSqlQuery(sql,
              new SqlParameter("@sirketId", global.SirketId),
              new SqlParameter("@ORGTKD", orgtkd));

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public List<GNORGA> FindAllParents(GNORGA child, List<GNORGA> tumorg, int seviye, int itt)
        {
            var parentList = new List<GNORGA>();
            var parent = _gnorgaDal.Get(z => z.CHILDD == child.PARENT);
            if (parent != null)
            {
                if (parent.GNONAY != false || parent.GNLONY != false || parent.GNDFON != false)
                {
                    tumorg.Add(parent);
                }

                if (itt < seviye)
                {
                    itt++;
                    parentList.AddRange(FindAllParents(parent, tumorg, seviye, itt));
                }
            }
            return tumorg;
        }
        public ListResponse<GNORGA> Ncch_KullaniciOnayList_NLog(string orgKod, Global global)
        {
            var sonuc = new ListResponse<GNORGA>();
            var tumOrg = new List<GNORGA>();

            var kisiorg = _gnorgaDal.Get(z => z.SIRKID == global.SirketId && z.ACTIVE && z.KULKOD == global.UserKod && z.ORGTKD == orgKod);

            if (kisiorg == null)
            {
                sonuc.Message = "Sayin " + global.FirstName + " " + global.LastName + " '" + orgKod +
                                "' koduna ait organizasyon listesinde bulunmadiginiz icin kayit giremezsiniz!";
                sonuc.Status = ResponseStatusEnum.ERROR;
                return sonuc;
            }
            var allparents = FindAllParents(kisiorg, tumOrg, (int)kisiorg.ONYSVY, 1);
            var defAndLast = _gnorgaDal.GetList(z => z.SIRKID == global.SirketId && z.ACTIVE &&
                z.GNDFON == true && z.ORGTKD == orgKod || z.GNLONY == true && z.ORGTKD == orgKod);

            if (allparents == null && defAndLast == null) return sonuc;
            if (allparents == null)
            {
                sonuc.Items = defAndLast;
            }
            if (allparents != null && defAndLast == null)
            {
                sonuc.Items = allparents;
                return sonuc;
            }

            if (allparents != null)
            {
                foreach (var par in allparents)
                {
                    var tekrarKayit = defAndLast.FirstOrDefault(x => x.KULKOD == par.KULKOD);

                    if (tekrarKayit != null)
                    {
                        defAndLast.Remove(tekrarKayit);
                    }
                }

                allparents.AddRange(defAndLast);
                sonuc.Items = allparents;
            }

            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }
        #endregion ClientFunc
    }
}
