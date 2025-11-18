using System;
using System.Collections.Generic;
using Bps.Core.Response;
using Bps.Core.GlobalStaticsVariables;
using Bps.BpsBase.Entities.Concrete.WM;

#region ClientUsing

#endregion ClientUsing

namespace Bps.BpsBase.Business.Abstract.WM
{
    public interface IWmhratService
    {
        ListResponse<WMHRAT> Cch_GetAll_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMHRAT> Cch_GetList_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMHRAT> Cch_GetListPasif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMHRAT> Cch_GetListAktif_NLog(Global global, bool yetkiKontrol = true);
        ListResponse<WMHRAT> Cch_GetListSilinen_NLog(Global global, bool yetkiKontrol = true);
        //Lock işlemi yapılmıyor
        StandardResponse<WMHRAT> Cch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        //Lock var
        StandardResponse<WMHRAT> Ncch_GetById_NLog(int id, Global global, bool yetkiKontrol = true);
        StandardResponse<WMHRAT> Ncch_Add_NLog(WMHRAT wmhrat, Global global);
        StandardResponse<WMHRAT> Ncch_Update_Log(WMHRAT wmhrat,WMHRAT oldWmhrat, Global global);
        StandardResponse<WMHRAT> Ncch_UpdateAktifPasif_Log(WMHRAT wmhrat, Global global);
        StandardResponse<WMHRAT> Ncch_Delete_Log(WMHRAT wmhrat, Global global);

        #region ClientFunc

        StandardResponse<WMHRAT> Cch_GetByFisTip_NLog(int fisTip, Global global, bool yetkiKontrol = true);

        #endregion ClientFunc
    }
}
