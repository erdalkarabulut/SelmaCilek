using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.UA;
using Bps.BpsBase.Business.Abstract.UA;
using Bps.BpsBase.DataAccess.Abstract.UA;
using Bps.BpsBase.Entities.Concrete.UA;

#region ClientUsing

using System.Data.SqlClient;
using Bps.BpsBase.Entities.Models.UA;
using Bps.BpsBase.Business.Abstract.IS;
using System.Collections.Generic;
using System.Linq;


#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.UA
{
    public class UastbgManager : IUastbgService
    {
        private IUastbgDal _uastbgDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices
        private IIsrevzService _isrevzService;
        private IUakltpService _uakltpService;
        private IGnthrkService _gnthrkService;
        #endregion ClientServices

        public UastbgManager(IUastbgDal uastbgDal,IGnService gnservice,ILockedService lockedservice
        #region ClientConts
            , IIsrevzService  isrevzService
            , IUakltpService  uakltpService
            , IGnthrkService gnthrkService
        #endregion ClientConts

            )
        {
            _uastbgDal = uastbgDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
            #region ClientContsitems
            _isrevzService = isrevzService;
            _uakltpService = uakltpService;
            _gnthrkService = gnthrkService;
            #endregion ClientContsitems
        }

        public ListResponse<UASTBG> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UASTBG>();
            sonuc.Items = global.SirketId != null ? _uastbgDal.GetList(x => x.SIRKID == global.SirketId) : _uastbgDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UASTBG> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UASTBG>();
            sonuc.Items = global.SirketId != null ? _uastbgDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _uastbgDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UASTBG> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UASTBG>();
            sonuc.Items = global.SirketId != null ? _uastbgDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _uastbgDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UASTBG> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UASTBG>();
            sonuc.Items = global.SirketId != null ? _uastbgDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _uastbgDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UASTBG> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UASTBG>();
            sonuc.Items = global.SirketId != null ? _uastbgDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _uastbgDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<UASTBG> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<UASTBG>();
            sonuc.Nesne = _uastbgDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<UASTBG> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("UASTBG", id, global);
            var sonuc = new StandardResponse<UASTBG>();
            sonuc.Nesne = _uastbgDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UastbgValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UASTBG> Ncch_Add_NLog(UASTBG uastbg, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<UASTBG>();
            uastbg.SIRKID = global.SirketId.Value; 
            uastbg.EKKULL = global.UserKod;
            uastbg.ETARIH = DateTime.Now;
            uastbg.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uastbgDal.Add(uastbg);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UastbgValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UASTBG> Ncch_Update_Log(UASTBG uastbg,UASTBG oldUastbg, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("UASTBG", uastbg.Id, global);
            var sonuc = new StandardResponse<UASTBG>();
            uastbg.SIRKID = global.SirketId.Value; 
            uastbg.DEKULL = global.UserKod;
            uastbg.DTARIH = DateTime.Now;
            uastbg.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uastbgDal.Update(uastbg);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UastbgValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UASTBG> Ncch_UpdateAktifPasif_Log(UASTBG uastbg, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<UASTBG>();
            uastbg.SIRKID = global.SirketId.Value; 
            uastbg.ACTIVE = !uastbg.ACTIVE;
            uastbg.DEKULL = global.UserKod;
            uastbg.DTARIH = DateTime.Now;
            uastbg.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uastbgDal.Update(uastbg);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UastbgValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UASTBG> Ncch_Delete_Log(UASTBG uastbg, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("UASTBG", uastbg.Id, global);
            var sonuc = new StandardResponse<UASTBG>();
            uastbg.SIRKID = global.SirketId.Value; 
            uastbg.ACTIVE = false;
            uastbg.SLINDI = true;
            uastbg.DEKULL = global.UserKod;
            uastbg.DTARIH = DateTime.Now;
            uastbg.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uastbgDal.Update(uastbg);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public ListResponse<UrunAgaciRevizyonlar> Ncch_GetByStokKoduUaKullanim_NLog(string stokKodu, string uaKullanim, Global global)
        {

            var sonuc = new ListResponse<UrunAgaciRevizyonlar>();
            var sql = @"
                 SELECT 
				UASTBG.STKODU AS StokKodu, UASTBG.GNREZV AS RevizyonNo, ISREVZ.TANIMI AS RevizyonText, 
                ISREVZ.BASTAR AS BaslangicTarih, ISREVZ.ACTIVE AS Etkin, ISREVZ.URTONY AS UretimOnay, 
				UASTBG.URYRKD AS UretimYeriKodu,
                UASTBG.URAKOD AS UrunAgaciKodu, UAKLTP.TANIMI AS UAKullanimText
                FROM UASTBG 
				LEFT OUTER JOIN ISREVZ ON ISREVZ.SIRKID = UASTBG.SIRKID AND ISREVZ.GNREZV = UASTBG.GNREZV 
				LEFT OUTER JOIN UAKLTP ON UAKLTP.SIRKID = UASTBG.SIRKID AND UAKLTP.KLNKOD = UASTBG.KLNKOD
                WHERE UASTBG.SIRKID = @SirketId AND UASTBG.STKODU = @StokKodu AND UASTBG.KLNKOD = @KullanimKodu";

            sonuc.Items = _uastbgDal.GetListSqlQuery<UrunAgaciRevizyonlar>(sql,
                new SqlParameter("@StokKodu", stokKodu),
                new SqlParameter("@SirketId", global.SirketId),
                new SqlParameter("@KullanimKodu", uaKullanim));
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<string> Ncch_GetUrunAgaciKodu_NLog(string stokKodu, string revizyonNo, string uaKullanim, Global global,string vrkodu =null)
        {
            var sonuc = new StandardResponse<string>();
            UASTBG ua = new UASTBG();
            if (vrkodu == null)
            {
                ua = _uastbgDal.Get(p =>
                p.SIRKID == global.SirketId && p.SLINDI == false && p.STKODU == stokKodu && p.KLNKOD == uaKullanim &&
                p.GNREZV == revizyonNo);
            }
            else
            {
                ua = _uastbgDal.Get(p =>
               p.SIRKID == global.SirketId && p.SLINDI == false && p.STKODU == stokKodu && p.KLNKOD == uaKullanim &&
               p.GNREZV == revizyonNo && p.VRKODU == vrkodu);
            }
            

            if (ua != null)
            {
                sonuc.Status = ResponseStatusEnum.OK;
                sonuc.Nesne = ua.URAKOD;
            }
            else
            {
                sonuc.Status = ResponseStatusEnum.ERROR;
            }

            return sonuc;
        }

        public ListResponse<UrunAgaciRevizyonlar> Ncch_GetByStokKoduUaKullanim_NLog(string stokKodu, string uaKullanim, Global global, bool yetkiKontrol = true,string _vrkodu = null)
        {
            if (yetkiKontrol)
            {
                var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
                if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UrunAgaciRevizyonlar>();
            List<UrunAgaciRevizyonlar> _listurunAgacRev = new List<UrunAgaciRevizyonlar>();
            var copylist = new List<UASTBG>();
            var revizyonlist = _isrevzService.Cch_GetListAktif_NLog(global, false).Items;
            var UAKalemTipList = _uakltpService.Cch_GetListAktif_NLog(global, false).Items;
            if (_vrkodu == null)
            {
                copylist = global.SirketId != null ? _uastbgDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.ACTIVE && x.STKODU
                            == stokKodu)
                            : _uastbgDal.GetList(x => x.SLINDI == false && x.ACTIVE && x.STKODU == stokKodu);
            }
            else
            {
                copylist = global.SirketId != null ? _uastbgDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false && x.ACTIVE && x.STKODU
                            == stokKodu && x.VRKODU == _vrkodu)
                            : _uastbgDal.GetList(x => x.SLINDI == false && x.ACTIVE && x.STKODU == stokKodu && x.VRKODU == _vrkodu);
            }

            foreach (var item in copylist)
            {
                UrunAgaciRevizyonlar _urunAgacRev = new UrunAgaciRevizyonlar();
                _urunAgacRev.StokKodu = item.STKODU;
                _urunAgacRev.RevizyonNo = item.GNREZV;
                _urunAgacRev.UretimYeriKodu = item.URYRKD;
                _urunAgacRev.UrunAgaciKodu = item.URAKOD;
                _urunAgacRev.VRKODU = item.VRKODU;
                _urunAgacRev.UAKullanimText = UAKalemTipList.Where(x => x.SIRKID == global.SirketId && x.KLNKOD == item.KLNKOD).Select(y => y.TANIMI).FirstOrDefault();
                _urunAgacRev.BaslangicTarih = (DateTime)revizyonlist.Where(x => x.SIRKID == global.SirketId && x.GNREZV  == item.GNREZV).Select(y => y.BASTAR).FirstOrDefault();
                _urunAgacRev.Etkin = revizyonlist.Where(x => x.SIRKID == global.SirketId && x.GNREZV == item.GNREZV).Select(y => y.ACTIVE).FirstOrDefault();
                _urunAgacRev.UretimOnay = (bool)revizyonlist.Where(x => x.SIRKID == global.SirketId && x.GNREZV == item.GNREZV).Select(y => y.URTONY).FirstOrDefault();
              

                _listurunAgacRev.Add(_urunAgacRev);
            }

            sonuc.Items = _listurunAgacRev;
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
