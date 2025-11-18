using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.SH;
using Bps.BpsBase.Entities.Models.SP.Single;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.SH
{
    public interface IShsrvsService
    {
        ListResponse<SHSRVS> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SHSRVS> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SHSRVS> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SHSRVS> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<SHSRVS> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<SHSRVS> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<SHSRVS> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<SHSRVS> Ncch_Add_NLog(SHSRVS shsrvs, Global global);
        StandardResponse<SHSRVS> Ncch_Update_Log(SHSRVS shsrvs,SHSRVS oldShsrvs, Global global);
        StandardResponse<SHSRVS> Ncch_UpdateAktifPasif_Log(SHSRVS shsrvs, Global global);
        StandardResponse<SHSRVS> Ncch_Delete_Log(SHSRVS shsrvs, Global global);

        #region ClientFunc
        StandardResponse<SHSRVS> Ncch_GetByBelgeNo_NLog(string belgeNo, Global global, bool yetkiKontrol = true);
        ListResponse<SHSRVS> Ncch_GetList_NLog(Global global, bool yetkiKontrol = true);
        StandardResponse<SHSRVS> Ncch_UpdateFromApi_Log(SHSRVS shsrvs, SHSRVS oldShsrvs, Global global);
        ListResponse<SHSRVS> Cch_GetListByParam_NLog(SshParamModel param, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
