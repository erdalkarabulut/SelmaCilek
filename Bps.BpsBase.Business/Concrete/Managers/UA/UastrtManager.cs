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
using Bps.BpsBase.Entities.Concrete.UR;
using System.Collections.Generic;
using System.Data.SqlClient;
#endregion ClientUsing

namespace Bps.BpsBase.Business.Concrete.Managers.UA
{
    public class UastrtManager : IUastrtService
    {
        private IUastrtDal _uastrtDal;
        private IGnService _gnService;
        private ILockedService _lockedService;
        #region ClientDals

        #endregion ClientDals
        #region ClientServices

        #endregion ClientServices

        public UastrtManager(IUastrtDal uastrtDal,IGnService gnservice,ILockedService lockedservice)
        {
            _uastrtDal = uastrtDal;
            _gnService = gnservice;
            _lockedService = lockedservice;
        }

        public ListResponse<UASTRT> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UASTRT>();
            sonuc.Items = global.SirketId != null ? _uastrtDal.GetList(x => x.SIRKID == global.SirketId) : _uastrtDal.GetList();
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UASTRT> Cch_GetList_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UASTRT>();
            sonuc.Items = global.SirketId != null ? _uastrtDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI == false) : _uastrtDal.GetList(x => x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UASTRT> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UASTRT>();
            sonuc.Items = global.SirketId != null ? _uastrtDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == false && x.SLINDI == false) : _uastrtDal.GetList(x => x.ACTIVE == false && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UASTRT> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UASTRT>();
            sonuc.Items = global.SirketId != null ? _uastrtDal.GetList(x => x.SIRKID == global.SirketId && x.ACTIVE == true && x.SLINDI == false) : _uastrtDal.GetList(x => x.ACTIVE == true && x.SLINDI == false);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public ListResponse<UASTRT> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new ListResponse<UASTRT>();
            sonuc.Items = global.SirketId != null ? _uastrtDal.GetList(x => x.SIRKID == global.SirketId && x.SLINDI) : _uastrtDal.GetList(x => x.SLINDI);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<UASTRT> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            var sonuc = new StandardResponse<UASTRT>();
            sonuc.Nesne = _uastrtDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        public StandardResponse<UASTRT> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true)
        {
            if (yetkiKontrol)
            {
              var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
              if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            }
            _lockedService.LockControlRead("UASTRT", id, global);
            var sonuc = new StandardResponse<UASTRT>();
            sonuc.Nesne = _uastrtDal.Get(x => x.Id == id);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UastrtValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UASTRT> Ncch_Add_NLog(UASTRT uastrt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Add" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<UASTRT>();
            uastrt.SIRKID = global.SirketId.Value; 
            uastrt.EKKULL = global.UserKod;
            uastrt.ETARIH = DateTime.Now;
            uastrt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uastrtDal.Add(uastrt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UastrtValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UASTRT> Ncch_Update_Log(UASTRT uastrt,UASTRT oldUastrt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("UASTRT", uastrt.Id, global);
            var sonuc = new StandardResponse<UASTRT>();
            uastrt.SIRKID = global.SirketId.Value; 
            uastrt.DEKULL = global.UserKod;
            uastrt.DTARIH = DateTime.Now;
            uastrt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uastrtDal.Update(uastrt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UastrtValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UASTRT> Ncch_UpdateAktifPasif_Log(UASTRT uastrt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Edit" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
            var sonuc = new StandardResponse<UASTRT>();
            uastrt.SIRKID = global.SirketId.Value; 
            uastrt.ACTIVE = !uastrt.ACTIVE;
            uastrt.DEKULL = global.UserKod;
            uastrt.DTARIH = DateTime.Now;
            uastrt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uastrtDal.Update(uastrt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        [FluentValidationAspect(typeof(UastrtValidator))]
        [CacheRemoveAspect(typeof(MemoryCacheManager))]
        public StandardResponse<UASTRT> Ncch_Delete_Log(UASTRT uastrt, Global global)
        {
            var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "Delete" });
            if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
             _lockedService.LockControlWrite("UASTRT", uastrt.Id, global);
            var sonuc = new StandardResponse<UASTRT>();
            uastrt.SIRKID = global.SirketId.Value; 
            uastrt.ACTIVE = false;
            uastrt.SLINDI = true;
            uastrt.DEKULL = global.UserKod;
            uastrt.DTARIH = DateTime.Now;
            uastrt.KYNKKD = global.KaynakKod;
            sonuc.Nesne = _uastrtDal.Update(uastrt);
            sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #region ClientFunc

        [FluentValidationAspect(typeof(UastrtValidator))]
        public ListResponse<UASTRT> Ncch_UrunAgacStokRotaKaydet_Log(URAGAC uragac, List<string> operasyonList, Global global, bool yetkiKontrol = true)
        {
	        if (yetkiKontrol)
	        {
		        var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
		        if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
	        }
            string sql = "";
	        var sonuc = new ListResponse<UASTRT>();
	        sonuc.Items = new List<UASTRT>();
	        sonuc.Status = ResponseStatusEnum.ERROR;
            if ((bool)global.RenkBeden)
            {
                sql = @"DELETE FROM UASTRT WHERE URYRKD = @Uryrkd AND GNREZV = @Gnrezv AND URAKOD = @Urakod AND STKODU = @Stkodu 
						AND PARENT = @Parent AND CHILDD = @Childd AND SEVIYE = @Seviye AND SIRKID = @SirketId AND VRKODU = @Vrkodu";
                _uastrtDal.ExecuteSqlQuery(sql, new SqlParameter("@SirketId", global.SirketId), new SqlParameter("@Uryrkd", uragac.URYRKD),
                    new SqlParameter("@Gnrezv", uragac.GNREZV), new SqlParameter("@Urakod", uragac.URAKOD), new SqlParameter("@Stkodu", uragac.STKODU),
                    new SqlParameter("@Parent", uragac.PARENT), new SqlParameter("@Childd", uragac.CHILDD), new SqlParameter("@Seviye", uragac.SEVIYE),
                     new SqlParameter("@Vrkodu", uragac.VRKODU));

            }
            else
            {
                sql = @"DELETE FROM UASTRT WHERE URYRKD = @Uryrkd AND GNREZV = @Gnrezv AND URAKOD = @Urakod AND STKODU = @Stkodu 
						AND PARENT = @Parent AND CHILDD = @Childd AND SEVIYE = @Seviye AND SIRKID = @SirketId";
                _uastrtDal.ExecuteSqlQuery(sql, new SqlParameter("@SirketId", global.SirketId), new SqlParameter("@Uryrkd", uragac.URYRKD),
                    new SqlParameter("@Gnrezv", uragac.GNREZV), new SqlParameter("@Urakod", uragac.URAKOD), new SqlParameter("@Stkodu", uragac.STKODU),
                    new SqlParameter("@Parent", uragac.PARENT), new SqlParameter("@Childd", uragac.CHILDD), new SqlParameter("@Seviye", uragac.SEVIYE));

            }
             

            for (int i = 0; i < operasyonList.Count; i++)
	        {
		        UASTRT uastrt = new UASTRT();
		        uastrt.SIRKID = global.SirketId.Value;
		        uastrt.ACTIVE = true;
		        uastrt.SLINDI = false;
		        uastrt.EKKULL = global.UserKod;
		        uastrt.ETARIH = DateTime.Now;
		        uastrt.KYNKKD = global.KaynakKod;
		        uastrt.URYRKD = uragac.URYRKD;
		        uastrt.GNREZV = uragac.GNREZV;
		        uastrt.URAKOD = uragac.URAKOD;
		        uastrt.STKODU = uragac.STKODU;
		        uastrt.PARENT = uragac.PARENT;
		        uastrt.CHILDD = uragac.CHILDD.Value;
		        uastrt.SEVIYE = uragac.SEVIYE.Value;
		        uastrt.SIRANO = i + 1;
                uastrt.ISOPKD = operasyonList[i];
                uastrt.VRKODU = uragac.VRKODU;

                sonuc.Items.Add(_uastrtDal.Add(uastrt));
	        }

	        sonuc.Status = ResponseStatusEnum.OK;
	        return sonuc;
        }

        public ListResponse<UASTRT> Ncch_GetListByUrunAgacInfo_NLog(URAGAC uragac, Global global, bool yetkiKontrol = true)
        {
	        if (yetkiKontrol)
	        {
		        var yetki = _gnService.Ncch_GetListYetki_NLog(global, new[] { "View" });
		        if (yetki.Status != ResponseStatusEnum.OK) throw new BusinessException().FromMessageNo("0000", global);
	        }
	        var sonuc = new ListResponse<UASTRT>();
            if ((bool)global.RenkBeden)
            {
                sonuc.Items = _uastrtDal.GetList(x => x.URYRKD == uragac.URYRKD && x.GNREZV == uragac.GNREZV &&
                                                            x.URAKOD == uragac.URAKOD && x.STKODU == uragac.STKODU && x.PARENT == uragac.PARENT &&
                                                            x.CHILDD == uragac.CHILDD.Value && x.SEVIYE == uragac.SEVIYE &&
                                                            x.SIRKID == global.SirketId && x.ACTIVE && !x.SLINDI && x.VRKODU == uragac.VRKODU);
            }
            else
            {
                sonuc.Items = _uastrtDal.GetList(x => x.URYRKD == uragac.URYRKD && x.GNREZV == uragac.GNREZV &&
                                                            x.URAKOD == uragac.URAKOD && x.STKODU == uragac.STKODU && x.PARENT == uragac.PARENT &&
                                                            x.CHILDD == uragac.CHILDD.Value && x.SEVIYE == uragac.SEVIYE &&
                                                            x.SIRKID == global.SirketId && x.ACTIVE && !x.SLINDI);
            }
                
	        sonuc.Status = ResponseStatusEnum.OK;
            return sonuc;
        }

        #endregion ClientFunc
    }
}
