using System;
using Bps.Core.Response;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Business.Abstract.GN;
using Bps.BpsBase.Business.DependencyResolvers.Exception;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.Business.ValidationRules.FluentValidation;
using Bps.BpsBase.Business.Abstract;
using Bps.BpsBase.DataAccess.Abstract;
using Bps.BpsBase.Entities.Concrete;

#region ClientUsing

using System.Linq;
using System.Xml;
using System.Globalization;

#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers
{
    public class DovkurManager : IDovkurService
    {
        private IDovkurDal _dovkurDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        private short attempt = 0;

        #endregion ClientServices

        public DovkurManager(IDovkurDal dovkurDal,IGnService gnservice,ILockedService lockedservice)
        {
            _dovkurDal = dovkurDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<DOVKUR> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<DOVKUR>();
            sonuc.Items = _dovkurDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<DOVKUR> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<DOVKUR>();
            sonuc.Items = _dovkurDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<DOVKUR> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<DOVKUR>();
            sonuc.Items = _dovkurDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<DOVKUR> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<DOVKUR>();
            sonuc.Items = _dovkurDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<DOVKUR> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<DOVKUR>();
            sonuc.Items = _dovkurDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<DOVKUR> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<DOVKUR>();
            sonuc.Nesne = _dovkurDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<DOVKUR> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("DOVKUR", id, global);
            var sonuc = new StandardResponse<DOVKUR>();
            sonuc.Nesne = _dovkurDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(DovkurValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<DOVKUR> Ncch_Add_NLog(DOVKUR dovkur, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<DOVKUR>();
            dovkur.EKKULL = global.UserKod;
            dovkur.ETARIH = DateTime.Now;
            dovkur.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _dovkurDal.Add(dovkur);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(DovkurValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<DOVKUR> Ncch_Update_Log(DOVKUR dovkur,DOVKUR oldDovkur, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("DOVKUR", dovkur.Id, global);
            var sonuc = new StandardResponse<DOVKUR>();
            dovkur.DEKULL = global.UserKod;
            dovkur.DTARIH = DateTime.Now;
            dovkur.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _dovkurDal.Update(dovkur);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(DovkurValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<DOVKUR> Ncch_UpdateAktifPasif_Log(DOVKUR dovkur, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<DOVKUR>();
            dovkur.ACTIVE = !dovkur.ACTIVE;
            dovkur.DEKULL = global.UserKod;
            dovkur.DTARIH = DateTime.Now;
            dovkur.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _dovkurDal.Update(dovkur);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(DovkurValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<DOVKUR> Ncch_Delete_Log(DOVKUR dovkur, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("DOVKUR", dovkur.Id, global);
            var sonuc = new StandardResponse<DOVKUR>();
            dovkur.ACTIVE = false;
            dovkur.SLINDI = true;
            dovkur.DEKULL = global.UserKod;
            dovkur.DTARIH = DateTime.Now;
            dovkur.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _dovkurDal.Update(dovkur);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        public StandardResponse<DOVKUR> Cch_GetByDate_NLog(string dvcnkd, DateTime dovDate)
        {
            var sonuc = new StandardResponse<DOVKUR>();
            sonuc.Nesne = _dovkurDal.Get(x => x.DVCNKD == dvcnkd && x.DOVTRH == dovDate && x.ACTIVE && !x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<DOVKUR> GetRecentCurrencies(Global global)
        {
            var sonuc = new ListResponse<DOVKUR>();

            string sql = @"SELECT MAX(DOVTRH) AS DOVTRH FROM DOVKUR WHERE DVFYT1 IS NOT NULL AND DVFYT1 > 0 AND ACTIVE = 1 AND SLINDI = 0";
            DateTime? maxDate = _dovkurDal.GetObjectSqlQuery<DateTime?>(sql);
            if (maxDate == null) return new ListResponse<DOVKUR>();

            sonuc.Items = _dovkurDal.GetList(d => d.DOVTRH == maxDate).ToList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(DovkurValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<DOVKUR> Ncch_AutoAdd_NLog(DOVKUR dovkur, Global global)
        {
            var sonuc = new StandardResponse<DOVKUR>();
            dovkur.EKKULL = global.UserKod;
            dovkur.ETARIH = DateTime.Now;
            dovkur.KYNKKD = global.KaynakKod;
            dovkur.ACTIVE = true;
            dovkur.SLINDI = false;
            sonuc.Nesne = _dovkurDal.Add(dovkur);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public DOVKUR GetDovizKuru(DOVKUR dovkur)
        {
            DateTime dovizDate = (DateTime)dovkur.DOVTRH;
            string dovizKodu = dovkur.DVCNKD;

            try
            {
                string yyyyMM = dovizDate.AddDays(-1).ToString("yyyyMM");
                string ddMMyyyy = dovizDate.AddDays(-1).ToString("ddMMyyyy");

                string dovizTarihi = "http://www.tcmb.gov.tr/kurlar/" + yyyyMM + "/" + ddMMyyyy + ".xml";
                XmlDocument dovizXml = new XmlDocument();
                dovizXml.Load(dovizTarihi);

                //string kur = "0";
                //if (CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
                //    kur = dovizXml.SelectSingleNode("Tarih_Date/Currency[@Kod='" + dovizKodu + "']/ForexBuying").InnerXml.Replace(".", ",");
                //else if (CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ".")
                //    kur = dovizXml.SelectSingleNode("Tarih_Date/Currency[@Kod='" + dovizKodu + "']/ForexBuying").InnerXml;

                //if (dovizKodu == "JPY" || dovizKodu == "IRR") kur = (Convert.ToSingle(kur) / 100).ToString();

                var dovizAlis = dovizXml.SelectSingleNode("Tarih_Date/Currency[@Kod='" + dovizKodu + "']/ForexBuying").InnerXml;
                var dovizSatis = dovizXml.SelectSingleNode("Tarih_Date/Currency[@Kod='" + dovizKodu + "']/ForexSelling").InnerXml;
                var efektifAlis = dovizXml.SelectSingleNode("Tarih_Date/Currency[@Kod='" + dovizKodu + "']/BanknoteBuying").InnerXml;
                var efektifSatis = dovizXml.SelectSingleNode("Tarih_Date/Currency[@Kod='" + dovizKodu + "']/BanknoteSelling").InnerXml;

                if (CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator == ",")
                {
                    dovizAlis = dovizAlis.Replace(".", ",");
                    dovizSatis = dovizSatis.Replace(".", ",");
                    efektifAlis = efektifAlis.Replace(".", ",");
                    efektifSatis = efektifSatis.Replace(".", ",");
                }

                if (dovizAlis != null && dovizAlis != "") dovkur.DVFYT1 = Math.Round(Convert.ToSingle(dovizAlis), 4);
                if (dovizSatis != null && dovizSatis != "") dovkur.DVFYT2 = Math.Round(Convert.ToSingle(dovizSatis), 4);
                if (efektifAlis != null && efektifAlis != "") dovkur.DVFYT3 = Math.Round(Convert.ToSingle(efektifAlis), 4);
                if (efektifSatis != null && efektifSatis != "") dovkur.DVFYT4 = Math.Round(Convert.ToSingle(efektifSatis), 4);
            }
            catch (Exception ex)
            {
                if (ex.ToString().IndexOf("Uzak ad ", 0) > -1)
                {
                    dovkur.DVFYT1 = -1;
                    dovkur.DVFYT2 = -1;
                    dovkur.DVFYT3 = -1;
                    dovkur.DVFYT4 = -1;
                }
                else if (ex.ToString().IndexOf("(404) Bulunamad", 0) > -1)
                {
                    if (attempt == 20)
                    {
                        attempt = 0;
                        return null;
                    }

                    attempt++;
                    dovkur.DOVTRH = dovizDate.AddDays(-1);
                    GetDovizKuru(dovkur);
                }
            }

            attempt = 0;
            return dovkur;
        }
        #endregion ClientFunc
    }
}
