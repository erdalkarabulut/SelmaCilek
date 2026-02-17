using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.ST;
using Bps.Core.Aspects.Postsharp.CacheAspects;
using Bps.Core.CrossCuttingConcerns.Caching.Microsoft;
using Bps.Core.Aspects.Postsharp.ValidationAspects;
using Bps.BpsBase.Business.ValidationRules.FluentValidation.ST;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.ST
{
    public interface IStcrkdService
    {
        ListResponse<STCRKD> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STCRKD> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STCRKD> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STCRKD> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<STCRKD> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<STCRKD> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<STCRKD> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<STCRKD> Ncch_Add_NLog(STCRKD stcrkd, Global global);
        StandardResponse<STCRKD> Ncch_Update_Log(STCRKD stcrkd,STCRKD oldStcrkd, Global global);
        StandardResponse<STCRKD> Ncch_UpdateAktifPasif_Log(STCRKD stcrkd, Global global);
        StandardResponse<STCRKD> Ncch_Delete_Log(STCRKD stcrkd, Global global);

        #region ClientFunc
        ListResponse<STCRKD> Cch_GetListByStokKodu_NLog(string stokKodu, string vrykod, Global global, bool yetkiKontrol = true);
       
        StandardResponse Ncch_MultiAdd_Log(List<STCRKD> stcrkd, Global global, bool yetkiKontrol = true);
        StandardResponse<STCRKD> Ncch_GetByCRVRKO_NLog(string _crvrko, string _crkodu, Global global, bool yetkiKontrol = true);
        string Ncch_HardDelete_Log(string stkodu, Global global);
        #endregion ClientFunc
    }
}
